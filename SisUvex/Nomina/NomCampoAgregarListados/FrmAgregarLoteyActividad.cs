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
		public DataTable dtLotesDgv = new DataTable();
		private TextBox txtBusquedaDgv;
		private ListBox lstResultadosDgv;
		private bool filtrandoLote = false;
		private string textoBusquedaLote = "";
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
			dgvAgregarLoteyActividad.ColumnHeaderMouseClick -=dgvAgregarLoteyActividad_ColumnHeaderMouseClick;

			dgvAgregarLoteyActividad.ColumnHeaderMouseClick +=dgvAgregarLoteyActividad_ColumnHeaderMouseClick;

			// Cargar la actividad anterior del día seleccionado
			if (cboFecha.SelectedItem is DiaRegistro dia)
			{
				FechaSeleccionada = dia.Fecha;

				clsCAL.CargarActividadAnterior(FechaSeleccionada);
			}

			CargarActividades();
			ConfigurarActividadDgv();
			clsCAL.CargarComboCultivos();
			ConfigurarLoteDgv();

			clsCAL.CargarDiasRegistro(FechaInicio);
			clsCAL.ConfigurarSeleccionEmpleados();
			clsCAL.ConfigurarColumnasOcultas();


			dgvAgregarLoteyActividad.EditingControlShowing += dgvAgregarLoteyActividad_EditingControlShowing;

			dgvAgregarLoteyActividad.KeyDown += dgvAgregarLoteyActividad_KeyDown;

			cboCultivo.SelectionChangeCommitted += cboCultivo_SelectionChangeCommitted;
		}
		private void CargarActividades()
		{
			try
			{
				cargandoActividades = true;

				dtActividades = clsCAL.ObtenerActividades();

				// ==========================================
				// COLUMNA PARA MOSTRAR:
				// CODIGO - DESCRIPCION
				// ==========================================

				if (!dtActividades.Columns.Contains("Descripcion"))
				{
					dtActividades.Columns.Add(
						"Descripcion",
						typeof(string));
				}

				actividadesOriginales.Clear();

				cboActividad.Items.Clear();

				foreach (DataRow fila in dtActividades.Rows)
				{
					string codigo =
						fila["c_codigo_tab"]
						.ToString()
						.Trim();

					string descripcion =
						fila["v_descripcion_tab"]
						.ToString()
						.Trim();

					string actividad =
						$"{codigo} - {descripcion}";

					// Guardar texto completo en la columna auxiliar
					fila["Descripcion"] = actividad;

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

			DiaRegistro dia =
				(DiaRegistro)cboFecha.SelectedItem;

			FechaSeleccionada =
				dia.Fecha;

			cboFecha.ForeColor =
				Color.Black;

			clsCAL.CargarActividadAnterior(FechaSeleccionada);
		}
		private void AsignarActividad()
		{
			dgvAgregarLoteyActividad.EndEdit();

			if (cboActividad.SelectedIndex < 0)
			{
				MessageBox.Show("Seleccione una actividad.");
				return;
			}

			string textoActividad =
				cboActividad.Text.Trim();

			string idActividad = "";

			int posicion =
				textoActividad.IndexOf("-");

			if (posicion > 0)
			{
				idActividad =
					textoActividad
					.Substring(0, posicion)
					.Trim();
			}

			if (string.IsNullOrWhiteSpace(idActividad))
			{
				MessageBox.Show(
					"No se pudo obtener el código de la actividad.");
				return;
			}

			int empleadosAsignados = 0;

			foreach (DataGridViewRow fila
				in dgvAgregarLoteyActividad.Rows)
			{
				if (fila.IsNewRow)
					continue;

				bool seleccionado =
					Convert.ToBoolean(
						fila.Cells["Seleccionar"].Value ?? false);

				if (!seleccionado)
					continue;

				// ==========================================
				// MOSTRAR LA ACTIVIDAD COMPLETA
				// IGUAL QUE EN EL COMBO
				// ==========================================

				fila.Cells["Actividad"].Value =
					textoActividad;

				// ==========================================
				// GUARDAR SOLAMENTE EL ID
				// ==========================================

				fila.Cells["IdActividad"].Value =
					idActividad;

				// Quitar selección
				fila.Cells["Seleccionar"].Value =
					false;

				empleadosAsignados++;
			}

			if (empleadosAsignados == 0)
			{
				MessageBox.Show(
					"Marque uno o varios empleados.");
				return;
			}
		}
		private void AsignarLote()
		{
			dgvAgregarLoteyActividad.EndEdit();

			if (cboLote.SelectedIndex < 0)
			{
				MessageBox.Show(
					"Seleccione un lote.",
					"Lote",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			// ==========================================
			// OBTENER FILA DEL LOTE
			// ==========================================

			if (!(cboLote.SelectedItem is DataRowView filaLote))
			{
				MessageBox.Show(
					"No se pudo obtener la información del lote.",
					"Lote",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			// ==========================================
			// OBTENER IDS
			// ==========================================

			string idLote =
				filaLote["id_lot"]?
				.ToString()
				.Trim();

			string idVariedad =
				filaLote["id_variety"]?
				.ToString()
				.Trim();

			string loteCompleto =
				filaLote["LoteCompleto"]?
				.ToString()
				.Trim();

			// ==========================================
			// VALIDAR
			// ==========================================

			if (string.IsNullOrWhiteSpace(idLote))
			{
				MessageBox.Show(
					"No se pudo obtener el ID del lote.",
					"Lote");

				return;
			}

			if (string.IsNullOrWhiteSpace(idVariedad))
			{
				MessageBox.Show(
					"No se pudo obtener la variedad del lote.",
					"Lote");

				return;
			}

			// ==========================================
			// ASIGNAR A EMPLEADOS SELECCIONADOS
			// ==========================================

			int empleadosAsignados = 0;

			foreach (DataGridViewRow fila
				in dgvAgregarLoteyActividad.Rows)
			{
				if (fila.IsNewRow)
					continue;

				bool seleccionado =
					Convert.ToBoolean(
						fila.Cells["Seleccionar"].Value ?? false);

				if (!seleccionado)
					continue;

				// ==========================================
				// MOSTRAR LOTE COMPLETO
				// ==========================================

				fila.Cells["Lote"].Value =
					idLote;

				// ==========================================
				// GUARDAR IDS REALES
				// ==========================================

				fila.Cells["IdLote"].Value =
					idLote;

				fila.Cells["IdVariedad"].Value =
					idVariedad;

				// ==========================================
				// QUITAR SELECCIÓN
				// ==========================================

				fila.Cells["Seleccionar"].Value =
					false;

				empleadosAsignados++;
			}

			if (empleadosAsignados == 0)
			{
				MessageBox.Show(
					"Marque uno o varios empleados.",
					"Empleados",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			MessageBox.Show(
				"Lote asignado correctamente.",
				"Lote",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information);
		}
		private void btnContinuar_Click(object sender, EventArgs e)
		{
			try
			{
				// ==========================================
				// FINALIZAR EDICIÓN DEL DGV
				// ==========================================

				dgvAgregarLoteyActividad.EndEdit();

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

				foreach (DataGridViewRow fila
						 in dgvAgregarLoteyActividad.Rows)
				{
					if (fila.IsNewRow)
						continue;

					// ==========================================
					// OBTENER EMPLEADO
					// ==========================================

					string codigoEmpleado =
						fila.Cells["Codigo"].Value?
						.ToString()
						.Trim();

					// ==========================================
					// OBTENER IDs REALES DE LA FILA
					// ==========================================

					string idActividad =
						fila.Cells["IdActividad"].Value?
						.ToString()
						.Trim();

					string idVariedad =
						fila.Cells["IdVariedad"].Value?
						.ToString()
						.Trim();

					string idLote =
						fila.Cells["IdLote"].Value?
						.ToString()
						.Trim();

					// ==========================================
					// VALIDAR EMPLEADO
					// ==========================================

					if (string.IsNullOrWhiteSpace(codigoEmpleado))
						continue;

					// ==========================================
					// VALIDAR ACTIVIDAD
					// ==========================================

					if (string.IsNullOrWhiteSpace(idActividad))
						continue;

					// ==========================================
					// VALIDAR VARIEDAD
					// ==========================================

					if (string.IsNullOrWhiteSpace(idVariedad))
						continue;

					// ==========================================
					// VALIDAR LOTE
					// ==========================================

					if (string.IsNullOrWhiteSpace(idLote))
						continue;

					// ==========================================
					// GUARDAR ESTA FILA
					// ==========================================

					clsCAL.GuardarActividadLoteCuadrilla(
						codigoEmpleado,
						SecuenciaSemana,
						FechaInicio,
						FechaFin,
						dia,
						IdCuadrilla,
						idActividad,
						idVariedad,
						idLote);

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
					$"La información se guardó correctamente.\n\n" +
					$"Empleados guardados: {empleadosGuardados}",
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

		private void cboLote_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				e.Handled = true;
			}
		}
		private void ConfigurarActividadDgv()
		{
			DataGridViewComboBoxColumn columna =
		dgvAgregarLoteyActividad.Columns["Actividad"]
		as DataGridViewComboBoxColumn;

			if (columna == null)
				return;

			DataTable dtCombo = dtActividades.Copy();

			// ==========================================
			// AGREGAR OPCIÓN VACÍA
			// ==========================================

			DataRow filaVacia = dtCombo.NewRow();

			filaVacia["c_codigo_tab"] = "";
			filaVacia["v_descripcion_tab"] = "";
			filaVacia["Descripcion"] = "";

			dtCombo.Rows.InsertAt(filaVacia, 0);

			// ==========================================
			// CONFIGURAR COMBOBOX
			// ==========================================

			columna.DataSource = dtCombo;

			columna.DisplayMember = "Descripcion";

			columna.ValueMember = "c_codigo_tab";

			columna.AutoComplete = false;
		}
		public void ConfigurarLoteDgv()
		{
			DataGridViewComboBoxColumn columna =
				dgvAgregarLoteyActividad.Columns["Lote"]
				as DataGridViewComboBoxColumn;

			if (columna == null)
				return;

			if (dtLotesDgv == null ||
				dtLotesDgv.Rows.Count == 0)
			{
				columna.DataSource = null;
				return;
			}

			// ==========================================
			// CREAR DATA TABLE PARA EL COMBO
			// ==========================================

			DataTable dtCombo = dtLotesDgv.Clone();

			// IMPORTANTE:
			// El ID del lote lo manejaremos como string
			dtCombo.Columns["id_lot"].DataType =
				typeof(string);

			foreach (DataRow fila in dtLotesDgv.Rows)
			{
				DataRow nuevaFila =
					dtCombo.NewRow();

				foreach (DataColumn columnaDatos
						 in dtLotesDgv.Columns)
				{
					nuevaFila[columnaDatos.ColumnName] =
						fila[columnaDatos.ColumnName];
				}

				nuevaFila["id_lot"] =
					fila["id_lot"]
					.ToString()
					.Trim();

				dtCombo.Rows.Add(nuevaFila);
			}

			// ==========================================
			// FILA VACÍA
			// ==========================================

			DataRow filaVacia =
				dtCombo.NewRow();

			filaVacia["id_lot"] = "";

			if (dtCombo.Columns.Contains("id_variety"))
				filaVacia["id_variety"] = "";

			if (dtCombo.Columns.Contains("c_codigo_lot"))
				filaVacia["c_codigo_lot"] = "";

			if (dtCombo.Columns.Contains("v_nameLot"))
				filaVacia["v_nameLot"] = "";

			if (dtCombo.Columns.Contains("NombreVariedad"))
				filaVacia["NombreVariedad"] = "";

			if (dtCombo.Columns.Contains("LoteCompleto"))
				filaVacia["LoteCompleto"] = "";

			dtCombo.Rows.InsertAt(
				filaVacia,
				0);

			// ==========================================
			// CONFIGURAR COLUMNA
			// ==========================================

			columna.DataSource = dtCombo;

			columna.DisplayMember =
				"LoteCompleto";

			columna.ValueMember =
				"id_lot";

			columna.DropDownWidth = 400;

			columna.FlatStyle =
				FlatStyle.Flat;

			columna.DisplayStyle =
				DataGridViewComboBoxDisplayStyle.DropDownButton;
		}
		private void dgvAgregarLoteyActividad_EditingControlShowing(
	object sender,
	DataGridViewEditingControlShowingEventArgs e)
		{
			if (dgvAgregarLoteyActividad.CurrentCell == null)
				return;

			if (!(e.Control is ComboBox combo))
				return;

			string columna =
				dgvAgregarLoteyActividad
				.CurrentCell
				.OwningColumn
				.Name;

			if (columna != "Lote")
				return;

			combo.DropDownStyle =
				ComboBoxStyle.DropDown;

			combo.AutoCompleteMode =
				AutoCompleteMode.None;

			combo.AutoCompleteSource =
				AutoCompleteSource.None;

			// ==========================================
			// TECLADO
			// ==========================================

			combo.KeyDown -=
				ComboLoteDgv_KeyDown;

			combo.KeyDown +=
				ComboLoteDgv_KeyDown;

			// ==========================================
			// FILTRO
			// ==========================================

			combo.TextChanged -=
				ComboLote_TextChanged;

			combo.TextChanged +=
				ComboLote_TextChanged;

			// ==========================================
			// SELECCIÓN
			// ==========================================

			combo.SelectionChangeCommitted -=
				ComboLote_SelectionChangeCommitted;

			combo.SelectionChangeCommitted +=
				ComboLote_SelectionChangeCommitted;

			// ==========================================
			// CUANDO SE CIERRA LA LISTA
			// ==========================================

			combo.DropDownClosed -=
				ComboLote_DropDownClosed;

			combo.DropDownClosed +=
				ComboLote_DropDownClosed;
		}
		private void ComboLote_DropDownClosed(
	object sender,
	EventArgs e)
		{
			if (!(sender is ComboBox combo))
				return;

			if (dgvAgregarLoteyActividad.CurrentCell == null)
				return;

			// ==========================================
			// OBTENER LA OPCIÓN SELECCIONADA
			// ==========================================

			if (!(combo.SelectedItem is DataRowView filaLote))
				return;

			string idLote =
				filaLote["id_lot"]
				?.ToString()
				.Trim();

			string idVariedad =
				filaLote["id_variety"]
				?.ToString()
				.Trim();

			if (string.IsNullOrWhiteSpace(idLote))
				return;

			if (string.IsNullOrWhiteSpace(idVariedad))
				return;

			// ==========================================
			// OBTENER FILA ACTUAL
			// ==========================================

			int filaActual =
				dgvAgregarLoteyActividad
				.CurrentCell
				.RowIndex;

			DataGridViewRow fila =
				dgvAgregarLoteyActividad
				.Rows[filaActual];

			// ==========================================
			// GUARDAR LOTE
			// ==========================================

			fila.Cells["Lote"].Value =
				idLote;

			// ==========================================
			// GUARDAR IDs
			// ==========================================

			fila.Cells["IdLote"].Value =
				idLote;

			fila.Cells["IdVariedad"].Value =
				idVariedad;
		}
		private void dgvAgregarLoteyActividad_KeyDown(object sender, KeyEventArgs e)
		{
			if (dgvAgregarLoteyActividad.CurrentCell == null)
				return;

			int fila =
				dgvAgregarLoteyActividad.CurrentCell.RowIndex;

			int columna =
				dgvAgregarLoteyActividad.CurrentCell.ColumnIndex;

			// ==========================================
			// FLECHA ABAJO
			// ==========================================

			if (e.KeyCode == Keys.Down)
			{
				if (fila <
					dgvAgregarLoteyActividad.Rows.Count - 1)
				{
					dgvAgregarLoteyActividad.CurrentCell =
						dgvAgregarLoteyActividad
						.Rows[fila + 1]
						.Cells[columna];
				}

				e.SuppressKeyPress = true;
				e.Handled = true;
				return;
			}

			// ==========================================
			// FLECHA ARRIBA
			// ==========================================

			if (e.KeyCode == Keys.Up)
			{
				if (fila > 0)
				{
					dgvAgregarLoteyActividad.CurrentCell =
						dgvAgregarLoteyActividad
						.Rows[fila - 1]
						.Cells[columna];
				}

				e.SuppressKeyPress = true;
				e.Handled = true;
				return;
			}

			// ==========================================
			// FLECHA DERECHA
			// BUSCAR SIGUIENTE COLUMNA VISIBLE
			// ==========================================

			if (e.KeyCode == Keys.Right)
			{
				int siguienteColumna =
					columna + 1;

				while (
					siguienteColumna <
					dgvAgregarLoteyActividad.Columns.Count &&
					!dgvAgregarLoteyActividad
						.Columns[siguienteColumna]
						.Visible)
				{
					siguienteColumna++;
				}

				if (siguienteColumna <
					dgvAgregarLoteyActividad.Columns.Count)
				{
					dgvAgregarLoteyActividad.CurrentCell =
						dgvAgregarLoteyActividad
						.Rows[fila]
						.Cells[siguienteColumna];
				}

				e.SuppressKeyPress = true;
				e.Handled = true;
				return;
			}

			// ==========================================
			// FLECHA IZQUIERDA
			// BUSCAR ANTERIOR COLUMNA VISIBLE
			// ==========================================

			if (e.KeyCode == Keys.Left)
			{
				int anteriorColumna =
					columna - 1;

				while (
					anteriorColumna >= 0 &&
					!dgvAgregarLoteyActividad
						.Columns[anteriorColumna]
						.Visible)
				{
					anteriorColumna--;
				}

				if (anteriorColumna >= 0)
				{
					dgvAgregarLoteyActividad.CurrentCell =
						dgvAgregarLoteyActividad
						.Rows[fila]
						.Cells[anteriorColumna];
				}

				e.SuppressKeyPress = true;
				e.Handled = true;
				return;
			}
		}
		private void ComboLote_TextChanged(object sender, EventArgs e)
		{
			if (filtrandoLote)
				return;

			if (!(sender is ComboBox combo))
				return;

			textoBusquedaLote =
				combo.Text.Trim();

			if (dtLotesDgv == null ||
				dtLotesDgv.Rows.Count == 0)
				return;

			filtrandoLote = true;

			try
			{
				DataTable filtradas =
					dtLotesDgv.Clone();

				foreach (DataRow fila in dtLotesDgv.Rows)
				{
					string codigo =
						fila["c_codigo_lot"]?.ToString().Trim() ?? "";

					string nombre =
						fila["v_nameLot"]?.ToString().Trim() ?? "";

					string variedad =
						fila["NombreVariedad"]?.ToString().Trim() ?? "";

					if (codigo.IndexOf(
							textoBusquedaLote,
							StringComparison.OrdinalIgnoreCase) >= 0
						||
						nombre.IndexOf(
							textoBusquedaLote,
							StringComparison.OrdinalIgnoreCase) >= 0
						||
						variedad.IndexOf(
							textoBusquedaLote,
							StringComparison.OrdinalIgnoreCase) >= 0)
					{
						filtradas.ImportRow(fila);
					}
				}

				if (filtradas.Rows.Count == 0)
				{
					combo.DroppedDown = false;
					return;
				}

				combo.DataSource =
					filtradas;

				combo.DisplayMember =
					"LoteCompleto";

				combo.ValueMember =
					"id_lot";

				// ==========================================
				// NINGÚN LOTE SELECCIONADO
				// ==========================================

				combo.SelectedIndex = -1;

				// ==========================================
				// CONSERVAR LO QUE ESCRIBIÓ
				// ==========================================

				combo.Text =
					textoBusquedaLote;

				combo.SelectionStart =
					combo.Text.Length;

				combo.SelectionLength =
					0;

				combo.DroppedDown = true;
			}
			finally
			{
				filtrandoLote = false;
			}
		}
		private void ComboLoteDgv_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode != Keys.Enter)
				return;

			if (!(sender is ComboBox combo))
				return;

			if (dgvAgregarLoteyActividad.CurrentCell == null)
				return;

			int filaActual =
				dgvAgregarLoteyActividad
				.CurrentCell
				.RowIndex;

			// ==========================================
			// OBTENER LOTE SELECCIONADO
			// ==========================================

			if (!(combo.SelectedItem is DataRowView filaLote))
			{
				MessageBox.Show(
					"Seleccione un lote de la lista.",
					"Lote");

				return;
			}

			string idLote =
				filaLote["id_lot"]
				.ToString()
				.Trim();

			string idVariedad =
				filaLote["id_variety"]
				.ToString()
				.Trim();

			if (string.IsNullOrWhiteSpace(idLote))
				return;

			if (string.IsNullOrWhiteSpace(idVariedad))
				return;

			// ==========================================
			// GUARDAR
			// ==========================================

			DataGridViewRow fila =
				dgvAgregarLoteyActividad
				.Rows[filaActual];

			// IMPORTANTE:
			// Guardar ID, NO LoteCompleto

			fila.Cells["Lote"].Value =
				idLote;

			fila.Cells["IdLote"].Value =
				idLote;

			fila.Cells["IdVariedad"].Value =
				idVariedad;

			// ==========================================
			// CERRAR COMBO
			// ==========================================

			combo.DroppedDown = false;

			dgvAgregarLoteyActividad.EndEdit();

			e.SuppressKeyPress = true;
			e.Handled = true;

			// ==========================================
			// SIGUIENTE FILA
			// ==========================================

			if (filaActual <
				dgvAgregarLoteyActividad.Rows.Count - 1)
			{
				int siguienteFila =
					filaActual + 1;

				dgvAgregarLoteyActividad.BeginInvoke(
					new Action(() =>
					{
						dgvAgregarLoteyActividad.CurrentCell =
							dgvAgregarLoteyActividad
							.Rows[siguienteFila]
							.Cells["Lote"];

						dgvAgregarLoteyActividad.BeginEdit(true);
					}));
			}
		}
		private void ComboLote_SelectionChangeCommitted(
	object sender,
	EventArgs e)
		{
			if (!(sender is ComboBox combo))
				return;

			if (dgvAgregarLoteyActividad.CurrentCell == null)
				return;

			// ==========================================
			// OBTENER EL LOTE QUE EL USUARIO SELECCIONÓ
			// ==========================================

			DataRowView filaLote =
				combo.SelectedItem as DataRowView;

			if (filaLote == null)
				return;

			// ==========================================
			// OBTENER DATOS DEL LOTE SELECCIONADO
			// ==========================================

			string idLote =
				filaLote["id_lot"]
				?.ToString()
				.Trim();

			string idVariedad =
				filaLote["id_variety"]
				?.ToString()
				.Trim();

			string loteCompleto =
					filaLote["LoteCompleto"]
					?.ToString()
					.Trim();

			if (string.IsNullOrWhiteSpace(idLote))
				return;

			if (string.IsNullOrWhiteSpace(idVariedad))
				return;

			// ==========================================
			// FILA ACTUAL
			// ==========================================

			int filaActual =
				dgvAgregarLoteyActividad.CurrentCell.RowIndex;

			DataGridViewRow fila =
				dgvAgregarLoteyActividad.Rows[filaActual];

			// ==========================================
			// MOSTRAR EL LOTE QUE EL USUARIO SELECCIONÓ
			// ==========================================

			fila.Cells["Lote"].Value =
				idLote;

			// ==========================================
			// GUARDAR IDs
			// ==========================================

			fila.Cells["IdLote"].Value =
				idLote;

			fila.Cells["IdVariedad"].Value =
				idVariedad;

			// ==========================================
			// ACTUALIZAR EL TEXTO DEL COMBO
			// ==========================================

			combo.Text =
				loteCompleto;

			combo.SelectionStart =
				combo.Text.Length;

			combo.SelectionLength = 0;

			// ==========================================
			// CERRAR LISTA
			// ==========================================

			combo.DroppedDown = false;
		}
		private void btnAsignar_Click(object sender, EventArgs e)
		{
			AsignarActividad();
		}

		private void btnLote_Click(object sender, EventArgs e)
		{
			AsignarLote();
		}

		private void dgvAgregarLoteyActividad_ColumnHeaderMouseClick(
	object sender,
	DataGridViewCellMouseEventArgs e)
		{
			if (e.ColumnIndex < 0)
				return;

			// Verificar que sea la columna Actividad
			if (dgvAgregarLoteyActividad
				.Columns[e.ColumnIndex]
				.Name != "Actividad")
			{
				return;
			}

			// ==========================================
			// RECORRER TODOS LOS EMPLEADOS
			// ==========================================

			foreach (DataGridViewRow fila
				in dgvAgregarLoteyActividad.Rows)
			{
				if (fila.IsNewRow)
					continue;

				string actividadAnterior =
					fila.Cells["ActividadAnterior"]
						.Value?
						.ToString()
						.Trim();

				// Si no tiene actividad anterior,
				// dejar Actividad vacía
				if (string.IsNullOrWhiteSpace(actividadAnterior))
				{
					fila.Cells["Actividad"].Value = "";
					fila.Cells["IdActividad"].Value = "";

					continue;
				}

				// ==========================================
				// COPIAR ACTIVIDAD ANTERIOR
				// ==========================================

				fila.Cells["Actividad"].Value =
					actividadAnterior;

				// ==========================================
				// OBTENER ID
				// ==========================================

				int posicion =
					actividadAnterior.IndexOf("-");

				if (posicion > 0)
				{
					string idActividad =
						actividadAnterior
							.Substring(0, posicion)
							.Trim();

					fila.Cells["IdActividad"].Value =
						idActividad;
				}
			}

			dgvAgregarLoteyActividad.Refresh();
		}
	}
}
		