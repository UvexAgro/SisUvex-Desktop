namespace SisUvex.Catalogos.LabelLegend;

internal partial class FrmLabelLegendAdd : Form
{
    public ClsLabelLegend cls = null!;

    public FrmLabelLegendAdd()
    {
        InitializeComponent();
    }

    private void FrmLabelLegendAdd_Load(object sender, EventArgs e)
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
