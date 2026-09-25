using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Nomina.Nom_SemAutomaticaCampo
{
	public class ClsListaCuadrillas : Panel
	{
		private CheckedListBox lista;
		private Button btnTodas;
		private Button btnNinguna;
		private Button btnAceptar;
		private Label lblTitulo;
		public event EventHandler? Aceptado;

		public ClsListaCuadrillas()
		{
			// ==========================================
			// CONFIGURACIÓN DEL PANEL
			// ==========================================

			Dock = DockStyle.Fill;

			BackColor = Color.White;
			BorderStyle = BorderStyle.FixedSingle;
			// =====================================================
			// TÍTULO
			// =====================================================

			lblTitulo = new Label();

			lblTitulo.Text = "CUADRILLAS";

			lblTitulo.Font = new Font(
				"Segoe UI",
				16,
				FontStyle.Bold
			);

			lblTitulo.ForeColor = Color.White;

			lblTitulo.BackColor =
				Color.FromArgb(25, 105, 155);

			lblTitulo.TextAlign =
				ContentAlignment.MiddleLeft;

			lblTitulo.Dock =
				DockStyle.Top;

			lblTitulo.Height = 42;

			lblTitulo.Padding =
				new Padding(12, 0, 0, 0);

			Controls.Add(lblTitulo);

			// ==========================================
			// LISTA DE CUADRILLAS
			// ==========================================

			lista = new CheckedListBox();

			lista.CheckOnClick = true;

			lista.BorderStyle =
				BorderStyle.FixedSingle;

			lista.Location =
				new Point(12, 45);

			lista.Width = 278;

			lista.Anchor =
				AnchorStyles.Top |
				AnchorStyles.Left |
				AnchorStyles.Right |
				AnchorStyles.Bottom;

			Controls.Add(lista);

			// ==========================================
			// BOTÓN SELECCIONAR TODAS
			// ==========================================

			btnTodas = new Button();

			btnTodas.Text =
				"✓  Seleccionar Todas";

			btnTodas.Height = 35;

			btnTodas.Anchor =
				AnchorStyles.Left |
				AnchorStyles.Right |
				AnchorStyles.Bottom;

			btnTodas.Click += BtnTodas_Click;

			Controls.Add(btnTodas);

			// ==========================================
			// BOTÓN QUITAR SELECCIÓN
			// ==========================================

			btnNinguna = new Button();

			btnNinguna.Text =
				"✕  Quitar Selección";

			btnNinguna.Height = 35;

			btnNinguna.Anchor =
				AnchorStyles.Left |
				AnchorStyles.Right |
				AnchorStyles.Bottom;

			btnNinguna.Click += BtnNinguna_Click;

			Controls.Add(btnNinguna);

			// ==========================================
			// BOTÓN ACEPTAR
			// ==========================================

			btnAceptar = new Button();

			btnAceptar.Text =
				"Aceptar";

			btnAceptar.Height = 35;

			btnAceptar.Anchor =
				AnchorStyles.Left |
				AnchorStyles.Right |
				AnchorStyles.Bottom;

			btnAceptar.Click += BtnAceptar_Click;

			Controls.Add(btnAceptar);

			// ==========================================
			// AJUSTAR POSICIONES
			// ==========================================

			Resize += ClsListaCuadrillas_Resize;

			AjustarControles();
		}

		// =========================================================
		// AJUSTAR CONTROLES
		// =========================================================

		private void ClsListaCuadrillas_Resize(
			object sender,
			EventArgs e)
		{
			AjustarControles();
		}

		private void AjustarControles()
		{
			if (lista == null)
				return;

			int margen = 10;

			int ancho =
				Width - (margen * 2);

			// ==========================================
			// TÍTULO
			// ==========================================

			lblTitulo.Location =
				new Point(
					margen,
					10
				);

			lblTitulo.Width =
				ancho;

			// ==========================================
			// BOTONES
			// ==========================================

			int altoBoton = 35;

			int separacion = 5;

			int yAceptar =
				Height
				- margen
				- altoBoton;

			int yNinguna =
				yAceptar
				- separacion
				- altoBoton;

			int yTodas =
				yNinguna
				- separacion
				- altoBoton;

			btnAceptar.Location =
				new Point(
					margen,
					yAceptar
				);

			btnAceptar.Width =
				ancho;

			btnNinguna.Location =
				new Point(
					margen,
					yNinguna
				);

			btnNinguna.Width =
				ancho;

			btnTodas.Location =
				new Point(
					margen,
					yTodas
				);

			btnTodas.Width =
				ancho;

			// ==========================================
			// LISTA
			// ==========================================

			int listaTop = 45;

			int listaBottom =
				yTodas - separacion;

			lista.Location =
				new Point(
					margen,
					listaTop
				);

			lista.Width =
				ancho;

			lista.Height =
				listaBottom - listaTop;
		}

		// =========================================================
		// AGREGAR CUADRILLA
		// =========================================================

		public void AgregarCuadrilla(object cuadrilla)
		{
			lista.Items.Add(
				cuadrilla,
				false
			);
		}

		// =========================================================
		// LIMPIAR
		// =========================================================

		public void Limpiar()
		{
			lista.Items.Clear();
		}

		// =========================================================
		// SELECCIONAR TODAS
		// =========================================================

		private void BtnTodas_Click(
			object sender,
			EventArgs e)
		{
			for (
				int i = 0;
				i < lista.Items.Count;
				i++)
			{
				lista.SetItemChecked(
					i,
					true
				);
			}
		}

		// =========================================================
		// QUITAR SELECCIÓN
		// =========================================================

		private void BtnNinguna_Click(
			object sender,
			EventArgs e)
		{
			for (
				int i = 0;
				i < lista.Items.Count;
				i++)
			{
				lista.SetItemChecked(
					i,
					false
				);
			}
		}

		// =========================================================
		// ACEPTAR
		// =========================================================

		private void BtnAceptar_Click(
			object sender,
			EventArgs e)
		{
			Aceptado?.Invoke(
			this,
			EventArgs.Empty
			);
		}

		// =========================================================
		// OBTENER SELECCIONADOS
		// =========================================================

		public List<object> ObtenerSeleccionados()
		{
			return lista.CheckedItems
				.Cast<object>()
				.ToList();
		}

		// =========================================================
		// CANTIDAD
		// =========================================================

		public int CantidadSeleccionados()
		{
			return lista.CheckedItems.Count;
		}

		// =========================================================
		// MOSTRAR
		// =========================================================

		public void Mostrar()
		{
			Visible = true;

			BringToFront();

			lista.Focus();
		}

		// =========================================================
		// OCULTAR
		// =========================================================

		public void Ocultar()
		{
			Visible = false;
		}
	}
}