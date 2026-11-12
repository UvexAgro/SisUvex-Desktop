using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using System.Data;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.Querys;
using System.Media;
using static SisUvex.Catalogos.Metods.ClsObject;
using Microsoft.IdentityModel.Tokens;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using iText.Kernel.Pdf;

namespace SisUvex.Catalogos.Lot
{
    internal class ClsLot
    {
        private static string _columnActive2 = ClsObject.Column.active + "2";
        private static string _columnVariety = "var";
        ClsControls controlList;
        public FrmLotAdd _frmAdd;
        public FrmLotCat _frmCat;
        public ELot eLot;
        //public ClsDataGridViewCatalogs dgv = new ClsDataGridViewCatalogs();
        private string QueryCatalogo => $@" SELECT cat.[{Column.active}] AS [{_columnActive2}], cat.*, lot.id_farm AS [{Farm.ColumnId}] FROM vw_PackLotCat cat LEFT JOIN Pack_Lot lot ON lot.id_lot = cat.[{Column.id}] AND lot.id_variety = cat.[{_columnVariety}] LEFT JOIN Grow_Farm farm ON farm.id_farm = lot.id_farm ";

        public DataView _dvCatalogo;

        public void BeginFormCat()
        {
            _dvCatalogo = new DataView(ClsQuerysDB.GetDataTable(QueryCatalogo));
            _dvCatalogo.RowFilter = $"{_columnActive2} = '1'";
            _frmCat.dgvCatalog.DataSource = _dvCatalogo;
            _frmCat.dgvCatalog.Columns[_columnActive2].Visible = false;
            _frmCat.dgvCatalog.Columns[_columnVariety].Visible = false;

            if (_frmCat.dgvCatalog.Columns.Contains(Farm.ColumnId))
                _frmCat.dgvCatalog.Columns[Farm.ColumnId].Visible = false;

            ClsDGVCatalog.DgvApplyCellFormattingEvent(_frmCat.dgvCatalog);

            ClsComboBoxes.CboLoadActives(_frmCat.cboVariety, ClsObject.Variety.Cbo);
            ClsComboBoxes.CboApplyClickEvent(_frmCat.cboVariety, _frmCat.chbRemovedVariety);
            _frmCat.cboVariety.SelectedIndexChanged += (_, _) => SetFilterCatalog();

            ClsComboBoxes.CboLoadAll(_frmCat.cboFarm, Farm.Cbo);
            _frmCat.cboFarm.SelectedIndexChanged += (_, _) => SetFilterCatalog();
        }

        private void ProcedureRemoveRecover(bool active)
        {
            if (_frmCat.dgvCatalog.Rows.Count == 0 || _frmCat.dgvCatalog.SelectedRows.Count == 0)
                return;

            string idLot = _frmCat.dgvCatalog.SelectedRows[0].Cells[ClsObject.Column.id].Value.ToString()!;
            string idVariety = _frmCat.dgvCatalog.SelectedRows[0].Cells[_columnVariety].Value.ToString()!;

            bool ok = ELot.ActiveProcedure(idLot, idVariety, active ? "1" : "0");
            if (ok)
                _frmCat.dgvCatalog.SelectedRows[0].Cells[ClsObject.Column.active].Value = active ? "1" : "0";
        }

        public void BtnRecover()
        {
            ProcedureRemoveRecover(true);
        }

        public void BtnRemove()
        {
            ProcedureRemoveRecover(false);
        }

        public void BtnRemoved()
        {
            SetFilterCatalog();
        }

