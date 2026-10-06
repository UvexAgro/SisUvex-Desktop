using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Nomina.CONTRATO.Nom_employees_pairNumber;

namespace SisUvex.Nomina.Nom_de_aplicadores
{
	internal class ClsAplicadores
	{
		public FrmAplicadores frm;
		private bool cargando = false;
		private bool cargandoLote = false;
		public void CargarCuadrillaCampo(ComboBox combo)
		{
			cargando = true;

			try
			{
				DataTable dt = CboCuadrillaCampo();

				DataRow dr = dt.NewRow();
				dr["ID"] = "";
				dr["Código"] = "";
				dr["Nombre"] = " ------ Selecciona ------ ";

				dt.Rows.InsertAt(dr, 0);

				combo.DataSource = dt.Copy();
				combo.DisplayMember = "Nombre";
				combo.ValueMember = "ID";
				combo.SelectedIndex = 0;
			}
			finally
			{
				cargando = false;
			}
		}
		public DataTable CboCuadrillaCampo()
		{
			SQLControl sql = new SQLControl();
			DataTable dt = new DataTable();

			sql.OpenConectionWrite();

			string query = @"
			SELECT 
				g.id_workGroup AS ID,
				g.c_order AS Código,
				g.v_nameWorkGroup AS Nombre
			FROM Nom_WorkGroup g
			WHERE g.c_active = 1
			ORDER BY
				CASE 
					WHEN g.c_order IS NULL OR g.c_order = '' THEN 1
					ELSE 0
				END,
				g.c_order,
				g.id_workGroup";

			SqlCommand cmd =
				new SqlCommand(query, sql.cnn);

			SqlDataAdapter da =
				new SqlDataAdapter(cmd);

			da.Fill(dt);

			sql.CloseConectionWrite();

			return dt;
		}
		public void CargarEmpleadosFechaCuadrilla()
		{
			try
			{
				if (frm.cboCuadrilla.SelectedIndex <= 0)
				{
					frm.dgvEmpleados.DataSource = null;
					return;
				}

				DateTime fecha = frm.dtpFecha.Value.Date;

				string idWorkGroup =
					frm.cboCuadrilla.SelectedValue?.ToString().Trim();

				if (string.IsNullOrEmpty(idWorkGroup))
				{
					frm.dgvEmpleados.DataSource = null;
					return;
				}

				string columnaCuadrilla = "";
				string columnaAsistencia = "";

				switch (fecha.DayOfWeek)
				{
					case DayOfWeek.Friday:
						columnaCuadrilla = "id_workGroup_vie";
						columnaAsistencia = "b_vie";
						break;

					case DayOfWeek.Saturday:
						columnaCuadrilla = "id_workGroup_sab";
						columnaAsistencia = "b_sab";
						break;

					case DayOfWeek.Sunday:
						columnaCuadrilla = "id_workGroup_dom";
						columnaAsistencia = "b_dom";
						break;

					case DayOfWeek.Monday:
						columnaCuadrilla = "id_workGroup_lun";
						columnaAsistencia = "b_lun";
						break;

					case DayOfWeek.Tuesday:
						columnaCuadrilla = "id_workGroup_mar";
						columnaAsistencia = "b_mar";
						break;

					case DayOfWeek.Wednesday:
						columnaCuadrilla = "id_workGroup_mie";
						columnaAsistencia = "b_mie";
						break;

					case DayOfWeek.Thursday:
						columnaCuadrilla = "id_workGroup_jue";
						columnaAsistencia = "b_jue";
						break;
				}

				string query = $@"
				SELECT
					e.id_employee AS Codigo,

					LTRIM(RTRIM(
						ISNULL(e.v_lastNamePat, '') + ' ' +
						ISNULL(e.v_lastNameMat, '') + ' ' +
						ISNULL(e.v_name, '')
					)) AS Empleado

				FROM dbo.Nom_EmployeeAttendanceWeekly a

				INNER JOIN dbo.Nom_Employees e
					ON e.id_employee = a.id_employee

				WHERE
					'{fecha:yyyy-MM-dd}' BETWEEN a.d_startDate_per AND a.d_endDate_per

					AND a.{columnaAsistencia} = 1

					AND a.{columnaCuadrilla} = '{idWorkGroup}'

				ORDER BY
					e.v_lastNamePat,
					e.v_lastNameMat,
					e.v_name";

				DataTable dt =
					ClsQuerysDB.GetDataTable(query);

				frm.dgvEmpleados.DataSource = null;
				frm.dgvEmpleados.DataSource = dt;
				EstiloDgvEmpleados();

				if (frm.dgvEmpleados.Columns.Count >= 2)
				{
					frm.dgvEmpleados.Columns["Codigo"].HeaderText = "Código";
					frm.dgvEmpleados.Columns["Empleado"].HeaderText = "Empleado";
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Cargar empleados",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}
		private void EstiloDgvEmpleados()
		{
			DataGridView dgv = frm.dgvEmpleados;

			// ==========================================
			// CONFIGURACIÓN GENERAL
			// ==========================================

			dgv.ReadOnly = true;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToResizeRows = false;
			dgv.RowHeadersVisible = false;

			dgv.SelectionMode =
				DataGridViewSelectionMode.FullRowSelect;

			dgv.MultiSelect = false;

			// ==========================================
			// TAMAÑO
			// ==========================================

			dgv.RowTemplate.Height = 30;
			dgv.ColumnHeadersHeight = 38;

			dgv.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.Fill;

			// ==========================================
			// FONDO
			// ==========================================

			dgv.BackgroundColor =
				System.Drawing.Color.White;

			dgv.GridColor =
				System.Drawing.Color.FromArgb(220, 225, 230);

			// ==========================================
			// ENCABEZADO
			// ==========================================

			dgv.EnableHeadersVisualStyles = false;

			dgv.ColumnHeadersDefaultCellStyle.BackColor =
				System.Drawing.Color.FromArgb(25, 103, 170);

			dgv.ColumnHeadersDefaultCellStyle.ForeColor =
				System.Drawing.Color.White;

			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor =
				System.Drawing.Color.FromArgb(25, 103, 170);

			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor =
				System.Drawing.Color.White;

			dgv.ColumnHeadersDefaultCellStyle.Font =
				new System.Drawing.Font(
					"Segoe UI",
					10F,
					System.Drawing.FontStyle.Bold
				);

			dgv.ColumnHeadersDefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			// ==========================================
			// FILAS
			// ==========================================

			dgv.DefaultCellStyle.Font =
				new System.Drawing.Font(
					"Segoe UI",
					9F
				);

			dgv.DefaultCellStyle.ForeColor =
				System.Drawing.Color.FromArgb(45, 45, 45);

			dgv.DefaultCellStyle.BackColor =
				System.Drawing.Color.White;

			dgv.DefaultCellStyle.SelectionBackColor =
				System.Drawing.Color.FromArgb(225, 238, 252);

			dgv.DefaultCellStyle.SelectionForeColor =
				System.Drawing.Color.FromArgb(30, 30, 30);

			dgv.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleLeft;

			// ==========================================
			// CÓDIGO
			// ==========================================

			if (dgv.Columns.Contains("Codigo"))
			{
				dgv.Columns["Codigo"].HeaderText = "Código";

				dgv.Columns["Codigo"].FillWeight = 20;

				dgv.Columns["Codigo"].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleCenter;
			}

			// ==========================================
			// EMPLEADO
			// ==========================================

			if (dgv.Columns.Contains("Empleado"))
			{
				dgv.Columns["Empleado"].HeaderText = "Empleado";

				dgv.Columns["Empleado"].FillWeight = 80;

				dgv.Columns["Empleado"].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleLeft;
			}
		}
		public void CargarDatosEmpleadoSeleccionado()
		{
			try
			{
				if (frm.dgvEmpleados.CurrentRow == null)
					return;

				if (frm.dgvEmpleados.CurrentRow.IsNewRow)
					return;

				// ==========================================
				// CÓDIGO
				// ==========================================

				string codigo =
					frm.dgvEmpleados.CurrentRow
						.Cells["Codigo"]
						.Value?.ToString()
						.Trim();

				// ==========================================
				// EMPLEADO
				// ==========================================

				string empleado =
					frm.dgvEmpleados.CurrentRow
						.Cells["Empleado"]
						.Value?.ToString()
						.Trim();

				// ==========================================
				// MOSTRAR DATOS
				// ==========================================

				frm.txbCodigo.Text = codigo;
				frm.txbNombre.Text = empleado;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Seleccionar empleado",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
			}
		}
		public void CargarLotes()
		{
			cargandoLote = true;

			try
			{
				string query = @"
            SELECT
                id_lot,
                c_nombreCuadro,
                v_lineas,
                m_costo,
                m_porcentajeLinea
            FROM Nom_CuadroCosto
            ORDER BY c_nombreCuadro";

				DataTable dt =
					ClsQuerysDB.GetDataTable(query);

				frm.cboLote.DataSource = null;

				if (dt.Rows.Count == 0)
				{
					frm.cboLote.Items.Clear();
					LimpiarDatosLote();
					return;
				}

				frm.cboLote.DisplayMember =
					"c_nombreCuadro";

				frm.cboLote.ValueMember =
					"id_lot";

				frm.cboLote.DataSource =
					dt;

				frm.cboLote.SelectedIndex = -1;

				LimpiarDatosLote();
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Cargar Cuadros",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				cargandoLote = false;
			}
		}
		private void LimpiarDatosLote()
		{
			frm.txbLineas.Clear();
			frm.txbCosto.Clear();
			frm.txbPorcentaje.Clear();

			frm.nudCantidad.Value = 0;

			frm.txbImportePorcentaje.Text = "0.00";
		}
		public void CargarDatosLote()
		{
			try
			{
				if (frm.cboLote.SelectedIndex == -1)
					return;

				if (frm.cboLote.SelectedValue == null)
					return;

				string idLot =
					frm.cboLote.SelectedValue.ToString().Trim();

				if (string.IsNullOrEmpty(idLot))
					return;

				string query = $@"
				SELECT
					v_lineas,
					m_costo,
					m_porcentajeLinea
				FROM Nom_CuadroCosto
				WHERE id_lot = '{idLot}'";

				DataTable dt =
					ClsQuerysDB.GetDataTable(query);

				if (dt.Rows.Count == 0)
					return;

				DataRow row = dt.Rows[0];

				// ==========================================
				// LÍNEAS
				// ==========================================
				string rangoLineas =
					row["v_lineas"].ToString().Trim();

				frm.txbLineas.Text = rangoLineas;

				frm.maxCantidadLineas =
					ObtenerCantidadLineas(rangoLineas);

				frm.nudCantidad.Minimum = 0;
				frm.nudCantidad.Maximum =
					frm.maxCantidadLineas;

				if (frm.nudCantidad.Value >
					frm.maxCantidadLineas)
				{
					frm.nudCantidad.Value =
						frm.maxCantidadLineas;
				}

				// ==========================================
				// COSTO
				// ==========================================

				frm.txbCosto.Text =
					Convert.ToDecimal(
						row["m_costo"]
					).ToString("N2");

				// ==========================================
				// PORCENTAJE POR LÍNEA
				// ==========================================

				frm.txbPorcentaje.Text =
					Convert.ToDecimal(
						row["m_porcentajeLinea"]
					).ToString("N2");

				// ==========================================
				// CALCULAR IMPORTE
				// ==========================================

				CalcularImporteCuadro();
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Cargar información del cuadro",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}
		public void CalcularImporteCuadro()
		{
			try
			{
				decimal cantidad = frm.nudCantidad.Value;

				if (!decimal.TryParse(
					frm.txbPorcentaje.Text,
					out decimal porcentaje))
				{
					frm.txbImportePorcentaje.Text = "0.00";
					return;
				}

				decimal importe = cantidad * porcentaje;

				frm.txbImportePorcentaje.Text = importe.ToString("N2");
			}
			catch
			{
				frm.txbImportePorcentaje.Text = "0.00";
			}
		}
		public int ObtenerCantidadLineas(string rango)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(rango))
					return 0;

				string[] partes = rango.Split('-');

				if (partes.Length != 2)
					return 0;

				if (!int.TryParse(partes[0].Trim(), out int inicio))
					return 0;

				if (!int.TryParse(partes[1].Trim(), out int fin))
					return 0;

				return Math.Abs(fin - inicio) + 1;
			}
			catch
			{
				return 0;
			}
		}
		public decimal ObtenerTarifaHora()
		{
			try
			{
				string query = @"
            SELECT TOP 1
                v_valueParameters
            FROM Conf_Parameters
            WHERE v_nameParameters = 'precio de hora'
              AND v_DetailParameter = 'Aplicadores'
              AND c_active = 1";

				DataTable dt =
					ClsQuerysDB.GetDataTable(query);

				if (dt.Rows.Count == 0)
					return 0;

				return Convert.ToDecimal(
					dt.Rows[0]["v_valueParameters"]);
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Obtener tarifa por hora",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return 0;
			}
		}
		public void CargarTarifaHora()
		{
			decimal tarifa = ObtenerTarifaHora();

			frm.txbTarifa.Text =
				tarifa.ToString("N2");
		}
		public void CalcularImporteHoras()
		{
			if (!decimal.TryParse(
				frm.txbTarifa.Text,
				out decimal tarifa))
			{
				frm.txbImporteHoras.Text = "0.00";
				return;
			}

			if (!decimal.TryParse(
				frm.txbHorasTrabajadas.Text,
				out decimal horas))
			{
				frm.txbImporteHoras.Text = "0.00";
				return;
			}

			decimal importe = horas * tarifa;

			frm.txbImporteHoras.Text =
				importe.ToString("N2");
		}
		public void AgregarCuadroDetalle()
		{
			// ==========================================
			// VALIDAR EMPLEADO SELECCIONADO
			// ==========================================

			if (string.IsNullOrWhiteSpace(frm.txbCodigo.Text))
			{
				MessageBox.Show(
					"Primero debes seleccionar un empleado.",
					"Empleado requerido",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}
			// ==========================================
			// VALIDAR LOTE
			// ==========================================

			if (frm.cboLote.SelectedIndex == -1)
			{
				MessageBox.Show(
					"Seleccione un lote.",
					"Agregar cuadro",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				frm.cboLote.Focus();
				return;
			}

			// ==========================================
			// VALIDAR CANTIDAD
			// ==========================================

			if (frm.nudCantidad.Value <= 0)
			{
				MessageBox.Show(
					"Capture la cantidad de líneas.",
					"Agregar cuadro",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				frm.nudCantidad.Focus();
				return;
			}

			// ==========================================
			// OBTENER DATOS
			// ==========================================

			string idLot =
				frm.cboLote.SelectedValue.ToString().Trim();

			string lote =
				frm.cboLote.Text.Trim();

			string lineas =
				frm.txbLineas.Text.Trim();

			decimal cantidad =
				frm.nudCantidad.Value;

			decimal porcentaje =
				Convert.ToDecimal(frm.txbPorcentaje.Text);

			// ==========================================
			// CALCULAR IMPORTE
			// ==========================================

			decimal importe =
				cantidad * porcentaje;

			// ==========================================
			// AGREGAR AL DGV
			// ==========================================

			frm.dgvDatos.Rows.Add(
				"Cuadro",
				lote,
				lineas,
				cantidad.ToString("N2"),
				porcentaje.ToString("$ #,##0.00"),
				importe.ToString("$ #,##0.00"),
				idLot
			);

			// ==========================================
			// ACTUALIZAR RESUMEN
			// ==========================================

			ActualizarDetalleCuadros();

			// ==========================================
			// LIMPIAR CAPTURA
			// ==========================================

			frm.cboLote.SelectedIndex = -1;

			frm.txbLineas.Clear();
			frm.txbCosto.Clear();
			frm.txbPorcentaje.Clear();

			frm.nudCantidad.Value = 0;

			frm.txbImportePorcentaje.Text = "0.00";
		}
		public void ActualizarDetalleCuadros()
		{   // ==========================================
			// LIMPIAR DETALLE DE CUADROS
			// ==========================================

			frm.flpCuadros.Controls.Clear();

			decimal totalCuadros = 0;
			decimal totalHoras = 0;
			decimal horasTrabajadas = 0;
			decimal tarifaHora = 0;

			// ==========================================
			// RECORRER DGV
			// ==========================================

			foreach (DataGridViewRow row in frm.dgvDatos.Rows)
			{
				if (row.IsNewRow)
					continue;

				string tipo =
					row.Cells["Tipo"].Value?.ToString()?.Trim();

				string concepto =
					row.Cells["Concepto"].Value?.ToString()?.Trim();

				decimal importe = 0;

				decimal.TryParse(
					row.Cells["Importe"].Value?.ToString()
						?.Replace("$", "")
						.Replace(",", ""),
					out importe);

				// ==========================================
				// CUADROS
				// ==========================================

				if (tipo == "Cuadro")
				{
					totalCuadros += importe;

					AgregarFilaResumen(
						frm.flpCuadros,
						concepto,
						importe);
				}

				// ==========================================
				// HORAS
				// ==========================================

				else if (tipo == "Horas")
				{
					totalHoras += importe;

					decimal horas = 0;

					decimal.TryParse(
						row.Cells["Cantidad"].Value?.ToString()
							?.Replace(",", ""),
						out horas);

					horasTrabajadas += horas;

					decimal tarifa = 0;

					decimal.TryParse(
						row.Cells["Tarifa"].Value?.ToString()
							?.Replace("$", "")
							.Replace(",", ""),
						out tarifa);

					tarifaHora = tarifa;
				}
			}

			// ==========================================
			// TOTAL POR CUADROS
			// ==========================================

			frm.lblTotalCuadros.Text =
				totalCuadros.ToString("$ #,##0.00");

			// ==========================================
			// TOTAL POR HORAS
			// ==========================================

			frm.lblTotalHoras.Text =
				totalHoras.ToString("$ #,##0.00");

			// Solo el valor, porque "Horas:" ya
			// está escrito en el diseñador.
			frm.lblHorasTrabajadas.Text =
				horasTrabajadas.ToString("N2");

			// Solo el valor, porque "Tarifa:" ya
			// está escrito en el diseñador.
			frm.lblTarifaHoraResumen.Text =
				tarifaHora.ToString("$ #,##0.00");

			// ==========================================
			// TOTAL A PAGAR
			// ==========================================

			decimal totalPagar =
				totalCuadros + totalHoras;

			frm.lblTotalPagar.Text =
				totalPagar.ToString("$ #,##0.00");
		}
		private void AgregarFilaResumen(FlowLayoutPanel panel,string concepto,decimal importe)
		{
			Panel fila = new Panel();

			fila.Width = panel.ClientSize.Width - 20;
			fila.Height = 28;
			fila.Margin = new Padding(0, 0, 0, 2);
			fila.BackColor = Color.White;

			// ==========================================
			// CONCEPTO
			// ==========================================

			Label lblConcepto = new Label();

			lblConcepto.Text = concepto;
			lblConcepto.AutoSize = false;
			lblConcepto.Dock = DockStyle.Left;
			lblConcepto.Width = fila.Width - 100;
			lblConcepto.TextAlign =
				ContentAlignment.MiddleLeft;

			lblConcepto.Font =
				new Font("Segoe UI", 9F);

			// ==========================================
			// IMPORTE
			// ==========================================

			Label lblImporte = new Label();

			lblImporte.Text =
				importe.ToString("$ #,##0.00");

			lblImporte.AutoSize = false;
			lblImporte.Dock = DockStyle.Right;
			lblImporte.Width = 100;
			lblImporte.TextAlign =
				ContentAlignment.MiddleRight;

			lblImporte.Font =
				new Font("Segoe UI", 9F);

			// ==========================================
			// AGREGAR
			// ==========================================

			fila.Controls.Add(lblImporte);
			fila.Controls.Add(lblConcepto);

			panel.Controls.Add(fila);
		}
		public void AgregarHorasDetalle()
		{
			if (string.IsNullOrWhiteSpace(frm.txbCodigo.Text))
			{
				MessageBox.Show(
					"Primero debes seleccionar un empleado.",
					"Empleado requerido",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}
			if (string.IsNullOrWhiteSpace(frm.txbHorasTrabajadas.Text))
			{
				MessageBox.Show(
					"Capture las horas trabajadas.",
					"Agregar horas",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				frm.txbHorasTrabajadas.Focus();
				return;
			}

			if (!decimal.TryParse(
				frm.txbHorasTrabajadas.Text.Trim(),
				out decimal horas))
			{
				MessageBox.Show(
					"Las horas capturadas no son válidas.",
					"Agregar horas",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				frm.txbHorasTrabajadas.Focus();
				return;
			}

			if (horas <= 0)
			{
				MessageBox.Show(
					"Las horas deben ser mayores a cero.",
					"Agregar horas",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return;
			}

			if (!decimal.TryParse(
				frm.txbTarifa.Text.Trim(),
				out decimal tarifa))
			{
				MessageBox.Show(
					"No se encontró una tarifa por hora válida.",
					"Agregar horas",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return;
			}

			decimal importe = horas * tarifa;

			// Crear fila
			int fila = frm.dgvDatos.Rows.Add();

			// Asignar valores por nombre
			frm.dgvDatos.Rows[fila].Cells["Tipo"].Value = "Horas";
			frm.dgvDatos.Rows[fila].Cells["Concepto"].Value = "HORAS";
			frm.dgvDatos.Rows[fila].Cells["Lineas"].Value = "-";
			frm.dgvDatos.Rows[fila].Cells["Cantidad"].Value = horas.ToString("N2");
			frm.dgvDatos.Rows[fila].Cells["Tarifa"].Value =
				tarifa.ToString("$ #,##0.00");
			frm.dgvDatos.Rows[fila].Cells["Importe"].Value =
				importe.ToString("$ #,##0.00");

			frm.dgvDatos.Rows[fila].Cells["IdLot"].Value = null;
			frm.dgvDatos.Rows[fila].Cells["Costo"].Value = null;

			ActualizarDetalleCuadros();

			frm.txbHorasTrabajadas.Clear();
			frm.txbImporteHoras.Text = "0.00";
		}
		public void ConfigurarDgvDatos()
		{
			frm.dgvDatos.Columns.Clear();

			frm.dgvDatos.AutoGenerateColumns = false;
			frm.dgvDatos.AllowUserToAddRows = false;
			frm.dgvDatos.AllowUserToDeleteRows = false;
			frm.dgvDatos.ReadOnly = true;
			frm.dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			frm.dgvDatos.MultiSelect = false;

			// ==========================================
			// TIPO
			// ==========================================

			frm.dgvDatos.Columns.Add("Tipo", "Tipo");

			// ==========================================
			// CONCEPTO
			// ==========================================

			frm.dgvDatos.Columns.Add("Concepto", "Concepto");

			// ==========================================
			// LÍNEAS
			// ==========================================

			frm.dgvDatos.Columns.Add("Lineas", "Líneas");

			// ==========================================
			// CANTIDAD
			// ==========================================

			frm.dgvDatos.Columns.Add("Cantidad", "Cantidad");

			// ==========================================
			// TARIFA
			// ==========================================

			frm.dgvDatos.Columns.Add("Tarifa", "Tarifa");

			// ==========================================
			// IMPORTE
			// ==========================================

			frm.dgvDatos.Columns.Add("Importe", "Importe");

			// ==========================================
			// ID LOTE
			// ==========================================

			frm.dgvDatos.Columns.Add("IdLot", "IdLot");

			// Ocultamos el ID
			frm.dgvDatos.Columns["IdLot"].Visible = false;

			// ==========================================
			// COSTO
			// ==========================================

			frm.dgvDatos.Columns.Add("Costo", "Costo");

			// Ocultamos el costo
			frm.dgvDatos.Columns["Costo"].Visible = false;

			// ==========================================
			// COLUMNA ELIMINAR
			// ==========================================

			DataGridViewImageColumn colEliminar =
				new DataGridViewImageColumn();

			colEliminar.Name = "Eliminar";
			colEliminar.HeaderText = "";
			colEliminar.Image = Properties.Resources.Eliminar;
			colEliminar.ImageLayout =
				DataGridViewImageCellLayout.Zoom;

			colEliminar.AutoSizeMode =
				DataGridViewAutoSizeColumnMode.None;

			colEliminar.Width = 45;

			colEliminar.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			frm.dgvDatos.Columns.Add(colEliminar);

			// ==========================================
			// ALINEACIÓN
			// ==========================================

			frm.dgvDatos.Columns["Tipo"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			frm.dgvDatos.Columns["Concepto"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleLeft;

			frm.dgvDatos.Columns["Lineas"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			frm.dgvDatos.Columns["Cantidad"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleRight;

			frm.dgvDatos.Columns["Tarifa"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleRight;

			frm.dgvDatos.Columns["Importe"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleRight;

			// ==========================================
			// COLUMNAS QUE SE AJUSTAN AL DGV
			// ==========================================

			frm.dgvDatos.Columns["Tipo"].AutoSizeMode =
				DataGridViewAutoSizeColumnMode.Fill;

			frm.dgvDatos.Columns["Concepto"].AutoSizeMode =
				DataGridViewAutoSizeColumnMode.Fill;

			frm.dgvDatos.Columns["Lineas"].AutoSizeMode =
				DataGridViewAutoSizeColumnMode.Fill;

			frm.dgvDatos.Columns["Cantidad"].AutoSizeMode =
				DataGridViewAutoSizeColumnMode.Fill;

			frm.dgvDatos.Columns["Tarifa"].AutoSizeMode =
				DataGridViewAutoSizeColumnMode.Fill;

			frm.dgvDatos.Columns["Importe"].AutoSizeMode =
				DataGridViewAutoSizeColumnMode.Fill;

			// ==========================================
			// PROPORCIÓN
			// ==========================================

			frm.dgvDatos.Columns["Tipo"].FillWeight = 10;
			frm.dgvDatos.Columns["Concepto"].FillWeight = 20;
			frm.dgvDatos.Columns["Lineas"].FillWeight = 15;
			frm.dgvDatos.Columns["Cantidad"].FillWeight = 15;
			frm.dgvDatos.Columns["Tarifa"].FillWeight = 15;
			frm.dgvDatos.Columns["Importe"].FillWeight = 15;
		}
		public void EstilizarDgvDatos()
		{
			DataGridView dgv = frm.dgvDatos;

			// ==========================================
			// CONFIGURACIÓN GENERAL
			// ==========================================

			dgv.BackgroundColor = Color.White;
			dgv.BorderStyle = BorderStyle.None;
			dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
			dgv.GridColor = Color.FromArgb(225, 225, 225);

			dgv.RowHeadersVisible = false;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToResizeRows = false;

			dgv.ReadOnly = true;
			dgv.MultiSelect = false;
			dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

			dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
			dgv.RowTemplate.Height = 32;

			// ==========================================
			// ENCABEZADO
			// ==========================================

			dgv.EnableHeadersVisualStyles = false;

			dgv.ColumnHeadersDefaultCellStyle.BackColor =
				Color.FromArgb(25, 103, 170);

			dgv.ColumnHeadersDefaultCellStyle.ForeColor =
				Color.White;

			dgv.ColumnHeadersDefaultCellStyle.Font =
				new Font("Segoe UI", 9F, FontStyle.Bold);

			dgv.ColumnHeadersDefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor =
				Color.FromArgb(25, 103, 170);

			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor =
				Color.White;

			dgv.ColumnHeadersHeight = 36;

			// ==========================================
			// FILAS
			// ==========================================

			dgv.DefaultCellStyle.Font =
				new Font("Segoe UI", 9F);

			dgv.DefaultCellStyle.ForeColor =
				Color.FromArgb(45, 45, 45);

			dgv.DefaultCellStyle.BackColor =
				Color.White;

			dgv.DefaultCellStyle.SelectionBackColor =
				Color.FromArgb(220, 235, 248);

			dgv.DefaultCellStyle.SelectionForeColor =
				Color.FromArgb(25, 70, 110);

			dgv.AlternatingRowsDefaultCellStyle.BackColor =
				Color.FromArgb(248, 250, 252);

			// ==========================================
			// ALINEACIÓN
			// ==========================================

			dgv.Columns["Tipo"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.Columns["Concepto"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleLeft;

			dgv.Columns["Lineas"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.Columns["Cantidad"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleRight;

			dgv.Columns["Tarifa"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleRight;

			dgv.Columns["Importe"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleRight;

			// ==========================================
			// AJUSTAR COLUMNAS AL ANCHO DEL DGV
			// ==========================================

			dgv.Columns["Tipo"].AutoSizeMode =
				DataGridViewAutoSizeColumnMode.Fill;

			dgv.Columns["Concepto"].AutoSizeMode =
				DataGridViewAutoSizeColumnMode.Fill;

			dgv.Columns["Lineas"].AutoSizeMode =
				DataGridViewAutoSizeColumnMode.Fill;

			dgv.Columns["Cantidad"].AutoSizeMode =
				DataGridViewAutoSizeColumnMode.Fill;

			dgv.Columns["Tarifa"].AutoSizeMode =
				DataGridViewAutoSizeColumnMode.Fill;

			dgv.Columns["Importe"].AutoSizeMode =
				DataGridViewAutoSizeColumnMode.Fill;

			// ==========================================
			// PROPORCIÓN DE CADA COLUMNA
			// ==========================================

			dgv.Columns["Tipo"].FillWeight = 12;
			dgv.Columns["Concepto"].FillWeight = 25;
			dgv.Columns["Lineas"].FillWeight = 18;
			dgv.Columns["Cantidad"].FillWeight = 15;
			dgv.Columns["Tarifa"].FillWeight = 15;
			dgv.Columns["Importe"].FillWeight = 15;

			// ==========================================
			// ID LOTE OCULTO
			// ==========================================

			if (dgv.Columns.Contains("IdLot"))
				dgv.Columns["IdLot"].Visible = false;
		}
		public bool AddProcedure(DateTime fecha,string idEmployee,string idWorkGroup,string tipo,string? idLot,string? concepto,string? lineas,decimal? costo,decimal? porcentajeLinea,decimal? cantidad,decimal? horas,decimal? tarifaHora,decimal importe)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				SqlCommand cmd =
					new SqlCommand(
						"sp_AddEmployeeCostAplicador",
						sql.cnn);

				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@d_fecha", fecha);
				cmd.Parameters.AddWithValue("@id_employee", idEmployee);
				cmd.Parameters.AddWithValue("@id_workGroup", idWorkGroup);
				cmd.Parameters.AddWithValue("@c_tipo", tipo);

				cmd.Parameters.AddWithValue(
					"@id_lot",
					(object?)idLot ?? DBNull.Value);

				cmd.Parameters.AddWithValue(
					"@v_concepto",
					(object?)concepto ?? DBNull.Value);

				cmd.Parameters.AddWithValue(
					"@v_lineas",
					(object?)lineas ?? DBNull.Value);

				cmd.Parameters.AddWithValue(
					"@m_costo",
					(object?)costo ?? DBNull.Value);

				cmd.Parameters.AddWithValue(
					"@m_porcentajeLinea",
					(object?)porcentajeLinea ?? DBNull.Value);

				cmd.Parameters.AddWithValue(
					"@m_cantidad",
					(object?)cantidad ?? DBNull.Value);

				cmd.Parameters.AddWithValue(
					"@m_horas",
					(object?)horas ?? DBNull.Value);

				cmd.Parameters.AddWithValue(
					"@m_tarifaHora",
					(object?)tarifaHora ?? DBNull.Value);

				cmd.Parameters.AddWithValue(
					"@m_importe",
					importe);

				cmd.Parameters.AddWithValue(
					"@v_userCreate",
					User.GetUserName());

				SqlDataReader dr = cmd.ExecuteReader();

				if (dr.Read())
				{
					int rows =
						Convert.ToInt32(dr["rowsAffected"]);

					return rows > 0;
				}

				return false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Guardar costo de aplicador",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return false;
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public void GuardarCostosAplicador()
		{
			try
			{
				// ==========================================
				// VALIDAR EMPLEADO
				// ==========================================

				if (frm.dgvEmpleados.CurrentRow == null)
				{
					MessageBox.Show(
						"Seleccione un empleado.",
						"Guardar",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					return;
				}

				// ==========================================
				// VALIDAR CUADRILLA
				// ==========================================

				if (frm.cboCuadrilla.SelectedIndex <= 0 ||
					frm.cboCuadrilla.SelectedValue == null)
				{
					MessageBox.Show(
						"Seleccione una cuadrilla.",
						"Guardar",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					return;
				}

				// ==========================================
				// VALIDAR DETALLE
				// ==========================================

				if (frm.dgvDatos.Rows.Count == 0)
				{
					MessageBox.Show(
						"No hay información para guardar.",
						"Guardar",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					return;
				}

				// ==========================================
				// DATOS GENERALES
				// ==========================================

				DateTime fecha =
					frm.dtpFechaRegistro.Value.Date;

				string idEmployee =
					frm.txbCodigo.Text.Trim();

				string idWorkGroup =
					frm.cboCuadrilla.SelectedValue
						.ToString()
						.Trim();

				// ==========================================
				// CONFIRMAR
				// ==========================================

				DialogResult respuesta = MessageBox.Show(
					"¿Desea guardar los registros del empleado?",
					"Guardar costos",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question);

				if (respuesta != DialogResult.Yes)
					return;

				// ==========================================
				// RECORRER DGV
				// ==========================================

				foreach (DataGridViewRow row in frm.dgvDatos.Rows)
				{
					if (row.IsNewRow)
						continue;

					string tipo =
						row.Cells["Tipo"].Value?
							.ToString()
							.Trim();

					string concepto =
						row.Cells["Concepto"].Value?
							.ToString()
							.Trim();

					string lineas =
						row.Cells["Lineas"].Value?
							.ToString()
							.Trim();

					string idLot =
						row.Cells["IdLot"].Value?
							.ToString()
							.Trim();

					decimal cantidad =
						ObtenerDecimal(
							row.Cells["Cantidad"].Value);

					decimal tarifa =
						ObtenerDecimal(
							row.Cells["Tarifa"].Value);

					decimal importe =
						ObtenerDecimal(
							row.Cells["Importe"].Value);

					// ==========================================
					// CUADRO
					// ==========================================

					if (tipo.Equals("Cuadro", StringComparison.OrdinalIgnoreCase))
					{
						bool guardado = AddProcedure(
							fecha,
							idEmployee,
							idWorkGroup,
							"CUADRO",
							idLot,
							concepto,
							lineas,
							null,       // costo
							tarifa,     // porcentaje línea
							cantidad,   // cantidad
							null,       // horas
							null,       // tarifa hora
							importe);

						if (!guardado)
						{
							MessageBox.Show(
								"No se pudo guardar el registro de cuadro.",
								"Guardar",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error);

							return;
						}
					}

					// ==========================================
					// HORAS
					// ==========================================

					else if (tipo.Equals("Horas", StringComparison.OrdinalIgnoreCase))
					{
						bool guardado = AddProcedure(
							fecha,
							idEmployee,
							idWorkGroup,
							"HORAS",
							null,       // id_lot
							"HORAS",    // concepto
							null,       // lineas
							null,       // costo
							null,       // porcentaje
							null,       // cantidad
							cantidad,   // horas
							tarifa,     // tarifa hora
							importe);   // importe

						if (!guardado)
						{
							MessageBox.Show(
								"No se pudo guardar el registro de horas.",
								"Guardar",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error);

							return;
						}
					}
				}

				// ==========================================
				// MENSAJE FINAL
				// ==========================================

				MessageBox.Show(
					"Los registros se guardaron correctamente.",
					"Guardar",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				// ==========================================
				// LIMPIAR DGV
				// ==========================================

				frm.dgvDatos.Rows.Clear();

				ActualizarDetalleCuadros();
				CargarTodoDatos(frm.dtpFechaRegistro.Value);
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Guardar costos",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}
		private decimal ObtenerDecimal(object valor)
		{
			if (valor == null)
				return 0;

			string texto = valor
				.ToString()
				.Replace("$", "")
				.Replace(",", "")
				.Trim();

			decimal.TryParse(
				texto,
				out decimal resultado);

			return resultado;
		}
		public void ConfigurarDgvTodoDatos()
		{
			frm.dgvTodoDatos.Columns.Clear();

			frm.dgvTodoDatos.AutoGenerateColumns = false;
			frm.dgvTodoDatos.AllowUserToAddRows = false;
			frm.dgvTodoDatos.ReadOnly = true;
			frm.dgvTodoDatos.SelectionMode =
				DataGridViewSelectionMode.FullRowSelect;
			frm.dgvTodoDatos.MultiSelect = false;

			// ==========================================
			// ID
			// ==========================================

			frm.dgvTodoDatos.Columns.Add(
				"IdEmployeeCost",
				"ID");

			// ==========================================
			// FECHA
			// ==========================================

			frm.dgvTodoDatos.Columns.Add(
				"Fecha",
				"Fecha");

			// ==========================================
			// CÓDIGO EMPLEADO
			// ==========================================

			frm.dgvTodoDatos.Columns.Add(
				"IdEmployee",
				"Código");

			// ==========================================
			// EMPLEADO
			// ==========================================

			frm.dgvTodoDatos.Columns.Add(
				"Empleado",
				"Empleado");

			// ==========================================
			// CUADRILLA
			// ==========================================

			frm.dgvTodoDatos.Columns.Add(
				"IdWorkGroup",
				"Cuadrilla");

			// ==========================================
			// TIPO
			// ==========================================

			frm.dgvTodoDatos.Columns.Add(
				"Tipo",
				"Tipo");

			// ==========================================
			// LOTE
			// ==========================================

			frm.dgvTodoDatos.Columns.Add(
				"IdLot",
				"Lote");

			// ==========================================
			// CONCEPTO
			// ==========================================

			frm.dgvTodoDatos.Columns.Add(
				"Concepto",
				"Concepto");

			// ==========================================
			// LÍNEAS
			// ==========================================

			frm.dgvTodoDatos.Columns.Add(
				"Lineas",
				"Líneas");

			// ==========================================
			// CANTIDAD
			// ==========================================

			frm.dgvTodoDatos.Columns.Add(
				"Cantidad",
				"Cantidad");

			// ==========================================
			// TARIFA
			// ==========================================

			frm.dgvTodoDatos.Columns.Add(
				"Tarifa",
				"Tarifa");

			// ==========================================
			// IMPORTE
			// ==========================================

			frm.dgvTodoDatos.Columns.Add(
				"Importe",
				"Importe");

			// ==========================================
			// OCULTAR IDS
			// ==========================================

			frm.dgvTodoDatos.Columns["IdEmployeeCost"].Visible = false;
			frm.dgvTodoDatos.Columns["IdEmployee"].Visible = false;
			frm.dgvTodoDatos.Columns["IdWorkGroup"].Visible = false;
			frm.dgvTodoDatos.Columns["IdLot"].Visible = false;

			// ==========================================
			// AJUSTAR COLUMNAS
			// ==========================================

			frm.dgvTodoDatos.Columns["Fecha"].AutoSizeMode =
				DataGridViewAutoSizeColumnMode.AllCells;

			frm.dgvTodoDatos.Columns["Empleado"].AutoSizeMode =
				DataGridViewAutoSizeColumnMode.Fill;

			frm.dgvTodoDatos.Columns["Tipo"].AutoSizeMode =
				DataGridViewAutoSizeColumnMode.AllCells;

			frm.dgvTodoDatos.Columns["Concepto"].AutoSizeMode =
				DataGridViewAutoSizeColumnMode.Fill;

			frm.dgvTodoDatos.Columns["Lineas"].AutoSizeMode =
				DataGridViewAutoSizeColumnMode.AllCells;

			frm.dgvTodoDatos.Columns["Cantidad"].AutoSizeMode =
				DataGridViewAutoSizeColumnMode.AllCells;

			frm.dgvTodoDatos.Columns["Tarifa"].AutoSizeMode =
				DataGridViewAutoSizeColumnMode.AllCells;

			frm.dgvTodoDatos.Columns["Importe"].AutoSizeMode =
				DataGridViewAutoSizeColumnMode.AllCells;
		}
		public void EstilizarDgvTodoDatos()
		{
			DataGridView dgv = frm.dgvTodoDatos;

			// ==========================================
			// CONFIGURACIÓN GENERAL
			// ==========================================

			dgv.BackgroundColor = Color.White;
			dgv.BorderStyle = BorderStyle.None;
			dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
			dgv.GridColor = Color.FromArgb(225, 230, 235);

			dgv.EnableHeadersVisualStyles = false;

			dgv.RowHeadersVisible = false;

			dgv.AllowUserToResizeRows = false;
			dgv.AllowUserToResizeColumns = false;

			dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgv.MultiSelect = false;

			dgv.ReadOnly = true;

			dgv.RowTemplate.Height = 32;

			// ==========================================
			// ENCABEZADO
			// ==========================================

			dgv.EnableHeadersVisualStyles = false;

			dgv.ColumnHeadersDefaultCellStyle.BackColor =
				Color.FromArgb(38, 111, 161);

			dgv.ColumnHeadersDefaultCellStyle.ForeColor =
				Color.White;

			dgv.ColumnHeadersDefaultCellStyle.Font =
				new Font("Segoe UI", 9F, FontStyle.Bold);

			dgv.ColumnHeadersDefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			// Mantener encabezado azul al seleccionar
			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor =
				Color.FromArgb(38, 111, 161);

			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor =
				Color.White;

			dgv.ColumnHeadersHeight = 38;

			dgv.ColumnHeadersBorderStyle =
				DataGridViewHeaderBorderStyle.None;

			// ==========================================
			// DESACTIVAR ORDENAMIENTO
			// ==========================================

			foreach (DataGridViewColumn columna in dgv.Columns)
			{
				columna.SortMode =
					DataGridViewColumnSortMode.NotSortable;
			}

			// ==========================================
			// FILAS
			// ==========================================

			dgv.DefaultCellStyle.Font =
				new Font("Segoe UI", 9F);

			dgv.DefaultCellStyle.ForeColor =
				Color.FromArgb(45, 45, 45);

			dgv.DefaultCellStyle.BackColor =
				Color.White;

			dgv.DefaultCellStyle.SelectionBackColor =
				Color.FromArgb(218, 235, 247);

			dgv.DefaultCellStyle.SelectionForeColor =
				Color.FromArgb(30, 30, 30);

			dgv.AlternatingRowsDefaultCellStyle.BackColor =
				Color.FromArgb(245, 248, 251);

			// ==========================================
			// FECHA
			// ==========================================

			dgv.Columns["Fecha"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			// ==========================================
			// EMPLEADO
			// ==========================================

			dgv.Columns["Empleado"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleLeft;

			// ==========================================
			// TIPO
			// ==========================================

			dgv.Columns["Tipo"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			// ==========================================
			// CONCEPTO
			// ==========================================

			dgv.Columns["Concepto"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleLeft;

			// ==========================================
			// LÍNEAS
			// ==========================================

			dgv.Columns["Lineas"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			// ==========================================
			// CANTIDAD
			// ==========================================

			dgv.Columns["Cantidad"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleRight;

			// ==========================================
			// TARIFA
			// ==========================================

			dgv.Columns["Tarifa"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleRight;

			// ==========================================
			// IMPORTE
			// ==========================================

			dgv.Columns["Importe"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleRight;

			dgv.Columns["Importe"].DefaultCellStyle.Font =
				new Font("Segoe UI", 9F, FontStyle.Bold);

			// ==========================================
			// ANCHOS
			// ==========================================

			dgv.Columns["Fecha"].AutoSizeMode =
				DataGridViewAutoSizeColumnMode.AllCells;

			dgv.Columns["Empleado"].AutoSizeMode =
				DataGridViewAutoSizeColumnMode.Fill;

			dgv.Columns["Tipo"].AutoSizeMode =
				DataGridViewAutoSizeColumnMode.AllCells;

			dgv.Columns["Concepto"].AutoSizeMode =
				DataGridViewAutoSizeColumnMode.Fill;

			dgv.Columns["Lineas"].AutoSizeMode =
				DataGridViewAutoSizeColumnMode.AllCells;

			dgv.Columns["Cantidad"].AutoSizeMode =
				DataGridViewAutoSizeColumnMode.AllCells;

			dgv.Columns["Tarifa"].AutoSizeMode =
				DataGridViewAutoSizeColumnMode.AllCells;

			dgv.Columns["Importe"].AutoSizeMode =
				DataGridViewAutoSizeColumnMode.AllCells;
		}
		public void CargarTodoDatos(DateTime fecha)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				string consulta = @"
			SELECT
				C.id_employeeCost,
				C.d_fecha,
				C.id_employee,

				CONCAT(
					E.v_name, ' ',
					E.v_lastNamePat, ' ',
					E.v_lastNameMat
				) AS Empleado,

				C.id_workGroup,
				C.c_tipo,
				C.id_lot,
				C.v_concepto,
				C.v_lineas,
				C.m_costo,
				C.m_porcentajeLinea,
				C.m_cantidad,
				C.m_horas,
				C.m_tarifaHora,
				C.m_importe,
				C.v_userCreate,
				C.d_create

			FROM Nom_EmployeeCostAplicador C

			INNER JOIN Nom_Employees E
				ON C.id_employee = E.id_employee

			WHERE C.d_fecha = @fecha

			ORDER BY
				C.id_employeeCost DESC;";

				SqlCommand cmd = new SqlCommand(consulta, sql.cnn);
				cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha.Date;

				SqlDataReader dr = cmd.ExecuteReader();

				frm.dgvTodoDatos.Rows.Clear();

				while (dr.Read())
				{
					int fila = frm.dgvTodoDatos.Rows.Add();

					frm.dgvTodoDatos.Rows[fila].Cells["IdEmployeeCost"].Value =
						dr["id_employeeCost"].ToString();

					frm.dgvTodoDatos.Rows[fila].Cells["Fecha"].Value =
						Convert.ToDateTime(dr["d_fecha"])
							.ToString("dd/MM/yyyy");

					frm.dgvTodoDatos.Rows[fila].Cells["IdEmployee"].Value =
						dr["id_employee"].ToString();

					frm.dgvTodoDatos.Rows[fila].Cells["Empleado"].Value =
						dr["Empleado"].ToString();

					frm.dgvTodoDatos.Rows[fila].Cells["IdWorkGroup"].Value =
						dr["id_workGroup"].ToString();

					frm.dgvTodoDatos.Rows[fila].Cells["Tipo"].Value =
						dr["c_tipo"].ToString();

					frm.dgvTodoDatos.Rows[fila].Cells["IdLot"].Value =
						dr["id_lot"] == DBNull.Value
							? ""
							: dr["id_lot"].ToString();

					frm.dgvTodoDatos.Rows[fila].Cells["Concepto"].Value =
						dr["v_concepto"] == DBNull.Value
							? ""
							: dr["v_concepto"].ToString();

					frm.dgvTodoDatos.Rows[fila].Cells["Lineas"].Value =
						dr["v_lineas"] == DBNull.Value
							? ""
							: dr["v_lineas"].ToString();

					frm.dgvTodoDatos.Rows[fila].Cells["Cantidad"].Value =
						dr["m_cantidad"] == DBNull.Value
							? ""
							: Convert.ToDecimal(dr["m_cantidad"])
								.ToString("N2");

					// ==========================================
					// TARIFA
					// ==========================================

					if (dr["c_tipo"].ToString() == "CUADRO")
					{
						frm.dgvTodoDatos.Rows[fila].Cells["Tarifa"].Value =
							dr["m_porcentajeLinea"] == DBNull.Value
								? ""
								: Convert.ToDecimal(
									dr["m_porcentajeLinea"])
									.ToString("$ #,##0.00");
					}
					else if (dr["c_tipo"].ToString() == "HORAS")
					{
						frm.dgvTodoDatos.Rows[fila].Cells["Tarifa"].Value =
							dr["m_tarifaHora"] == DBNull.Value
								? ""
								: Convert.ToDecimal(
									dr["m_tarifaHora"])
									.ToString("$ #,##0.00");
					}

					// ==========================================
					// IMPORTE
					// ==========================================

					frm.dgvTodoDatos.Rows[fila].Cells["Importe"].Value =
						dr["m_importe"] == DBNull.Value
							? ""
							: Convert.ToDecimal(
								dr["m_importe"])
								.ToString("$ #,##0.00");
				}

				dr.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Cargar costos",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public bool EliminarCosto(string idEmployeeCost)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				string consulta = @"
            DELETE FROM Nom_EmployeeCostAplicador
            WHERE id_employeeCost = @id_employeeCost;";

				SqlCommand cmd = new SqlCommand(consulta, sql.cnn);

				cmd.Parameters.Add("@id_employeeCost", SqlDbType.Char, 10)
					.Value = idEmployeeCost;

				int filasAfectadas = cmd.ExecuteNonQuery();

				return filasAfectadas > 0;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Eliminar registro",
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
