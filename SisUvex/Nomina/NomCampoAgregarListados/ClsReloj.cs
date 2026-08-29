using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.Formula.Functions;

namespace SisUvex.Nomina.NomCampoAgregarListados
{
	public class ClsReloj
	{
		private SQLControl sql = new SQLControl();
		public FrmAsistencia _frmA;
		public DataTable CargarAsistenciaReloj(string idWorkGroup, DateTime fechaInicio, DateTime fechaFin)
		{
			DataTable dt = new DataTable();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"sp_GetAsistenciaRelojSemanal",
					sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@id_workGroup", SqlDbType.Char, 4).Value =
						idWorkGroup;

					cmd.Parameters.Add("@fechaInicio", SqlDbType.Date).Value =
						fechaInicio.Date;

					cmd.Parameters.Add("@fechaFin", SqlDbType.Date).Value =
						fechaFin.Date;

					using (SqlDataAdapter da = new SqlDataAdapter(cmd))
					{
						da.Fill(dt);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al cargar la asistencia del reloj:\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				sql.CloseConectionWrite();
			}

			return dt;
		}
		public void CargarRelojChecador()
		{
			if (_frmA.cboCuadrilla.SelectedIndex == -1 ||
				_frmA.cboSemana.SelectedIndex == -1)
				return;

			string idWorkGroup =
				_frmA.cboCuadrilla.SelectedValue.ToString();

			DataRowView semana =
				(DataRowView)_frmA.cboSemana.SelectedItem;

			DateTime fechaInicio =
				Convert.ToDateTime(
					semana["d_startDate_per"]).Date;

			DateTime fechaFin =
				Convert.ToDateTime(
					semana["d_endDate_per"]).Date;

			DataTable dt = CargarAsistenciaReloj(
				idWorkGroup,
				fechaInicio,
				fechaFin);

			_frmA.dgvChecador.DataSource = dt;

			ConfigurarGridChecador();

			AplicarColoresAsistencia();

			_frmA.dgvChecador.ClearSelection();
			_frmA.dgvChecador.CurrentCell = null;

			_frmA.dgvChecador.Invalidate();
		}
		private void AplicarColoresAsistencia()
		{
			string[] columnas =
			{
					"VIE",
					"SAB",
					"DOM",
					"LUN",
					"MAR",
					"MIÉ",
					"JUE"
				};

			foreach (DataGridViewRow fila in _frmA.dgvChecador.Rows)
			{
				foreach (string columna in columnas)
				{
					if (!_frmA.dgvChecador.Columns.Contains(columna))
						continue;

					DataGridViewCell celda = fila.Cells[columna];

					// Fondo normal de la celda
					celda.Style.BackColor = Color.White;
					celda.Style.ForeColor = Color.Black;
					celda.Style.Alignment =
						DataGridViewContentAlignment.MiddleCenter;
				}
			}
		}
		public void DgvChecador_CellPainting(
	object sender,
	DataGridViewCellPaintingEventArgs e)
		{
			string[] columnas =
			{
		"VIE",
		"SAB",
		"DOM",
		"LUN",
		"MAR",
		"MIÉ",
		"JUE"
	};

			if (e.RowIndex < 0 || e.ColumnIndex < 0)
				return;

			string nombreColumna =
				_frmA.dgvChecador.Columns[e.ColumnIndex].Name;

			if (!columnas.Contains(nombreColumna))
				return;

			string estado =
				e.Value?.ToString()?.Trim() ?? "";

			if (string.IsNullOrWhiteSpace(estado))
				return;

			Color color;

			switch (estado)
			{
				case "E/S":
					color = Color.Green;
					break;

				case "E":
					color = Color.Gold;
					break;

				case "S":
					color = Color.Orange;
					break;

				case "F":
					color = Color.Red;
					break;

				default:
					return;
			}

			// Fondo
			e.PaintBackground(
				e.CellBounds,
				true);

			// Borde
			e.Paint(
				e.CellBounds,
				DataGridViewPaintParts.Border);

			// ==========================
			// CÍRCULO
			// ==========================

			int tamaño = Math.Min(
				e.CellBounds.Width,
				e.CellBounds.Height) - 3;

			Rectangle circulo = new Rectangle(
				e.CellBounds.X +
					(e.CellBounds.Width - tamaño) / 2,

				e.CellBounds.Y +
					(e.CellBounds.Height - tamaño) / 2,

				tamaño,
				tamaño);

			using (SolidBrush brush =
				new SolidBrush(color))
			{
				e.Graphics.FillEllipse(
					brush,
					circulo);
			}

			using (Pen pen =
				new Pen(Color.Gray, 1))
			{
				e.Graphics.DrawEllipse(
					pen,
					circulo);
			}

			// ==========================
			// TEXTO
			// ==========================

			using (StringFormat sf =
				new StringFormat())
			{
				sf.Alignment =
					StringAlignment.Center;

				sf.LineAlignment =
					StringAlignment.Center;

				Color colorTexto =
					estado == "E" ||
					estado == "S"
						? Color.Black
						: Color.White;

				float tamañoFuente =
					estado == "E/S"
						? 6f
						: 8f;

				using (Font fuente =
					new Font(
						"Segoe UI",
						tamañoFuente,
						FontStyle.Bold))
				{
					using (SolidBrush brushTexto =
						new SolidBrush(colorTexto))
					{
						e.Graphics.DrawString(
							estado,
							fuente,
							brushTexto,
							circulo,
							sf);
					}
				}
			}

			e.Handled = true;
		}
		public void ConfigurarGridChecador()
		{
			DataGridView dgv = _frmA.dgvChecador;

			// ============================
			// CONFIGURACIÓN GENERAL
			// ============================

			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToResizeRows = false;

			dgv.ReadOnly = true;

			dgv.RowHeadersVisible = false;

			dgv.MultiSelect = false;

			// FILA COMPLETA
			dgv.SelectionMode =
				DataGridViewSelectionMode.FullRowSelect;

			dgv.EnableHeadersVisualStyles = false;

			dgv.BorderStyle =
				BorderStyle.None;

			dgv.CellBorderStyle =
				DataGridViewCellBorderStyle.Single;

			dgv.GridColor =
				Color.LightGray;


			// ============================
			// ENCABEZADO
			// ============================

			dgv.ColumnHeadersHeight = 42;

			dgv.ColumnHeadersDefaultCellStyle.BackColor =
				Color.FromArgb(22, 32, 45);

			dgv.ColumnHeadersDefaultCellStyle.ForeColor =
				Color.White;

			dgv.ColumnHeadersDefaultCellStyle.Font =
				new Font("Segoe UI", 9, FontStyle.Bold);

			dgv.ColumnHeadersDefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			// EVITA QUE EL ENCABEZADO CAMBIE
			// CUANDO SELECCIONAS UNA FILA

			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor =
				Color.FromArgb(22, 32, 45);

			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor =
				Color.White;


			// ============================
			// FILAS
			// ============================

			dgv.DefaultCellStyle.Font =
				new Font("Segoe UI", 9);

			dgv.DefaultCellStyle.BackColor =
				Color.FromArgb(248, 249, 251);

			dgv.DefaultCellStyle.ForeColor =
				Color.FromArgb(40, 40, 40);

			// MISMO COLOR DE SELECCIÓN
			dgv.DefaultCellStyle.SelectionBackColor =
				Color.FromArgb(190, 205, 222);

			dgv.DefaultCellStyle.SelectionForeColor =
				Color.Black;

			dgv.AlternatingRowsDefaultCellStyle.BackColor =
				Color.FromArgb(238, 241, 245);

			dgv.RowTemplate.Height = 28;


			// ============================
			// COLUMNAS
			// ============================

			dgv.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.Fill;


			// ============================
			// CÓDIGO
			// ============================

			if (dgv.Columns.Contains("id_employee"))
			{
				dgv.Columns["id_employee"].HeaderText =
					"CÓDIGO";

				dgv.Columns["id_employee"].FillWeight = 100;

				dgv.Columns["id_employee"].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleLeft;

				// FORZAR ENCABEZADO
				dgv.Columns["id_employee"].HeaderCell.Style.BackColor =
					Color.FromArgb(22, 32, 45);

				dgv.Columns["id_employee"].HeaderCell.Style.ForeColor =
					Color.White;

				dgv.Columns["id_employee"].HeaderCell.Style.Font =
					new Font("Segoe UI", 9, FontStyle.Bold);
			}


			// ============================
			// DÍAS
			// ============================

			string[] dias =
			{
		"VIE",
		"SAB",
		"DOM",
		"LUN",
		"MAR",
		"MIÉ",
		"JUE"
	};

			foreach (string dia in dias)
			{
				if (!dgv.Columns.Contains(dia))
					continue;

				dgv.Columns[dia].HeaderText = dia;

				dgv.Columns[dia].FillWeight = 70;

				dgv.Columns[dia].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleCenter;

				// FORZAR ENCABEZADO
				dgv.Columns[dia].HeaderCell.Style.BackColor =
					Color.FromArgb(22, 32, 45);

				dgv.Columns[dia].HeaderCell.Style.ForeColor =
					Color.White;

				dgv.Columns[dia].HeaderCell.Style.Font =
					new Font("Segoe UI", 9, FontStyle.Bold);
			}


			// ============================
			// QUITAR SELECCIÓN INICIAL
			// ============================

			dgv.ClearSelection();
			dgv.CurrentCell = null;
		}
	}
}
