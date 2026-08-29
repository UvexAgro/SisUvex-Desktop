using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Nomina.Nom_semAutomatizada
{
	internal class ClsEstiloNomina
	{
		public FrmSemiAutomatedPayroll frm;
		internal ClsSemiAutomatedPayroll cls;
		public string TemaActual = "E";
		public string TipoNomina { get; set; }

		public void CargarImagenTipoNomina(string tipo)
		{
			switch (tipo)
			{
				case "E":
					frm.pbImagen.Image =
						Properties.Resources.esparragoss;
					break;

				case "U":
					frm.pbImagen.Image =
						Properties.Resources.uvatres;
					break;

				default:
					frm.pbImagen.Image = null;
					break;
			}

			frm.pbImagen.SizeMode =
				PictureBoxSizeMode.Zoom;
		}

		public void AplicarColores(string tipo)
		{
			// Guardar el tema actual
			TemaActual = tipo;
			TipoNomina = tipo;

			CargarImagenTipoNomina(tipo);

			System.Drawing.Color color;
			System.Drawing.Color colorOscuro;
			System.Drawing.Color fondoFormulario;

			switch (tipo)
			{
				case "E":
					color = System.Drawing.Color.FromArgb(228, 236, 231);
					colorOscuro = System.Drawing.Color.FromArgb(0, 91, 45);
					fondoFormulario = System.Drawing.Color.FromArgb(245, 249, 246);


					frm.lblencabezado.Text = "Empaque Central - Espárrago";
					break;

				case "U":
					color = System.Drawing.Color.FromArgb(238, 231, 243);
					colorOscuro = System.Drawing.Color.FromArgb(91, 45, 120);
					fondoFormulario = System.Drawing.Color.FromArgb(249, 246, 250);

					frm.lblencabezado.Text = "Empaque Central - Uva";
					break;

				default:
					color = SystemColors.Control;
					colorOscuro = SystemColors.ControlDark;
					fondoFormulario = System.Drawing.Color.FromArgb(245, 247, 246);

					frm.lblencabezado.Text = "Reporte de Empaque Central";
					break;
			}

			frm.BackColor = fondoFormulario;
			frm.gbCsv.BackColor = color;
			frm.gbLibras.BackColor = color;
			frm.gbGenerar.BackColor = color;
			frm.gbFecha.BackColor = color;
			frm.gbSueldos.BackColor = color;
			frm.plCerrar.BackColor = color;
			frm.gbTipo.BackColor = color;
			frm.plCajas.BackColor = color;
			frm.plEmpleados.BackColor = color;

			frm.pnCerrar.BackColor = colorOscuro;
			frm.plTitulo.BackColor = colorOscuro;
			frm.lblNomina.ForeColor = System.Drawing.Color.White;
			frm.lblencabezado.ForeColor = System.Drawing.Color.White;
			frm.lblSubtitulo.ForeColor = System.Drawing.Color.White;

			// Volver a pintar el DataGridView
			if (frm.dgvEmployee != null)
			{
				frm.dgvEmployee.Invalidate();
				frm.dgvEmployee.Refresh();
			}
		}
		public void ActivarEstiloGrid(DataGridView dgv)
		{
			if (dgv == null) return;

			System.Drawing.Color colorPrincipal;
			System.Drawing.Color colorAlterno;
			System.Drawing.Color colorSeleccion;

			switch (TipoNomina)
			{
				case "E":

					colorPrincipal =
						System.Drawing.Color.FromArgb(0, 91, 45);

					colorAlterno =
						System.Drawing.Color.FromArgb(248, 251, 249);

					colorSeleccion =
						System.Drawing.Color.FromArgb(232, 245, 236);

					break;

				case "U":

					colorPrincipal =
						System.Drawing.Color.FromArgb(91, 45, 120);

					colorAlterno =
						System.Drawing.Color.FromArgb(250, 247, 252);

					colorSeleccion =
						System.Drawing.Color.FromArgb(242, 233, 248);

					break;

				default:

					colorPrincipal =
						System.Drawing.Color.FromArgb(70, 70, 70);

					colorAlterno =
						System.Drawing.Color.FromArgb(248, 248, 248);

					colorSeleccion =
						System.Drawing.Color.FromArgb(235, 235, 235);

					break;
			}



			dgv.EnableHeadersVisualStyles = false;
			dgv.RowHeadersVisible = false;

			dgv.BorderStyle =
				BorderStyle.None;

			dgv.BackgroundColor =
				System.Drawing.Color.White;

			dgv.GridColor =
				System.Drawing.Color.FromArgb(232, 232, 232);

			dgv.CellBorderStyle =
				DataGridViewCellBorderStyle.SingleHorizontal;

			dgv.ColumnHeadersBorderStyle =
				DataGridViewHeaderBorderStyle.None;



			dgv.ColumnHeadersDefaultCellStyle.BackColor =
				colorPrincipal;

			dgv.ColumnHeadersDefaultCellStyle.ForeColor =
				System.Drawing.Color.White;

			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor =
				colorPrincipal;

			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor =
				System.Drawing.Color.White;

			dgv.ColumnHeadersDefaultCellStyle.Font =
				new Font(
					"Segoe UI",
					9F,
					FontStyle.Bold);

			dgv.ColumnHeadersDefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.ColumnHeadersHeight = 42;


			dgv.DefaultCellStyle.Font =
				new Font(
					"Segoe UI",
					9F);

			dgv.DefaultCellStyle.ForeColor =
				System.Drawing.Color.FromArgb(
					45,
					45,
					45);

			dgv.DefaultCellStyle.BackColor =
				System.Drawing.Color.White;

			dgv.DefaultCellStyle.SelectionBackColor =
				colorSeleccion;

			dgv.DefaultCellStyle.SelectionForeColor =
				System.Drawing.Color.FromArgb(
					30,
					30,
					30);


			dgv.AlternatingRowsDefaultCellStyle.BackColor =
				colorAlterno;


			dgv.RowTemplate.Height = 34;

			dgv.AllowUserToResizeRows = false;

			dgv.SelectionMode =
				DataGridViewSelectionMode.FullRowSelect;

			dgv.MultiSelect = false;

			dgv.CellFormatting -= Dgv_CellFormatting;
			dgv.CellFormatting += Dgv_CellFormatting;
		}
		private void Dgv_CellFormatting(
		object sender,
		DataGridViewCellFormattingEventArgs e)
		{
			DataGridView dgv = sender as DataGridView;

			if (dgv == null)
				return;

			if (e.RowIndex < 0 || e.ColumnIndex < 0)
				return;

			if (dgv.Columns[e.ColumnIndex].Name == "SueldoTotal")
			{
				DataGridViewCell cell =
					dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

				decimal original;
				decimal nuevo;

				if (decimal.TryParse(
					Convert.ToString(cell.Tag),
					out original) &&
					decimal.TryParse(
					Convert.ToString(cell.Value),
					out nuevo))
				{
					if (original != nuevo)
					{
						e.CellStyle.BackColor =
							System.Drawing.Color.FromArgb(
								255, 244, 204);
					}
					else
					{
						// Regresar al color normal
						e.CellStyle.BackColor =
							dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor;
					}
				}
			}
		}
	}
}

		