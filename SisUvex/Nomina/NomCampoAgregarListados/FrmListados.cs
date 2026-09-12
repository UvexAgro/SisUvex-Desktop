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

		private void btnQuitar_Click(object sender, EventArgs e)
		{
			if (dgvListado.SelectedRows.Count == 0)
			{
				MessageBox.Show(
					"Seleccione uno o varios empleados.",
					"Quitar empleados",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				return;
			}

			if (dgvCuadrilla.CurrentRow == null)
			{
				MessageBox.Show(
					"Seleccione una cuadrilla.",
					"Quitar empleados",
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

			if (string.IsNullOrWhiteSpace(idCuadrilla))
			{
				MessageBox.Show(
					"No se pudo obtener la cuadrilla.",
					"Quitar empleados",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			// Guardar los códigos de los empleados seleccionados
			List<string> empleadosSeleccionados = new List<string>();

			foreach (DataGridViewRow fila in dgvListado.SelectedRows)
			{
				if (fila.IsNewRow)
					continue;

				string idEmpleado =
					fila.Cells["Codigo"].Value?.ToString();

				if (!string.IsNullOrWhiteSpace(idEmpleado))
				{
					empleadosSeleccionados.Add(idEmpleado);
				}
			}

			if (empleadosSeleccionados.Count == 0)
			{
				MessageBox.Show(
					"No se encontraron empleados seleccionados.",
					"Quitar empleados",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				return;
			}

			DialogResult resultado = MessageBox.Show(
				$"¿Desea quitar {empleadosSeleccionados.Count} empleado(s) seleccionados?",
				"Confirmar eliminación",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			if (resultado != DialogResult.Yes)
				return;

			int eliminados = 0;

			// Eliminar los empleados seleccionados
			foreach (string idEmpleado in empleadosSeleccionados)
			{
				bool eliminado = cls.EliminarEmpleadoCuadrilla(
					idEmpleado,
					idCuadrilla,
					secuenciaSemana,
					fechaInicio,
					fechaFin);

				if (eliminado)
				{
					eliminados++;
				}
			}

			// Recargar la lista
			cls.CargarEmpleadosCuadrilla(
				idCuadrilla,
				secuenciaSemana,
				fechaInicio,
				fechaFin);

			cls.ActualizarTotalEmpleados();

			MessageBox.Show(
				$"Se quitaron {eliminados} empleado(s) correctamente.",
				"Quitar empleados",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information);
		}
	}
}
