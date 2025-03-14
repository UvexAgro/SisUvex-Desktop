using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Querys;
using System.Data;
using System.Data.OleDb;
using System.Numerics;

namespace SisUvex.Nomina.Padron.SUA
{
    class ClsSUALoad
    {
        public FrmSUALoad _frm;
        public DataTable LoadSUAErrors()
        {
            string suaPath = _frm.txbSUAPath.Text;
            string folderPath = System.IO.Path.GetDirectoryName(suaPath);
            string dbPath = System.IO.Path.Combine(folderPath, "SUA.MDB");

            string connectionString = @$"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath};Jet OLEDB:Database Password=S5@N52V49;";
            string query = "SELECT NSS, Falla FROM MovtosImp";

            DataTable dataTable = new DataTable();

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    dataTable.Load(reader);

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return dataTable;
        }

        public void BeginFrm()
        {
            CboSUAConfig();

            _frm.txbIntegratedDaylyWage.Text = ClsQuerysDB.GetData(" SELECT v_valueParameters FROM Conf_Parameters WHERE id_typeParameter = '01' AND id_parameter = '009' ");
        } 

        public void CboSUAConfig()
        {
            string qry = $" SELECT sua.id_SUAConfig AS [Código], CONCAT_WS(' | ', sua.id_SUAConfig, sua.v_SUAType, gro.v_shortName, sua.v_SUAPath) AS [Nombre], sua.id_grower AS [idGrower],sua.v_SUAPath AS [Path], sua.v_SUAType AS [Type], sua.v_computerName AS [Computer], gro.v_regPat AS [RegPat], gro.v_nameGrower AS [Grower], gro.v_shortName AS [GrowerShortName] FROM Nom_SUAConfig sua LEFT JOIN Pack_Grower gro ON gro.id_grower = sua.id_grower WHERE sua.v_computerName = @computerName ";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@computerName", Environment.MachineName);

            DataTable dt = ClsQuerysDB.ExecuteParameterizedQuery(qry, parameters);

            ClsComboBoxes.LoadComboBoxDataSource(_frm.cboIdSUAConfig, dt);

            _frm.cboIdSUAConfig.SelectedIndexChanged += (s, e) =>
            {
                if (_frm.cboIdSUAConfig.SelectedIndex > -1)
                {
                    DataRow dr = ((DataRowView)_frm.cboIdSUAConfig.SelectedItem).Row;
                    _frm.txbSUAPath.Text = dr["Path"].ToString();
                    _frm.txbGrower.Text = dr["Grower"].ToString();
                    _frm.txbRegPatGrower.Text = dr["RegPat"].ToString();
                    _frm.txbSUAType.Text = dr["Type"].ToString();
                    _frm.txbComputer.Text = dr["Computer"].ToString();
                    _frm.txbGrowerShortName.Text = dr["GrowerShortName"].ToString();

                    _frm.dgvQuery.DataSource = null;
                }
            };
        }

