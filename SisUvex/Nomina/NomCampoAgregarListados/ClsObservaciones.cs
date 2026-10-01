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

			// Cargar ComboBox
			frmO.cboEstado.DataSource = dt;

			// Lo que se muestra
			frmO.cboEstado.DisplayMember = "c_status";

			// Lo que realmente devuelve
			frmO.cboEstado.ValueMember = "id_status";

			frmO.cboEstado.SelectedIndex = -1;
		}
		public void CargarEstadoCuadrillas(
	string sequencePer,
	DateTime fechaInicio,
	DateTime fechaFin)
		{
			DataTable dt = new DataTable();

			string query = @"
			SELECT
				WG.id_workGroup,
				WG.c_order,
				WG.v_nameWorkGroup,
				D.d_fecha,
				S.id_Registro,
				S.id_Status,
				CS.c_status,
				S.c_observaciones
			FROM dbo.Nom_WorkGroup WG
			CROSS JOIN
			(
				SELECT DATEADD(DAY, N, @fechaInicio) AS d_fecha
				FROM
				(
					SELECT TOP (DATEDIFF(DAY, @fechaInicio, @fechaFin) + 1)
						ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS N
					FROM sys.objects
				) X
			) D
			LEFT JOIN dbo.Nom_WorkGroupStatus S
				ON S.id_workGroup = WG.id_workGroup
				AND S.d_fecha = D.d_fecha
				AND S.c_sequence_per = @sequencePer
			LEFT JOIN dbo.Cat_StatusCuadrilla CS
				ON CS.id_status = S.id_Status
			WHERE WG.c_active = 1
			ORDER BY
				CASE
					WHEN WG.c_order IS NULL OR WG.c_order = '' THEN 1
					ELSE 0
				END,
				WG.c_order,
				WG.id_workGroup,
				D.d_fecha;";

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd =
					new SqlCommand(query, sql.cnn))
				{
					cmd.Parameters.AddWithValue(
						"@sequencePer",
						sequencePer);

					cmd.Parameters.AddWithValue(
						"@fechaInicio",
						fechaInicio.Date);

					cmd.Parameters.AddWithValue(
						"@fechaFin",
						fechaFin.Date);

					using (SqlDataAdapter da =
						new SqlDataAdapter(cmd))
					{
						da.Fill(dt);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al cargar el estado de las cuadrillas:\n" +
					ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				sql.CloseConectionWrite();
			}

			CrearTablaEstado(
				dt,
				fechaInicio,
				fechaFin);
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
						Convert.ToDateTime(
							dato["d_fecha"]);

					string columna =
						"F_" +
						fecha.ToString("yyyyMMdd");

					DataGridViewCell celda =
						row.Cells[columna];

					// Estado visible
					string estado =
						dato["c_status"] == DBNull.Value
							? ""
							: dato["c_status"].ToString();

					celda.Value = estado;

					// =================================================
					// INFORMACIÓN DEL REGISTRO
					// =================================================

					celda.Tag = new DatosEstado
					{
						IdRegistro =
							dato["id_Registro"] == DBNull.Value
								? ""
								: dato["id_Registro"].ToString(),

						Fecha = fecha,

						IdStatus =
							dato["id_Status"] == DBNull.Value
								? ""
								: dato["id_Status"].ToString(),

						Observaciones =
							dato["c_observaciones"] == DBNull.Value
								? ""
								: dato["c_observaciones"].ToString()
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
		public bool GuardarEstadoCuadrilla()
		{
			if (frmO.cboCuadrilla2.SelectedIndex == -1 ||
				frmO.cboCuadrilla2.SelectedValue == null)
			{
				MessageBox.Show(
					"Seleccione una cuadrilla.",
					"Aviso",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return false;
			}

			if (frmO.cboDia.SelectedIndex == -1)
			{
				MessageBox.Show(
					"Seleccione un día.",
					"Aviso",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return false;
			}

			if (frmO.cboEstado.SelectedIndex == -1 ||
				frmO.cboEstado.SelectedValue == null)
			{
				MessageBox.Show(
					"Seleccione un estado.",
					"Aviso",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return false;
			}

			string idWorkGroup =
				frmO.cboCuadrilla2.SelectedValue.ToString();

			string idStatus =
				frmO.cboEstado.SelectedValue.ToString();

			string sequencePer =
				frmO.txbSemana.Text.Trim();

			DateTime fechaInicio =
				frmO.dtpInicio.Value.Date;

			DateTime fechaFin =
				frmO.dtpFinal.Value.Date;

			// El índice representa el día de la semana
			DateTime fecha =
				fechaInicio.AddDays(frmO.cboDia.SelectedIndex);

			string observaciones =
				frmO.txbObservaciones.Text.Trim();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"sp_AddWorkGroupStatus",
					sql.cnn))
				{
					cmd.CommandType =
						CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(
						"@id_Registro",
						ObtenerNuevoIdRegistro());

					cmd.Parameters.AddWithValue(
						"@id_Status",
						idStatus);

					cmd.Parameters.AddWithValue(
						"@id_workGroup",
						idWorkGroup);

					cmd.Parameters.AddWithValue(
						"@c_sequence_per",
						sequencePer);

					cmd.Parameters.AddWithValue(
						"@d_startDate_per",
						fechaInicio);

					cmd.Parameters.AddWithValue(
						"@d_endDate_per",
						fechaFin);

					cmd.Parameters.AddWithValue(
						"@d_fecha",
						fecha);

					cmd.Parameters.AddWithValue(
						"@c_observaciones",
						string.IsNullOrWhiteSpace(observaciones)
							? (object)DBNull.Value
							: observaciones);

					cmd.Parameters.AddWithValue(
						"@v_userCreate",
						Environment.UserName);

					cmd.ExecuteNonQuery();
				}

				MessageBox.Show(
					"Registro guardado correctamente.",
					"Guardado",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);


				CargarEstadoCuadrillas(
				sequencePer,
				fechaInicio,
				fechaFin);

				// Guardado correctamente
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al guardar el estado:\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				// No se guardó
				return false;
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		private string ObtenerNuevoIdRegistro()
		{
			string query = @"
        SELECT RIGHT(
            '000' +
            CAST(
                ISNULL(
                    MAX(CAST(id_Registro AS INT)),
                    0
                ) + 1
                AS VARCHAR(3)
            ),
            3
        )
        FROM dbo.Nom_WorkGroupStatus";

			using (SqlCommand cmd =
				   new SqlCommand(query, sql.cnn))
			{
				return cmd.ExecuteScalar().ToString();
			}
		}
		public bool ModificarEstadoCuadrilla()
		{
			if (string.IsNullOrWhiteSpace(idRegistroSeleccionado))
			{
				MessageBox.Show(
					"Seleccione un registro para modificar.",
					"Aviso",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return false;
			}

			if (frmO.cboEstado.SelectedIndex == -1 ||
				frmO.cboEstado.SelectedValue == null)
			{
				MessageBox.Show(
					"Seleccione un estado.",
					"Aviso",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return false;
			}

			string idStatus =
				frmO.cboEstado.SelectedValue.ToString();

			string observaciones =
				frmO.txbObservaciones.Text.Trim();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"sp_UpdateWorkGroupStatus",
					sql.cnn))
				{
					cmd.CommandType =
						CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(
						"@id_Registro",
						idRegistroSeleccionado);

					cmd.Parameters.AddWithValue(
						"@id_Status",
						idStatus);

					cmd.Parameters.AddWithValue(
						"@c_observaciones",
						string.IsNullOrWhiteSpace(observaciones)
							? (object)DBNull.Value
							: observaciones);

					cmd.Parameters.AddWithValue(
						"@v_userUpdate",
						Environment.UserName);

					cmd.ExecuteNonQuery();
				}

				MessageBox.Show(
					"Registro modificado correctamente.",
					"Modificado",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				// ==========================================
				// RECARGAR TABLA
				// ==========================================

				CargarEstadoCuadrillas(
					frmO.txbSemana.Text.Trim(),
					frmO.dtpInicio.Value,
					frmO.dtpFinal.Value);

				// Modificación correcta
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al modificar el registro:\n" +
					ex.Message,
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

			// SOLO SELECCIONA UNA CELDA
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
				e.Value?.ToString()?.Trim().ToUpper();

			if (string.IsNullOrWhiteSpace(estado))
				return;

			Color fondo;
			Color texto;

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
					return;
			}

			e.Handled = true;

			// Pintar fondo de la celda
			using (SolidBrush brush =
				new SolidBrush(fondo))
			{
				e.Graphics.FillRectangle(
					brush,
					e.CellBounds);
			}

			// Borde de la celda
			using (Pen pen =
				new Pen(Color.FromArgb(180, 205, 225)))
			{
				e.Graphics.DrawRectangle(
					pen,
					e.CellBounds.X,
					e.CellBounds.Y,
					e.CellBounds.Width - 1,
					e.CellBounds.Height - 1);
			}

			// Texto
			TextRenderer.DrawText(
				e.Graphics,
				estado,
				new Font(
					"Segoe UI",
					8F,
					FontStyle.Bold),
				e.CellBounds,
				texto,
				TextFormatFlags.HorizontalCenter |
				TextFormatFlags.VerticalCenter |
				TextFormatFlags.NoPrefix);
		}
		
	}
}