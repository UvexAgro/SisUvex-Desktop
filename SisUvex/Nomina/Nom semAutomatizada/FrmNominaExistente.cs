using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Nomina.LOAD;

namespace SisUvex.Nomina.Nom_semAutomatizada
{
	public partial class FrmNominaExistente : Form
	{
		ClsSemiAutomatedPayroll cls;
		ClsCierre clsC;
		private Color colorTema;
		public string TipoFestivo { get; private set; }
		public FrmNominaExistente()
		{
			InitializeComponent();

			this.StartPosition = FormStartPosition.CenterParent;
			cls = new ClsSemiAutomatedPayroll();
			clsC = new ClsCierre();
			// Asignar eventos
			btnMostrar.MouseEnter += Boton_MouseEnter;
			btnMostrar.MouseLeave += Boton_MouseLeave;

			btnRecalcular.MouseEnter += Boton_MouseEnter;
			btnRecalcular.MouseLeave += Boton_MouseLeave;

			btnCancelar.MouseEnter += Boton_MouseEnter;
			btnCancelar.MouseLeave += Boton_MouseLeave;
		}
		private void Boton_MouseEnter(object sender, EventArgs e)
		{
			Button btn = (Button)sender;

			btn.BackColor = colorTema;
			btn.ForeColor = Color.White;
		}

		private void Boton_MouseLeave(object sender, EventArgs e)
		{
			Button btn = (Button)sender;

			btn.BackColor = Color.White;
			btn.ForeColor = Color.Black;
		}
		private void btnMostrar_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnRecalcular_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		public void CargarDatos(string tipoNomina, DateTime fecha)
		{
			TipoFestivo = "";
			lblGenero.Text = tipoNomina == "E" ? "Espárrago" : "Uva";
			lblFechaNomina.Text = $"{fecha:dd/MM/yyyy}";

			DataTable dt = cls.ObtenerInfoNomina(fecha, tipoNomina);

			if (dt.Rows.Count > 0)
			{
				lblUsuario.Text = dt.Rows[0]["Usuario"].ToString();

				lblFecha.Text = Convert.ToDateTime(dt.Rows[0]["Fecha"])
					.ToString("dd/MM/yyyy HH:mm");

				if (dt.Columns.Contains("TipoFestivo") &&
					dt.Rows[0]["TipoFestivo"] != DBNull.Value)
				{
					TipoFestivo = dt.Rows[0]["TipoFestivo"].ToString();
				}
			}
			else
			{
				lblUsuario.Text = "";
				lblFecha.Text = fecha.ToString("dd/MM/yyyy HH:mm");
			}

			// Obtener empleados de la nómina
			string fechaTexto =
				fecha.ToString("yyyy-MM-dd");

			string query = tipoNomina == "E"
				? $"EXEC sp_GetReporteNominaDiaria_Esparrago '{fechaTexto}'"
				: $"EXEC sp_GetReporteNominaDiaria_Uva '{fechaTexto}'";

			DataTable dtNomina =
				ClsQuerysDB.GetDataTable(query);

			int cantidadEmpleados =
				dtNomina.Rows.Count;

			lblCantidadEmpleados.Text =
				$"{cantidadEmpleados}";

			CargarImagenTipoNomina(tipoNomina);
			AplicarColores(tipoNomina);
		}
		public enum ModoNomina
		{
			FestivoInicial,
			NominaExistente,
			NominaFestivaExistente
		}
		public void ConfigurarModo(ModoNomina modo)
		{
			switch (modo)
			{
				case ModoNomina.FestivoInicial:

					lblTitulo.Text = "DÍA FESTIVO";

					btnMostrar.Text = "Generar Nómina Normal";
					btnRecalcular.Text = "Generar Nómina Festiva";
					btnCancelar.Text = "Cancelar";

					btnMostrar.DialogResult = DialogResult.No;
					btnRecalcular.DialogResult = DialogResult.Yes;
					btnCancelar.DialogResult = DialogResult.Cancel;


					btnCancelar.Image = Properties.Resources.x__1_;

					break;

				case ModoNomina.NominaExistente:

					lblTitulo.Text = "NÓMINA EXISTENTE";

					btnMostrar.Text = "Mostrar Nómina";
					btnRecalcular.Text = "Recalcular Nómina";
					btnCancelar.Text = "Cancelar";

					btnMostrar.DialogResult = DialogResult.No;
					btnRecalcular.DialogResult = DialogResult.Yes;
					btnCancelar.DialogResult = DialogResult.Cancel;

					btnCancelar.Image = Properties.Resources.x__1_;

					break;

				case ModoNomina.NominaFestivaExistente:

					lblTitulo.Text = "NÓMINA EXISTENTE";

					btnMostrar.Text = "Mostrar Nómina";
					btnRecalcular.Text = "Recalcular Nómina Normal";
					btnCancelar.Text = "Recalcular Nómina Festiva";

					btnMostrar.DialogResult = DialogResult.No;
					btnRecalcular.DialogResult = DialogResult.Yes;
					btnCancelar.DialogResult = DialogResult.Retry;

					btnCancelar.Image = Properties.Resources.refrescar;

					break;
			}
		}

		private void CargarImagenTipoNomina(string tipoNomina)
		{
			ptbGenero.SizeMode = PictureBoxSizeMode.Zoom;

			if (tipoNomina == "E")
				ptbGenero.Image = Properties.Resources.esparragoss;
			else
				ptbGenero.Image = Properties.Resources.uvatres;
		}
		private void FrmNominaExistente_Load(object sender, EventArgs e)
		{

		}
		public void AplicarColores(string tipo)
		{
			Color color;

			switch (tipo)
			{
				case "E":
					color = Color.FromArgb(0, 91, 45); // Espárrago
					break;

				case "U":
					color = Color.FromArgb(91, 45, 120); // Uva
					break;

				default:
					color = SystemColors.Control;
					break;
			}

			plNomina.BackColor = color;
			lblTitulo.ForeColor = color;

			lbldatos.ForeColor = color;
			lblAccion.ForeColor = color;
			lblGeneracion.ForeColor = color;

			// Mostrar Nómina
			btnMostrar.BackColor = Color.White;
			btnMostrar.ForeColor = Color.Black;
			btnMostrar.FlatStyle = FlatStyle.Flat;
			btnMostrar.FlatAppearance.BorderColor = color;
			btnMostrar.FlatAppearance.BorderSize = 1;

			// Recalcular Nómina
			btnRecalcular.BackColor = Color.White;
			btnRecalcular.ForeColor = Color.Black;
			btnRecalcular.FlatStyle = FlatStyle.Flat;
			btnRecalcular.FlatAppearance.BorderColor = color;
			btnRecalcular.FlatAppearance.BorderSize = 1;

			// Cancelar
			btnCancelar.BackColor = Color.White;
			btnCancelar.ForeColor = Color.Black;
			btnCancelar.FlatStyle = FlatStyle.Flat;
			btnCancelar.FlatAppearance.BorderColor = Color.Gray;
			btnCancelar.FlatAppearance.BorderSize = 1;
		}
		public void BloquearRecalculo()
		{
			btnRecalcular.Enabled = false;

		}
		public void BloquearCancelar()
		{
			btnCancelar.Enabled = false;
		}

		private void gbDatos_Enter(object sender, EventArgs e)
		{

		}
	}
}
