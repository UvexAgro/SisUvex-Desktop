using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisUvex.Catalogos.GTIN;
using SisUvex.Catalogos.GTIN_UPC;
using SisUvex.Nomina.Conceptos_Ingresos_Diversos;

namespace SisUvex.Nomina.Work_time
{
	internal partial class FrmWorkTimeAdd : Form
	{
		ClsWorkTime cls;
		FrmWorkTimeCat frmCat;
		public bool IsAddModify = true, AddIsUpdate = false;
		public string? idModify;
		public FrmWorkTimeAdd(FrmWorkTimeCat frmCatalog, ClsWorkTime clsClass)
		{
			InitializeComponent();
			cls = clsClass;
			frmCat = frmCatalog;
		}

		private void FrmWorkTimeAdd_Load(object sender, EventArgs e)
		{
			dtpBeginNormal.CustomFormat = "dd/MM/yyyy HH:mm:ss";
			dtpEndNormal.CustomFormat = "dd/MM/yyyy HH:mm:ss";
			dtpEndExtra.CustomFormat = "dd/MM/yyyy HH:mm:ss";
			cls.BeginFormAdd();

			dtpBeginNormal.MinDate = dtpDay.Value;
			dtpEndNormal.MinDate = dtpBeginNormal.Value;
			dtpEndExtra.MinDate = dtpEndNormal.Value;
			cls.CargarCuadrillasCheckList();

			if (IsAddModify)
			{
				DateTime cero = DateTime.Today;

				dtpComidaInicial.Value = cero;
				dtpComidaFinal.Value = cero;

				dtpCenaInicial.Value = cero;
				dtpCenaFinal.Value = cero;

				dtpDescansoInicial.Value = cero;
				dtpDescansoFinal.Value = cero;

				dtpDinicial2.Value = cero;
				dtpFinalD2.Value = cero;
			}
		}

		private void btnAcept_Click(object sender, EventArgs e)
		{
			cls.btnAcceptAddModify();
			if (AddIsUpdate)
				cls.LoadDgvCatalog();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void dtpDay_ValueChanged(object sender, EventArgs e)
		{
			dtpBeginNormal.MinDate = dtpDay.Value;
			//if (dtpDay.Value > dtpBeginNormal.Value)
			//{
			dtpBeginNormal.Value = dtpDay.Value;
			//}

		}
		private void dtpBeginNormal_ValueChanged(object sender, EventArgs e)
		{
			dtpEndNormal.MinDate = dtpBeginNormal.Value;
			//if (dtpBeginNormal.Value > dtpEndNormal.Value)
			//{
			dtpEndNormal.Value = dtpBeginNormal.Value;
			//}


		}
		private void dtpEndNormal_ValueChanged(object sender, EventArgs e)
		{
			dtpEndExtra.MinDate = dtpEndNormal.Value;
			//if (dtpEndNormal.Value > dtpEndExtra.Value)
			//{
			dtpEndExtra.Value = dtpEndNormal.Value;
			//}
		}

		private void dtpComidaInicial_ValueChanged(object sender, EventArgs e)
		{
			cls.CalcularHoras(dtpComidaInicial, dtpComidaFinal, nudComidaHora);
		}

		private void dtpComidaFinal_ValueChanged(object sender, EventArgs e)
		{
			cls.CalcularHoras(dtpComidaInicial, dtpComidaFinal, nudComidaHora);
		}

		private void dtpCenaInicial_ValueChanged(object sender, EventArgs e)
		{
			cls.CalcularHoras(dtpCenaInicial, dtpCenaFinal, nudCenaHora);
		}

		private void dtpCenaFinal_ValueChanged(object sender, EventArgs e)
		{
			cls.CalcularHoras(dtpCenaInicial, dtpCenaFinal, nudCenaHora);
		}

		private void dtpDescansoInicial_ValueChanged(object sender, EventArgs e)
		{
			cls.CalcularHoras(dtpDescansoInicial, dtpDescansoFinal, nudHorasDescanso);
		}

		private void dtpDescansoFinal_ValueChanged(object sender, EventArgs e)
		{
			cls.CalcularHoras(dtpDescansoInicial, dtpDescansoFinal, nudHorasDescanso);
		}

		private void dtpDinicial2_ValueChanged(object sender, EventArgs e)
		{
			cls.CalcularHoras(dtpDinicial2, dtpFinalD2, nudHorasD2);
		}

		private void dtpFinalD2_ValueChanged(object sender, EventArgs e)
		{
			cls.CalcularHoras(dtpDinicial2, dtpFinalD2, nudHorasD2);
		}

		private void FrmWorkTimeAdd_Shown(object sender, EventArgs e)
		{
			if (IsAddModify)
			{
				DateTime cero = DateTime.Today;

				// COMIDA
				dtpComidaInicial.Value = cero;
				dtpComidaFinal.Value = cero;
				dtpComidaInicial.Checked = false;
				dtpComidaFinal.Checked = false;

				// CENA
				dtpCenaInicial.Value = cero;
				dtpCenaFinal.Value = cero;
				dtpCenaInicial.Checked = false;
				dtpCenaFinal.Checked = false;

				// DESCANSO
				dtpDescansoInicial.Value = cero;
				dtpDescansoFinal.Value = cero;
				dtpDescansoInicial.Checked = false;
				dtpDescansoFinal.Checked = false;

				// DESCANSO 2
				dtpDinicial2.Value = cero;
				dtpFinalD2.Value = cero;
				dtpDinicial2.Checked = false;
				dtpFinalD2.Checked = false;

				// HORAS
				nudComidaHora.Value = 0;
				nudCenaHora.Value = 0;
				nudHorasDescanso.Value = 0;
				nudHorasD2.Value = 0;
			}
		}
	}
}

