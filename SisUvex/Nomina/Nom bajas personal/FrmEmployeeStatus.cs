using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Nomina.Nom_bajas_personal
{
	public partial class FrmEmployeeStatus : Form
	{
		public ClsEmployeeStatus cls;
		public FrmEmployeeStatus()
		{
			InitializeComponent();
			cls = new();
			cls.frm = this;
		}

		private void FrmEmployeeStatus_Load(object sender, EventArgs e)
		{
			cls.CargarTemporada();

			if (cboTemporada.SelectedValue != null &&
			int.TryParse(cboTemporada.SelectedValue.ToString(), out int idSeason))
			{
				cls.CargarCuadrillas(cboCuadrilla, idSeason);
			}
			this.BeginInvoke(new Action(() =>
			{
				cboTemporada.Focus();
			}));
		}

		private void cboTemporada_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cls.cargando)
				return;

			if (cboTemporada.SelectedValue == null)
				return;

			if (cboTemporada.SelectedValue is DataRowView)
				return;

			cls.CargarCuadrillas(
				cboCuadrilla,
				Convert.ToInt32(cboTemporada.SelectedValue));
		}

		private void btnMostrar_Click(object sender, EventArgs e)
		{
			cls.CargarEmpleados();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DateTime fechaBaja = dtpFecha.Value.Date;

			foreach (DataGridViewRow row in dgvCatalog.Rows)
			{
				object valor = row.Cells["Seleccionar"].Value;

				bool seleccionado = valor != DBNull.Value &&
									valor != null &&
									Convert.ToBoolean(valor);

				if (seleccionado)
				{
					string idEmpleado = row.Cells["Código"].Value.ToString();

					cls.ActualizarFechaBaja(idEmpleado, fechaBaja);
				}
			}
			cls.CargarEmpleados	();		

			MessageBox.Show("Las bajas se guardaron correctamente.");
		}

		private void txbEmpleado_TextChanged(object sender, EventArgs e)
		{
			cls.BuscarEmpleado(txbEmpleado.Text);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow row in dgvCatalog.Rows)
			{
				object valor = row.Cells["Seleccionar"].Value;

				bool seleccionado = valor != null &&
									valor != DBNull.Value &&
									Convert.ToBoolean(valor);

				if (seleccionado)
				{
					string idEmpleado = row.Cells["Código"].Value.ToString();

					cls.EliminarFechaBaja(idEmpleado);
				}
			}

			cls.CargarEmpleados();

			MessageBox.Show("La baja se eliminó correctamente.");
		}
	}
}
