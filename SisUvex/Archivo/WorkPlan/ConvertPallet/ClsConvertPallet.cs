using System.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Querys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using SisUvex.Catalogos.Metods.Values;
using SisUvex.Catalogos.Metods.TextBoxes;

namespace SisUvex.Archivo.WorkPlan.ConvertPallet
{
    internal class ClsConvertPallet
    {
        SQLControl sql = new SQLControl();
        public FrmConvertPallet frm;
        DataTable? dtCboWorkPlan = null;
        DataTable? dtPalletList = null;
        string queryCboWorkPlan = " SELECT [Activo], [Código], CONCAT_WS(' ', Código, '|', 'Cuadrilla:',Cuadrilla, '|'+dis.v_nameDistShort, Lote, Variedad, Tamaño, CONCAT(Contenedor, CAST(Libras AS float)),[Pre etiqueta], Presentación, [Post etiqueta]) AS [Nombre], Fecha AS [Fecha] FROM vw_PackWorkPlanCat cat JOIN Pack_GTIN gtn ON gtn.id_GTIN = cat.GTIN join Pack_Distributor dis ON dis.id_distributor = gtn.id_distributor WHERE [Activo] = '1' ";
        string queryPallet = " SELECT * FROM vw_PackPalletCon ";

        public ClsConvertPallet()
        {
            frm = new FrmConvertPallet();
            frm.cls = this;
        }
        public void BeginForm()
        {
            ClsTextBoxes.TxbApplyKeyPressEventInt(frm.txbIdPallet);

            dtCboWorkPlan = ClsQuerysDB.GetDataTable(queryCboWorkPlan);

            ClsComboBoxes.LoadComboBoxDataSource(frm.cboWorkPlan, dtCboWorkPlan);
        }
        public void BtnAddPallet()
        {
            string idPallet = ClsValues.FormatZeros(frm.txbIdPallet.Text,"00000");
            if (frm.dgvPallet.Rows.Cast<DataGridViewRow>().Any(row => row.Cells["Pallet"].Value?.ToString() == idPallet))
            {
                SystemSounds.Exclamation.Play();
                return;
            }

            DataTable dtPallet = ClsQuerysDB.GetDataTable(queryPallet + " WHERE Pallet = '" + idPallet + "' ");

            string idPlanTxb = frm.txbIdWorkPlan.Text;

            string estiba = dtPallet.Rows[0]["Estiba"].ToString();

            if (!string.IsNullOrEmpty(estiba))
            {
                SystemSounds.Exclamation.Play();

                MessageBox.Show($"El pallet pertenece a la estiba {estiba}. \n Se necesita desestibar ", "Convertir pallet", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            else
            {
                string plan = dtPallet.Rows[0]["Plan de Trabajo"].ToString();

                if (idPlanTxb.IsNullOrEmpty())
                {
                    string fecha = DateTime.Parse(dtPallet.Rows[0]["Fecha"].ToString()).ToString("yyyy-MM-dd");
                    dtPalletList = dtPallet;
                    frm.dgvPallet.DataSource = dtPallet;
                    frm.txbIdWorkPlan.Text = plan;
                    frm.txbDay.Text = fecha;
                    frm.txbWorkPlan.Text = dtCboWorkPlan.Select($"Código = '{plan}'")[0]["Nombre"].ToString();
                    ClsComboBoxes.CboSelectIndexWithTextInValueMember(frm.cboWorkPlan, plan);
                    dtCboWorkPlan.DefaultView.RowFilter = $"Fecha = '{fecha}'";

                }
                else if (plan == idPlanTxb)
                {
                    if (dtPallet.Rows.Count > 0)
                    {
                        DataRow newRow = dtPalletList.NewRow();
                        newRow.ItemArray = dtPallet.Rows[0].ItemArray;
                        dtPalletList.Rows.InsertAt(newRow, 0);
                    }
                }
                else
                {
                    SystemSounds.Exclamation.Play();

                    MessageBox.Show($"El pallet pertenece a un plan de trabajo diferente.", "Convertir pallet", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }

            frm.txbIdPallet.Focus();
            frm.txbIdPallet.SelectAll();
        }

        public void BtnQuitPallet()
        {
            if (frm.dgvPallet.SelectedRows.Count > 0)
            {
                dtPalletList.Rows.RemoveAt(frm.dgvPallet.SelectedRows[0].Index);

                if (dtPalletList.Rows.Count == 0)
                {
                    ClearFields();
                }
            }
        }

        private void ClearFields()
        {
            frm.txbIdPallet.Text = string.Empty;
            frm.txbIdWorkPlan.Text = string.Empty;
            frm.txbWorkPlan.Text = string.Empty;
            frm.txbDay.Text = string.Empty;
            dtCboWorkPlan.DefaultView.RowFilter = null;
            frm.dgvPallet.DataSource = null;
            dtPalletList = null;
        }

        public void BtnAccept()
        {
            if (frm.dgvPallet.Rows.Count > 0)
            {
                if (frm.txbIdWorkPlan.Text != frm.cboWorkPlan.SelectedValue.ToString())
                {
                    DialogResult result = MessageBox.Show("¿Está seguro de aceptar los cambios?", "Aceptar cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        UpdatePalletWorkPlan();
                        ClearFields();
                    }
                }
                else
                {
                    MessageBox.Show("Está seleccionado el mismo plan de trabajo.", "Convertir pallet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                SystemSounds.Exclamation.Play();
            }
        }

        private void UpdatePalletWorkPlan()
        {
            string userUpdate = User.GetUserName();
            string selectedWorkPlan = frm.cboWorkPlan.SelectedValue.ToString();
            try
            {
                sql.BeginTransaction();

                foreach (DataGridViewRow row in frm.dgvPallet.Rows)
                {
                    if (row.Cells["Pallet"].Value != null)
                    {
                        string pallet = row.Cells["Pallet"].Value.ToString();
                        
                        string query = $"UPDATE Pack_Pallet SET id_workPlan = '{selectedWorkPlan}', userUpdate = '{userUpdate}', d_update = CAST(GETDATE() AS DATE) WHERE id_pallet = '{pallet}'";

                        SqlCommand command = new SqlCommand(query, sql.cnn, sql.transaction);
                        command.ExecuteNonQuery();
                    }
                }
                sql.CommitTransaction();
            }
            catch (Exception ex)
            {
                sql.RollbackTransaction();
                MessageBox.Show(ex.ToString(), "Convertir pallet");
            }
        }
    }
}
