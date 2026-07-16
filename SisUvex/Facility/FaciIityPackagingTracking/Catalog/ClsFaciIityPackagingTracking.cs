using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Querys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Facility.FaciIityPackagingTracking.Catalog
{
    internal class ClsFaciIityPackagingTracking
    {
        ClsControls controlList = null!;
        public FrmFaciIityPackagingTrackingAdd _frmAdd = null!;
        public FrmFaciIityPackagingTrackingCat _frmCat = null!;
        public EFaciIityPackagingTracking entity = null!;

        // Catálogo (vista: 1 fila por id_facilityPackaging con columnas Color1..ColorN)
        private readonly string queryCatalog = $" SELECT cat.* FROM vw_PackFacilityPackagingRatioCat cat ";

        // Colores disponibles para el flp (toggle + textbox)
        public readonly string queryColorAdd = $" SELECT col.id_color AS [{Column.id}], col.v_nameColor AS [{ClsObject.Color.ColumnName}] FROM Pack_Color col ORDER BY col.id_color ";

        ClsDGVCatalog? dgv;
        DataTable dtCatalog = null!;

        public bool IsAddOrModify = true;
        public bool IsAddUpdate;
        public bool IsModifyUpdate;
        public string? idAddModify;

        private string? GetSelectedIdFromCatalog()
        {
            if (_frmCat?.dgvCatalog == null || _frmCat.dgvCatalog.CurrentRow == null)
                return null;
            if (!_frmCat.dgvCatalog.Columns.Contains(Column.id))
                return null;
            return _frmCat.dgvCatalog.CurrentRow.Cells[Column.id].Value?.ToString();
        }

        public void BeginFormCat()
        {
            _frmCat ??= new();
            _frmCat.cls ??= this;

            dtCatalog = ClsQuerysDB.GetDataTable(queryCatalog + " WHERE 1 = 1 ");
            dgv = new ClsDGVCatalog(_frmCat.dgvCatalog, dtCatalog);

            ChbRemovedFilter();
        }

        public void OpenFrmAdd()
        {
            IsAddOrModify = true;
            IsAddUpdate = false;
            idAddModify = null;
            _frmAdd = new();
            _frmAdd.cls = this;
            _frmAdd.Text = "Añadir relación tipo de empaque";
            _frmAdd.lblTitle.Text = "Añadir relación de tipo de empaque";
            _frmAdd.ShowDialog();
        }

        public void OpenFrmModify(string? idModify)
        {
            IsAddOrModify = false;
            IsModifyUpdate = false;
            if (string.IsNullOrEmpty(idModify))
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se ha seleccionado un registro para modificar.", "Modificar relación tipo de empaque");
                return;
            }

            idAddModify = idModify;
            _frmAdd = new();
            _frmAdd.cls = this;
            _frmAdd.Text = "Modificar relación tipo de empaque";
            _frmAdd.lblTitle.Text = "Modificar relación de tipo de empaque";
            _frmAdd.ShowDialog();
        }

        public void BeginFormAdd()
        {
            AddControlsToList();

            if (IsAddOrModify)
            {
                _frmAdd.cboActive.SelectedIndex = 1;
                _frmAdd.txbId.Text = EFaciIityPackagingTracking.GetNextId();
            }
            else
            {
                LoadControlsModify();
            }
        }

        private void AddControlsToList()
        {
            controlList = new ClsControls();
            controlList.ChangeHeadMessage("Para dar de alta una relación de tipo de empaque debe:\n");
            controlList.Add(_frmAdd.txbId, "Ingresar el código.");
            controlList.Add(_frmAdd.txbName, "Ingresar el nombre.");
        }

        private void LoadControlsModify()
        {
            entity = new();
            entity.GetFacilityPackaging(idAddModify);

            _frmAdd.txbId.Text = entity.idFacilityPackaging;
            _frmAdd.txbName.Text = entity.facPackagingName;
            _frmAdd.cboActive.SelectedIndex = entity.active;

            ApplySelectedColorsToForm(entity.lsColors);
        }
        private bool IsAnyColorSelected()
        {
            List<(string id, decimal value)> selectedColors = _frmAdd.GetSelectedWithValues();

            // 🔹 1. Que haya al menos uno
            if (selectedColors == null || selectedColors.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un color y su proporción.", "Añadir relación tipo de empaque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 🔹 2 y 3. Validar contenido
            bool isValid = selectedColors != null && selectedColors.Count > 0 && selectedColors.All(x => !string.IsNullOrWhiteSpace(x.id) && x.value > 0 );
            if (!isValid)
            {
                MessageBox.Show("Debe ingresar una proporción válida mayor a 0.", "Añadir relación tipo de empaque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void ApplySelectedColorsToForm(List<(string idColor, decimal ratio)>? selected)
        {
            if (selected == null || _frmAdd == null)
                return;

            var dict = selected.ToDictionary(x => x.idColor, x => x.ratio);

            foreach (Panel pnl in _frmAdd.ColorsPanels())
            {
                var toggle = pnl.Controls.OfType<SisUvex.Cuadro_de_herramientas.ToggleButton>().FirstOrDefault();
                var txt = pnl.Controls.OfType<TextBox>().FirstOrDefault();
                if (toggle == null || txt == null)
                    continue;

                string? id = toggle.Tag?.ToString();
                if (id != null && dict.TryGetValue(id, out decimal ratio))
                {
                    toggle.Checked = true;
                    txt.Text = ratio.ToString();
                }
            }
        }

        private EFaciIityPackagingTracking SetEntityFromForm()
        {
            entity = new();
            entity.idFacilityPackaging = _frmAdd.txbId.Text?.Trim();
            entity.facPackagingName = _frmAdd.txbName.Text?.Trim();
            entity.active = _frmAdd.cboActive.SelectedIndex;
            entity.lsColors = _frmAdd.GetSelectedWithValues();
            return entity;
        }

        public void AddProcedure()
        {
            var addEntity = SetEntityFromForm();
            var result = addEntity.AddProcedure();
            IsAddUpdate = result.ok;
            idAddModify = result.id;
        }

        public void ModifyProcedure()
        {
            var modifyEntity = SetEntityFromForm();
            var result = modifyEntity.ModifyProcedure();
            IsModifyUpdate = result.ok;
            idAddModify = result.id;
        }

        public void BtnAccept()
        {
            if (!controlList.ValidateControls())
                return;

            if (!IsAnyColorSelected())
                return;

            if (IsAddOrModify)
            {
                AddProcedure();
                if (IsAddUpdate)
                {
                    _frmAdd.txbId.Text = idAddModify;
                    MessageBox.Show($"Se ha agregado el registro con código: {idAddModify}", "Añadir relación tipo de empaque");
                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo agregar el registro.", "Añadir relación tipo de empaque");
                }
            }
            else
            {
                ModifyProcedure();
                if (IsModifyUpdate)
                {
                    MessageBox.Show($"Se ha modificado el registro con el código: {idAddModify}", "Modificar relación tipo de empaque");
                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo modificar el registro.", "Modificar relación tipo de empaque");
                }
            }
        }
        public void ChbRemovedFilter()
        {
            if (dgv == null)
                return;

            if (!_frmCat.chbRemoved.Checked)
            {
                dgv.CopyActiveValuesToHiddenColumn();

                dgv.SetFilterActivesOnly();
            }
            else
            {
                dgv.SetFilterNull();
            }

        }
        public void BtnActiveProcedure(string id, string activeValue)
        {
            bool result = EFaciIityPackagingTracking.ActiveProcedure(id, activeValue);
            if (result)
                dgv!.ChangeActiveCell(_frmCat.dgvCatalog, activeValue);
        }

        public void BtnRemove()
        {
            string? id = GetSelectedIdFromCatalog();
            if (string.IsNullOrEmpty(id))
                return;
            BtnActiveProcedure(id, "0");
        }

        public void BtnRecover()
        {
            string? id = GetSelectedIdFromCatalog();
            if (string.IsNullOrEmpty(id))
                return;
            BtnActiveProcedure(id, "1");
        }
    }
}
