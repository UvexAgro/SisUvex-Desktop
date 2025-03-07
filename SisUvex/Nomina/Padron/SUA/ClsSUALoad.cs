using iText.Pdfua;
using Microsoft.Win32.SafeHandles;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Querys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

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
        } 

        public void CboSUAConfig()
        {
            string qry = $" select sua.id_SUAConfig AS [Código], CONCAT_WS(' | ', sua.id_SUAConfig, sua.v_SUAType, gro.v_shortName, sua.v_SUAPath) AS [Nombre], sua.id_grower AS [idGrower],sua.v_SUAPath AS [Path], sua.v_SUAType AS [Type], sua.v_computerName AS [Computer], gro.v_regPat AS [RegPat], gro.v_nameGrower AS [Grower] from Nom_SUAConfig sua LEFT JOIN Pack_Grower gro ON gro.id_grower = sua.id_grower WHERE sua.v_computerName = @computerName ";

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

                    //string qry = $"SELECT id_employee AS [Código], v_lastNamePat AS [A. Paterno], v_lastNameMat AS [A. Materno], v_name AS [Nombre], c_numimss AS NSS, (SELECT COUNT(*) FROM Nom_Employees AS sub WHERE sub.c_numimss = main.c_numimss) AS [Repeticiones] FROM Nom_Employees AS main WHERE c_numimss IN ({nssInClause}) ORDER BY NSS, v_lastNamePat, v_lastNameMat, v_name;";

                    string qry = "SELECT id_employee AS [Código], v_lastNamePat AS [A. Paterno], v_lastNameMat AS [A. Materno], v_name AS [Nombre], c_numimss AS NSS, (SELECT COUNT(*) FROM Nom_Employees AS sub WHERE sub.c_numimss = main.c_numimss) AS [Repeticiones] FROM Nom_Employees AS main WHERE c_numimss IN ('10139462013', '11169447031', '11169462345', '12160447129', '15160392658', \r\n                        '16160299000', '16160645707', '17159414022', '19148681026', '19220409171', \r\n                        '20160675904', '21160550600', '22160188987', '22160646901', '27159291700', \r\n                        '28160494549', '30160612062', '42169774462', '44220447005', '48048324122', \r\n                        '50210322876', '50220484906', '52190337593', '71149902398', '82119421863', \r\n                        '82129125678', '84078412487', '84200537839', '92169835912', '93169886004', \r\n                        '95169969243', '96169977491', '96169993456', '11139431131', '24129312385', ' 24129312385', '27149579313', '27149579313', '30190117942', '30190117942', '37169959139', '37169959139', '38179957758') ORDER BY NSS, v_lastNamePat, v_lastNameMat, v_name;";

                    DataTable dtEmployeesData = ClsQuerysDB.GetDataTable(qry);

                    ValidateNSSDuplicates(dtEmployeesData);

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
            }
            else
            {
                System.Media.SystemSounds.Hand.Play();
            }
        }

        public DataTable FilterNSSDuplicatesRows(DataTable dtEmployees)
        {
            DataTable duplicatesRowsTable = dtEmployees.Clone(); // Clona la estructura del DataTable original

            foreach (DataRow row in dtEmployees.Rows)
            {
                if (int.TryParse(row["Repeticiones"].ToString(), out int repetidos) && repetidos > 1)
                {
                    duplicatesRowsTable.ImportRow(row);
                }
            }

            return duplicatesRowsTable;
        }

        public bool ValidateNSSDuplicates(DataTable dtEmployees)
        {
            if (dtEmployees.Rows.Count > 0)
            {
                FrmNSSDuplicates frmNSSDuplicates = new FrmNSSDuplicates();

                frmNSSDuplicates.dtNSSDuplicatesEmployees = FilterNSSDuplicatesRows(dtEmployees);

                frmNSSDuplicates.ShowDialog();

                return frmNSSDuplicates.isDataValidated;
            }

            return true;
        }
    }
}
