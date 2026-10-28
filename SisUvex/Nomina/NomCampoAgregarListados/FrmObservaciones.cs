using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SisUvex.Nomina.NomCampoAgregarListados.ClsAsistencia;
using static SisUvex.Nomina.NomCampoAgregarListados.ClsObservaciones;

namespace SisUvex.Nomina.NomCampoAgregarListados
{
	public partial class FrmObservaciones : Form
	{
		internal ClsObservaciones clsO;
		private bool modoModificar = false;
		private bool cargandoFormulario = true;
		private ContextMenuStrip menuNotas = new ContextMenuStrip();
		private DataGridViewCell celdaNotaSeleccionada;
		public FrmObservaciones(string semana, DateTime fechaInicio, DateTime fechaFin)
		{
			InitializeComponent();

			clsO = new ClsObservaciones();
			clsO.frmO = this;

			// Cargar información de la semana
			txbSemana.Text = semana;
			dtpInicio.Value = fechaInicio;
			dtpFinal.Value = fechaFin;

			// No permitir modificar estos datos
			txbSemana.ReadOnly = true;
			dtpInicio.Enabled = false;
			dtpFinal.Enabled = false;
			ConfigurarSeleccionMultiple();
			ConfigurarMenuNotas();
			dgvEstado.ShowCellToolTips = true;

			dgvEstado.CellMouseEnter -= dgvEstado_CellMouseEnter;
			dgvEstado.CellMouseEnter += dgvEstado_CellMouseEnter;
		}
		private void ConfigurarSeleccionMultiple()
		{
			dgvEstado.MultiSelect = true;

			dgvEstado.SelectionMode =
				DataGridViewSelectionMode.CellSelect;

			dgvEstado.ReadOnly = true;

			dgvEstado.EditMode =
				DataGridViewEditMode.EditProgrammatically;
		}
	
