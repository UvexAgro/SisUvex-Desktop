using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using NPOI.SS.Formula.Functions;
using SisUvex.Catalogos;
using SisUvex.Catalogos.Metods.Values;
using SisUvex.Nomina.Asistencia_de_empaque;
namespace SisUvex.Nomina.Registro_de_Asistencia
{
	public class ClsRegistroA
	{
		public FrmRegistroA frm;
		string titulo = "Asistencia de empaque";
		SQLControl sql = new SQLControl();
		bool cargando = false;

		public void BuscarExcel()
		{
			frm.ofdExcel.Filter = "Archivos de Excel|*.xls;*.xlsx";

			if (frm.ofdExcel.ShowDialog() == DialogResult.OK)
			{
				string selectedFilePath = frm.ofdExcel.FileName;
				string fileExtension = Path.GetExtension(selectedFilePath).ToLower();

				if (fileExtension != ".xls" && fileExtension != ".xlsx")
				{
					MessageBox.Show("Seleccione un archivo de Excel válido.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}

				frm.btnExaminar.Enabled = false;
				frm.btnExcelAceptar.Enabled = false;
				frm.btnMostrar.Enabled = false;
				frm.cboHoja.Enabled = false;

				frm.txbRuta.Text = selectedFilePath;

				try
				{
					frm.cboHoja.Items.Clear();


					using (var workbook = new XLWorkbook(selectedFilePath))
					{
						foreach (var worksheet in workbook.Worksheets)
						{
							frm.cboHoja.Items.Add(worksheet.Name);
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error al cargar los nombres de las hojas del archivo de Excel: " + ex.Message);
				}

				frm.btnExaminar.Enabled = true;
				frm.btnExcelAceptar.Enabled = true;
				frm.btnMostrar.Enabled = true;
				frm.cboHoja.Enabled = true;

				if (frm.cboHoja.Items.Count > 0)
				{
					frm.cboHoja.SelectedIndex = 0;
				}
			}
		}
		public void CargarHojaExcelEnDatagridView()
		{
			if (frm.cboHoja.SelectedItem != null)
			{
				string selectedSheet = frm.cboHoja.SelectedItem?.ToString();
				string excelFilePath = frm.txbRuta.Text;

				if (!string.IsNullOrEmpty(selectedSheet) && !string.IsNullOrEmpty(excelFilePath))
				{
					try
					{
						using (var workbook = new XLWorkbook(excelFilePath))
						{
							var worksheet = workbook.Worksheet(selectedSheet);

							var range = worksheet.RangeUsed();

							if (range != null)
							{
								int rows = range.RowCount();
								int columns = range.ColumnCount();

								frm.dgvAsistencia.Rows.Clear();
								frm.dgvAsistencia.Columns.Clear();

								// Crear columnas (primera fila como encabezado)
								for (int c = 1; c <= columns; c++)
								{
									string header = range.Cell(1, c).GetValue<string>();
									if (string.IsNullOrWhiteSpace(header))
										header = "Column" + c;

									DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
									column.HeaderText = header;
									column.Name = header;

									frm.dgvAsistencia.Columns.Add(column);
								}

								// Agregar filas (desde la fila 2)
								for (int r = 2; r <= rows; r++)
								{
									DataGridViewRow row = new DataGridViewRow();

									for (int c = 1; c <= columns; c++)
									{
										DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
										cell.Value = range.Cell(r, c).Value;
										row.Cells.Add(cell);
									}

									frm.dgvAsistencia.Rows.Add(row);
								}

								return;
							}
							else
							{
								MessageBox.Show("No hay datos en la hoja seleccionada.", "Error en hoja seleccionada.");
							}
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("Error al cargar los datos.\n\nEl documento no cumple con el formato esperado.\n\n" + ex.Message);
					}

					frm.dgvAsistencia.DataSource = null;
					frm.dgvAsistencia.Rows.Clear();
					frm.dgvAsistencia.Columns.Clear();
				}
				else
				{
					MessageBox.Show("Debe seleccionar una hoja y cargar un archivo de Excel primero.");
				}
			}
		}

		public void BotonAceptar()
		{
			if (!frm.dgvAsistencia.Columns.Contains(frm.idEmpleado) || !frm.dgvAsistencia.Columns.Contains(frm.idActividad) || !frm.dgvAsistencia.Columns.Contains(frm.idBanda))
			{
				MessageBox.Show($"Se ocupan las columnas '{frm.idEmpleado}', '{frm.idActividad}' y '{frm.idBanda}'  en el Excel.");
			}
			else
			{//GUARDAR REGISTROS

				if (ValidarColumnaCodigo(frm.dgvAsistencia) && ValidarColumnaActividad(frm.dgvAsistencia) && ValidarColumnaBanda(frm.dgvAsistencia) && ValidarEmpleadoRepetido(frm.dgvAsistencia))
				{
					ConfirmarAccionAceptar();
				}
			}
		}
		private bool ValidarColumnaCodigo(DataGridView dataGridView)
		{
			foreach (DataGridViewRow row in dataGridView.Rows)
			{
				object cellValue = row.Cells[frm.idEmpleado].Value;
				string codigo = cellValue != null ? cellValue.ToString().Split('-')[0].Trim() : "";

				int codigoInt;

				if (!int.TryParse(codigo, out codigoInt) || codigoInt <= 0 || codigoInt > 999999 || codigo.Length == 0)
				{
					MessageBox.Show($"El valor: '{codigo}'\nNo cumple con el formato esperado para la columna {frm.idEmpleado}.", "Columna " + frm.idEmpleado);
					return false;
				}
			}

			return true;
		}

		private bool ValidarColumnaActividad(DataGridView dataGridView)
		{
			foreach (DataGridViewRow row in dataGridView.Rows)
			{
				object cellValue = row.Cells[frm.idActividad].Value;
				string codigo = cellValue != null ? cellValue.ToString().Split('-')[0].Trim() : "";

				int codigoInt;

				if (!int.TryParse(codigo, out codigoInt) || codigoInt <= 0 || codigoInt > 9999 || codigo.Length == 0)
				{
					MessageBox.Show($"El valor: '{codigo}'\nNo cumple con el formato esperado para la columna {frm.idActividad}.", "Columna " + frm.idActividad);
					return false;
				}
			}

			return true;
		}
		private bool ValidarColumnaBanda(DataGridView dataGridView)
		{
			foreach (DataGridViewRow row in dataGridView.Rows)
			{

				object cellValue = row.Cells[frm.idBanda].Value;
				string codigo = cellValue != null ? cellValue.ToString().Trim() : "";

				//  Permitir vacío
				if (string.IsNullOrEmpty(codigo))
					continue;

				if (string.IsNullOrEmpty(cellValue.ToString()))
					return true;


				int codigoInt;

				// Validar que sea entero y esté entre 1 y 999
				if (!int.TryParse(codigo, out codigoInt) || codigoInt < 1 || codigoInt > 999)
				{
					MessageBox.Show($"El valor: '{codigo}'\nNo cumple con el formato esperado para la columna {frm.idBanda}.", "Columna " + frm.idBanda);
					return false;
				}

				//  3 dígitos
				row.Cells[frm.idBanda].Value = codigoInt.ToString("000");
			}

			return true;
		}
		
		private bool ValidarEmpleadoRepetido(DataGridView dgv)
		{
			Dictionary<string, DataGridViewRow> empleados = new Dictionary<string, DataGridViewRow>();

			foreach (DataGridViewRow row in dgv.Rows)
			{
				if (row.IsNewRow)
					continue;

				string idEmpleado = row.Cells["EMPLEADO"].Value?.ToString().Split('-')[0].Trim();

				if (string.IsNullOrEmpty(idEmpleado))
					continue;

				//  SI YA EXISTE
				if (empleados.ContainsKey(idEmpleado))
				{
					var filaOriginal = empleados[idEmpleado];

					DialogResult resp = MessageBox.Show(
						$"El empleado {idEmpleado} ya tiene actividad:\n{filaOriginal.Cells["ACTIVIDAD"].Value}\n\n¿Deseas cambiarla por:\n{row.Cells["ACTIVIDAD"].Value}?",
						"Confirmar cambio",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Question
					);

					if (resp == DialogResult.Yes)
					{
						//  ACTUALIZA LA FILA ORIGINAL
						filaOriginal.Cells["ACTIVIDAD"].Value = row.Cells["ACTIVIDAD"].Value;
						filaOriginal.Cells["BANDA"].Value = row.Cells["BANDA"].Value;

						// ACTUALIZA TAGS (IMPORTANTE)
						filaOriginal.Cells["ACTIVIDAD"].Tag = row.Cells["ACTIVIDAD"].Tag;
						filaOriginal.Cells["BANDA"].Tag = row.Cells["BANDA"].Tag;
					}

					//  ELIMINA LA FILA DUPLICADA
					dgv.Rows.Remove(row);
					continue;
				}

				empleados.Add(idEmpleado, row);
			}

			return true;
		}
		public void ConfirmarAccionAceptar()
		{
			DialogResult result = MessageBox.Show("¿Está seguro de registrar los datos?", titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				string fecha = frm.dtpDay.Value.ToString("yyyy-MM-dd");
				int registros = ContarRegistrosPorFecha(fecha);

				if (registros == 0)
				{

					try
					{
						sql.BeginTransaction(); //aquí abre la conexion

						InsertarRegistrosDeAsistencia();

						sql.CommitTransaction(); //aquí cierra la conexion
					}
					catch (Exception ex)
					{
						sql.RollbackTransaction(); //aquí cierra la conexion
						MessageBox.Show(ex.ToString(), titulo);
					}

				}
				else
				{
					DialogResult overwriteResult = MessageBox.Show($"Ya existen {registros} registros para la fecha {fecha}. \n¿Desea sobreescribirlos?", titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

					if (overwriteResult == DialogResult.Yes)
					{
						try
						{
							sql.BeginTransaction();

							if (ExisteMiscellaneousPorFecha(fecha))
							{
								DialogResult resp = MessageBox.Show(
									"Existen ingresos/deducciones relacionados a esta fecha.\n\n¿Desea eliminarlos también?",
									titulo,
									MessageBoxButtons.YesNo,
									MessageBoxIcon.Warning
								);

								if (resp == DialogResult.Yes)
								{
									EliminarMiscellaneousPorFecha(fecha);
								}
								else
								{
									sql.RollbackTransaction();
									return;
								}
							}

							//  BORRA ASISTENCIA
							EliminarRegistrosPorFecha(fecha);

							//  INSERTA NUEVO
							InsertarRegistrosDeAsistencia();

							sql.CommitTransaction();
						}
						catch (Exception ex)
						{
							sql.RollbackTransaction();
							MessageBox.Show(ex.ToString(), titulo);
						}
					}
				}
			}
		}
		private int ContarRegistrosPorFecha(string fecha)
		{//USAR SOLO SI NO SE HA ABIERTO LA CONEXION
			int registros = 0;

			try
			{
				sql.OpenConectionWrite();
				SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Nom_AttendenceList WHERE d_attendence = @Fecha", sql.cnn);
				cmd.Parameters.AddWithValue("@Fecha", fecha);

				registros = (int)cmd.ExecuteScalar();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), titulo);
			}
			finally
			{
				sql.CloseConectionRead();
			}

			return registros;
		}
		public void InsertarRegistrosDeAsistencia()
		{ //USAR SOLO SI YA SE ABRIO LA CONEXION
			try
			{
				SqlCommand cmd = new SqlCommand("sp_Nom_AttendenceListAdd", sql.cnn, sql.transaction);
				cmd.CommandType = CommandType.StoredProcedure;

				int conteo = 0;
				string fecha = frm.dtpDay.Value.ToString("yyyy-MM-dd");

				if (frm.cboCuadrilla.SelectedValue == null || frm.cboCuadrilla.SelectedValue == DBNull.Value)
				{
					MessageBox.Show("Debe seleccionar una cuadrilla válida");
					return;
				}

				string idCuadrilla = frm.cboCuadrilla.SelectedValue.ToString().PadLeft(2, '0');

				foreach (DataGridViewRow row in frm.dgvAsistencia.Rows)
				{
					string codigo = row.Cells[frm.idEmpleado].Value?.ToString().Split('-')[0].Trim() ?? "";
					string actividad = row.Cells[frm.idActividad].Value?.ToString().Split('-')[0].Trim() ?? "";
					string banda = row.Cells[frm.idBanda].Value?.ToString() ?? "";

					cmd.Parameters.Clear();
					cmd.Parameters.AddWithValue("@idEmployee", ClsValues.FormatZeros(codigo, "000000"));
					cmd.Parameters.AddWithValue("@dAttendence", fecha);
					cmd.Parameters.AddWithValue("@codigoTab", ClsValues.FormatZeros(actividad, "0000"));
					cmd.Parameters.AddWithValue("@userCreate", User.GetUserName());
					cmd.Parameters.AddWithValue("@banda", ClsValues.IfEmptyToDBNull(banda));
					cmd.Parameters.AddWithValue("@idWorkGroup", idCuadrilla);

					try
					{
						cmd.ExecuteNonQuery();
					}
					catch (SqlException ex)
					{
						if (ex.Number == 547) // Número de error específico para violación de clave foránea
						{
							MessageBox.Show($"Debe ingresar un valor válido para el empleado: {codigo}", titulo);
						}
						else
						{
							MessageBox.Show(ex.ToString(), titulo);
						}
						sql.RollbackTransaction();
						return;
					}
					conteo++;
				}

				MessageBox.Show($"Se han añadido {conteo} registros para el día {fecha}", titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), titulo);
			}
		}
		private bool ExisteMiscellaneousPorFecha(string fecha)
		{
			int count = 0;

			try
			{
				SqlCommand cmd = new SqlCommand(@"
				SELECT COUNT(*)
				FROM dbo.Nom_MiscellaneousIncome mi
				INNER JOIN dbo.Nom_AttendenceList a
				ON mi.id_attendence = a.id_attendence
				WHERE CAST(a.d_attendence AS DATE) = @Fecha", sql.cnn, sql.transaction);

				cmd.Parameters.AddWithValue("@Fecha", fecha);

				count = (int)cmd.ExecuteScalar();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), titulo);
			}

			return count > 0;
		}
		private void EliminarMiscellaneousPorFecha(string fecha)
		{
			try
			{
				SqlCommand cmd = new SqlCommand(@"
				DELETE mi
				FROM dbo.Nom_MiscellaneousIncome mi
				INNER JOIN dbo.Nom_AttendenceList a
					ON mi.id_attendence = a.id_attendence
				WHERE CAST(a.d_attendence AS DATE) = @Fecha", sql.cnn, sql.transaction);

				cmd.Parameters.AddWithValue("@Fecha", fecha);
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), titulo);
				throw;
			}
		}
		public void EliminarRegistrosPorFecha(string fecha)
		{//USAR SOLO SI YA SE ABRIO LA CONEXION
			try
			{
				SqlCommand cmd = new SqlCommand("DELETE FROM Nom_AttendenceList WHERE d_attendence = @Fecha", sql.cnn, sql.transaction);
				cmd.Parameters.AddWithValue("@Fecha", fecha);

				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), titulo);
			}
		}
		public void CargarAsistenciasPorFecha()
		{
			DateTime fecha = frm.dtpDay.Value.Date;

			string query = @"
			SELECT 
				a.id_employee + ' - ' + 
				(e.v_lastNamePat + ' ' + e.v_lastNameMat + ' ' + e.v_name) AS Codigo,

				a.c_codigo_tab + ' - ' + t.v_descripcion_tab AS Actividad,

				a.id_productionLine AS Banda

			FROM Nom_AttendenceList a
			LEFT JOIN Nom_Employees e 
				ON a.id_employee = e.id_employee
			LEFT JOIN Nom_Tabulador t 
				ON a.c_codigo_tab = t.c_codigo_tab
			WHERE CAST(a.d_attendence AS DATE) = @Fecha
			ORDER BY a.id_employee
			";

			DataTable dt = new DataTable();

			try
			{
				sql.OpenConectionWrite();

				SqlCommand cmd = new SqlCommand(query, sql.cnn);
				cmd.Parameters.AddWithValue("@Fecha", fecha);

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(dt);

				frm.dgvAsistencia.Rows.Clear();

				foreach (DataRow dr in dt.Rows)
				{
					frm.dgvAsistencia.Rows.Add(
						dr["Codigo"].ToString(),
						dr["Actividad"].ToString(),
						dr["Banda"].ToString()
					);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error");
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public void EliminarRegistrosPorFechaDgv(string fecha)
		{
			try
			{
				sql.OpenConectionWrite();

				SqlCommand cmd = new SqlCommand(
					"DELETE FROM Nom_AttendenceList WHERE CAST(d_attendence AS DATE) = @Fecha",
					sql.cnn
				);

				cmd.Parameters.AddWithValue("@Fecha", fecha);

				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), titulo);
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public void CargarCuadrillas(ComboBox combo)
		{
			cargando = true;

			DataTable dt = CboCuadrilla();

			DataRow dr = dt.NewRow();
			dr["Código"] = DBNull.Value;
			dr["Nombre"] = " ------ Seleccionar ------ ";
			dt.Rows.InsertAt(dr, 0);

			combo.DataSource = dt.Copy();
			combo.DisplayMember = "Nombre";
			combo.ValueMember = "Código";
			combo.SelectedIndex = 0;

			cargando = false;
		}
		public DataTable CboCuadrilla()
		{
			DataTable dt = new DataTable();

			sql.OpenConectionWrite();

			string query = @" SELECT 
				g.id_workGroup AS Código,
				g.v_nameWorkGroup + ' - ' + c.v_nameContractor AS Nombre
			FROM Pack_WorkGroup g
			INNER JOIN Pack_Contractor c 
				ON g.id_contractor = c.id_contractor
			WHERE g.id_season = (
				SELECT TOP 1 id_season
				FROM Pack_Season
				WHERE CAST(GETDATE() AS DATE) 
					  BETWEEN CAST(d_seasonBegins AS DATE) 
					  AND CAST(d_seasonEnds AS DATE)
				ORDER BY d_seasonBegins DESC
			)
			AND g.c_active = 1
			ORDER BY g.v_nameWorkGroup";
			SqlCommand cmd = new SqlCommand(query, sql.cnn);

			SqlDataAdapter da = new SqlDataAdapter(cmd);
			da.Fill(dt);

			sql.CloseConectionWrite();

			return dt;
		}
	}
}
