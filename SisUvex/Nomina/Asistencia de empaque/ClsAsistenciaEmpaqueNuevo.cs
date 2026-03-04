using System.Data;
using System.Data.SqlClient;
using SisUvex.Catalogos;
using ClosedXML.Excel;
using SisUvex.Catalogos.Metods.Values;

namespace SisUvex.Nomina.Asistencia_de_empaque
{
    internal class ClsAsistenciaEmpaqueNuevo : ClsCatalogos
    {
        SQLControl sql = new SQLControl();
        public FrmAsistenciaEmpaqueNuevo frm;
        string titulo = "Asistencia de empaque";

        public ClsAsistenciaEmpaqueNuevo(FrmAsistenciaEmpaqueNuevo frmAsistenciaEmpaqueNuevo)
        { 
            this.frm = frmAsistenciaEmpaqueNuevo;
        }
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
				frm.btnAceptar.Enabled = false;
				frm.btnMostrar.Enabled = false;
				frm.cboHoja.Enabled = false;

				frm.txbExaminar.Text = selectedFilePath;

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
				frm.btnAceptar.Enabled = true;
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
				string excelFilePath = frm.txbExaminar.Text;

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

								frm.dgvLista.Rows.Clear();
								frm.dgvLista.Columns.Clear();

								// Crear columnas (primera fila como encabezado)
								for (int c = 1; c <= columns; c++)
								{
									string header = range.Cell(1, c).GetValue<string>();
									if (string.IsNullOrWhiteSpace(header))
										header = "Column" + c;

									DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
									column.HeaderText = header;
									column.Name = header;

									frm.dgvLista.Columns.Add(column);
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

									frm.dgvLista.Rows.Add(row);
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

					frm.dgvLista.DataSource = null;
					frm.dgvLista.Rows.Clear();
					frm.dgvLista.Columns.Clear();
				}
				else
				{
					MessageBox.Show("Debe seleccionar una hoja y cargar un archivo de Excel primero.");
				}
			}
		}

		public void BotonAceptar()
        {
            if (!frm.dgvLista.Columns.Contains(frm.idEmpleado) || !frm.dgvLista.Columns.Contains(frm.idActividad) || !frm.dgvLista.Columns.Contains(frm.idBanda))
            {
                MessageBox.Show($"Se ocupan las columnas '{frm.idEmpleado}', '{frm.idActividad}' y '{frm.idBanda}'  en el Excel.");
            }
            else
            {//GUARDAR REGISTROS

                if (ValidarColumnaCodigo(frm.dgvLista) && ValidarColumnaActividad(frm.dgvLista) && ValidarColumnaBanda(frm.dgvLista))
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
                string codigo = cellValue != null ? cellValue.ToString() : "";

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
                string codigo = cellValue != null ? cellValue.ToString() : "";

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



        //private bool ValidarColumnaHorasExtras(DataGridView dataGridView)
        //      {
        //          foreach (DataGridViewRow row in dataGridView.Rows)
        //          {
        //              string _horasExtras = row.Cells[frm.horasExtras].Value?.ToString() ?? "";

        //              if (!string.IsNullOrEmpty(_horasExtras))
        //              {
        //                  decimal horasExtrasDecimal;

        //                  if (!decimal.TryParse(_horasExtras, out horasExtrasDecimal) || horasExtrasDecimal < 0)
        //                  {
        //                      MessageBox.Show($"El valor: '{_horasExtras}'\nNo cumple con el formato esperado para la columna {frm.horasExtras}.", "Columna " + frm.horasExtras);
        //                      return false;
        //                  }
        //              }
        //          }

        //          return true;
        //      }

        public void ConfirmarAccionAceptar()
        {
            DialogResult result = MessageBox.Show("¿Está seguro de registrar los datos del Excel?", titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string fecha = frm.dtpDia.Value.ToString("yyyy-MM-dd");
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
                            sql.BeginTransaction(); //aquí abre la conexion

                            EliminarRegistrosPorFecha(fecha);

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

        public void InsertarRegistrosDeAsistencia()
        { //USAR SOLO SI YA SE ABRIO LA CONEXION
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Nom_AttendenceListAdd", sql.cnn, sql.transaction);
                cmd.CommandType = CommandType.StoredProcedure;

                int conteo = 0;
                string fecha = frm.dtpDia.Value.ToString("yyyy-MM-dd");

                foreach (DataGridViewRow row in frm.dgvLista.Rows)
                {
                    string codigo = row.Cells[frm.idEmpleado].Value?.ToString() ?? "";
                    string actividad = row.Cells[frm.idActividad].Value?.ToString() ?? "";
                    string banda = row.Cells[frm.idBanda].Value?.ToString() ?? "";

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@idEmployee", FormatoCeros(codigo, "000000"));
                    cmd.Parameters.AddWithValue("@dAttendence", fecha);
                    cmd.Parameters.AddWithValue("@codigoTab", FormatoCeros(actividad, "0000"));
                    cmd.Parameters.AddWithValue("@userCreate", User.GetUserName());
                    cmd.Parameters.AddWithValue("@banda", ClsValues.IfEmptyToDBNull(banda));

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

                MessageBox.Show($"Se han añadido {conteo} registros para el día {fecha}",titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), titulo);
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
    }
}

