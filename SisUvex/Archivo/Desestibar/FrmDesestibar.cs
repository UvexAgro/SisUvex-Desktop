
using SisUvex.Catalogos.Metods.Values;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace SisUvex.Archivo.Desestibar
{
    public partial class FrmDesestibar : Form
    {
        ClsDesestibar cls = new ClsDesestibar();
        string? _idEstiba;

        public FrmDesestibar()
        {
            InitializeComponent();
        }
        private void btnBuscarEstiba_Click(object sender, EventArgs e)
        {
            SearchByStowage();
        }

        private void btnDesestibar_Click(object sender, EventArgs e)
        {
            string advertencia = "";
            if (dgvEstiba.Rows.Count > 0)
            {
                if (cls.EnColumna(dgvEstiba, "Manifiesto"))
                    advertencia += "-los pallets de la estiba estan en un manifiesto.";

                if (cls.EnColumna(dgvEstiba, "Rack"))
                    advertencia += "\n-Los pallets de la estiba estan en un rack.";

                DialogResult result = MessageBox.Show(advertencia + $"\n\n¿Seguro que desea desestibar la estiba {_idEstiba}?", "Desestibar estiba", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    cls.ProcDesestibarEstiba(_idEstiba);
                    _idEstiba = string.Empty;

                    foreach (DataGridViewRow row in dgvEstiba.Rows)
                    {
                        row.Cells["Estiba"].Value = string.Empty;
                    }
                }
            }
            else
            {
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void btnSearchPallet_Click(object sender, EventArgs e)
        {
            SearchByPallet();
        }

        private void txbIdEstiba_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchByStowage();
            }
        }

        private void txbIdPallet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchByPallet();
            }
        }

        private void SearchByStowage()
        {
            if (int.TryParse(txbIdEstiba.Text, out int intEstiba))
            {
                _idEstiba = ClsValues.FormatZeros(intEstiba.ToString(), "0000");

                txbIdEstiba.Text = _idEstiba;

                dgvEstiba.DataSource = cls.BuscarEstiba(_idEstiba);

                txbIdPallet.Text = string.Empty;
            }
            else
            {
                System.Media.SystemSounds.Beep.Play();
                dgvEstiba.DataSource = null;
                _idEstiba = string.Empty;
            }
        }

        private void SearchByPallet()
        {
            if (int.TryParse(txbIdPallet.Text, out int intPallet))
            {
                txbIdPallet.Text = ClsValues.FormatZeros(intPallet.ToString(), "00000");

                _idEstiba = cls.SearchPalletStowage(txbIdPallet.Text);

                dgvEstiba.DataSource = cls.BuscarEstiba(_idEstiba);

                txbIdEstiba.Text = string.Empty;
            }
            else
            {
                System.Media.SystemSounds.Beep.Play();
                dgvEstiba.DataSource = null;
                _idEstiba = string.Empty;
            }
        }
    }
}