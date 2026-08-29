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

			string idCuadrilla =
				dgvCuadrilla.CurrentRow.Cells[0].Value?.ToString();

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

			string idCuadrilla =
				dgvCuadrilla.CurrentRow.Cells["Codigo"].Value?.ToString();

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
					idCuadrilla,
					fecha);

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

			string idCuadrilla =
				dgvCuadrilla.CurrentRow.Cells[0].Value?.ToString();

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

				string idEmpleado =
					fila.Cells[0].Value?.ToString();

				cls.EliminarEmpleadoCuadrilla(
					idEmpleado,
					idCuadrilla,
					fecha
				);
			}

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
			cls.IdCuadrilla =
		dgvCuadrilla.CurrentRow.Cells["Codigo"].Value?.ToString();

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

		private void btnActulizar_Click(object sender, EventArgs e)
		{
			DateTime fechaActual = dtpFecha.Value.Date;

			if (cls.ExistenEmpleadosFecha(fechaActual))
			{
				DialogResult resultado = MessageBox.Show(
					"Ya existen empleados registrados para este día.\n\n" +
					"¿Estás seguro de actualizar nuevamente?",
					"Actualizar nuevamente",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Warning);

				if (resultado != DialogResult.Yes)
					return;
			}

			if (cls.ActualizarCuadrillas(fechaActual))
			{
				string idCuadrilla =
				dgvCuadrilla.CurrentRow.Cells["Codigo"].Value?.ToString();

				cls.CargarEmpleadosCuadrilla(
					idCuadrilla,
					fechaActual
				);

				cls.ActualizarTotalEmpleados();
				cls.MostrarEmpleados();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			FrmAsistencia frm = new FrmAsistencia();

			frm.ShowDialog();
		}
	}
}