        public void BtnErrors()
        {
            if (_frm.cboIdSUAConfig.SelectedIndex > -0)
            {
                _frm.dgvQuery.DataSource = null;

                DataTable dtErrors = LoadSUAErrors();

                if (dtErrors.Rows.Count > 0)
                {
                    var nssList = dtErrors.AsEnumerable()
                                          .Select(row => $"'{row["NSS"].ToString()}'")
                                          .ToList();

                    string nssInClause = string.Join(", ", nssList);

                    string qry = $"SELECT id_employee AS [Código], v_lastNamePat AS [A. Paterno], v_lastNameMat AS [A. Materno], v_name AS [Nombre], c_numimss AS NSS, (SELECT COUNT(*) FROM Nom_Employees AS sub WHERE sub.c_numimss = main.c_numimss) AS [Repeticiones] FROM Nom_Employees AS main WHERE c_numimss IN ({nssInClause}) ORDER BY NSS, v_lastNamePat, v_lastNameMat, v_name;";

                    DataTable dtEmployeesData = ClsQuerysDB.GetDataTable(qry);

                    if (!ValidateNSSDuplicates(dtEmployeesData))
                        return;

                    if (!dtErrors.Columns.Contains("Código"))
                        dtErrors.Columns.Add("Código", typeof(int)).SetOrdinal(0);
                    if (!dtErrors.Columns.Contains("A. Paterno"))
                        dtErrors.Columns.Add("A. Paterno", typeof(string)).SetOrdinal(1);
                    if (!dtErrors.Columns.Contains("A. Materno"))
                        dtErrors.Columns.Add("A. Materno", typeof(string)).SetOrdinal(2);
                    if (!dtErrors.Columns.Contains("Nombre"))
                        dtErrors.Columns.Add("Nombre", typeof(string)).SetOrdinal(3);

                    foreach (DataRow errorRow in dtErrors.Rows)
                    {
                        if (BigInteger.TryParse(errorRow["NSS"].ToString(), out BigInteger errorNss))
                        {
                            foreach (DataRow employeeRow in dtEmployeesData.Rows)
                            {
                                BigInteger employeeNss = 0;
                                BigInteger.TryParse(employeeRow["NSS"].ToString(), out employeeNss);

                                if (errorNss == employeeNss)
                                {
                                    errorRow["Código"] = employeeRow["Código"];
                                    errorRow["A. Paterno"] = employeeRow["A. Paterno"];
                                    errorRow["A. Materno"] = employeeRow["A. Materno"];
                                    errorRow["Nombre"] = employeeRow["Nombre"];
                                }
                            }
                        }
                    }   

                    _frm.dgvQuery.DataSource = dtErrors;
                }
                else
                {
                    System.Media.SystemSounds.Hand.Play();

                    MessageBox.Show("No se encontraron fallas en la ruta de SUA.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                System.Media.SystemSounds.Hand.Play();
            }
        }

        public bool ValidateNSSDuplicates(DataTable dtEmployees)
        {
            if (dtEmployees.Rows.Count > 0)
            {
                FrmNSSDuplicates frmNSSDuplicates = new FrmNSSDuplicates();

                frmNSSDuplicates.dtEmployeesInput = dtEmployees;

                frmNSSDuplicates.ShowDialog();

                return frmNSSDuplicates.isDataValidated;
            }

            return true;
        }

        public void CreateTxtFiles()
        {
            string suaPath = _frm.txbSUAPath.Text;
            string folderSUAPath = System.IO.Path.GetDirectoryName(suaPath);
            string folderFilesPath = System.IO.Path.Combine(folderSUAPath, "Archivos SisUvex");

            var codigoList = _frm.dgvQuery.Rows.Cast<DataGridViewRow>()
                                               .Where(row => row.Cells["Código"].Value != null)
                                               .Select(row => $"'{row.Cells["Código"].Value.ToString()}'")
                                               .ToList();

            string idEmployeeInClause = string.Join(", ", codigoList);

            Directory.CreateDirectory(folderFilesPath);

            bool isFileGenerated = false;

            string growerShortName = _frm.txbGrowerShortName.Text + " " + _frm.txbSUAType.Text + " " + _frm.dtpHireDate.Value.ToString("yyyy-MM-dd");

            if (_frm.chbAfil.Checked)
            {
                string qryAfil = $" SELECT  EMP.id_employee, EMP.c_numimss, EMP.d_dateBirth, EMP.v_stateName, EMP.c_stateCode, EMP.c_gender FROM Nom_Employees AS EMP WHERE EMP.id_employee IN ({idEmployeeInClause}) ORDER BY EMP.v_lastNamePat, EMP.v_lastNameMat, EMP.v_name ";

                DataTable dtAfil = ClsQuerysDB.GetDataTable(qryAfil);

                DataTable filteredDtAfil = FilterDataTable(dtAfil);

                DataTable dtCompleteAfil = SetCompleteAFILTble(filteredDtAfil);

                if (filteredDtAfil.Rows.Count > 0)
                {
                    string filePathAfil = Path.Combine(folderFilesPath, $"{growerShortName} Afil.txt");
                    WriteDataTableToTxt(dtCompleteAfil, filePathAfil);
                    isFileGenerated = true;
                }
            }

            if (_frm.chbAseg.Checked)
            {
                string qryAseg = $" SELECT EMP.id_employee, EMP.v_lastNamePat,EMP.v_lastNameMat, EMP.v_name, GRO.v_regPat, EMP.c_numimss, EMP.v_rfcEmp, EMP.v_curp FROM Nom_Employees AS EMP JOIN Nom_PlacePayment AS PLAC ON EMP.id_paymentPlace = PLAC.id_placePayment JOIN Pack_Grower AS GRO ON GRO.id_grower = PLAC.id_grower WHERE EMP.id_employee IN ({idEmployeeInClause}) ORDER BY Emp.v_lastNamePat, Emp.v_lastNameMat, Emp.v_name";

                DataTable dtAseg = ClsQuerysDB.GetDataTable(qryAseg);

                DataTable filteredDtAseg = FilterDataTable(dtAseg);

                DataTable dtCompleteAseg = SetCompleteASEGTble(filteredDtAseg);

                if (filteredDtAseg.Rows.Count > 0)
                {
                    string filePathAseg = Path.Combine(folderFilesPath, $"{growerShortName} Aseg.txt");
                    WriteDataTableToTxt(dtCompleteAseg, filePathAseg);
                    isFileGenerated = true;
                }
            }

            OpenFolderPath();
        }

        private DataTable FilterDataTable(DataTable dataTable)
        {
            DataTable filteredTable = dataTable.Clone();
            foreach (DataRow row in dataTable.Rows)
            {
                if (!string.IsNullOrEmpty(row["id_employee"].ToString()) && !string.IsNullOrEmpty(row["c_numimss"].ToString()))
                    filteredTable.ImportRow(row);
            }
            return filteredTable;
        }
        
        private void WriteDataTableToTxt(DataTable dataTable, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    string line = string.Join("", row.ItemArray.Select(item => item.ToString()));
                    writer.WriteLine(line);
                }
            }
        }