        public void SetFilterCatalog()
        {
            foreach (DataRowView rowView in _dvCatalogo)
                rowView[_columnActive2] = rowView[Column.active];

            List<string> filters = new();

            if (!_frmCat.chbRemoved.Checked)
                filters.Add($"[{_columnActive2}] = '1'");

            if (_frmCat.cboVariety.TryGetValue(out string varietyValue))
                filters.Add($"{_columnVariety} = '{varietyValue.Replace("'", "''")}'");

            if (_frmCat.cboFarm.TryGetValue(out string farmValue)
                && _dvCatalogo.Table != null
                && _dvCatalogo.Table.Columns.Contains(Farm.ColumnId))
            {
                filters.Add($"[{Farm.ColumnId}] = '{farmValue.Replace("'", "''")}'");
            }

            _dvCatalogo.RowFilter = filters.Count > 0 ? string.Join(" AND ", filters) : string.Empty;
        }

        public void OpenFrmAdd()
        {
            _frmAdd = new FrmLotAdd();
            _frmAdd.cls = this;
            _frmAdd.Text = "Añadir lote";
            _frmAdd.lblTitle.Text = "Añadir lote";
            _frmAdd.IsAddModify = true;

            _frmAdd.ShowDialog();
        }
        public void BeginFormAdd()
        {
            AddControlsToList();

            CargarComboBoxes();

            if (_frmAdd.IsAddModify)
            {
                _frmAdd.chbActive.Checked = true;
                _frmAdd.spnId.Text = ClsQuerysDB.GetData("SELECT FORMAT( (SELECT MIN(t1.id_lot + 1) FROM Pack_Lot t1 WHERE NOT EXISTS ( SELECT 1 FROM Pack_Lot t2 WHERE t2.id_lot = t1.id_lot + 1 ) ), '0000' ) AS 'Id'").ToString();
            }
            else
            {
                _frmAdd.spnId.Enabled = false;

                _frmAdd.txbIdVariety.Enabled = false;
                _frmAdd.cboVariety.Enabled = false;
                _frmAdd.chbActiveVariety.Enabled = false;
                _frmAdd.btnSearchVariety.Enabled = false;

                LoadControlsModify();
            }
        }

        private void AddControlsToList()
        {
            controlList = new ClsControls();

            controlList.ChangeHeadMessage("Para dar de alta una cuadrilla debe:\n");
            controlList.Add(_frmAdd.spnId, "Ingresar el código de lote de 4 números.");
            controlList.Add(_frmAdd.txbName, "Ingrese el nombre del lote");
            controlList.Add(_frmAdd.txbIdVariety, "Seleccionar una variedad.");
            controlList.Add(_frmAdd.txbIdFarm, "Seleccionar un campo.");
            controlList.Add(_frmAdd.nudHa, "Ingresar las hectáreas.");
            controlList.Add(_frmAdd.dtpDate, "Seleccionar una fecha.");
        }

        private void CargarComboBoxes()
        {
            ClsComboBoxes.CboLoadActives(_frmAdd.cboVariety, ClsObject.Variety.Cbo);
            ClsComboBoxes.CboLoadAll(_frmAdd.cboFarm, ClsObject.Farm.Cbo);
            ELot.LoadRowAxisCombo(_frmAdd.cboRowAxis);

            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboVariety, _frmAdd.txbIdVariety);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboFarm, _frmAdd.txbIdFarm);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboRowAxis, _frmAdd.txbIdRowAxis);

            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboVariety, _frmAdd.chbActiveVariety);
        }

        public void OpenFrmModify()
        {
            if (_frmCat.dgvCatalog.SelectedRows.Count != 0)
            {
                _frmAdd = new FrmLotAdd();
                _frmAdd.cls = this;
                _frmAdd.Text = "Modificar lote";
                _frmAdd.lblTitle.Text = "Modificar lote";
                _frmAdd.IsAddModify = false;

                _frmAdd.idLotModify = _frmCat.dgvCatalog.SelectedRows[0].Cells[ClsObject.Column.id].Value.ToString();
                _frmAdd.idVarietyModify = _frmCat.dgvCatalog.SelectedRows[0].Cells[_columnVariety].Value.ToString();

                _frmAdd.ShowDialog();
            }
            else
            {
                SystemSounds.Exclamation.Play();
            }
        }

        private void LoadControlsModify()
        {
            eLot = new ELot();
            eLot.SetLot(_frmAdd.idLotModify, _frmAdd.idVarietyModify);

            _frmAdd.spnId.Text = eLot.idLot;
            _frmAdd.txbName.Text = eLot.nameLot;
            _frmAdd.nudHa.Value = eLot.ha;
            _frmAdd.chbActive.Checked = eLot.active == 1;
            _frmAdd.dtpDate.Value = eLot.date;

            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboVariety, eLot.idVariety);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboFarm, eLot.idFarm);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboRowAxis, eLot.rowAxis);
        }

        private ELot SetEntity()
        {
            eLot = new ELot();
            eLot.idLot = _frmAdd.spnId.Text.Trim();
            eLot.idVariety = _frmAdd.txbIdVariety.Text.Trim();
            eLot.nameLot = _frmAdd.txbName.Text.Trim();
            eLot.ha = _frmAdd.nudHa.Value;
            eLot.date = _frmAdd.dtpDate.Value;
            eLot.active = _frmAdd.chbActive.Checked ? 1 : 0;
            eLot.idFarm = _frmAdd.txbIdFarm.Text.Trim();
            eLot.rowAxis = _frmAdd.cboRowAxis.ComboValueOrNull();
            return eLot;
        }

        public void btnSearchNameWithIdLot()
        {
            string qryName = " SELECT TOP (1) v_nameLot FROM Pack_Lot WHERE id_lot = @idLot ";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@idLot", _frmAdd.spnId.Text },
            };

            DataTable dt = ClsQuerysDB.ExecuteParameterizedQuery(qryName, parameters);

            if (dt.Rows.Count > 0)
                _frmAdd.txbName.Text = dt.Rows[0][0].ToString();
            else
                SystemSounds.Exclamation.Play();
        }

        public void btnAcceptAddModify()
        {
            if (!controlList.ValidateControls())
                return;

            if (_frmAdd.IsAddModify)
            {
                if (!IsLotDisponible())
                {
                    MessageBox.Show("El lote con esa variedad ya existe", "Catálogo añadir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                AddProcedure();
            }
            else
            {
                ModifyProcedure();
            }

            if (_frmAdd.AddIsUpdate)
            {
                InsertLotInDGV();
                _frmAdd.Close();
            }
        }

        public bool IsLotDisponible()
        {
            string qryName = " SELECT COUNT(id_lot) 'Id' FROM Pack_Lot WHERE id_lot = @idLot AND id_variety  = @idVariety ";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@idLot", _frmAdd.spnId.Text },
                { "@idVariety", _frmAdd.txbIdVariety.Text }
            };

            string count = ClsQuerysDB.GetStringExecuteParameterizedQuery(qryName, parameters);

            int.TryParse(count, out int result);

            if (result > 0)
                return false;
            else
                return true;
        }

        public void AddProcedure()
        {
            ELot addEntity = SetEntity();
            var result = addEntity.AddProcedure();
            _frmAdd.AddIsUpdate = result.success;

            if (result.success)
                MessageBox.Show("Se añadió el lote: " + _frmAdd.spnId.Text + "\n con variedad: " + _frmAdd.txbIdVariety.Text, "Catálogo añadir", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ModifyProcedure()
        {
            ELot modifyEntity = SetEntity();
            var result = modifyEntity.ModifyProcedure();
            _frmAdd.AddIsUpdate = result.success;

            if (result.success)
                MessageBox.Show("Se modificó el lote: " + _frmAdd.spnId.Text + "\n con variedad: " + _frmAdd.txbIdVariety.Text, "Catálogo modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InsertLotInDGV()
        {
            string qry = $"{QueryCatalogo} WHERE cat.[{Column.id}] = @idLot AND cat.[{_columnVariety}] = @idVariety";

            Dictionary<string, object> parameters = new()
            {
                { "@idLot", _frmAdd.spnId.Text },
                { "@idVariety", _frmAdd.txbIdVariety.Text }
            };

            DataTable dt = ClsQuerysDB.ExecuteParameterizedQuery(qry, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                DataRowView drv = null;
                bool found = false;

                // Buscar si la fila ya existe en el DataView (_dvCatalog)
                foreach (DataRowView rowView in _dvCatalogo)
                {
                    if (rowView[ClsObject.Column.id].ToString() == dr[ClsObject.Column.id].ToString() &&
                        rowView[_columnVariety].ToString() == dr[_columnVariety].ToString())
                    {
                        drv = rowView;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    // Si no se encuentra, agregar una nueva fila al DataView
                    drv = _dvCatalogo.AddNew();
                }

                if (drv != null)
                {
                    for (int i = 0; i < dr.ItemArray.Length; i++)
                    {
                        drv[i] = dr[i]; // Copiar valores de DataRow a DataRowView
                    }

                    drv.EndEdit();
                }

                SelectLotRow(dr[ClsObject.Column.id].ToString(), dr[_columnVariety].ToString());
            }
        }

        private void SelectLotRow(string? idLot, string? idVariety)
        {
            DataGridView dgv = _frmCat.dgvCatalog;
            if (dgv.Rows.Count == 0 || string.IsNullOrEmpty(idLot))
                return;

            foreach (DataGridViewRow dgvRow in dgv.Rows)
            {
                if (dgvRow.Cells[ClsObject.Column.id].Value?.ToString() != idLot)
                    continue;
                if (dgvRow.Cells[_columnVariety].Value?.ToString() != idVariety)
                    continue;

                DataGridViewCell? visibleCell = dgvRow.Cells.Cast<DataGridViewCell>().FirstOrDefault(c => c.Visible);
                if (visibleCell == null)
                    return;

                dgv.CurrentCell = visibleCell;
                dgvRow.Selected = true;
                dgv.FirstDisplayedScrollingRowIndex = dgvRow.Index;
                return;
            }
        }


    }
}
