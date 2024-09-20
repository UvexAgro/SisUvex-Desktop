using SisUvex.Catalogos.Metods;
using System.Data;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Querys;
using static SisUvex.Catalogos.Metods.ClsObject;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlClient;
using System.Media;
using System.Windows.Forms;

namespace SisUvex.Archivo.WorkPlan
{
    internal class ClsWorkPlanEventsControls
    {
        public ClsWorkPlan clsWP; 
        private SQLControl sql = new SQLControl();
        string queryCatalog = ClsObject.WorkPlan.QueryDgvCatalog;
        public void SetCboFilterLots()
        {
            DataTable dt = clsWP._frmAdd.cboLot.DataSource as DataTable;
            bool IschbLotChecked = clsWP._frmAdd.chbLotActives.Checked;
            string idVariety = clsWP._frmAdd.txbIdVariety.Text;
            string? filter = null;

            clsWP._frmAdd.cboLot.SelectedIndex = 0;

            if (!IschbLotChecked)
                filter = $"{Column.active} = '1'";

            if (idVariety != string.Empty)
            {
                if (!IschbLotChecked)
                    filter += $" AND ";

                filter += $"{Variety.ColumnId} = '{idVariety}' OR {Column.name} = '{ClsComboBoxes.textSelect}'";
            }

            dt.DefaultView.RowFilter = filter;

            clsWP._frmAdd.cboLot.DataSource = dt;

            ClsComboBoxes.CboSelectIndexWithTextInValueMember(clsWP._frmAdd.cboLot, clsWP._frmAdd.txbIdLot);
        }
        public void CboApplyClickEventChbLotInWorkPlanForLot(ComboBox comboBox, CheckBox checkBox)
        {
            checkBox.Click += (sender, e) =>
            {
                DataTable dt = (DataTable)comboBox.DataSource;

                if (checkBox.Checked)
                {
                    dt.DefaultView.RowFilter = null;
                }
                else
                {
                    dt.DefaultView.RowFilter = $"{Column.active} = '1'";
                }

                comboBox.DataSource = dt;

                SetCboFilterLots();

                comboBox.SelectedIndex = 0;
                comboBox.DroppedDown = true;
            };
        }
        public void CboApplyClickEventChbGtinActivesForDgv(CheckBox checkBoxGtin)
        {
            checkBoxGtin.Click += (sender, e) =>
            {
                SetDgvFilterGTIN();
            };
        }
        public void CboApplyValueChangedEventDateTimePicker(DateTimePicker dateTimePicker)
        {
            dateTimePicker.ValueChanged += (sender, e) =>
            {
                clsWP.GenerarVoicePickCode();
            };
        }
        public void CboApplyTextChangedEventInWorkPlanForVariety(ComboBox comboBox, TextBox textBox)
        {
            comboBox.TextChanged += (sender, e) =>
            {
                textBox.Text = comboBox.SelectedValue?.ToString();

                // Apply filter to the DataTable
                SetCboFilterLots();

                if (!clsWP.IsIdGtinInDgv())
                {
                    clsWP._frmAdd.txbIdGTIN.Text = string.Empty;
                }
            };
        }
        public void CboApplyTextChangedEventInWorkPlanForLot(ComboBox comboBox, TextBox textBox)
        {
            comboBox.TextChanged += (sender, e) =>
            {
                textBox.Text = comboBox.SelectedValue?.ToString();

                SetDgvFilterGTIN();

                if (clsWP.IsIdGtinInDgv())
                    GenerarVoicePickCode();
                else
                {
                    clsWP._frmAdd.txbVPC.Text = string.Empty;
                    clsWP._frmAdd.txbIdGTIN.Text = string.Empty;
                }
            };
        }
        public void CboApplyTextChangedEventInWorkPlanForDistributor(ComboBox comboBox, TextBox textBox)
        {
            comboBox.TextChanged += (sender, e) =>
            {
                textBox.Text = comboBox.SelectedValue?.ToString();

                SetDgvFilterGTIN();

                if (clsWP.IsIdGtinInDgv())
                    GenerarVoicePickCode();
                else
                {
                    clsWP._frmAdd.txbVPC.Text = string.Empty;
                    clsWP._frmAdd.txbIdGTIN.Text = string.Empty;
                }
            };
        }
        public void SetDgvFilterGTIN()
        {
            DataTable dt = clsWP._frmAdd.dgvGTIN.DataSource as DataTable;
            bool IsChbGTINChecked = clsWP._frmAdd.chbGtinActives.Checked;
            string? filter = null;
            string idVariety = string.Empty;
            string idDistributor = clsWP._frmAdd.txbIdDistributor.Text;

            if (clsWP._frmAdd.txbIdLot.Text.Length > 0)
                idVariety = clsWP._frmAdd.txbIdLot.Text.Substring(5, 2);

            if (!IsChbGTINChecked)
                filter = $"{Gtin.ColumnActive} = '1'";

            if (!idVariety.IsNullOrEmpty())
            {
                if (!filter.IsNullOrEmpty())
                    filter += $" AND ";

                filter += $"{Variety.ColumnId} = '{idVariety}'";
            }

            if (!idDistributor.IsNullOrEmpty())
            {
                if (!filter.IsNullOrEmpty())
                    filter += $" AND ";

                filter += $"{Distributor.ColumnId} = '{idDistributor}'";
            }

            dt.DefaultView.RowFilter = filter;
            clsWP._frmAdd.dgvGTIN.DataSource = dt;
        }
        public void SetDgvFilterGTINBeginModify()
        {
            if (!IsIdGtinInDgv())
            {
                DataTable dt = clsWP._frmAdd.dgvGTIN.DataSource as DataTable;
                string? filter = dt.DefaultView.RowFilter;

                if (!filter.IsNullOrEmpty())
                    filter += $" OR ";

                filter += $"{Gtin.ColumnId} = '{clsWP._frmAdd.txbIdGTIN.Text}'";

                dt.DefaultView.RowFilter = filter;
                clsWP._frmAdd.dgvGTIN.DataSource = dt;
            }
        }

