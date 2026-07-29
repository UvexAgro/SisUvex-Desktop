using System.Media;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.Querys;
using System.Data;
using static SisUvex.Catalogos.Metods.ClsObject;
using SisUvex.Catalogos.Metods;

namespace SisUvex.Catalogos.Consignee;

internal class ClsConsignee
{
    ClsControls controlList = null!;
    public FrmConsigneeAdd _frmAdd = null!;
    public FrmConsigneeCat _frmCat = null!;
    public EConsignee entity = null!;

    private readonly string queryCatalog = $" SELECT cat.* FROM vw_PackConsigneeCat cat ";

    ClsDGVCatalog? dgv;
    DataTable dtCatalog = null!;

    public bool IsAddOrModify = true;
    public bool IsAddUpdate;
    public bool IsModifyUpdate;
    public string? idAddModify;

    private void BindDgvCatalog(DataGridView dgvCatalog)
    {
        dgv = new ClsDGVCatalog(dgvCatalog, dtCatalog);
        dgv.SetColumnWidth("Dirección", 200);
        dgv.CopyActiveValuesToHiddenColumn();
        dgv.SetFilterActivesOnly();
    }

    public void BeginFormCat()
    {
        _frmCat ??= new();
        _frmCat.cls ??= this;

        dtCatalog = ClsQuerysDB.GetDataTable(queryCatalog + " WHERE 1 = 1 ");
        BindDgvCatalog(_frmCat.dgvCatalog);
    }

    public void BeginFormAdd()
    {
        AddControlsToList();
        LoadControls();

        if (IsAddOrModify)
        {
            _frmAdd.cboActive.SelectedIndex = 1;
            _frmAdd.txbId.Text = EConsignee.GetNextId();
        }
        else
        {
            _frmAdd.txbName.Font = new Font(_frmAdd.txbName.Font, FontStyle.Bold);
            LoadControlsModify();
        }
    }

    private void AddControlsToList()
    {
        controlList = new ClsControls();

        controlList.ChangeHeadMessage("Para dar de alta un consignatario debe:\n");
        controlList.Add(_frmAdd.txbName, "Ingresar el nombre del consignatario.");
        controlList.Add(_frmAdd.cboActive, "Seleccionar si el consignatario está activo.");
    }

    private void LoadControls()
    {
        ClsComboBoxes.CboLoadActives(_frmAdd.cboDistributor, ClsObject.Distributor.Cbo);
        ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboDistributor, _frmAdd.chbDistributorRemoved);
    }

    private void LoadControlsModify()
    {
        entity = new();
        entity.GetConsignee(idAddModify);

        _frmAdd.txbId.Text = entity.IdConsignee ?? "";
        _frmAdd.txbName.Text = entity.NameConsignee ?? "";
        _frmAdd.txbAddress.Text = entity.Address ?? "";
        _frmAdd.txbCityDistributor.Text = entity.City ?? "";
        _frmAdd.txbCountry.Text = entity.Country ?? "";
        _frmAdd.txbRFC.Text = entity.RFC ?? "";
        _frmAdd.txbPhoneNumber.Text = entity.PhoneNumber ?? "";
        _frmAdd.txbTaxId.Text = entity.taxId ?? "";
        _frmAdd.cboActive.SelectedIndex = entity.Active;

        ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboDistributor, entity.IdDistributor);
    }

    private EConsignee SetEntity()
    {
        entity = new();
        entity.IdConsignee = _frmAdd.txbId.Text;
        entity.NameConsignee = _frmAdd.txbName.Text;
        entity.Address = _frmAdd.txbAddress.Text;
        entity.City = _frmAdd.txbCityDistributor.Text;
        entity.Country = _frmAdd.txbCountry.Text;
        entity.RFC = _frmAdd.txbRFC.Text;
        entity.taxId = _frmAdd.txbTaxId.Text;

        string tel = _frmAdd.txbPhoneNumber.Text;
        if (tel.Length > 13)
            tel = tel[..13];
        entity.PhoneNumber = tel;

        entity.Active = _frmAdd.cboActive.SelectedIndex;
        entity.IdDistributor = _frmAdd.cboDistributor.ComboValueOrNull();

        return entity;
    }

    public void OpenFrmAdd()
    {
        IsAddOrModify = true;
        IsAddUpdate = false;
        idAddModify = null;
        _frmAdd = new();
        _frmAdd.cls = this;
        _frmAdd.Text = "Añadir consignatario";
        _frmAdd.lblTitle.Text = "Añadir consignatario";
        _frmAdd.ShowDialog();
    }

    public void OpenFrmModify(string? idModify)
    {
        IsAddOrModify = false;
        IsModifyUpdate = false;
        if (string.IsNullOrEmpty(idModify))
        {
            SystemSounds.Exclamation.Play();
            MessageBox.Show("No se ha seleccionado un consignatario para modificar.", "Modificar consignatario");
            return;
        }

        idAddModify = idModify;
        _frmAdd = new();
        _frmAdd.cls = this;
        _frmAdd.Text = "Modificar consignatario";
        _frmAdd.lblTitle.Text = "Modificar consignatario";
        _frmAdd.ShowDialog();
    }

    public void BtnAccept()
    {
        if (!controlList.ValidateControls())
            return;

        if (IsAddOrModify)
        {
            EConsignee addEntity = SetEntity();
            var result = addEntity.AddProcedure();
            IsAddUpdate = result.success;
            idAddModify = result.id;

            if (IsAddUpdate)
            {
                string nombre = string.IsNullOrWhiteSpace(addEntity.NameConsignee) ? idAddModify ?? "" : addEntity.NameConsignee;
                MessageBox.Show($"Se ha agregado el consignatario {nombre} con código: {idAddModify}.", "Añadir consignatario");
                _frmAdd.Close();
            }
            else
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se pudo agregar el consignatario.", "Añadir consignatario");
            }
        }
        else
        {
            EConsignee modifyEntity = SetEntity();
            var result = modifyEntity.ModifyProcedure();
            IsModifyUpdate = result.success;
            idAddModify = result.id;

            if (IsModifyUpdate)
            {
                string nombre = string.IsNullOrWhiteSpace(modifyEntity.NameConsignee) ? idAddModify ?? "" : modifyEntity.NameConsignee;
                MessageBox.Show($"Se ha modificado el consignatario {nombre} con código: {idAddModify}.", "Modificar consignatario");
                _frmAdd.Close();
            }
            else
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se pudo modificar el consignatario.", "Modificar consignatario");
            }
        }
    }

    public void BtnActiveProcedure(string id, string activeValue)
    {
        bool ok = EConsignee.ActiveProcedure(id, activeValue);
        if (ok)
            dgv!.ChangeActiveCell(_frmCat.dgvCatalog, activeValue);
    }

    public void AddNewRowByIdInDGVCatalog()
    {
        string esc = idAddModify?.Replace("'", "''") ?? "";
        DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalog + $" WHERE [{Column.id}] = '{esc}'");
        dgv!.AddNewRowToDGV(newIdRow);
    }

    public void ModifyRowByIdInDGVCatalog()
    {
        string esc = idAddModify?.Replace("'", "''") ?? "";
        DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalog + $" WHERE [{Column.id}] = '{esc}'");
        dgv!.ModifyIdRowInDGV(newIdRow);
    }

    public void ChbRemovedFilter()
    {
        if (_frmCat.chbRemoved.Checked)
            dgv!.SetFilterNull();
        else
        {
            dgv!.CopyActiveValuesToHiddenColumn();
            dgv!.SetFilterActivesOnly();
        }
    }
}
