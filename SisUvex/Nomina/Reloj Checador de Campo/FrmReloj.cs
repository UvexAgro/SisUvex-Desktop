using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisUvex.Nomina.NomCuadrillasCampo;

namespace SisUvex.Nomina.Reloj_Checador_de_Campo
{
	public partial class FrmReloj : Form
	{
		internal ClsReloj cls;
		public FrmReloj()
		{
			InitializeComponent();
			cls = new ClsReloj();
			cls.frm = this;
		}
		private void HasEditCatalogsPermission() //metodo para dar permisos al usuario 
		{
			if (User.HasEditCatalogsPermission())
				return;

			txbCodigo.Enabled = false;
			btnConsultar.Enabled = false;
		}
		private void FrmReloj_Load(object sender, EventArgs e)
		{
			HasEditCatalogsPermission();
		}

		private void txbCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode != Keys.Enter)
				return;

			e.SuppressKeyPress = true;

			// Obtener el código como texto y completar a 6 dígitos
			string codigo = txbCodigo.Text.Trim();

			if (string.IsNullOrWhiteSpace(codigo))
			{
				MessageBox.Show("Ingresa un código de empleado.");
				txbCodigo.Focus();
				return;
			}

			codigo = codigo.PadLeft(6, '0');

			ClsReloj reloj = new ClsReloj();

			// Buscar empleado por código
			var empleado = reloj.ObtenerEmpleado(codigo);

			if (!empleado.Item1)
			{
				txbEmpleado.Clear();
				MessageBox.Show("No se encontró el empleado.");
				txbCodigo.Focus();
				txbCodigo.SelectAll();
				return;
			}

			// Mostrar nombre completo
			txbEmpleado.Text = empleado.Item2 ?? "";

			// Consultar checadas según código y fecha seleccionada
			DataTable dt = reloj.ObtenerChecadas(
				codigo,
				dateTimePicker1.Value.Date
			);

			dgvLista.DataSource = dt;
			cls.ConfigurarGridReloj();
		}

		private void btnConsultar_Click(object sender, EventArgs e)
		{
			ClsReloj reloj = new ClsReloj();

			DataTable dt = reloj.ObtenerChecadas(
				null,
				dateTimePicker1.Value.Date
			);

			dgvLista.DataSource = dt;

			cls.ConfigurarGridReloj();

			if (dt.Rows.Count == 0)
			{
				MessageBox.Show(
					"No hay checadas registradas para esa fecha.",
					"Reloj checador",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
		}
	}
}
