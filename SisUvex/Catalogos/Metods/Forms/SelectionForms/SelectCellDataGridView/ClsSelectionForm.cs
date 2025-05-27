using Microsoft.IdentityModel.Tokens;
using SisUvex.Catalogos.Metods.Forms.SelectionForms.SelectCellDataGridView;
using SisUvex.Catalogos.Metods.Querys;
using System.Data;

namespace SisUvex.Catalogos.Metods.Forms.SelectionForms
{
    internal class ClsSelectionForm
    {
        private string? queryString { get; set; }
        private string? ParameterName { get; set; }
        private string? ColumnNameResult { get; set; }
        public string? SelectedValue { get; set; }

        public DataTable dtQuery { get; set; }

        private FrmSelectCellDataGridView frm;

        private readonly Dictionary<string, (string Query, string Parameter)> predefinedQueries = new()
            {
                { "EmployeeBasic", (" SELECT id_employee AS 'Código', v_lastNamePat AS 'A. paterno', v_lastNameMat AS 'A. materno', v_name AS 'Nombre', id_paymentPlace AS 'LP', id_workGroup AS 'Cuadrilla', id_productionLine AS 'Línea', dpr.v_nameDinerProvider AS 'Comedor' ,FORMAT(emp.d_dateBirth, 'yyyy-MM-dd') AS 'F. nacimiento' FROM Nom_Employees emp LEFT JOIN Nom_DinerProvider AS dpr ON dpr.id_dinerProvider = emp.id_dinerProvider WHERE CONCAT_WS(' ', v_lastNamePat, v_lastNameMat, v_name, id_employee) LIKE @parameter ", "@parameter") },
                {"Contractor", (" SELECT cat.* FROM vw_PackContractorCat cat JOIN Pack_Contractor ctr ON ctr.id_contractor = cat.Código WHERE CONCAT(v_nameContractor,' ',id_contractor) LIKE @parameter ", "@parameter")},
                {"TransportLine", (" SELECT * FROM vw_PackTransportLineCat WHERE CONCAT_WS(' ', Código, Nombre, SCAC, SCAAT) LIKE @parameter ", "@parameter")},
                {"Driver", (" SELECT * FROM vw_PackDriverCat WHERE CONCAT_WS(' ', Código, Nombre, [Línea de transporte]) LIKE @parameter ", "@parameter")},
                {"Truck", (" SELECT * FROM vw_PackTruckCat WHERE dbo.fn_CleanSpecialCharacters(CONCAT_WS(' ', Código, [N. Económico], [Placas US], [Placas MX], [Línea de transporte])) LIKE '%' + dbo.fn_CleanSpecialCharacters(@parameter) + '%' ", "@parameter")},
                {"FreightContainer", (" SELECT * FROM vw_PackFreightContainerCat WHERE dbo.fn_CleanSpecialCharacters(CONCAT_WS(' ', Código, [N. Económico], [Placas US], [Placas MX], [Línea de transporte])) LIKE '%' + dbo.fn_CleanSpecialCharacters(@parameter) + '%' ", "@parameter ")},
                {"MaterialCatalog", (" SELECT * FROM vw_PackMaterialCatalogCat WHERE dbo.fn_CleanSpecialCharacters(CONCAT_WS(' ', [Código], [Nombre])) LIKE '%' + dbo.fn_CleanSpecialCharacters(@parameter) + '%' ", "@parameter")},
                {"MaterialProvider", (" SELECT * FROM vw_PackProviderCat WHERE dbo.fn_CleanSpecialCharacters(CONCAT_WS(' ', [Código], [Nombre], [Diminutivo])) LIKE '%' + dbo.fn_CleanSpecialCharacters(@parameter) + '%' ", "@parameter")},
                {"Distributor", (" SELECT * FROM vw_PackDistributorCat WHERE dbo.fn_CleanSpecialCharacters(CONCAT_WS(' ', [Código], [Nombre], [Diminutivo])) LIKE '%' + dbo.fn_CleanSpecialCharacters(@parameter) + '%' ", "@parameter")},
                {"Grower", (" SELECT * FROM vw_PackGrowerCat WHERE dbo.fn_CleanSpecialCharacters(CONCAT_WS(' ', [Código], [Nombre], [Diminutivo])) LIKE '%' + dbo.fn_CleanSpecialCharacters(@parameter) + '%' ", "@parameter")},
                {"WareHouses", (" SELECT * FROM vw_PackWareHousesCat WHERE dbo.fn_CleanSpecialCharacters(CONCAT_WS(' ', [Código], [Nombre])) LIKE '%' + dbo.fn_CleanSpecialCharacters(@parameter) + '%' ", "@parameter")},
                {"MaterialType", (" SELECT id_matType AS [Código], v_nameMatType AS [Nombre] FROM Pack_MaterialType WHERE dbo.fn_CleanSpecialCharacters(CONCAT_WS(' ', id_matType, v_nameMatType)) LIKE '%' + dbo.fn_CleanSpecialCharacters(@parameter) + '%' ", "@parameter")},
                {"ForeignDest", (" SELECT * FROM vw_PackForeignDestCat WHERE dbo.fn_CleanSpecialCharacters(CONCAT_WS(' ', [Código], [Dirección], [Ciudad], [Estado], [C.P.])) LIKE '%' + dbo.fn_CleanSpecialCharacters(@parameter) + '%' ", "@parameter")},
            // Add more predefined queries here
            };

        public void OpenSelectionForm(string startQueryString, string parameterName, string columnNameResult)
        {
            queryString = startQueryString;
            ParameterName = parameterName;
            ColumnNameResult = columnNameResult;

            InitializeForm();
        }
        //[ENTRAN LOS PARÁMETROS PARA MOSTRAR LA QUERY CORRESPONDIENE DEL DICTIONARY Y DE EL NOMBRE DE LA COLUMNA DE DONDE VA A SACAR EL VALOR]
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

            if (!text.IsNullOrEmpty())
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                {ParameterName, $"%{text}%" }
                };

                dtQuery = ClsQuerysDB.ExecuteParameterizedQuery(queryString, parameters);

                frm.dgvRows.DataSource = dtQuery;
            }
            else
            {
                System.Media.SystemSounds.Hand.Play();
            }
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
