using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.IdentityModel.Tokens;
using NPOI.SS.Formula.Functions;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;
using SisUvex.Nomina.Reporte_de_Asistencia;
using static SisUvex.Nomina.NomCampoAgregarListados.ClsAgregar;

namespace SisUvex.Nomina.NomCampoAgregarListados
{
	public partial class FrmAgregar : Form
	{
		public ClsAgregar clsA;
		public FrmListados frm;
		public ClsListados cls;
		public ClsAsistencia _clsA;
		public FrmAsistencia _frmA;
		public bool MostrarActividadLote { get; set; }
		public string IdCuadrilla { get; set; }
		public string SecuenciaSemana { get; set; }

		public DateTime FechaInicio { get; set; }
		public DateTime FechaFin { get; set; }

		public bool ModoModificar { get; set; }
		public int IndiceFilaModificar { get; set; }
		public DateTime FechaSeleccionada { get; set; }
		public List<string> EmpleadosSeleccionados { get; set; } = new List<string>();
		public FrmAgregar()
		{
			InitializeComponent();

			cboFecha.DrawMode = DrawMode.OwnerDrawFixed;

			this.StartPosition = FormStartPosition.CenterScreen;
			txbCodigo.Text = "Ej. 012365";
			txbCodigo.ForeColor = Color.Gray;

			cboFecha.Text = "Ej. Selecciona un Dia";
			cboFecha.ForeColor = Color.Gray;

			txbCodigo.Enter += txbCodigo_Enter;
			txbCodigo.Leave += txbCodigo_Leave;

			this.Load += FrmAgregar_Load;

			dgvListadoAgregar.CellDoubleClick += dgvListadoAgregar_CellDoubleClick;

			clsA = new ClsAgregar();
			clsA.frmA = this;

			cls = new ClsListados();
			cls.frmA = this;

			_clsA = new ClsAsistencia();
			_clsA.frmA = this;

		}

		public void BloquearControlesAgregarCuadrilla()
		{
			txbCodigo.Enabled = false;
			btnBuscar.Enabled = false;
			btnAgregarListado.Enabled = false;
			lblCodigo.Enabled = false;
		}
		private void dgvListadoAgregar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			// Evitar doble clic en el encabezado
			if (e.RowIndex < 0)
				return;

			string empleado = dgvListadoAgregar.Rows[e.RowIndex].Cells["Nombre"].Value?.ToString();

			DialogResult respuesta = MessageBox.Show(
				$"¿Desea quitar a {empleado} de la lista?",
				"Quitar empleado",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			if (respuesta != DialogResult.Yes)
				return;

			dgvListadoAgregar.Rows.RemoveAt(e.RowIndex);
		}
		private void txbCodigo_Enter(object sender, EventArgs e)
		{
			if (txbCodigo.Text == "Ej. 012365")
			{
				txbCodigo.Clear();
				txbCodigo.ForeColor = Color.Black;
			}
		}

