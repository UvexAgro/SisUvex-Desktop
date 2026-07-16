using System.Media;
using SisUvex.Catalogos.Metods;

namespace SisUvex.Nomina.PlacePaymentLP;

internal partial class FrmPlacePaymentCat : Form
{
    public ClsPlacePayment cls = null!;

    public FrmPlacePaymentCat()
    {
        InitializeComponent();
    }

    private void FrmPlacePaymentCat_Load(object sender, EventArgs e)
    {
        cls ??= new();
        cls._frmCat ??= this;
        cls.BeginFormCat();

        HasEditCatalogsPermission();
    }

    private void HasEditCatalogsPermission()
    {
        if (User.HasEditCatalogsPermission())
            return;

        btnAdd.Enabled = false;
        btnModify.Enabled = false;
        chbRemoved.Enabled = false;
        btnRemove.Enabled = false;
        btnRecover.Enabled = false;
        btnPriorizeOrder.Enabled = false;

        if (dgvCatalog.Columns.Contains(ClsPlacePayment.ColumnOrder))
            dgvCatalog.Columns[ClsPlacePayment.ColumnOrder].ReadOnly = true;

        dgvCatalog.CellMouseDoubleClick -= dgvCatalog_CellMouseDoubleClick;
    }

    // btnAdd_Click — alta por SP no disponible por ahora (OpenFrmAdd).
    private void btnAdd_Click(object sender, EventArgs e)
    {
        // cls.OpenFrmAdd();
    }

    private void btnModify_Click(object sender, EventArgs e)
    {
        OpenFrmModifyFromCat();
    }

    private void OpenFrmModifyFromCat()
    {
        if (dgvCatalog.SelectedRows.Count == 0)
        {
            SystemSounds.Exclamation.Play();
            return;
        }

        cls.OpenFrmModify(dgvCatalog.Rows[dgvCatalog.SelectedRows[0].Index].Cells[ClsObject.Column.id].Value?.ToString());

        if (cls.IsModifyUpdate)
            cls.ModifyRowByIdInDGVCatalog();
    }

    private void chbRemoved_CheckedChanged(object sender, EventArgs e)
    {
        cls.ChbRemovedFilter();
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {
        if (dgvCatalog.SelectedRows.Count != 0)
        {
            cls.BtnActiveProcedure(
                dgvCatalog.Rows[dgvCatalog.SelectedRows[0].Index].Cells[ClsObject.Column.id].Value.ToString()!,
                "0");
        }
        else
            SystemSounds.Exclamation.Play();
    }

    private void btnRecover_Click(object sender, EventArgs e)
    {
        if (dgvCatalog.SelectedRows.Count != 0)
        {
            cls.BtnActiveProcedure(
                dgvCatalog.SelectedRows[0].Cells[ClsObject.Column.id].Value.ToString()!,
                "1");
        }
        else
            SystemSounds.Exclamation.Play();
    }

    private void btnPriorizeOrder_Click(object sender, EventArgs e)
    {
        cls.BtnPriorizeOrderSelected();
    }

    private void dgvCatalog_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        OpenFrmModifyFromCat();
    }
}
