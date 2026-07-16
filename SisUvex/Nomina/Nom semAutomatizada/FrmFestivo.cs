using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Nomina.Nom_semAutomatizada
{
	public partial class FrmFestivo : Form
	{
		ClsFestivo clsF;
		public string TipoSeleccionado { get; set; }
		public FrmFestivo()
		{
			InitializeComponent();
		}

		private void FrmFestivo_Load(object sender, EventArgs e)
		{

		}

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			if (rbtFDescansado.Checked)
				TipoSeleccionado = "DESCANSO_TRABAJADO";
			else if (rbtFestivoTrabajado.Checked)
				TipoSeleccionado = "TRABAJADO";
			else if (rbtDescansado.Checked)
				TipoSeleccionado = "NO_TRABAJADO";
			else
			{
				MessageBox.Show("Seleccione una opción");
				return;
			}

			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
