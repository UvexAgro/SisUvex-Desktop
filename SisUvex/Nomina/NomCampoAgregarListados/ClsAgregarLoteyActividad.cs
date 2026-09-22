using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static SisUvex.Nomina.NomCampoAgregarListados.ClsAgregar;
using static SisUvex.Nomina.NomCampoAgregarListados.FrmAgregarLoteyActividad;
using static SisUvex.Nomina.NomCampoAgregarListados.FrmAsistencia;

namespace SisUvex.Nomina.NomCampoAgregarListados
{
	public class ClsAgregarLoteyActividad
	{
		private bool todosSeleccionados = false;
		private bool eventosSeleccionConfigurados = false;
		public FrmAgregarLoteyActividad frmCAL;
		public bool cargandoCultivos = false;
		public void CargarDiasRegistro(DateTime fechaInicio)
		{
			frmCAL.cboFecha.Items.Clear();

			frmCAL.cboFecha.Items.Add(
				new DiaRegistro { Nombre = "VIERNES", Fecha = fechaInicio });

			frmCAL.cboFecha.Items.Add(
				new DiaRegistro { Nombre = "SÁBADO", Fecha = fechaInicio.AddDays(1) });

			frmCAL.cboFecha.Items.Add(
				new DiaRegistro { Nombre = "DOMINGO", Fecha = fechaInicio.AddDays(2) });

			frmCAL.cboFecha.Items.Add(
				new DiaRegistro { Nombre = "LUNES", Fecha = fechaInicio.AddDays(3) });

			frmCAL.cboFecha.Items.Add(
				new DiaRegistro { Nombre = "MARTES", Fecha = fechaInicio.AddDays(4) });

			frmCAL.cboFecha.Items.Add(
				new DiaRegistro { Nombre = "MIÉRCOLES", Fecha = fechaInicio.AddDays(5) });

			frmCAL.cboFecha.Items.Add(
				new DiaRegistro { Nombre = "JUEVES", Fecha = fechaInicio.AddDays(6) });

			frmCAL.cboFecha.DisplayMember = "Texto";
			frmCAL.cboFecha.SelectedIndex = -1;
		}
		public DataTable CargarCultivos()
		{
			SQLControl sql = new SQLControl();
			DataTable dt = new DataTable();

			string query = @"
        SELECT
            id_crop,
            v_nameCrop,
            v_nameCropEsp,
            i_priority
        FROM dbo.Pack_Crop
        WHERE NULLIF(LTRIM(RTRIM(v_nameCropEsp)), '') IS NOT NULL
        ORDER BY
            TRY_CONVERT(INT, i_priority) ASC,
            v_nameCropEsp ASC;";

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd =
					   new SqlCommand(query, sql.cnn))
				{
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
					"Error al cargar los cultivos: " + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				sql.CloseConectionWrite();
			}

