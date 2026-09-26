using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisUvex.Catalogos.Nomina.LOAD;
using SisUvex.Nomina.Ingresos_Diversos;
using static SisUvex.Nomina.Nom_SemAutomaticaCampo.ClsNomina;

namespace SisUvex.Nomina.Nom_SemAutomaticaCampo
{
	public partial class FrmNomina : Form
	{
		public ClsNomina cls;
		bool cargando = false;
		private ClsListaCuadrillas listaCuadrillas;
		public List<object> cuadrillasSeleccionadas =new List<object>();
		public FrmNomina()
		{
			InitializeComponent();
			cls ??= new ClsNomina();
			cls.frm ??= this;

			InicializarListaCuadrillas();
		}
		public List<string> ObtenerIdsCuadrillasSeleccionadas()
		{
			return cuadrillasSeleccionadas
				.Cast<CuadrillaItem>()
				.Select(x => x.ID)
				.ToList();
		}
		private void InicializarListaCuadrillas()
		{
			listaCuadrillas =
				new ClsListaCuadrillas();

			splitNomina.Panel1.Controls.Add(
				listaCuadrillas
			);

			listaCuadrillas.Dock =
				DockStyle.Fill;

			listaCuadrillas.BringToFront();

			// ==========================================
			// CONECTAR EVENTO ACEPTAR
			// ==========================================

			listaCuadrillas.Aceptado +=
				ListaCuadrillas_Aceptado;

			// ==========================================
			// INICIAR OCULTO
			// ==========================================

			splitNomina.Panel1Collapsed = true;
		}

		private void FrmNomina_Load(object sender, EventArgs e)
		{
			cls.CargarCuadrillaCampoCheck(listaCuadrillas);
			cls.CargarCuadrillaCampo(cboCuadrillaRevisar);
			cls.CargarLugarPago(cboLugarPago);
			cls.CargarSemanas();
			txbReferencia.Text = dtpFecha.Value.ToString("yyyyMMdd");
			txbJornada.Text = "8";
			txbDestajo.Text = "0";
			cls.CargarCuadrillasConCsv(lbCSV, dtpFecha.Value.Date);
		}

		private void btnConsultar_Click(object sender, EventArgs e)
		{
			cls.ConsultarNomina();
		}

		private void dtpFecha_ValueChanged(object sender, EventArgs e)
		{
			txbReferencia.Text = dtpFecha.Value.ToString("yyyyMMdd");

			cls.CargarCuadrillasConCsv(lbCSV, dtpFecha.Value.Date);
		}

		private void btnCSV_Click(object sender, EventArgs e)
		{
			cls.GenerarArchivoCsv();
		}

		private void tabControl2_DrawItem(object sender, DrawItemEventArgs e)
		{
			TabControl tabControl = (TabControl)sender;

			Rectangle rect = e.Bounds;

			bool seleccionado = e.Index == tabControl.SelectedIndex;

			Color azulUvex = Color.FromArgb(40, 116, 166);
			Color fondoClaro = Color.FromArgb(242, 246, 249);

			Color colorFondo = seleccionado
				? azulUvex
				: fondoClaro;

			Color colorTexto = seleccionado
				? Color.White
				: azulUvex;

			// Dibujar fondo
			using (SolidBrush brush = new SolidBrush(colorFondo))
			{
				e.Graphics.FillRectangle(brush, rect);
			}

			// Dibujar texto
			using (SolidBrush brush = new SolidBrush(colorTexto))
			using (StringFormat sf = new StringFormat())
			using (Font fuente = new Font("Segoe UI", 9F, FontStyle.Bold))
			{
				sf.Alignment = StringAlignment.Center;
				sf.LineAlignment = StringAlignment.Center;

				e.Graphics.DrawString(
					tabControl.TabPages[e.Index].Text,
					fuente,
					brush,
					rect,
					sf
				);
			}
		}

		private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
		{
			tabControl2.Invalidate();
		}

		private void btnConsultarRevisar_Click(object sender, EventArgs e)
		{
			DataTable dt = cls.ConsultarNominaSemana();

			dgvNomina.DataSource = dt;
		}