		private void FrmObservaciones_Load(object sender, EventArgs e)
		{
			clsO.CargarCuadrillas();
			clsO.CargarEstados();

			cboDia.Items.Clear();
			cboDia.Items.AddRange(new object[]
			{
			"VIE", "SAB", "DOM", "LUN", "MAR", "MIE", "JUE"
			});

			cboDia.SelectedIndex = 0;

			clsO.CargarEstadoCuadrillas(
				txbSemana.Text.Trim(),
				dtpInicio.Value.Date,
				dtpFinal.Value.Date);

			DeshabilitarDetalleDia();

		}
		private void DeshabilitarDetalleDia()
		{
			cboCuadrilla2.Enabled = false;
			cboDia.Enabled = false;
		
			txbObservaciones.Enabled = false;
		}

	
		private void dgvEstado_CellClick(object sender, DataGridViewCellEventArgs e)
		{

			if (e.RowIndex < 0)
				return;

			if (e.ColumnIndex < 3)
				return;

			DataGridViewRow fila =
				dgvEstado.Rows[e.RowIndex];

			DataGridViewCell celda =
				fila.Cells[e.ColumnIndex];

			// =====================================================
			// OBTENER CUADRILLA
			// =====================================================

			string idCuadrilla =
				fila.Cells["id_workGroup"]
					.Value?.ToString();

			if (string.IsNullOrWhiteSpace(idCuadrilla))
				return;

			// =====================================================
			// OBTENER FECHA DE LA COLUMNA
			// =====================================================

			DataGridViewColumn columna =
				dgvEstado.Columns[e.ColumnIndex];

			if (columna.Tag == null)
				return;

			DateTime fecha =
				(DateTime)columna.Tag;

			// =====================================================
			// CARGAR CUADRILLA EN EL DETALLE
			// =====================================================

			cboCuadrilla2.SelectedValue = idCuadrilla;

			// =====================================================
			// CARGAR DÍA
			// =====================================================

			int indiceDia =
				(fecha.Date - dtpInicio.Value.Date).Days;

			if (indiceDia >= 0 &&
				indiceDia < cboDia.Items.Count)
			{
				cboDia.SelectedIndex = indiceDia;
			}

			// =====================================================
			// OBTENER DATOS DE LA CELDA
			// =====================================================

			DatosEstado datos =
				celda.Tag as DatosEstado;

			if (datos != null)
			{
				// Observaciones
				txbObservaciones.Text =
					datos.Observaciones ?? "";

				// Guardar ID del registro
				clsO.idRegistroSeleccionado =
					datos.IdRegistro;
			}
			else
			{
				txbObservaciones.Clear();
				clsO.idRegistroSeleccionado = "";
			}
		}
		public void dgvEstado_Resize(object sender, EventArgs e)
		{
			clsO.AjustarFilasAlAlto();
		}
		private void MostrarEditorNota()
		{
			if (celdaNotaSeleccionada == null)
				return;

			DatosEstado datos =
				celdaNotaSeleccionada.Tag as DatosEstado;

			if (datos == null)
				return;

			string notaActual = datos.Nota ?? "";

			using (Form ventana = new Form())
			using (TextBox txtNota = new TextBox())
			using (Button btnAceptar = new Button())
			using (Button btnCancelar = new Button())
			{
				ventana.Text = "Nota de la cuadrilla";
				ventana.StartPosition = FormStartPosition.CenterParent;
				ventana.Size = new Size(400, 250);
				ventana.FormBorderStyle = FormBorderStyle.FixedDialog;
				ventana.MaximizeBox = false;
				ventana.MinimizeBox = false;

				txtNota.Multiline = true;
				txtNota.ScrollBars = ScrollBars.Vertical;
				txtNota.Dock = DockStyle.Top;
				txtNota.Height = 145;
				txtNota.Text = notaActual;

				btnAceptar.Text = "Guardar";
				btnAceptar.DialogResult = DialogResult.OK;
				btnAceptar.SetBounds(205, 165, 80, 30);

				btnCancelar.Text = "Cancelar";
				btnCancelar.DialogResult = DialogResult.Cancel;
				btnCancelar.SetBounds(295, 165, 80, 30);

				ventana.Controls.Add(txtNota);
				ventana.Controls.Add(btnAceptar);
				ventana.Controls.Add(btnCancelar);

				ventana.AcceptButton = btnAceptar;
				ventana.CancelButton = btnCancelar;

				if (ventana.ShowDialog(this) == DialogResult.OK)
				{
					string nuevaNota = txtNota.Text.Trim();

					string idCuadrilla = dgvEstado.Rows[
						celdaNotaSeleccionada.RowIndex]
						.Cells["id_workGroup"].Value?.ToString() ?? "";

					DateTime fecha = datos.Fecha;

					bool guardado = clsO.GuardarNotaCuadrilla(
						idCuadrilla,
						txbSemana.Text.Trim(),
						dtpInicio.Value.Date,
						dtpFinal.Value.Date,
						fecha,
						nuevaNota);

					if (!guardado)
					{
						MessageBox.Show(
							"No se pudo guardar la nota.",
							"Error",
							MessageBoxButtons.OK,
							MessageBoxIcon.Error);

						return;
					}

					datos.Nota = nuevaNota;
					celdaNotaSeleccionada.Tag = datos;
					celdaNotaSeleccionada.ToolTipText = nuevaNota;

					dgvEstado.InvalidateCell(celdaNotaSeleccionada);
				}
			}
		}
		private void EliminarNotaSeleccionada()
		{
			if (celdaNotaSeleccionada == null)
				return;

			DatosEstado datos =
				celdaNotaSeleccionada.Tag as DatosEstado;

			if (datos == null ||
				string.IsNullOrWhiteSpace(datos.Nota))
			{
				MessageBox.Show("Esta celda no tiene una nota.");
				return;
			}

			DialogResult respuesta = MessageBox.Show(
				"¿Deseas eliminar permanentemente esta nota?",
				"Confirmar eliminación",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			if (respuesta != DialogResult.Yes)
				return;

			string idCuadrilla =
				dgvEstado.Rows[celdaNotaSeleccionada.RowIndex]
					.Cells["id_workGroup"].Value?.ToString() ?? "";

			bool eliminado = clsO.EliminarNotaCuadrilla(
				idCuadrilla,
				txbSemana.Text.Trim(),
				dtpInicio.Value.Date,
				dtpFinal.Value.Date,
				datos.Fecha);

			if (!eliminado)
			{
				MessageBox.Show(
					"No se encontró la nota para eliminar.",
					"Aviso",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			datos.Nota = "";
			celdaNotaSeleccionada.Tag = datos;
			celdaNotaSeleccionada.ToolTipText = "";

			dgvEstado.InvalidateCell(celdaNotaSeleccionada);

			MessageBox.Show(
				"Nota eliminada correctamente.",
				"Listo",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information);
		}
		private void ConfigurarMenuNotas()
		{
			menuNotas.ShowImageMargin = false;
			menuNotas.ShowCheckMargin = false;
			menuNotas.Padding = Padding.Empty;
			menuNotas.Margin = Padding.Empty;
			menuNotas.Font = new Font("Segoe UI", 8F);
			menuNotas.AutoSize = true;

			var agregar = new ToolStripMenuItem("Agregar nota");
			var editar = new ToolStripMenuItem("Editar nota");
			var eliminar = new ToolStripMenuItem("Eliminar nota");

			// Reducir espacio vertical y horizontal
			agregar.Padding = new Padding(4, 0, 4, 0);
			editar.Padding = new Padding(4, 0, 4, 0);
			eliminar.Padding = new Padding(4, 0, 4, 0);

			agregar.Margin = Padding.Empty;
			editar.Margin = Padding.Empty;
			eliminar.Margin = Padding.Empty;

			agregar.Click += (s, e) => MostrarEditorNota();
			editar.Click += (s, e) => MostrarEditorNota();
			eliminar.Click += (s, e) => EliminarNotaSeleccionada();

			menuNotas.Items.Clear();
			menuNotas.Items.Add(agregar);
			menuNotas.Items.Add(editar);
			menuNotas.Items.Add(eliminar);

			dgvEstado.CellMouseDown += (s, e) =>
			{
				if (e.Button != MouseButtons.Right ||
					e.RowIndex < 0 ||
					e.ColumnIndex < 3)
					return;

				celdaNotaSeleccionada =
					dgvEstado.Rows[e.RowIndex].Cells[e.ColumnIndex];

				dgvEstado.CurrentCell = celdaNotaSeleccionada;

				DatosEstado datos =
					celdaNotaSeleccionada.Tag as DatosEstado;

				bool tieneNota =
					datos != null &&
					!string.IsNullOrWhiteSpace(datos.Nota);

				agregar.Enabled = !tieneNota;
				editar.Enabled = tieneNota;
				eliminar.Enabled = tieneNota;

				Rectangle rectCelda =
				dgvEstado.GetCellDisplayRectangle(
					e.ColumnIndex,
					e.RowIndex,
					true);

				Point posicion = new Point(
					rectCelda.Right,
					rectCelda.Top);

				menuNotas.Show(dgvEstado, posicion);
			};
		}

		private void dgvEstado_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0 || e.ColumnIndex < 3)
				return;

			DataGridViewCell celda =
				dgvEstado.Rows[e.RowIndex].Cells[e.ColumnIndex];

			if (celda.Tag is DatosEstado datos &&
				!string.IsNullOrWhiteSpace(datos.Nota))
			{
				celda.ToolTipText = datos.Nota;
			}
			else
			{
				celda.ToolTipText = "";
			}
		}

		private void btnConfirmar_Click(object sender, EventArgs e)
		{
			var celdas = dgvEstado.SelectedCells
		   .Cast<DataGridViewCell>()
		   .Where(c =>
			   c.RowIndex >= 0 &&
			   c.ColumnIndex >= 3 &&
			   dgvEstado.Columns[c.ColumnIndex].Name.StartsWith("F_"))
		   .ToList();

			if (celdas.Count == 0)
			{
				MessageBox.Show(
					"Selecciona uno o varios días de diferentes cuadrillas.",
					"Aviso",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			DialogResult respuesta = MessageBox.Show(
				$"¿Quieres pasar a TERMINADAS las {celdas.Count} celdas seleccionadas?",
				"Confirmar terminación",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			if (respuesta != DialogResult.Yes)
				return;

			if (clsO.GuardarTerminadasSeleccionadas(celdas))
			{
				MessageBox.Show(
					"Los días seleccionados se guardaron como TERMINADA.",
					"Guardado correcto",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
		}
	}
}