        private DataTable SetCompleteASEGTble(DataTable dtEmployees)
        {
            DataTable dtComplete = new DataTable();
            dtComplete.Columns.Add("RegPat");   //11
            dtComplete.Columns.Add("NSS");      //11
            dtComplete.Columns.Add("RFC");      //13
            dtComplete.Columns.Add("CURP");     //18
            dtComplete.Columns.Add("Nombre");   //50
            dtComplete.Columns.Add("TipoTrabajador"); //1
            dtComplete.Columns.Add("Jornada");  //1
            dtComplete.Columns.Add("FechaAlta");//8
            dtComplete.Columns.Add("SalarioDiarioIntegrado");   //7
            dtComplete.Columns.Add("ClaveUbicacion");           //17
            dtComplete.Columns.Add("NumInfonavit");             //10
            dtComplete.Columns.Add("FechaInicioDescuento");     //8
            dtComplete.Columns.Add("TipoDescuento");            //1
            dtComplete.Columns.Add("ValorDescuento");           //8

            string ClaveUbicacion = new string(' ', 17);
            string NumInfonavit = new string(' ', 10);
            string FechaInicioDescuento = new string('0', 8);
            string TipoDescuento = new string('0', 1);
            string ValorDescuento = new string('0', 8);

            string RegPatronal = _frm.txbRegPatGrower.Text;
            string HireDate = _frm.dtpHireDate.Value.ToString("ddMMyyyy");

            string IntegratedDaylyWage = _frm.txbIntegratedDaylyWage.Text;
            if (decimal.TryParse(IntegratedDaylyWage, out decimal wage))
                IntegratedDaylyWage = (wage * 100).ToString("0000000");
            else
                IntegratedDaylyWage = "0000000";

            foreach (DataRow row in dtEmployees.Rows)
            {
                DataRow newRow = dtComplete.NewRow();
                newRow["RegPat"] = RegPatronal;
                newRow["NSS"] = row["c_numimss"];
                newRow["RFC"] = row["v_rfcEmp"];
                newRow["CURP"] = row["v_curp"];

                string nombre = row["v_lastNamePat"] + "$" + row["v_lastNameMat"] + "$" + row["v_name"];
                newRow["Nombre"] = nombre.PadRight(50);

                newRow["TipoTrabajador"] = "4";
                newRow["Jornada"] = "0";
                newRow["FechaAlta"] = HireDate;
                newRow["SalarioDiarioIntegrado"] = IntegratedDaylyWage;
                newRow["ClaveUbicacion"] = ClaveUbicacion;
                newRow["NumInfonavit"] = NumInfonavit;
                newRow["FechaInicioDescuento"] = FechaInicioDescuento;
                newRow["TipoDescuento"] = TipoDescuento;
                newRow["ValorDescuento"] = ValorDescuento;
                dtComplete.Rows.Add(newRow);
            }

            return dtComplete;
        }

