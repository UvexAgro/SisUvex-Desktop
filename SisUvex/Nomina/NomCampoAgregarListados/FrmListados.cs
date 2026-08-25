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

namespace SisUvex.Nomina.NomCampoAgregarListados
{
	public partial class FrmListados : Form
	{
		public ClsListados cls;
		public FrmListados()
		{
			InitializeComponent();
			cls = new ClsListados();
			cls.frm = this;
			cls.CrearColumnasListado();
			cls.EstiloDgvListado();

		}
		private void HasEditCatalogsPermission() //metodo para dar permisos al usuario 
		{
			if (User.HasEditCatalogsPermission())
				return;
			btnMostrar.Enabled = false;
		}
		private void FrmListados_Load(object sender, EventArgs e)
		{
			cls.CargarCuadrillas();
			cls.EstiloDgvCuadrilla();
			HasEditCatalogsPermission();
		}

		private void btnMostrar_Click(object sender, EventArgs e)
		{
			if (dgvCuadrilla.CurrentRow == null)
			{
				MessageBox.Show(
					"Primero seleccione una cuadrilla.",
					"Cuadrilla",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				return;
			}

			int idCuadrilla = Convert.ToInt32(
				dgvCuadrilla.CurrentRow.Cells[0].Value
			);

			string nombreCuadrilla =
				dgvCuadrilla.CurrentRow.Cells[1].Value.ToString();

			lblCuadrilla.Text = nombreCuadrilla;

			cls.CargarEmpleadosCuadrilla(
				idCuadrilla,
				dtpFecha.Value.Date
			);
			cls.ActualizarTotalEmpleados();
			cls.MostrarEmpleados();
		}


		private void btnAgregar_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(lblCuadrilla.Text))
			{
				MessageBox.Show(
					"Primero seleccione una cuadrilla.",
					"Cuadrilla",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				return;
			}

			int idCuadrilla = Convert.ToInt32(
				dgvCuadrilla.CurrentRow.Cells["Codigo"].Value
			);

			DateTime fecha = dtpFecha.Value.Date;

			FrmAgregar frmAgregar = new FrmAgregar();

			// Enviar cuadrilla y fecha a FrmAgregar
			frmAgregar.IdCuadrilla = idCuadrilla;
			frmAgregar.Fecha = fecha;

			if (frmAgregar.ShowDialog() == DialogResult.OK)
			{
				// Quitar el panel
				pnlSinEmpleados.Visible = false;

				// Mostrar la DGV
				dgvListado.Visible = true;

				// Cargar nuevamente los empleados
				cls.CargarEmpleadosCuadrilla(
					Convert.ToInt32(
						dgvCuadrilla.CurrentRow.Cells["Codigo"].Value),
					dtpFecha.Value.Date);

				// Actualizar total
				cls.ActualizarTotalEmpleados();
			}
		}

		private void btnImprimir_Click(object sender, EventArgs e)
		{
			cls.ImprimirListado();
		}

		private void btnQuitar_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(lblCuadrilla.Text))
			{
				MessageBox.Show(
					"Primero seleccione una cuadrilla.",
					"Cuadrilla",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				return;
			}

			if (dgvListado.SelectedRows.Count == 0)
			{
				MessageBox.Show(
					"Seleccione al menos un empleado para quitar.",
					"Quitar empleado",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				return;
			}

			int idCuadrilla = Convert.ToInt32(
				dgvCuadrilla.CurrentRow.Cells[0].Value
			);

			int cantidad = dgvListado.SelectedRows.Count;

			DialogResult respuesta = MessageBox.Show(
				$"¿Está seguro de quitar {cantidad} empleado(s) de la cuadrilla?",
				"Quitar empleados",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			if (respuesta != DialogResult.Yes)
				return;

			DateTime fecha = dtpFecha.Value.Date;

			foreach (DataGridViewRow fila in dgvListado.SelectedRows)
			{
				if (fila.IsNewRow)
					continue;

				int idEmpleado = Convert.ToInt32(
					fila.Cells[0].Value
				);

				cls.EliminarEmpleadoCuadrilla(
					idEmpleado,
					idCuadrilla,
					fecha
				);
			}

			// Volver a cargar desde la base de datos
			cls.CargarEmpleadosCuadrilla(
				idCuadrilla,
				fecha
			);

			cls.ActualizarTotalEmpleados();

		}

		private void btnModificar_Click(object sender, EventArgs e)
		{
			if (dgvListado.CurrentRow == null)
			{
				MessageBox.Show(
					"Seleccione un empleado.",
					"Modificar empleado",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				return;
			}

			string idEmpleado =
				dgvListado.CurrentRow.Cells["Codigo"].Value?.ToString();

			if (string.IsNullOrWhiteSpace(idEmpleado))
			{
				MessageBox.Show(
					"No se pudo obtener el código del empleado.",
					"Modificar empleado",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			// Guardar los datos necesarios para la consulta
			cls.IdCuadrilla = Convert.ToInt32(
				dgvCuadrilla.CurrentRow.Cells["Codigo"].Value
			);

			cls.Fecha = dtpFecha.Value.Date;

			// Abrir formulario en modo modificar
			cls.OpenFrmModify(idEmpleado);

			// Si se modificó correctamente, recargar la lista
			if (cls.frmA.DialogResult == DialogResult.OK)
			{
				cls.CargarEmpleadosCuadrilla(
					cls.IdCuadrilla,
					cls.Fecha
				);

				cls.ActualizarTotalEmpleados();
			}
		}
	}
}
