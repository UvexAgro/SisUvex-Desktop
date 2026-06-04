using System.Data;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using DocumentFormat.OpenXml.EMMA;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.Querys;
using static SisUvex.Catalogos.Metods.ClsObject;
using static SisUvex.Catalogos.Metods.Extentions.ComboBoxExtensions;
using LotInfo = SisUvex.Catalogos.Metods.ClsObject.Lot;
using VarietyInfo = SisUvex.Catalogos.Metods.ClsObject.Variety;

namespace SisUvex.Catalogos.Lot.LotCertification;

internal class ClsLotCertification
{
    ClsControls controlList = null!;
    public FrmLotCertificationAdd _frmAdd = null!;
    public FrmLotCertificationCat _frmCat = null!;
    public ELotCertification entity = null!;

    private readonly string queryCatalog = " SELECT cat.* FROM vw_PackLotCertificationCat cat ";

    ClsDGVCatalog? dgv;
    DataTable dtCatalog = null!;

    public bool IsAddOrModify = true;
    public bool IsAddUpdate;
    public bool IsModifyUpdate;
    public string? idAddModify;

    private void BindDgvCatalog(DataGridView dgvCatalog)
    {
        dgv = new ClsDGVCatalog(dgvCatalog, dtCatalog);
        dgv.AddHideColumn(LotInfo.ColumnId); // idLot
        dgv.HideColumnsList();

        dgv.CopyActiveValuesToHiddenColumn();
        dgv.SetFilterActivesOnly();
    }

    private void WireCatalogFilterEvents()
    {
        // Sin filtros en el catálogo (solo activos/eliminados).
    }

    public void BeginFormCat()
    {
        _frmCat ??= new();
        _frmCat.cls ??= this;

        dtCatalog = ClsQuerysDB.GetDataTable(queryCatalog + " WHERE 1 = 1 ");
        BindDgvCatalog(_frmCat.dgvCatalog);
    }

    static string ActiveHideColumnName => $"{Column.active}2";

