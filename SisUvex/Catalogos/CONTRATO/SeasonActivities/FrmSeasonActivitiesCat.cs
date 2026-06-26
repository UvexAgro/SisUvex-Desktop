using System.Media;
using SisUvex.Catalogos.Metods;

namespace SisUvex.Catalogos.CONTRATO.SeasonActivities;

internal partial class FrmSeasonActivitiesCat : Form
{
    public ClsSeasonActivities cls = null!;

    public FrmSeasonActivitiesCat()
    {
        InitializeComponent();
    }

    private void FrmSeasonActivitiesCat_Load(object sender, EventArgs e)
    {
        cls ??= new();
        cls._frmCat ??= this;
        cls.BeginFormCat();

        if (!User.HasEditCatalogsPermission())
        {
            btnAdd.Enabled = false;
            btnModify.Enabled = false;
        }
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

    private void dgvCatalog_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        OpenFrmModifyFromCat();
    }
}
