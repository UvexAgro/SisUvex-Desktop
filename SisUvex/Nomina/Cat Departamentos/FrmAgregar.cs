using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Nomina.Cat_Departamentos
{
	public partial class FrmAgregar : Form
	{
		public ClsDepartamento cls;
		public FrmAgregar()
		{
			InitializeComponent();

			cls ??= new();
			cls.frmAdd = this;

			StartPosition = FormStartPosition.CenterScreen;

		}

		private void FrmAgregar_Load(object sender, EventArgs e)
		{
			if (cls.IsAddOrModify)
			{
				// AGREGAR
				txbDepartamento.Text = "Escriba el nombre de la cuadrilla";
				txbDepartamento.ForeColor = Color.Gray;

				chkActivo.Checked = true;
			}
			else
			{
				// MODIFICAR
				cls.CargarDatosModificar();
			}

			btnCancelar.Select();
		}

		private void btnAccept_Click(object sender, EventArgs e)
		{
			cls.BtnAccept();
		}

		private void txbDepartamento_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txbDepartamento.Text))
			{
				txbDepartamento.Text = "Escriba el nombre de la cuadrilla";
				txbDepartamento.ForeColor = Color.Gray;
			}
		}

		private void txbDepartamento_Enter(object sender, EventArgs e)
		{
			if (txbDepartamento.Text == "Escriba el nombre de la cuadrilla")
			{
				txbDepartamento.Text = "";
				txbDepartamento.ForeColor = Color.Black;
			}
		}
	}
}
