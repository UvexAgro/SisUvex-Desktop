using System.Media;
using SisUvex.Catalogos.Metods;

namespace SisUvex.Usuarios.UserCrud;

internal partial class FrmUserCat : Form
{
    public ClsUserCrud cls = null!;

    public FrmUserCat()
    {
        InitializeComponent();
    }

    private void FrmUserCat_Load(object sender, EventArgs e)
    {
        cls ??= new();
        cls._frmCat ??= this;
        cls.BeginFormCat();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        cls.OpenFrmAdd();

        if (cls.IsAddUpdate)
            cls.AddNewRowByIdInDGVCatalog();
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
            cls.BtnActiveProcedure(dgvCatalog.Rows[dgvCatalog.SelectedRows[0].Index].Cells[ClsObject.Column.id].Value.ToString()!, "0");
        }
        else
            SystemSounds.Exclamation.Play();
    }

    private void btnRecover_Click(object sender, EventArgs e)
    {
        if (dgvCatalog.SelectedRows.Count != 0)
        {
            cls.BtnActiveProcedure(dgvCatalog.Rows[dgvCatalog.SelectedRows[0].Index].Cells[ClsObject.Column.id].Value.ToString()!, "1");
        }
        else
            SystemSounds.Exclamation.Play();
    }

    private void btnChangeUserPass_Click(object sender, EventArgs e)
    {
        cls.OpenFrmChangePasswordFromCatalog();
    }

    private void dgvCatalog_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        OpenFrmModifyFromCat();
    }
}
