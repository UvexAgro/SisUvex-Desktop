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
		}
		private void HabilitarCampos()
		{
			cboCuadrilla2.Enabled = true;
			cboDia.Enabled = true;
			cboEstado.Enabled = true;
			txbObservaciones.Enabled = true;
		}
		private void BloquearCampos()
		{
			cboCuadrilla2.Enabled = false;
			cboDia.Enabled = false;
			cboEstado.Enabled = false;
			txbObservaciones.Enabled = false;
		}
		private void EstadoGuardado()
		{
			// Campos bloqueados
			BloquearCampos();

			// Botones
			btnAgregar.Enabled = true;
			btnModificar.Enabled = true;
			btnGuardar.Enabled = false;
		}
		private void EstadoAgregar()
		{
			// Campos habilitados
			HabilitarCampos();

			// Botones
			btnAgregar.Enabled = false;
			btnModificar.Enabled = false;
			btnGuardar.Enabled = true;
		}
		private void EstadoModificar()
		{
			// Campos habilitados
			HabilitarCampos();

			// Botones
			btnAgregar.Enabled = false;
			btnModificar.Enabled = false;
			btnGuardar.Enabled = true;
		}
		private void EstadoNormal()
		{
			// ==========================================
			// CONTROLES DE DATOS BLOQUEADOS
			// ==========================================

			cboCuadrilla2.Enabled = false;
			cboDia.Enabled = false;
			cboEstado.Enabled = false;
			txbObservaciones.ReadOnly = true;


			// ==========================================
			// BOTONES
			// ==========================================

			btnAgregar.Enabled = true;
			btnModificar.Enabled = true;
			btnCancelar.Enabled = true;
			btnGuardar.Enabled = false;
		}

		private void FrmObservaciones_Load(object sender, EventArgs e)
		{
			clsO.CargarCuadrillas();
			clsO.CargarEstados();
			cboEstado.DrawMode = DrawMode.OwnerDrawFixed;
			cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
			cboEstado.ItemHeight = 28;

			cboEstado.DrawItem += cboEstado_DrawItem;
			clsO.CargarEstadoCuadrillas(
				   txbSemana.Text.Trim(),
				   dtpInicio.Value,
				   dtpFinal.Value);

			cargandoFormulario = false;

			// Estado inicial
			BloquearCampos();

			btnAgregar.Enabled = true;
			btnModificar.Enabled = true;
			btnGuardar.Enabled = true;

			cboDia.Items.Clear();

			cboDia.Items.Add("VIE");
			cboDia.Items.Add("SAB");
			cboDia.Items.Add("DOM");
			cboDia.Items.Add("LUN");
			cboDia.Items.Add("MAR");
			cboDia.Items.Add("MIE");
			cboDia.Items.Add("JUE");

			cboDia.SelectedIndex = 0;

		}

		private void cboEstado_DrawItem(object sender, DrawItemEventArgs e)
		{
			if (e.Index < 0)
				return;

			string estado = cboEstado.GetItemText(cboEstado.Items[e.Index]);

			Color colorEstado;

			switch (estado)
			{
				case "TERMINADA":
					colorEstado = Color.FromArgb(40, 167, 69);
					break;

				case "EN PROCESO":
					colorEstado = Color.FromArgb(255, 193, 7);
					break;

				case "PENDIENTE":
					colorEstado = Color.FromArgb(220, 53, 69);
					break;

				default:
					colorEstado = Color.Gray;
					break;
			}

			// Fondo
			if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
			{
				e.Graphics.FillRectangle(
					new SolidBrush(Color.FromArgb(235, 240, 250)),
					e.Bounds);
			}
			else
			{
				e.Graphics.FillRectangle(
					new SolidBrush(Color.White),
					e.Bounds);
			}

			// Círculo
			using (SolidBrush brush =
				   new SolidBrush(colorEstado))
			{
				e.Graphics.FillEllipse(
					brush,
					e.Bounds.Left + 8,
					e.Bounds.Top + 7,
					14,
					14);
			}

			// Texto
			Color colorTexto =
				(e.State & DrawItemState.Selected) == DrawItemState.Selected
				? Color.FromArgb(30, 30, 30)
				: Color.FromArgb(30, 30, 30);

			using (SolidBrush brushTexto =
				   new SolidBrush(colorTexto))
			{
				e.Graphics.DrawString(
					estado,
					e.Font,
					brushTexto,
					e.Bounds.Left + 30,
					e.Bounds.Top + 5);
			}

			e.DrawFocusRectangle();
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			bool guardado;

			if (modoModificar)
			{
				guardado = clsO.ModificarEstadoCuadrilla();
			}
			else
			{
				guardado = clsO.GuardarEstadoCuadrilla();
			}

			if (!guardado)
				return;

			modoModificar = false;

			EstadoGuardado();
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
			modoModificar = false;

			clsO.idRegistroSeleccionado = "";

			// Limpiar datos
			cboCuadrilla2.SelectedIndex = -1;
			cboDia.SelectedIndex = -1;
			cboEstado.SelectedIndex = -1;

			txbObservaciones.Clear();

			// Habilitar campos
			EstadoAgregar();
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

			cboCuadrilla2.SelectedValue =
				idCuadrilla;

			// =====================================================
			// CARGAR DÍA
			// =====================================================

			int indiceDia =
				(fecha.Date - dtpInicio.Value.Date).Days;

			if (indiceDia >= 0 &&
				indiceDia < cboDia.Items.Count)
			{
				cboDia.SelectedIndex =
					indiceDia;
			}

			// =====================================================
			// OBTENER DATOS DE LA CELDA
			// =====================================================
			DatosEstado datos =
				celda.Tag as DatosEstado;

			if (datos != null)
			{
				// Estado
				if (!string.IsNullOrWhiteSpace(datos.IdStatus))
				{
					cboEstado.SelectedValue =
						datos.IdStatus;
				}
				else
				{
					cboEstado.SelectedIndex = -1;
				}

				// Observaciones
				txbObservaciones.Text =
					datos.Observaciones ?? "";

				// GUARDAR ID DEL REGISTRO
				clsO.idRegistroSeleccionado =
					datos.IdRegistro;
			}
			else
			{
				cboEstado.SelectedIndex = -1;
				txbObservaciones.Clear();

				clsO.idRegistroSeleccionado = "";

				MessageBox.Show(
					"La celda no tiene DatosEstado.",
					"Prueba");
			}
		}

		private void btnModificar_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(
			clsO.idRegistroSeleccionado))
			{
				MessageBox.Show(
					"Seleccione un día con información para modificar.",
					"Aviso",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			modoModificar = true;

			EstadoModificar();
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			modoModificar = false;

			EstadoNormal();
		}

		public void dgvEstado_Resize(object sender, EventArgs e)
		{
			clsO.AjustarFilasAlAlto();
		}
	}
}

