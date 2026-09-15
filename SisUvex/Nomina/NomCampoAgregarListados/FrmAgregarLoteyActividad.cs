using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SisUvex.Nomina.NomCampoAgregarListados.ClsAgregar;
using static SisUvex.Nomina.NomCampoAgregarListados.FrmAsistencia;

namespace SisUvex.Nomina.NomCampoAgregarListados
{
	public partial class FrmAgregarLoteyActividad : Form
	{
		public ClsAgregarLoteyActividad clsCAL;
		public DateTime FechaSeleccionada { get; set; }
		public bool cargandoActividades = false;
		public BindingSource bsActividades = new BindingSource();
		private DataTable dtActividades = new DataTable();
		private List<string> actividadesOriginales =
			new List<string>();

		public List<FrmAsistencia.EmpleadoSeleccionado> EmpleadosSeleccionados
		{
			get;
			set;
		}

		public string IdCuadrilla
		{
			get;
			set;
		}

		public string SecuenciaSemana
		{
			get;
			set;
		}

		public DateTime FechaInicio
		{
			get;
			set;
		}

		public DateTime FechaFin
		{
			get;
			set;
		}

		public FrmAgregarLoteyActividad()
		{
			InitializeComponent();

			clsCAL = new ClsAgregarLoteyActividad();
			clsCAL.frmCAL = this;


			cboFecha.DrawMode = DrawMode.OwnerDrawFixed;

			this.StartPosition = FormStartPosition.CenterScreen;

			cboFecha.Text = "Ej. Selecciona un Dia";
			cboFecha.ForeColor = Color.Gray;
		}

		private void FrmAgregarLoteyActividad_Load(object sender, EventArgs e)
		{
			clsCAL.DiseñarDgvEmpleados();

			clsCAL.CargarEmpleadosSeleccionados();

			CargarActividades();
			clsCAL.CargarComboCultivos();

			clsCAL.CargarDiasRegistro(FechaInicio);
			clsCAL.ConfigurarSeleccionEmpleados();
			clsCAL.ConfigurarColumnasOcultas();

			clsCAL.CargarComboCultivos();

			cboCultivo.SelectionChangeCommitted +=
				cboCultivo_SelectionChangeCommitted;
		}
		private void CargarActividades()
		{
			try
			{
				cargandoActividades = true;

				dtActividades = clsCAL.ObtenerActividades();

				actividadesOriginales.Clear();

				cboActividad.Items.Clear();

				foreach (DataRow fila in dtActividades.Rows)
				{
					string codigo =
						fila["c_codigo_tab"].ToString();

					string descripcion =
						fila["v_descripcion_tab"].ToString();

					string actividad =
						$"{codigo} - {descripcion}";

					actividadesOriginales.Add(actividad);

					cboActividad.Items.Add(actividad);
				}

				cboActividad.DropDownStyle =
					ComboBoxStyle.DropDown;

				cboActividad.AutoCompleteMode =
					AutoCompleteMode.None;

				cboActividad.SelectedIndex = -1;
				cboActividad.Text = "";
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al cargar las actividades: " +
					ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				cargandoActividades = false;
			}
		}

		private void cboActividad_TextUpdate(object sender, EventArgs e)
		{
			if (cargandoActividades)
				return;

			if (actividadesOriginales == null)
				return;

			string texto = cboActividad.Text;

			int posicionCursor = cboActividad.SelectionStart;

			List<string> resultados = actividadesOriginales
				.Where(a =>
					a.IndexOf(
						texto,
						StringComparison.OrdinalIgnoreCase) >= 0)
				.ToList();

			cargandoActividades = true;

			try
			{
				cboActividad.BeginUpdate();

				cboActividad.Items.Clear();

				foreach (string actividad in resultados)
				{
					cboActividad.Items.Add(actividad);
				}

				// Restaurar el texto que escribió el usuario
				cboActividad.Text = texto;

				cboActividad.SelectionStart =
					Math.Min(posicionCursor, texto.Length);

				cboActividad.SelectionLength = 0;

				cboActividad.EndUpdate();

				// Mostrar coincidencias
				if (resultados.Count > 0 &&
					!string.IsNullOrWhiteSpace(texto))
				{
					cboActividad.DroppedDown = true;
				}
			}
			finally
			{
				cargandoActividades = false;
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

		private void cboFecha_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboFecha.SelectedItem == null)
				return;

			DiaRegistro dia = (DiaRegistro)cboFecha.SelectedItem;

			FechaSeleccionada = dia.Fecha;

			cboFecha.ForeColor = Color.Black;
		}

