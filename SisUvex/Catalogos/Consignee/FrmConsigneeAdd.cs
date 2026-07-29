namespace SisUvex.Catalogos.Consignee;

internal partial class FrmConsigneeAdd : Form
{
    public ClsConsignee cls = null!;

    public FrmConsigneeAdd()
    {
        InitializeComponent();
    }

    private void FrmConsigneeAdd_Load(object sender, EventArgs e)
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
}
