using Microsoft.IdentityModel.Tokens;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Querys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Nomina.Comedores.EmployeeDiningHallAssignment
{
    internal class ClsEmployeeDiningHallAssignment
    {
        public FrmEmployeeDiningHallAsingment frm;

        string qryReport = " SELECT \r\n\tdpr.id_dinerProvider AS [Num. Comedor],\r\n\tdpr.v_nameDinerProvider AS [Comedor],\r\n\temp.id_employee AS [Código Emp.],\r\n\temp.v_lastNamePat AS [A. Paterno],\r\n\temp.v_lastNameMat AS [A. Materno],\r\n\temp.v_name AS [Nombre],\r\n\temp.id_paymentPlace AS [LP]\r\n\r\nFROM Nom_Employees emp\r\n\r\nLEFT JOIN Nom_DinerProvider dpr ON dpr.id_dinerProvider = emp.id_dinerProvider ";

        public void LoadForm()
        {
            DataTable dtPlacePayment = ClsQuerysDB.GetDataTable(ClsObject.PlacePayment.QueryCbo);

            if (dtPlacePayment == null || dtPlacePayment.Rows.Count == 0)
                return;

            // Insertar la fila especial en el índice 1 (PARA QUE SE PUEDAN SELECCIONAR LOS EMPLEADOS QUE AUN NO SE LE HA ASIGNADO UN LUGAR DE TRABAJO)
            DataRow newRow = dtPlacePayment.NewRow();
            newRow[ClsObject.Column.id] = null;
            newRow[ClsObject.Column.active] = "1";
            newRow[ClsObject.Column.name] = "*Sin lugar de pago*";
            dtPlacePayment.Rows.InsertAt(newRow, 0);

            dtPlacePayment.DefaultView.RowFilter = $"{ClsObject.Column.active} = '1'";
            ClsComboBoxes.LoadComboBoxDataSource(frm.cboPaymentPlace, dtPlacePayment);

            DataTable dtProvider = ClsQuerysDB.GetDataTable(ClsObject.DinerProvider.QueryCbo);
            dtProvider.DefaultView.RowFilter = $"{ClsObject.Column.active} = '1'";
            ClsComboBoxes.LoadComboBoxDataSource(frm.cboDinerProvider, dtProvider);
        }

        public void SetDGVReport()
        {
            Dictionary<string, object?> dicDateTables = new();

            string where = " WHERE emp.id_dinerProvider is not null ";

            if (frm.cboDinerProvider.SelectedIndex > 0)
            {
                where += " AND dpr.id_dinerProvider = @DinerProvider ";
                dicDateTables.Add("@DinerProvider", frm.cboDinerProvider.SelectedValue);
            }

            if (frm.cboPaymentPlace.SelectedIndex > 0)
            {
                if (frm.cboPaymentPlace.SelectedValue.ToString().IsNullOrEmpty())
                {
                    where += " AND emp.id_paymentPlace IS NULL ";
                }
                else
                {
                    where += " AND emp.id_paymentPlace = @PaymentPlace ";
                    dicDateTables.Add("@PaymentPlace", frm.cboPaymentPlace.SelectedValue);
                }
            }

            frm.dgvLista.DataSource = ClsQuerysDB.ExecuteParameterizedQuery(qryReport + where, dicDateTables);
        }

        public void SetDGVReportEmployee()
        {
            Dictionary<string, object?> dicDateTables = new();
            dicDateTables.Add("@idEmployee", frm.txbIdEmployee.Text);

            string where = $" WHERE emp.id_employee = @idEmployee ";

            frm.dgvLista.DataSource = ClsQuerysDB.ExecuteParameterizedQuery(qryReport + where, dicDateTables);

            frm.txbIdEmployee.Focus();

            frm.txbIdEmployee.SelectAll();
        }
    }
}
