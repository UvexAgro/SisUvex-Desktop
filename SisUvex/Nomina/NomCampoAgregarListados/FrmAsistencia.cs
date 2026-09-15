using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.SS.Formula.Functions;
using SisUvex.Nomina.Reporte_de_Asistencia;
using static SisUvex.Nomina.NomCampoAgregarListados.ClsAsistencia;
using static SisUvex.Nomina.NomCampoAgregarListados.FrmAgregarLoteyActividad;

namespace SisUvex.Nomina.NomCampoAgregarListados
{
	public partial class FrmAsistencia : Form
	{
		public ClsAsistencia _clsA;
		public ClsReloj clsJ;
		public class DiaSemana
		{
			public string Nombre { get; set; }
			public DateTime Fecha { get; set; }
		}
		public class EmpleadoSeleccionado
		{
			public string Codigo { get; set; }
			public string Nombre { get; set; }
		}
		public FrmAsistencia()
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterScreen;

			_clsA = new ClsAsistencia();
			_clsA._frmA = this;

			clsJ = new ClsReloj();
			clsJ._frmA = this;

			dgvAsistencia.ColumnHeaderMouseClick += _clsA.DgvAsistencia_ColumnHeaderMouseClick;

			dgvChecador.CellPainting += clsJ.DgvChecador_CellPainting;

			dgvAsistencia.CellPainting += _clsA.DgvAsistencia_CellPainting;

