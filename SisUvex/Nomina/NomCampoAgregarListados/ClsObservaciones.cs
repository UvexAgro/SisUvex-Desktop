using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Nomina.NomCampoAgregarListados
{
	internal class ClsObservaciones
	{
		public FrmObservaciones frmO;
		public string idRegistroSeleccionado = "";
		private SQLControl sql = new SQLControl();

		public class DatosEstado
		{
			public string IdRegistro { get; set; }
			public DateTime Fecha { get; set; }
			public string IdStatus { get; set; }
			public string Observaciones { get; set; }
			public string Nota { get; set; } = "";
		}

		public void CargarCuadrillas()
		{
			string query = @"
			SELECT 
				id_workGroup,
				c_order,
				v_nameWorkGroup
			FROM dbo.Nom_WorkGroup
			WHERE c_active = 1
			ORDER BY
				CASE
					WHEN c_order IS NULL OR c_order = '' THEN 1
					ELSE 0
				END,
				c_order,
				id_workGroup";

			DataTable dt = new DataTable();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				{
					using (SqlDataAdapter da = new SqlDataAdapter(cmd))
					{
						da.Fill(dt);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al cargar las cuadrillas:\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				sql.CloseConectionWrite();
			}

			// Columna que se mostrará en el ComboBox
			dt.Columns.Add("Descripcion", typeof(string));

			foreach (DataRow row in dt.Rows)
			{
				string codigo = row["c_order"] == DBNull.Value ? "" : row["c_order"].ToString();

				string nombre = row["v_nameWorkGroup"].ToString();

				row["Descripcion"] =
					(string.IsNullOrWhiteSpace(codigo)
						? nombre
						: codigo + " - " + nombre);
			}

			// Agregar opción "Todos"
			DataRow rowTodos = dt.NewRow();

			rowTodos["id_workGroup"] = 000;
			rowTodos["c_order"] = "";
			rowTodos["v_nameWorkGroup"] = "SIN SELECCIONAR";
			rowTodos["Descripcion"] = "SIN SELECCIONAR";

			dt.Rows.InsertAt(rowTodos, 0);


			frmO.cboCuadrilla2.DataSource = dt.Copy();
			frmO.cboCuadrilla2.DisplayMember = "Descripcion";
			frmO.cboCuadrilla2.ValueMember = "id_workGroup";

			frmO.cboCuadrilla2.DropDownStyle = ComboBoxStyle.DropDown;
			frmO.cboCuadrilla2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			frmO.cboCuadrilla2.AutoCompleteSource = AutoCompleteSource.ListItems;

			frmO.cboCuadrilla2.SelectedIndex = -1;
			frmO.cboCuadrilla2.Text = "";
		}
		public void CargarEstados()
		{
			string query = @"
        SELECT 
            id_status,
            c_status
        FROM dbo.Cat_StatusCuadrilla
        ORDER BY c_status";

			DataTable dt = new DataTable();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				{
					using (SqlDataAdapter da = new SqlDataAdapter(cmd))
					{
						da.Fill(dt);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al cargar los estados:\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public void CargarEstadoCuadrillas(
	string sequencePer,
	DateTime fechaInicio,
	DateTime fechaFin)
		{
			DataTable dt = new DataTable();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"dbo.sp_GetEstadoDeCuadrillas",
					sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add(
						"@sequencePer",
						SqlDbType.Char,
						2
					).Value = sequencePer.Trim();

					cmd.Parameters.Add(
						"@fechaInicio",
						SqlDbType.Date
					).Value = fechaInicio.Date;

					cmd.Parameters.Add(
						"@fechaFin",
						SqlDbType.Date
					).Value = fechaFin.Date;

					using (SqlDataAdapter da = new SqlDataAdapter(cmd))
					{
						da.Fill(dt);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al validar las cuadrillas:\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return;
			}
			finally
			{
				sql.CloseConectionWrite();
			}

			CrearTablaEstado(dt, fechaInicio, fechaFin);
		}

		private void CrearTablaEstado(
	DataTable dt,
	DateTime fechaInicio,
	DateTime fechaFin)
		{
			frmO.dgvEstado.Columns.Clear();
			frmO.dgvEstado.Rows.Clear();

			frmO.dgvEstado.AutoGenerateColumns = false;

			// =====================================================
			// ID DE CUADRILLA
			// =====================================================

			DataGridViewTextBoxColumn colId =
				new DataGridViewTextBoxColumn();

			colId.Name = "id_workGroup";
			colId.Visible = false;

			frmO.dgvEstado.Columns.Add(colId);

			// =====================================================
			// CÓDIGO
			// =====================================================

			frmO.dgvEstado.Columns.Add(
				"Codigo",
				"Código");

			// =====================================================
			// CUADRILLA
			// =====================================================

			frmO.dgvEstado.Columns.Add(
				"Cuadrilla",
				"Cuadrilla");

			// =====================================================
			// DÍAS
			// =====================================================

			for (DateTime fecha = fechaInicio.Date;
				 fecha <= fechaFin.Date;
				 fecha = fecha.AddDays(1))
			{
				DataGridViewTextBoxColumn col =
					new DataGridViewTextBoxColumn();

				col.Name =
					"F_" + fecha.ToString("yyyyMMdd");

				col.HeaderText =
					fecha.ToString(
						"ddd",
						new CultureInfo("es-MX"))
					.ToUpper();

				// Guardar fecha real
				col.Tag = fecha;

				frmO.dgvEstado.Columns.Add(col);
			}

			// =====================================================
			// CUADRILLAS
			// =====================================================

			var cuadrillas =
				dt.AsEnumerable()
				  .GroupBy(r =>
					  r["id_workGroup"].ToString())
				  .ToList();

			foreach (var grupo in cuadrillas)
			{
				DataRow primera =
					grupo.First();

				int fila =
					frmO.dgvEstado.Rows.Add();

				DataGridViewRow row =
					frmO.dgvEstado.Rows[fila];

				// =================================================
				// ID CUADRILLA
				// =================================================

				row.Cells["id_workGroup"].Value =
					primera["id_workGroup"].ToString();

				// =================================================
				// CÓDIGO
				// =================================================

				row.Cells["Codigo"].Value =
					primera["c_order"] == DBNull.Value
						? ""
						: primera["c_order"].ToString();

				// =================================================
				// NOMBRE
				// =================================================

				row.Cells["Cuadrilla"].Value =
					primera["v_nameWorkGroup"] == DBNull.Value
						? ""
						: primera["v_nameWorkGroup"].ToString();

				// =================================================
				// ESTADO DE CADA DÍA
				// =================================================

				foreach (DataRow dato in grupo)
				{
					DateTime fecha =
						Convert.ToDateTime(dato["d_fecha"]);

					string columna =
						"F_" + fecha.ToString("yyyyMMdd");

					DataGridViewCell celda =
						row.Cells[columna];

					// Estado visible
					string estado =
						dato["Estado"] == DBNull.Value
							? ""
							: dato["Estado"].ToString();

					celda.Value = estado;

					// Información del registro y de la nota
					celda.Tag = new DatosEstado
					{
						IdRegistro = "",
						Fecha = fecha,
						IdStatus = "",

						Observaciones =
							dato["Observaciones"] == DBNull.Value
								? ""
								: dato["Observaciones"].ToString(),

						Nota =
							dato.Table.Columns.Contains("c_notas") &&
							dato["c_notas"] != DBNull.Value
								? dato["c_notas"].ToString()
								: ""
					};
				}
			}

			// =====================================================
			// ESTILO
			// =====================================================

			EstilizarDgvEstado();
			frmO.BeginInvoke(new Action(() =>
			{
				AjustarFilasAlAlto();
			}));
		}
		
		
		private void EstilizarDgvEstado()
		{
			DataGridView dgv = frmO.dgvEstado;

			// ==========================================
			// CONFIGURACIÓN GENERAL
			// ==========================================

			dgv.BackgroundColor = Color.White;

			dgv.BorderStyle =
				BorderStyle.None;

			dgv.GridColor =
				Color.FromArgb(190, 215, 240);

			dgv.CellBorderStyle =
				DataGridViewCellBorderStyle.Single;

			dgv.EnableHeadersVisualStyles =
				false;

			dgv.AllowUserToAddRows =
				false;

			dgv.AllowUserToDeleteRows =
				false;

			dgv.AllowUserToResizeRows =
				false;

			dgv.AllowUserToResizeColumns =
				false;

			dgv.ReadOnly =
				true;

			dgv.MultiSelect =
				false;

			// Permitir seleccionar varias celdas
			dgv.MultiSelect = true;

			dgv.SelectionMode =
				DataGridViewSelectionMode.CellSelect;

			dgv.RowHeadersVisible =
				false;


			// ==========================================
			// FUENTE
			// ==========================================

			dgv.Font =
				new Font(
					"Segoe UI",
					9F,
					FontStyle.Regular);


			// ==========================================
			// ENCABEZADO
			// ==========================================

			dgv.ColumnHeadersDefaultCellStyle.BackColor =
				Color.FromArgb(0, 102, 204);

			dgv.ColumnHeadersDefaultCellStyle.ForeColor =
				Color.White;

			dgv.ColumnHeadersDefaultCellStyle.Font =
				new Font(
					"Segoe UI",
					9F,
					FontStyle.Bold);

			dgv.ColumnHeadersDefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor =
				Color.FromArgb(0, 102, 204);

			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor =
				Color.White;

			dgv.ColumnHeadersHeight =
				34;

			dgv.ColumnHeadersHeightSizeMode =
				DataGridViewColumnHeadersHeightSizeMode.DisableResizing;


			// ==========================================
			// CELDAS
			// ==========================================

			dgv.DefaultCellStyle.BackColor =
				Color.White;

			dgv.DefaultCellStyle.ForeColor =
				Color.FromArgb(25, 55, 85);

			dgv.DefaultCellStyle.SelectionBackColor =
				Color.FromArgb(210, 230, 250);

			dgv.DefaultCellStyle.SelectionForeColor =
				Color.FromArgb(25, 55, 85);

			dgv.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.DefaultCellStyle.Padding =
				new Padding(3, 0, 3, 0);


			// ==========================================
			// FILAS ALTERNADAS
			// ==========================================

			dgv.AlternatingRowsDefaultCellStyle.BackColor =
				Color.FromArgb(232, 242, 252);

			dgv.AlternatingRowsDefaultCellStyle.ForeColor =
				Color.FromArgb(25, 55, 85);


			// ==========================================
			// ALTURA DE FILAS
			// ==========================================

			dgv.AutoSizeRowsMode =
				DataGridViewAutoSizeRowsMode.None;

			dgv.RowTemplate.Height =
				50;


			// ==========================================
			// AJUSTAR COLUMNAS AL ANCHO DE LA DGV
			// ==========================================

			dgv.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.Fill;


			// ==========================================
			// CÓDIGO
			// ==========================================

			if (dgv.Columns.Contains("Codigo"))
			{
				dgv.Columns["Codigo"].FillWeight =
					9;

				dgv.Columns["Codigo"]
					.DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleCenter;
			}


			// ==========================================
			// CUADRILLA
			// ==========================================

			if (dgv.Columns.Contains("Cuadrilla"))
			{
				dgv.Columns["Cuadrilla"].FillWeight =
					25;

				dgv.Columns["Cuadrilla"]
					.DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleLeft;
			}


			// ==========================================
			// DÍAS
			// ==========================================

			foreach (DataGridViewColumn col in dgv.Columns)
			{
				if (col.Name.StartsWith("F_"))
				{
					col.FillWeight =
						11;

					col.DefaultCellStyle.Alignment =
						DataGridViewContentAlignment.MiddleCenter;
				}
			}


			// ==========================================
			// OCULTAR ID
			// ==========================================

			if (dgv.Columns.Contains("id_workGroup"))
			{
				dgv.Columns["id_workGroup"].Visible =
					false;
			}


			// ==========================================
			// PINTAR ESTADOS
			// ==========================================

			dgv.CellPainting -=
				dgvEstado_CellPainting;

			dgv.CellPainting +=
				dgvEstado_CellPainting;


			// ==========================================
			// FORZAR ALTURA DE LAS FILAS EXISTENTES
			// ==========================================

			foreach (DataGridViewRow fila in dgv.Rows)
			{
				fila.Height = 50;
			}
		}
		public void AjustarFilasAlAlto()
		{
			DataGridView dgv = frmO.dgvEstado;

			if (dgv.Rows.Count == 0)
				return;

			int altoDisponible =
				dgv.ClientSize.Height -
				dgv.ColumnHeadersHeight;

			if (altoDisponible <= 0)
				return;

			int altoFila =
				altoDisponible / dgv.Rows.Count;

			foreach (DataGridViewRow fila in dgv.Rows)
			{
				fila.Height = altoFila;
			}
		}


		private void dgvEstado_CellPainting(
	object sender,
	DataGridViewCellPaintingEventArgs e)
		{
			if (e.RowIndex < 0 || e.ColumnIndex < 0)
				return;

			DataGridView dgv = sender as DataGridView;

			if (dgv == null)
				return;

			DataGridViewColumn columna =
				dgv.Columns[e.ColumnIndex];

			// Solo pintar las columnas de los días
			if (!columna.Name.StartsWith("F_"))
				return;

			string estado =
				Convert.ToString(e.Value)?.Trim().ToUpperInvariant() ?? "";

			bool seleccionada =
				(e.State & DataGridViewElementStates.Selected) != 0;

			// Obtener la nota guardada en el Tag
			DatosEstado datos =
				dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag
					as DatosEstado;

			bool tieneNota =
				datos != null &&
				!string.IsNullOrWhiteSpace(datos.Nota);

			Color fondo;
			Color texto;

			if (seleccionada)
			{
				fondo = Color.FromArgb(0, 80, 200);
				texto = Color.White;
			}
			else
			{
				switch (estado)
				{
					case "TERMINADA":
						fondo = Color.FromArgb(205, 239, 215);
						texto = Color.FromArgb(25, 115, 55);
						break;

					case "EN PROCESO":
						fondo = Color.FromArgb(255, 239, 190);
						texto = Color.FromArgb(150, 100, 0);
						break;

					case "PENDIENTE":
						fondo = Color.FromArgb(255, 215, 218);
						texto = Color.FromArgb(180, 40, 50);
						break;

					default:
						// Dejar que el DataGridView pinte normalmente
						// las celdas vacías que no están seleccionadas.
						if (!tieneNota)
						{
							e.Handled = false;
							return;
						}

						fondo = dgv.DefaultCellStyle.BackColor;
						texto = dgv.DefaultCellStyle.ForeColor;
						break;
				}
			}

			e.Handled = true;

			// Fondo
			using (SolidBrush brush = new SolidBrush(fondo))
			{
				e.Graphics.FillRectangle(brush, e.CellBounds);
			}

			// Borde
			using (Pen pen = new Pen(Color.FromArgb(180, 205, 225)))
			{
				e.Graphics.DrawRectangle(
					pen,
					e.CellBounds.X,
					e.CellBounds.Y,
					e.CellBounds.Width - 1,
					e.CellBounds.Height - 1);
			}

			// Texto del estado
			if (!string.IsNullOrWhiteSpace(estado))
			{
				TextRenderer.DrawText(
					e.Graphics,
					estado,
					new Font("Segoe UI", 8F, FontStyle.Bold),
					e.CellBounds,
					texto,
					TextFormatFlags.HorizontalCenter |
					TextFormatFlags.VerticalCenter |
					TextFormatFlags.NoPrefix);
			}

			// Triángulo rojo tipo Excel
			if (tieneNota)
			{
				int tamaño = 9;

				Point[] puntos =
				{
			new Point(
				e.CellBounds.Right - tamaño,
				e.CellBounds.Top),

			new Point(
				e.CellBounds.Right,
				e.CellBounds.Top),

			new Point(
				e.CellBounds.Right,
				e.CellBounds.Top + tamaño)
		};

				using (SolidBrush brush = new SolidBrush(Color.Red))
				{
					e.Graphics.FillPolygon(brush, puntos);
				}
			}
		}


		public bool GuardarNotaCuadrilla(
			string idCuadrilla,
			string secuenciaSemana,
			DateTime fechaInicio,
			DateTime fechaFin,
			DateTime fecha,
			string nota)
		{
			SqlTransaction transaccion = null;

			try
			{
				string notaLimpia = string.IsNullOrWhiteSpace(nota)
					? null
					: nota.Trim();

				sql.OpenConectionWrite();

				transaccion = sql.cnn.BeginTransaction(
					IsolationLevel.Serializable);

				string consulta = @"
            DECLARE @filas INT;

            -- 1. Actualizar el registro si ya existe.
            UPDATE dbo.Nom_WorkGroupStatus
            SET c_notas = @nota,
                v_userUpdate = @usuario,
                d_update = GETDATE()
            WHERE id_workGroup = @idCuadrilla
              AND c_sequence_per = @secuenciaSemana
              AND d_startDate_per = @fechaInicio
              AND d_endDate_per = @fechaFin
              AND d_fecha = @fecha;

            SET @filas = @@ROWCOUNT;

            -- 2. Si no existe, crear registro solo
            -- cuando se haya escrito una nota.
            IF @filas = 0 AND @nota IS NOT NULL
            BEGIN
                DECLARE @nuevoId INT;

                SELECT @nuevoId =
                    ISNULL(
                        MAX(TRY_CONVERT(INT, id_Registro)),
                        0
                    ) + 1
                FROM dbo.Nom_WorkGroupStatus
                    WITH (UPDLOCK, HOLDLOCK);

                IF @nuevoId > 999
                    THROW 50001,
                        'Se agotaron los identificadores de tres dígitos.',
                        1;

                INSERT INTO dbo.Nom_WorkGroupStatus
                (
                    id_Registro,
                    id_Status,
                    id_workGroup,
                    c_sequence_per,
                    d_startDate_per,
                    d_endDate_per,
                    d_fecha,
                    c_observaciones,
                    c_notas,
                    v_userCreate,
                    d_create
                )
                VALUES
                (
                    RIGHT(
                        '000' + CAST(@nuevoId AS VARCHAR(3)),
                        3
                    ),
                    'PEN',
                    @idCuadrilla,
                    @secuenciaSemana,
                    @fechaInicio,
                    @fechaFin,
                    @fecha,
                    NULL,
                    @nota,
                    @usuario,
                    GETDATE()
                );
					END;";

				using (SqlCommand comando =
					new SqlCommand(consulta, sql.cnn, transaccion))
				{
					comando.Parameters.Add(
						"@idCuadrilla", SqlDbType.Char, 3).Value =
						idCuadrilla.Trim();

					comando.Parameters.Add(
						"@secuenciaSemana", SqlDbType.Char, 2).Value =
						secuenciaSemana.Trim();

					comando.Parameters.Add(
						"@fechaInicio", SqlDbType.Date).Value =
						fechaInicio.Date;

					comando.Parameters.Add(
						"@fechaFin", SqlDbType.Date).Value =
						fechaFin.Date;

					comando.Parameters.Add(
						"@fecha", SqlDbType.Date).Value =
						fecha.Date;

					comando.Parameters.Add(
						"@nota", SqlDbType.NVarChar, -1).Value =
						(object)notaLimpia ?? DBNull.Value;

					comando.Parameters.Add(
						"@usuario", SqlDbType.VarChar, 50).Value =
						Environment.UserName;

					comando.ExecuteNonQuery();
				}

				transaccion.Commit();
				return true;
			}
			catch (Exception ex)
			{
				try
				{
					transaccion?.Rollback();
				}
				catch
				{
					// La transacción podría haberse cerrado.
				}

				MessageBox.Show(
					"No se pudo guardar la nota.\n\nDetalle: "
					+ ex.Message,
					"Error al guardar",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return false;
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}


		public bool GuardarTerminadasSeleccionadas(List<DataGridViewCell> celdas)
		{
			if (celdas == null || celdas.Count == 0)
				return false;

			string secuencia = frmO.txbSemana.Text.Trim();
			DateTime inicio = frmO.dtpInicio.Value.Date;
			DateTime fin = frmO.dtpFinal.Value.Date;

			SqlTransaction transaccion = null;

			try
			{
				sql.OpenConectionWrite();

				transaccion = sql.cnn.BeginTransaction();

				string consulta = @"
				IF EXISTS
				(
					SELECT 1
					FROM dbo.Nom_WorkGroupStatus WITH (UPDLOCK, HOLDLOCK)
					WHERE id_workGroup = @id_workGroup
					  AND c_sequence_per = @secuencia
					  AND d_startDate_per = @inicio
					  AND d_endDate_per = @fin
					  AND d_fecha = @fecha
				)
				BEGIN
					UPDATE dbo.Nom_WorkGroupStatus
					SET id_Status = 'TER',
						v_userUpdate = @usuario,
						d_update = GETDATE()
					WHERE id_workGroup = @id_workGroup
					  AND c_sequence_per = @secuencia
					  AND d_startDate_per = @inicio
					  AND d_endDate_per = @fin
					  AND d_fecha = @fecha;
				END
				ELSE
				BEGIN
					DECLARE @nuevoId CHAR(3);

					SELECT @nuevoId =
						RIGHT(
							'000' + CAST(
								ISNULL(MAX(TRY_CONVERT(INT, id_Registro)), 0) + 1
								AS VARCHAR(3)
							),
							3
						)
					FROM dbo.Nom_WorkGroupStatus WITH (UPDLOCK, HOLDLOCK);

					IF TRY_CONVERT(INT, @nuevoId) IS NULL
						THROW 50001, 'No se pudo generar el identificador.', 1;

					INSERT INTO dbo.Nom_WorkGroupStatus
					(
						id_Registro,
						id_Status,
						id_workGroup,
						c_sequence_per,
						d_startDate_per,
						d_endDate_per,
						d_fecha,
						c_observaciones,
						v_userCreate,
						d_create
					)
					VALUES
					(
						@nuevoId,
						'TER',
						@id_workGroup,
						@secuencia,
						@inicio,
						@fin,
						@fecha,
						NULL,
						@usuario,
						GETDATE()
					);
				END;";

				foreach (DataGridViewCell celda in celdas)
				{
					string idCuadrilla =
						frmO.dgvEstado.Rows[celda.RowIndex]
							.Cells["id_workGroup"].Value?.ToString();

					DateTime fecha =
						Convert.ToDateTime(
							frmO.dgvEstado.Columns[celda.ColumnIndex].Tag);

					using (SqlCommand cmd =
						new SqlCommand(consulta, sql.cnn, transaccion))
					{
						cmd.Parameters.Add(
							"@id_workGroup", SqlDbType.Char, 3).Value =
							idCuadrilla;

						cmd.Parameters.Add(
							"@secuencia", SqlDbType.Char, 2).Value =
							secuencia;

						cmd.Parameters.Add(
							"@inicio", SqlDbType.Date).Value = inicio;

						cmd.Parameters.Add(
							"@fin", SqlDbType.Date).Value = fin;

						cmd.Parameters.Add(
							"@fecha", SqlDbType.Date).Value = fecha;

						cmd.Parameters.Add(
							"@usuario", SqlDbType.VarChar, 50).Value =
							Environment.UserName;

						cmd.ExecuteNonQuery();
					}
				}

				transaccion.Commit();

				CargarEstadoCuadrillas(secuencia, inicio, fin);

				return true;
			}
			catch (Exception ex)
			{
				try
				{
					transaccion?.Rollback();
				}
				catch
				{
					// La transacción podría haberse cerrado.
				}

				MessageBox.Show(
					"Error al guardar las terminaciones:\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return false;
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public bool EliminarNotaCuadrilla(
	string idCuadrilla,
	string secuenciaSemana,
	DateTime fechaInicio,
	DateTime fechaFin,
	DateTime fecha)
		{
			try
			{
				sql.OpenConectionWrite();

				string consulta = @"
            UPDATE dbo.Nom_WorkGroupStatus
            SET c_notas = NULL,
                v_userUpdate = @usuario,
                d_update = GETDATE()
            WHERE id_workGroup = @idCuadrilla
              AND c_sequence_per = @secuenciaSemana
              AND d_startDate_per = @fechaInicio
              AND d_endDate_per = @fechaFin
              AND d_fecha = @fecha;";

				using (SqlCommand cmd = new SqlCommand(consulta, sql.cnn))
				{
					cmd.Parameters.Add("@idCuadrilla", SqlDbType.Char, 3).Value =
						idCuadrilla;

					cmd.Parameters.Add("@secuenciaSemana", SqlDbType.Char, 2).Value =
						secuenciaSemana;

					cmd.Parameters.Add("@fechaInicio", SqlDbType.Date).Value =
						fechaInicio.Date;

					cmd.Parameters.Add("@fechaFin", SqlDbType.Date).Value =
						fechaFin.Date;

					cmd.Parameters.Add("@fecha", SqlDbType.Date).Value =
						fecha.Date;

					cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value =
						Environment.UserName;

					return cmd.ExecuteNonQuery() > 0;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al eliminar la nota:\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return false;
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
	}
}
