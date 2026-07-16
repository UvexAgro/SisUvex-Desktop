namespace SisUvex.Nomina.PlacePaymentLP;

internal partial class FrmPlacePaymentAdd : Form
{
    public ClsPlacePayment cls = null!;

    public FrmPlacePaymentAdd()
    {
        InitializeComponent();
    }

    private void FrmPlacePaymentAdd_Load(object sender, EventArgs e)
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
