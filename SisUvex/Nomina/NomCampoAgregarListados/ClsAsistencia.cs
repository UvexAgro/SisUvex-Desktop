using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Drawing.Printing;
using System.Linq;
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
		private HashSet<string> celdasBloqueadas = new HashSet<string>();
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
		ORDER BY d_startDate_per ASC";

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
					// Semana revisión manual
					_frmA.cboSemana.SelectedValue =
						row["c_sequence_per"];

					return;
				}
			}

			_frmA.cboSemana.SelectedIndex = -1;
		}

		public DataTable CargarEmpleadosCuadrillaSemana(string idCuadrilla, DateTime fechaInicio, DateTime fechaFin)
		{
			DataTable dt = new DataTable();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"sp_GetEmpleadosCuadrillaSemana",
					sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@id_workGroup", SqlDbType.Char, 3).Value =
						idCuadrilla;

					cmd.Parameters.Add("@fechaInicio", SqlDbType.Date).Value =
						fechaInicio.Date;

					cmd.Parameters.Add("@fechaFin", SqlDbType.Date).Value =
						fechaFin.Date;

					using (SqlDataAdapter da = new SqlDataAdapter(cmd))
					{
						da.Fill(dt);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al cargar los empleados de la cuadrilla:\n" + ex.Message,
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
				_frmA.cboCuadrilla.SelectedValue.ToString();

			DataRow semana = ObtenerSemanaSeleccionada();

			if (semana == null)
				return;

			DateTime fechaInicio =
				Convert.ToDateTime(semana["d_startDate_per"]);

			DateTime fechaFin =
				Convert.ToDateTime(semana["d_endDate_per"]);

			DataTable dt =
				CargarEmpleadosCuadrillaSemana(
					idCuadrilla,
					fechaInicio,
					fechaFin);

			_frmA.dgvAsistencia.DataSource = dt;

			// Cargar registros reales de Nom_WorkGroupEmployeeDaily
			DataTable dtRegistros =
				CargarRegistrosSemana(
					idCuadrilla,
					fechaInicio,
					fechaFin);

			// Bloquear/desbloquear días según exista registro
			BloquearDiasSinRegistro(
				dtRegistros,
				fechaInicio);

			MarcarEmpleadosEnOtraCuadrilla(dt);

			_frmA.dgvAsistencia.Visible = true;
			_frmA.dgvAsistencia.BringToFront();

			_frmA.dgvAsistencia.ClearSelection();
			_frmA.dgvAsistencia.CurrentCell = null;

		}
		public void ConfigurarGrid()
		{
			_frmA.dgvAsistencia.Columns.Clear();

			DataGridView dgv = _frmA.dgvAsistencia;

			// =========================
			// CONFIGURACIÓN GENERAL
			// =========================

			dgv.ReadOnly = false;

			dgv.EditMode =
				DataGridViewEditMode.EditOnEnter;

			dgv.AutoGenerateColumns = false;

			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToResizeRows = false;

			dgv.RowHeadersVisible = false;

			// SELECCIONAR FILA COMPLETA
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


			// =========================
			// TAMAÑO
			// =========================

			dgv.ColumnHeadersHeight = 42;
			dgv.RowTemplate.Height = 28;


			// =========================
			// ENCABEZADO
			// =========================

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


			// =========================
			// FILAS
			// =========================

			dgv.DefaultCellStyle.Font =
				new Font("Segoe UI", 9);

			dgv.DefaultCellStyle.BackColor =
				Color.FromArgb(248, 249, 251);

			dgv.DefaultCellStyle.ForeColor =
				Color.FromArgb(40, 40, 40);

			// COLOR DE SELECCIÓN
			dgv.DefaultCellStyle.SelectionBackColor =
				Color.FromArgb(190, 205, 222);

			dgv.DefaultCellStyle.SelectionForeColor =
				Color.Black;

			// FILAS ALTERNADAS
			dgv.AlternatingRowsDefaultCellStyle.BackColor =
				Color.FromArgb(238, 241, 245);


			// =========================
			// COLUMNAS
			// =========================

			dgv.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.Fill;


			// =========================
			// CÓDIGO
			// =========================

			DataGridViewTextBoxColumn colCodigo =
				new DataGridViewTextBoxColumn();

			colCodigo.Name = "Codigo";
			colCodigo.HeaderText = "CÓDIGO";
			colCodigo.DataPropertyName = "Codigo";

			colCodigo.FillWeight = 1.2f;

			colCodigo.ReadOnly = true;

			colCodigo.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			// FORZAR ENCABEZADO OSCURO
			colCodigo.HeaderCell.Style.BackColor =
				Color.FromArgb(22, 32, 45);

			colCodigo.HeaderCell.Style.ForeColor =
				Color.White;

			colCodigo.HeaderCell.Style.Font =
				new Font("Segoe UI", 9, FontStyle.Bold);

			colCodigo.HeaderCell.Style.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			_frmA.dgvAsistencia.Columns.Add(colCodigo);


			// =========================
			// EMPLEADO
			// =========================

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

			// ENCABEZADO
			colEmpleado.HeaderCell.Style.BackColor =
				Color.FromArgb(22, 32, 45);

			colEmpleado.HeaderCell.Style.ForeColor =
				Color.White;

			colEmpleado.HeaderCell.Style.Font =
				new Font("Segoe UI", 9, FontStyle.Bold);

			_frmA.dgvAsistencia.Columns.Add(colEmpleado);


			// =========================
			// DÍAS
			// =========================

			AgregarColumnaDia("Vie", "VIE");
			AgregarColumnaDia("Sab", "SÁB");
			AgregarColumnaDia("Dom", "DOM");
			AgregarColumnaDia("Lun", "LUN");
			AgregarColumnaDia("Mar", "MAR");
			AgregarColumnaDia("Mie", "MIÉ");
			AgregarColumnaDia("Jue", "JUE");


			// =========================
			// QUITAR SELECCIÓN INICIAL
			// =========================

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
		private void MarcarEmpleadosEnOtraCuadrilla(DataTable dt)
		{
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

			foreach (DataGridViewRow row in _frmA.dgvAsistencia.Rows)
			{
				if (row.IsNewRow)
					continue;

				int indice = row.Index;

				if (indice >= dt.Rows.Count)
					continue;

				DataRow datos = dt.Rows[indice];

				foreach (string dia in dias)
				{
					string columnaOtra = dia + "OtraCuadrilla";

					if (!dt.Columns.Contains(columnaOtra))
						continue;

					object valor = datos[columnaOtra];

					if (valor != null &&
					valor != DBNull.Value &&
					!string.IsNullOrWhiteSpace(valor.ToString()))
					{
						if (!_frmA.dgvAsistencia.Columns.Contains(dia))
							continue;

						DataGridViewCell celda = row.Cells[dia];

						// Bloquear
						celda.ReadOnly = true;

						// Apariencia
						celda.Style.BackColor = Color.FromArgb(255, 152, 0);
						celda.Style.ForeColor = Color.DarkOrange;
						celda.Style.SelectionBackColor = Color.FromArgb(255, 152, 0);
						celda.Style.SelectionForeColor = Color.DarkOrange;

						// Mensaje al pasar el mouse
						celda.ToolTipText =
							"⚠ Este empleado está asignado a la cuadrilla: "
							+ valor.ToString();
					}
				}
			}
		}

		public void DgvAsistencia_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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

			// Solo actuar si es una columna de día
			if (!dias.Contains(nombreColumna))
				return;

			// Verificar si hay algún empleado disponible sin marcar
			bool marcarTodos = false;

			foreach (DataGridViewRow row in dgv.Rows)
			{
				if (row.IsNewRow)
					continue;

				DataGridViewCell celda =
					row.Cells[nombreColumna];

				// Si está bloqueado, ignorarlo
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

			// Marcar o desmarcar todos
			foreach (DataGridViewRow row in dgv.Rows)
			{
				if (row.IsNewRow)
					continue;

				DataGridViewCell celda =
					row.Cells[nombreColumna];

				// No tocar empleados bloqueados
				if (celda.ReadOnly)
					continue;

				celda.Value = marcarTodos;
			}

			dgv.EndEdit();
		}
		public MemoryStream GenerarPdfAsistenciaCuadrilla(DataGridView dgv)
		{
			MemoryStream ms = new MemoryStream();

			// =========================================
			// CREAR PDF
			// =========================================

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

			// =========================================
			// COLORES
			// =========================================

			iText.Kernel.Colors.DeviceRgb colorHeader =
				new iText.Kernel.Colors.DeviceRgb(25, 35, 48);

			iText.Kernel.Colors.DeviceRgb colorBorde =
				new iText.Kernel.Colors.DeviceRgb(90, 90, 90);

			iText.Kernel.Colors.DeviceRgb colorAzul =
				new iText.Kernel.Colors.DeviceRgb(0, 102, 204);

			// =========================================
			// TÍTULO
			// =========================================

			iText.Layout.Element.Paragraph titulo =
				new iText.Layout.Element.Paragraph(
					"ASISTENCIA PARA REVISIÓN");

			titulo
			.SetFontSize(16)
			.SetTextAlignment(
				iText.Layout.Properties.TextAlignment.CENTER);

			document.Add(titulo);

			// =========================================
			// INFORMACIÓN
			// =========================================

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

			// =========================================
			// TABLA
			// =========================================

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

			// =========================================
			// ENCABEZADOS
			// =========================================

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

			// =========================================
			// FILAS
			// =========================================

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

					// =====================================
					// CÓDIGO Y EMPLEADO
					// =====================================

					if (i < 2)
					{
						string texto =
							valor == null ||
							valor == DBNull.Value
								? ""
								: valor.ToString();

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
						// =====================================
						// CHECKBOX
						// =====================================

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

						// =================================
						// SIN NARANJA
						// =================================

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

			// =========================================
			// CERRAR
			// =========================================

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

		public void GuardarAsistenciaManual(
	DateTime fecha,
	string idEmployee,
	string idWorkGroup,
	bool asistencia,
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

					cmd.Parameters.Add("@fecha", SqlDbType.Date).Value =
						fecha.Date;

					cmd.Parameters.Add("@id_employee", SqlDbType.Char, 6).Value =
						idEmployee;

					cmd.Parameters.Add("@id_workGroup", SqlDbType.Char, 4).Value =
						idWorkGroup;

					cmd.Parameters.Add("@b_attendance", SqlDbType.Bit).Value =
						asistencia;

					cmd.Parameters.Add("@userUpdate", SqlDbType.VarChar, 100).Value =
						usuario;

					cmd.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al guardar la asistencia:\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public void GuardarAsistencia()
		{
			if (_frmA.cboCuadrilla.SelectedIndex == -1)
				return;

			if (_frmA.cboSemana.SelectedIndex == -1)
				return;

			string idWorkGroup =
				_frmA.cboCuadrilla.SelectedValue.ToString();

			DataRow semana = ObtenerSemanaSeleccionada();

			if (semana == null)
				return;

			DateTime fechaInicio =
				Convert.ToDateTime(
					semana["d_startDate_per"]).Date;

			string usuario = User.GetUserName();

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

			for (int i = 0; i < _frmA.dgvAsistencia.Rows.Count; i++)
			{
				DataGridViewRow fila =
					_frmA.dgvAsistencia.Rows[i];

				if (fila.IsNewRow)
					continue;

				string idEmployee =
					fila.Cells["Codigo"].Value?.ToString();

				if (string.IsNullOrWhiteSpace(idEmployee))
					continue;

				for (int d = 0; d < dias.Length; d++)
				{
					bool asistencia = false;

					object valor =
						fila.Cells[dias[d]].Value;

					if (valor != null &&
						valor != DBNull.Value)
					{
						asistencia = Convert.ToBoolean(valor);
					}

					DateTime fecha =
						fechaInicio.AddDays(d);

					GuardarAsistenciaManual(
						fecha,
						idEmployee,
						idWorkGroup,
						asistencia,
						usuario);
				}
			}

			MessageBox.Show(
				"La asistencia se guardó correctamente.",
				"Asistencia",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information);
		}
		private DataTable CargarRegistrosSemana(
	string idCuadrilla,
	DateTime fechaInicio,
	DateTime fechaFin)
		{
			DataTable dt = new DataTable();

			string query = @"
        SELECT
            d_date,
            id_employee
        FROM dbo.Nom_WorkGroupEmployeeDaily
        WHERE id_workGroup = @id_workGroup
          AND d_date BETWEEN @fechaInicio AND @fechaFin;";

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				{
					cmd.Parameters.Add("@id_workGroup", SqlDbType.Char, 4).Value =
						idCuadrilla;

					cmd.Parameters.Add("@fechaInicio", SqlDbType.Date).Value =
						fechaInicio.Date;

					cmd.Parameters.Add("@fechaFin", SqlDbType.Date).Value =
						fechaFin.Date;

					using (SqlDataAdapter da = new SqlDataAdapter(cmd))
					{
						da.Fill(dt);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al cargar los registros de la semana:\n" + ex.Message,
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
		private void BloquearDiasSinRegistro(
	DataTable dtRegistros,
	DateTime fechaInicio)
		{
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

			foreach (DataGridViewRow fila in _frmA.dgvAsistencia.Rows)
			{
				if (fila.IsNewRow)
					continue;

				string idEmpleado =
					fila.Cells["Codigo"].Value?.ToString()?.Trim();

				if (string.IsNullOrEmpty(idEmpleado))
					continue;

				for (int i = 0; i < dias.Length; i++)
				{
					DateTime fecha =
						fechaInicio.Date.AddDays(i);

					bool existeRegistro =
						dtRegistros.AsEnumerable().Any(r =>
							r["id_employee"].ToString().Trim() == idEmpleado &&
							Convert.ToDateTime(r["d_date"]).Date == fecha.Date
						);

					DataGridViewCheckBoxCell checkbox =
						fila.Cells[dias[i]]
						as DataGridViewCheckBoxCell;

					if (checkbox == null)
						continue;

					if (existeRegistro)
					{
						// EXISTE REGISTRO
						// → CHECKBOX DISPONIBLE
						checkbox.ReadOnly = false;
					}
					else
					{
						// NO EXISTE REGISTRO
						// → CHECKBOX BLOQUEADO
						checkbox.ReadOnly = true;
						checkbox.Value = false;
					}
				}
			}
		}
		public void DgvAsistencia_CellPainting(
	object sender,
	DataGridViewCellPaintingEventArgs e)
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
	}
}
		
		