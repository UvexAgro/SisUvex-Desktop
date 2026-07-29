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

namespace SisUvex.Nomina.Nom_semAutomatizada
{
	public partial class FrmNominaExistente : Form
	{
	    ClsSemiAutomatedPayroll cls;
		private Color colorTema;
		public FrmNominaExistente()
		{
			InitializeComponent();
			cls = new ClsSemiAutomatedPayroll();
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
			lblGenero.Text = tipoNomina == "E" ? "Espárrago" : "Uva";

			DataTable dt = cls.ObtenerInfoNomina(fecha, tipoNomina);

			if (dt.Rows.Count > 0)
			{
				lblUsuario.Text = dt.Rows[0]["Usuario"].ToString();
				lblFecha.Text = Convert.ToDateTime(dt.Rows[0]["Fecha"])
					.ToString("dd/MM/yyyy HH:mm");
			}
			else
			{
				lblUsuario.Text = "";
				lblFecha.Text = fecha.ToString("dd/MM/yyyy HH:mm");
			}

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
			string nombreImagen = tipoNomina == "E"
				? "esparragos1.png"
				: "uvas1.png";

			string ruta = Path.Combine(
				@"C:\SisUvex\SisUvex-Desktop\SisUvex\Resources",
				nombreImagen);

			if (File.Exists(ruta))
			{
				ptbGenero.SizeMode = PictureBoxSizeMode.Zoom;
				ptbGenero.Image = Image.FromFile(ruta);
			}
			else
			{
				MessageBox.Show("No se encontró la imagen:\n" + ruta);
				ptbGenero.Image = null;
			}
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
					color = Color.FromArgb(76, 175, 80); // Espárrago
					break;

				case "U":
					color = Color.FromArgb(106, 27, 154); // Uva
					break;

				default:
					color = SystemColors.Control;
					break;
			}

			plNomina.BackColor = color;

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
	}
}
