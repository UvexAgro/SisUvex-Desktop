using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods.Querys;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Nomina.Nom_de_aplicadores
{
	public partial class FrmAplicadores : Form
	{
		internal ClsAplicadores cls;
		public int maxCantidadLineas = 0;

		public FrmAplicadores()
		{
			InitializeComponent();
			cls ??= new();
			cls.frm = this;
		}
		private void HasEditCatalogsPermission() //metodo para dar permisos al usuario 
		{
			if (User.HasEditCatalogsPermission())
				return;

			cboCuadrilla.Enabled = false;
		}
		private void FrmAplicadores_Load(object sender, EventArgs e)
		{
			txbImportePorcentaje.ReadOnly = true;
			txbCodigo.ReadOnly = true;
			txbNombre.ReadOnly = true;
			txbTarifa.ReadOnly = true;

			cboLote.Enabled = false;
			txbHorasTrabajadas.Enabled = false;

			cboLote.SelectedIndex = -1;
			txbHorasTrabajadas.Clear();

			dtpFechaRegistro.Enabled = false;
			cls.ConfigurarDgvDatos();
			cls.EstilizarDgvDatos();
			cls.CargarCuadrillaCampo(cboCuadrilla);
			cls.CargarLotes();
			cls.CargarTarifaHora();
			cls.ConfigurarDgvTodoDatos();
			cls.EstilizarDgvTodoDatos();
			cls.CargarTodoDatos(dtpFecha.Value);
			HasEditCatalogsPermission();
		}
		private void HabilitarCamposEmpleado()
		{
			bool empleadoSeleccionado =
				!string.IsNullOrWhiteSpace(txbCodigo.Text) &&
				!string.IsNullOrWhiteSpace(txbNombre.Text);

			cboLote.Enabled = empleadoSeleccionado;
			txbHorasTrabajadas.Enabled = empleadoSeleccionado;

			if (!empleadoSeleccionado)
			{
				cboLote.SelectedIndex = -1;
				txbHorasTrabajadas.Clear();
			}
		}
		private void dtpFecha_ValueChanged(object sender, EventArgs e)
		{
			dtpFechaRegistro.Value = dtpFecha.Value;
			cls.CargarEmpleadosFechaCuadrilla();
			cls.CargarTodoDatos(dtpFecha.Value);
		}

		private void cboCuadrilla_SelectedIndexChanged(object sender, EventArgs e)
		{

			cls.CargarEmpleadosFechaCuadrilla();
		}

		private void dgvEmpleados_SelectionChanged(object sender, EventArgs e)
		{
			cls.CargarDatosEmpleadoSeleccionado();
		}

		private void cboLote_SelectedIndexChanged(object sender, EventArgs e)
		{
			cls.CargarDatosLote();
			cls.CalcularImporteCuadro();
		}

		private void nudCantidad_ValueChanged(object sender, EventArgs e)
		{
			if (nudCantidad.Value > maxCantidadLineas)
			{
				MessageBox.Show(
					$"La cantidad no puede ser mayor a {maxCantidadLineas} líneas.",
					"Cantidad no válida",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				nudCantidad.Value = maxCantidadLineas;
				return;
			}

			cls.CalcularImporteCuadro();
		}

		private void txbHorasTrabajadas_TextChanged(object sender, EventArgs e)
		{
			cls.CalcularImporteHoras();
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
			cls.AgregarCuadroDetalle();
		}

		private void btnAgregarHoras_Click(object sender, EventArgs e)
		{
			cls.AgregarHorasDetalle();
		}

		private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
				return;

			if (dgvDatos.Columns[e.ColumnIndex].Name != "Eliminar")
				return;

			DialogResult respuesta = MessageBox.Show(
				"¿Desea eliminar este registro?",
				"Eliminar registro",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			if (respuesta != DialogResult.Yes)
				return;

			dgvDatos.Rows.RemoveAt(e.RowIndex);

			cls.ActualizarDetalleCuadros();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			cls.GuardarCostosAplicador();
		}

		private void txbCodigo_TextChanged(object sender, EventArgs e)
		{
			HabilitarCamposEmpleado();
		}

		private void txbNombre_TextChanged(object sender, EventArgs e)
		{
			HabilitarCamposEmpleado();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			// ==========================================
			// VALIDAR QUE HAYA UNA FILA SELECCIONADA
			// ==========================================

			if (dgvTodoDatos.CurrentRow == null)
			{
				MessageBox.Show(
					"Seleccione un registro para eliminar.",
					"Aviso",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			// ==========================================
			// OBTENER ID
			// ==========================================

			string idEmployeeCost =
				dgvTodoDatos.CurrentRow.Cells["IdEmployeeCost"]
				.Value?.ToString();

			if (string.IsNullOrWhiteSpace(idEmployeeCost))
			{
				MessageBox.Show(
					"No se pudo identificar el registro seleccionado.",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return;
			}

			// ==========================================
			// OBTENER INFORMACIÓN PARA CONFIRMACIÓN
			// ==========================================

			string empleado =
				dgvTodoDatos.CurrentRow.Cells["Empleado"]
				.Value?.ToString() ?? "";

			string tipo =
				dgvTodoDatos.CurrentRow.Cells["Tipo"]
				.Value?.ToString() ?? "";

			string concepto =
				dgvTodoDatos.CurrentRow.Cells["Concepto"]
				.Value?.ToString() ?? "";

			string importe =
				dgvTodoDatos.CurrentRow.Cells["Importe"]
				.Value?.ToString() ?? "";

			// ==========================================
			// CONFIRMAR ELIMINACIÓN
			// ==========================================

			DialogResult resultado = MessageBox.Show(
				$"¿Está seguro de eliminar este registro?\n\n" +
				$"Empleado: {empleado}\n" +
				$"Tipo: {tipo}\n" +
				$"Concepto: {concepto}\n" +
				$"Importe: {importe}",
				"Confirmar eliminación",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			if (resultado != DialogResult.Yes)
				return;

			// ==========================================
			// ELIMINAR
			// ==========================================

			bool eliminado = cls.EliminarCosto(idEmployeeCost);

			if (eliminado)
			{
				MessageBox.Show(
					"El registro se eliminó correctamente.",
					"Eliminado",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				// Recargar registros de la fecha seleccionada
				cls.CargarTodoDatos(dtpFecha.Value);
			}
		}
	}
}
