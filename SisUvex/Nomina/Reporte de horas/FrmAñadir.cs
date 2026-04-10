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

			dtpEndNormal.Format = DateTimePickerFormat.Custom;
			dtpEndNormal.CustomFormat = "dd/MM/yyyy HH:mm:ss";

			dtpEndExtra.Format = DateTimePickerFormat.Custom;
			dtpEndExtra.CustomFormat = "dd/MM/yyyy HH:mm:ss";
			clsA.CargarCuadrillasCheckList();
		}

		private void btnAcept_Click(object sender, EventArgs e)
		{
		
			//  Validar si cruza de día
			if (dtpEndExtra.Value.Date > dtpBeginNormal.Value.Date)
			{
				DialogResult res = MessageBox.Show(
					"El horario de fin extra pasa al siguiente día.\n\n¿Desea continuar?",
					"Turno nocturno",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question
				);

				if (res == DialogResult.No)
				{
					return; 
				}
			}

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
	}

}
