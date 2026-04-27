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

namespace SisUvex.Nomina.Reporte_de_horas
{
	public partial class FrmAñadir : Form
	{
		public bool IsAddModify = true, AddIsUpdate = false;
		public string? idModify;
		ClsAñadir clsA;
		FrmPackingHours frmPacki;
		public FrmAñadir(FrmPackingHours frmPacking, ClsAñadir clsAdd)
		{
			InitializeComponent();
			clsA = clsAdd;
			frmPacki = frmPacking;


		}

		private void FrmAñadir_Load(object sender, EventArgs e)
		{
			dtpBeginNormal.Format = DateTimePickerFormat.Custom;
			dtpBeginNormal.CustomFormat = "dd/MM/yyyy HH:mm:ss";

			dtpEndNormal.Format = DateTimePickerFormat.Custom;
			dtpEndNormal.CustomFormat = "dd/MM/yyyy HH:mm:ss";

			dtpEndExtra.Format = DateTimePickerFormat.Custom;
			dtpEndExtra.CustomFormat = "dd/MM/yyyy HH:mm:ss";
			clsA.CargarCuadrillasCheckList();

			if (IsAddModify)
			{
				DateTime cero = DateTime.Today;

				dtpComidaInicial.Value = cero;
				dtpComidaFinal.Value = cero;

				dtpCenaInicial.Value = cero;
				dtpCenaFinal.Value = cero;

				dtpDescansoInicial.Value = cero;
				dtpDescansoFinal.Value = cero;

				dtpD2.Value = cero;
				dtpDf2.Value = cero;
			}
		}

		private void btnAcept_Click(object sender, EventArgs e)
		{
			//  NORMAL
			DateTime inicioNormal = dtpBeginNormal.Value;
			DateTime finNormal = dtpEndNormal.Value;

			//  SI CRUZA DE DÍA
			if (finNormal <= inicioNormal)
			{
				DialogResult res = MessageBox.Show(
					"El turno normal pasa al siguiente día.\n\n¿Desea continuar?",
					"Turno nocturno",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question
				);

				if (res == DialogResult.No)
					return;
			}

			//  EXTRA
			DateTime inicioExtra = finNormal;
			DateTime finExtra = dtpEndExtra.Value;

			bool tieneExtra = nudOvertime.Value > 0;

			// VALIDAR SOLO SI HAY EXTRA
			if (tieneExtra)
			{
				if (finExtra <= inicioExtra)
				{
					DialogResult res = MessageBox.Show(
						"La hora extra pasa al siguiente día.\n\n¿Desea continuar?",
						"Turno nocturno",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Question
					);

					if (res == DialogResult.No)
						return;
				}
			}

			// YA NO VALIDES 00:00:00 ❌
			// (esa línea se elimina completamente)

			// EJECUCIÓN
			if (IsAddModify)
			{
				clsA.AddProcedure();
			}
			else
			{
				clsA.UpdateProcedure();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{

			this.Close();
		}

		private void dtpBeginNormal_ValueChanged(object sender, EventArgs e)
		{
			clsA.AjustarTurno(dtpBeginNormal, dtpEndNormal);
		}

		private void dtpEndNormal_ValueChanged(object sender, EventArgs e)
		{
			clsA.AjustarTurno(dtpEndNormal, dtpEndExtra);
		}

		private void dtpDay_ValueChanged(object sender, EventArgs e)
		{
			dtpBeginNormal.Value = dtpDay.Value;
			dtpEndNormal.Value = dtpBeginNormal.Value;
			dtpEndExtra.Value = dtpEndNormal.Value;
		}

		private void dtpDinicial2_ValueChanged(object sender, EventArgs e)
		{
			clsA.CalcularHoras(dtpComidaInicial, dtpComidaFinal, nudComidaHora);
		}

		private void dtpComidaFinal_ValueChanged(object sender, EventArgs e)
		{
			clsA.CalcularHoras(dtpComidaInicial, dtpComidaFinal, nudComidaHora);
		}

		private void dtpCenaInicial_ValueChanged(object sender, EventArgs e)
		{
			clsA.CalcularHoras(dtpCenaInicial, dtpCenaFinal, nudCenaHora);
		}

		private void dtpCenaFinal_ValueChanged(object sender, EventArgs e)
		{
			clsA.CalcularHoras(dtpCenaInicial, dtpCenaFinal, nudCenaHora);
		}

		private void dtpDescansoInicial_ValueChanged(object sender, EventArgs e)
		{
			clsA.CalcularHoras(dtpDescansoInicial, dtpDescansoFinal, nudHorasDescanso);
		}

		private void dtpDescansoFinal_ValueChanged(object sender, EventArgs e)
		{
			clsA.CalcularHoras(dtpDescansoInicial, dtpDescansoFinal, nudHorasDescanso);
		}

		private void dtpD2_ValueChanged(object sender, EventArgs e)
		{
			clsA.CalcularHoras(dtpD2, dtpDf2, nudD2);
		}

		private void dtpDf2_ValueChanged(object sender, EventArgs e)
		{
			clsA.CalcularHoras(dtpD2, dtpDf2, nudD2);
		}
	}

}
