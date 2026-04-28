namespace SisUvex.Catalogos.Distributor;

internal partial class FrmDistributorAdd : Form
{
    public ClsDistributor cls = null!;

    public FrmDistributorAdd()
    {
        InitializeComponent();
    }

    private void FrmDistributorAdd_Load(object sender, EventArgs e)
    {
        cls ??= new();
        cls._frmAdd ??= this;
        cls.BeginFormAdd();
    }

    private void btnAceptar_Click(object sender, EventArgs e)
    {
        cls.BtnAccept();
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        Close();
    }
}
