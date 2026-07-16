using System.Data;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.Querys;
using static SisUvex.Catalogos.Metods.ClsObject;
using static SisUvex.Catalogos.Metods.Extentions.ComboBoxExtensions;

namespace SisUvex.Archivo.Manifiesto.ManifestTemplates;

internal class ClsManifestTemplates
{
    ClsControls controlList = null!;
    public FrmManifestTemplatesAdd _frmAdd = null!;
    public FrmManifestTemplatesCat _frmCat = null!;
    public EManifestTemplate entity = null!;

    private readonly string queryCatalog = " SELECT cat.* FROM vw_PackManifestTemplatesCat cat ";

    ClsDGVCatalog? dgv;
    DataTable dtCatalog = null!;

    public bool IsAddOrModify = true;
    public bool IsAddUpdate;
    public bool IsModifyUpdate;
    public string? idAddModify;

    private void BindDgvCatalog(DataGridView dgvCatalog)
    {
        dgv = new ClsDGVCatalog(dgvCatalog, dtCatalog);
        dgv.AddHideColumn(Crop.ColumnId);
        dgv.AddHideColumn(Grower.ColumnId);
        dgv.AddHideColumn(Distributor.ColumnId);
        dgv.AddHideColumn(Consignee.ColumnId);
        dgv.AddHideColumn(AgencyTradeUS.ColumnId);
        dgv.AddHideColumn(AgencyTradeMX.ColumnId);
        dgv.AddHideColumn(City.ColumnIdCrossPoint);
        dgv.AddHideColumn(City.ColumnIdDestiny);
        dgv.HideColumnsList();
        ClsDGVCatalog.ConvertToCheckBoxColumn(dgvCatalog, ClsObject.ManifestTemplate.ColumnPrintShowSize);
        ClsDGVCatalog.ConvertToCheckBoxColumn(dgvCatalog, ClsObject.ManifestTemplate.ColumnPrintManifest);
        ClsDGVCatalog.ConvertToCheckBoxColumn(dgvCatalog, ClsObject.ManifestTemplate.ColumnPrintManifestPerField);
        ClsDGVCatalog.ConvertToCheckBoxColumn(dgvCatalog, ClsObject.ManifestTemplate.ColumnPrintMaping);
        ClsDGVCatalog.ConvertToCheckBoxColumn(dgvCatalog, ClsObject.ManifestTemplate.ColumnPrintExcelLayout);
        ClsDGVCatalog.ConvertToCheckBoxColumn(dgvCatalog, ClsObject.ManifestTemplate.ColumnPrintPackingList);
    }

    private void WireCatalogFilterEvents()
    {
        void subscribe(ComboBox cbo) => cbo.SelectedIndexChanged += (_, _) => ApplyCatalogRowFilter();

        subscribe(_frmCat.cboCrop);
        subscribe(_frmCat.cboDistributor);
        subscribe(_frmCat.cboConsignee);
        subscribe(_frmCat.cboGrower);
        subscribe(_frmCat.cboAgencyUS);
        subscribe(_frmCat.cboAgencyMX);
        subscribe(_frmCat.cboCityCross);
        subscribe(_frmCat.cboCityDestiny);
    }

    public void BeginFormCat()
    {
        _frmCat ??= new();
        _frmCat.cls ??= this;

        ClsComboBoxes.CboLoadActives(_frmCat.cboCrop, Crop.Cbo);
        ClsComboBoxes.CboLoadActives(_frmCat.cboDistributor, ClsObject.Distributor.Cbo);
        ClsComboBoxes.CboLoadActives(_frmCat.cboConsignee, Consignee.Cbo);
        ClsComboBoxes.CboLoadActives(_frmCat.cboGrower, Grower.Cbo);
        ClsComboBoxes.CboLoadActives(_frmCat.cboAgencyUS, AgencyTradeUS.Cbo);
        ClsComboBoxes.CboLoadActives(_frmCat.cboAgencyMX, AgencyTradeMX.Cbo);
        ClsComboBoxes.CboLoadActives(_frmCat.cboCityCross, City.Cbo);
        ClsComboBoxes.CboLoadActives(_frmCat.cboCityDestiny, City.Cbo);

        dtCatalog = ClsQuerysDB.GetDataTable(queryCatalog + " WHERE 1 = 1 ");
        BindDgvCatalog(_frmCat.dgvCatalog);

        WireCatalogFilterEvents();
    }

    static string ActiveHideColumnName => $"{Column.active}2";

