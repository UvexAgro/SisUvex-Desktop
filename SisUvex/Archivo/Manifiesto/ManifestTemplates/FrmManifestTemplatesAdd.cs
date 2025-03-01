using SisUvex.Catalogos.Lot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Archivo.Manifiesto.ManifestTemplates
{

    internal partial class FrmManifestTemplatesAdd : Form
    {
        public ClsManifestTemplates cls;
        public bool IsAddModify = true, AddIsUpdate = false;
        public string? idLotModify, idVarietyModify;
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
            cls.btnAcceptAddModify();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
