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
		public ClsAsistencia _clsA;
		public FrmListados()
		{
			InitializeComponent();
			cls = new ClsListados();
			cls.frm = this;

			_clsA = new ClsAsistencia();
			_clsA.frm = this;
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
			cls.CargarSemanas();
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

			if (!ObtenerSemanaSeleccionada(
				out string secuenciaSemana,
				out DateTime fechaInicio,
				out DateTime fechaFin))
			{
				return;
			}

			string idCuadrilla =
				dgvCuadrilla.CurrentRow.Cells["Codigo"].Value?.ToString();

			string nombreCuadrilla =
				dgvCuadrilla.CurrentRow.Cells[1].Value?.ToString();

			lblCuadrilla.Text = nombreCuadrilla;

			cls.CargarEmpleadosCuadrilla(
				idCuadrilla,
				secuenciaSemana,
				fechaInicio,
				fechaFin);

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

			if (!ObtenerSemanaSeleccionada(
			out string secuenciaSemana,
			out DateTime fechaInicio,
			out DateTime fechaFin))
			{
				return;
			}

			string idCuadrilla =
				dgvCuadrilla.CurrentRow.Cells["Codigo"].Value?.ToString();

			FrmAgregar frmAgregar = new FrmAgregar();

			frmAgregar.IdCuadrilla = idCuadrilla;
			frmAgregar.FechaInicio = fechaInicio;
			frmAgregar.FechaFin = fechaFin;
			frmAgregar.SecuenciaSemana = secuenciaSemana;

			if (frmAgregar.ShowDialog() == DialogResult.OK)
			{
				pnlSinEmpleados.Visible = false;
				dgvListado.Visible = true;

				cls.CargarEmpleadosCuadrilla(
					idCuadrilla,
					secuenciaSemana,
					fechaInicio,
					fechaFin);

				cls.ActualizarTotalEmpleados();
			}
		}

		private void btnImprimir_Click(object sender, EventArgs e)
		{
			cls.ImprimirListado();
		}

		private void btnQuitar_Click(object sender, EventArgs e)
		{
			if (dgvListado.CurrentRow == null)
			{
				MessageBox.Show(
					"Seleccione un empleado.",
					"Quitar empleado",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				return;
			}

			if (!ObtenerSemanaSeleccionada(
				out string secuenciaSemana,
				out DateTime fechaInicio,
				out DateTime fechaFin))
			{
				return;
			}

			string idEmpleado =
				dgvListado.CurrentRow.Cells["Codigo"].Value?.ToString();

			string idCuadrilla =
				dgvCuadrilla.CurrentRow.Cells["Codigo"].Value?.ToString();

			if (string.IsNullOrWhiteSpace(idEmpleado) ||
				string.IsNullOrWhiteSpace(idCuadrilla))
			{
				MessageBox.Show(
					"No se pudo obtener el empleado o la cuadrilla.",
					"Quitar empleado",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			bool eliminado = cls.EliminarEmpleadoCuadrilla(
				idEmpleado,
				idCuadrilla,
				secuenciaSemana,
				fechaInicio,
				fechaFin);
			if (eliminado)
			{
				MessageBox.Show(
					"Empleado quitado correctamente.",
					"Quitar empleado",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				cls.CargarEmpleadosCuadrilla(
					idCuadrilla,
					secuenciaSemana,
					fechaInicio,
					fechaFin);

				cls.ActualizarTotalEmpleados();
			}
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

			if (!ObtenerSemanaSeleccionada(
				out string secuenciaSemana,
				out DateTime fechaInicio,
				out DateTime fechaFin))
			{
				return;
			}

			string idCuadrilla =
				dgvCuadrilla.CurrentRow.Cells["Codigo"].Value?.ToString();

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

			// Abrir formulario en modo modificar
			cls.OpenFrmModify(
				idEmpleado,
				idCuadrilla,
				secuenciaSemana,
				fechaInicio,
				fechaFin);

			// Si se modificó correctamente, recargar la lista
			if (cls.frmA != null &&
				cls.frmA.DialogResult == DialogResult.OK)
			{
				cls.CargarEmpleadosCuadrilla(
					idCuadrilla,
					secuenciaSemana,
					fechaInicio,
					fechaFin);

				cls.ActualizarTotalEmpleados();
			}
		}
		

		private void btnActulizar_Click(object sender, EventArgs e)
		{
			cls.btnCopiarDatosDeLaSemanaAnterior();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			FrmAsistencia frm = new FrmAsistencia();

			frm.ShowDialog();
		}
		public bool ObtenerSemanaSeleccionada(out string secuenciaSemana, out DateTime fechaInicio, out DateTime fechaFin)
		{
			secuenciaSemana = "";
			fechaInicio = DateTime.MinValue;
			fechaFin = DateTime.MinValue;

			DataRowView semana = cboSemana.SelectedItem as DataRowView;

			if (semana == null)
			{
				MessageBox.Show(
					"Seleccione una semana.",
					"Semana",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				return false;
			}

			secuenciaSemana =
				semana["c_sequence_per"]?.ToString();

			fechaInicio =
				Convert.ToDateTime(semana["d_startDate_per"]);

			fechaFin =
				Convert.ToDateTime(semana["d_endDate_per"]);

			return true;
		}
	}
}
