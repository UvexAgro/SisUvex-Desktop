using SisUvex.Catalogos.Metods.Forms.SelectionForms.SelectCellDataGridView;
using SisUvex.Catalogos.Metods.Querys;
using System.Data;

namespace SisUvex.Catalogos.Metods.Forms.SelectionForms
{
    internal class ClsSelectionForm
    {
        private string queryString { get; set; }
        private string ParameterName { get; set; }
        private string ColumnNameResult { get; set; }
        public string SelectedValue { get; set; }

        private DataTable DataTable { get; set; }

        private FrmSelectCellDataGridView frm;

        private readonly Dictionary<string, (string Query, string Parameter)> predefinedQueries = new()
            {
                { "EmployeeBasic", ("SELECT id_employee AS 'Código', v_lastNamePat AS 'A. paterno', v_lastNameMat AS 'A. materno', v_name AS 'Nombre', id_paymentPlace AS 'LP', id_workGroup AS 'Cuadrilla', id_productionLine AS 'Línea', dpr.v_nameDinerProvider AS 'Comedor' ,FORMAT(emp.d_dateBirth, 'yyyy-MM-dd') AS 'F. nacimiento' FROM Nom_Employees emp LEFT JOIN Nom_DinerProvider AS dpr ON dpr.id_dinerProvider = emp.id_dinerProvider WHERE CONCAT_WS(' ', v_lastNamePat, v_lastNameMat, v_name, id_employee) LIKE @parameter", "@parameter") },
                {"Contractor", ("SELECT cat.* FROM vw_PackContractorCat cat JOIN Pack_Contractor ctr ON ctr.id_contractor = cat.Código WHERE CONCAT(v_nameContractor,' ',id_contractor) LIKE @parameter", "@parameter")},
                // Add more predefined queries here
            };

        public void OpenSelectionForm(string startQueryString, string parameterName, string columnNameResult)
        {
            queryString = startQueryString;
            ParameterName = parameterName;
            ColumnNameResult = columnNameResult;

            InitializeForm();
        }

        public void OpenSelectionForm(string QueryKey, string columnNameResult)
        {
            if (predefinedQueries.TryGetValue(QueryKey, out var queryDetails))
            {
                queryString= queryDetails.Query;
                ParameterName = queryDetails.Parameter;

                ColumnNameResult = columnNameResult;

                InitializeForm();
            }
            else
            {
                throw new ArgumentException("No se encontró la palabre clave para el formulario de selección.");
            }
        }

        private void InitializeForm()
        {
            frm = new FrmSelectCellDataGridView();

            frm.btnSearch.Click += (s, e) => btnSearch(frm.txbSearch.Text);
            frm.btnSelect.Click += (s, e) => btnSelect();
            frm.btnCancel.Click += (s, e) => CloseSelectionForm();
            frm.txbSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSearch(frm.txbSearch.Text);
                    e.SuppressKeyPress = true;
                }
            };
            frm.dgvRows.CellDoubleClick += (s, e) => btnSelect();

            frm.ShowDialog();
        }

        private void CloseSelectionForm()
        {
            frm.Close();
        }

        private void btnSearch(string text)
        {
            //// Copiar el valor de query al portapapeles
            //System.Windows.Forms.Clipboard.SetText(query);

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {ParameterName, $"%{text}%" }
            };

            frm.dgvRows.DataSource = ClsQuerysDB.ExecuteParameterizedQuery(queryString, parameters);
        }

        private void btnSelect()
        {
            if (frm.dgvRows.Rows.Count == 0 || frm.dgvRows.CurrentRow == null)
            {
                System.Media.SystemSounds.Hand.Play();
            }
            else
            {
                var cellValue = frm.dgvRows.CurrentRow.Cells[ColumnNameResult]?.Value;
                if (cellValue != null)
                {
                    SelectedValue = cellValue.ToString();
                }
                frm.Close();
            }
        }
    }
}
