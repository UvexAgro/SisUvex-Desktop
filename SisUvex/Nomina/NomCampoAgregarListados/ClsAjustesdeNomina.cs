using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Nomina.Conceptos_Ingresos_Diversos;

namespace SisUvex.Nomina.NomCampoAgregarListados
{
	public class ClsAjustesdeNomina
	{
		public FrmAsistencia _frmA;
		private SQLControl sql = new SQLControl();

		public DataTable CargarConceptos()
		{
			DataTable dt = new DataTable();

			try
			{
				sql.OpenConectionWrite();

				string query = @"
                SELECT
                    id_concept,
                    v_concept,
                    n_amount
                FROM Nom_concept
                ORDER BY id_concept";

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				{
					cmd.CommandType = CommandType.Text;

					using (SqlDataAdapter da = new SqlDataAdapter(cmd))
					{
						da.Fill(dt);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al cargar los conceptos:\n" + ex.Message,
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

		public void CargarConceptosCombo()
		{
			DataTable dt = CargarConceptos();

			_frmA.cboConceptos.DataSource = dt;
			_frmA.cboConceptos.DisplayMember = "v_concept";
			_frmA.cboConceptos.ValueMember = "id_concept";
			_frmA.cboConceptos.SelectedIndex = -1;
		}
		public void AgregarBotonesConfirmar(DateTime fechaInicio)
		{
			// ==========================================
			// ELIMINAR FILAS ANTERIORES
			// ==========================================

			for (int i = _frmA.dgvReloj.Rows.Count - 1; i >= 0; i--)
			{
				string tag = _frmA.dgvReloj.Rows[i].Tag?.ToString();

				if (tag == "MONTO" || tag == "BOTONES")
				{
					_frmA.dgvReloj.Rows.RemoveAt(i);
				}
			}

			// ==========================================
			// GUARDAR FECHA DE CADA COLUMNA
			// ==========================================

			for (int i = 0; i < 7; i++)
			{
				if (i < _frmA.dgvReloj.Columns.Count)
				{
					_frmA.dgvReloj.Columns[i].Tag =
						fechaInicio.AddDays(i).Date;
				}
			}

			// ==========================================
			// FILA DE BOTONES
			// ==========================================

			int filaBotones =
				_frmA.dgvReloj.Rows.Add();

			DataGridViewRow fila =
				_frmA.dgvReloj.Rows[filaBotones];

			fila.Tag = "BOTONES";

			for (int i = 0; i < 7; i++)
			{
				if (i < _frmA.dgvReloj.Columns.Count)
				{
					DataGridViewButtonCell boton =
						new DataGridViewButtonCell();

					boton.Value = "Confirmar";

					fila.Cells[i] = boton;
				}
			}

			// ==========================================
			// CARGAR MONTOS EXISTENTES
			// ==========================================

			CargarMontosSemana();
		}
		public void CargarMontosSemana()
		{
			string idAttendance =
				_frmA.IdWorkGroupEmployeeDailyActual;

			if (string.IsNullOrWhiteSpace(idAttendance))
				return;

			// ==========================================
			// ELIMINAR FILA DE MONTOS ANTERIOR
			// ==========================================

			for (int i = _frmA.dgvReloj.Rows.Count - 1; i >= 0; i--)
			{
				if (_frmA.dgvReloj.Rows[i].Tag?.ToString() == "MONTO")
				{
					_frmA.dgvReloj.Rows.RemoveAt(i);
				}
			}

			// ==========================================
			// OBTENER FECHAS DE LAS COLUMNAS
			// ==========================================

			DateTime? fechaInicio = null;
			DateTime? fechaFin = null;

			for (int i = 0; i < 7; i++)
			{
				if (i < _frmA.dgvReloj.Columns.Count &&
					_frmA.dgvReloj.Columns[i].Tag != null)
				{
					DateTime fecha =
						Convert.ToDateTime(
							_frmA.dgvReloj.Columns[i].Tag).Date;

					if (fechaInicio == null)
						fechaInicio = fecha;

					fechaFin = fecha;
				}
			}

			if (fechaInicio == null || fechaFin == null)
				return;

			// ==========================================
			// CONSULTAR INGRESOS
			// ==========================================

			DataTable dt = new DataTable();

			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				string query = @"
            SELECT
                d_date,
                n_amount
            FROM Nom_MiscellaneousIncome
            WHERE id_workGroupEmployeeDaily =
                  @idAttendance
              AND d_date >= @fechaInicio
              AND d_date <= @fechaFin
              AND id_concept IS NOT NULL
              AND n_amount IS NOT NULL
            ORDER BY d_date;
        ";

				using (SqlCommand cmd =
					new SqlCommand(query, sql.cnn))
				{
					cmd.Parameters.AddWithValue(
						"@idAttendance",
						idAttendance);

					cmd.Parameters.AddWithValue(
						"@fechaInicio",
						fechaInicio.Value);

					cmd.Parameters.AddWithValue(
						"@fechaFin",
						fechaFin.Value);

					using (SqlDataAdapter da =
						new SqlDataAdapter(cmd))
					{
						da.Fill(dt);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al cargar los montos:\n" +
					ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return;
			}
			finally
			{
				sql.CloseConectionWrite();
			}

			// ==========================================
			// CREAR FILA DE MONTOS
			// ==========================================

			int posicionBotones = -1;

			for (int i = 0;
				 i < _frmA.dgvReloj.Rows.Count;
				 i++)
			{
				if (_frmA.dgvReloj.Rows[i]
					.Tag?.ToString() == "BOTONES")
				{
					posicionBotones = i;
					break;
				}
			}

			if (posicionBotones == -1)
				return;

			_frmA.dgvReloj.Rows.Insert(
				posicionBotones,
				1);

			DataGridViewRow filaMonto =
				_frmA.dgvReloj.Rows[posicionBotones];

			filaMonto.Tag = "MONTO";

			// ==========================================
			// COLOCAR MONTOS EN SU DÍA
			// ==========================================

			for (int i = 0; i < 7; i++)
			{
				if (i >= _frmA.dgvReloj.Columns.Count)
					continue;

				object valorFecha =
					_frmA.dgvReloj.Columns[i].Tag;

				if (valorFecha == null)
				{
					filaMonto.Cells[i].Value = "";
					continue;
				}

				DateTime fechaColumna =
					Convert.ToDateTime(valorFecha).Date;

				DataRow[] encontrados =
					dt.Select(
						$"d_date = #{fechaColumna:MM/dd/yyyy}#");

				if (encontrados.Length > 0)
				{
					decimal monto =
						Convert.ToDecimal(
							encontrados[0]["n_amount"]);

					filaMonto.Cells[i].Value =
						monto.ToString("$#,##0.00");
				}
				else
				{
					// NO HAY REGISTRO
					filaMonto.Cells[i].Value = "";
				}
			}
		}
		public void GuardarIngresoCampo(string idWorkGroupEmployeeDaily,DateTime fecha)
		{
			object val =
	   _frmA.cboConceptos.SelectedValue;

			if (val == null || val is DataRowView)
			{
				MessageBox.Show(
					"Seleccione un concepto.",
					"Aviso",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			string idConcepto =
				val.ToString();

			if (!decimal.TryParse(
				_frmA.txbMonto.Text,
				out decimal monto))
			{
				MessageBox.Show(
					"El monto no es válido.",
					"Aviso",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			string query = $@"
        EXEC sp_Nom_MiscellaneousIncome_Campo
            '{idWorkGroupEmployeeDaily}',
            '{idConcepto}',
            {monto.ToString(
						System.Globalization.CultureInfo.InvariantCulture)},
            'SYSTEM',
            '{fecha:yyyy-MM-dd}'";

			try
			{
				// Guardar o actualizar en la base de datos
				ClsQuerysDB.ExecuteQuery(query);

				// Actualizar el monto mostrado en el día correspondiente
				ActualizarMontoDia(fecha, monto);

				MessageBox.Show(
					"Ingreso guardado correctamente.",
					"Correcto",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al guardar el ingreso:\n" +
					ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}
		private void ActualizarMontoDia(DateTime fecha,decimal monto)
		{
			// Buscar la columna correspondiente a la fecha
			for (int i = 0;
				 i < _frmA.dgvReloj.Columns.Count;
				 i++)
			{
				if (_frmA.dgvReloj.Columns[i].Tag == null)
					continue;

				DateTime fechaColumna =
					Convert.ToDateTime(
						_frmA.dgvReloj.Columns[i].Tag).Date;

				if (fechaColumna != fecha.Date)
					continue;

				// Buscar la fila MONTO
				for (int j = 0;
					 j < _frmA.dgvReloj.Rows.Count;
					 j++)
				{
					if (_frmA.dgvReloj.Rows[j]
						.Tag?.ToString() == "MONTO")
					{
						_frmA.dgvReloj.Rows[j]
							.Cells[i]
							.Value =
							monto.ToString("$#,##0.00");

						_frmA.dgvReloj.InvalidateCell(i, j);

						return;
					}
				}
			}
		}
		public void ConfirmarIngresoDia(int columnIndex)
		{
			if (columnIndex < 0 ||
				columnIndex >= _frmA.dgvReloj.Columns.Count)
			{
				return;
			}

			object valorFecha =
				_frmA.dgvReloj.Columns[columnIndex].Tag;

			if (valorFecha == null)
			{
				MessageBox.Show(
					"No se pudo determinar la fecha del día.",
					"Aviso",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			DateTime fecha =
				Convert.ToDateTime(valorFecha).Date;

			string idWorkGroupEmployeeDaily =
				_frmA.IdWorkGroupEmployeeDailyActual;

			if (string.IsNullOrWhiteSpace(
				idWorkGroupEmployeeDaily))
			{
				MessageBox.Show(
					"No se encontró el registro del empleado.",
					"Aviso",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			GuardarIngresoCampo(
				idWorkGroupEmployeeDaily,
				fecha);
		}
		public void FiltrarDiaChecador(string dia)
		{
			string[] dias =
			{
		"VIE",
		"SAB",
		"DOM",
		"LUN",
		"MAR",
		"MIE",
		"JUE"
	};

			// La columna 0 es CÓDIGO
			for (int i = 0; i < 7; i++)
			{
				int indiceColumna = i + 1;

				if (indiceColumna >= _frmA.dgvChecador.Columns.Count)
					continue;

				if (dia == "TODOS")
				{
					_frmA.dgvChecador.Columns[indiceColumna].Visible = true;
				}
				else
				{
					_frmA.dgvChecador.Columns[indiceColumna].Visible =
						dias[i] == dia;
				}
			}

			_frmA.dgvChecador.ClearSelection();
			_frmA.dgvChecador.CurrentCell = null;


		}
	}
}

