using System.Data;
using System.Media;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Cuadro_de_herramientas;
using SisUvex.Usuarios;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Usuarios.Role
{
    internal class ClsUserRole
    {
        ClsControls controlList = null!;
        public FrmUserRoleAdd _frmAdd = null!;
        public FrmUserRoleCat _frmCat = null!;
        public EUserRole entity = null!;
        private readonly string queryCatalog = $" SELECT cat.*, cat.[{Column.active}] AS [{Column.active}2] FROM vw_Conf_Rol_Cat cat ";
        ClsDGVCatalog? dgv;
        DataTable dtCatalog = null!;
        public bool IsAddOrModify = true, IsAddUpdate = false, IsModifyUpdate = false;
        public string? idAddModify;

        public void BeginFormCat()
        {
            _frmCat ??= new();
            _frmCat.cls ??= this;

            dtCatalog = ClsQuerysUsuarios.GetDataTable(queryCatalog + " WHERE 1 = 1 ");
            dgv = new ClsDGVCatalog(_frmCat.dgvCatalog, dtCatalog);
        }

        public void BeginFormAdd()
        {
            AddControlsToList();

            LoadControls();

            if (IsAddOrModify)
            {
                _frmAdd.cboActive.SelectedIndex = 1;
                _frmAdd.txbId.Text = EUserRole.GetNextId();
            }
            else
            {
                LoadControlsModify();
            }
        }

        private void AddControlsToList()
        {
            controlList = new ClsControls();

            controlList.ChangeHeadMessage("Para dar de alta un rol debe:\n");
            controlList.Add(_frmAdd.txbName, "Ingresar el nombre del rol.");
            controlList.Add(_frmAdd.cboActive, "Seleccionar si el rol está activo.");
        }

        private void LoadControls()
        {
        }

        public void OpenFrmAdd()
        {
            IsAddOrModify = true;
            IsAddUpdate = false;
            idAddModify = null;
            _frmAdd = new();
            _frmAdd.cls = this;
            _frmAdd.Text = "Añadir rol";
            _frmAdd.lblTitle.Text = "Añadir rol";
            _frmAdd.ShowDialog();
        }

        public void OpenFrmModify(string? idModify)
        {
            IsAddOrModify = false;
            IsModifyUpdate = false;
            if (string.IsNullOrEmpty(idModify))
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se ha seleccionado un rol para modificar.", "Modificar rol");
                return;
            }

            idAddModify = idModify;
            _frmAdd = new();
            _frmAdd.cls = this;
            _frmAdd.Text = "Modificar rol";
            _frmAdd.lblTitle.Text = "Modificar rol";
            _frmAdd.ShowDialog();
        }

        private static void SetToggleFromFlag(ToggleButton toggle, int value)
        {
            toggle.Checked = value == 1;
        }

        private void LoadControlsModify()
        {
            entity = new();
            entity.GetRole(idAddModify);

            _frmAdd.txbId.Text = entity.idRole;
            _frmAdd.txbName.Text = entity.roleName ?? "";
            _frmAdd.cboActive.SelectedIndex = entity.active;

            SetToggleFromFlag(_frmAdd.tgbPrintLabels, entity.printLabels);
            SetToggleFromFlag(_frmAdd.tgbViewCatalogs, entity.viewCatalogs);
            SetToggleFromFlag(_frmAdd.tgbEditCatalogs, entity.editCatalogs);
            SetToggleFromFlag(_frmAdd.tgbCreateRecords, entity.createRecords);
            SetToggleFromFlag(_frmAdd.tgbProductionReports, entity.productionReports);
            SetToggleFromFlag(_frmAdd.tgbCostReports, entity.costReports);
            SetToggleFromFlag(_frmAdd.tgbAudit, entity.audit);
            SetToggleFromFlag(_frmAdd.tgbOwnFilter, entity.ownFilter);
        }

        private EUserRole SetEntity()
        {
            entity = new();
            entity.idRole = _frmAdd.txbId.Text;
            entity.roleName = _frmAdd.txbName.Text;
            entity.active = _frmAdd.cboActive.SelectedIndex;
            entity.printLabels = _frmAdd.tgbPrintLabels.Checked ? 1 : 0;
            entity.viewCatalogs = _frmAdd.tgbViewCatalogs.Checked ? 1 : 0;
            entity.editCatalogs = _frmAdd.tgbEditCatalogs.Checked ? 1 : 0;
            entity.createRecords = _frmAdd.tgbCreateRecords.Checked ? 1 : 0;
            entity.productionReports = _frmAdd.tgbProductionReports.Checked ? 1 : 0;
            entity.costReports = _frmAdd.tgbCostReports.Checked ? 1 : 0;
            entity.audit = _frmAdd.tgbAudit.Checked ? 1 : 0;
            entity.ownFilter = _frmAdd.tgbOwnFilter.Checked ? 1 : 0;

            return entity;
        }

        public void AddProcedure()
        {
            EUserRole addEntity = new();
            addEntity = SetEntity();
            var result = addEntity.AddProcedure();
            IsAddUpdate = result.Item1;
            idAddModify = result.Item2;
        }

        public void ModifyProcedure()
        {
            EUserRole modifyEntity = new();
            modifyEntity = SetEntity();
            var result = modifyEntity.ModifyProcedure();
            IsModifyUpdate = result.Item1;
            idAddModify = result.Item2;
        }

        public void BtnAccept()
        {
            if (!controlList.ValidateControls())
                return;

            if (IsAddOrModify)
            {
                AddProcedure();
                if (IsAddUpdate)
                {
                    _frmAdd.txbId.Text = idAddModify;
                    MessageBox.Show($"Se ha agregado el rol con código: {idAddModify}", "Añadir rol");
                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo agregar el rol.", "Añadir rol");
                }
            }
            else
            {
                ModifyProcedure();

                if (IsModifyUpdate)
                {
                    MessageBox.Show($"Se ha modificado el rol con el código: {idAddModify}", "Modificar rol");
                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo modificar el rol.", "Modificar rol");
                }
            }
        }

        public void BtnActiveProcedure(string id, string activeValue)
        {
            bool result = EUserRole.ActiveProcedure(id, activeValue);

            if (result)
                dgv!.ChangeActiveCell(id, activeValue);
        }

        public void AddNewRowByIdInDGVCatalog()
        {
            DataTable newIdRow = ClsQuerysUsuarios.GetDataTable(queryCatalog + $" WHERE [{Column.id}] = '{idAddModify}'");
            dgv!.AddNewRowToDGV(newIdRow);
        }

        public void ModifyRowByIdInDGVCatalog()
        {
            DataTable newIdRow = ClsQuerysUsuarios.GetDataTable(queryCatalog + $" WHERE [{Column.id}] = '{idAddModify}'");
            dgv!.ModifyIdRowInDGV(newIdRow);
        }

        public void ChbRemovedFilter()
        {
            dtCatalog = ClsQuerysUsuarios.GetDataTable(queryCatalog + " WHERE 1 = 1 ");
            dgv = new ClsDGVCatalog(_frmCat.dgvCatalog, dtCatalog);

            if (_frmCat.chbRemoved.Checked)
                dgv.SetFilterNull();
            else
            {
                dgv.CopyActiveValuesToHiddenColumn();
                dgv.SetFilterActivesOnly();
            }
        }
    }
}