        private DataTable SetCompleteAFILTble(DataTable dtEmployees)
        {
            DataTable dtComplete = new DataTable();
            dtComplete.Columns.Add("RegPat");   //11
            dtComplete.Columns.Add("NSS");      //11
            dtComplete.Columns.Add("CP");      //5
            dtComplete.Columns.Add("FechaNacimiento");     //8
            dtComplete.Columns.Add("EstadoNacimiento");   //25
            dtComplete.Columns.Add("ClaveEstadoNacimiento"); //2
            dtComplete.Columns.Add("UnidadMedicaFam");  //3
            dtComplete.Columns.Add("Ocupacion");//12
            dtComplete.Columns.Add("Sexo");   //1
            dtComplete.Columns.Add("TipoSalario");           //1
            dtComplete.Columns.Add("Hora");             //1

            string Ocupacion = new string(' ', 12);
            string Hora = new string(' ', 1);


            string RegPatronal = _frm.txbRegPatGrower.Text;

            foreach (DataRow row in dtEmployees.Rows)
            {
                DataRow newRow = dtComplete.NewRow();
                newRow["RegPat"] = RegPatronal;
                newRow["NSS"] = row["c_numimss"];
                newRow["CP"] = "83734";

                DateTime.TryParse(row["d_dateBirth"].ToString(), out DateTime birthDay);
                newRow["FechaNacimiento"] = birthDay.ToString("ddMMyyyy");

                newRow["EstadoNacimiento"] = row["v_stateName"].ToString().PadRight(25);
                newRow["ClaveEstadoNacimiento"] = row["c_stateCode"];
                newRow["UnidadMedicaFam"] = "032";
                newRow["Ocupacion"] = Ocupacion;
                newRow["Sexo"] = row["c_gender"];
                newRow["TipoSalario"] = "0";
                newRow["Hora"] = Hora;

                dtComplete.Rows.Add(newRow);
            }

            return dtComplete;
        }

        public void OpenFolderPath()
        {
            if (_frm.txbSUAPath.Text == "")
            {
                System.Media.SystemSounds.Hand.Play();
                MessageBox.Show("No se ha seleccionado una ruta del SUA.", "Generar archivos SUA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string suaPath = _frm.txbSUAPath.Text;
            string folderSUAPath = System.IO.Path.GetDirectoryName(suaPath);
            string folderFilesPath = System.IO.Path.Combine(folderSUAPath, "Archivos SisUvex");

            if (!Directory.Exists(folderFilesPath))
            {
                System.Media.SystemSounds.Hand.Play();
                MessageBox.Show("No se ha generado ningún archivo.", "Generar archivos SUA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult result = MessageBox.Show($"Archivos guardados en: {folderFilesPath}\n\n¿Desea abrir la carpeta?",
                "Ruta de la carpeta", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
                System.Diagnostics.Process.Start("explorer.exe", folderFilesPath);
        }
    }
}