		private void txbCodigo_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txbCodigo.Text))
			{
				txbCodigo.Text = "Ej. 012365";
				txbCodigo.ForeColor = Color.Gray;
			}
		}

		private void FrmAgregar_Load(object sender, EventArgs e)
		{
			cboActividad.Visible = MostrarActividadLote;
			cboLote.Visible = MostrarActividadLote;

			lblActividad.Visible = MostrarActividadLote;
			lblLote.Visible = MostrarActividadLote;
			cboFecha.Visible = MostrarActividadLote;

			dgvListadoAgregar.Columns.Clear();

			dgvListadoAgregar.Columns.Add("Codigo", "Código");
			dgvListadoAgregar.Columns.Add("Nombre", "Empleado");
			dgvListadoAgregar.Columns.Add("LugarPago", "Lugar de Pago");

			dgvListadoAgregar.Columns.Add("IdLugarPago", "IdLugarPago");

			dgvListadoAgregar.Columns["IdLugarPago"].Visible = false;
			clsA.EstiloDgvListadoAgregar();

			clsA.CargarComboActividades();
			clsA.CargarComboLotes();
			clsA.CargarDiasRegistro(FechaInicio);
			if (EmpleadosSeleccionados.Count > 0)
			{
				clsA.CargarEmpleadosSeleccionados(
					EmpleadosSeleccionados);
			}

			if (ModoModificar)
			{
				cls.CargarEmpleadoModificar();
			}

			BeginInvoke(new Action(() =>
			{
				btnAgregarListado.Focus();
			}));

		}

		private void btnContinuar_Click(object sender, EventArgs e)
		{
			if (dgvListadoAgregar.Rows.Count == 0)
			{
				MessageBox.Show(
					"Agregue al menos un empleado.",
					"Empleados",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				return;
			}

			// =========================================================
			// MODO: AGREGAR LOTE Y ACTIVIDAD
			// =========================================================
			if (MostrarActividadLote)
			{
				if (cboFecha.SelectedItem == null)
				{
					MessageBox.Show(
						"Seleccione el día.",
						"Fecha",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					return;
				}

				if (cboActividad.SelectedValue == null)
				{
					MessageBox.Show(
						"Seleccione una actividad.",
						"Actividad",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					return;
				}

				if (cboLote.SelectedValue == null)
				{
					MessageBox.Show(
						"Seleccione un lote.",
						"Lote",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					return;
				}

				// =====================================================
				// GUARDAR LOTE, ACTIVIDAD Y CUADRILLA
				// PARA EL DÍA SELECCIONADO
				// =====================================================
				if (clsA.GuardarActividadLote())
				{
					MessageBox.Show(
						"El lote y la actividad se asignaron correctamente.",
						"Correcto",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information);

					// Avisar al formulario Asistencia
					// que los datos se guardaron correctamente
					this.DialogResult = DialogResult.OK;
					this.Close();
				}

				return;
			}


			// =========================================================
			// MODO NORMAL: AGREGAR EMPLEADOS
			// =========================================================

			// Validar empleados repetidos dentro de la lista
			HashSet<string> empleados =
				new HashSet<string>();

			foreach (DataGridViewRow fila in dgvListadoAgregar.Rows)
			{
				if (fila.IsNewRow)
					continue;

				string codigo =
					fila.Cells["Codigo"].Value?.ToString().Trim();

				if (string.IsNullOrWhiteSpace(codigo))
					continue;

				// EMPLEADO REPETIDO EN LA LISTA
				if (!empleados.Add(codigo))
				{
					MessageBox.Show(
						$"El empleado {codigo} ya está agregado a la lista.",
						"Empleado ya agregado",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					return;
				}

				// EMPLEADO YA EXISTE EN LA CUADRILLA
				if (cls.ExisteEmpleadoEnCuadrilla(
					codigo,
					IdCuadrilla,
					SecuenciaSemana,
					FechaInicio,
					FechaFin))
				{
					MessageBox.Show(
						$"El empleado {codigo} ya está agregado a esta cuadrilla " +
						$"para la semana {SecuenciaSemana}.",
						"Empleado ya agregado",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					return;
				}
			}

			// =========================================================
			// GUARDAR EMPLEADOS
			// =========================================================
			cls.ActualizarEmpleadosCuadrilla(
				IdCuadrilla,
				SecuenciaSemana,
				FechaInicio,
				FechaFin,
				dgvListadoAgregar);

			// Avisar al formulario Asistencia
			// que los empleados se guardaron correctamente
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnAgregarListado_Click(object sender, EventArgs e)
		{
			clsA.btnAgregarVariosEmpleados();
		}

		private void btnBuscar_Click(object sender, EventArgs e)
		{
			ClsSelectionForm sel = new ClsSelectionForm();

			sel.OpenSelectionForm("EmployeeBasic", "Código");

			if (!sel.SelectedValue.IsNullOrEmpty())
			{
				string nuevoCodigo = sel.SelectedValue.Trim();

				string codigosActuales = txbCodigo.Text.Trim();

				// Si tiene el texto de ejemplo, considerarlo vacío
				if (codigosActuales == "Ej. 012365" ||
					string.IsNullOrWhiteSpace(codigosActuales))
				{
					txbCodigo.Text = nuevoCodigo;
				}
				else
				{
					txbCodigo.Text =
						codigosActuales + ", " + nuevoCodigo;
				}

				txbCodigo.ForeColor = Color.Black;
				txbCodigo.Focus();
			}
		}

		private void txbCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;

				clsA.btnAgregarVariosEmpleados();

				txbCodigo.Clear();
				txbCodigo.Focus();
			}
		}

		private void cboFecha_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboFecha.SelectedItem == null)
				return;

			DiaRegistro dia = (DiaRegistro)cboFecha.SelectedItem;

			FechaSeleccionada = dia.Fecha;

			cboFecha.ForeColor = Color.Black;
		}
		

		private void cboFecha_Enter(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txbCodigo.Text))
			{
				cboFecha.Text = "Ej. Selecciona un Dia";
				cboFecha.ForeColor = Color.Gray;
			}
		}

		private void cboFecha_DrawItem(object sender, DrawItemEventArgs e)
		{
			if (e.Index < 0)
				return;

			e.DrawBackground();

			DiaRegistro dia = (DiaRegistro)cboFecha.Items[e.Index];

			string texto = dia.Fecha.ToString("dddd dd/MM/yyyy").ToUpper();

			using (Brush brush = new SolidBrush(Color.Black))
			{
				e.Graphics.DrawString(
					texto,
					e.Font,
					brush,
					e.Bounds
				);
			}

			e.DrawFocusRectangle();
		}
	}
}