        public void GenerarVoicePickCode()
        {
            string idGTIN = clsWP._frmAdd.txbIdGTIN.Text;
            DateTime fecha = clsWP._frmAdd.dtpDateWorkPlan.Value;
            string VPC = string.Empty;
            string idLote = string.Empty;

            if (clsWP._frmAdd.txbIdLot.Text.Length >= 4)
                idLote = clsWP._frmAdd.txbIdLot.Text.Substring(0, 4);

            if (idGTIN.Length == 5 && idLote.Length == 4 && fecha > new DateTime(2000, 1, 1))
            {
                string GTIN = ClsQuerysDB.GetData($"SELECT v_GTIN FROM Pack_GTIN WHERE id_GTIN = '{idGTIN}'");

                if (GTIN != string.Empty)
                    VPC = ClsVoicePickCode.Calculator(GTIN, idLote, fecha);
            }

            clsWP._frmAdd.txbVPC.Text = VPC;
        }
        public bool IsIdGtinInDgv()
        {
            foreach (DataGridViewRow row in clsWP._frmAdd.dgvGTIN.Rows)
            {
                if (row.Cells[Column.id].Value?.ToString() == clsWP._frmAdd.txbIdGTIN.Text)
                    return true;
            }

            return false;
        }
        public static void DgvLoadActives(DataGridView dataGridView, string tableNameDB)
        {
            DataTable dt = ClsComboBoxFiles.GetCboCatalogDataTable(tableNameDB);
            dt.DefaultView.RowFilter = $"{Gtin.ColumnActive} = '1'";

            LoadDataGridView(dataGridView, dt);
        }
        private static void LoadDataGridView(DataGridView dataGridView, DataTable dt)
        {
            dataGridView.DataSource = dt;

            List<string> hiddenColumns = new List<string>()
            {
                Gtin.ColumnActive,
                Gtin.ColumnId,
                Variety.ColumnId,
                Presentation.ColumnId,
                Container.ColumnId,
                Price.ColumnId,
                Pti.ColumnId,
                Distributor.ColumnId
            };

            foreach (string column in hiddenColumns)
            {
                if (dt.Columns.Contains(column))
                {
                    dataGridView.Columns[column].Visible = false;
                }
            }
        }

        ////// cargar catalogo de plan de trabajo
        public void LoadDataGridViewCatalog()
        {
            string query = queryCatalog + $" WHERE w.d_workDay BETWEEN '{clsWP._frmCat.dtpDate1.Value.ToString("yyyy-MM-dd")}' AND '{clsWP._frmCat.dtpDate2.Value.ToString("yyyy-MM-dd")}' ";

            //en los filtros: GTIN Porque la tabla tiene como columna GTIN y Cuadrilla por el workGroup solo tiene el numero y no todo el nombre completo

            if (clsWP._frmCat.cboDistribuidor.SelectedIndex > 0)
                query += $" AND '{clsWP._frmCat.cboDistribuidor.SelectedValue}' IN (SELECT gtn.id_distributor FROM gtn WHERE gtn.id_GTIN = GTIN) ";

            if (clsWP._frmCat.cboPresentacion.SelectedIndex > 0)
                query += $" AND '{clsWP._frmCat.cboPresentacion.SelectedValue}' IN (SELECT gtn.id_presentation FROM gtn WHERE gtn.id_GTIN = GTIN) ";

            if (clsWP._frmCat.cboVariety.SelectedIndex > 0)
                query += $" AND '{clsWP._frmCat.cboVariety.SelectedValue}' IN (SELECT gtn.id_variety FROM gtn WHERE gtn.id_GTIN = GTIN) ";

            if (clsWP._frmCat.cboContainer.SelectedIndex > 0)
                query += $" AND '{clsWP._frmCat.cboContainer.SelectedValue}' IN (SELECT gtn.id_container FROM gtn WHERE gtn.id_GTIN = GTIN) ";

            if (clsWP._frmCat.cboWorkGroup.SelectedIndex > 0)
                query += $" AND '{clsWP._frmCat.cboWorkGroup.SelectedValue}' IN (SELECT wgp.id_workGroup FROM wgp WHERE wgp.id_workGroup = Cuadrilla) ";

            if (clsWP._frmCat.cboLot.SelectedIndex > 0 && clsWP._frmCat.cboLot.SelectedValue.ToString().Length == 7)
                query += $" AND '{clsWP._frmCat.cboLot.SelectedValue.ToString().Substring(0, 4)}' IN (SELECT lot.id_lot FROM lot WHERE lot.id_lot = w.id_lot) AND '{clsWP._frmCat.cboLot.SelectedValue.ToString().Substring(7 - 2)}' IN (SELECT gtn.id_variety FROM gtn WHERE gtn.id_GTIN = GTIN) ";
            
            //Clipboard.SetText(query); //Copiar la query en el portapapeles

            clsWP.dtCatalog = ClsQuerysDB.GetDataTable(query);

            clsWP._frmCat.dgvCatalog.DataSource = clsWP.dtCatalog;

            if (!clsWP._frmCat.chbRemoved.Checked)
                clsWP.dtCatalog.DefaultView.RowFilter = $" {ClsObject.WorkPlan.ColumnActive} = '1' ";

            List<string> hiddenColumns = new List<string>()
            {
                ClsObject.WorkPlan.ColumnId,
                ClsObject.WorkPlan.ColumnActive,
                ClsObject.WorkPlan.ColumnDate
            };

            foreach (string column in hiddenColumns)
            {
                if (clsWP.dtCatalog.Columns.Contains(column))
                {
                    clsWP._frmCat.dgvCatalog.Columns[column].Visible = false;
                }
            }
        }

