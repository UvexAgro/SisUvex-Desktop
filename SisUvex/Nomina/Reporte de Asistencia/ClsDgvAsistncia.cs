using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing.Printing;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout.Properties;
using iText.Layout;
using iText.Layout.Element;

namespace SisUvex.Nomina.Reporte_de_Asistencia
{
	internal class ClsDgvAsistncia
	{
		ClsDgvAsistncia clsDgv;
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

		public ClsDgvAsistncia(FrmAsistenciaR frm)
		{
			frmR = frm;
		}

		public DataTable GenerarAsistenciaDesdeDgv(
	DateTime fechaInicial,
	DateTime fechaFinal,
	string idWorkGroup,
	int periodo,
	int semanaInicio,
	int semanaFin)
		{
			DataTable dtAsistencia = new DataTable();

			dtAsistencia.Columns.Add("Codigo");
			dtAsistencia.Columns.Add("NombreCompleto");
			dtAsistencia.Columns.Add("Fecha");
			dtAsistencia.Columns.Add("HoraEntrada");
			dtAsistencia.Columns.Add("HoraSalida");

			Random rnd = new Random();

			
			DataTable dtHorarios = ObtenerHorarios(fechaInicial, fechaFinal);

			Dictionary<DateTime, DataRow> dicHorarios = new Dictionary<DateTime, DataRow>();

			foreach (DataRow dr in dtHorarios.Rows)
			{
				DateTime fecha = Convert.ToDateTime(dr["Fecha"]).Date;
				dicHorarios[fecha] = dr;
			}

		
			HashSet<string> horasUsadas = new HashSet<string>();

			foreach (DataGridViewRow row in frmR.dgvEmployee.Rows)
			{
				if (row.IsNewRow) continue;
				if (row.Cells["Codigo"].Value == null) continue;

				
				string idEmpleado = row.Cells["Codigo"].Value.ToString();
				string nombre = row.Cells["Nombre"].Value.ToString();

				for (DateTime fecha = fechaInicial; fecha <= fechaFinal; fecha = fecha.AddDays(1))
				{
					if (!dicHorarios.ContainsKey(fecha.Date))
						continue;

					DataRow drHorario = dicHorarios[fecha.Date];

					DateTime entradaBase = Convert.ToDateTime(drHorario["d_dateHourBeginNormal"]);

					
					DateTime entradaMin = entradaBase.AddMinutes(-18);
					DateTime entradaMax = entradaBase.AddMinutes(13);

					DateTime entradaReal = GenerarHoraUnica(entradaMin, entradaMax, rnd, horasUsadas);

					DateTime salidaBase;

					
					if (drHorario["d_dateHourEndExtra"] != DBNull.Value)
						salidaBase = Convert.ToDateTime(drHorario["d_dateHourEndExtra"]);
					else
						salidaBase = Convert.ToDateTime(drHorario["d_dateHourEndNormal"]);

					DateTime salidaMin = salidaBase.AddMinutes(-18);
					DateTime salidaMax = salidaBase.AddMinutes(13);

					DateTime salidaReal = GenerarHoraUnica(salidaMin, salidaMax, rnd, horasUsadas);

					dtAsistencia.Rows.Add(
						idEmpleado,
						nombre,
						fecha.ToString("dd/MM/yyyy"),
						entradaReal.ToString("HH:mm:ss"),
						salidaReal.ToString("HH:mm:ss")
					);
				}
			}

			return dtAsistencia;
		}
		private DataTable ObtenerHorarios(DateTime fechaInicial, DateTime fechaFinal)
		{
			DataTable dt = new DataTable();
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				string query = @"
				SELECT 
					CAST(d_workTime AS DATE) AS Fecha,
					d_dateHourBeginNormal,
					d_dateHourEndNormal,
					d_dateHourBeginExtra,
					d_dateHourEndExtra
				FROM dbo.WorkTimeConfig
				WHERE d_workTime BETWEEN @inicio AND @fin
				";

				SqlCommand cmd = new SqlCommand(query, sql.cnn);

				cmd.Parameters.AddWithValue("@inicio", fechaInicial);
				cmd.Parameters.AddWithValue("@fin", fechaFinal);

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
		private DateTime GenerarHoraUnica(DateTime min, DateTime max, Random rnd, HashSet<string> usadas)
		{
			DateTime hora;
			string clave;

			do
			{
				int segundos = rnd.Next(0, (int)(max - min).TotalSeconds + 1);
				hora = min.AddSeconds(segundos);
				clave = hora.ToString("HH:mm:ss");

			} while (usadas.Contains(clave));

			usadas.Add(clave);

			return hora;
		}
		public void CargarDgvAsistencia()
		{
			DateTime fechaInicial = ObtenerFechaDesdeSemana(frmR.cboSemanaInicial.Text, true);
			DateTime fechaFinal = ObtenerFechaDesdeSemana(frmR.cboSemanaFinal.Text, false);
			string idWorkGroup = frmR.cboCuadrilla.SelectedValue.ToString();

			string[] valoresSemanaInicio = frmR.cboSemanaInicial.SelectedValue.ToString().Split('|');
			string[] valoresSemanaFin = frmR.cboSemanaFinal.SelectedValue.ToString().Split('|');

			int periodo = Convert.ToInt32(valoresSemanaInicio[0]);
			int semanaInicio = Convert.ToInt32(valoresSemanaInicio[1]);
			int semanaFin = Convert.ToInt32(valoresSemanaFin[1]);

			frmR.dgvAsistencia.DataSource = GenerarAsistenciaDesdeDgv(
				fechaInicial,
				fechaFinal,
				idWorkGroup,
				periodo,
				semanaInicio,
				semanaFin);

			EstiloDGV(frmR.dgvAsistencia);
			frmR.dgvAsistencia.ClearSelection();
		}

		private void EstiloDGV(DataGridView dgv)
		{
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgv.MultiSelect = false;
			dgv.ReadOnly = true;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
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

		public void ExportarDgv(DataGridView dgv)
		{
			string ruta = Path.Combine(Path.GetTempPath(), "Reporte_Asistencia.pdf");

			PdfWriter writer = new PdfWriter(ruta);
			PdfDocument pdf = new PdfDocument(writer);
			Document doc = new Document(pdf);

			var font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
			var bold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

			//  AGRUPAR POR EMPLEADO
			var grupos = dgv.Rows
				.Cast<DataGridViewRow>()
				.Where(r => !r.IsNewRow)
				.GroupBy(r => r.Cells["Codigo"].Value?.ToString());

			foreach (var grupo in grupos)
			{
				//  TÍTULO
				doc.Add(new Paragraph("REPORTE DE ASISTENCIA")
					.SetFont(bold)
					.SetFontSize(16));

				doc.Add(new Paragraph(" "));

				//  TABLA IGUAL AL DGV
				int totalCols = dgv.Columns.Count;
				Table table = new Table(totalCols);
				table.SetWidth(UnitValue.CreatePercentValue(100));

				//  ENCABEZADOS
				foreach (DataGridViewColumn col in dgv.Columns)
				{
					string header = SepararEncabezado(col.HeaderText);

					table.AddHeaderCell(
						new Cell()
							.SetBackgroundColor(iText.Kernel.Colors.ColorConstants.LIGHT_GRAY)
							.Add(new Paragraph(header)
								.SetFont(bold)
								.SetTextAlignment(TextAlignment.CENTER))
					);
				}

				//  FILAS SOLO DEL EMPLEADO
				foreach (var row in grupo)
				{
					foreach (DataGridViewCell cell in row.Cells)
					{
						string texto = cell.Value?.ToString() ?? "";

						table.AddCell(
							new Cell()
								.Add(new Paragraph(texto)
									.SetFont(font)
									.SetTextAlignment(TextAlignment.CENTER))
						);
					}
				}

				doc.Add(table);

				//  SALTO DE PÁGINA
				doc.Add(new AreaBreak());
			}

			doc.Close();

			//  ABRIR AUTOMÁTICAMENTE
			Process.Start(new ProcessStartInfo()
			{
				FileName = ruta,
				UseShellExecute = true
			});
		}
		private string SepararEncabezado(string texto)
		{
			return System.Text.RegularExpressions.Regex        			
			.Replace(texto, "([a-z])([A-Z])", "$1\n$2");
		}
	}
}
