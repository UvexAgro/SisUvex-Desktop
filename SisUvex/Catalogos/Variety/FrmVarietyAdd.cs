using System.Windows.Forms;

namespace SisUvex.Catalogos.Variety;

internal partial class FrmVarietyAdd : Form{
    public ClsVariety cls = null!;

    public FrmVarietyAdd()
    {
        InitializeComponent();
    }

    private void FrmVarietyAdd_Load(object sender, EventArgs e)
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