			return dt;
		}
		public void CargarComboCultivos()
		{
			try
			{
				cargandoCultivos = true;

				DataTable dtCultivos = CargarCultivos();

				frmCAL.cboCultivo.DataSource = null;

				frmCAL.cboCultivo.DisplayMember =
					"v_nameCropEsp";

				frmCAL.cboCultivo.ValueMember =
					"id_crop";

				frmCAL.cboCultivo.DataSource =
					dtCultivos;

				if (dtCultivos.Rows.Count > 0)
				{
					DataRow[] cultivoPrioridad =
						dtCultivos.Select("i_priority = '1'");

					if (cultivoPrioridad.Length > 0)
					{
						frmCAL.cboCultivo.SelectedValue =
							cultivoPrioridad[0]["id_crop"].ToString();
					}
					else
					{
						frmCAL.cboCultivo.SelectedIndex = 0;
					}
				}
				else
				{
					frmCAL.cboCultivo.SelectedIndex = -1;
					frmCAL.cboCultivo.Text = "";
				}
			}
			finally
			{
				cargandoCultivos = false;
			}

			// Cargar los lotes del cultivo seleccionado
			CargarLotesDelCultivoSeleccionado();
		}
		public DataTable ObtenerLotes(string idCrop)
		{
			SQLControl sql = new SQLControl();
			DataTable dt = new DataTable();

			try
			{
				sql.OpenConectionWrite();

				string query = @"
            SELECT
                L.id_lot,
                L.c_codigo_lot,
                L.v_nameLot,
                L.id_variety,
                V.v_nameComercial AS NombreVariedad,
                C.id_crop,
                C.v_nameCropEsp,
                C.i_priority
            FROM dbo.Pack_Lot AS L
            INNER JOIN dbo.Pack_Variety AS V
                ON L.id_variety = V.id_variety
            INNER JOIN dbo.Pack_Crop AS C
                ON V.id_crop = C.id_crop
            WHERE L.c_active = '1'
              AND C.id_crop = @id_crop
              AND NULLIF(
                    LTRIM(RTRIM(L.c_codigo_lot)), ''
                  ) IS NOT NULL
            ORDER BY
                TRY_CONVERT(INT, C.i_priority) ASC,
                C.v_nameCropEsp ASC,
                L.c_codigo_lot ASC;";

				using (SqlCommand cmd =
					   new SqlCommand(query, sql.cnn))
				{
					cmd.Parameters.Add(
						"@id_crop",
						SqlDbType.Char,
						2).Value = idCrop.Trim();

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
					"Error al obtener los lotes:\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				sql.CloseConectionWrite();
			}

			return dt;
		}
		public void CargarComboLotes(string idCrop)
		{
			if (string.IsNullOrWhiteSpace(idCrop))
			{
				frmCAL.cboLote.DataSource = null;
				frmCAL.cboLote.Text = "";

				frmCAL.dtLotesDgv = new DataTable();

				return;
			}

			DataTable dtLotes = ObtenerLotes(idCrop);

			if (!dtLotes.Columns.Contains("LoteCompleto"))
			{
				dtLotes.Columns.Add(
					"LoteCompleto",
					typeof(string));
			}

			foreach (DataRow row in dtLotes.Rows)
			{
				row["LoteCompleto"] =
					row["c_codigo_lot"].ToString() +
					" - " +
					row["v_nameLot"].ToString() +
					" - " +
					row["NombreVariedad"].ToString();
			}

			// ==========================================
			// GUARDAR LOS LOTES PARA EL DGV
			// ==========================================

			frmCAL.dtLotesDgv = dtLotes;

			// ==========================================
			// COMBO SUPERIOR DE LOTE
			// ==========================================

			frmCAL.cboLote.DataSource = null;

			frmCAL.cboLote.DisplayMember =
				"LoteCompleto";

			frmCAL.cboLote.ValueMember =
				"id_lot";

			frmCAL.cboLote.DataSource =
				dtLotes;

			frmCAL.cboLote.DropDownStyle =
				ComboBoxStyle.DropDown;

			frmCAL.cboLote.AutoCompleteMode =
				AutoCompleteMode.SuggestAppend;

			frmCAL.cboLote.AutoCompleteSource =
				AutoCompleteSource.ListItems;

			frmCAL.cboLote.SelectedIndex = -1;
			frmCAL.cboLote.Text = "";

			// ==========================================
			// ACTUALIZAR LOTE DEL DGV
			// ==========================================

			frmCAL.ConfigurarLoteDgv();
		}
		public void CargarLotesDelCultivoSeleccionado()
		{
			if (frmCAL.cboCultivo.SelectedIndex < 0)
				return;

			if (frmCAL.cboCultivo.SelectedValue == null)
				return;

			string idCrop =
				frmCAL.cboCultivo.SelectedValue
				.ToString()
				.Trim();

			if (string.IsNullOrWhiteSpace(idCrop))
				return;

			// ==========================================
			// LIMPIAR LOTES ACTUALES
			// ==========================================

			foreach (DataGridViewRow fila in frmCAL.dgvAgregarLoteyActividad.Rows)
			{
				if (fila.IsNewRow)
					continue;

				if (fila.Cells["Lote"] != null)
				{
					fila.Cells["Lote"].Value = null;
				}
			}

			// ==========================================
			// CARGAR LOTES DEL NUEVO CULTIVO
			// ==========================================

			CargarComboLotes(idCrop);
		}
		public DataTable ObtenerActividades()
		{
			SQLControl sql = new SQLControl();
			DataTable dt = new DataTable();
			try
			{
				sql.OpenConectionWrite();

				string query = @"
				SELECT c_codigo_tab, v_descripcion_tab 
				FROM dbo.Nom_Tabulador
				ORDER BY c_codigo_tab";

				SqlCommand cmd = new SqlCommand(query, sql.cnn);

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(dt);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				sql.CloseConectionWrite();
			}

			return dt;
		}

		public void CargarEmpleadosSeleccionados()
		{
			frmCAL.dgvAgregarLoteyActividad.Rows.Clear();

			if (frmCAL.EmpleadosSeleccionados == null ||
				frmCAL.EmpleadosSeleccionados.Count == 0)
			{
				return;
			}

			foreach (FrmAsistencia.EmpleadoSeleccionado empleado
					 in frmCAL.EmpleadosSeleccionados)
			{
				int fila =
					frmCAL.dgvAgregarLoteyActividad.Rows.Add();

				frmCAL.dgvAgregarLoteyActividad.Rows[fila]
					.Cells["Codigo"]
					.Value = empleado.Codigo;

				frmCAL.dgvAgregarLoteyActividad.Rows[fila]
					.Cells["Empleado"]
					.Value = empleado.Nombre;

				// NO poner valores en Actividad ni Lote
			}
		}
		public void DiseñarDgvEmpleados()
		{
			frmCAL.dgvAgregarLoteyActividad.Columns.Clear();

			frmCAL.dgvAgregarLoteyActividad.AutoGenerateColumns = false;
			frmCAL.dgvAgregarLoteyActividad.AllowUserToAddRows = false;
			frmCAL.dgvAgregarLoteyActividad.ReadOnly = false;

			frmCAL.dgvAgregarLoteyActividad.SelectionMode =
			DataGridViewSelectionMode.CellSelect;

			frmCAL.dgvAgregarLoteyActividad.MultiSelect = false;

			// =========================================
			// CÓDIGO
			// =========================================

			DataGridViewTextBoxColumn codigo =
				new DataGridViewTextBoxColumn();

			codigo.Name = "Codigo";
			codigo.HeaderText = "Código";
			codigo.ReadOnly = true;

			frmCAL.dgvAgregarLoteyActividad.Columns.Add(codigo);

			// =========================================
			// EMPLEADO
			// =========================================

			DataGridViewTextBoxColumn empleado =
				new DataGridViewTextBoxColumn();

			empleado.Name = "Empleado";
			empleado.HeaderText = "Empleado";
			empleado.ReadOnly = true;

			frmCAL.dgvAgregarLoteyActividad.Columns.Add(empleado);
			// =========================================
			// ACTIVIDAD ANTERIOR
			// =========================================

			DataGridViewTextBoxColumn actividadAnterior =
				new DataGridViewTextBoxColumn();

			actividadAnterior.Name =
				"ActividadAnterior";

			actividadAnterior.HeaderText =
				"Actividad anterior";

			actividadAnterior.ReadOnly = true;

			frmCAL.dgvAgregarLoteyActividad.Columns.Add(
				actividadAnterior);

			// =========================================
			// ACTIVIDAD
			// =========================================

			DataGridViewTextBoxColumn actividad =
				new DataGridViewTextBoxColumn();

			actividad.Name = "Actividad";
			actividad.HeaderText = "Actividad";

			actividad.ReadOnly = true;

			frmCAL.dgvAgregarLoteyActividad.Columns.Add(actividad);
			// =========================================
			// LOTE
			// =========================================

			DataGridViewComboBoxColumn lote =
				new DataGridViewComboBoxColumn();

			lote.Name = "Lote";
			lote.HeaderText = "Lote";

			lote.FlatStyle = FlatStyle.Flat;

			lote.DisplayStyle =
				DataGridViewComboBoxDisplayStyle.DropDownButton;

			lote.ReadOnly = false;

			frmCAL.dgvAgregarLoteyActividad.Columns.Add(lote);

			frmCAL.dgvAgregarLoteyActividad.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.Fill;
		}
		public void ConfigurarSeleccionEmpleados()
		{
			DataGridView dgv = frmCAL.dgvAgregarLoteyActividad;

			if (dgv == null)
				return;

			// =====================================================
			// CREAR COLUMNA SELECCIONAR
			// =====================================================

			if (!dgv.Columns.Contains("Seleccionar"))
			{
				DataGridViewCheckBoxColumn columnaSeleccionar =
					new DataGridViewCheckBoxColumn();

				columnaSeleccionar.Name = "Seleccionar";
				columnaSeleccionar.HeaderText = "✓";
				columnaSeleccionar.Width = 25;
				columnaSeleccionar.MinimumWidth = 25;
				columnaSeleccionar.ReadOnly = false;
				columnaSeleccionar.Resizable =
					DataGridViewTriState.False;

				columnaSeleccionar.AutoSizeMode =
					DataGridViewAutoSizeColumnMode.None;

				columnaSeleccionar.FlatStyle =
					FlatStyle.Standard;

				columnaSeleccionar.DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleCenter;

				columnaSeleccionar.DefaultCellStyle.NullValue =
					false;

				dgv.Columns.Insert(0, columnaSeleccionar);
			}

			// =====================================================
			// COLORES
			// =====================================================

			Color colorEncabezado =
				Color.FromArgb(22, 32, 45);

			Color colorSeleccion =
				Color.FromArgb(190, 215, 240);

			// =====================================================
			// DISEÑO GENERAL
			// =====================================================

			dgv.EnableHeadersVisualStyles = false;

			dgv.ColumnHeadersDefaultCellStyle.BackColor =
				colorEncabezado;

			dgv.ColumnHeadersDefaultCellStyle.ForeColor =
				Color.White;

			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor =
				colorEncabezado;

			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor =
				Color.White;

			dgv.ColumnHeadersDefaultCellStyle.Font =
				new Font("Segoe UI", 9F, FontStyle.Bold);

			dgv.ColumnHeadersDefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.ColumnHeadersHeight = 35;

			// =====================================================
			// DISEÑO DE FILAS
			// =====================================================

			dgv.DefaultCellStyle.BackColor =
				Color.White;

			dgv.DefaultCellStyle.ForeColor =
				Color.FromArgb(30, 30, 30);

			dgv.DefaultCellStyle.SelectionBackColor =
				colorSeleccion;

			dgv.DefaultCellStyle.SelectionForeColor =
				Color.FromArgb(30, 30, 30);

			dgv.AlternatingRowsDefaultCellStyle.BackColor =
				Color.FromArgb(245, 247, 249);

			dgv.RowTemplate.Height = 25;
			dgv.RowHeadersVisible = false;
			dgv.AllowUserToResizeRows = false;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;

			// =====================================================
			// ESTILO DE LA COLUMNA SELECCIONAR
			// =====================================================

			DataGridViewCheckBoxColumn chkSeleccionar =
				dgv.Columns["Seleccionar"]
				as DataGridViewCheckBoxColumn;

			if (chkSeleccionar != null)
			{
				chkSeleccionar.HeaderCell.Style.BackColor =
					colorEncabezado;

				chkSeleccionar.HeaderCell.Style.ForeColor =
					Color.White;

				chkSeleccionar.HeaderCell.Style.SelectionBackColor =
					colorEncabezado;

				chkSeleccionar.HeaderCell.Style.SelectionForeColor =
					Color.White;

				chkSeleccionar.DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleCenter;

				chkSeleccionar.DefaultCellStyle.BackColor =
					Color.White;

				chkSeleccionar.DefaultCellStyle.SelectionBackColor =
					colorSeleccion;

				chkSeleccionar.DefaultCellStyle.NullValue =
					false;
			}

			// =====================================================
			// EVENTO DEL ENCABEZADO
			// =====================================================

			if (!eventosSeleccionConfigurados)
			{
				dgv.ColumnHeaderMouseClick +=
					dgv_ColumnHeaderMouseClick;

				eventosSeleccionConfigurados = true;
			}
		}
		private void dgv_CellPainting(
	object sender,
	DataGridViewCellPaintingEventArgs e)
		{
			DataGridView dgv = sender as DataGridView;

			if (dgv == null)
				return;

			if (e.ColumnIndex < 0)
				return;

			if (dgv.Columns[e.ColumnIndex].Name != "Seleccionar")
				return;

			// Solo pintar el encabezado.
			// Los checkbox de las filas los dibuja Windows.
			if (e.RowIndex == -1)
			{
				Color colorEncabezado =
					Color.FromArgb(22, 32, 45);

				e.PaintBackground(e.CellBounds, true);

				using (SolidBrush brocha =
					   new SolidBrush(colorEncabezado))
				{
					e.Graphics.FillRectangle(
						brocha,
						e.CellBounds);
				}

				// Dibujar la palomita del encabezado
				if (todosSeleccionados)
				{
					int tamaño = 14;

					int x = e.CellBounds.X +
							(e.CellBounds.Width - tamaño) / 2;

					int y = e.CellBounds.Y +
							(e.CellBounds.Height - tamaño) / 2;

					Rectangle rectangulo =
						new Rectangle(x, y, tamaño, tamaño);

					using (Pen lapiz =
						   new Pen(Color.White, 2))
					{
						e.Graphics.DrawLine(
							lapiz,
							rectangulo.X + 2,
							rectangulo.Y + 7,
							rectangulo.X + 6,
							rectangulo.Y + 11);

						e.Graphics.DrawLine(
							lapiz,
							rectangulo.X + 6,
							rectangulo.Y + 11,
							rectangulo.X + 12,
							rectangulo.Y + 3);
					}
				}

				e.Handled = true;
			}
		}
		private void dgv_ColumnHeaderMouseClick(
	object sender,
	DataGridViewCellMouseEventArgs e)
		{
			DataGridView dgv = sender as DataGridView;

			if (dgv == null)
				return;

			if (e.ColumnIndex < 0)
				return;

			if (dgv.Columns[e.ColumnIndex].Name != "Seleccionar")
				return;

			todosSeleccionados = !todosSeleccionados;

			foreach (DataGridViewRow fila in dgv.Rows)
			{
				if (fila.IsNewRow)
					continue;

				fila.Cells["Seleccionar"].Value =
					todosSeleccionados;
			}

			dgv.Columns["Seleccionar"].HeaderText =
				todosSeleccionados ? "✓" : "";

			dgv.Invalidate();
		}

		public void GuardarActividadLoteCuadrilla(string idEmpleado, string secuenciaSemana, DateTime fechaInicio, DateTime fechaFin, string dia, string idCuadrilla, string idActividad, string idVariedad, string idLote)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"sp_GuardarActividadLoteCuadrilla",
					sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add(
						"@id_employee",
						SqlDbType.Char,
						6).Value = idEmpleado;

					cmd.Parameters.Add(
						"@c_sequence_per",
						SqlDbType.Char,
						2).Value = secuenciaSemana;

					cmd.Parameters.Add(
						"@d_startDate",
						SqlDbType.Date).Value = fechaInicio.Date;

					cmd.Parameters.Add(
						"@d_endDate",
						SqlDbType.Date).Value = fechaFin.Date;

					cmd.Parameters.Add(
						"@dia",
						SqlDbType.VarChar,
						3).Value = dia;

					cmd.Parameters.Add(
						"@id_workGroup",
						SqlDbType.Char,
						4).Value = idCuadrilla;

					cmd.Parameters.Add(
						"@id_activity",
						SqlDbType.Char,
						4).Value = idActividad;

					// NUEVO PARÁMETRO: ID DE VARIEDAD
					cmd.Parameters.Add(
						"@id_variety",
						SqlDbType.Char,
						2).Value = idVariedad;

					cmd.Parameters.Add(
						"@id_lot",
						SqlDbType.Char,
						4).Value = idLote;

					cmd.Parameters.Add(
						"@userCreate",
						SqlDbType.VarChar,
						100).Value = User.GetUserName();

					cmd.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Error al guardar actividad, lote y cuadrilla",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public void ConfigurarColumnasOcultas()
		{
			if (!frmCAL.dgvAgregarLoteyActividad.Columns.Contains("IdActividad"))
			{
				frmCAL.dgvAgregarLoteyActividad.Columns.Add(
					"IdActividad",
					"IdActividad");
			}

			if (!frmCAL.dgvAgregarLoteyActividad.Columns.Contains("IdVariedad"))
			{
				frmCAL.dgvAgregarLoteyActividad.Columns.Add(
					"IdVariedad",
					"IdVariedad");
			}

			if (!frmCAL.dgvAgregarLoteyActividad.Columns.Contains("IdLote"))
			{
				frmCAL.dgvAgregarLoteyActividad.Columns.Add(
					"IdLote",
					"IdLote");
			}

			frmCAL.dgvAgregarLoteyActividad.Columns["IdActividad"].Visible = false;
			frmCAL.dgvAgregarLoteyActividad.Columns["IdVariedad"].Visible = false;
			frmCAL.dgvAgregarLoteyActividad.Columns["IdLote"].Visible = false;
		}
		public DataTable ObtenerActividadAnterior(DateTime fechaSeleccionada)
		{
			SQLControl sql = new SQLControl();
			DataTable dt = new DataTable();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"sp_GetActividadAnterior",
					sql.cnn))
				{
					cmd.CommandType =
						CommandType.StoredProcedure;

					cmd.Parameters.Add(
						"@FechaSeleccionada",
						SqlDbType.Date).Value =
							fechaSeleccionada.Date;

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
					ex.Message,
					"Error al obtener actividad anterior",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				sql.CloseConectionWrite();
			}

