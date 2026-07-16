using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Configuracion.Parameters
{
    internal partial class FrmParametersAdd : Form
    {
        public ClsParameters cls;
        public FrmParametersAdd()
        {
            InitializeComponent();
        }

        private void FrmParametersAdd_Load(object sender, EventArgs e)
        {
            cls ??= new();
            cls.BeginFormAdd();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            cls.BtnAccept();
        }

        private void btnIdEdit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de cambiar los códigos del parámetro?\n\n" +
                                "-No dejará modificar si ya existe una combinación con esos códigos."
                                , "Parámetros", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result != DialogResult.OK)
                return;

            cboType.Enabled = true; //Estará bloqueado si es Modify
            txbId.Enabled = true;
            txbId.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
