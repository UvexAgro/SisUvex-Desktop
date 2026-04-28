using System.Media;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.Querys;
using System.Data;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Catalogos.Distributor;

internal class ClsDistributor
{
    ClsControls controlList = null!;
    public FrmDistributorAdd _frmAdd = null!;
    public FrmDistributorCat _frmCat = null!;
    public EDistributor entity = null!;

    private readonly string queryCatalog = $" SELECT cat.* FROM vw_PackDistributorCat cat ";

    ClsDGVCatalog? dgv;
    DataTable dtCatalog = null!;

    public bool IsAddOrModify = true;
    public bool IsAddUpdate;
    public bool IsModifyUpdate;
    public string? idAddModify;

    private void BindDgvCatalog(DataGridView dgvCatalog)
    {
        dgv = new ClsDGVCatalog(dgvCatalog, dtCatalog);
        dgv.AddHideColumn(AgencyTradeUS.ColumnId);
        dgv.AddHideColumn(AgencyTradeMX.ColumnId);
        dgv.AddHideColumn(Grower.ColumnId);
        dgv.AddHideColumn(City.ColumnIdCrossPoint);
        dgv.AddHideColumn(City.ColumnIdDestiny);
        dgv.HideColumnsList();

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
            _frmAdd.txbId.Text = EDistributor.GetNextId();
            _frmAdd.cboMarket.SelectedIndex = _frmAdd.cboMarket.Items.Count > 0 ? 0 : -1;
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

        controlList.ChangeHeadMessage("Para dar de alta un distribuidor debe:\n");
        controlList.Add(_frmAdd.txbName, "Ingresar el nombre del distribuidor.");
        controlList.Add(_frmAdd.txbShortName, "Ingresar el nombre corto del distribuidor.");
        controlList.Add(_frmAdd.cboMarket, "Seleccionar mercado (E / N).");
        controlList.Add(_frmAdd.cboActive, "Seleccionar si el distribuidor está activo.");
    }