		private void btnAsignar_Click(object sender, EventArgs e)
		{
			dgvAgregarLoteyActividad.EndEdit();

			if (cboActividad.SelectedIndex < 0)
			{
				MessageBox.Show("Seleccione una actividad.");
				return;
			}

			if (cboLote.SelectedIndex < 0)
			{
				MessageBox.Show("Seleccione un lote.");
				return;
			}

			string actividad = cboActividad.Text.Trim();
			string lote = cboLote.Text.Trim();

			string idActividad =
				cboActividad.SelectedValue?.ToString().Trim();

			string idLote =
				cboLote.SelectedValue?.ToString().Trim();

			string idVariedad = "";

			if (cboLote.SelectedItem is DataRowView filaLote)
			{
				idVariedad = filaLote["id_variety"]
					.ToString()
					.Trim();
			}

			if (string.IsNullOrWhiteSpace(idVariedad))
			{
				MessageBox.Show("No se pudo obtener la variedad del lote.");
				return;
			}

			int empleadosAsignados = 0;

			foreach (DataGridViewRow fila in dgvAgregarLoteyActividad.Rows)
			{
				if (fila.IsNewRow)
					continue;

				bool seleccionado = Convert.ToBoolean(
					fila.Cells["Seleccionar"].Value ?? false);

				if (!seleccionado)
					continue;

				fila.Cells["Actividad"].Value = actividad;
				fila.Cells["Lote"].Value = lote;

				fila.Cells["IdActividad"].Value = idActividad;
				fila.Cells["IdVariedad"].Value = idVariedad;
				fila.Cells["IdLote"].Value = idLote;

				fila.Cells["Seleccionar"].Value = false;

				empleadosAsignados++;
			}

			if (empleadosAsignados == 0)
			{
				MessageBox.Show("Marque uno o varios empleados.");
				return;
			}

			MessageBox.Show("Actividad y lote asignados correctamente.");
		}

		private void btnContinuar_Click(object sender, EventArgs e)
		{
			try
			{
				// ==========================================
				// VALIDAR DÍA
				// ==========================================

				DiaRegistro diaSeleccionado =
					cboFecha.SelectedItem as DiaRegistro;

				if (diaSeleccionado == null)
				{
					MessageBox.Show(
						"Seleccione un día.",
						"Día",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					return;
				}

				// ==========================================
				// OBTENER SUFIJO DEL DÍA
				// ==========================================

				string dia = "";

				switch (diaSeleccionado.Fecha.DayOfWeek)
				{
					case DayOfWeek.Friday:
						dia = "vie";
						break;

					case DayOfWeek.Saturday:
						dia = "sab";
						break;

					case DayOfWeek.Sunday:
						dia = "dom";
						break;

					case DayOfWeek.Monday:
						dia = "lun";
						break;

					case DayOfWeek.Tuesday:
						dia = "mar";
						break;

					case DayOfWeek.Wednesday:
						dia = "mie";
						break;

					case DayOfWeek.Thursday:
						dia = "jue";
						break;
				}

				// ==========================================
				// VALIDAR EMPLEADOS
				// ==========================================

				if (dgvAgregarLoteyActividad.Rows.Count == 0)
				{
					MessageBox.Show(
						"No hay empleados para guardar.",
						"Empleados",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					return;
				}

				int empleadosGuardados = 0;

				// ==========================================
				// RECORRER EMPLEADOS
				// ==========================================

				foreach (DataGridViewRow fila in dgvAgregarLoteyActividad.Rows)
				{
					if (fila.IsNewRow)
						continue;

					string codigoEmpleado =
						fila.Cells["Codigo"].Value?
						.ToString()
						.Trim();

					string actividad =
						fila.Cells["Actividad"].Value?
						.ToString()
						.Trim();

					string variedad =
						fila.Cells["IdVariedad"].Value?
						.ToString()
						.Trim();

					string lote =
						fila.Cells["Lote"].Value?
						.ToString()
						.Trim();

					// ==========================================
					// VALIDAR DATOS
					// ==========================================

					if (string.IsNullOrWhiteSpace(codigoEmpleado))
						continue;

					if (string.IsNullOrWhiteSpace(actividad) ||
						string.IsNullOrWhiteSpace(variedad) ||
						string.IsNullOrWhiteSpace(lote))
					{
						continue;
					}

					// ==========================================
					// GUARDAR EN LA TABLA MEDIANTE PROCEDIMIENTO
					// ==========================================

					clsCAL.GuardarActividadLoteCuadrilla(
						codigoEmpleado,
						SecuenciaSemana,
						FechaInicio,
						FechaFin,
						dia,
						IdCuadrilla,
						actividad,
						variedad,
						lote);

					empleadosGuardados++;
				}

				// ==========================================
				// VALIDAR GUARDADO
				// ==========================================

				if (empleadosGuardados == 0)
				{
					MessageBox.Show(
						"No hay empleados con actividad, variedad y lote asignados.",
						"Guardar",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					return;
				}

				MessageBox.Show(
					"La información se guardó correctamente.",
					"Guardar",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Error al guardar",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private void cboCultivo_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (clsCAL.cargandoCultivos)
				return;

			clsCAL.CargarLotesDelCultivoSeleccionado();
		}
	}
}