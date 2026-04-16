using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using ClosedXML.Excel;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using PdfiumViewer;
using SisUvex.Catalogos.WorkGroup;
using static SisUvex.Catalogos.Metods.ClsObject;
using DrawingColor = System.Drawing.Color;
using ITextPdf = iText.Kernel.Pdf.PdfDocument;
using PdfDocument = iText.Kernel.Pdf.PdfDocument;
using PdfiumDoc = PdfiumViewer.PdfDocument;


namespace SisUvex.Nomina.Reporte_de_Asistencia
{
	internal class ClsDgvAsistncia
	{
		FrmAsistenciaR frmR;
		private PrintDocument printDocument1 = new PrintDocument();
		private Bitmap bmp;
		private DataGridView dgv;
		private int currentRow;
		private int[] columnLefts;
		private int[] columnWidths;
		private bool firstPage;
		private bool newPage;
		private List<List<DataGridViewRow>> gruposEmpleados;
		private int grupoActual;
		int filaActual = 0;
		private PdfViewer? pdfViewer;
		private MemoryStream? pdfMemoryStream;
		private DataTable dtAsistenciaGlobal;

		public ClsDgvAsistncia(FrmAsistenciaR frm)
		{
			frmR = frm;
		}
		public DataTable ObtenerAsistencia(
			DateTime fechaInicial,
			DateTime fechaFinal,
			string idWorkGroup)
		{
			DataTable dt = new DataTable();
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();


				SqlCommand cmdSP = new SqlCommand("sp_PackingAttendenceChecker", sql.cnn);
				cmdSP.CommandType = CommandType.StoredProcedure;

				cmdSP.Parameters.AddWithValue("@FechaInicio", fechaInicial);
				cmdSP.Parameters.AddWithValue("@FechaFin", fechaFinal);
				cmdSP.Parameters.AddWithValue("@idWorkGroup", idWorkGroup);

				cmdSP.ExecuteNonQuery();


				string query = @"
					SELECT 
					a.id_AttendanceChecker, 
					a.id_employee AS Codigo,
					e.v_lastNamePat + ' ' + e.v_lastNameMat + ' ' + e.v_name AS NombreCompleto,
					a.d_Date AS Fecha,
					a.t_CheckInTime AS HoraEntrada,
					a.t_CheckOutTime AS HoraSalida
				FROM dbo.PackingAttendanceChecker a
				INNER JOIN dbo.Nom_Employees e ON e.id_employee = a.id_employee
				WHERE a.d_Date BETWEEN @inicio AND @fin
				  AND e.id_workGroup = @grupo
				ORDER BY a.d_Date, NombreCompleto " ;

				SqlCommand cmd = new SqlCommand(query, sql.cnn);
				cmd.Parameters.AddWithValue("@inicio", fechaInicial);
				cmd.Parameters.AddWithValue("@fin", fechaFinal);
				cmd.Parameters.AddWithValue("@grupo", idWorkGroup);

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(dt);

				sql.CloseConectionWrite();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			return dt;
		}
		public void CargarDgvAsistencia()
		{
			DateTime fechaInicial = ObtenerFechaDesdeSemana(frmR.cboSemanaInicial.Text, true);
			DateTime fechaFinal = ObtenerFechaDesdeSemana(frmR.cboSemanaFinal.Text, false);
			string idWorkGroup = frmR.cboCuadrilla.SelectedValue.ToString();

			frmR.dgvAsistencia.DataSource = ObtenerAsistencia(
				fechaInicial,
				fechaFinal,
				idWorkGroup);

			if (frmR.dgvAsistencia.Columns.Contains("id_AttendanceChecker"))
			{
				frmR.dgvAsistencia.Columns["id_AttendanceChecker"].Visible = false;
			}

			AjustarColumnas(frmR.dgvAsistencia);
			frmR.dgvAsistencia.ClearSelection();
		}
		public void AjustarColumnas(DataGridView dgv)
		{
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgv.ScrollBars = ScrollBars.Vertical;

			dgv.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

			if (dgv.Columns.Contains("Codigo"))
				dgv.Columns["Codigo"].FillWeight = 15;

			if (dgv.Columns.Contains("NombreCompleto"))
				dgv.Columns["NombreCompleto"].FillWeight = 40;

			if (dgv.Columns.Contains("Fecha"))
				dgv.Columns["Fecha"].FillWeight = 15;

			if (dgv.Columns.Contains("HoraEntrada"))
				dgv.Columns["HoraEntrada"].FillWeight = 15;

			if (dgv.Columns.Contains("HoraSalida"))
				dgv.Columns["HoraSalida"].FillWeight = 15;
		}

