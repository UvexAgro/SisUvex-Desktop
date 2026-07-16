using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using System.Data.SqlClient;
using NPOI.OpenXmlFormats.Spreadsheet;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.Values;
using SisUvex.Configuracion.Parameters;
using ZXing;
using static SisUvex.Catalogos.Metods.ClsObject;
using Excel = Microsoft.Office.Interop.Excel;

namespace SisUvex.Nomina.Nom_Reporte_de_sueldos_diarios
{

	internal class ClsNomSemana
	{
		public FrmNomsemana frmNom;
		public List<string> empleadosSeleccionados = new List<string>();

		private string ObtenerTabla()
		{
			if (frmNom.rbtEsparrago.Checked)
				return "HistNom_ReporteSemanalEsparrago";

			if (frmNom.rbtUva.Checked)
				return "HistNom_ReporteSemanalUva";

			MessageBox.Show("Selecciona tipo de nómina");
			return null;
		}

		public void CargarPeriodos()
		{
			ClsComboBoxes.CboLoadActives(frmNom.cboSemana, Payroll_AttendancePeriod.Cbo);

			DateTime hoy = DateTime.Today;

			for (int i = 0; i < frmNom.cboSemana.Items.Count; i++)
			{
				DataRowView row = (DataRowView)frmNom.cboSemana.Items[i];

				if (row[Payroll_AttendancePeriod.ColumnStartDate] == DBNull.Value ||
					row[Payroll_AttendancePeriod.ColumnEndDate] == DBNull.Value)
				{
					continue;
				}

				DateTime fechaInicio = Convert.ToDateTime(row[Payroll_AttendancePeriod.ColumnStartDate]);
				DateTime fechaFin = Convert.ToDateTime(row[Payroll_AttendancePeriod.ColumnEndDate]);

				if (hoy >= fechaInicio && hoy <= fechaFin)
				{
					frmNom.cboSemana.SelectedIndex = i;
					break;
				}
			}
		}
		public DataTable ObtenerSueldosSemanaVarios()
		{
			string tabla = ObtenerTabla();
			if (tabla == null) return null;

			DataRowView row = (DataRowView)frmNom.cboSemana.SelectedItem;

			DateTime fechaInicio = Convert.ToDateTime(row[Payroll_AttendancePeriod.ColumnStartDate]);
			DateTime fechaFin = Convert.ToDateTime(row[Payroll_AttendancePeriod.ColumnEndDate]);

			if (empleadosSeleccionados.Count == 0)
			{
				MessageBox.Show("No hay empleados agregados.");
				return null;
			}

			string filtro = string.Join(",", empleadosSeleccionados.Select(e => $"'{e}'"));

			// columnas dinámicas (fechas)
			List<string> columnas = new();
			for (DateTime d = fechaInicio; d <= fechaFin; d = d.AddDays(1))
			{
				columnas.Add($"[{d:yyyy-MM-dd}]");
			}

			string columnasPivot = string.Join(",", columnas);

			string query = $@"
			SELECT *
			FROM
			(
				SELECT 
					h.IdEmpleado as Codigo,
					h.NombreCompleto,
					v.Fecha,
					v.SueldoTotal
				FROM {tabla} h

				CROSS APPLY
				(
					VALUES
					(DATEADD(DAY,0,h.FechaInicioSemana),h.Vie),
					(DATEADD(DAY,1,h.FechaInicioSemana),h.Sab),
					(DATEADD(DAY,2,h.FechaInicioSemana),h.Dom),
					(DATEADD(DAY,3,h.FechaInicioSemana),h.Lun),
					(DATEADD(DAY,4,h.FechaInicioSemana),h.Mar),
					(DATEADD(DAY,5,h.FechaInicioSemana),h.Mie),
					(DATEADD(DAY,6,h.FechaInicioSemana),h.Jue)
				) v(Fecha,SueldoTotal)

				WHERE h.FechaInicioSemana = '{fechaInicio:yyyy-MM-dd}'
				AND h.IdEmpleado IN ({filtro})
			) src

			PIVOT
			(
				SUM(SueldoTotal)
				FOR Fecha IN ({columnasPivot})
			) p

			ORDER BY NombreCompleto";

			return ClsQuerysDB.GetDataTable(query);
		}
		public void AgregarEmpleado()
		{
			string tabla = ObtenerTabla();
			if (tabla == null) return;

			string codigo = frmNom.txbCodigo.Text.Trim();

			if (codigo == "")
			{
				MessageBox.Show("Ingresa un código de empleado.");
				return;
			}

			string query = $@"
			SELECT 
			IdEmpleado as Codigo,
			NombreCompleto 
			FROM {tabla}
			WHERE IdEmpleado = '{codigo}'";

			DataTable dt = ClsQuerysDB.GetDataTable(query);

			if (dt.Rows.Count == 0)
			{
				MessageBox.Show("El empleado no existe en la nómina seleccionada.");
				return;
			}

			string nombre = dt.Rows[0]["NombreCompleto"].ToString();

			if (empleadosSeleccionados.Contains(codigo))
			{
				MessageBox.Show("El empleado ya está agregado.");
				return;
			}

			empleadosSeleccionados.Add(codigo);

			if (frmNom.dgvListaEmpleado.Columns.Count == 0)
			{
				frmNom.dgvListaEmpleado.Columns.Add("IdEmpleado", "Codigo");
				frmNom.dgvListaEmpleado.Columns.Add("Nombre", "Nombre");
			}

			frmNom.dgvListaEmpleado.Rows.Add(codigo, nombre);

			frmNom.txbCodigo.Clear();
		}

