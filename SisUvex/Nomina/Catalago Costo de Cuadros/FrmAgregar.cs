using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisUvex.Nomina.Conceptos_Ingresos_Diversos;

namespace SisUvex.Nomina.Catalago_Costo_de_Cuadros
{
	public partial class FrmAgregar : Form
	{
		internal ClsCostos cls;
		public FrmAgregar()
		{
			InitializeComponent();

			cls ??= new ClsCostos();
			cls.frmA ??= this;
		}

		private void FrmAgregar_Load(object sender, EventArgs e)
		{
		
			cls.CargarLotes();

			if (cls.IsAddOrModify)
			{

				cboLote.SelectedIndex = -1;

				txbLineas.Clear();
				txbCosto.Clear();
				txbPorcentaje.Clear();
			}
			else
			{

				cls.CargarDatosModificar();
				cboLote.Enabled = false;
			}

			btnCancelar.Select();
		}

		private void cboLote_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboLote.SelectedIndex == -1)
				return;

			string idLot = cboLote.SelectedValue?.ToString();
		}

		private void btnAccept_Click(object sender, EventArgs e)
		{
			cls.BtnAccept();
		}
	}
}
