using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.SS.Formula.Functions;

namespace SisUvex.Nomina.NomCampoAgregarListados
{
	public partial class FrmAsistencia : Form
	{
		public ClsAsistencia _clsA;
		public ClsReloj clsJ;
		private HashSet<string> celdasBloqueadas =
			new HashSet<string>();
		public FrmAsistencia()
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterScreen;
			_clsA = new ClsAsistencia();
			_clsA._frmA = this;

			clsJ = new ClsReloj();
			clsJ._frmA = this;
			dgvAsistencia.ColumnHeaderMouseClick +=
					_clsA.DgvAsistencia_ColumnHeaderMouseClick;

			dgvChecador.CellPainting +=clsJ.DgvChecador_CellPainting;

			dgvAsistencia.CellPainting +=_clsA.DgvAsistencia_CellPainting;
		}

		private void FrmAsistencia_Load(object sender, EventArgs e)
		{
			_clsA.ConfigurarGrid();
			_clsA.CargarCuadrillas();
			_clsA.CargarSemanas();
			clsJ.ConfigurarGridChecador();

		}

		private void cboCuadrilla_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboCuadrilla.SelectedIndex == -1)
				return;

			if (cboSemana.SelectedIndex == -1)
				return;

			_clsA.CargarEmpleados();
			clsJ.CargarRelojChecador();
		}

		private void cboSemana_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboSemana.SelectedIndex == -1)
				return;

			if (cboCuadrilla.SelectedIndex == -1)
				return;

			_clsA.CargarEmpleados();
			clsJ.CargarRelojChecador();
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

			{
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

				// ==========================================
				// OBTENER CELDA
				// ==========================================

				DataGridViewCell celda =
					dgvAsistencia.Rows[e.RowIndex]
					.Cells[e.ColumnIndex];

				// ==========================================
				// SI ESTÁ BLOQUEADA → NO HACER NADA
				// ==========================================

				if (celda.ReadOnly)
					return;

				string codigo =
					dgvAsistencia.Rows[e.RowIndex]
					.Cells["Codigo"]
					.Value?.ToString();

				if (string.IsNullOrWhiteSpace(codigo))
					return;

				string empleado =
					dgvAsistencia.Rows[e.RowIndex]
					.Cells["Empleado"]
					.Value?.ToString();

				bool marcado =
					Convert.ToBoolean(celda.Value ?? false);

				// ==========================================
				// CONFIRMAR CAMBIO
				// ==========================================

				if (marcado)
				{
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
						celda.Value = true;
				}
				else
				{
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
						celda.Value = false;
				}
			}
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			_clsA.GuardarAsistencia();
		}
	}
}

