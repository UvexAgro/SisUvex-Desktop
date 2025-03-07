using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Nomina.Padron.SUA
{
    public partial class FrmSUALoad : Form
    {
        ClsSUALoad cls;
        public FrmSUALoad()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void FrmSUALoad_Load(object sender, EventArgs e)
        {
            cls ??= new ClsSUALoad();
            cls._frm ??= this;

            cls.BeginFrm();
        }

        private void btnAddSUAConfig_Click(object sender, EventArgs e)
        {
            FrmSuaConfigCat frmSuaConfigCat = new FrmSuaConfigCat();
            frmSuaConfigCat.IsAddModify = true;
            frmSuaConfigCat.ShowDialog();

            if (frmSuaConfigCat.IsFrmUpdate)
                cls.CboSUAConfig();
        }

        private void btnErrors_Click(object sender, EventArgs e)
        {
            cls.BtnErrors();


        }

        private void btnModifySUAConfig_Click(object sender, EventArgs e)
        {
            if (cboIdSUAConfig.SelectedIndex > 0)
            {
                FrmSuaConfigCat frmSuaConfigCat = new FrmSuaConfigCat();
                frmSuaConfigCat.IsAddModify = false;
                frmSuaConfigCat.idModify = cboIdSUAConfig.SelectedValue.ToString();
                frmSuaConfigCat.ShowDialog();

                if (frmSuaConfigCat.IsFrmUpdate)
                    cls.CboSUAConfig();
            }
            else
                System.Media.SystemSounds.Hand.Play();
        }

        private void btnDeleteSUAConfig_Click(object sender, EventArgs e)
        {
            if (cboIdSUAConfig.SelectedIndex > 0)
            {
                bool isDelete = ESuaConfig.DeleteSuaConfig(cboIdSUAConfig.SelectedValue.ToString());

                cls.CboSUAConfig();

                if (isDelete)
                {
                    MessageBox.Show("Registro eliminado correctamente.", "Eliminar registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cls.CboSUAConfig();
                }
                else
                    MessageBox.Show("Error al eliminar el registro.", "Eliminar registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                System.Media.SystemSounds.Hand.Play();
        }
    }
}
