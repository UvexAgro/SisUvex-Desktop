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
using SisUvex.Nomina.NomCampoAgregarListados;

namespace SisUvex.Nomina.Generar_Recibos_de_Nomina
{
	public partial class FrmRecibos : Form
	{
		public ClsRecibos cls;
		public ClsGeneraraPdf clsG;
		public FrmRecibos()
		{
			InitializeComponent();

			cls = new ClsRecibos();
			cls.frm = this;

			clsG = new ClsGeneraraPdf();
			clsG.frm = this;

		}

		private void FrmRecibos_Load(object sender, EventArgs e)
		{
			cboOrdenar.Items.Clear();

			cboOrdenar.Items.Add("Alfabético (Apellidos)");
			cboOrdenar.Items.Add("Numérico (Código)");

			cboOrdenar.SelectedIndex = 0;

			cboDireccion.Items.Clear();

			cboDireccion.Items.Add("Ascendente (A-Z)");
			cboDireccion.Items.Add("Descendente (Z-A)");

			cboDireccion.SelectedIndex = 0;

			cls.CargarSemanas();
			cls.CargarLugarPago(cboLugarPago);
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
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;

				// Buscar el nombre del empleado
				cls.BuscarEmpleadoPorCodigo();

				// Si existe el empleado, consultar sus recibos
				if (!string.IsNullOrWhiteSpace(txbNombre.Text))
				{
					cls.ConsultarRecibos();
				}
			}
		}

		private void btnConsultar_Click(object sender, EventArgs e)
		{
			cls.ConsultarRecibos();
		}

		private void btnLimpiar_Click(object sender, EventArgs e)
		{
			// Limpiar DataGridView
			dgvRecibo.DataSource = null;
			dgvRecibo.Rows.Clear();

			// Limpiar datos del empleado
			txbCodigo.Clear();
			txbNombre.Clear();

			// Quitar selección
			dgvRecibo.ClearSelection();

			// Regresar el cursor al código
			txbCodigo.Focus();
		}

		private void btnPdf_Click(object sender, EventArgs e)
		{
			clsG.GenerarPDF();
		}
	}
}