		public DataTable ObtenerSueldosSemana()
		{
			string tabla = ObtenerTabla();
			if (tabla == null) return null;

			DataRowView row = (DataRowView)frmNom.cboSemana.SelectedItem;

			DateTime fechaInicio = Convert.ToDateTime(row[Payroll_AttendancePeriod.ColumnStartDate]);
			DateTime fechaFin = Convert.ToDateTime(row[Payroll_AttendancePeriod.ColumnEndDate]);

			string f1 = fechaInicio.ToString("yyyy-MM-dd");
			string f2 = fechaFin.ToString("yyyy-MM-dd");

			List<string> columnas = new();

			for (DateTime d = fechaInicio; d <= fechaFin; d = d.AddDays(1))
			{
				columnas.Add($"[{d:yyyy-MM-dd}]");
			}

			string columnasPivot = string.Join(",", columnas);

			string query = $@"
			SELECT *
			FROM
			(
			SELECT 
            h.IdEmpleado as Codigo,
            h.NombreCompleto,
            v.Fecha,
            v.SueldoTotal
			FROM {tabla} h

			CROSS APPLY
			(
            VALUES
            (DATEADD(DAY,0,h.FechaInicioSemana),h.Vie),
            (DATEADD(DAY,1,h.FechaInicioSemana),h.Sab),
            (DATEADD(DAY,2,h.FechaInicioSemana),h.Dom),
            (DATEADD(DAY,3,h.FechaInicioSemana),h.Lun),
            (DATEADD(DAY,4,h.FechaInicioSemana),h.Mar),
            (DATEADD(DAY,5,h.FechaInicioSemana),h.Mie),
            (DATEADD(DAY,6,h.FechaInicioSemana),h.Jue)
			) v(Fecha,SueldoTotal)

			WHERE h.FechaInicioSemana = '{f1}'
			) src

			PIVOT
			(
			SUM(SueldoTotal)
			FOR Fecha IN ({columnasPivot})
			) p

			ORDER BY NombreCompleto";

			return dtSemana(query);
		}
		
		private DataTable dtSemana(string query)
		{
			DataTable dataTable = new DataTable();
			SQLControl sql = new SQLControl();
			try
			{
				sql.OpenConectionWrite();
				SqlDataAdapter dataAdapter = new SqlDataAdapter(query, sql.cnn);
				dataAdapter.SelectCommand.CommandTimeout = 130;
				dataAdapter.Fill(dataTable);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Obtener tabla de consulta.");
			}
			finally
			{
				sql.CloseConectionWrite();
			}

			return dataTable;
		}


