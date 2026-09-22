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
		public ClsListados cls;
		public ClsAsistencia _clsA;
		public string IdCuadrilla { get; set; }
		public string SecuenciaSemana { get; set; }
		public DateTime FechaInicio { get; set; }
		public DateTime FechaFin { get; set; }
		public bool ModoModificar { get; set; }
		public List<string> EmpleadosSeleccionados { get; set; } = new List<string>();
		public FrmAgregar()
		{
			InitializeComponent();

			this.StartPosition = FormStartPosition.CenterScreen;

			txbCodigo.Text = "Ej. 012365";
			txbCodigo.ForeColor = Color.Gray;

			txbCodigo.Enter += txbCodigo_Enter;
			txbCodigo.Leave += txbCodigo_Leave;

			this.Load += FrmAgregar_Load;

			dgvListadoAgregar.CellDoubleClick +=
				dgvListadoAgregar_CellDoubleClick;

			clsA = new ClsAgregar();
			clsA.frmA = this;

			cls = new ClsListados();
			cls.frmA = this;

			_clsA = new ClsAsistencia();
			_clsA.frmA = this;
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

			dgvListadoAgregar.Columns.Clear();

			dgvListadoAgregar.Columns.Add("Codigo", "Código");
			dgvListadoAgregar.Columns.Add("Nombre", "Empleado");
			dgvListadoAgregar.Columns.Add("LugarPago", "Lugar de Pago");
			dgvListadoAgregar.Columns.Add("IdLugarPago", "IdLugarPago");

			dgvListadoAgregar.Columns["IdLugarPago"].Visible = false;

			clsA.EstiloDgvListadoAgregar();

		

			if (EmpleadosSeleccionados.Count > 0)
			{
				clsA.CargarEmpleadosSeleccionados(
					EmpleadosSeleccionados);
			}

			//if (ModoModificar)
			//{
			//	cls.CargarEmpleadoModificar();
			//}

			BeginInvoke(new Action(() =>
			{
				btnAgregarListado.Focus();
			}));

		}

		private void btnContinuar_Click(object sender, EventArgs e)
		{
			// =========================================================
			// VALIDAR ID REAL DE CUADRILLA
			// =========================================================

			if (string.IsNullOrWhiteSpace(IdCuadrilla))
			{
				MessageBox.Show(
					"No se recibió el ID de la cuadrilla.",
					"Cuadrilla",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			// =========================================================
			// VALIDAR EMPLEADOS
			// =========================================================

			if (dgvListadoAgregar.Rows.Count == 0)
			{
				MessageBox.Show(
					"Agregue al menos un empleado.",
					"Empleados",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				return;
			}

			HashSet<string> empleados =
				new HashSet<string>();

			foreach (DataGridViewRow fila in dgvListadoAgregar.Rows)
			{
				if (fila.IsNewRow)
					continue;

				string codigo =
					fila.Cells["Codigo"]
					.Value?
					.ToString()
					.Trim();

				if (string.IsNullOrWhiteSpace(codigo))
					continue;

				// ==========================================
				// EMPLEADO REPETIDO EN LA LISTA
				// ==========================================

				if (!empleados.Add(codigo))
				{
					MessageBox.Show(
						$"El empleado {codigo} ya está agregado a la lista.",
						"Empleado ya agregado",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					return;
				}

				// ==========================================
				// VALIDAR SI YA EXISTE
				// ==========================================

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
			// GUARDAR
			// =========================================================

			cls.ActualizarEmpleadosCuadrilla(
				IdCuadrilla,
				SecuenciaSemana,
				FechaInicio,
				FechaFin,
				dgvListadoAgregar);

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
	}
}
		
		