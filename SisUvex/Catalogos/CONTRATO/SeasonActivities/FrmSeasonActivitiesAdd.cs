namespace SisUvex.Catalogos.CONTRATO.SeasonActivities;

internal partial class FrmSeasonActivitiesAdd : Form
{
    public ClsSeasonActivities cls = null!;

    public FrmSeasonActivitiesAdd()
    {
        InitializeComponent();
    }

    private void FrmSeasonActivitiesAdd_Load(object sender, EventArgs e)
    {
        cls ??= new();
        cls._frmAdd ??= this;
        cls.BeginFormAdd();
    }

    private void btnAccept_Click(object sender, EventArgs e)
    {
        cls.BtnAccept();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void lblObliUnit_Click(object sender, EventArgs e)
    {

    }
}
