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
			dtpBeginNormal.ShowUpDown = true;

			dtpEndNormal.Format = DateTimePickerFormat.Custom;
			dtpEndNormal.CustomFormat = "dd/MM/yyyy HH:mm:ss";
			dtpEndNormal.ShowUpDown = true;

			dtpEndExtra.Format = DateTimePickerFormat.Custom;
			dtpEndExtra.CustomFormat = "dd/MM/yyyy HH:mm:ss";
			dtpEndExtra.ShowUpDown = true;
		}

		private void btnAcept_Click(object sender, EventArgs e)
		{
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

		private void dtpDay_ValueChanged(object sender, EventArgs e)
		{
			clsA.ActualizarFecha(dtpBeginNormal);
			clsA.ActualizarFecha(dtpEndNormal);
			clsA.ActualizarFecha(dtpEndExtra);
		}

		private void dtpBeginNormal_ValueChanged(object sender, EventArgs e)
		{
			if (dtpEndNormal.Value < dtpBeginNormal.Value)
				dtpEndNormal.Value = dtpBeginNormal.Value;
		}

		private void dtpEndNormal_ValueChanged(object sender, EventArgs e)
		{
			if (dtpEndExtra.Value < dtpEndNormal.Value)
				dtpEndExtra.Value = dtpEndNormal.Value;
		}

	}
	
}
