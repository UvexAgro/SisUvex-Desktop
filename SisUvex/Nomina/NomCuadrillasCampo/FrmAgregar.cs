using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Nomina.NomCuadrillasCampo
{
	public partial class FrmAgregar : Form
	{
		public ClsCuadrillas cls;
		public FrmAgregar()
		{
			InitializeComponent();
			StartPosition = FormStartPosition.CenterScreen;
			cls = new ClsCuadrillas();
		}

		private void FrmAgregar_Load(object sender, EventArgs e)
		{
			if (cls.IsAddOrModify)
			{
				// AGREGAR
				txbCuadrilla.Text = "Escriba el nombre de la cuadrilla";
				txbCuadrilla.ForeColor = Color.Gray;

				chkActivo.Checked = true;
			}
			else
			{
				// MODIFICAR
				cls.CargarDatosModificar();
			}

			btnCancelar.Select();
		}

		private void txbCuadrilla_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txbCuadrilla.Text))
			{
				txbCuadrilla.Text = "Escriba el nombre de la cuadrilla";
				txbCuadrilla.ForeColor = Color.Gray;
			}
		}

		private void txbCuadrilla_Enter(object sender, EventArgs e)
		{
			if (txbCuadrilla.Text == "Escriba el nombre de la cuadrilla")
			{
				txbCuadrilla.Text = "";
				txbCuadrilla.ForeColor = Color.Black;
			}
		}

		private void btnAccept_Click(object sender, EventArgs e)
		{
			cls.BtnAccept();
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
