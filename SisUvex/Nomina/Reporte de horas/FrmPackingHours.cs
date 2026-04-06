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
		ClsAñadir clsA;
		bool isLoaded = false;

		public FrmPackingHours()
		{
			InitializeComponent();
		}

		private void FrmPackingHours_Load(object sender, EventArgs e)
		{
			cls ??= new();
			cls.frmPacki ??= this;


			clsA ??= new();
			clsA.frmPacki ??= this;

			cls.CargarPeriodos();

			cls.CargarTemporada();
			clsA.CargarHorasInicial();

			isLoaded = true;
		}

		private void cboFinal_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboFinal.SelectedIndex < cboSemana.SelectedIndex)
			{
				cboFinal.SelectedIndex = cboSemana.SelectedIndex;
			}
			clsA.CargarHorasInicial();
		}

		private void cboSemana_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!isLoaded) return;

			if (cboFinal.Items.Count == 0) return;

			int index = cboSemana.SelectedIndex;

			if (index >= 0 && index < cboFinal.Items.Count)
			{
				cboFinal.SelectedIndex = index;
			}

			clsA.CargarHorasInicial();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			clsA.OpenFrmAdd();
		}

		private void btnModify_Click(object sender, EventArgs e)
		{
			clsA.OpenFrmModify();
		}
	}
}
