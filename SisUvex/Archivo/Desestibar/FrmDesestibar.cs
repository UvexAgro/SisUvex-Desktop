
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
        public FrmDesestibar()
        {
            InitializeComponent();
        }
        string _idEstiba;
        private void btnBuscarEstiba_Click(object sender, EventArgs e)
        {
            dgvEstiba.DataSource = cls.BuscarEstiba(txbIdEstiba.Text);
            if (dgvEstiba.Rows.Count > 0)
            {
                _idEstiba = ClsValues.FormatZeros(txbIdEstiba.Text, "0000");
            }
        }

        private void btnDesestibar_Click(object sender, EventArgs e)
        {
            string advertencia = "";
            if (dgvEstiba.Rows.Count > 0)
            {
                if (cls.EnColumna(dgvEstiba, "Manifiesto"))
                {
                    advertencia += "-los pallets de la estiba estan en un manifiesto.";
                }
                if (cls.EnColumna(dgvEstiba, "Rack"))
                {
                    advertencia += "\n-Los pallets de la estiba estan en un rack.";
                }

                DialogResult result = MessageBox.Show(advertencia + $"\n\n¿Seguro que desea desestibar la estiba {_idEstiba}?", "Desestibar estiba", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    cls.ProcDesestibarEstiba(_idEstiba);
                    dgvEstiba.DataSource = null;
                }
            }
        }
    }
}