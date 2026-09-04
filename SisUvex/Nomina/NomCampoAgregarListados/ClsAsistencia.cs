using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using PdfiumViewer;

namespace SisUvex.Nomina.NomCampoAgregarListados
{
	public class ClsAsistencia
	{
		private SQLControl sql = new SQLControl();
		public FrmAsistencia _frmA;
		public FrmListados frm;
		public FrmAgregar frmA;
		public class Semana
		{
			public string Secuencia { get; set; }
			public DateTime FechaInicio { get; set; }
			public DateTime FechaFin { get; set; }

			public string Texto
			{
				get
				{
					return $"{Secuencia} - {FechaInicio:dd/MM/yyyy} al {FechaFin:dd/MM/yyyy}";
				}
			}
		}
		public void CargarCuadrillas()
		{
			string query = @"
		SELECT 
			id_workGroup,
			v_nameWorkGroup
		FROM dbo.Nom_WorkGroup
		WHERE c_active = '1'
		ORDER BY id_workGroup";

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
				row["Descripcion"] =
					row["id_workGroup"].ToString() +
					" - " +
					row["v_nameWorkGroup"].ToString();
			}

			_frmA.cboCuadrilla.DataSource = dt;
			_frmA.cboCuadrilla.DisplayMember = "Descripcion";
			_frmA.cboCuadrilla.ValueMember = "id_workGroup";

			_frmA.cboCuadrilla.DropDownStyle = ComboBoxStyle.DropDown;
			_frmA.cboCuadrilla.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			_frmA.cboCuadrilla.AutoCompleteSource = AutoCompleteSource.ListItems;

			_frmA.cboCuadrilla.SelectedIndex = -1;
			_frmA.cboCuadrilla.Text = "";
		}
		public void CargarSemanas()
		{
			string query = @"
        SELECT
            id_period,
            c_sequence_per,
            d_startDate_per,
            d_endDate_per,
            v_name_per
        FROM dbo.Payroll_AttendancePeriod
        WHERE c_active = '1'
        ORDER BY d_startDate_per DESC";

			DataTable dt = new DataTable();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				using (SqlDataAdapter da = new SqlDataAdapter(cmd))
				{
					da.Fill(dt);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al cargar las semanas:\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				sql.CloseConectionWrite();
			}

			_frmA.cboSemana.DataSource = dt;
			_frmA.cboSemana.DisplayMember = "v_name_per";
			_frmA.cboSemana.ValueMember = "c_sequence_per";

			SeleccionarSemanaActual(dt);
		}

