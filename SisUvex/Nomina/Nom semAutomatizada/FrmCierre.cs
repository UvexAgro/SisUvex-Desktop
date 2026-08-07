using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.SS.Formula.Functions;

namespace SisUvex.Nomina.Nom_semAutomatizada
{
	public partial class FrmCierre : Form
	{
		internal ClsCierre clsC;
		public FrmCierre()
		{
			InitializeComponent();
		}

		private void FrmCierre_Load(object sender, EventArgs e)
		{
			clsC.frmC = this;
			clsC.CargarInformacionCierre(this);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnCerrar_Click(object sender, EventArgs e)
		{
			DialogResult respuesta = MessageBox.Show(
		   "¿Está seguro de cerrar esta semana?\n\nDespués del cierre ya no podrá modificar la nómina de este período.",
		   "Confirmar cierre",
		   MessageBoxButtons.YesNo,
		   MessageBoxIcon.Question);

			if (respuesta == DialogResult.No)
				return;

			if (clsC.CerrarSemana())
			{
				MessageBox.Show(
					"La semana se cerró correctamente.",
					"Sistema",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				Close();
			}
		}
	}
}
