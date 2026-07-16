namespace SisUvex.Catalogos.WorkGroup;

internal partial class FrmWorkGroupAdd : Form
{
    public ClsWorkGroup cls = null!;

    public FrmWorkGroupAdd()
    {
        InitializeComponent();
    }

    private void FrmWorkGroupAdd_Load(object sender, EventArgs e)
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

    private void btnSearchContractor_Click(object sender, EventArgs e)
    {
        cls.BtnSearchContractor();
    }
}
