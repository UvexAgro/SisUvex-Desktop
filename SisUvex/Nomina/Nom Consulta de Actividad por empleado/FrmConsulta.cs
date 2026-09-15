using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;

namespace SisUvex.Nomina.Nom_Consulta_de_Actividad_por_empleado
{
	public partial class FrmConsulta : Form
	{
		public ClsConsulta cls;
		public FrmConsulta()
		{
			InitializeComponent();
			cls ??= new ClsConsulta();
			cls.frm ??= this;

			this.StartPosition = FormStartPosition.CenterScreen;
		}

		private void FrmConsulta_Load(object sender, EventArgs e)
		{
			cls.CargarSemanas();
		}

		private void cboSemana_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboSemana.SelectedIndex < 0)
				return;

			DataRowView fila = cboSemana.SelectedItem as DataRowView;

			if (fila == null)
				return;

			dtpInicio.Value =
				Convert.ToDateTime(fila["d_startDate_per"]).Date;

			dtpFinal.Value =
				Convert.ToDateTime(fila["d_endDate_per"]).Date;
		}

		private void btnBuscar_Click(object sender, EventArgs e)
		{
			ClsSelectionForm sel = new ClsSelectionForm();

			sel.OpenSelectionForm("EmployeeBasic", "Código");

			if (!string.IsNullOrEmpty(sel.SelectedValue?.ToString()))
			{
				string nuevoCodigo = sel.SelectedValue.Trim();

				string codigosActuales = txbCodigo.Text.Trim();

				if (string.IsNullOrWhiteSpace(codigosActuales))
				{
					txbCodigo.Text = nuevoCodigo;
				}
				else
				{
					txbCodigo.Text =
						codigosActuales + ", " + nuevoCodigo;
				}

				txbCodigo.Focus();
			}
		}

		private void txbCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode != Keys.Enter)
				return;

			e.SuppressKeyPress = true;

			string codigo = txbCodigo.Text.Trim();

			if (string.IsNullOrWhiteSpace(codigo))
			{
				MessageBox.Show(
					"Capture el código del empleado.",
					"Consulta",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				txbCodigo.Focus();
				return;
			}

			// Cargar datos del empleado
			cls.Empleado();

			// Cargar actividades usando el código capturado
			cls.CargarActividadesEmpleado(codigo);

			txbCodigo.Clear();
			txbCodigo.Focus();
		}

		private void btnConsultar_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
