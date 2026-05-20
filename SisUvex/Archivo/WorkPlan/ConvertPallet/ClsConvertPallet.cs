using Microsoft.IdentityModel.Tokens;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.TextBoxes;
using SisUvex.Catalogos.Metods.Values;
using SisUvex.Nomina.Conceptos_Ingresos_Diversos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Archivo.WorkPlan.ConvertPallet
{
    internal class ClsConvertPallet
    {
        SQLControl sql = new SQLControl();
        public FrmConvertPallet frm;
        DataTable? dtCboWorkPlan = null;
        DataTable? dtPalletList = null;
        string queryCboWorkPlan = $" SELECT [Activo], [Código], CONCAT_WS(' ', Código, '|', 'Cuadrilla:',Cuadrilla, '|'+dis.v_nameDistShort, Lote, Variedad, Tamaño, CONCAT(Contenedor, CAST(Libras AS float)),[Pre etiqueta], Presentación, [Post etiqueta]) AS [Nombre], Fecha AS [Fecha], gtn.id_distributor AS [{ClsObject.Distributor.ColumnId}], wpl.id_lot AS [{ClsObject.Lot.ColumnId}],gtn.id_variety AS [{ClsObject.Variety.ColumnId}], gtn.id_presentation AS [{ClsObject.Presentation.ColumnId}], gtn.id_container  AS [{ClsObject.Container.ColumnId}] FROM vw_PackWorkPlanCat cat JOIN Pack_WorkPlan wpl ON wpl.id_workPlan = cat.Código  JOIN Pack_GTIN gtn ON gtn.id_GTIN = cat.GTIN join Pack_Distributor dis ON dis.id_distributor = gtn.id_distributor WHERE [Activo] = '1' ";
        string queryPallet = " SELECT * FROM vw_PackPalletCon ";

        public ClsConvertPallet()
        {
            frm = new FrmConvertPallet();
            frm.cls = this;
        }
        public void BeginForm()
        {
            ClsComboBoxes.CboLoadActives(frm.cboSeason, Season.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboDistribuidor, ClsObject.Distributor.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboPresentacion, Presentation.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboVariety, Variety.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboContainer, Container.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboWorkGroup, WorkGroup.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboLot, Lot.Cbo);

            List<(ComboBox Cbo, string IdColumnFilter)> lsWGDep = new();
            lsWGDep.Add((frm.cboSeason, Season.ColumnId));
            ClsComboBoxes.Events.CboApplyEventFilterAllForOne(frm.cboWorkGroup, null, lsWGDep);

            List<(ComboBox Cbo, string IdColumnFilter)> lsLotDep = new();
            lsLotDep.Add((frm.cboVariety, Variety.ColumnId));
            ClsComboBoxes.Events.CboApplyEventFilterAllForOne(frm.cboLot, null, lsLotDep);

            ClsTextBoxes.TxbApplyKeyPressEventInt(frm.txbIdPallet);

            dtCboWorkPlan = ClsQuerysDB.GetDataTable(queryCboWorkPlan);

            ClsComboBoxes.CboSelectIndexWithTextInValueMember(frm.cboSeason, "08"); //<-- Seleccionar temporada actual (luego filtrar plan de trabajo por fechas de temporada)

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

            if (dtPallet.Rows.Count < 1)
            {
                SystemSounds.Exclamation.Play();
                return;
            }

            string idPlanTxb = frm.txbIdWorkPlan.Text;

            string estiba = dtPallet.Rows[0]["Estiba"].ToString();

            //if (!string.IsNullOrEmpty(estiba))
            //{
            //    SystemSounds.Exclamation.Play();

            //    MessageBox.Show($"El pallet pertenece a la estiba {estiba}. \n Se necesita desestibar ", "Convertir pallet", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //    return;
            //}
            //else
            //{
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
            //}

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
            try
            {
                string userUpdate = User.GetUserName();
                string selectedWorkPlan = frm.cboWorkPlan.SelectedValue.ToString();

                sql.BeginTransaction();

                SqlCommand cmd = new SqlCommand("sp_PackPalletConvert", sql.cnn, sql.transaction);
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (DataGridViewRow row in frm.dgvPallet.Rows)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@idPallet", row.Cells["Pallet"].Value.ToString());
                    cmd.Parameters.AddWithValue("@idWorkPlanNew", selectedWorkPlan);
                    cmd.Parameters.AddWithValue("@user", userUpdate);

                    cmd.ExecuteNonQuery();
                }

                sql.CommitTransaction();
            }
            catch (Exception ex)
            {
                sql.RollbackTransaction();
                MessageBox.Show(ex.ToString(), "Error al añadir materiales de salida");
            }
        }
    }
}
