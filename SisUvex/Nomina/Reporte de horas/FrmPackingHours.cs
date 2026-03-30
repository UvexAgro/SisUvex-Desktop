using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Nomina.Reporte_de_horas
{
	public partial class FrmPackingHours : Form
	{
		ClSPackingHours cls;
		public FrmPackingHours()
		{
			InitializeComponent();
		}

		private void FrmPackingHours_Load(object sender, EventArgs e)
		{
			cls ??= new();
			cls.frmPacki ??= this;

			cls.CargarPeriodos();

			cls.CargarTemporada();

			cls.CargarHoras();
		}

		private void cboFinal_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboFinal.SelectedIndex < cboSemana.SelectedIndex)
			{
				cboFinal.SelectedIndex = cboSemana.SelectedIndex;
			}
			cls.CargarHoras();
		}

		private void cboSemana_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboFinal.Items.Count == 0) return;

			int index = cboSemana.SelectedIndex;

			if (index >= 0 && index < cboFinal.Items.Count)
			{
				cboFinal.SelectedIndex = index;
			}
			cls.CargarHoras();
		}
	}
}
