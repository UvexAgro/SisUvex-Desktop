using System.Data;
using System.Media;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Usuarios;
using SisUvex.Usuarios.Role;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Usuarios.UserCrud;

internal class ClsUserCrud
{
    private const string PasswordVisualPlaceholder = "*******";

    ClsControls controlList = null!;
    public FrmUserAdd _frmAdd = null!;
    public FrmUserCat _frmCat = null!;
    public EUserCrud entity = null!;
    private string? _validateCodeSnapshot;
    public static string columnUserName = "Usuario";
    private readonly string queryCatalog = $" SELECT cat.*, cat.[{Column.active}] AS [{Column.active}2] FROM vw_user_cat cat ";

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

        _frmAdd.txbPassword.Enabled = IsAddOrModify;
        _frmAdd.txbPasswordConfirm.Enabled = IsAddOrModify;
        _frmAdd.txbUserName.Enabled = IsAddOrModify;

        if (IsAddOrModify)
        {
            _frmAdd.cboActive.SelectedIndex = 1;
            _frmAdd.txbId.Text = EUserCrud.GetNextId();
            //_frmAdd.txbUserName.Clear();
            //_frmAdd.txbPassword.Clear();
            //_frmAdd.txbPasswordConfirm.Clear();
            //_frmAdd.txbIdEmployee.Clear();
            //_frmAdd.txbEmployeeName.Clear();
        }
        else
        {
            _frmAdd.txbUserName.Font = new Font(_frmAdd.txbUserName.Font, FontStyle.Bold);
            LoadControlsModify();
            ApplyPasswordPlaceholderForModify();
        }
    }

    private void ApplyPasswordPlaceholderForModify()
    {
        _frmAdd.txbPassword.Text = PasswordVisualPlaceholder;
        _frmAdd.txbPasswordConfirm.Text = PasswordVisualPlaceholder;
    }

    private void LoadControls()
    {
        EUserRole.CboLoadActives(_frmAdd.cboRole);
        ClsComboBoxes.CboLoadActives(_frmAdd.cboSeason, Season.Cbo);
        ClsComboBoxes.CboLoadActives(_frmAdd.cboContractor, Contractor.Cbo);
        ClsComboBoxes.CboLoadActives(_frmAdd.cboWorkGroup, WorkGroup.Cbo);

        List<(ComboBox Cbo, string IdColumnFilter)> lsWGDep = new();
        lsWGDep.Add((_frmAdd.cboSeason, Season.ColumnId));
        lsWGDep.Add((_frmAdd.cboContractor, Contractor.ColumnId));

        ClsComboBoxes.Events.CboApplyEventFilterAllForOne(_frmAdd.cboWorkGroup, null, lsWGDep);
    }

    private void AddControlsToList()
    {
        controlList = new ClsControls();

        controlList.ChangeHeadMessage("Para dar de alta un usuario debe:\n");
        controlList.Add(_frmAdd.txbUserName, "Ingresar el nombre del usuario.");
        controlList.Add(_frmAdd.txbPassword, "Ingresar la contraseña del usuario.");
        controlList.Add(_frmAdd.txbPasswordConfirm, "Confirmar la contraseña del usuario.");
        controlList.Add(_frmAdd.cboRole, "Seleccionar el rol del usuario.");
        controlList.Add(_frmAdd.txbEmployeeName, "Ingresar el nombre de la persona.");
        controlList.Add(_frmAdd.cboActive, "Seleccionar si el usuario está activo.");
    }

    private static string? ComboValueOrNull(ComboBox cbo)
    {
        if (cbo.SelectedIndex <= 0)
            return null;
        return cbo.SelectedValue?.ToString()?.Trim();
    }

    private void LoadControlsModify()
    {
        entity = new();
        entity.GetUser(idAddModify);

        _frmAdd.txbId.Text = entity.IdUser ?? "";
        _frmAdd.txbId.Enabled = false;
        _frmAdd.txbUserName.Text = entity.UserDisplayName ?? "";
        _frmAdd.nudAcces.Value = Math.Clamp(entity.Accesibilidad, (int)_frmAdd.nudAcces.Minimum, (int)_frmAdd.nudAcces.Maximum);
        _frmAdd.txbIdEmployee.Text = entity.IdEmployee ?? "";
        _frmAdd.txbEmployeeName.Text = entity.Name ?? "";
        _frmAdd.cboActive.SelectedIndex = entity.Active;

        ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboRole, entity.IdRole);
        ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboContractor, entity.IdContractor);
        ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboWorkGroup, entity.IdWorkGroup);
    }

    private EUserCrud SetEntity(bool includePasswordHash, string? passwordHashBcrypt)
    {
        entity = new();
        entity.IdUser = _frmAdd.txbId.Text.Trim().ToUpperInvariant();
        entity.UserDisplayName = _frmAdd.txbUserName.Text.Trim();
        entity.Accesibilidad = (int)_frmAdd.nudAcces.Value;
        entity.IdContractor = ComboValueOrNull(_frmAdd.cboContractor);
        entity.IdWorkGroup = ComboValueOrNull(_frmAdd.cboWorkGroup);
        entity.IdEmployee = string.IsNullOrWhiteSpace(_frmAdd.txbIdEmployee.Text) ? null : _frmAdd.txbIdEmployee.Text.Trim();
        entity.Name = string.IsNullOrWhiteSpace(_frmAdd.txbEmployeeName.Text) ? null : _frmAdd.txbEmployeeName.Text.Trim();
        entity.IdRole = ComboValueOrNull(_frmAdd.cboRole);
        entity.Active = _frmAdd.cboActive.SelectedIndex;
        if (includePasswordHash && passwordHashBcrypt != null)
            entity.PasswordHash = passwordHashBcrypt;

        return entity;
    }

    public void OpenFrmAdd()
    {
        _validateCodeSnapshot = null;
        IsAddOrModify = true;
        IsAddUpdate = false;
        idAddModify = null;
        _frmAdd = new();
        _frmAdd.cls = this;
        _frmAdd.Text = "Añadir usuario";
        _frmAdd.lblTitle.Text = "Añadir nuevo usuario";
        _frmAdd.ShowDialog();
    }

    public void OpenFrmModify(string? idModify)
    {
        IsAddOrModify = false;
        IsModifyUpdate = false;
        if (string.IsNullOrEmpty(idModify))
        {
            SystemSounds.Exclamation.Play();
            MessageBox.Show("No se ha seleccionado un usuario para modificar.", "Modificar usuario");
            return;
        }

        idAddModify = idModify;
        _frmAdd = new();
        _frmAdd.cls = this;
        _frmAdd.Text = "Modificar usuario";
        _frmAdd.lblTitle.Text = "Modificar usuario";
        _frmAdd.ShowDialog();
    }

    /// <summary>Abre el formulario de cambio de contraseña cargando datos por código de usuario (<c>c_codigo_usu</c>).</summary>
    public static void OpenFrmChangePassword(string userCode)
    {
        if (string.IsNullOrWhiteSpace(userCode))
        {
            SystemSounds.Exclamation.Play();
            return;
        }

        FrmUserChangePass f = new();
        f.LoadByUserCode(userCode.Trim());
        f.ShowDialog();
    }

    public void OpenFrmChangePasswordFromCatalog()
    {
        if (_frmCat.dgvCatalog.SelectedRows.Count == 0)
        {
            SystemSounds.Exclamation.Play();
            return;
        }

        string? code = _frmCat.dgvCatalog.Rows[_frmCat.dgvCatalog.SelectedRows[0].Index].Cells[ClsUserCrud.columnUserName].Value?.ToString();
        OpenFrmChangePassword(code ?? string.Empty);
    }

    private bool ValidatePasswordsForAdd()
    {
        if (_frmAdd.txbPassword.Text != _frmAdd.txbPasswordConfirm.Text)
        {
            MessageBox.Show("La contraseña y la confirmación no coinciden.", "Añadir usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        if (string.IsNullOrWhiteSpace(_frmAdd.txbPassword.Text))
        {
            MessageBox.Show("Debe ingresar una contraseña.", "Añadir usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        return true;
    }

    public void BtnAccept()
    {
        if (!controlList.ValidateControls())
            return;

        if (IsAddOrModify)
        {
            if (!ValidatePasswordsForAdd())
                return;

            string code = _frmAdd.txbUserName.Text.Trim().ToUpperInvariant();
            if (EUserCrud.UserExists(code))
            {
                MessageBox.Show($"El usuario {code} ya existe. Use otro código.", "Añadir usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hash = BCrypt.Net.BCrypt.HashPassword(_frmAdd.txbPassword.Text);
            EUserCrud addEntity = SetEntity(true, hash);
            var result = addEntity.AddProcedure();
            IsAddUpdate = result.success;
            idAddModify = result.id;

            if (IsAddUpdate)
            {
                MessageBox.Show($"Se ha agregado el usuario con código: {idAddModify}", "Añadir usuario");
                _frmAdd.Close();
            }
            else
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se pudo agregar el usuario.", "Añadir usuario");
            }
        }
        else
        {
            EUserCrud modifyEntity = SetEntity(false, null);
            var result = modifyEntity.ModifyProcedure();
            IsModifyUpdate = result.success;
            idAddModify = result.id;

            if (IsModifyUpdate)
            {
                MessageBox.Show($"Se ha modificado el usuario con código: {idAddModify}", "Modificar usuario");
                _frmAdd.Close();
            }
            else
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se pudo modificar el usuario.", "Modificar usuario");
            }
        }
    }

    public void BtnActiveProcedure(string id, string activeValue)
    {
        bool ok = EUserCrud.ActiveProcedure(id, activeValue);
        if (ok)
            dgv!.ChangeActiveCell(id, activeValue);
    }

    public void AddNewRowByIdInDGVCatalog()
    {
        DataTable newIdRow = ClsQuerysUsuarios.GetDataTable(queryCatalog + $" WHERE [{Column.id}] = '{idAddModify?.Replace("'", "''")}'");
        dgv!.AddNewRowToDGV(newIdRow);
    }

    public void ModifyRowByIdInDGVCatalog()
    {
        DataTable newIdRow = ClsQuerysUsuarios.GetDataTable(queryCatalog + $" WHERE [{Column.id}] = '{idAddModify?.Replace("'", "''")}'");
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
