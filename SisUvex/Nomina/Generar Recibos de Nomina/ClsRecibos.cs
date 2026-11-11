using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.Formula.Functions;

namespace SisUvex.Nomina.Generar_Recibos_de_Nomina
{
	public class ClsRecibos
	{
		private bool cargando = false;
		private DataTable dtLugaresPago;
		private DataView dvLugaresPago;
		private bool filtrandoLugarPago = false;
		public FrmRecibos frm;
		public void CargarSemanas()
		{
			SQLControl sql = new SQLControl();

			string query = @"
			SELECT
				c_sequence_per,
				d_startDate_per,
				d_endDate_per
			FROM dbo.Payroll_AttendancePeriod
			WHERE c_active = '1'
			ORDER BY d_startDate_per DESC";

			DataTable dt = new DataTable();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				using (SqlDataAdapter da = new SqlDataAdapter(cmd))
				{
					da.Fill(dt);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al cargar las semanas:\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				sql.CloseConectionWrite();
			}

			// El ComboBox SOLO mostrará c_sequence_per
			frm.cboSemana.DataSource = null;

			frm.cboSemana.DisplayMember = "c_sequence_per";
			frm.cboSemana.ValueMember = "c_sequence_per";

			frm.cboSemana.DataSource = dt;
			// AQUÍ SE HACE LA REFERENCIA
			frm.cboSemana.SelectedIndexChanged += (s, e) =>
			{
				CargarFechasSemana();
			};

			// Seleccionar la semana actual
			SeleccionarSemanaActual(dt);
		}
		private void SeleccionarSemanaActual(DataTable dt)
		{
			DateTime fechaActual = DateTime.Today;

			foreach (DataRow row in dt.Rows)
			{
				DateTime fechaInicio =
					Convert.ToDateTime(row["d_startDate_per"]).Date;

				DateTime fechaFin =
					Convert.ToDateTime(row["d_endDate_per"]).Date;

				if (fechaActual >= fechaInicio &&
					fechaActual <= fechaFin)
				{
					frm.cboSemana.SelectedValue =
						row["c_sequence_per"].ToString().Trim();

					return;
				}
			}

			frm.cboSemana.SelectedIndex = -1;
		}
		private void CargarFechasSemana()
		{
			if (frm.cboSemana.SelectedIndex < 0)
				return;

			if (frm.cboSemana.SelectedItem == null)
				return;

			DataRowView fila =
				frm.cboSemana.SelectedItem as DataRowView;

			if (fila == null)
				return;

			frm.dtpFechaInicial.Value =
				Convert.ToDateTime(fila["d_startDate_per"]).Date;

			frm.dtpFechaFinal.Value =
				Convert.ToDateTime(fila["d_endDate_per"]).Date;
		}
		public void CargarLugarPago(ComboBox combo)
		{
			cargando = true;

			dtLugaresPago = CboLugarPago();

			DataRow dr = dtLugaresPago.NewRow();
			dr["Código"] = "";
			dr["Nombre"] = "------ selecciona ------";

			dtLugaresPago.Rows.InsertAt(dr, 0);

			dvLugaresPago = new DataView(dtLugaresPago);

			combo.DataSource = dvLugaresPago;
			combo.DisplayMember = "Nombre";
			combo.ValueMember = "Código";

			combo.DropDownStyle = ComboBoxStyle.DropDown;
			combo.AutoCompleteMode = AutoCompleteMode.None;

			combo.SelectedIndex = 0;

			// Registrar evento de búsqueda
			combo.TextUpdate -= comboLugarPago_TextUpdate;
			combo.TextUpdate += comboLugarPago_TextUpdate;

			cargando = false;
		}
		public DataTable CboLugarPago()
		{
			SQLControl sql = new SQLControl();
			DataTable dt = new DataTable();

			sql.OpenConectionWrite();

			string query = @"
        SELECT 
            p.id_placePayment AS Código,
            p.id_placePayment + ' - ' + p.v_namePlace AS Nombre
        FROM Nom_PlacePayment p
        WHERE p.c_activePlace = 1
        ORDER BY p.id_placePayment";

			SqlCommand cmd = new SqlCommand(query, sql.cnn);

			SqlDataAdapter da = new SqlDataAdapter(cmd);
			da.Fill(dt);

			sql.CloseConectionWrite();

			return dt;
		}
		private void comboLugarPago_TextUpdate(object sender, EventArgs e)
		{
			if (cargando || filtrandoLugarPago)
				return;

			ComboBox combo = sender as ComboBox;

			string texto = combo.Text.Trim();

			filtrandoLugarPago = true;

			try
			{
				if (string.IsNullOrWhiteSpace(texto))
				{
					dvLugaresPago.RowFilter = "";
				}
				else
				{
					string buscar = texto.Replace("'", "''");

					dvLugaresPago.RowFilter =
						$"CONVERT([Código], 'System.String') LIKE '%{buscar}%' " +
						$"OR [Nombre] LIKE '%{buscar}%'";
				}

				combo.SelectedIndex = -1;
				combo.Text = texto;
				combo.SelectionStart = texto.Length;
				combo.SelectionLength = 0;

				combo.DroppedDown = true;
				Cursor.Current = Cursors.Default;
			}
			finally
			{
				filtrandoLugarPago = false;
			}
		}
		public void BuscarEmpleadoPorCodigo()
		{
			string codigo = frm.txbCodigo.Text.Trim();

			if (string.IsNullOrWhiteSpace(codigo))
			{
				frm.txbNombre.Clear();
				return;
			}

			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				string query = @"
						   SELECT
					LTRIM(RTRIM(
						CONCAT(
							v_lastNamePat, ' ',
							v_lastNameMat, ' ',
							v_name
						)
					)) AS NombreCompleto
				FROM dbo.Nom_Employees
				WHERE id_employee = @codigo; ";

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				{
					cmd.Parameters.AddWithValue("@codigo", codigo);

					object resultado = cmd.ExecuteScalar();

					if (resultado != null && resultado != DBNull.Value)
					{
						frm.txbNombre.Text = resultado.ToString();
					}
					else
					{
						frm.txbNombre.Clear();

						MessageBox.Show(
							"No se encontró el empleado.",
							"Consulta de empleado",
							MessageBoxButtons.OK,
							MessageBoxIcon.Information);

						frm.txbCodigo.Focus();
						frm.txbCodigo.SelectAll();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al buscar empleado: " + ex.Message);
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		private string ObtenerCodigoLugarPago()
		{
			if (frm.cboLugarPago.SelectedIndex <= 0 ||
				frm.cboLugarPago.SelectedValue == null)
			{
				return "";
			}

			return frm.cboLugarPago.SelectedValue.ToString().Trim();
		}

		// ==========================================
		// CONSULTAR EMPLEADOS POR LUGAR DE PAGO
		// ==========================================
		public DataTable ObtenerRecibos()
		{
			SQLControl sql = new SQLControl();
			DataTable dt = new DataTable();

			if (frm.cboSemana.SelectedIndex < 0)
			{
				MessageBox.Show("Selecciona una semana.");
				return dt;
			}

			DataRowView semana = frm.cboSemana.SelectedItem as DataRowView;

			if (semana == null)
				return dt;

			string numeroSemana =
				semana["c_sequence_per"].ToString().Trim();

			DateTime fechaInicial =
				Convert.ToDateTime(semana["d_startDate_per"]).Date;

			DateTime fechaFinal =
				Convert.ToDateTime(semana["d_endDate_per"]).Date;

			string lugarPago = ObtenerCodigoLugarPago();
			string codigoEmpleado = frm.txbCodigo.Text.Trim();

			string orden = frm.cboOrdenar.SelectedIndex == 1
				? "Codigo"
				: "NombreCompleto";

			string direccion = frm.cboDireccion.SelectedIndex == 1
				? "DESC"
				: "ASC";

			if (!frm.rbCfdi.Checked && !frm.rbNormal.Checked)
			{
				MessageBox.Show("Selecciona el tipo de recibo.");
				return dt;
			}

			try
			{
				sql.OpenConectionWrite();

				string columnas;
				string query;

				// =========================================
				// RECIBO CON IMPUESTOS (CFDI)
				// =========================================
				if (frm.rbCfdi.Checked)
				{
					columnas = @"
				R.c_codigo_emp AS Codigo,
				R.v_nomtrabajador_emp AS NombreCompleto,
				R.c_codigo_lug AS CodigoLugarPago,
				P.v_namePlace AS LugarPago,
				RP.v_descripcion_reg AS RegistroPatronal,
				R.c_numimss_emp AS NumeroIMSS,
				R.n_diastrabajados_rec AS DiasTrabajados,

				-- PERCEPCIONES
				(
					ISNULL(R.n_totalpercepcalc_rec, 0)
					- ISNULL(R.n_septimodia_rec, 0)
					- ISNULL(R.n_aguinaldo_rec, 0)
					- ISNULL(R.n_vacacion_rec, 0)
					- ISNULL(R.n_primavac_rec, 0)
					- ISNULL(R.n_primadomi_rec, 0)
					- ISNULL(R.n_primadomig_rec, 0)
					- ISNULL(R.n_productividad_rec, 0)
					- ISNULL(R.n_asistencia_rec, 0)
					- ISNULL(R.n_otraspercep_rec, 0)
				) AS SueldoOrdinario,

				R.n_septimodia_rec AS SeptimoDia,
				R.n_aguinaldo_rec AS ProporcionalAguinaldo,
				R.n_vacacion_rec AS ProporcionalVacaciones,
				R.n_primavac_rec AS PrimaVacacional,
				R.n_primadomi_rec AS Domingo,
				R.n_primadomig_rec AS PrimaDominical,
				R.n_productividad_rec AS Productividad,
				R.n_asistencia_rec AS Asistencia,
				R.n_otraspercep_rec AS Bonos,

				R.n_isptcal_rec AS ISPT,
				R.n_otrosdcalc_rec AS OtrasDeducciones,

				R.n_totalpercepcalc_rec AS TotalPercepciones,

				(
					ISNULL(R.n_isptcal_rec, 0)
					+ ISNULL(R.n_otrosdcalc_rec, 0)
				) AS TotalDeducciones,

				R.n_importeneto_rec AS ImporteNeto,

				R.v_uuid_rec AS UUID,
				R.d_fechatimbre_rec AS FechaTimbrado,
				R.n_importecfdi_rec AS ImporteCFDI";

					query = @"
                SELECT
                    @Semana AS Semana,
                    " + columnas + @"
                FROM AgroSmart_SanAndres.dbo.nomrecibo R

                LEFT JOIN dbo.Nom_PlacePayment P
                    ON P.id_placePayment = R.c_codigo_lug

                LEFT JOIN AgroSmart_SanAndres.dbo.nomlugarp LP
                    ON LP.c_codigo_lug = R.c_codigo_lug

                LEFT JOIN AgroSmart_SanAndres.dbo.nomregistrop RP
                    ON RP.c_codigo_reg = LP.c_codigo_reg

                WHERE
                    R.d_ultdia_rec >= @FechaInicial
                    AND R.d_ultdia_rec < DATEADD(DAY, 1, @FechaFinal)

                    AND (@LugarPago = ''
                        OR LTRIM(RTRIM(R.c_codigo_lug)) = @LugarPago)

                    AND (@CodigoEmpleado = ''
                        OR LTRIM(RTRIM(R.c_codigo_emp)) = @CodigoEmpleado)

                UNION ALL

                SELECT
                    R.c_secuencia_per AS Semana,
                    " + columnas + @"
                FROM AgroSmart_SanAndres.dbo.nomrecibo_hist R

                LEFT JOIN dbo.Nom_PlacePayment P
                    ON P.id_placePayment = R.c_codigo_lug

                LEFT JOIN AgroSmart_SanAndres.dbo.nomlugarp LP
                    ON LP.c_codigo_lug = R.c_codigo_lug

                LEFT JOIN AgroSmart_SanAndres.dbo.nomregistrop RP
                    ON RP.c_codigo_reg = LP.c_codigo_reg

                WHERE
                    LTRIM(RTRIM(R.c_secuencia_per)) = @Semana

                    AND (@LugarPago = ''
                        OR LTRIM(RTRIM(R.c_codigo_lug)) = @LugarPago)

                    AND (@CodigoEmpleado = ''
                        OR LTRIM(RTRIM(R.c_codigo_emp)) = @CodigoEmpleado)

                ORDER BY " + orden + " " + direccion + ";";
				}

				// =========================================
				// RECIBO NORMAL
				// =========================================
				else
				{
					columnas = @"
                R.c_codigo_emp AS Codigo,
                R.v_nomtrabajador_emp AS NombreCompleto,
                R.c_codigo_lug AS CodigoLugarPago,
                P.v_namePlace AS LugarPago,
                RP.v_descripcion_reg AS RegistroPatronal,
                R.c_numimss_emp AS NumeroIMSS,

                R.n_lun_rec AS Lunes,
                R.n_mar_rec AS Martes,
                R.n_mie_rec AS Miercoles,
                R.n_jue_rec AS Jueves,
                R.n_vie_rec AS Viernes,
                R.n_sab_rec AS Sabado,
                R.n_dom_rec AS Domingo,

                R.n_totalpercep_rec AS TotalPercepciones,
                R.n_totaldeduc_rec AS TotalDeducciones,
                R.n_importeneto_rec AS ImporteNeto";

					query = @"
                SELECT
                    @Semana AS Semana,
                    " + columnas + @"
                FROM AgroSmart_SanAndres.dbo.nomrecibo R

                LEFT JOIN dbo.Nom_PlacePayment P
                    ON P.id_placePayment = R.c_codigo_lug

                LEFT JOIN AgroSmart_SanAndres.dbo.nomlugarp LP
                    ON LP.c_codigo_lug = R.c_codigo_lug

                LEFT JOIN AgroSmart_SanAndres.dbo.nomregistrop RP
                    ON RP.c_codigo_reg = LP.c_codigo_reg

                WHERE
                    R.d_ultdia_rec >= @FechaInicial
                    AND R.d_ultdia_rec < DATEADD(DAY, 1, @FechaFinal)

                    AND (@LugarPago = ''
                        OR LTRIM(RTRIM(R.c_codigo_lug)) = @LugarPago)

                    AND (@CodigoEmpleado = ''
                        OR LTRIM(RTRIM(R.c_codigo_emp)) = @CodigoEmpleado)

                UNION ALL

                SELECT
                    R.c_secuencia_per AS Semana,
                    " + columnas + @"
                FROM AgroSmart_SanAndres.dbo.nomrecibo_hist R

                LEFT JOIN dbo.Nom_PlacePayment P
                    ON P.id_placePayment = R.c_codigo_lug

                LEFT JOIN AgroSmart_SanAndres.dbo.nomlugarp LP
                    ON LP.c_codigo_lug = R.c_codigo_lug

                LEFT JOIN AgroSmart_SanAndres.dbo.nomregistrop RP
                    ON RP.c_codigo_reg = LP.c_codigo_reg

                WHERE
                    LTRIM(RTRIM(R.c_secuencia_per)) = @Semana

                    AND (@LugarPago = ''
                        OR LTRIM(RTRIM(R.c_codigo_lug)) = @LugarPago)

                    AND (@CodigoEmpleado = ''
                        OR LTRIM(RTRIM(R.c_codigo_emp)) = @CodigoEmpleado)

                ORDER BY " + orden + " " + direccion + ";";
				}

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				{
					cmd.Parameters.Add("@Semana", SqlDbType.VarChar, 20)
						.Value = numeroSemana;

					cmd.Parameters.Add("@FechaInicial", SqlDbType.Date)
						.Value = fechaInicial;

					cmd.Parameters.Add("@FechaFinal", SqlDbType.Date)
						.Value = fechaFinal;

					cmd.Parameters.Add("@LugarPago", SqlDbType.VarChar, 10)
						.Value = lugarPago;

					cmd.Parameters.Add("@CodigoEmpleado", SqlDbType.VarChar, 10)
						.Value = codigoEmpleado;

					using (SqlDataAdapter da = new SqlDataAdapter(cmd))
					{
						da.Fill(dt);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al consultar recibos:\n" + ex.Message,
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


		public void ConsultarRecibos()
		{
			DataTable dt = ObtenerRecibos();

			frm.dgvRecibo.DataSource = dt;

			frm.dgvRecibo.ReadOnly = true;
			frm.dgvRecibo.AllowUserToAddRows = false;
			frm.dgvRecibo.AllowUserToDeleteRows = false;
			frm.dgvRecibo.SelectionMode =
				DataGridViewSelectionMode.FullRowSelect;

			frm.dgvRecibo.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.Fill;

			frm.dgvRecibo.ClearSelection();

			if (dt.Rows.Count == 0)
			{
				MessageBox.Show(
					"No se encontraron recibos con los filtros seleccionados.",
					"Sin resultados",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
		}
	}
}