		private void cboCuadrillaRevisar_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cargando)
				return;

			if (cboCuadrillaRevisar.SelectedIndex <= 0)
				return;

			if (cboSemana.SelectedIndex < 0)
				return;

			// Quitar Lugar de Pago
			cargando = true;
			cboLugarPago.SelectedIndex = 0;
			cargando = false;

			DataTable dt = cls.ConsultarNominaSemana();

			dgvNomina.DataSource = dt;

			DiseñarDgvNomina();
			ConfigurarColumnasNomina();

			dgvNomina.ClearSelection();
		}

		private void cboSemana_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cargando)
				return;

			if (cboSemana.SelectedIndex < 0)
				return;

			// Solo consultar si ya eligió Cuadrilla o Lugar de Pago
			if (cboCuadrillaRevisar.SelectedIndex > 0 ||
				cboLugarPago.SelectedIndex > 0)
			{
				DataTable dt = cls.ConsultarNominaSemana();

				dgvNomina.DataSource = dt;

				DiseñarDgvNomina();
				ConfigurarColumnasNomina();

				dgvNomina.ClearSelection();
			}
		}

		private void cboLugarPago_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cargando)
				return;

			if (cboLugarPago.SelectedIndex <= 0)
				return;

			if (cboSemana.SelectedIndex < 0)
				return;

			// Quitar Cuadrilla
			cargando = true;
			cboCuadrillaRevisar.SelectedIndex = 0;
			cargando = false;

			DataTable dt = cls.ConsultarNominaSemana();

			dgvNomina.DataSource = dt;

			DiseñarDgvNomina();
			ConfigurarColumnasNomina();

			dgvNomina.ClearSelection();
		}
		private void DiseñarDgvNomina()
		{
			// =========================================================
			// CONFIGURACIÓN GENERAL
			// =========================================================

			dgvNomina.BackgroundColor = Color.White;
			dgvNomina.BorderStyle = BorderStyle.None;

			dgvNomina.ReadOnly = true;
			dgvNomina.AllowUserToAddRows = false;
			dgvNomina.AllowUserToDeleteRows = false;
			dgvNomina.AllowUserToResizeRows = false;

			dgvNomina.RowHeadersVisible = false;

			dgvNomina.SelectionMode =
				DataGridViewSelectionMode.FullRowSelect;

			dgvNomina.MultiSelect = false;

			dgvNomina.AutoSizeRowsMode =
				DataGridViewAutoSizeRowsMode.None;

			dgvNomina.RowTemplate.Height = 24;

			dgvNomina.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.Fill;


			// =========================================================
			// FUENTE
			// =========================================================

			dgvNomina.Font =
				new Font("Segoe UI", 8.5F, FontStyle.Regular);

			dgvNomina.ColumnHeadersDefaultCellStyle.Font =
				new Font("Segoe UI", 8F, FontStyle.Bold);


			// =========================================================
			// ENCABEZADO
			// =========================================================

			dgvNomina.EnableHeadersVisualStyles = false;

			dgvNomina.ColumnHeadersHeight = 32;

			dgvNomina.ColumnHeadersDefaultCellStyle.BackColor =
				Color.FromArgb(52, 122, 168);

			dgvNomina.ColumnHeadersDefaultCellStyle.ForeColor =
				Color.White;

			dgvNomina.ColumnHeadersDefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgvNomina.ColumnHeadersDefaultCellStyle.SelectionBackColor =
				Color.FromArgb(52, 122, 168);

			dgvNomina.ColumnHeadersDefaultCellStyle.SelectionForeColor =
				Color.White;


			// =========================================================
			// FILAS
			// =========================================================

			dgvNomina.DefaultCellStyle.BackColor =
				Color.White;

			dgvNomina.DefaultCellStyle.ForeColor =
				Color.FromArgb(45, 45, 45);

			dgvNomina.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgvNomina.DefaultCellStyle.SelectionBackColor =
				Color.FromArgb(40, 116, 166);

			dgvNomina.DefaultCellStyle.SelectionForeColor =
				Color.White;

			dgvNomina.DefaultCellStyle.Padding =
				new Padding(3, 0, 3, 0);


			// =========================================================
			// FILAS ALTERNADAS
			// =========================================================

			dgvNomina.AlternatingRowsDefaultCellStyle.BackColor =
				Color.FromArgb(239, 246, 251);


			// =========================================================
			// BORDES
			// =========================================================

			dgvNomina.CellBorderStyle =
				DataGridViewCellBorderStyle.SingleHorizontal;

			dgvNomina.GridColor =
				Color.FromArgb(225, 232, 238);


			// =========================================================
			// QUITAR SELECCIÓN AL CARGAR
			// =========================================================

			dgvNomina.ClearSelection();
		}
		private void ConfigurarColumnasNomina()
		{
			// =========================================================
			// FOLIO
			// =========================================================

			dgvNomina.Columns["FOLIO"].FillWeight = 70;


			// =========================================================
			// NOMBRE
			// =========================================================

			dgvNomina.Columns["NOMBRE"].FillWeight = 180;

			dgvNomina.Columns["NOMBRE"]
				.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleLeft;


			// =========================================================
			// DT
			// =========================================================

			dgvNomina.Columns["DT"].FillWeight = 55;


			// =========================================================
			// DÍAS
			// =========================================================

			dgvNomina.Columns["VIE"].FillWeight = 75;
			dgvNomina.Columns["SAB"].FillWeight = 75;
			dgvNomina.Columns["DOM"].FillWeight = 75;
			dgvNomina.Columns["LUN"].FillWeight = 75;
			dgvNomina.Columns["MAR"].FillWeight = 75;
			dgvNomina.Columns["MIE"].FillWeight = 75;
			dgvNomina.Columns["JUE"].FillWeight = 75;


			// =========================================================
			// DESCUENTOS
			// =========================================================

			dgvNomina.Columns["DESCTOS"].FillWeight = 85;


			// =========================================================
			// IMPORTE NETO
			// =========================================================

			dgvNomina.Columns["IMPORTE NETO"].FillWeight = 105;


			// =========================================================
			// SEMANA
			// =========================================================

			dgvNomina.Columns["SEMANA"].FillWeight = 60;


			// =========================================================
			// LUGAR DE PAGO
			// =========================================================

			dgvNomina.Columns["LP"].FillWeight = 55;


			// =========================================================
			// FORMATO DE NÚMEROS
			// =========================================================

			string[] columnasImporte =
			{
		"VIE",
		"SAB",
		"DOM",
		"LUN",
		"MAR",
		"MIE",
		"JUE",
		"DESCTOS",
		"IMPORTE NETO"
	};

			foreach (string columna in columnasImporte)
			{
				if (dgvNomina.Columns.Contains(columna))
				{
					dgvNomina.Columns[columna]
						.DefaultCellStyle.Format = "N2";

					dgvNomina.Columns[columna]
						.DefaultCellStyle.Alignment =
						DataGridViewContentAlignment.MiddleRight;
				}
			}


			// =========================================================
			// DT
			// =========================================================

			dgvNomina.Columns["DT"]
				.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;


			// =========================================================
			// SEMANA
			// =========================================================

			dgvNomina.Columns["SEMANA"]
				.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;


			// =========================================================
			// LP
			// =========================================================

			dgvNomina.Columns["LP"]
				.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;
		}

		private void btnSeleccionar_Click(object sender, EventArgs e)
		{
			splitNomina.Panel1Collapsed = false;
		}
		private void ListaCuadrillas_Aceptado(object? sender,EventArgs e)
		{
			cuadrillasSeleccionadas =
				listaCuadrillas.ObtenerSeleccionados();

			if (cuadrillasSeleccionadas.Count == 0)
			{
				MessageBox.Show(
					"Seleccione al menos una cuadrilla.",
					"Cuadrillas",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);

				return;
			}

			// Cerrar panel
			splitNomina.Panel1Collapsed = true;

			// Mantener el texto del botón
			// y agregar la cantidad
			btnSeleccionar.Text =
				$" Seleccionadas ({cuadrillasSeleccionadas.Count})";
		}
	}
}