    /// <summary>Filtros sobre <see cref="dtCatalog"/> (sin nueva consulta), combinados con activos/eliminados.</summary>
    public void ApplyCatalogRowFilter()
    {
        if (dtCatalog == null)
            return;

        List<string> filters = new();

        if (!_frmCat.chbRemoved.Checked && dtCatalog.Columns.Contains(ActiveHideColumnName))
            filters.Add($"[{ActiveHideColumnName}] = '1'");

        if (_frmCat.cboCrop.TryGetValue(out string cropValue))
            filters.Add($"[{Crop.ColumnId}] = '{cropValue.Replace("'", "''")}'");

        if (_frmCat.cboDistributor.TryGetValue(out string distributorValue))
            filters.Add($"[{Distributor.ColumnId}] = '{distributorValue.Replace("'", "''")}'");

        if (_frmCat.cboConsignee.TryGetValue(out string consigneeValue))
            filters.Add($"[{Consignee.ColumnId}] = '{consigneeValue.Replace("'", "''")}'");

        if (_frmCat.cboGrower.TryGetValue(out string growerValue))
            filters.Add($"[{Grower.ColumnId}] = '{growerValue.Replace("'", "''")}'");

        if (_frmCat.cboAgencyUS.TryGetValue(out string agencyUsValue))
            filters.Add($"[{AgencyTradeUS.ColumnId}] = '{agencyUsValue.Replace("'", "''")}'");

        if (_frmCat.cboAgencyMX.TryGetValue(out string agencyMxValue))
            filters.Add($"[{AgencyTradeMX.ColumnId}] = '{agencyMxValue.Replace("'", "''")}'");

        if (_frmCat.cboCityCross.TryGetValue(out string cityCrossValue))
            filters.Add($"[{City.ColumnIdCrossPoint}] = '{cityCrossValue.Replace("'", "''")}'");

        if (_frmCat.cboCityDestiny.TryGetValue(out string cityDestValue))
            filters.Add($"[{City.ColumnIdDestiny}] = '{cityDestValue.Replace("'", "''")}'");

        dtCatalog.DefaultView.RowFilter = filters.Count > 0 ? string.Join(" AND ", filters) : string.Empty;
    }

    public void ChbRemovedFilter()
    {
        if (!_frmCat.chbRemoved.Checked)
            dgv!.CopyActiveValuesToHiddenColumn();

        ApplyCatalogRowFilter();
    }

    public void BeginFormAdd()
    {
        AddControlsToList();
        CargarComboBoxes();

        if (IsAddOrModify)
        {
            _frmAdd.cboActive.SelectedIndex = 1;
            _frmAdd.txbId.Text = EManifestTemplate.GetNextId();
            _frmAdd.tglShowSize.Checked = false;
            _frmAdd.tglManifest.Checked = false;
            _frmAdd.btnManifestPerFarm.Checked = false;
            _frmAdd.tglMapping.Checked = false;
            _frmAdd.tglExcelLayout.Checked = false;
            _frmAdd.tglPrintPackingList.Checked = false;
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

        controlList.ChangeHeadMessage("Para dar de alta una plantilla de manifiesto debe:\n");
        controlList.Add(_frmAdd.txbName, "Ingresar el nombre de la plantilla.");
        controlList.Add(_frmAdd.cboActive, "Seleccionar si la plantilla está activa.");
        controlList.Add(_frmAdd.cboCrop, "Seleccionar un cultivo.");
        controlList.Add(_frmAdd.cboDistributor, "Seleccionar un distribuidor.");
    }

    private void CargarComboBoxes()
    {
        ClsComboBoxes.CboLoadActives(_frmAdd.cboCrop, Crop.Cbo);
        ClsComboBoxes.CboLoadActives(_frmAdd.cboDistributor, ClsObject.Distributor.Cbo);
        ClsComboBoxes.CboLoadActives(_frmAdd.cboConsignee, Consignee.Cbo);
        ClsComboBoxes.CboLoadActives(_frmAdd.cboGrower, Grower.Cbo);
        ClsComboBoxes.CboLoadActives(_frmAdd.cboAgencyMX, AgencyTradeMX.Cbo);
        ClsComboBoxes.CboLoadActives(_frmAdd.cboAgencyUS, AgencyTradeUS.Cbo);
        ClsComboBoxes.CboLoadActives(_frmAdd.cboCityCrossPoint, City.Cbo);
        ClsComboBoxes.CboLoadActives(_frmAdd.cboCityDestination, City.Cbo);

        ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboDistributor, _frmAdd.chbRemovedDistributor);
        ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboConsignee, _frmAdd.chbRemovedConsignee);
        ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboGrower, _frmAdd.chbRemovedGrower);
        ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboAgencyUS, _frmAdd.chbRemovedAgencyUS);
        ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboAgencyMX, _frmAdd.chbRemovedAgencyMX);
        ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboCityCrossPoint, _frmAdd.chbRemovedCityCrossPoint);
        ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboCityDestination, _frmAdd.chbRemovedCityDestination);
    }

    private void LoadControlsModify()
    {
        entity = new();
        entity.GetManifestTemplate(idAddModify);

        _frmAdd.txbId.Text = entity.IdTemplate ?? "";
        _frmAdd.txbName.Text = entity.NameTemplate ?? "";
        _frmAdd.txbDescription.Text = entity.Description ?? "";
        _frmAdd.cboActive.SelectedIndex = entity.Active;

        ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboCrop, entity.IdCrop);
        ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboDistributor, entity.IdDistributor);
        ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboConsignee, entity.IdConsignee);
        ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboGrower, entity.IdGrower);
        ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboAgencyUS, entity.IdUSAgencyTrade);
        ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboAgencyMX, entity.IdMXAgencyTrade);
        ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboCityCrossPoint, entity.IdCityCrossPoint);
        ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboCityDestination, entity.IdCityDestiny);

        _frmAdd.tglShowSize.Checked = entity.printShowSize;
        _frmAdd.tglManifest.Checked = entity.printManifest;
        _frmAdd.btnManifestPerFarm.Checked = entity.printManifestPerFarm;
        _frmAdd.tglMapping.Checked = entity.printMaping;
        _frmAdd.tglExcelLayout.Checked = entity.printExcelLayout;
        _frmAdd.tglPrintPackingList.Checked = entity.printPackingList;
    }

    private EManifestTemplate SetEntity()
    {
        entity = new();
        entity.IdTemplate = _frmAdd.txbId.Text.Trim();
        entity.NameTemplate = _frmAdd.txbName.Text.Trim();
        entity.Description = _frmAdd.txbDescription.Text.Trim();
        entity.Active = _frmAdd.cboActive.SelectedIndex;

        entity.IdCrop = _frmAdd.cboCrop.ComboValueOrNull();
        entity.IdDistributor = _frmAdd.cboDistributor.ComboValueOrNull();
        entity.IdConsignee = _frmAdd.cboConsignee.ComboValueOrNull();
        entity.IdGrower = _frmAdd.cboGrower.ComboValueOrNull();
        entity.IdUSAgencyTrade = _frmAdd.cboAgencyUS.ComboValueOrNull();
        entity.IdMXAgencyTrade = _frmAdd.cboAgencyMX.ComboValueOrNull();
        entity.IdCityCrossPoint = _frmAdd.cboCityCrossPoint.ComboValueOrNull();
        entity.IdCityDestiny = _frmAdd.cboCityDestination.ComboValueOrNull();

        entity.printShowSize = _frmAdd.tglShowSize.Checked;
        entity.printManifest = _frmAdd.tglManifest.Checked;
        entity.printManifestPerFarm = _frmAdd.btnManifestPerFarm.Checked;
        entity.printMaping = _frmAdd.tglMapping.Checked;
        entity.printExcelLayout = _frmAdd.tglExcelLayout.Checked;
        entity.printPackingList = _frmAdd.tglPrintPackingList.Checked;

        return entity;
    }

    public void OpenFrmAdd()
    {
        IsAddOrModify = true;
        IsAddUpdate = false;
        idAddModify = null;
        _frmAdd = new();
        _frmAdd.cls = this;
        _frmAdd.Text = "Añadir plantilla de manifiesto";
        _frmAdd.lblTitle.Text = "Añadir plantilla de manifiesto";
        _frmAdd.ShowDialog();
    }

    public void OpenFrmModify(string? idModify)
    {
        IsAddOrModify = false;
        IsModifyUpdate = false;
        if (string.IsNullOrEmpty(idModify))
        {
            SystemSounds.Exclamation.Play();
            MessageBox.Show("No se ha seleccionado una plantilla para modificar.", "Modificar plantilla");
            return;
        }

        idAddModify = idModify;
        _frmAdd = new();
        _frmAdd.cls = this;
        _frmAdd.Text = "Modificar plantilla de manifiesto";
        _frmAdd.lblTitle.Text = "Modificar plantilla de manifiesto";
        _frmAdd.ShowDialog();
    }

    public void BtnAccept()
    {
        if (!controlList.ValidateControls())
            return;

        if (IsAddOrModify)
        {
            EManifestTemplate addEntity = SetEntity();
            var result = addEntity.AddProcedure();
            IsAddUpdate = result.success;
            idAddModify = result.id;

            if (IsAddUpdate)
            {
                string nombre = string.IsNullOrWhiteSpace(addEntity.NameTemplate)
                    ? idAddModify ?? ""
                    : addEntity.NameTemplate.Trim();
                MessageBox.Show($"Se ha agregado la plantilla {nombre} con código: {idAddModify}.", "Añadir plantilla");
                _frmAdd.Close();
            }
            else
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se pudo agregar la plantilla.", "Añadir plantilla");
            }
        }
        else
        {
            EManifestTemplate modifyEntity = SetEntity();
            var result = modifyEntity.ModifyProcedure();
            IsModifyUpdate = result.success;
            idAddModify = result.id;

            if (IsModifyUpdate)
            {
                string nombre = string.IsNullOrWhiteSpace(modifyEntity.NameTemplate)
                    ? idAddModify ?? ""
                    : modifyEntity.NameTemplate.Trim();
                MessageBox.Show($"Se ha modificado la plantilla {nombre} con código: {idAddModify}.", "Modificar plantilla");
                _frmAdd.Close();
            }
            else
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se pudo modificar la plantilla.", "Modificar plantilla");
            }
        }
    }

    public void BtnActiveProcedure(string id, string activeValue)
    {
        bool ok = EManifestTemplate.ActiveProcedure(id, activeValue);
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
}

