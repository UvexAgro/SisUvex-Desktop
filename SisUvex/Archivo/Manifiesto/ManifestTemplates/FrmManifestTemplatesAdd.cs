using System;
using System.Windows.Forms;

namespace SisUvex.Archivo.Manifiesto.ManifestTemplates;

internal partial class FrmManifestTemplatesAdd : Form
{
    public ClsManifestTemplates cls = null!;

    public FrmManifestTemplatesAdd()
    {
        InitializeComponent();
    }

    private void FrmManifestTemplatesAdd_Load(object sender, EventArgs e)
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