		private DateTime ObtenerFechaDesdeSemana(string textoSemana, bool fechaInicio)
		{
			string[] partes = textoSemana.Split('-');
			string[] rango = partes[1].Trim().Split('a');

			if (fechaInicio)
				return Convert.ToDateTime(rango[0].Trim());
			else
				return Convert.ToDateTime(rango[1].Trim());
		}
		public MemoryStream GenerarPdfAsistenciaPorEmpleado(DataTable datos)
		{
			MemoryStream ms = new MemoryStream();

			PdfWriter writer = new PdfWriter(ms);
			writer.SetCloseStream(false);

			PdfDocument pdf = new PdfDocument(writer);
			Document document = new Document(pdf);

			document.SetMargins(40, 40, 50, 40); //  mejor margen

			var empleados = datos.AsEnumerable()
				.GroupBy(x => new
				{
					Codigo = x["Codigo"],
					Nombre = x["NombreCompleto"]
				});

			bool primeraHoja = true;

			foreach (var emp in empleados)
			{
				if (!primeraHoja)
					document.Add(new AreaBreak());

				primeraHoja = false;

				//  TÍTULO
				Paragraph titulo = new Paragraph("REPORTE DE ASISTENCIA")
					.SetFontSize(16)
					.SetTextAlignment(TextAlignment.CENTER);

				document.Add(titulo);
				document.Add(new Paragraph(" "));

				//  TABLA
				float[] columnas = { 1, 3, 2, 2, 2 };
				Table tabla = new Table(UnitValue.CreatePercentArray(columnas))
					.UseAllAvailableWidth();

				tabla.SetKeepTogether(false);

				//  ENCABEZADOS
				tabla.AddHeaderCell(CrearHeader("Codigo"));
				tabla.AddHeaderCell(CrearHeader("Nombre Completo"));
				tabla.AddHeaderCell(CrearHeader("Fecha"));
				tabla.AddHeaderCell(CrearHeader("Hora Entrada"));
				tabla.AddHeaderCell(CrearHeader("Hora Salida"));

				//  DATOS
				foreach (var fila in emp)
				{
					if (fila["Fecha"] == DBNull.Value)
						continue;

					tabla.AddCell(CrearCelda(fila["Codigo"].ToString()));
					tabla.AddCell(CrearCelda(fila["NombreCompleto"].ToString()));

					string fechaTexto = "";
					if (fila["Fecha"] != DBNull.Value)
					{
						DateTime fecha = Convert.ToDateTime(fila["Fecha"]);
						fechaTexto = fecha.ToString("dd/MM/yyyy");
					}

					tabla.AddCell(CrearCelda(fechaTexto));
					tabla.AddCell(CrearCelda(fila["HoraEntrada"].ToString()));
					tabla.AddCell(CrearCelda(fila["HoraSalida"].ToString()));
				}

				document.Add(tabla);
			}

			document.Close();
			ms.Position = 0;

			return ms;
		}

		public void ShowPdfViewer(MemoryStream ms)
		{
			Form visor = new Form();
			visor.Text = "SisUvex-[Vista de Asistencia]";
			visor.WindowState = FormWindowState.Maximized;

			PdfViewer pdfViewer = new PdfViewer
			{
				Dock = DockStyle.Fill,
				//ShowToolbar = true
			};

			visor.Controls.Add(pdfViewer);

			ms.Position = 0;
			pdfViewer.Document = PdfiumViewer.PdfDocument.Load(ms);

			visor.TopMost = true;
			visor.Show();
			visor.TopMost = false;
		}
		private Cell CrearHeader(string texto)
		{
			var fontBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

			return new Cell()
				.Add(new Paragraph(texto).SetFont(fontBold))
				.SetBackgroundColor(ColorConstants.LIGHT_GRAY)
				.SetTextAlignment(TextAlignment.CENTER)
				.SetBorder(new SolidBorder(1));
		}
		private Cell CrearCelda(string texto)
		{
			return new Cell()
				.Add(new Paragraph(texto)
					.SetTextAlignment(TextAlignment.CENTER)
					.SetFontSize(9)
					.SetKeepTogether(true))
				.SetBorder(new SolidBorder(1));
		}


