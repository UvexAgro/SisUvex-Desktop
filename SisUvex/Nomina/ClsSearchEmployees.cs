using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.Values;
using System.Data;

namespace SisUvex.Nomina
{
    internal class ClsSearchEmployees
    {
        public DataTable dtEmployees = new DataTable();
        string query = "SELECT id_employee AS 'Código', v_lastNamePat AS 'Apellido paterno',  v_lastNameMat AS 'Apellido materno', v_name AS 'Nombre', id_paymentPlace AS 'LP' FROM Nom_Employees ";
        public string id { get; set; }
        public string lastNamePat { get; set; }
        public string lastNameMat { get; set; }
        public string name { get; set; }

        public void SetEmployeesTable()
        {
            if (dtEmployees.Rows.Count == 0)
            {
                dtEmployees = ClsQuerysDB.GetDataTable(query);
            }
        }

        public void FilterEmployeesWithFullName(string searchTerm)
        {
            if (searchTerm.Length == 0)
            {
                dtEmployees.DefaultView.RowFilter = null;
            }
            else
            {
                dtEmployees.DefaultView.RowFilter = "Código + ' ' + [Apellido paterno] + ' ' + [Apellido materno] + ' ' + Nombre LIKE '%" + searchTerm + "%'";
            }
            
        }
        public void GetEmployeeData(string idEmploye)
        {
            DataRow[] rows = dtEmployees.Select(" Código = " + ClsValues.FormatZeros(idEmploye,"000000"));
            if (rows.Length > 0)
            {
                id = rows[0]["Código"].ToString();
                lastNamePat = rows[0]["Apellido paterno"].ToString();
                lastNameMat = rows[0]["Apellido materno"].ToString();
                name = rows[0]["Nombre"].ToString();
            }
            else
            {
                id = string.Empty;
                lastNamePat = string.Empty;
                lastNameMat = string.Empty;
                name = string.Empty;
            }
        }
    }
}
