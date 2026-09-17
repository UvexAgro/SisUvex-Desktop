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
using static SisUvex.Nomina.NomCampoAgregarListados.FrmAsistencia;

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
			clsJ.CargarCuadrillas();
			_clsA.CargarSemanas();
			clsJ.ConfigurarGridChecador();
			clsJ.EstilizarDgvReloj();
			_clsA.CargarDiasSemana();
			HasEditCatalogsPermission();

		}
		private void cboCuadrilla_SelectedIndexChanged(object sender, EventArgs e)
		{
			CargarDatosCuadrillaSemana();
		}

		private void cboSemana_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboSemana.SelectedIndex == -1)
				return;

			_clsA.CargarDiasSemana();

			CargarDatosCuadrillaSemana();
		}
		private bool ObtenerFechasSemana(out DateTime fechaInicio, out DateTime fechaFin)
		{
			fechaInicio = DateTime.MinValue;
			fechaFin = DateTime.MinValue;

			if (cboSemana.SelectedItem is ClsAsistencia.Semana semana)
			{
				fechaInicio = semana.FechaInicio;
				fechaFin = semana.FechaFin;
				return true;
			}

			if (cboSemana.SelectedItem is DataRowView fila)
			{
				if (fila.Row.Table.Columns.Contains("FechaInicio") && fila.Row.Table.Columns.Contains("FechaFin"))
				{
					fechaInicio = Convert.ToDateTime(fila["FechaInicio"]);
					fechaFin = Convert.ToDateTime(fila["FechaFin"]);
					return true;
				}

				if (fila.Row.Table.Columns.Contains("d_startDate_per") && fila.Row.Table.Columns.Contains("d_endDate_per"))
				{
					fechaInicio = Convert.ToDateTime(fila["d_startDate_per"]);
					fechaFin = Convert.ToDateTime(fila["d_endDate_per"]);
					return true;
				}
			}

			return false;
		}
		private void CargarDatosCuadrillaSemana()
		{
			if (cboCuadrilla.SelectedIndex == -1 ||
				cboSemana.SelectedIndex == -1)
				return;

			if (!ObtenerIdCuadrilla(out int idWorkGroup))
				return;

			if (!ObtenerFechasSemana(out DateTime fechaInicio, out DateTime fechaFin))
			{
				MessageBox.Show(
					"No se pudieron obtener las fechas de la semana seleccionada.",
					"Aviso",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			txbRegistro.Clear();
			dgvChecador.DataSource = null;

			// OPCIÓN "TODOS"
			if (idWorkGroup == 0)
			{
				DataTable empleadosSinCuadrilla =
					_clsA.CargarEmpleadosSinCuadrilla(fechaInicio, fechaFin);

				if (empleadosSinCuadrilla == null ||
					empleadosSinCuadrilla.Rows.Count == 0)
				{
					MessageBox.Show(
						"No se encontraron empleados sin cuadrilla.",
						"Información",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information);

					return;
				}

				dgvChecador.DataSource = empleadosSinCuadrilla;
				clsJ.MostrarEmpleadosSinCuadrilla(empleadosSinCuadrilla);

				return;
			}

			// CUADRILLA NORMAL
			_clsA.CargarEmpleados();
			_clsA.CargarCAL();
			clsJ.CargarRelojChecador();
		}
		private bool ObtenerIdCuadrilla(out int idWorkGroup)
		{
			idWorkGroup = -1;

			if (cboCuadrilla.SelectedIndex == -1)
				return false;

			if (cboCuadrilla.SelectedItem is DataRowView fila)
			{
				if (fila.Row.Table.Columns.Contains("id_workGroup"))
				{
					return int.TryParse(
						fila["id_workGroup"]?.ToString(),
						out idWorkGroup);
				}
			}

			return int.TryParse(
				cboCuadrilla.SelectedValue?.ToString(),
				out idWorkGroup);
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

		private void btnAsignar_Click(object sender, EventArgs e)
		{
			if (cboCuadrilla2.SelectedIndex == -1)
			{
				MessageBox.Show(
					"Seleccione una cuadrilla.",
					"Aviso",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			string idCuadrilla =
				cboCuadrilla2.SelectedValue.ToString();

			string nombreCuadrilla =
				cboCuadrilla2.Text.Trim();

			bool haySeleccionados = false;

			foreach (DataGridViewRow fila in dgvChecador.Rows)
			{
				if (fila.IsNewRow)
					continue;

				bool seleccionado = Convert.ToBoolean(
					fila.Cells["Seleccionar"].Value ?? false);

				if (!seleccionado)
					continue;

				haySeleccionados = true;

				// Mostrar el nombre de la cuadrilla
				fila.Cells["Cuadrilla"].Value =
					nombreCuadrilla;

				// Guardar el ID de la cuadrilla en la fila
				fila.Cells["id_workGroup"].Value =
					idCuadrilla;

				// Desmarcar después de asignar
				fila.Cells["Seleccionar"].Value = false;
			}

			if (!haySeleccionados)
			{
				MessageBox.Show(
					"Seleccione al menos un empleado.",
					"Aviso",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			MessageBox.Show(
				"Cuadrilla asignada a los empleados seleccionados.",
				"Información",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information);
		}

		private void btnGuardarCuadrilla_Click(object sender, EventArgs e)
		{

			if (!ObtenerFechasSemana(
			out DateTime fechaInicio,
			out DateTime fechaFin))
			{
				return;
			}

			if (cboSemana.SelectedIndex == -1)
			{
				MessageBox.Show(
					"Seleccione una semana.",
					"Aviso",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			// Obtener el ID de la semana seleccionada
			string idSemana = cboSemana.SelectedValue.ToString().Trim();

			bool hayEmpleados = false;

			foreach (DataGridViewRow fila in dgvChecador.Rows)
			{
				if (fila.IsNewRow)
					continue;

				// Verificar que tenga una cuadrilla asignada
				object valorIdCuadrilla =
					fila.Cells["id_workGroup"].Value;

				if (valorIdCuadrilla == null ||
					valorIdCuadrilla == DBNull.Value ||
					string.IsNullOrWhiteSpace(
						valorIdCuadrilla.ToString()))
				{
					continue;
				}

				// Obtener código del empleado
				string codigoEmpleado = fila.Cells["Codigo"].Value?.ToString().Trim();

				if (string.IsNullOrWhiteSpace(codigoEmpleado))
					continue;

				string idCuadrilla =
					valorIdCuadrilla.ToString().Trim();

				bool guardado = clsJ.GuardarEmpleadoCuadrilla(
					codigoEmpleado,
					idSemana,
					idCuadrilla,
					fechaInicio,
					fechaFin);

				if (guardado)
					hayEmpleados = true;
			}

			if (!hayEmpleados)
			{
				MessageBox.Show(
					"No hay empleados con cuadrilla asignada para guardar.",
					"Aviso",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			MessageBox.Show(
				"Los empleados fueron guardados correctamente.",
				"Información",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information);
		}
	}
}
