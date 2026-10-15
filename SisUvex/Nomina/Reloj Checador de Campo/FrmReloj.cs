using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.IdentityModel.Tokens;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;
using SisUvex.Nomina.NomCuadrillasCampo;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Nomina.Reloj_Checador_de_Campo
{
	public partial class FrmReloj : Form
	{
		internal ClsReloj cls;
		public FrmReloj()
		{
			InitializeComponent();
			cls = new ClsReloj();
			cls.frm = this;
		}
		private void HasEditCatalogsPermission() //metodo para dar permisos al usuario 
		{
			if (User.HasEditCatalogsPermission())
				return;

			txbCodigo.Enabled = false;
			btnConsultar.Enabled = false;
		}
		private void FrmReloj_Load(object sender, EventArgs e)
		{
			cls.CargarSemanas();
			HasEditCatalogsPermission();
			dtpFechaFinal.MinDate = dtpFechaInicial.Value.Date;
		}

		private void btnConsultar_Click(object sender, EventArgs e)
		{
			DateTime fechaInicio = dtpFechaInicial.Value.Date;
			DateTime fechaFin = dtpFechaFinal.Value.Date;

			if (fechaInicio > fechaFin)
			{
				MessageBox.Show(
					"La fecha inicial no puede ser mayor que la fecha final.",
					"Rango de fechas",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			cls.ConsultarAsistencia(fechaInicio, fechaFin);
		}


		private void btnConsultarSemana_Click(object sender, EventArgs e)
		{
			if (cboSemana.SelectedItem is not DataRowView semana)
			{
				MessageBox.Show("Selecciona una semana.");
				return;
			}

			DateTime fechaInicio =
				Convert.ToDateTime(semana["d_startDate_per"]).Date;

			DateTime fechaFin =
				Convert.ToDateTime(semana["d_endDate_per"]).Date;

			cls.ConsultarAsistencia(fechaInicio, fechaFin);
		}

		private void txbCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode != Keys.Enter)
				return;

			e.SuppressKeyPress = true;

			string codigo = txbCodigo.Text.Trim();

			if (string.IsNullOrWhiteSpace(codigo))
			{
				txbEmpleado.Clear();
				txbLugardePago.Clear();
				txbCuadrilla.Clear();

				MessageBox.Show("Ingresa un código de empleado.");
				txbCodigo.Focus();
				return;
			}

			codigo = codigo.PadLeft(6, '0');

			// Validar la semana seleccionada
			if (cboSemana.SelectedItem is not DataRowView semana)
			{
				MessageBox.Show(
					"Selecciona una semana para consultar los datos del empleado.",
					"Consulta de asistencia",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				cboSemana.Focus();
				return;
			}

			// Obtener periodo y semana seleccionados
			string idPeriodo = semana["id_period"].ToString()!.Trim();
			string numeroSemana = semana["c_sequence_per"].ToString()!.Trim();

			ClsReloj reloj = new ClsReloj();

			// Buscar empleado según el periodo y la semana
			var empleado = reloj.ObtenerEmpleado(
				codigo,
				idPeriodo,
				numeroSemana);

			if (!empleado.Encontrado)
			{
				txbEmpleado.Clear();
				txbLugardePago.Clear();
				txbCuadrilla.Clear();

				MessageBox.Show(
					"No se encontró el empleado.",
					"Buscar empleado",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				txbCodigo.Focus();
				txbCodigo.SelectAll();
				return;
			}

			// Mostrar datos del empleado
			txbEmpleado.Text = empleado.Nombre ?? "";
			txbLugardePago.Text = empleado.LugarPago ?? "";
			txbCuadrilla.Text = empleado.Cuadrilla ?? "Sin cuadrilla";
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

				txbCodigo.ForeColor = System.Drawing.Color.Black;
				txbCodigo.Focus();
			}
		}

		private void dtpFechaInicial_ValueChanged(object sender, EventArgs e)
		{
			// Impedir que la fecha final sea anterior a la inicial
			dtpFechaFinal.MinDate = dtpFechaInicial.Value.Date;

			// Si la fecha final quedó por debajo, actualizarla
			if (dtpFechaFinal.Value.Date < dtpFechaInicial.Value.Date)
			{
				dtpFechaFinal.Value = dtpFechaInicial.Value.Date;
			}
		}

		private void btnLimpiar_Click(object sender, EventArgs e)
		{
			// Limpiar código y empleado
			txbCodigo.Clear();
			txbEmpleado.Clear();

			// Quitar selección de la tabla
			dgvLista.DataSource = null;
			dgvLista.ClearSelection();

			// Regresar el cursor al código
			txbCodigo.Focus();
		}
	}

}