    private void LoadControls()
    {
        ClsComboBoxes.CboLoadActives(_frmAdd.cboAgencyUS, AgencyTradeUS.Cbo);
        ClsComboBoxes.CboLoadActives(_frmAdd.cboAgencyMX, AgencyTradeMX.Cbo);
        ClsComboBoxes.CboLoadActives(_frmAdd.cboGrower, Grower.Cbo);
        ClsComboBoxes.CboLoadActives(_frmAdd.cboCityCross, City.Cbo);
        ClsComboBoxes.CboLoadActives(_frmAdd.cboCityDestination, City.Cbo);

        ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboAgencyUS, _frmAdd.chbAgencyUSRemoved);
        ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboAgencyMX, _frmAdd.chbAgencyMXRemoved);
        ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboGrower, _frmAdd.chbGrowerRemoved);
        ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboCityCross, _frmAdd.chbCityCrossRemoved);
        ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboCityDestination, _frmAdd.chbCityDestinationRemoved);
    }

    private void LoadControlsModify()
    {
        entity = new();
        entity.GetDistributor(idAddModify);

        _frmAdd.txbId.Text = entity.IdDistributor ?? "";
        _frmAdd.txbName.Text = entity.NameDistributor ?? "";
        _frmAdd.txbShortName.Text = entity.ShortName ?? "";
        _frmAdd.txbAddress.Text = entity.Address ?? "";
        _frmAdd.txbCityDistributor.Text = entity.City ?? "";
        _frmAdd.txbCountry.Text = entity.Country ?? "";
        _frmAdd.txbRFC.Text = entity.RFC ?? "";
        _frmAdd.txbPhoneNumber.Text = entity.PhoneNumber ?? "";
        _frmAdd.cboMarket.Text = entity.MarketTarget ?? "";
        _frmAdd.cboActive.SelectedIndex = entity.Active;

        ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboAgencyUS, entity.IdUSAgency);
        ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboAgencyMX, entity.IdMXAgency);
        ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboGrower, entity.IdGrower);
        ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboCityCross, entity.IdCityCrossPoint);
        ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboCityDestination, entity.IdCityDestiny);
    }

    private EDistributor SetEntity()
    {
        entity = new();
        entity.IdDistributor = _frmAdd.txbId.Text.Trim();
        entity.NameDistributor = _frmAdd.txbName.Text.Trim();
        entity.ShortName = _frmAdd.txbShortName.Text.Trim();
        entity.Address = _frmAdd.txbAddress.Text.Trim();
        entity.City = _frmAdd.txbCityDistributor.Text.Trim();
        entity.Country = _frmAdd.txbCountry.Text.Trim();
        entity.RFC = _frmAdd.txbRFC.Text.Trim();

        string tel = _frmAdd.txbPhoneNumber.Text.Trim().Replace(" ", "");
        if (tel.Length > 13)
            tel = tel[..13];
        entity.PhoneNumber = tel;

        entity.MarketTarget = _frmAdd.cboMarket.Text;
        entity.Active = _frmAdd.cboActive.SelectedIndex;

        entity.IdUSAgency = _frmAdd.cboAgencyUS.ComboValueOrNull();
        entity.IdMXAgency = _frmAdd.cboAgencyMX.ComboValueOrNull();
        entity.IdGrower = _frmAdd.cboGrower.ComboValueOrNull();
        entity.IdCityCrossPoint = _frmAdd.cboCityCross.ComboValueOrNull();
        entity.IdCityDestiny = _frmAdd.cboCityDestination.ComboValueOrNull();

        return entity;
    }

    public void OpenFrmAdd()
    {
        IsAddOrModify = true;
        IsAddUpdate = false;
        idAddModify = null;
        _frmAdd = new();
        _frmAdd.cls = this;
        _frmAdd.Text = "Añadir distribuidor";
        _frmAdd.lblTitulo.Text = "Añadir distribuidor";
        _frmAdd.ShowDialog();
    }

    public void OpenFrmModify(string? idModify)
    {
        IsAddOrModify = false;
        IsModifyUpdate = false;
        if (string.IsNullOrEmpty(idModify))
        {
            SystemSounds.Exclamation.Play();
            MessageBox.Show("No se ha seleccionado un distribuidor para modificar.", "Modificar distribuidor");
            return;
        }

        idAddModify = idModify;
        _frmAdd = new();
        _frmAdd.cls = this;
        _frmAdd.Text = "Modificar distribuidor";
        _frmAdd.lblTitulo.Text = "Modificar distribuidor";
        _frmAdd.ShowDialog();
    }

    public void BtnAccept()
    {
        if (!controlList.ValidateControls())
            return;

        if (IsAddOrModify)
        {
            EDistributor addEntity = SetEntity();
            var result = addEntity.AddProcedure();
            IsAddUpdate = result.success;
            idAddModify = result.id;

            if (IsAddUpdate)
            {
                string nombre = string.IsNullOrWhiteSpace(addEntity.NameDistributor) ? idAddModify ?? "" : addEntity.NameDistributor.Trim();
                MessageBox.Show($"Se ha agregado el distribuidor {nombre} con código: {idAddModify}.", "Añadir distribuidor");
                _frmAdd.Close();
            }
            else
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se pudo agregar el distribuidor.", "Añadir distribuidor");
            }
        }
        else
        {
            EDistributor modifyEntity = SetEntity();
            var result = modifyEntity.ModifyProcedure();
            IsModifyUpdate = result.success;
            idAddModify = result.id;

            if (IsModifyUpdate)
            {
                string nombre = string.IsNullOrWhiteSpace(modifyEntity.NameDistributor) ? idAddModify ?? "" : modifyEntity.NameDistributor.Trim();
                MessageBox.Show($"Se ha modificado el distribuidor {nombre} con código: {idAddModify}.", "Modificar distribuidor");
                _frmAdd.Close();
            }
            else
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se pudo modificar el distribuidor.", "Modificar distribuidor");
            }
        }
    }

    public void BtnActiveProcedure(string id, string activeValue)
    {
        bool ok = EDistributor.ActiveProcedure(id, activeValue);
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
