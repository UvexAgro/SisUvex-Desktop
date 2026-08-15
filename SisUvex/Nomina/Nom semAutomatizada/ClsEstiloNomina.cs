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

		public void ActivarEstiloGrid(DataGridView dgv)
		{
			if (dgv == null) return;

			dgv.EnableHeadersVisualStyles = false;
			dgv.RowHeadersVisible = false;
			dgv.BorderStyle = BorderStyle.None;
			dgv.BackgroundColor = System.Drawing.Color.White;
			dgv.ColumnHeadersHeight = 40;

			dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);

			dgv.DefaultCellStyle.SelectionBackColor = dgv.DefaultCellStyle.BackColor;
			dgv.DefaultCellStyle.SelectionForeColor = dgv.DefaultCellStyle.ForeColor;

			dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;

			dgv.CellPainting -= PintarCeldaGrid;
			dgv.CellPainting += PintarCeldaGrid;

			dgv.SelectionChanged += (s, e) => dgv.ClearSelection();
		}
		private void PintarCeldaGrid(object sender, DataGridViewCellPaintingEventArgs e)
		{
			DataGridView dgv = sender as DataGridView;
			if (dgv == null) return;

			System.Drawing.Color colorHeader;
			System.Drawing.Color fondoBase;
			System.Drawing.Color colorLinea;

			switch (TipoNomina)
			{
				case "E":
					// Espárrago
					colorHeader = System.Drawing.Color.FromArgb(34, 139, 34);
					fondoBase = System.Drawing.Color.FromArgb(240, 255, 240);
					colorLinea = System.Drawing.Color.FromArgb(180, 220, 180);
					break;

				case "U":
					// Uva
					colorHeader = System.Drawing.Color.FromArgb(102, 0, 153);
					fondoBase = System.Drawing.Color.FromArgb(245, 240, 255);
					colorLinea = System.Drawing.Color.FromArgb(210, 180, 230);
					break;

				default:
					colorHeader = SystemColors.ControlDark;
					fondoBase = System.Drawing.Color.White;
					colorLinea = SystemColors.ControlLight;
					break;
			}
			// HEADER
			if (e.RowIndex == -1 && e.ColumnIndex >= 0)
			{
				using (SolidBrush brush = new SolidBrush(colorHeader))
				{
					e.Graphics.FillRectangle(brush, e.CellBounds);
				}

				TextRenderer.DrawText(
					e.Graphics,
					e.FormattedValue?.ToString() ?? "",
					new Font("Segoe UI", 10, FontStyle.Bold),
					e.CellBounds,
					System.Drawing.Color.White,
					TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

				using (Pen pen = new Pen(colorLinea))
				{
					e.Graphics.DrawRectangle(
						pen,
						e.CellBounds.X,
						e.CellBounds.Y,
						e.CellBounds.Width - 1,
						e.CellBounds.Height - 1);
				}

				e.Handled = true;
				return;
			}
			// CELDAS
			if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
			{
				System.Drawing.Color fondo = (e.RowIndex % 2 == 0)
					? fondoBase
					: System.Drawing.Color.White;

				// Resaltar cambios en SueldoTotal
				if (dgv.Columns[e.ColumnIndex].Name == "SueldoTotal")
				{
					DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

					decimal original = 0;
					decimal nuevo = 0;

					decimal.TryParse(Convert.ToString(cell.Tag), out original);
					decimal.TryParse(Convert.ToString(cell.Value), out nuevo);

					if (original != nuevo)
						fondo = System.Drawing.Color.FromArgb(255, 236, 179);
				}

				using (SolidBrush brush = new SolidBrush(fondo))
				{
					e.Graphics.FillRectangle(brush, e.CellBounds);
				}

				TextRenderer.DrawText(
					e.Graphics,
					e.FormattedValue?.ToString() ?? "",
					new Font("Segoe UI", 10),
					e.CellBounds,
					System.Drawing.Color.Black,
					TextFormatFlags.Left | TextFormatFlags.VerticalCenter);

				using (Pen pen = new Pen(colorLinea))
				{
					e.Graphics.DrawRectangle(
						pen,
						e.CellBounds.X,
						e.CellBounds.Y,
						e.CellBounds.Width - 1,
						e.CellBounds.Height - 1);
				}

				e.Handled = true;
			}
		}
		public void AplicarColores(string tipo)
		{
			// Guardar el tema actual
			TemaActual = tipo;
			TipoNomina = tipo; 

			System.Drawing.Color color;
			System.Drawing.Color colorOscuro;

			switch (tipo)
			{
				case "E":
					color = System.Drawing.Color.FromArgb(230, 245, 230);
					colorOscuro = System.Drawing.Color.FromArgb(40, 120, 45);

					frm.lblencabezado.Text = "Empaque Central - Espárrago";
					break;

				case "U":
					color = System.Drawing.Color.FromArgb(240, 230, 250);
					colorOscuro = System.Drawing.Color.FromArgb(106, 27, 154);

					frm.lblencabezado.Text = "Empaque Central - Uva";
					break;

				default:
					color = SystemColors.Control;
					colorOscuro = SystemColors.ControlDark;

					frm.lblencabezado.Text = "Reporte de Empaque Central";
					break;
			}

			frm.gbCsv.BackColor = color;
			frm.gbLibras.BackColor = color;
			frm.gbGenerar.BackColor = color;
			frm.gbFecha.BackColor = color;
			frm.gbSueldos.BackColor = color;
			frm.plCerrar.BackColor = color;

			frm.plTitulo.BackColor = colorOscuro;
			frm.lblencabezado.ForeColor = System.Drawing.Color.White;

			// Volver a pintar el DataGridView
			if (frm.dgvEmployee != null)
			{
				frm.dgvEmployee.Invalidate();
				frm.dgvEmployee.Refresh();
			}
		}
	}
}
