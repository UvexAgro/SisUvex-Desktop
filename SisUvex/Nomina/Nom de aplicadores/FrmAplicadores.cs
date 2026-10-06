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
		private bool _hayCambios = false;
		private bool _cargandoDatos = false;
		private bool _cambiandoEmpleado = false;
		private int _filaEmpleadoAnterior = -1;
		private int _cuadrillaAnterior = -1;

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
			if (_cargandoDatos || _cambiandoEmpleado)
				return;

			int nuevaCuadrilla = cboCuadrilla.SelectedIndex;

			// Primera carga
			if (_cuadrillaAnterior == -1)
			{
				_cuadrillaAnterior = nuevaCuadrilla;

				_cargandoDatos = true;

				try
				{
					cls.CargarEmpleadosFechaCuadrilla();
				}
				finally
				{
					_cargandoDatos = false;
				}

				return;
			}

			// Si no cambió realmente
			if (nuevaCuadrilla == _cuadrillaAnterior)
				return;

			// ==========================================
			// VALIDAR CAMBIOS
			// ==========================================

			if (!ConfirmarCambiosSinGuardar())
			{
				_cambiandoEmpleado = true;

				try
				{
					cboCuadrilla.SelectedIndex = _cuadrillaAnterior;
				}
				finally
				{
					_cambiandoEmpleado = false;
				}

				return;
			}

			// ==========================================
			// CAMBIAR CUADRILLA
			// ==========================================

			_cuadrillaAnterior = nuevaCuadrilla;

			_cargandoDatos = true;

			try
			{
				cls.CargarEmpleadosFechaCuadrilla();
			}
			finally
			{
				_cargandoDatos = false;
			}
		}
		
		private void dgvEmpleados_SelectionChanged(object sender, EventArgs e)
		{
			if (_cargandoDatos || _cambiandoEmpleado)
				return;

			if (dgvEmpleados.CurrentRow == null)
				return;

			int nuevaFila = dgvEmpleados.CurrentRow.Index;

			// Primera selección
			if (_filaEmpleadoAnterior == -1)
			{
				_filaEmpleadoAnterior = nuevaFila;

				cls.CargarDatosEmpleadoSeleccionado();

				_hayCambios = false;

				return;
			}

			// Si sigue siendo el mismo empleado
			if (nuevaFila == _filaEmpleadoAnterior)
				return;

			// ==========================================
			// VALIDAR CAMBIOS
			// ==========================================

			if (!ConfirmarCambiosSinGuardar())
			{
				_cambiandoEmpleado = true;

				try
				{
					dgvEmpleados.ClearSelection();

					if (_filaEmpleadoAnterior >= 0 &&
						_filaEmpleadoAnterior < dgvEmpleados.Rows.Count)
					{
						dgvEmpleados.Rows[_filaEmpleadoAnterior].Selected = true;

						dgvEmpleados.CurrentCell =
							dgvEmpleados.Rows[_filaEmpleadoAnterior]
							.Cells[0];
					}
				}
				finally
				{
					_cambiandoEmpleado = false;
				}

				return;
			}

			// ==========================================
			// ACEPTAR CAMBIO
			// ==========================================

			_filaEmpleadoAnterior = nuevaFila;

			cls.CargarDatosEmpleadoSeleccionado();

			_hayCambios = false;
		}
		private bool ConfirmarCambiosSinGuardar()
		{
			if (!_hayCambios)
				return true;

			DialogResult respuesta = MessageBox.Show(
				"Tienes cambios sin guardar.\n\n" +
				"¿Deseas guardar los cambios antes de continuar?",
				"Cambios sin guardar",
				MessageBoxButtons.YesNoCancel,
				MessageBoxIcon.Warning
			);

			// ==========================================
			// SÍ → GUARDAR
			// ==========================================

			if (respuesta == DialogResult.Yes)
			{
				cls.GuardarCostosAplicador();

				_hayCambios = false;

				return true;
			}

			// ==========================================
			// NO → DESCARTAR
			// ==========================================

			if (respuesta == DialogResult.No)
			{
				LimpiarCapturaEmpleado();

				_hayCambios = false;

				return true;
			}

			// ==========================================
			// CANCELAR
			// ==========================================

			return false;
		}
		private void LimpiarCapturaEmpleado()
		{
			dgvDatos.Rows.Clear();

			cboLote.SelectedIndex = -1;

			txbLineas.Clear();
			txbCosto.Clear();
			txbImportePorcentaje.Clear();

			nudCantidad.Value = 0;

			txbHorasTrabajadas.Clear();
			txbImporteHoras.Clear();

			// Si tienes estos controles:
			// lblTotalCuadro.Text = "$ 0.00";
			// lblTotalHoras.Text = "$ 0.00";
			// lblTotalPagar.Text = "$ 0.00";

			cls.ActualizarDetalleCuadros();
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
			_hayCambios = true;
		}

		private void btnAgregarHoras_Click(object sender, EventArgs e)
		{
			cls.AgregarHorasDetalle();
			_hayCambios = true;
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
