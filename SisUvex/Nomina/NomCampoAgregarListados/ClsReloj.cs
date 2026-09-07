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

			dt = OrdenarChecadorIgualAsistencia(dt);

			_frmA.dgvChecador.DataSource = dt;

			ConfigurarGridChecador();

			_frmA.dgvChecador.ClearSelection();
			_frmA.dgvChecador.CurrentCell = null;

			_frmA.dgvChecador.Invalidate();
		}
		public void MarcarPorEstado(string estado)
		{
			estado = estado.Trim().ToUpper();

			DialogResult resultado = MessageBox.Show(
				"¿Está seguro de que desea agregar la asistencia?",
				"Confirmar asistencia",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			if (resultado != DialogResult.Yes)
				return;

			DataTable dt =
				_frmA.dgvAsistencia.DataSource as DataTable;

			if (dt == null)
				return;

			string[] dias =
			{
		"Vie",
		"Sab",
		"Dom",
		"Lun",
		"Mar",
		"Mie",
		"Jue"
	};

			foreach (DataGridViewRow filaReloj in _frmA.dgvChecador.Rows)
			{
				if (filaReloj.IsNewRow)
					continue;

				// Código del empleado
				string codigo =
					filaReloj.Cells["id_employee"].Value?
					.ToString()
					.Trim();

				if (string.IsNullOrWhiteSpace(codigo))
					continue;

				// Buscar empleado respetando ceros a la izquierda
				DataRow[] empleados = dt.Select(
					$"Codigo = '{codigo.Replace("'", "''")}'");

				if (empleados.Length == 0)
					continue;

				DataRow empleado = empleados[0];

				// Revisar los 7 días
				for (int dia = 0; dia < 7; dia++)
				{
					string columnaReloj =
						new string[]
						{
					"VIE",
					"SAB",
					"DOM",
					"LUN",
					"MAR",
					"MIÉ",
					"JUE"
						}[dia];

					if (!_frmA.dgvChecador.Columns.Contains(columnaReloj))
						continue;

					string valor =
						filaReloj.Cells[columnaReloj].Value?
						.ToString()
						.Trim()
						.ToUpper();

					if (valor == estado)
					{
						empleado[dias[dia]] = true;
					}
				}
			}

			_frmA.dgvAsistencia.Refresh();
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

			// ==========================================
			// CONFIGURACIÓN GENERAL
			// ==========================================

			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToResizeRows = false;

			dgv.ReadOnly = true;
			dgv.RowHeadersVisible = false;
			dgv.MultiSelect = false;

			dgv.SelectionMode =
				DataGridViewSelectionMode.FullRowSelect;

			dgv.EnableHeadersVisualStyles = false;

			dgv.BorderStyle = BorderStyle.None;

			dgv.CellBorderStyle =
				DataGridViewCellBorderStyle.Single;

			dgv.GridColor = Color.LightGray;

			dgv.ColumnHeadersHeight = 42;

			dgv.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.Fill;

			// ==========================================
			// ENCABEZADOS
			// ==========================================

			dgv.ColumnHeadersDefaultCellStyle.BackColor =
				Color.FromArgb(22, 32, 45);

			dgv.ColumnHeadersDefaultCellStyle.ForeColor =
				Color.White;

			dgv.ColumnHeadersDefaultCellStyle.Font =
				new Font("Segoe UI", 9, FontStyle.Bold);

			dgv.ColumnHeadersDefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			// IMPORTANTE:
			// CUANDO SE HAGA CLIC EN EL ENCABEZADO
			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor =
				Color.FromArgb(22, 32, 45);

			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor =
				Color.White;

			// ==========================================
			// CELDAS
			// ==========================================

			dgv.DefaultCellStyle.Font =
				new Font("Segoe UI", 9);

			dgv.DefaultCellStyle.BackColor =
				Color.FromArgb(248, 249, 251);

			dgv.DefaultCellStyle.ForeColor =
				Color.FromArgb(40, 40, 40);

			dgv.DefaultCellStyle.SelectionBackColor =
				Color.FromArgb(190, 205, 222);

			dgv.DefaultCellStyle.SelectionForeColor =
				Color.Black;

			// ==========================================
			// FILAS ALTERNADAS
			// ==========================================

			dgv.AlternatingRowsDefaultCellStyle.BackColor =
				Color.FromArgb(238, 241, 245);

			dgv.RowTemplate.Height = 28;

			// ==========================================
			// CÓDIGO
			// ==========================================

			if (dgv.Columns.Contains("id_employee"))
			{
				dgv.Columns["id_employee"].HeaderText =
					"CÓDIGO";

				dgv.Columns["id_employee"].FillWeight = 100;

				dgv.Columns["id_employee"]
					.DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleLeft;
			}

			// ==========================================
			// DÍAS
			// ==========================================

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

				dgv.Columns[dia]
					.DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleCenter;
			}

			// ==========================================
			// TODOS LOS ENCABEZADOS
			// MISMO COLOR NORMAL Y AL SELECCIONAR
			// ==========================================

			foreach (DataGridViewColumn columna in dgv.Columns)
			{
				columna.HeaderCell.Style.BackColor =
					Color.FromArgb(22, 32, 45);

				columna.HeaderCell.Style.ForeColor =
					Color.White;

				columna.HeaderCell.Style.SelectionBackColor =
					Color.FromArgb(22, 32, 45);

				columna.HeaderCell.Style.SelectionForeColor =
					Color.White;

				columna.HeaderCell.Style.Font =
					new Font(
						"Segoe UI",
						9,
						FontStyle.Bold);

				columna.HeaderCell.Style.Alignment =
					DataGridViewContentAlignment.MiddleCenter;

				// NO permitir ordenar al hacer clic
				columna.SortMode =
					DataGridViewColumnSortMode.NotSortable;
			}

			// ==========================================
			// FINAL
			// ==========================================

			dgv.ClearSelection();
			dgv.CurrentCell = null;
		}
		private DataTable OrdenarChecadorIgualAsistencia(DataTable dt)
		{
			if (dt == null)
				return dt;

			DataTable dtOrdenado = dt.Clone();

			// Recorrer dgvAsistencia en el orden actual
			foreach (DataGridViewRow fila in _frmA.dgvAsistencia.Rows)
			{
				if (fila.IsNewRow)
					continue;

				string codigo =
					fila.Cells["Codigo"].Value?.ToString()?.Trim();

				if (string.IsNullOrWhiteSpace(codigo))
					continue;


				// Buscar el código en la PRIMERA columna
				// del DataTable de checador
				foreach (DataRow row in dt.Rows)
				{
					string codigoChecador =
						row[0]?.ToString()?.Trim();

					if (codigoChecador == codigo)
					{
						dtOrdenado.ImportRow(row);
						break;
					}
				}
			}

			return dtOrdenado;
		}
		public void CargarRegistrosEmpleado(string codigo, string nombre)
		{
			if (string.IsNullOrWhiteSpace(codigo))
				return;

			// Mostrar empleado seleccionado
			_frmA.txbRegistro.Text = $"{codigo} - {nombre}";

			// Obtener semana seleccionada
			if (_frmA.cboSemana.SelectedIndex == -1)
				return;

			DataRowView semana = (DataRowView)_frmA.cboSemana.SelectedItem;

			DateTime fechaInicio =
				Convert.ToDateTime(semana["d_startDate_per"]).Date;

			DateTime fechaFin =
				Convert.ToDateTime(semana["d_endDate_per"]).Date;

			DataTable dtChecadas = new DataTable();

			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				string query = @"
				WITH Checadas AS
				(
					SELECT
						d_date,
						d_time,
						c_deviceName,
						ROW_NUMBER() OVER (
							PARTITION BY d_date
							ORDER BY d_time ASC
						) AS Primera,
						ROW_NUMBER() OVER (
							PARTITION BY d_date
							ORDER BY d_time DESC
						) AS Ultima
					FROM [SisUvex].[dbo].[Nom_HikvisionIVMS]
					WHERE TRY_CONVERT(int, id_employee) = TRY_CONVERT(int, @Codigo)
					  AND d_date >= @FechaInicio
					  AND d_date <= @FechaFin
				)
				SELECT
					d_date,
					d_time,
					c_deviceName
				FROM Checadas
				WHERE Primera = 1
				   OR Ultima = 1
				ORDER BY d_date, d_time";

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				{
					cmd.Parameters.AddWithValue("@Codigo", codigo);
					cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
					cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

					using (SqlDataAdapter da = new SqlDataAdapter(cmd))
					{
						da.Fill(dtChecadas);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al consultar las checadas:\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				sql.CloseConectionWrite();
			}

			// Llenar la tabla del reloj
			CrearTablaReloj(dtChecadas, fechaInicio, fechaFin);
		}
		private void CrearTablaReloj(DataTable dtChecadas, DateTime fechaInicio, DateTime fechaFin)
		{
			// Limpiar la tabla
			_frmA.dgvReloj.DataSource = null;
			_frmA.dgvReloj.Columns.Clear();
			_frmA.dgvReloj.Rows.Clear();

			// Crear las 7 columnas de los días
			string[] nombresDias =
			{
				"VIE",
				"SÁB",
				"DOM",
				"LUN",
				"MAR",
				"MIÉ",
				"JUE"
			};

			for (int i = 0; i < 7; i++)
			{
				DateTime fechaDia = fechaInicio.AddDays(i);

				DataGridViewTextBoxColumn columna =
					new DataGridViewTextBoxColumn();

				columna.Name = "Dia" + i;
				columna.HeaderText =
					$"{nombresDias[i]} {fechaDia:dd/MM/yyyy}";

				columna.AutoSizeMode =
					DataGridViewAutoSizeColumnMode.Fill;

				columna.DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleCenter;

				_frmA.dgvReloj.Columns.Add(columna);
			}

			// Guardar las checadas de cada día
			List<string>[] horasPorDia =
			{
				new List<string>(),
				new List<string>(),
				new List<string>(),
				new List<string>(),
				new List<string>(),
				new List<string>(),
				new List<string>()
			};

			// Obtener las horas
			foreach (DataRow row in dtChecadas.Rows)
			{
				DateTime fecha =
					Convert.ToDateTime(row["d_date"]).Date;

				TimeSpan hora =
					(TimeSpan)row["d_time"];

				int dia =
					(int)(fecha - fechaInicio).TotalDays;

				if (dia >= 0 && dia < 7)
				{
					horasPorDia[dia].Add(
						hora.ToString(@"hh\:mm\:ss"));
				}
			}

			// Cantidad máxima de checadas
			int maxHoras = horasPorDia.Max(x => x.Count);

			// Si no hay ninguna checada en toda la semana
			if (maxHoras == 0)
			{
				int fila = _frmA.dgvReloj.Rows.Add();

				for (int dia = 0; dia < 7; dia++)
				{
					_frmA.dgvReloj.Rows[fila].Cells[dia].Value =
						"SIN CHECADA";
				}
			}
			else
			{
				// Crear las filas necesarias
				for (int i = 0; i < maxHoras; i++)
				{
					int fila =
						_frmA.dgvReloj.Rows.Add();

					for (int dia = 0; dia < 7; dia++)
					{
						if (i < horasPorDia[dia].Count)
						{
							_frmA.dgvReloj.Rows[fila]
								.Cells[dia].Value =
								horasPorDia[dia][i];
						}
						else
						{
							// Si ese día no tiene esa checada
							_frmA.dgvReloj.Rows[fila]
								.Cells[dia].Value = "";
						}
					}
				}

				// Revisar qué días no tuvieron NINGUNA checada
				for (int dia = 0; dia < 7; dia++)
				{
					if (horasPorDia[dia].Count == 0)
					{
						_frmA.dgvReloj.Rows[0]
							.Cells[dia].Value = "SIN CHECADA";

						// Combinar visualmente las filas
						for (int fila = 1;
							 fila < _frmA.dgvReloj.Rows.Count;
							 fila++)
						{
							_frmA.dgvReloj.Rows[fila]
								.Cells[dia].Value = "";
						}
					}
				}
				// Aplicar estilo
				EstilizarDgvReloj();
			}

			// ESTILO
			_frmA.dgvReloj.EnableHeadersVisualStyles = false;

			_frmA.dgvReloj.ColumnHeadersDefaultCellStyle.Font =
				new Font("Segoe UI", 9, FontStyle.Bold);

			_frmA.dgvReloj.ColumnHeadersDefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			_frmA.dgvReloj.DefaultCellStyle.Font =
				new Font("Segoe UI", 9);

			_frmA.dgvReloj.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			_frmA.dgvReloj.RowHeadersVisible = false;

			_frmA.dgvReloj.AllowUserToAddRows = false;

			_frmA.dgvReloj.AutoSizeRowsMode =
				DataGridViewAutoSizeRowsMode.None;

			_frmA.dgvReloj.RowTemplate.Height = 28;
		}
		public void DgvAsistencia_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
				return;

			DataGridViewRow fila =
				_frmA.dgvAsistencia.Rows[e.RowIndex];

			string codigo =
				fila.Cells["Codigo"].Value?.ToString()?.Trim();

			string nombre =
				fila.Cells["Empleado"].Value?.ToString()?.Trim();

			if (string.IsNullOrWhiteSpace(codigo))
				return;

			CargarRegistrosEmpleado(codigo, nombre);
		}
		public void EstilizarDgvReloj()
		{
			DataGridView dgv = _frmA.dgvReloj;

			// ==========================================
			// ESTILO GENERAL
			// ==========================================

			dgv.EnableHeadersVisualStyles = false;

			dgv.BorderStyle = BorderStyle.None;

			dgv.CellBorderStyle =
				DataGridViewCellBorderStyle.Single;

			dgv.GridColor = Color.LightGray;

			dgv.RowHeadersVisible = false;

			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToResizeRows = false;

			dgv.ReadOnly = true;

			// ==========================================
			// ENCABEZADOS
			// ==========================================

			dgv.ColumnHeadersDefaultCellStyle.BackColor =
				Color.FromArgb(25, 35, 50);

			dgv.ColumnHeadersDefaultCellStyle.ForeColor =
				Color.White;

			dgv.ColumnHeadersDefaultCellStyle.Font =
				new Font("Segoe UI", 9, FontStyle.Bold);

			dgv.ColumnHeadersDefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			// IMPORTANTE:
			// AL HACER CLIC EN EL ENCABEZADO
			// NO SE PONE BLANCO

			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor =
				Color.FromArgb(25, 35, 50);

			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor =
				Color.White;

			// ==========================================
			// CELDAS
			// ==========================================

			dgv.DefaultCellStyle.BackColor =
				Color.FromArgb(248, 249, 251);

			dgv.DefaultCellStyle.ForeColor =
				Color.FromArgb(40, 40, 40);

			dgv.DefaultCellStyle.SelectionBackColor =
				Color.FromArgb(190, 205, 222);

			dgv.DefaultCellStyle.SelectionForeColor =
				Color.Black;

			dgv.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.DefaultCellStyle.Font =
				new Font("Segoe UI", 9);

			// ==========================================
			// FILAS ALTERNADAS
			// ==========================================

			dgv.AlternatingRowsDefaultCellStyle.BackColor =
				Color.FromArgb(238, 241, 245);

			// ==========================================
			// ALTURAS
			// ==========================================

			dgv.ColumnHeadersHeight = 35;

			dgv.RowTemplate.Height = 28;

			// ==========================================
			// ANCHO DE COLUMNAS
			// ==========================================

			dgv.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.Fill;

			foreach (DataGridViewColumn columna in dgv.Columns)
			{
				columna.AutoSizeMode =
					DataGridViewAutoSizeColumnMode.Fill;

				columna.FillWeight = 100;

				// ==========================================
				// FORZAR COLOR DEL ENCABEZADO
				// ==========================================

				columna.HeaderCell.Style.BackColor =
					Color.FromArgb(25, 35, 50);

				columna.HeaderCell.Style.ForeColor =
					Color.White;

				columna.HeaderCell.Style.SelectionBackColor =
					Color.FromArgb(25, 35, 50);

				columna.HeaderCell.Style.SelectionForeColor =
					Color.White;

				columna.HeaderCell.Style.Font =
					new Font(
						"Segoe UI",
						9,
						FontStyle.Bold);

				columna.HeaderCell.Style.Alignment =
					DataGridViewContentAlignment.MiddleCenter;
			}

			// ==========================================
			// QUITAR SELECCIÓN
			// ==========================================

			dgv.ClearSelection();
			dgv.CurrentCell = null;
		}
	}
}