		private void SeleccionarSemanaActual(DataTable dt)
		{
			DateTime fechaActual = DateTime.Today;

			foreach (DataRow row in dt.Rows)
			{
				DateTime fechaInicio =
					Convert.ToDateTime(
						row["d_startDate_per"]).Date;

				DateTime fechaFin =
					Convert.ToDateTime(
						row["d_endDate_per"]).Date;

				if (fechaActual >= fechaInicio &&
					fechaActual <= fechaFin)
				{
					_frmA.cboSemana.SelectedValue =
						row["c_sequence_per"];

					return;
				}
			}

			_frmA.cboSemana.SelectedIndex = -1;
		}
		public DataTable CargarEmpleadosCuadrillaSemana(
	string idCuadrilla,
	string secuenciaSemana,
	DateTime fechaInicio,
	DateTime fechaFin)
		{
			DataTable dt = new DataTable();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"sp_GetEmployeesWorkGroupByWeek",
					sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(
						"@c_sequence_per",
						secuenciaSemana);

					cmd.Parameters.AddWithValue(
						"@d_startDate_per",
						fechaInicio.Date);

					cmd.Parameters.AddWithValue(
						"@d_endDate_per",
						fechaFin.Date);

					cmd.Parameters.AddWithValue(
						"@id_workGroup",
						idCuadrilla);

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
					"Error al cargar empleados:\n" + ex.Message,
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
		private DataRow ObtenerSemanaSeleccionada()
		{
			if (_frmA.cboSemana.SelectedIndex == -1)
				return null;

			DataRowView rowView = _frmA.cboSemana.SelectedItem as DataRowView;

			if (rowView == null)
				return null;

			return rowView.Row;
		}

		public void CargarEmpleados()
		{
			if (_frmA.cboCuadrilla.SelectedIndex == -1)
				return;

			if (_frmA.cboSemana.SelectedIndex == -1)
				return;

			string idCuadrilla =
				_frmA.cboCuadrilla.SelectedValue.ToString().Trim();

			DataRow semana = ObtenerSemanaSeleccionada();

			if (semana == null)
				return;

			string secuenciaSemana =
				semana["c_sequence_per"].ToString();

			DateTime fechaInicio =
				Convert.ToDateTime(
					semana["d_startDate_per"]).Date;

			DateTime fechaFin =
				Convert.ToDateTime(
					semana["d_endDate_per"]).Date;


			// ==========================================
			// CARGAR EMPLEADOS DE LA CUADRILLA
			// ==========================================

			DataTable dt =
				CargarEmpleadosCuadrillaSemana(
					idCuadrilla,
					secuenciaSemana,
					fechaInicio,
					fechaFin);


			// ==========================================
			// COLUMNAS DE ASISTENCIA
			// ==========================================

			string[] dias =
			{
		"Vie",
		"Sab",
		"Dom",
		"Lun",
		"Mar",
		"Mie",
		"Jue"
	};

			foreach (string dia in dias)
			{
				if (!dt.Columns.Contains(dia))
				{
					dt.Columns.Add(dia, typeof(bool));
				}
			}


			// ==========================================
			// INICIALIZAR
			// ==========================================

			foreach (DataRow row in dt.Rows)
			{
				foreach (string dia in dias)
				{
					row[dia] = false;
				}
			}


			// ==========================================
			// MOSTRAR EMPLEADOS
			// ==========================================

			_frmA.dgvAsistencia.DataSource = dt;

			AgregarSeleccionador();


			// ==========================================
			// CARGAR ASISTENCIA GUARDADA
			// ==========================================

			DataTable dtAsistencia =
				CargarAsistenciaSemanal(
					secuenciaSemana,
					fechaInicio,
					fechaFin);

			if (dtAsistencia == null)
				return;


			// ==========================================
			// MARCAR LOS DÍAS DE LA CUADRILLA ACTUAL
			// ==========================================

			foreach (DataRow empleado in dt.Rows)
			{
				string idEmployee =
					empleado["Codigo"]?.ToString()?.Trim();

				if (string.IsNullOrWhiteSpace(idEmployee))
					continue;


				DataRow[] registros =
					dtAsistencia.Select(
						$"id_employee = '{idEmployee.Replace("'", "''")}'");

				if (registros.Length == 0)
					continue;


				DataRow asistencia = registros[0];


				// VIE
				bool vie =
					asistencia["b_vie"] != DBNull.Value &&
					Convert.ToBoolean(asistencia["b_vie"]);

				string grupoVie =
					asistencia["id_workGroup_vie"]?.ToString().Trim();

				empleado["Vie"] =
					vie && grupoVie == idCuadrilla;


				// SAB
				bool sab =
					asistencia["b_sab"] != DBNull.Value &&
					Convert.ToBoolean(asistencia["b_sab"]);

				string grupoSab =
					asistencia["id_workGroup_sab"]?.ToString().Trim();

				empleado["Sab"] =
					sab && grupoSab == idCuadrilla;


				// DOM
				bool dom =
					asistencia["b_dom"] != DBNull.Value &&
					Convert.ToBoolean(asistencia["b_dom"]);

				string grupoDom =
					asistencia["id_workGroup_dom"]?.ToString().Trim();

				empleado["Dom"] =
					dom && grupoDom == idCuadrilla;


				// LUN
				bool lun =
					asistencia["b_lun"] != DBNull.Value &&
					Convert.ToBoolean(asistencia["b_lun"]);

				string grupoLun =
					asistencia["id_workGroup_lun"]?.ToString().Trim();

				empleado["Lun"] =
					lun && grupoLun == idCuadrilla;


				// MAR
				bool mar =
					asistencia["b_mar"] != DBNull.Value &&
					Convert.ToBoolean(asistencia["b_mar"]);

				string grupoMar =
					asistencia["id_workGroup_mar"]?.ToString().Trim();

				empleado["Mar"] =
					mar && grupoMar == idCuadrilla;


				// MIE
				bool mie =
					asistencia["b_mie"] != DBNull.Value &&
					Convert.ToBoolean(asistencia["b_mie"]);

				string grupoMie =
					asistencia["id_workGroup_mie"]?.ToString().Trim();

				empleado["Mie"] =
					mie && grupoMie == idCuadrilla;


				// JUE
				bool jue =
					asistencia["b_jue"] != DBNull.Value &&
					Convert.ToBoolean(asistencia["b_jue"]);

				string grupoJue =
					asistencia["id_workGroup_jue"]?.ToString().Trim();

				empleado["Jue"] =
					jue && grupoJue == idCuadrilla;
			}


			// ==========================================
			// BLOQUEAR DÍAS DE OTRA CUADRILLA
			// ==========================================

			foreach (DataGridViewRow fila in _frmA.dgvAsistencia.Rows)
			{
				if (fila.IsNewRow)
					continue;

				string idEmployee =
					fila.Cells["Codigo"].Value?
					.ToString()
					.Trim();

				if (string.IsNullOrWhiteSpace(idEmployee))
					continue;


				DataRow[] registros =
					dtAsistencia.Select(
						$"id_employee = '{idEmployee.Replace("'", "''")}'");

				if (registros.Length == 0)
					continue;


				DataRow asistencia = registros[0];


				BloquearDia(
					fila,
					"Vie",
					Convert.ToBoolean(asistencia["b_vie"]),
					idCuadrilla,
					asistencia["id_workGroup_vie"]?.ToString().Trim());

				BloquearDia(
					fila,
					"Sab",
					Convert.ToBoolean(asistencia["b_sab"]),
					idCuadrilla,
					asistencia["id_workGroup_sab"]?.ToString().Trim());

				BloquearDia(
					fila,
					"Dom",
					Convert.ToBoolean(asistencia["b_dom"]),
					idCuadrilla,
					asistencia["id_workGroup_dom"]?.ToString().Trim());

				BloquearDia(
					fila,
					"Lun",
					Convert.ToBoolean(asistencia["b_lun"]),
					idCuadrilla,
					asistencia["id_workGroup_lun"]?.ToString().Trim());

				BloquearDia(
					fila,
					"Mar",
					Convert.ToBoolean(asistencia["b_mar"]),
					idCuadrilla,
					asistencia["id_workGroup_mar"]?.ToString().Trim());

				BloquearDia(
					fila,
					"Mie",
					Convert.ToBoolean(asistencia["b_mie"]),
					idCuadrilla,
					asistencia["id_workGroup_mie"]?.ToString().Trim());

				BloquearDia(
					fila,
					"Jue",
					Convert.ToBoolean(asistencia["b_jue"]),
					idCuadrilla,
					asistencia["id_workGroup_jue"]?.ToString().Trim());
			}


			// ==========================================
			// MOSTRAR
			// ==========================================

			_frmA.dgvAsistencia.Refresh();

			_frmA.dgvAsistencia.Visible = true;

			_frmA.dgvAsistencia.BringToFront();

			_frmA.dgvAsistencia.ClearSelection();

			_frmA.dgvAsistencia.CurrentCell = null;
		}
		private void BloquearDia(
	DataGridViewRow fila,
	string columna,
	bool tieneAsistencia,
	string idCuadrillaActual,
	string idCuadrillaExistente)
		{
			// Limpiar primero
			fila.Cells[columna].ReadOnly = false;
			fila.Cells[columna].ToolTipText = "";

			if (!tieneAsistencia)
				return;

			if (string.IsNullOrWhiteSpace(idCuadrillaExistente))
				return;

			if (idCuadrillaExistente == idCuadrillaActual)
				return;


			// ==========================================
			// YA ESTÁ EN OTRA CUADRILLA
			// ==========================================

			fila.Cells[columna].ReadOnly = true;

			string nombreCuadrilla =
				ObtenerNombreCuadrilla(idCuadrillaExistente);

			fila.Cells[columna].ToolTipText =
				"Este día ya tiene asistencia en la cuadrilla "
				+ nombreCuadrilla;
		}
		private string ObtenerNombreCuadrilla(string idCuadrilla)
		{
			if (string.IsNullOrWhiteSpace(idCuadrilla))
				return idCuadrilla;

			foreach (object item in _frmA.cboCuadrilla.Items)
			{
				DataRowView row = item as DataRowView;

				if (row != null)
				{
					string id =
						row[_frmA.cboCuadrilla.ValueMember]
						?.ToString()
						.Trim();

					if (id == idCuadrilla)
					{
						return _frmA.cboCuadrilla.GetItemText(item);
					}
				}
			}

			return idCuadrilla;
		}
		public void AgregarSeleccionador()
		{
			DataGridView dgv = _frmA.dgvAsistencia;

			if (dgv.Columns.Contains("Seleccionar"))
				return;

			DataGridViewCheckBoxColumn chk =
				new DataGridViewCheckBoxColumn();

			chk.Name = "Seleccionar";
			chk.HeaderText = "";
			chk.Width = 40;
			chk.MinimumWidth = 40;

			chk.ReadOnly = false;

			chk.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.Columns.Insert(0, chk);

			// Evita que Fill cambie el tamaño del checkbox
			dgv.Columns["Seleccionar"].AutoSizeMode =
				DataGridViewAutoSizeColumnMode.None;

			dgv.Columns["Seleccionar"].Width = 40;
		}
		public void SeleccionarTodos()
		{
			DataGridView dgv = _frmA.dgvAsistencia;

			bool todosSeleccionados = true;

			foreach (DataGridViewRow fila in dgv.Rows)
			{
				if (fila.IsNewRow)
					continue;

				bool seleccionado =
					fila.Cells["Seleccionar"].Value != null &&
					Convert.ToBoolean(
						fila.Cells["Seleccionar"].Value);

				if (!seleccionado)
				{
					todosSeleccionados = false;
					break;
				}
			}

			bool nuevoValor = !todosSeleccionados;

			foreach (DataGridViewRow fila in dgv.Rows)
			{
				if (fila.IsNewRow)
					continue;

				fila.Cells["Seleccionar"].Value = nuevoValor;
			}

			dgv.EndEdit();
			dgv.Refresh();
		}
		public void ConfigurarGrid()
		{
			_frmA.dgvAsistencia.Columns.Clear();

			DataGridView dgv = _frmA.dgvAsistencia;

			// CONFIGURACIÓN GENERAL

			dgv.ReadOnly = false;

			dgv.EditMode =
				DataGridViewEditMode.EditOnEnter;

			dgv.AutoGenerateColumns = false;

			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToResizeRows = false;

			dgv.RowHeadersVisible = false;

			dgv.SelectionMode =
				DataGridViewSelectionMode.FullRowSelect;

			dgv.MultiSelect = false;

			dgv.BackgroundColor = Color.White;

			dgv.BorderStyle =
				BorderStyle.None;

			dgv.CellBorderStyle =
				DataGridViewCellBorderStyle.SingleHorizontal;

			dgv.GridColor =
				Color.FromArgb(220, 220, 220);

			// TAMAÑO

			dgv.ColumnHeadersHeight = 42;
			dgv.RowTemplate.Height = 28;

			// ENCABEZADO

			dgv.EnableHeadersVisualStyles = false;

			dgv.ColumnHeadersDefaultCellStyle.BackColor =
				Color.FromArgb(22, 32, 45);

			dgv.ColumnHeadersDefaultCellStyle.ForeColor =
				Color.White;

			dgv.ColumnHeadersDefaultCellStyle.Font =
				new Font("Segoe UI", 9, FontStyle.Bold);

			dgv.ColumnHeadersDefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor =
				Color.FromArgb(22, 32, 45);

			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor =
				Color.White;

			// FILAS

			dgv.DefaultCellStyle.Font =
				new Font("Segoe UI", 9);

			dgv.DefaultCellStyle.BackColor =
				Color.FromArgb(248, 249, 251);

			dgv.DefaultCellStyle.ForeColor =
				Color.FromArgb(40, 40, 40);

			dgv.DefaultCellStyle.SelectionBackColor =
				Color.FromArgb(190, 205, 222);

			dgv.DefaultCellStyle.SelectionForeColor =
				Color.Black;

			dgv.AlternatingRowsDefaultCellStyle.BackColor =
				Color.FromArgb(238, 241, 245);

			// COLUMNAS

			dgv.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.Fill;

			// SELECCIONAR

			DataGridViewCheckBoxColumn colSeleccionar =
				new DataGridViewCheckBoxColumn();

			colSeleccionar.Name = "Seleccionar";
			colSeleccionar.HeaderText = "✓";
			colSeleccionar.Width = 40;
			colSeleccionar.MinimumWidth = 40;

			colSeleccionar.AutoSizeMode =
				DataGridViewAutoSizeColumnMode.None;

			colSeleccionar.ReadOnly = false;

			colSeleccionar.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			// Encabezado
			colSeleccionar.HeaderCell.Style.BackColor =
				Color.FromArgb(22, 32, 45);

			colSeleccionar.HeaderCell.Style.ForeColor =
				Color.White;

			// Agregar PRIMERO
			dgv.Columns.Add(colSeleccionar);

			// CÓDIGO

			DataGridViewTextBoxColumn colCodigo =
				new DataGridViewTextBoxColumn();

			colCodigo.Name = "Codigo";
			colCodigo.HeaderText = "CÓDIGO";
			colCodigo.DataPropertyName = "Codigo";

			colCodigo.FillWeight = 1.2f;

			colCodigo.ReadOnly = true;

			colCodigo.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			colCodigo.HeaderCell.Style.BackColor =
				Color.FromArgb(22, 32, 45);

			colCodigo.HeaderCell.Style.ForeColor =
				Color.White;

			colCodigo.HeaderCell.Style.Font =
				new Font("Segoe UI", 9, FontStyle.Bold);

			colCodigo.HeaderCell.Style.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.Columns.Add(colCodigo);

			// EMPLEADO

			DataGridViewTextBoxColumn colEmpleado =
				new DataGridViewTextBoxColumn();

			colEmpleado.Name = "Empleado";
			colEmpleado.HeaderText = "EMPLEADO";
			colEmpleado.DataPropertyName = "Empleado";

			colEmpleado.AutoSizeMode =
				DataGridViewAutoSizeColumnMode.Fill;

			colEmpleado.FillWeight = 5;

			colEmpleado.ReadOnly = true;

			colEmpleado.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleLeft;

			colEmpleado.HeaderCell.Style.BackColor =
				Color.FromArgb(22, 32, 45);

			colEmpleado.HeaderCell.Style.ForeColor =
				Color.White;

			colEmpleado.HeaderCell.Style.Font =
				new Font("Segoe UI", 9, FontStyle.Bold);

			dgv.Columns.Add(colEmpleado);

			// DÍAS

			AgregarColumnaDia("Vie", "VIE");
			AgregarColumnaDia("Sab", "SÁB");
			AgregarColumnaDia("Dom", "DOM");
			AgregarColumnaDia("Lun", "LUN");
			AgregarColumnaDia("Mar", "MAR");
			AgregarColumnaDia("Mie", "MIÉ");
			AgregarColumnaDia("Jue", "JUE");

			// QUITAR SELECCIÓN INICIAL

			dgv.ClearSelection();
			dgv.CurrentCell = null;
		}
		private void AgregarColumnaDia(string nombre, string encabezado)
		{
			DataGridViewCheckBoxColumn columna =
				new DataGridViewCheckBoxColumn();

			columna.Name = nombre;
			columna.HeaderText = encabezado;
			columna.DataPropertyName = nombre;

			// Los días ocupan el espacio disponible
			columna.AutoSizeMode =
				DataGridViewAutoSizeColumnMode.Fill;

			// Todos los días tienen el mismo tamaño
			columna.FillWeight = 1;

			// PERMITIR MODIFICAR
			columna.ReadOnly = false;

			// Checkbox centrado
			columna.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			_frmA.dgvAsistencia.Columns.Add(columna);
		}

		public void DgvAsistencia_ColumnHeaderMouseClick(
	object sender,
	DataGridViewCellMouseEventArgs e)
		{
			DataGridView dgv = _frmA.dgvAsistencia;

			string nombreColumna =
				dgv.Columns[e.ColumnIndex].Name;

			string[] dias =
			{
				"Vie",
				"Sab",
				"Dom",
				"Lun",
				"Mar",
				"Mie",
				"Jue"
			};

			// SI ES UN DÍA

			if (dias.Contains(nombreColumna))
			{
				bool marcarTodos = false;

				foreach (DataGridViewRow row in dgv.Rows)
				{
					if (row.IsNewRow)
						continue;

					DataGridViewCell celda =
						row.Cells[nombreColumna];

					if (celda.ReadOnly)
						continue;

					bool marcado =
						celda.Value != null &&
						celda.Value != DBNull.Value &&
						Convert.ToBoolean(celda.Value);

					if (!marcado)
					{
						marcarTodos = true;
						break;
					}
				}

				foreach (DataGridViewRow row in dgv.Rows)
				{
					if (row.IsNewRow)
						continue;

					DataGridViewCell celda =
						row.Cells[nombreColumna];

					if (celda.ReadOnly)
						continue;

					// Cambiar visualmente
					celda.Value = marcarTodos;

					// Cambiar también el DataTable
					DataRowView drv =
						row.DataBoundItem as DataRowView;

					if (drv != null)
					{
						drv.Row[nombreColumna] = marcarTodos;
					}
				}

				dgv.EndEdit();
				dgv.Refresh();

				return;
			}

			// CÓDIGO / EMPLEADO

			// NO HACEMOS NADA.

			// El DataGridView realizará su ordenamiento
			// normal y los CheckBox permanecerán ligados
			// al empleado mediante el DataTable.
		}
		public MemoryStream GenerarPdfAsistenciaCuadrilla(DataGridView dgv)
		{
			MemoryStream ms = new MemoryStream();

			// CREAR PDF

			iText.Kernel.Pdf.PdfWriter writer =
				new iText.Kernel.Pdf.PdfWriter(ms);

			writer.SetCloseStream(false);

			iText.Kernel.Pdf.PdfDocument pdf =
				new iText.Kernel.Pdf.PdfDocument(writer);


			pdf.SetDefaultPageSize(
			iText.Kernel.Geom.PageSize.LETTER);

			iText.Layout.Document document =
				new iText.Layout.Document(pdf);

			document.SetMargins(25, 25, 25, 25);

			// COLORES

			iText.Kernel.Colors.DeviceRgb colorHeader =
				new iText.Kernel.Colors.DeviceRgb(25, 35, 48);

			iText.Kernel.Colors.DeviceRgb colorBorde =
				new iText.Kernel.Colors.DeviceRgb(90, 90, 90);

			iText.Kernel.Colors.DeviceRgb colorAzul =
				new iText.Kernel.Colors.DeviceRgb(0, 102, 204);

			// TÍTULO

			iText.Layout.Element.Paragraph titulo =
				new iText.Layout.Element.Paragraph(
					"ASISTENCIA PARA REVISIÓN");

			titulo
			.SetFontSize(16)
			.SetTextAlignment(
				iText.Layout.Properties.TextAlignment.CENTER);

			document.Add(titulo);

			// INFORMACIÓN

			string cuadrilla = "";

			if (_frmA != null &&
				_frmA.cboCuadrilla != null)
			{
				cuadrilla = _frmA.cboCuadrilla.Text;
			}

			string semana = "";

			if (_frmA != null &&
				_frmA.cboSemana != null)
			{
				semana = _frmA.cboSemana.Text;
			}

			iText.Layout.Element.Table info =
				new iText.Layout.Element.Table(
					iText.Layout.Properties.UnitValue
						.CreatePercentArray(new float[] { 1, 1 }))
				.UseAllAvailableWidth();

			iText.Layout.Element.Cell celdaCuadrilla =
				new iText.Layout.Element.Cell()
				.SetBorder(
					iText.Layout.Borders.Border.NO_BORDER)
				.Add(
					new iText.Layout.Element.Paragraph(
						"Cuadrilla: " + cuadrilla)
					.SetFontSize(9));

			iText.Layout.Element.Cell celdaSemana =
				new iText.Layout.Element.Cell()
				.SetBorder(
					iText.Layout.Borders.Border.NO_BORDER)
				.Add(
					new iText.Layout.Element.Paragraph(
						"Semana: " + semana)
					.SetFontSize(9));

			info.AddCell(celdaCuadrilla);
			info.AddCell(celdaSemana);

			document.Add(info);

			// Espacio
			document.Add(
				new iText.Layout.Element.Paragraph(" ")
					.SetFontSize(3));

			// TABLA

			float[] anchos =
			{
				55,     // Código
				250,    // Empleado
				37,     // Vie
				37,     // Sáb
				37,     // Dom
				37,     // Lun
				37,     // Mar
				37,     // Mié
				37      // Jue
			};

			iText.Layout.Element.Table tabla =
				new iText.Layout.Element.Table(
					anchos);

			tabla.SetWidth(
			iText.Layout.Properties.UnitValue
			.CreatePercentValue(100));

			// ENCABEZADOS

			string[] encabezados =
			{
				"CÓDIGO",
				"EMPLEADO",
				"VIE",
				"SÁB",
				"DOM",
				"LUN",
				"MAR",
				"MIÉ",
				"JUE"
			};

			foreach (string encabezado in encabezados)
			{
				iText.Layout.Element.Cell celda =
					new iText.Layout.Element.Cell();

				celda
					.SetBackgroundColor(colorHeader)
					.SetFontColor(
						iText.Kernel.Colors.ColorConstants.WHITE)
					.SetTextAlignment(
						iText.Layout.Properties.TextAlignment.CENTER)
					.SetVerticalAlignment(
						iText.Layout.Properties.VerticalAlignment.MIDDLE)
					.SetPadding(3)
					.SetBorder(
						new iText.Layout.Borders.SolidBorder(
							colorBorde, 0.5f));

				celda.Add(
				new iText.Layout.Element.Paragraph(encabezado)
				.SetFontSize(8)
				);

				tabla.AddHeaderCell(celda);
			}

			// FILAS

			string[] columnas =
			{
				"Codigo",
				"Empleado",
				"Vie",
				"Sab",
				"Dom",
				"Lun",
				"Mar",
				"Mie",
				"Jue"
			};

			foreach (DataGridViewRow row in dgv.Rows)
			{
				if (row.IsNewRow)
					continue;

				for (int i = 0; i < columnas.Length; i++)
				{
					string nombreColumna = columnas[i];

					if (!dgv.Columns.Contains(nombreColumna))
						continue;

					object valor =
						row.Cells[nombreColumna].Value;

					// CÓDIGO Y EMPLEADO

					if (i < 2)
					{
						string texto =
							valor == null || valor == DBNull.Value ? "" : valor.ToString();

						iText.Layout.Element.Cell celda =
							new iText.Layout.Element.Cell();

						celda
							.SetPadding(3)
							.SetVerticalAlignment(
								iText.Layout.Properties.VerticalAlignment.MIDDLE)
							.SetBorder(
								new iText.Layout.Borders.SolidBorder(
									colorBorde, 0.5f));

						celda.Add(
							new iText.Layout.Element.Paragraph(texto)
								.SetFontSize(7));

						tabla.AddCell(celda);
					}
					else
					{

						// CHECKBOX

						bool marcado = false;

						if (valor != null &&
							valor != DBNull.Value)
						{
							bool.TryParse(
								valor.ToString(),
								out marcado);
						}

						iText.Layout.Element.Cell celda =
							new iText.Layout.Element.Cell();

						celda
							.SetTextAlignment(
								iText.Layout.Properties.TextAlignment.CENTER)
							.SetVerticalAlignment(
								iText.Layout.Properties.VerticalAlignment.MIDDLE)
							.SetPadding(3)
							.SetBorder(
								new iText.Layout.Borders.SolidBorder(
									colorBorde, 0.5f));

						// SIN NARANJA

						if (marcado)
						{
							celda.Add(
								new iText.Layout.Element.Paragraph("✓")
									.SetFontSize(9)
									.SetFontColor(colorAzul));
						}
						else
						{
							celda.Add(
								new iText.Layout.Element.Paragraph("□")
									.SetFontSize(8)
									.SetFontColor(
										iText.Kernel.Colors.ColorConstants.DARK_GRAY));
						}

						tabla.AddCell(celda);
					}
				}
			}

			document.Add(tabla);

			// CERRAR

			document.Close();

			ms.Position = 0;

			return ms;
		}
		public void ShowPdfViewer(MemoryStream ms)
		{
			Form visor = new Form();

			visor.Text = "SisUvex - Vista de Asistencia";

			visor.WindowState =
				FormWindowState.Maximized;

			visor.StartPosition =
				FormStartPosition.CenterScreen;

			PdfiumViewer.PdfViewer pdfViewer =
				new PdfiumViewer.PdfViewer();

			pdfViewer.Dock =
				DockStyle.Fill;

			visor.Controls.Add(pdfViewer);

			ms.Position = 0;

			pdfViewer.Document =
				PdfiumViewer.PdfDocument.Load(ms);

			visor.ShowDialog();

			pdfViewer.Dispose();
			ms.Dispose();
		}

		public bool GuardarAsistenciaSemanal(
	string cSequencePer,
	DateTime fechaInicio,
	DateTime fechaFin,
	string idEmployee,

	bool asistenciaVie,
	string cuadrillaVie,

	bool asistenciaSab,
	string cuadrillaSab,

	bool asistenciaDom,
	string cuadrillaDom,

	bool asistenciaLun,
	string cuadrillaLun,

	bool asistenciaMar,
	string cuadrillaMar,

	bool asistenciaMie,
	string cuadrillaMie,

	bool asistenciaJue,
	string cuadrillaJue,

	string usuario)
		{
			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"sp_UpdateAsistenciaManual",
					sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@c_sequence_per", SqlDbType.Char, 2)
						.Value = cSequencePer;

					cmd.Parameters.Add("@d_startDate_per", SqlDbType.Date)
						.Value = fechaInicio.Date;

					cmd.Parameters.Add("@d_endDate_per", SqlDbType.Date)
						.Value = fechaFin.Date;

					cmd.Parameters.Add("@id_employee", SqlDbType.Char, 6)
						.Value = idEmployee;


					// ==============================
					// VIE
					// ==============================

					cmd.Parameters.Add("@b_vie", SqlDbType.Bit)
						.Value = asistenciaVie;

					cmd.Parameters.Add("@id_workGroup_vie", SqlDbType.Char, 4)
						.Value = cuadrillaVie ?? "";


					// ==============================
					// SAB
					// ==============================

					cmd.Parameters.Add("@b_sab", SqlDbType.Bit)
						.Value = asistenciaSab;

					cmd.Parameters.Add("@id_workGroup_sab", SqlDbType.Char, 4)
						.Value = cuadrillaSab ?? "";


					// ==============================
					// DOM
					// ==============================

					cmd.Parameters.Add("@b_dom", SqlDbType.Bit)
						.Value = asistenciaDom;

					cmd.Parameters.Add("@id_workGroup_dom", SqlDbType.Char, 4)
						.Value = cuadrillaDom ?? "";


					// ==============================
					// LUN
					// ==============================

					cmd.Parameters.Add("@b_lun", SqlDbType.Bit)
						.Value = asistenciaLun;

					cmd.Parameters.Add("@id_workGroup_lun", SqlDbType.Char, 4)
						.Value = cuadrillaLun ?? "";


					// ==============================
					// MAR
					// ==============================

					cmd.Parameters.Add("@b_mar", SqlDbType.Bit)
						.Value = asistenciaMar;

					cmd.Parameters.Add("@id_workGroup_mar", SqlDbType.Char, 4)
						.Value = cuadrillaMar ?? "";


					// ==============================
					// MIE
					// ==============================

					cmd.Parameters.Add("@b_mie", SqlDbType.Bit)
						.Value = asistenciaMie;

					cmd.Parameters.Add("@id_workGroup_mie", SqlDbType.Char, 4)
						.Value = cuadrillaMie ?? "";


					// ==============================
					// JUE
					// ==============================

					cmd.Parameters.Add("@b_jue", SqlDbType.Bit)
						.Value = asistenciaJue;

					cmd.Parameters.Add("@id_workGroup_jue", SqlDbType.Char, 4)
						.Value = cuadrillaJue ?? "";


					// ==============================
					// USUARIO
					// ==============================

					cmd.Parameters.Add("@user", SqlDbType.VarChar, 100)
						.Value = usuario;


					cmd.ExecuteNonQuery();
				}

				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al guardar la asistencia:\n\n" + ex.Message,
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
		public void GuardarAsistencia()
		{
			_frmA.dgvAsistencia.EndEdit();

			if (_frmA.cboCuadrilla.SelectedIndex == -1)
				return;

			if (_frmA.cboSemana.SelectedIndex == -1)
				return;

			DataRow semana = ObtenerSemanaSeleccionada();

			if (semana == null)
				return;

			string cSequencePer =
				semana["c_sequence_per"].ToString().Trim();

			DateTime fechaInicio =
				Convert.ToDateTime(
					semana["d_startDate_per"]).Date;

			DateTime fechaFin =
				Convert.ToDateTime(
					semana["d_endDate_per"]).Date;

			string usuario = User.GetUserName();

			string idCuadrillaActual =
				_frmA.cboCuadrilla.SelectedValue?
				.ToString()
				.Trim();

			if (string.IsNullOrWhiteSpace(idCuadrillaActual))
				return;

			string[] dias =
			{
		"Vie",
		"Sab",
		"Dom",
		"Lun",
		"Mar",
		"Mie",
		"Jue"
	};


			// ==========================================
			// CARGAR LO QUE YA EXISTE EN LA SEMANA
			// ==========================================

			DataTable dtAsistencia =
				CargarAsistenciaSemanal(
					cSequencePer,
					fechaInicio,
					fechaFin);

			if (dtAsistencia == null)
				return;


			// ==========================================
			// VALIDAR DUPLICADOS
			// ==========================================

			List<string> conflictos = new List<string>();

			foreach (DataGridViewRow fila in _frmA.dgvAsistencia.Rows)
			{
				if (fila.IsNewRow)
					continue;

				string idEmployee =
					fila.Cells["Codigo"].Value?
					.ToString()
					.Trim();

				string empleado =
					fila.Cells["Empleado"].Value?
					.ToString()
					.Trim();

				if (string.IsNullOrWhiteSpace(idEmployee))
					continue;


				DataRow[] registros =
					dtAsistencia.Select(
						$"id_employee = '{idEmployee.Replace("'", "''")}'");

				DataRow existente =
					registros.Length > 0
					? registros[0]
					: null;


				for (int d = 0; d < dias.Length; d++)
				{
					bool asistenciaNueva =
						ObtenerValorCheckBox(
							fila,
							dias[d]);

					if (!asistenciaNueva)
						continue;


					if (existente == null)
						continue;


					string columnaB =
						"b_" + dias[d].ToLower();

					string columnaGrupo =
						"id_workGroup_" + dias[d].ToLower();


					bool asistenciaExistente =
						existente[columnaB] != DBNull.Value &&
						Convert.ToBoolean(
							existente[columnaB]);


					string grupoExistente =
						existente[columnaGrupo]?
						.ToString()
						.Trim();


					if (asistenciaExistente &&
						!string.IsNullOrWhiteSpace(grupoExistente) &&
						grupoExistente != idCuadrillaActual)
					{
						conflictos.Add(
							$"Empleado: {empleado} ({idEmployee}) - " +
							$"{dias[d]} " +
							$"{fechaInicio.AddDays(d):dd/MM/yyyy} - " +
							$"Cuadrilla existente: {grupoExistente}");
					}
				}
			}


			// ==========================================
			// SI HAY CONFLICTOS NO GUARDAR
			// ==========================================

			if (conflictos.Count > 0)
			{
				MessageBox.Show(
					"No se puede guardar la asistencia porque " +
					"los siguientes empleados ya tienen asistencia " +
					"en otra cuadrilla:\n\n" +
					string.Join("\n", conflictos),
					"Asistencia duplicada",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}


			// ==========================================
			// GUARDAR
			// ==========================================

			foreach (DataGridViewRow fila in _frmA.dgvAsistencia.Rows)
			{
				if (fila.IsNewRow)
					continue;

				string idEmployee =
					fila.Cells["Codigo"].Value?
					.ToString()
					.Trim();

				if (string.IsNullOrWhiteSpace(idEmployee))
					continue;


				// Buscar registro existente
				DataRow[] registros =
					dtAsistencia.Select(
						$"id_employee = '{idEmployee.Replace("'", "''")}'");

				DataRow existente =
					registros.Length > 0
					? registros[0]
					: null;


				// ==========================================
				// ASISTENCIAS ACTUALES DEL GRID
				// ==========================================

				bool[] asistencias = new bool[7];

				for (int d = 0; d < dias.Length; d++)
				{
					asistencias[d] =
						ObtenerValorCheckBox(
							fila,
							dias[d]);
				}


				// ==========================================
				// CUADRILLAS
				// ==========================================

				string[] cuadrillas = new string[7];

				for (int d = 0; d < dias.Length; d++)
				{
					string columnaB =
						"b_" + dias[d].ToLower();

					string columnaGrupo =
						"id_workGroup_" + dias[d].ToLower();


					// No existe registro todavía
					if (existente == null)
					{
						cuadrillas[d] =
							asistencias[d]
							? idCuadrillaActual
							: "";

						continue;
					}


					bool asistenciaExistente =
						existente[columnaB] != DBNull.Value &&
						Convert.ToBoolean(
							existente[columnaB]);


					string grupoExistente =
						existente[columnaGrupo]?
						.ToString()
						.Trim();


					// ======================================
					// EL DÍA YA ESTÁ EN OTRA CUADRILLA
					// ======================================

					if (asistenciaExistente &&
						!string.IsNullOrWhiteSpace(grupoExistente) &&
						grupoExistente != idCuadrillaActual)
					{
						// CONSERVAR
						asistencias[d] = true;
						cuadrillas[d] = grupoExistente;
					}
					else
					{
						// ==================================
						// ES DE LA CUADRILLA ACTUAL
						// ==================================

						cuadrillas[d] =
							asistencias[d]
							? idCuadrillaActual
							: "";
					}
				}


				// ==========================================
				// GUARDAR SEMANA
				// ==========================================

				GuardarAsistenciaSemanal(
					cSequencePer,
					fechaInicio,
					fechaFin,
					idEmployee,

					asistencias[0],
					cuadrillas[0],

					asistencias[1],
					cuadrillas[1],

					asistencias[2],
					cuadrillas[2],

					asistencias[3],
					cuadrillas[3],

					asistencias[4],
					cuadrillas[4],

					asistencias[5],
					cuadrillas[5],

					asistencias[6],
					cuadrillas[6],

					usuario);
			}


			MessageBox.Show(
				"La asistencia se guardó correctamente.",
				"Asistencia",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information);
		}
		private bool ObtenerValorCheckBox(DataGridViewRow fila,string columna)
		{
			object valor =
				fila.Cells[columna].EditedFormattedValue;

			if (valor == null ||
				valor == DBNull.Value)
				return false;

			return Convert.ToBoolean(valor);
		}
		public bool EmpleadoYaTieneAsistencia(string codigoEmpleado,DateTime fecha,string cSequencePer,string idCuadrilla,out string cuadrillaExistente)
		{
			cuadrillaExistente = "";

			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"sp_ValidarAsistenciaEmpleadoDia",
					sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add(
						"@id_employee",
						SqlDbType.Char,
						6).Value = codigoEmpleado;

					cmd.Parameters.Add(
						"@c_sequence_per",
						SqlDbType.VarChar).Value = cSequencePer;

					cmd.Parameters.Add(
						"@fecha",
						SqlDbType.Date).Value = fecha.Date;

					cmd.Parameters.Add(
						"@id_workGroup",
						SqlDbType.Char,
						4).Value = idCuadrilla;

					object resultado = cmd.ExecuteScalar();

					if (resultado != null &&
						resultado != DBNull.Value)
					{
						cuadrillaExistente =
							resultado.ToString().Trim();

						return true;
					}
				}

				return false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al validar la asistencia del empleado:\n\n" +
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
		
		public DataTable CargarAsistenciaSemanal(string cSequencePer,DateTime fechaInicio,DateTime fechaFin)
		{
			DataTable dt = new DataTable();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand("dbo.sp_GetAsistenciaSemanal",sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@c_sequence_per", SqlDbType.Char, 2)
						.Value = cSequencePer;

					cmd.Parameters.Add("@d_startDate_per", SqlDbType.Date)
						.Value = fechaInicio.Date;

					cmd.Parameters.Add("@d_endDate_per", SqlDbType.Date)
						.Value = fechaFin.Date;

					using (SqlDataAdapter da = new SqlDataAdapter(cmd))
					{
						da.Fill(dt);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al cargar la asistencia semanal:\n\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return null;
			}
			finally
			{
				sql.CloseConectionWrite();
			}

			return dt;
		}

		public void DgvAsistencia_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			if (e.RowIndex < 0 || e.ColumnIndex < 0)
				return;

			DataGridView dgv = sender as DataGridView;

			string[] dias =
			{
				"Vie",
				"Sab",
				"Dom",
				"Lun",
				"Mar",
				"Mie",
				"Jue"
			};

			string columna =
				dgv.Columns[e.ColumnIndex].Name;

			if (!dias.Contains(columna))
				return;

			DataGridViewCell celda =
				dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

			if (!celda.ReadOnly)
				return;

			e.PaintBackground(e.CellBounds, true);

			TextRenderer.DrawText(
				e.Graphics,
				"🔒",
				new Font("Segoe UI Emoji", 10),
				e.CellBounds,
				Color.Gray,
				TextFormatFlags.HorizontalCenter |
				TextFormatFlags.VerticalCenter);

			e.Handled = true;
		}
		public List<string> ObtenerEmpleadosSeleccionados()
		{
			List<string> empleados = new List<string>();

			foreach (DataGridViewRow fila in _frmA.dgvAsistencia.Rows)
			{
				if (fila.IsNewRow)
					continue;

				bool seleccionado = false;

				if (fila.Cells["Seleccionar"].Value != null)
				{
					seleccionado = Convert.ToBoolean(
						fila.Cells["Seleccionar"].Value);
				}

				if (seleccionado)
				{
					string codigo = fila.Cells["Codigo"].Value?.ToString();

					if (!string.IsNullOrWhiteSpace(codigo))
					{
						empleados.Add(codigo.Trim());
					}
				}
			}

			return empleados;
		}
		public void ConfigurarGridCAL()
		{
			DataGridView dgv = _frmA.dgvCAL;

			dgv.Columns.Clear();
			dgv.AutoGenerateColumns = false;
			dgv.AllowUserToAddRows = false;
			dgv.ReadOnly = true;
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			// Datos del empleado
			dgv.Columns.Add("Codigo", "Código");
			dgv.Columns["Codigo"].DataPropertyName = "Codigo";

			dgv.Columns.Add("Empleado", "Empleado");
			dgv.Columns["Empleado"].DataPropertyName = "Empleado";

			// Los días los agregaremos dinámicamente
		}
		public void CargarCAL()
		{
			SQLControl sql = new SQLControl();

			try
			{
				if (_frmA.cboSemana.SelectedItem == null)
					return;

				if (_frmA.cboCuadrilla.SelectedValue == null)
					return;

				DataRowView semana =
					_frmA.cboSemana.SelectedItem as DataRowView;

				if (semana == null)
					return;

				string secuencia =
					semana["c_sequence_per"].ToString().Trim();

				DateTime fechaInicio =
					Convert.ToDateTime(
						semana["d_startDate_per"]);

				DateTime fechaFin =
					Convert.ToDateTime(
						semana["d_endDate_per"]);

				string cuadrilla =
					_frmA.cboCuadrilla.SelectedValue
					.ToString()
					.Trim();

				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"sp_GetEmployeeAttendenceWeeklyCAL",
					sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add(
						"@c_sequence_per",
						SqlDbType.Char,
						2).Value = secuencia;

					cmd.Parameters.Add(
						"@d_startDate_per",
						SqlDbType.Date).Value = fechaInicio.Date;

					cmd.Parameters.Add(
						"@d_endDate_per",
						SqlDbType.Date).Value = fechaFin.Date;

					cmd.Parameters.Add(
						"@id_workGroup",
						SqlDbType.Char,
						4).Value = cuadrilla;

					using (SqlDataAdapter da =
						new SqlDataAdapter(cmd))
					{
						DataTable dt = new DataTable();

						da.Fill(dt);

						MostrarCAL(dt, fechaInicio, fechaFin);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al cargar los registros de lote y actividad:\n\n" +
					ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		private void MostrarCAL(DataTable dt,DateTime fechaInicio,DateTime fechaFin)
		{
			DataGridView dgv = _frmA.dgvCAL;

			dgv.Columns.Clear();
			dgv.Rows.Clear();

			dgv.AutoGenerateColumns = false;
			dgv.AllowUserToAddRows = false;
			dgv.ReadOnly = true;

			dgv.BackgroundColor = Color.White;
			dgv.BorderStyle = BorderStyle.None;

			dgv.EnableHeadersVisualStyles = false;

			// COLUMNAS FIJAS

			dgv.Columns.Add("Codigo", "Código");
			dgv.Columns.Add("Empleado", "Empleado");

			// COLUMNAS DE LOS DÍAS

			for (DateTime fecha = fechaInicio;
				 fecha <= fechaFin;
				 fecha = fecha.AddDays(1))
			{
				string nombreColumna =
					fecha.ToString("yyyyMMdd");

				dgv.Columns.Add(
					nombreColumna,
					fecha.ToString(
						"ddd dd",
						new System.Globalization.CultureInfo("es-MX")
					));
			}

			// AGRUPAR POR EMPLEADO

			var empleados = dt.AsEnumerable()
				.GroupBy(row =>
					row["Codigo"].ToString().Trim());

			foreach (var grupo in empleados)
			{
				DataRow primeraFila = grupo.First();

				int indice = dgv.Rows.Add();

				// Código
				dgv.Rows[indice].Cells["Codigo"].Value =primeraFila["Codigo"].ToString().Trim();

				// Empleado
				dgv.Rows[indice].Cells["Empleado"].Value =primeraFila["Empleado"].ToString().Trim();

				// RECORRER REGISTROS DEL EMPLEADO

				foreach (DataRow row in grupo)
				{
					DateTime fecha =
						Convert.ToDateTime(row["Fecha"]).Date;

					string nombreColumna =
						fecha.ToString("yyyyMMdd");

					string cuadrilla =
						row["Cuadrilla"] == DBNull.Value
							? ""
							: row["Cuadrilla"].ToString().Trim();

					string actividad =
						row["Actividad"] == DBNull.Value
							? ""
							: row["Actividad"].ToString().Trim();

					string lote =
						row["Lote"] == DBNull.Value
							? ""
							: row["Lote"].ToString().Trim();

					// ARMAR TEXTO

					string texto = "";

					if (!string.IsNullOrWhiteSpace(cuadrilla))
					{
						texto += $"Cuadrilla: {cuadrilla}";
					}

					if (!string.IsNullOrWhiteSpace(actividad))
					{
						if (texto != "")
							texto += "\r\n";

						texto += $"Actividad: {actividad}";
					}

					if (!string.IsNullOrWhiteSpace(lote))
					{
						if (texto != "")
							texto += "\r\n";

						texto += $"Lote: {lote}";
					}

					// COLOCAR VALOR EN EL DÍA

					if (dgv.Columns.Contains(nombreColumna))
					{
						dgv.Rows[indice]
							.Cells[nombreColumna]
							.Value = texto;
					}
				}
			}

			// CONFIGURACIÓN GENERAL

			dgv.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.Fill;

			// ENCABEZADOS OSCUROS
			// MISMO COLOR QUE dgvChecador

			dgv.EnableHeadersVisualStyles = false;

			dgv.ColumnHeadersDefaultCellStyle.BackColor =
				Color.FromArgb(22, 32, 45);

			dgv.ColumnHeadersDefaultCellStyle.ForeColor =
				Color.White;

			dgv.ColumnHeadersDefaultCellStyle.Font =
				new Font("Segoe UI", 9F, FontStyle.Bold);

			dgv.ColumnHeadersDefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor =
				Color.FromArgb(22, 32, 45);

			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor =
				Color.White;

			dgv.ColumnHeadersHeight = 35;

			// FORZAR EL COLOR OSCURO EN TODOS LOS ENCABEZADOS
			foreach (DataGridViewColumn columna in dgv.Columns)
			{
				columna.HeaderCell.Style.BackColor =
					Color.FromArgb(22, 32, 45);

				columna.HeaderCell.Style.ForeColor =
					Color.White;

				columna.HeaderCell.Style.Font =
					new Font("Segoe UI", 9F, FontStyle.Bold);

				columna.HeaderCell.Style.Alignment =
					DataGridViewContentAlignment.MiddleCenter;
			}

			// CELDAS

			dgv.DefaultCellStyle.Font =
				new Font("Segoe UI", 9F);

			dgv.DefaultCellStyle.BackColor =
				Color.FromArgb(248, 249, 251);

			dgv.DefaultCellStyle.ForeColor =
				Color.FromArgb(40, 40, 40);

			dgv.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.DefaultCellStyle.SelectionBackColor =
				Color.FromArgb(190, 205, 222);

			dgv.DefaultCellStyle.SelectionForeColor =
				Color.Black;

			// FILAS ALTERNADAS

			dgv.AlternatingRowsDefaultCellStyle.BackColor =
				Color.FromArgb(238, 241, 245);

			// BORDES

			dgv.CellBorderStyle =
				DataGridViewCellBorderStyle.Single;

			dgv.GridColor =
				Color.LightGray;

			// ALTURA DE FILAS

			dgv.AutoSizeRowsMode =
				DataGridViewAutoSizeRowsMode.AllCells;

			dgv.RowTemplate.Height = 28;

			// COLUMNA CÓDIGO

			dgv.Columns["Codigo"].FillWeight = 45;

			dgv.Columns["Codigo"]
				.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			// IMPORTANTE:
			// El encabezado de Código también será oscuro
			dgv.Columns["Codigo"]
				.HeaderCell
				.Style
				.BackColor =
				Color.FromArgb(22, 32, 45);

			dgv.Columns["Codigo"]
				.HeaderCell
				.Style
				.ForeColor =
				Color.White;

			// COLUMNA EMPLEADO

			dgv.Columns["Empleado"].FillWeight = 120;

			dgv.Columns["Empleado"]
				.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleLeft;

			dgv.Columns["Empleado"]
				.DefaultCellStyle.Font =
				new Font(
					"Segoe UI",
					9F,
					FontStyle.Bold);

			// COLUMNAS DE LOS DÍAS

			foreach (DataGridViewColumn columna in dgv.Columns)
			{
				if (columna.Name == "Codigo" ||
					columna.Name == "Empleado")
					continue;

				columna.FillWeight = 75;

				columna.DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleCenter;

				columna.DefaultCellStyle.WrapMode =
					DataGridViewTriState.True;
			}

			// FINAL

			dgv.ClearSelection();
			dgv.CurrentCell = null;
		}
		public void CargarDiasSemana()
		{
			_frmA.cboDia.Items.Clear();

			if (_frmA.cboSemana.SelectedIndex == -1)
				return;

			DataRow semana = ObtenerSemanaSeleccionada();

			if (semana == null)
				return;

			DateTime fechaInicio =
				Convert.ToDateTime(semana["d_startDate_per"]).Date;

			string[] dias =
			{
				"Vie",
				"Sab",
				"Dom",
				"Lun",
				"Mar",
				"Mie",
				"Jue"
			};

			for (int i = 0; i < 7; i++)
			{
				DateTime fecha = fechaInicio.AddDays(i);

				_frmA.cboDia.Items.Add(
					$"{dias[i]} {fecha:dd}"
				);
			}

			if (_frmA.cboDia.Items.Count > 0)
				_frmA.cboDia.SelectedIndex = 0;
		}
		public DataTable ObtenerActividadLoteDiaAnterior(string idCuadrilla,DateTime fechaAnterior)
		{
			DataTable dt = new DataTable();

			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"sp_GetActividadLoteDiaAnterior",
					sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@id_workGroup", SqlDbType.Char, 4)
						.Value = idCuadrilla;

					cmd.Parameters.Add("@fechaAnterior", SqlDbType.Date)
						.Value = fechaAnterior.Date;

					using (SqlDataAdapter da = new SqlDataAdapter(cmd))
					{
						da.Fill(dt);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al consultar la actividad y lote :\n"
					+ ex.Message,
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
		public bool GuardarActividadLoteDia(string idEmployee,string cSequencePer,DateTime fechaInicio,DateTime fechaFin,DateTime fecha,string idActivity,string idLot,string usuario)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"sp_UpdateActividadLoteDia",
					sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@id_employee", SqlDbType.Char, 6)
						.Value = idEmployee;

					cmd.Parameters.Add("@c_sequence_per", SqlDbType.Char, 2)
						.Value = cSequencePer;

					cmd.Parameters.Add("@d_startDate_per", SqlDbType.Date)
						.Value = fechaInicio.Date;

					cmd.Parameters.Add("@d_endDate_per", SqlDbType.Date)
						.Value = fechaFin.Date;

					cmd.Parameters.Add("@fecha", SqlDbType.Date)
						.Value = fecha.Date;

					cmd.Parameters.Add("@id_activity", SqlDbType.Char, 4)
						.Value = string.IsNullOrWhiteSpace(idActivity)
							? ""
							: idActivity;

					cmd.Parameters.Add("@id_lot", SqlDbType.Char, 4)
						.Value = string.IsNullOrWhiteSpace(idLot)
							? ""
							: idLot;

					cmd.Parameters.Add("@user", SqlDbType.VarChar, 100)
						.Value = usuario ?? "";

					cmd.ExecuteNonQuery();
				}

				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al guardar actividad y lote:\n"
					+ ex.Message,
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
		public void JalarActividadLotePorDia()
		{
			string idCuadrilla =
				_frmA.cboCuadrilla.SelectedValue.ToString().Trim();

			DataRow semana = ObtenerSemanaSeleccionada();

			if (semana == null)
				return;

			string secuencia =
				semana["c_sequence_per"].ToString().Trim();

			DateTime fechaInicio =
				Convert.ToDateTime(semana["d_startDate_per"]).Date;

			DateTime fechaFin =
				Convert.ToDateTime(semana["d_endDate_per"]).Date;

			// Día seleccionado
			int indiceDia = _frmA.cboDia.SelectedIndex;

			DateTime fechaSeleccionada =
				fechaInicio.AddDays(indiceDia);

			// Día anterior
			DateTime fechaAnterior =
				fechaSeleccionada.AddDays(-1);

			// Si selecciona viernes, no hay día anterior dentro de la semana
			if (indiceDia == 0)
			{
				MessageBox.Show(
					"El viernes no tiene un día anterior dentro de esta semana.",
					"Información",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				return;
			}

			// Obtener actividad y lote del día anterior
			DataTable dt =
				ObtenerActividadLoteDiaAnterior(
					idCuadrilla,
					fechaAnterior);

			if (dt.Rows.Count == 0)
			{
				MessageBox.Show(
					"No se encontró actividad y lote del día anterior.",
					"Información",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				return;
			}

			bool todoGuardado = true;

			foreach (DataRow row in dt.Rows)
			{
				string idEmployee =
					row["id_employee"].ToString().Trim();

				string idActivity =
					row["id_activity"].ToString().Trim();

				string idLot =
					row["id_lot"].ToString().Trim();

				// Guardar solamente si existe actividad o lote
				if (string.IsNullOrWhiteSpace(idActivity) &&
					string.IsNullOrWhiteSpace(idLot))
				{
					continue;
				}

				bool guardado =
					GuardarActividadLoteDia(
						idEmployee,
						secuencia,
						fechaInicio,
						fechaFin,
						fechaSeleccionada,
						idActivity,
						idLot,
						User.GetUserName());

				if (!guardado)
				{
					todoGuardado = false;
					break;
				}
			}

			// SOLO después de guardar correctamente
			if (todoGuardado)
			{
				CargarCAL();

				MessageBox.Show(
					"Actividad y lote cargados correctamente.",
					"Información",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
		}
	}
}
public class DiaSemana
{
	public string Nombre { get; set; }
	public DateTime Fecha { get; set; }
}