    public void ApplyCatalogRowFilter()
    {
        // Sin filtros por ComboBox en el catálogo.
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

    public void BeginFormAdd()
    {
        AddControlsToList();
        LoadControls();

        if (IsAddOrModify)
        {
            _frmAdd.cboActive.SelectedIndex = 1;
        }
        else
        {
            _frmAdd.cboVariety.Font = new Font(_frmAdd.cboVariety.Font, FontStyle.Bold);
            _frmAdd.chbVarietyRemoved.Enabled = false;
            LoadControlsModify();
        }
    }

    private void AddControlsToList()
    {
        controlList = new ClsControls();
        controlList.ChangeHeadMessage("Para dar de alta un lote certificado por variedad debe:\n");
        controlList.Add(_frmAdd.cboVariety, "Seleccionar una variedad.");
        controlList.Add(_frmAdd.cboLot, "Seleccionar un lote.");
        controlList.Add(_frmAdd.cboActive, "Seleccionar si está activo.");
    }

    private void LoadControls()
    {
        ClsComboBoxes.CboLoadActives(_frmAdd.cboVariety, VarietyInfo.Cbo);
        ClsComboBoxes.CboLoadActives(_frmAdd.cboFarm, Farm.Cbo);
        ClsComboBoxes.CboLoadActives(_frmAdd.cboLot, LotInfo.Cbo);

        ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboVariety, _frmAdd.txbIdVariety);
        ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboFarm, _frmAdd.txbIdFarm);
        ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboLot, _frmAdd.txbIdLot);

        var lotFilterDependents = new List<(ComboBox Cbo, string IdColumnFilter)>
        {
            (_frmAdd.cboVariety, VarietyInfo.ColumnId),
            (_frmAdd.cboFarm, Farm.ColumnId)
        };

        // Mostrar/ocultar inactivos en combos.
        ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboVariety, _frmAdd.chbVarietyRemoved);
        ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboFarm, _frmAdd.chbFarmRemoved);
        ClsComboBoxes.CboApplyChbClickEventWithAllForOneDependents(_frmAdd.cboLot, _frmAdd.chbLotRemoved, lotFilterDependents);

        ClsComboBoxes.Events.CboApplyEventFilterAllForOne(
            _frmAdd.cboLot,
            _frmAdd.chbLotRemoved,
            lotFilterDependents);

        ClsComboBoxes.Metods.CboFilterAllForOne(_frmAdd.cboLot, _frmAdd.chbLotRemoved, lotFilterDependents);
    }

    private void LoadControlsModify()
    {
        entity = new();
        entity.GetLotCertification(idAddModify);

        _frmAdd.cboActive.SelectedIndex = entity.Active;
        ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboVariety, entity.IdVariety);
        _frmAdd.cboVariety.Enabled = false; // PK, no cambiar

        string idLotCbo = entity.IdLot + "|" + entity.IdVariety;
        string idFarmCbo = GetValueFromDataSource<string>(_frmAdd.cboLot, idLotCbo, Column.id, Farm.ColumnId);
        ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboFarm, idFarmCbo);

        ClsComboBoxes.CboSelectIndexWithTextInValueMemberKeepingFilter(_frmAdd.cboLot, idLotCbo);
    }

    private ELotCertification SetEntity()
    {
        entity = new();
        entity.IdVariety = _frmAdd.cboVariety.ComboValueOrNull();
        entity.Active = _frmAdd.cboActive.SelectedIndex;
        entity.IdLot = _frmAdd.cboLot.SelectedIndex > 0 ? _frmAdd.cboLot.GetColumnValue(LotInfo.ColumnId)?.ToString() : null;
        return entity;
    }

    public void OpenFrmAdd()
    {
        IsAddOrModify = true;
        IsAddUpdate = false;
        idAddModify = null;
        _frmAdd = new();
        _frmAdd.cls = this;
        _frmAdd.Text = "Añadir lote certificado";
        _frmAdd.lblTitle.Text = "Añadir lote certificado por variedad";
        _frmAdd.ShowDialog();
    }

    public void OpenFrmModify(string? idModify)
    {
        IsAddOrModify = false;
        IsModifyUpdate = false;
        if (string.IsNullOrEmpty(idModify))
        {
            SystemSounds.Exclamation.Play();
            MessageBox.Show("No se ha seleccionado un registro para modificar.", "Modificar lote certificado");
            return;
        }

        idAddModify = idModify;
        _frmAdd = new();
        _frmAdd.cls = this;
        _frmAdd.Text = "Modificar lote certificado";
        _frmAdd.lblTitle.Text = "Modificar lote certificado por variedad";
        _frmAdd.ShowDialog();
    }

    public void BtnAccept()
    {
        if (!controlList.ValidateControls())
            return;

        ELotCertification toSave = SetEntity();
        if (string.IsNullOrWhiteSpace(toSave.IdVariety))
        {
            SystemSounds.Exclamation.Play();
            MessageBox.Show("Selecciona una variedad.", "Guardar");
            return;
        }

        if (string.IsNullOrWhiteSpace(toSave.IdLot))
        {
            SystemSounds.Exclamation.Play();
            MessageBox.Show("Selecciona un lote.", "Guardar");
            return;
        }

        if (IsAddOrModify)
        {
            var result = toSave.AddProcedure();
            IsAddUpdate = result.success;
            idAddModify = result.id;

            if (IsAddUpdate)
            {
                MessageBox.Show($"Se ha agregado el lote certificado para la variedad con código: {idAddModify}.", "Añadir");
                _frmAdd.Close();
            }
            else
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se pudo agregar el registro.", "Añadir");
            }
        }
        else
        {
            var result = toSave.ModifyProcedure();
            IsModifyUpdate = result.success;
            idAddModify = result.id;

            if (IsModifyUpdate)
            {
                MessageBox.Show($"Se ha modificado el lote certificado para la variedad con código: {idAddModify}.", "Modificar");
                _frmAdd.Close();
            }
            else
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se pudo modificar el registro.", "Modificar");
            }
        }
    }

    public void BtnActiveProcedure(string idVariety, string activeValue)
    {
        bool ok = ELotCertification.ActiveProcedure(idVariety, activeValue);
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

