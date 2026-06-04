using System.Windows.Forms;

namespace SisUvex.Catalogos.Lot.LotCertification;

internal partial class FrmLotCertificationAdd : Form
{
    public ClsLotCertification cls = null!;

    public FrmLotCertificationAdd()
    {
        InitializeComponent();
    }

    private void FrmLotCertificationAdd_Load(object sender, EventArgs e)
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

