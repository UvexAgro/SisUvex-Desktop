using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.SS.Formula.Functions;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;

namespace SisUvex.Nomina.NomCampoAgregarListados
{
	public partial class FrmAgregar : Form
	{
		public ClsAgregar clsA;
		public FrmListados frm;
		public ClsListados cls;
		public DataGridView DgvEmpleados
		{
			get { return dgvListadoAgregar; }
		}
		public int IdCuadrilla { get; set; }
		public DateTime Fecha { get; set; }
		public bool ModoModificar { get; set; }
		public int IndiceFilaModificar { get; set; }
		public FrmAgregar()
		{
			InitializeComponent();
			txbCodigo.Text = "Ej. 012365";
			txbCodigo.ForeColor = Color.Gray;

			txbCodigo.Enter += txbCodigo_Enter;
			txbCodigo.Leave += txbCodigo_Leave;

			this.Load += FrmAgregar_Load;

			dgvListadoAgregar.CellDoubleClick += dgvListadoAgregar_CellDoubleClick;

			clsA = new ClsAgregar();
			clsA.frmA = this;

			cls = new ClsListados();
			cls.frmA = this;

		}
		private void dgvListadoAgregar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			// Evitar doble clic en el encabezado
			if (e.RowIndex < 0)
				return;

			string empleado = dgvListadoAgregar.Rows[e.RowIndex].Cells["colEmpleado"].Value?.ToString();

			DialogResult respuesta = MessageBox.Show(
				$"¿Desea quitar a {empleado} de la lista?",
				"Quitar empleado",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			if (respuesta != DialogResult.Yes)
				return;

			dgvListadoAgregar.Rows.RemoveAt(e.RowIndex);
		}
		private void txbCodigo_Enter(object sender, EventArgs e)
		{
			if (txbCodigo.Text == "Ej. 012365")
			{
				txbCodigo.Text = "";
				txbCodigo.ForeColor = Color.Black;
			}
		}

		private void txbCodigo_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txbCodigo.Text))
			{
				txbCodigo.Text = "Ej. 012365";
				txbCodigo.ForeColor = Color.Gray;
			}
		}

		private void FrmAgregar_Load(object sender, EventArgs e)
		{

			if (!ModoModificar)
			{
				// El nombre y lugar de pago NO se pueden modificar
				txbEmpleado.Enabled = false;
				cboLugarPago.Enabled = false;
			}
			else
			{
				// En modificar sí se pueden cambiar
				txbEmpleado.Enabled = false; // El nombre tampoco debería editarse
				cboLugarPago.Enabled = true;
				txbCodigo.Enabled = false;
			}

			dgvListadoAgregar.Columns.Clear();

			dgvListadoAgregar.Columns.Add("Codigo", "Código");
			dgvListadoAgregar.Columns.Add("Nombre", "Empleado");
			dgvListadoAgregar.Columns.Add("LugarPago", "Lugar de Pago");
			dgvListadoAgregar.Columns.Add("Actividad", "Actividad");

			dgvListadoAgregar.Columns.Add("IdLugarPago", "IdLugarPago");
			dgvListadoAgregar.Columns.Add("IdActividad", "IdActividad");

			dgvListadoAgregar.Columns["IdLugarPago"].Visible = false;
			dgvListadoAgregar.Columns["IdActividad"].Visible = false;
			clsA.EstiloDgvListadoAgregar();

			clsA.CargarComboActividades();
			clsA.CargarComboLugaresPago();

			if (ModoModificar)
			{
				cls.CargarEmpleadoModificar();
			}

			BeginInvoke(new Action(() =>
			{
				btnAgregarListado.Focus();
			}));

		}

		private void btnContinuar_Click(object sender, EventArgs e)
		{
			if (dgvListadoAgregar.Rows.Count == 0)
			{
				MessageBox.Show(
					"Agregue al menos un empleado.",
					"Empleados",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				return;
			}

			cls.ActualizarEmpleadosCuadrilla(IdCuadrilla, Fecha, dgvListadoAgregar);

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnAgregarListado_Click(object sender, EventArgs e)
		{
			if (ModoModificar)
			{
				clsA.ModificarEmpleado();
				return;
			}

			clsA.btnAgregarVariosEmpleados();
		}
	}
}