		public void ExportarExcel(DataGridView dgv)
		{
			using (var wb = new XLWorkbook())
			{
				var ws = wb.Worksheets.Add("Reporte");

				int columnas = dgv.Columns.Count;
				int filaEncabezado = 4;   // dejamos espacio para título
				int filaDatosInicio = 5;

				string semana = frmNom.cboSemana.Text;

				// TITULO
				ws.Cell(1, 1).Value = "REPORTE SEMANAL DE SUELDOS";
				ws.Range(1, 1, 1, columnas + 1).Merge();
				ws.Cell(1, 1).Style.Font.Bold = true;
				ws.Cell(1, 1).Style.Font.FontSize = 18;
				ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

				ws.Cell(2, 1).Value = semana;
				ws.Range(2, 1, 2, columnas + 1).Merge();
				ws.Cell(2, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
				ws.Cell(2, 1).Style.Font.Bold = true;

				// ENCABEZADOS
				for (int i = 0; i < columnas; i++)
				{
					ws.Cell(filaEncabezado, i + 1).Value = dgv.Columns[i].HeaderText;
				}

				ws.Cell(filaEncabezado, columnas + 1).Value = "TOTAL";

				var header = ws.Range(filaEncabezado, 1, filaEncabezado, columnas + 1);
				header.Style.Font.Bold = true;
				header.Style.Fill.BackgroundColor = XLColor.DarkBlue;
				header.Style.Font.FontColor = XLColor.White;
				header.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

				// DATOS
				for (int i = 0; i < dgv.Rows.Count; i++)
				{
					double total = 0;

					for (int j = 0; j < columnas; j++)
					{
						var valor = dgv.Rows[i].Cells[j].Value;

						ws.Cell(i + filaDatosInicio, j + 1).Value = valor?.ToString();

						if (j >= 2 && valor != null && double.TryParse(valor.ToString(), out double numero))
						{
							total += numero;
							ws.Cell(i + filaDatosInicio, j + 1).Style.NumberFormat.Format = "$#,##0.00";
						}
					}

					ws.Cell(i + filaDatosInicio, columnas + 1).Value = total;
					ws.Cell(i + filaDatosInicio, columnas + 1).Style.NumberFormat.Format = "$#,##0.00";
					ws.Cell(i + filaDatosInicio, columnas + 1).Style.Font.Bold = true;
				}

				int filaTotal = dgv.Rows.Count + filaDatosInicio;



				// BORDES
				var rango = ws.Range(filaEncabezado, 1, filaTotal, columnas + 1);
				rango.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
				rango.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

				ws.Columns().AdjustToContents();

				// CONGELAR ENCABEZADO
				ws.SheetView.FreezeRows(filaEncabezado);

				// GUARDAR
				SaveFileDialog guardar = new SaveFileDialog();
				guardar.Filter = "Archivo Excel (*.xlsx)|*.xlsx";

				string semanaArchivo = semana.Replace("/", "-");
				guardar.FileName = $"{semanaArchivo}.xlsx";

				if (guardar.ShowDialog() == DialogResult.OK)
				{
					try
					{
						wb.SaveAs(guardar.FileName);

						DialogResult abrir = MessageBox.Show(
							"Archivo guardado correctamente.\n¿Deseas abrir el Excel?",
							"Abrir archivo",
							MessageBoxButtons.YesNo,
							MessageBoxIcon.Question);

						if (abrir == DialogResult.Yes)
						{
							Process.Start(new ProcessStartInfo
							{
								FileName = guardar.FileName,
								UseShellExecute = true
							});
						}
					}
					catch (IOException)
					{
						MessageBox.Show(
							"El archivo está abierto.\nCierra el Excel y vuelve a intentar.",
							"Archivo en uso",
							MessageBoxButtons.OK,
							MessageBoxIcon.Warning);
					}
				}
			}
		}


		public void ExportarExcelEmpleado(DataTable dt)
		{
			using (XLWorkbook wb = new XLWorkbook())
			{
				var ws = wb.Worksheets.Add("Reporte");

				string semana = frmNom.cboSemana.Text.Replace("/", "-");

				// TITULO
				ws.Cell(1, 1).Value = "REPORTE SEMANAL DE SUELDO POR EMPLEADO";
				ws.Range(1, 1, 1, dt.Columns.Count + 1).Merge();
				ws.Cell(1, 1).Style.Font.Bold = true;
				ws.Cell(1, 1).Style.Font.FontSize = 16;
				ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

				// SEMANA
				ws.Cell(2, 1).Value = semana;
				ws.Range(2, 1, 2, dt.Columns.Count + 1).Merge();
				ws.Cell(2, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
				ws.Cell(2, 1).Style.Font.Bold = true;

				// ENCABEZADOS
				for (int i = 0; i < dt.Columns.Count; i++)
				{
					ws.Cell(4, i + 1).Value = dt.Columns[i].ColumnName;
				}

				// columna TOTAL
				ws.Cell(4, dt.Columns.Count + 1).Value = "TOTAL";

				var header = ws.Range(4, 1, 4, dt.Columns.Count + 1);
				header.Style.Fill.BackgroundColor = XLColor.DarkMidnightBlue;
				header.Style.Font.FontColor = XLColor.White;
				header.Style.Font.Bold = true;
				header.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

				// DATOS
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					double total = 0;

					for (int j = 0; j < dt.Columns.Count; j++)
					{
						ws.Cell(i + 5, j + 1).Value = dt.Rows[i][j]?.ToString();

						// columnas de días
						if (j >= 2 && dt.Rows[i][j] != DBNull.Value)
						{
							if (double.TryParse(dt.Rows[i][j].ToString(), out double sueldo))
							{
								total += sueldo;
								ws.Cell(i + 5, j + 1).Style.NumberFormat.Format = "$#,##0.00";
							}
						}
					}

					// escribir TOTAL por empleado
					ws.Cell(i + 5, dt.Columns.Count + 1).Value = total;
					ws.Cell(i + 5, dt.Columns.Count + 1).Style.NumberFormat.Format = "$#,##0.00";
					ws.Cell(i + 5, dt.Columns.Count + 1).Style.Font.Bold = true;
				}

				// BORDES
				var rango = ws.Range(4, 1, dt.Rows.Count + 4, dt.Columns.Count + 1);
				rango.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
				rango.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

				ws.Columns().AdjustToContents();

				SaveFileDialog guardar = new SaveFileDialog();
				guardar.Filter = "Excel (*.xlsx)|*.xlsx";
				string semanaArchivo = semana.Replace("/", "-");
				guardar.FileName = $"Empleado {semana}.xlsx";

				if (guardar.ShowDialog() == DialogResult.OK)
				{
					try
					{
						wb.SaveAs(guardar.FileName);

						DialogResult abrir = MessageBox.Show(
							"Archivo guardado correctamente.\n¿Deseas abrir el Excel?",
							"Abrir archivo",
							MessageBoxButtons.YesNo,
							MessageBoxIcon.Question);

						if (abrir == DialogResult.Yes)
						{
							Process.Start(new ProcessStartInfo
							{
								FileName = guardar.FileName,
								UseShellExecute = true
							});
						}
					}
					catch (IOException)
					{
						MessageBox.Show(
							"El archivo está abierto.\nCierra el Excel y vuelve a intentar.",
							"Archivo en uso",
							MessageBoxButtons.OK,
							MessageBoxIcon.Warning);
					}
				}
			}
		}

		public bool ValidarEmpleadoSemana()
		{
			if (frmNom.cboSemana.SelectedIndex == -1)
			{
				MessageBox.Show(
					"Selecciona una semana.",
					"Información",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return false;
			}

			if (string.IsNullOrWhiteSpace(frmNom.txbCodigo.Text))
			{
				MessageBox.Show(
					"Ingresa un código de empleado.",
					"Código requerido",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return false;
			}

			string query = $@"
			SELECT 1 
			FROM Nom_Employees 
			WHERE id_employee = '{frmNom.txbCodigo.Text}'";

			DataTable existe = ClsQuerysDB.GetDataTable(query);

			if (existe.Rows.Count == 0)
			{
				MessageBox.Show(
					"El ID de empleado es incorrecto.",
					"Empleado no encontrado",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return false;
			}

			return true;
		}
		public void VerificarEmpleadosSinDatos(DataTable dt)
		{
			List<string> empleadosSinDatos = new List<string>();

			foreach (DataRow row in dt.Rows)
			{
				bool tieneDatos = false;

				// Saltamos las primeras columnas (IdEmpleado y NombreCompleto)
				for (int i = 2; i < dt.Columns.Count; i++)
				{
					if (row[i] != DBNull.Value)
					{
						tieneDatos = true;
						break;
					}
				}

				if (!tieneDatos)
				{
					empleadosSinDatos.Add(row["NombreCompleto"].ToString());
				}
			}

			if (empleadosSinDatos.Count > 0)
			{
				MessageBox.Show(
					"Los siguientes empleados no tienen datos en toda la semana:\n\n" +
					string.Join("\n", empleadosSinDatos),
					"Aviso",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

			}
		}
		public void EstilizarDGV(DataGridView dgv)
		{
			dgv.BorderStyle = BorderStyle.None;
			dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

			dgv.EnableHeadersVisualStyles = false;
			dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

			dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 40, 55);
			dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
			dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
			dgv.ColumnHeadersHeight = 35;

			dgv.DefaultCellStyle.Font = new Font("Segoe UI", 8);
			dgv.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 120, 215);

			dgv.RowTemplate.Height = 28;

			dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);

			dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgv.MultiSelect = false;

			dgv.RowHeadersVisible = false;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToResizeRows = false;
			dgv.AllowUserToResizeColumns = false;

			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor =
				dgv.ColumnHeadersDefaultCellStyle.BackColor;
		}
		public void ConfigurarColumnas(DataGridView dgv)
		{
			if (dgv.Columns["Codigo"] != null)
			{
				dgv.Columns["Codigo"].Width = 90;
				dgv.Columns["Codigo"].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleCenter;
			}

			if (dgv.Columns["Nombre"] != null)
			{
				dgv.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				dgv.Columns["Nombre"].DefaultCellStyle.Font =
					new Font("Segoe UI", 10, FontStyle.Bold);
			}
		}
		public void EstilizarDGVEmployee(DataGridView dgv)
		{
			dgv.BorderStyle = BorderStyle.None;
			dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;

			dgv.EnableHeadersVisualStyles = false;
			dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

			dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 40, 55);
			dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
			dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
			dgv.ColumnHeadersHeight = 35;

			dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
			dgv.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 120, 215);

			dgv.RowTemplate.Height = 28;

			dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);

			dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgv.MultiSelect = false;

			dgv.RowHeadersVisible = false;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToResizeRows = false;
			dgv.AllowUserToResizeColumns = false;

			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor =
				dgv.ColumnHeadersDefaultCellStyle.BackColor;
		}
	}
}