        public void ChbRemovedChecked()
        {
            if (clsWP._frmCat.chbRemoved.Checked)
                clsWP.dtCatalog.DefaultView.RowFilter = null;
            else
                clsWP.dtCatalog.DefaultView.RowFilter = $" {ClsObject.Column.active} = '1' ";
        }

        public bool IsActive()
        {
            if (clsWP._frmCat.dgvCatalog.SelectedRows.Count > 0)
            {
                return "1" == clsWP._frmCat.dgvCatalog.SelectedRows[0].Cells[ClsObject.Column.active].Value.ToString();
            }
            return false;
        }
        public void ProcedureRemove(string procedureName)
        {
            if (clsWP._frmCat.dgvCatalog.SelectedRows.Count > 0)
            {
                if (IsActive())
                {
                    string id = clsWP._frmCat.dgvCatalog.SelectedRows[0].Cells[ClsObject.Column.id].Value.ToString();

                    try
                    {
                        sql.OpenConectionWrite();
                        SqlCommand cmd = new SqlCommand(procedureName, sql.cnn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());

                        cmd.ExecuteNonQuery();

                        clsWP._frmCat.dgvCatalog.SelectedRows[0].Cells[ClsObject.Column.active].Value = "0";

                        DeleteInDataTable(id);
                    }
                    catch (Exception ex)
                    {
                        SystemSounds.Exclamation.Play();
                        MessageBox.Show(ex.ToString(), "Catálogo eliminar");
                    }
                    finally
                    {
                        sql.CloseConectionWrite();
                    }
                }
            }
            else
                SystemSounds.Exclamation.Play();
        }
        public void ProcedureRecover(string procedureName)
        {
            if (clsWP._frmCat.dgvCatalog.SelectedRows.Count > 0)
            {
                if (!IsActive())
                {
                    string id = clsWP._frmCat.dgvCatalog.SelectedRows[0].Cells[ClsObject.Column.id].Value.ToString();

                    try
                    {
                        sql.OpenConectionWrite();
                        SqlCommand cmd = new SqlCommand(procedureName, sql.cnn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());

                        cmd.ExecuteNonQuery();

                        clsWP._frmCat.dgvCatalog.SelectedRows[0].Cells[ClsObject.Column.active].Value = "1";

                        RecoverInDataTable(id);
                    }
                    catch (Exception ex)
                    {
                        SystemSounds.Exclamation.Play();
                        MessageBox.Show(ex.ToString(), "Catálogo recuperar");
                    }
                    finally
                    {
                        sql.CloseConectionWrite();
                    }
                }
            }
            else
                SystemSounds.Exclamation.Play();
        }
        public void DeleteInDataTable(string id)
        {
            foreach (DataGridViewRow row in clsWP._frmCat.dgvCatalog.Rows)
            {
                if (row.Cells[ClsObject.WorkPlan.ColumnId].Value?.ToString() == id)
                {
                    row.Cells[Column.active].Value = "0";
                    break;
                }
            }
        }
        public void RecoverInDataTable(string id)
        {
            foreach (DataGridViewRow row in clsWP._frmCat.dgvCatalog.Rows)
            {
                if (row.Cells[ClsObject.WorkPlan.ColumnId].Value?.ToString() == id)
                {
                    row.Cells[Column.active].Value = "1";
                    break;
                }
            }
        }
    }
}
