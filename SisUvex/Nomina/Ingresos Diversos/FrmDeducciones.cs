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
using SisUvex.Catalogos.Metods.TextBoxes;
using static SisUvex.Catalogos.Metods.ClsObject;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Nomina.Conceptos_Ingresos_Diversos;


namespace SisUvex.Nomina.Ingresos_Diversos
{
	public partial class FrmDeducciones : Form
	{
		ClsDeducciones cls;

		public bool Edicion = false;

		public string IdDeductions = null;
		public decimal? Descuento = null;

		public string IdAttendence;

		public string IdWorkGroupEmployeeDaily;
		public bool EsCampo { get; set; }
		public List<string> IdsAttendence;


		public FrmDeducciones(string idAttendence, string idWorkGroupEmployeeDaily, string idDeductions, decimal montoD, bool esCampo)
		{
			InitializeComponent();

			IdAttendence = idAttendence;
			IdWorkGroupEmployeeDaily = idWorkGroupEmployeeDaily;

			IdDeductions = idDeductions;
			Descuento = montoD;

			Edicion = true;
			EsCampo = esCampo;

			cls = new ClsDeducciones();
			cls.frmDeu = this;
		}
		public FrmDeducciones(string idAttendence)
		{
			InitializeComponent();

			IdAttendence = idAttendence;

			Edicion = false;
			EsCampo = false;

			cls = new ClsDeducciones();
			cls.frmDeu = this;
		}

		public FrmDeducciones(List<string> ids, bool esCampo)
		{
			InitializeComponent();

			IdsAttendence = ids;

			Edicion = false;
			EsCampo = esCampo;

			cls = new ClsDeducciones();
			cls.frmDeu = this;
		}

		private void FrmDeducciones_Load(object sender, EventArgs e)
		{
			cls ??= new ClsDeducciones();

			cls.CboDeducciones(cboDeducciones);

			ClsTextBoxes.TxbApplyKeyPressEventNumericWithLimit(txbMmodificarD, 9, 2);

			if (Edicion)
			{
				this.Text = "Modificar Deduccion";
				btnAcceptD.Text = "Actualizar";
				lblAdd.Text = "Modificar Deduccion";

				cboDeducciones.SelectedValue = IdDeductions;
				cboDeducciones_SelectedIndexChanged(null, null);
			}
			else
			{
				this.Text = "Añadir Deduccion";
				btnAcceptD.Text = "Guardar";
				lblAdd.Text = "Añadir Deduccion";

				if (cboDeducciones.Items.Count > 0)
				{
					cboDeducciones.SelectedIndex = 0;
					cboDeducciones_SelectedIndexChanged(null, null);
				}
			}
		}

		private void cboDeducciones_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboDeducciones.SelectedIndex <= 0) return;

			txbMontoDeduccion.Text = cboDeducciones.GetColumnValue("Descuento").ToString();

		}

		private void btnCancelD_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnAcceptD_Click(object sender, EventArgs e)
		{
			if (!(cboDeducciones.SelectedValue is string))
			{
				MessageBox.Show("Debe seleccionar un concepto válido");
				return;
			}

			if (Edicion)
				cls.ActualizarDeducciones();
			else
				cls.InsertarDeducciones();

			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