		public void EstiloDGVAsistencia(DataGridView dgv)
		{
			// Quitar bordes
			dgv.BorderStyle = BorderStyle.None;
			dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
			dgv.RowHeadersVisible = false;

			// Colores generales
			dgv.BackgroundColor = DrawingColor.White;
			dgv.GridColor = DrawingColor.FromArgb(230, 230, 230);

			// Encabezados
			dgv.EnableHeadersVisualStyles = false;
			
			dgv.ColumnHeadersDefaultCellStyle.BackColor = DrawingColor.FromArgb(220, 230, 241);
			dgv.ColumnHeadersDefaultCellStyle.ForeColor = DrawingColor.Black;
			dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
			dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dgv.ColumnHeadersHeight = 35;

			// Filas
			dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
			dgv.DefaultCellStyle.BackColor = DrawingColor.White;
			dgv.DefaultCellStyle.ForeColor = DrawingColor.Black;

			//  IMPORTANTE: mantener sin selección visual
			// Selección visible (bonita)
			dgv.DefaultCellStyle.SelectionBackColor = DrawingColor.FromArgb(180, 200, 230);
			dgv.DefaultCellStyle.SelectionForeColor = DrawingColor.Black;

			dgv.RowsDefaultCellStyle.SelectionBackColor = DrawingColor.FromArgb(180, 200, 230);
			dgv.RowsDefaultCellStyle.SelectionForeColor = DrawingColor.Black;

			// Filas alternadas
			dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = DrawingColor.FromArgb(180, 200, 230);
			dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = DrawingColor.Black;
			// Ajuste automático
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			//  CAMBIO IMPORTANTE (evita que crezca demasiado)
			dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

			// Altura uniforme (como en tu imagen)
			dgv.RowTemplate.Height = 28;
			dgv.AllowUserToResizeRows = false;

			// Selección tipo celda (sin highlight)
			dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgv.MultiSelect = false;
			dgv.ReadOnly = true;

			// Solo lectura
			dgv.ReadOnly = true;

			//  Espaciado interno (se ve más limpio tipo sistema)
			dgv.DefaultCellStyle.Padding = new Padding(3);
			dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);

	
		}
		public DataTable ObtenerAsistenciaDesdeGrid(DateTime fechaInicial, DateTime fechaFinal)
		{
			DataTable dt = new DataTable();
			SQLControl sql = new SQLControl();

			try
			{
				if (frmR.dgvEmployee.Rows.Count == 0)
				{
					MessageBox.Show("No hay empleados en la lista");
					return null;
				}

				sql.OpenConectionWrite();

				List<string> empleados = new List<string>();


				foreach (DataGridViewRow row in frmR.dgvEmployee.Rows)
				{
					if (row.IsNewRow) continue;

					if (row.Cells["Codigo"].Value == null)
						continue;

					string idEmpleado = row.Cells["Codigo"].Value.ToString();

					empleados.Add("'" + idEmpleado + "'");

					SqlCommand cmdSP = new SqlCommand("sp_PackingAttendenceChecker", sql.cnn);
					cmdSP.CommandType = CommandType.StoredProcedure;

					cmdSP.Parameters.AddWithValue("@FechaInicio", fechaInicial);
					cmdSP.Parameters.AddWithValue("@FechaFin", fechaFinal);
					cmdSP.Parameters.AddWithValue("@idWorkGroup", DBNull.Value);
					cmdSP.Parameters.AddWithValue("@idEmployee", idEmpleado);

					cmdSP.ExecuteNonQuery();
				}

				if (empleados.Count == 0)
				{
					MessageBox.Show("No hay empleados válidos");
					return null;
				}

				string lista = string.Join(",", empleados);

				string query = $@"
				SELECT 
					a.id_employee AS Codigo,
					e.v_lastNamePat + ' ' + e.v_lastNameMat + ' ' + e.v_name AS NombreCompleto,
					a.d_Date AS Fecha,
					a.t_CheckInTime AS HoraEntrada,
					a.t_CheckOutTime AS HoraSalida
				FROM dbo.PackingAttendanceChecker a
				INNER JOIN dbo.Nom_Employees e ON e.id_employee = a.id_employee
				WHERE a.d_Date BETWEEN @inicio AND @fin
				AND a.id_employee IN ({lista})
				ORDER BY a.d_Date, NombreCompleto";

				SqlCommand cmd = new SqlCommand(query, sql.cnn);
				cmd.Parameters.AddWithValue("@inicio", fechaInicial);
				cmd.Parameters.AddWithValue("@fin", fechaFinal);

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




		public void ExportarDGVaExcel(DataGridView dgv)
		{
			if (dgv.Rows.Count == 0)
			{
				MessageBox.Show("No hay datos para exportar");
				return;
			}

			using (SaveFileDialog sfd = new SaveFileDialog())
			{
				sfd.Filter = "Excel (*.xlsx)|*.xlsx";
				sfd.FileName = "Reporte_Asistencia.xlsx";

				if (sfd.ShowDialog() == DialogResult.OK)
				{
					string ruta = sfd.FileName;

					using (XLWorkbook wb = new XLWorkbook())
					{
						var ws = wb.Worksheets.Add("Asistencia");

						int filaExcel = 1;

						//  TÍTULO GENERAL
						ws.Cell(filaExcel, 1).Value = "REPORTE DE ASISTENCIA";
						ws.Range(filaExcel, 1, filaExcel, dgv.Columns.Count).Merge();
						ws.Cell(filaExcel, 1).Style.Font.Bold = true;
						ws.Cell(filaExcel, 1).Style.Font.FontSize = 16;
						ws.Cell(filaExcel, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

						filaExcel += 2;

						//  AGRUPAR POR FECHA
						var grupos = dgv.Rows
							.Cast<DataGridViewRow>()
							.Where(r => !r.IsNewRow && r.Cells["Fecha"].Value != null)
							.GroupBy(r => Convert.ToDateTime(r.Cells["Fecha"].Value).Date)
							.OrderBy(g => g.Key);

						foreach (var grupo in grupos)
						{
							// TÍTULO POR FECHA
							ws.Cell(filaExcel, 1).Value = $"Fecha: {grupo.Key:dd/MM/yyyy}";
							ws.Cell(filaExcel, 1).Style.Font.Bold = true;
							ws.Cell(filaExcel, 1).Style.Font.FontSize = 12;

							filaExcel++;

							//  ENCABEZADOS
							for (int i = 0; i < dgv.Columns.Count; i++)
							{
								var cell = ws.Cell(filaExcel, i + 1);
								cell.Value = dgv.Columns[i].HeaderText;

								cell.Style.Font.Bold = true;
								cell.Style.Font.FontColor = XLColor.Black;
								cell.Style.Fill.BackgroundColor = XLColor.LightGray;
								cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
							}

							filaExcel++;

							//  DATOS DEL GRUPO
							foreach (var row in grupo)
							{
								for (int j = 0; j < dgv.Columns.Count; j++)
								{
									var valor = row.Cells[j].Value;
									var cell = ws.Cell(filaExcel, j + 1);

									if (dgv.Columns[j].Name == "Fecha" && valor != null)
									{
										DateTime fecha = Convert.ToDateTime(valor);
										cell.Value = fecha;
										cell.Style.DateFormat.Format = "dd/MM/yyyy";
									}
									else
									{
										cell.Value = valor?.ToString();
									}

									cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
								}

								filaExcel++;
							}

							//  ESPACIO ENTRE GRUPOS
							filaExcel += 2;
						}

						//  AJUSTAR COLUMNAS
						ws.Columns().AdjustToContents();

						wb.SaveAs(ruta);
					}

					//  PREGUNTAR SI ABRIR
					DialogResult result = MessageBox.Show(
						"Excel generado correctamente.\n¿Deseas abrirlo?",
						"Abrir archivo",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Question
					);

					if (result == DialogResult.Yes)
					{
						Process.Start(new ProcessStartInfo()
						{
							FileName = ruta,
							UseShellExecute = true
						});
					}
				}
			}
		}
		public void btnEliminar()
		{
			if (frmR.dgvAsistencia.SelectedCells.Count == 0)
			{
				MessageBox.Show("Selecciona un registro");
				return;
			}

			int fila = frmR.dgvAsistencia.SelectedCells[0].RowIndex;

			int id = Convert.ToInt32(
				frmR.dgvAsistencia.Rows[fila].Cells["id_AttendanceChecker"].Value
			);

			DialogResult r = MessageBox.Show(
				"¿Deseas eliminar este registro?",
				"Confirmar",
				MessageBoxButtons.YesNo
			);

			if (r == DialogResult.No)
				return;

			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				string query = "DELETE FROM PackingAttendanceChecker WHERE id_AttendanceChecker = @id";

				SqlCommand cmd = new SqlCommand(query, sql.cnn);
				cmd.Parameters.AddWithValue("@id", id);
				cmd.ExecuteNonQuery();

				// 🔥 Quitar fila del DGV (sin recargar todo)
				frmR.dgvAsistencia.Rows.RemoveAt(fila);

				MessageBox.Show("Registro eliminado");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}