			// Seleccionar empleado desde asistencia
			dgvAsistencia.CellClick += clsJ.DgvAsistencia_CellClick;
		}
		private void HasEditCatalogsPermission() //metodo para dar permisos al usuario 
		{
			if (User.HasEditCatalogsPermission())
				return;
			cboCuadrilla.Enabled = false;
			cboSemana.Enabled = false;
		}
		private void FrmAsistencia_Load(object sender, EventArgs e)
		{
			_clsA.ConfigurarGrid();
			_clsA.CargarCuadrillas();
			_clsA.CargarSemanas();
			clsJ.ConfigurarGridChecador();
			clsJ.EstilizarDgvReloj();
			_clsA.CargarDiasSemana();
			HasEditCatalogsPermission();

		}
		private void cboCuadrilla_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboCuadrilla.SelectedIndex == -1)
				return;

			if (cboSemana.SelectedIndex == -1)
				return;

			// Actualizar empleados según cuadrilla + semana
			_clsA.CargarEmpleados();

			// Actualizar reloj checador según cuadrilla + semana
			clsJ.CargarRelojChecador();

			// Actualizar CAL según cuadrilla + semana
			_clsA.CargarCAL();

			// Limpiar empleado seleccionado
			txbRegistro.Clear();

			// Limpiar sus checadas
			dgvReloj.DataSource = null;
		}

		private void cboSemana_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboSemana.SelectedIndex == -1)
				return;

			// Actualizar los días de la semana
			_clsA.CargarDiasSemana();

			// Si no hay cuadrilla seleccionada,
			// solamente actualizamos cboDia
			if (cboCuadrilla.SelectedIndex == -1)
				return;

			// Actualizar empleados según cuadrilla + semana
			_clsA.CargarEmpleados();

			// Actualizar CAL según cuadrilla + semana
			_clsA.CargarCAL();

			// Actualizar reloj checador según cuadrilla + semana
			clsJ.CargarRelojChecador();

			// Limpiar empleado seleccionado
			txbRegistro.Clear();

			// Limpiar sus checadas
			dgvReloj.DataSource = null;
		}

		private void btnImprimir_Click(object sender, EventArgs e)
		{
			try
			{
				if (dgvAsistencia.Rows.Count == 0)
				{
					MessageBox.Show(
						"No hay empleados para imprimir.",
						"Imprimir asistencia",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information);

					return;
				}

				MemoryStream ms =
					_clsA.GenerarPdfAsistenciaCuadrilla(dgvAsistencia);

				_clsA.ShowPdfViewer(ms);
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al generar el PDF:\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private void dgvAsistencia_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			{
				if (e.RowIndex < 0)
					return;

				string codigo =
					dgvAsistencia.Rows[e.RowIndex]
					.Cells["Codigo"]
					.Value?.ToString()
					.Trim();

				if (string.IsNullOrWhiteSpace(codigo))
					return;

				// Quitar selección anterior
				dgvChecador.ClearSelection();

				foreach (DataGridViewRow fila in dgvChecador.Rows)
				{
					if (fila.IsNewRow)
						continue;

					string codigoChecador =
						fila.Cells["id_employee"]
						.Value?.ToString()
						.Trim();

					if (codigoChecador == codigo)
					{
						// Seleccionar toda la fila
						fila.Selected = true;

						// Hacer visible la fila
						dgvChecador.FirstDisplayedScrollingRowIndex =
							fila.Index;

						// Evitar que se quede seleccionada una celda
						dgvChecador.CurrentCell = null;

						break;
					}
				}
			}
		}

		private void dgvAsistencia_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

			// =====================================================
			// SELECCIONAR TODOS LOS EMPLEADOS
			// =====================================================

			if (e.RowIndex == -1 &&
				e.ColumnIndex >= 0 &&
				dgvAsistencia.Columns[e.ColumnIndex].Name == "Seleccionar")
			{
				_clsA.SeleccionarTodos();
				return;
			}


			// =====================================================
			// CLIC EN UNA CELDA
			// =====================================================

			if (e.RowIndex < 0 || e.ColumnIndex < 0)
				return;


			string[] dias =
			{
		"Vie",
		"Sab",
		"Dom",
		"Lun",
		"Mar",
		"Mie",
		"Jue"
	};


			string dia =
				dgvAsistencia.Columns[e.ColumnIndex].Name;


			if (!dias.Contains(dia))
				return;


			// =====================================================
			// OBTENER CELDA
			// =====================================================

			DataGridViewCell celda =
				dgvAsistencia.Rows[e.RowIndex]
				.Cells[e.ColumnIndex];


			// =====================================================
			// SI ESTÁ BLOQUEADA
			// =====================================================

			if (celda.ReadOnly)
				return;


			// =====================================================
			// DATOS DEL EMPLEADO
			// =====================================================

			string codigo =
				dgvAsistencia.Rows[e.RowIndex]
				.Cells["Codigo"]
				.Value?.ToString()
				.Trim();


			if (string.IsNullOrWhiteSpace(codigo))
				return;


			string empleado =
				dgvAsistencia.Rows[e.RowIndex]
				.Cells["Empleado"]
				.Value?.ToString();


			// =====================================================
			// ESTADO ACTUAL DEL CHECKBOX
			// =====================================================

			bool marcado =
				Convert.ToBoolean(celda.Value ?? false);


			// =====================================================
			// SI ESTÁ MARCANDO
			// =====================================================

			if (!marcado)
			{
				// ================================================
				// OBTENER CUADRILLA ACTUAL
				// ================================================

				string idCuadrilla =
					cboCuadrilla.SelectedValue?
					.ToString()
					.Trim();


				if (string.IsNullOrWhiteSpace(idCuadrilla))
				{
					MessageBox.Show(
						"Seleccione una cuadrilla.",
						"Cuadrilla",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					return;
				}

				// ================================================
				// CONFIRMAR PONER ASISTENCIA
				// ================================================

				DialogResult resultado =
					MessageBox.Show(
						$"¿Está segura de ponerle la asistencia?\n\n" +
						$"Empleado: {empleado}\n" +
						$"Código: {codigo}\n" +
						$"Día: {dia}",
						"Confirmar asistencia",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Question);


				if (resultado == DialogResult.No)
				{
					celda.Value = false;
				}
			}
			else
			{
				// =================================================
				// QUITAR ASISTENCIA
				// =================================================

				DialogResult resultado =
					MessageBox.Show(
						$"¿Está segura de quitarle la asistencia?\n\n" +
						$"Empleado: {empleado}\n" +
						$"Código: {codigo}\n" +
						$"Día: {dia}",
						"Confirmar asistencia",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Question);


				if (resultado == DialogResult.No)
				{
					celda.Value = true;
				}
			}
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			_clsA.GuardarAsistencia();
		}

		private void btnES_Click(object sender, EventArgs e)
		{
			clsJ.MarcarPorEstado("E/S");
		}

		private void btnE_Click(object sender, EventArgs e)
		{
			clsJ.MarcarPorEstado("E");
		}

		private void btnS_Click(object sender, EventArgs e)
		{
			clsJ.MarcarPorEstado("S");
		}

		private void dgvChecador_SelectionChanged(object sender, EventArgs e)
		{
			if (dgvChecador.CurrentRow == null)
				return;

			DataGridViewRow fila =
				dgvChecador.CurrentRow;

			string codigo =
				fila.Cells[0].Value?.ToString()?.Trim();

			if (string.IsNullOrWhiteSpace(codigo))
				return;

			string nombre = "";

			foreach (DataGridViewRow empleado in dgvAsistencia.Rows)
			{
				if (empleado.IsNewRow)
					continue;

				string codigoEmpleado =
					empleado.Cells["Codigo"].Value?.ToString()?.Trim();

				if (codigoEmpleado == codigo)
				{
					nombre =
						empleado.Cells["Empleado"].Value?.ToString()?.Trim();

					break;
				}
			}

			if (!string.IsNullOrWhiteSpace(nombre))
			{
				clsJ.CargarRegistrosEmpleado(codigo, nombre);
			}
		}

		private void btnCAL_Click(object sender, EventArgs e)
		{
			if (cboSemana.SelectedItem == null)
			{
				MessageBox.Show(
					"Seleccione una semana.",
					"Aviso",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			if (cboCuadrilla.SelectedItem == null)
			{
				MessageBox.Show(
					"Seleccione una cuadrilla.",
					"Aviso",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			// ==========================================
			// OBTENER SEMANA
			// ==========================================

			DataRowView semana =
				cboSemana.SelectedItem as DataRowView;

			if (semana == null)
			{
				MessageBox.Show(
					"No se pudo obtener la semana seleccionada.",
					"Semana",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			DateTime fechaInicio =
				Convert.ToDateTime(semana["d_startDate_per"]);

			DateTime fechaFin =
				Convert.ToDateTime(semana["d_endDate_per"]);

			string secuenciaSemana =
				semana["c_sequence_per"]
				.ToString()
				.Trim();

			// ==========================================
			// OBTENER CUADRILLA
			// ==========================================

			string idCuadrilla =
				cboCuadrilla.SelectedValue?
				.ToString()
				.Trim();

			if (string.IsNullOrWhiteSpace(idCuadrilla))
			{
				MessageBox.Show(
					"No se encontró la cuadrilla seleccionada.",
					"Cuadrilla",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			// ==========================================
			// VALIDAR ASISTENCIA
			// ==========================================

			if (!_clsA.ExisteAsistenciaEnLaSemana(
					idCuadrilla,
					secuenciaSemana,
					fechaInicio,
					fechaFin))
			{
				MessageBox.Show(
					"No existe asistencia registrada para esta cuadrilla en la semana seleccionada.",
					"Asistencia requerida",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			// ==========================================
			// OBTENER EMPLEADOS SELECCIONADOS
			// ==========================================

			List<EmpleadoSeleccionado> empleadosSeleccionados =
				new List<EmpleadoSeleccionado>();

			foreach (DataGridViewRow fila in dgvAsistencia.Rows)
			{
				if (fila.IsNewRow)
					continue;

				bool seleccionado =
					fila.Cells["Seleccionar"].Value != null &&
					Convert.ToBoolean(
						fila.Cells["Seleccionar"].Value);

				if (!seleccionado)
					continue;

				string codigo =
					fila.Cells["Codigo"].Value?
					.ToString()
					.Trim();

				string nombre =
					fila.Cells["Empleado"].Value?
					.ToString()
					.Trim();

				if (string.IsNullOrWhiteSpace(codigo))
					continue;

				empleadosSeleccionados.Add(
					new EmpleadoSeleccionado
					{
						Codigo = codigo,
						Nombre = nombre
					});
			}

			if (empleadosSeleccionados.Count == 0)
			{
				MessageBox.Show(
					"Seleccione al menos un empleado.",
					"Empleados",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			// ==========================================
			// ABRIR FRM AGREGAR
			// ==========================================

			try
			{
				FrmAgregarLoteyActividad frm = new FrmAgregarLoteyActividad();

				frm.EmpleadosSeleccionados =
					empleadosSeleccionados;

				frm.IdCuadrilla = idCuadrilla;
				frm.SecuenciaSemana = secuenciaSemana;
				frm.FechaInicio = fechaInicio;
				frm.FechaFin = fechaFin;

				if (frm.ShowDialog() == DialogResult.OK)
				{
					_clsA.CargarCAL();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.ToString(),
					"Error detallado",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private void btnJalar_Click(object sender, EventArgs e)
		{
			if (cboCuadrilla.SelectedIndex == -1)
			{
				MessageBox.Show("Selecciona una cuadrilla.");
				return;
			}

			if (cboSemana.SelectedIndex == -1)
			{
				MessageBox.Show("Selecciona una semana.");
				return;
			}

			if (cboDia.SelectedIndex == -1)
			{
				MessageBox.Show("Selecciona un día.");
				return;
			}

			_clsA.JalarActividadLotePorDia();
		}

		private void dgvCAL_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.ColumnIndex < 2)
				return;

			DataGridViewColumn columna =
				dgvCAL.Columns[e.ColumnIndex];

			if (columna.SortMode ==
				DataGridViewColumnSortMode.NotSortable)
				return;

			ListSortDirection direccion;

			if (columna.HeaderCell.SortGlyphDirection ==
				SortOrder.Ascending)
			{
				direccion = ListSortDirection.Descending;
			}
			else
			{
				direccion = ListSortDirection.Ascending;
			}

			dgvCAL.Sort(columna, direccion);
		}

		private void dgvCAL_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.ColumnIndex < 2)
				return;

			int indiceDia = e.ColumnIndex - 2;

			if (indiceDia >= 0 &&
				indiceDia < cboDia.Items.Count)
			{
				cboDia.SelectedIndex = indiceDia;
			}
		}
	}
}
