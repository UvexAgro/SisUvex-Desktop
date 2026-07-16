using DocumentFormat.OpenXml.EMMA;
using SisUvex.Archivo.Manifiesto;
using SisUvex.Archivo.Reestibado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace SisUvex.Archivo.Mixteada
{
    public partial class FrmMixteado : Form
    {
        ClsMixteado cls = new ClsMixteado();
        public FrmMixteado()
        {
            InitializeComponent();
            cls.DgvColumnas(dgvPallet);
        }
        private void FrmMixteado_Load(object sender, EventArgs e)
        {


        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txbIdPallet.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar número de pallet.");
            }
            else
            {
                cls.AñadirPallet(dgvPallet, cls.FormatoCeros(txbIdPallet.Text, "00000"));
                txbIdPallet.Text = string.Empty;
            }
            txbCajas.Text = cls.SumarCajas(dgvPallet);
            cls.SeleccionarUltimo(dgvPallet);
            txbIdPallet.Focus();
        }
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            cls.MixtearPallets(dgvPallet, txbCajas.Text);
            txbCajas.Text = cls.SumarCajas(dgvPallet);
            txbIdPallet.Focus();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            cls.QuitarPallets(dgvPallet);
            txbCajas.Text = cls.SumarCajas(dgvPallet);
            txbIdPallet.Focus();
        }

        private void txbIdPallet_KeyPress(object sender, KeyPressEventArgs e)
        {
            cls.TxbTeclasEnteros(e);
        }
    }
}