			return dt;
		}
		public void CargarActividadAnterior(DateTime fecha)
		{
			DataTable dt = ObtenerActividadAnterior(fecha);

			// =========================================================
			// LIMPIAR SOLAMENTE ACTIVIDAD ANTERIOR
			// =========================================================

			foreach (DataGridViewRow fila in frmCAL.dgvAgregarLoteyActividad.Rows)
			{
				if (fila.IsNewRow)
					continue;

				fila.Cells["ActividadAnterior"].Value = "";
			}

			if (dt == null || dt.Rows.Count == 0)
				return;

			// =========================================================
			// BUSCAR ACTIVIDAD ANTERIOR DE CADA EMPLEADO
			// =========================================================

			foreach (DataGridViewRow fila in frmCAL.dgvAgregarLoteyActividad.Rows)
			{
				if (fila.IsNewRow)
					continue;

				string codigoEmpleado =
					fila.Cells["Codigo"]
						.Value?
						.ToString()
						.Trim();

				if (string.IsNullOrWhiteSpace(codigoEmpleado))
					continue;

				DataRow[] encontrados = dt.Select(
					$"id_employee = '{codigoEmpleado.Replace("'", "''")}'"
				);

				if (encontrados.Length == 0)
					continue;

				string actividadAnterior =
					encontrados[0]["ActividadAnterior"]
						?.ToString()
						.Trim();

				if (string.IsNullOrWhiteSpace(actividadAnterior))
					continue;

				// =====================================================
				// SOLO MOSTRAR LA ACTIVIDAD ANTERIOR
				// NO TOCAR LA ACTIVIDAD ASIGNADA
				// =====================================================

				fila.Cells["ActividadAnterior"].Value =
					actividadAnterior;
			}
		}
	}
}