using System.Drawing;
using System.Media;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Querys;
using System.Data;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Catalogos.LabelLegend;

internal class ClsLabelLegend
{
    ClsControls controlList = null!;
    public FrmLabelLegendAdd _frmAdd = null!;
    public FrmLabelLegendCat _frmCat = null!;
    public ELabelLegend entity = null!;

    private readonly string queryCatalog = $"{Metods.ClsObject.LabelLegend.QueryDgvCatalog} ";

    ClsDGVCatalog? dgv;
    DataTable dtCatalog = null!;

    public bool IsAddOrModify = true;
    public bool IsAddUpdate;
    public bool IsModifyUpdate;
    public string? idAddModify;

    private void BindDgvCatalog(DataGridView dgvCatalog)
    {
        dgv = new ClsDGVCatalog(dgvCatalog, dtCatalog);
        dgv.HideColumnsList();

        if (dgvCatalog.Columns.Contains(Metods.ClsObject.LabelLegend.ColumnDescription))
            dgv.SetColumnWidth(Metods.ClsObject.LabelLegend.ColumnDescription, 200);

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

        if (IsAddOrModify)
        {
            _frmAdd.cboActive.SelectedIndex = 1;
            _frmAdd.txbId.Text = ELabelLegend.GetNextId();
        }
        else
        {
            _frmAdd.txbLabelLegend.Font = new Font(_frmAdd.txbLabelLegend.Font, FontStyle.Bold);
            LoadControlsModify();
        }
    }

    private void AddControlsToList()
    {
        controlList = new ClsControls();
        controlList.ChangeHeadMessage("Para dar de alta una leyenda de etiqueta debe:\n");
        controlList.Add(_frmAdd.txbLabelLegend, "Ingresar la leyenda.");
        controlList.Add(_frmAdd.cboActive, "Seleccionar si está activa.");
    }

    private void LoadControlsModify()
    {
        entity = new();
        entity.GetLabelLegend(idAddModify);

        _frmAdd.txbId.Text = entity.IdLabelLegend ?? "";
        _frmAdd.txbLabelLegend.Text = entity.LabelLegend ?? "";
        _frmAdd.txbLabelLegend2.Text = entity.LabelLegend2 ?? "";
        _frmAdd.txbDescription.Text = entity.Description ?? "";
        _frmAdd.cboActive.SelectedIndex = entity.Active;
    }

    private ELabelLegend SetEntity()
    {
        entity = new();
        entity.IdLabelLegend = _frmAdd.txbId.Text;
        entity.LabelLegend = _frmAdd.txbLabelLegend.Text.Trim();
        entity.LabelLegend2 = string.IsNullOrWhiteSpace(_frmAdd.txbLabelLegend2.Text)
            ? null
            : _frmAdd.txbLabelLegend2.Text.Trim();
        entity.Description = string.IsNullOrWhiteSpace(_frmAdd.txbDescription.Text)
            ? null
            : TrimToMaxLength(_frmAdd.txbDescription.Text.Trim(), 200);
        entity.Active = _frmAdd.cboActive.SelectedIndex;
        return entity;
    }

    static string TrimToMaxLength(string value, int maxLength) =>
        value.Length <= maxLength ? value : value[..maxLength];

    public void OpenFrmAdd()
    {
        IsAddOrModify = true;
        IsAddUpdate = false;
        idAddModify = null;
        _frmAdd = new();
        _frmAdd.cls = this;
        _frmAdd.Text = "Añadir leyenda de etiqueta";
        _frmAdd.lblTitulo.Text = "Añadir leyenda de etiqueta";
        _frmAdd.ShowDialog();
    }

    public void OpenFrmModify(string? idModify)
    {
        IsAddOrModify = false;
        IsModifyUpdate = false;
        if (string.IsNullOrEmpty(idModify))
        {
            SystemSounds.Exclamation.Play();
            MessageBox.Show("No se ha seleccionado una leyenda para modificar.", "Modificar leyenda de etiqueta");
            return;
        }

        idAddModify = idModify;
        _frmAdd = new();
        _frmAdd.cls = this;
        _frmAdd.Text = "Modificar leyenda de etiqueta";
        _frmAdd.lblTitulo.Text = "Modificar leyenda de etiqueta";
        _frmAdd.ShowDialog();
    }

    public void BtnAccept()
    {
        if (!controlList.ValidateControls())
            return;

        if (IsAddOrModify)
        {
            ELabelLegend addEntity = SetEntity();
            var result = addEntity.AddProcedure();
            IsAddUpdate = result.success;
            idAddModify = result.id;

            if (IsAddUpdate)
            {
                string nombre = string.IsNullOrWhiteSpace(addEntity.LabelLegend) ? idAddModify ?? "" : addEntity.LabelLegend;
                MessageBox.Show($"Se ha agregado la leyenda {nombre} con código: {idAddModify}.", "Añadir leyenda de etiqueta");
                _frmAdd.Close();
            }
            else
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se pudo agregar la leyenda de etiqueta.", "Añadir leyenda de etiqueta");
            }
        }
        else
        {
            ELabelLegend modifyEntity = SetEntity();
            var result = modifyEntity.ModifyProcedure();
            IsModifyUpdate = result.success;
            idAddModify = result.id;

            if (IsModifyUpdate)
            {
                string nombre = string.IsNullOrWhiteSpace(modifyEntity.LabelLegend) ? idAddModify ?? "" : modifyEntity.LabelLegend;
                MessageBox.Show($"Se ha modificado la leyenda {nombre} con código: {idAddModify}.", "Modificar leyenda de etiqueta");
                _frmAdd.Close();
            }
            else
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se pudo modificar la leyenda de etiqueta.", "Modificar leyenda de etiqueta");
            }
        }
    }

    public void BtnActiveProcedure(string id, string activeValue)
    {
        bool ok = ELabelLegend.ActiveProcedure(id, activeValue);
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
