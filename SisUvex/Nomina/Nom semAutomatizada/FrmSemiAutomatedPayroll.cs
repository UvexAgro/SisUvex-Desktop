using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using SisUvex.Catalogos.Metods.Querys;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Nomina.Nom_semAutomatizada
{
	public partial class FrmSemiAutomatedPayroll : Form
	{
		ClsSemiAutomatedPayroll cls;
		ClsFestivo clsF;
		public string TipoFestivoSeleccionado = "";

		public FrmSemiAutomatedPayroll()
		{
			InitializeComponent();
		}

		private void FrmSemiAutomatedPayroll_Load(object sender, EventArgs e)
		{
			cls ??= new();
			cls.frm ??= this;
			clsF ??= new ClsFestivo();
			clsF.frm = this;
			cls.BeginForm();
			//rbtEsparrago.Checked = true;
		}

		private void btnCVS_Click(object sender, EventArgs e)
		{
			cls.BtnCsv();
		}



		public void dtpFecha_ValueChanged(object sender, EventArgs e)
		{
			cls.SetTxbReferencia();
		}

		private void btncargar_Click(object sender, EventArgs e)
		{
			cls.BtnCargarDatos();

		}

		private void btnExcel_Click(object sender, EventArgs e)
		{
			if (dgvEmployee.Rows.Count > 0)
			{
				DataTable dt = (DataTable)dgvEmployee.DataSource;
				cls.ExportarExcel(dt);
			}
			else
				SystemSounds.Exclamation.Play();
		}

		private void btnCalcularLibra_Click(object sender, EventArgs e)
		{
			cls.EjecutarCalculoProduccion();
		}

		private void btnFestivos_Click(object sender, EventArgs e)
		{
			DateTime fecha = dtpFecha.Value;

			if (!clsF.EsFestivo(fecha))
			{
				MessageBox.Show("No es un día festivo.");
				return;
			}
			FrmFestivo frmFestivo = new FrmFestivo();

			if (frmFestivo.ShowDialog() == DialogResult.OK)
			{
				TipoFestivoSeleccionado = frmFestivo.TipoSeleccionado;

			}

			clsF.BtnCargarDatos();
		}
	}
}

