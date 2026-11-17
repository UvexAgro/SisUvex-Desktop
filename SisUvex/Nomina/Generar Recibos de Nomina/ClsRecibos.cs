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

		private CheckedListBox clbLugaresPago;
		private ToolStripControlHost hostLugares;
		private ToolStripDropDown menuLugares;
		private bool cargandoLugares = false;

		private List<string> codigosLugaresSeleccionados =
			new List<string>();
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

		//public void CargarLugarPago(ComboBox combo)
		//{
		//	cargando = true;

		//	dtLugaresPago = CboLugarPago();

		//	DataRow dr = dtLugaresPago.NewRow();
		//	dr["Código"] = "";
		//	dr["Nombre"] = "------ selecciona ------";

		//	dtLugaresPago.Rows.InsertAt(dr, 0);

		//	dvLugaresPago = new DataView(dtLugaresPago);

		//	combo.DataSource = dvLugaresPago;
		//	combo.DisplayMember = "Nombre";
		//	combo.ValueMember = "Código";

		//	combo.DropDownStyle = ComboBoxStyle.DropDown;
		//	combo.AutoCompleteMode = AutoCompleteMode.None;

		//	combo.SelectedIndex = 0;

		//	// Registrar evento de búsqueda
		//	combo.TextUpdate -= comboLugarPago_TextUpdate;
		//	combo.TextUpdate += comboLugarPago_TextUpdate;

		//	cargando = false;
		//}


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

			DataRowView semana =
				frm.cboSemana.SelectedItem as DataRowView;

			if (semana == null)
				return dt;

			string numeroSemana =
				semana["c_sequence_per"].ToString().Trim();

			string codigoEmpleado = frm.txbCodigo.Text.Trim();

			// =========================================
			// LUGARES DE PAGO SELECCIONADOS
			// =========================================

			List<string> lugaresSeleccionados =
				ObtenerCodigosLugaresPago();

			string filtroLugares = "";

			if (lugaresSeleccionados.Count > 0)
			{
				filtroLugares =
					" AND LTRIM(RTRIM(R.c_codigo_lug)) IN (" +
					string.Join(",",
						lugaresSeleccionados.Select(
							(x, i) => "@Lugar" + i)) +
					")";
			}

			// =========================================
			// ORDENAMIENTO
			// =========================================

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
				// RECIBO CFDI
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

                (
                    ISNULL(R.n_totalpercepcalc_rec, 0)
                    - ISNULL(R.n_septimodia_rec, 0)
                    - ISNULL(R.n_horasextras_rec, 0)
                    - ISNULL(R.n_primadomi_rec, 0)
                    - ISNULL(R.n_primadomig_rec, 0)
                    - ISNULL(R.n_productividad_rec, 0)
                ) AS SueldoOrdinario,

                R.n_septimodia_rec AS SeptimoDia,
                R.n_horasextras_rec AS HorasExtras,
                R.n_primadomi_rec AS Domingo,
                R.n_primadomig_rec AS PrimaDominical,
                R.n_productividad_rec AS Productividad,

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
				}

				// =========================================
				// CONSULTA ACTUAL E HISTÓRICA
				// =========================================

				query = @"

        -- =====================================
        -- RECIBOS DE LA TABLA ACTUAL
        -- =====================================

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
            NOT EXISTS
            (
                SELECT 1
                FROM AgroSmart_SanAndres.dbo.nomrecibo_hist H
                WHERE LTRIM(RTRIM(
                    CONVERT(VARCHAR(20), H.c_secuencia_per)
                )) = @Semana
            )

            " + filtroLugares + @"

            AND
            (
                @CodigoEmpleado = ''
                OR LTRIM(RTRIM(R.c_codigo_emp)) = @CodigoEmpleado
            )

        UNION ALL

        -- =====================================
        -- RECIBOS DE LA TABLA HISTÓRICA
        -- =====================================

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
            LTRIM(RTRIM(
                CONVERT(VARCHAR(20), R.c_secuencia_per)
            )) = @Semana

            " + filtroLugares + @"

            AND
            (
                @CodigoEmpleado = ''
                OR LTRIM(RTRIM(R.c_codigo_emp)) = @CodigoEmpleado
            )

			   ORDER BY
			LugarPago ASC,
			NombreCompleto ASC;";

				// =========================================
				// EJECUTAR CONSULTA
				// =========================================

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				{
					cmd.Parameters.Add(
						"@Semana", SqlDbType.VarChar, 20)
						.Value = numeroSemana;

					cmd.Parameters.Add(
						"@CodigoEmpleado", SqlDbType.VarChar, 10)
						.Value = codigoEmpleado;

					// Parámetros individuales para cada lugar
					for (int i = 0; i < lugaresSeleccionados.Count; i++)
					{
						cmd.Parameters.Add(
							"@Lugar" + i,
							SqlDbType.VarChar,
							10).Value = lugaresSeleccionados[i];
					}

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

			frm.dgvRecibo.DataSource = null;
			frm.dgvRecibo.DataSource = dt;

			// =====================================
			// CONFIGURACIÓN Y ESTILO
			// =====================================

			frm.dgvRecibo.ReadOnly = true;
			frm.dgvRecibo.AllowUserToAddRows = false;
			frm.dgvRecibo.AllowUserToDeleteRows = false;
			frm.dgvRecibo.AllowUserToResizeRows = false;

			frm.dgvRecibo.SelectionMode =
				DataGridViewSelectionMode.FullRowSelect;

			frm.dgvRecibo.MultiSelect = false;

			// No forzar todas las columnas al mismo espacio
			frm.dgvRecibo.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.None;

			// Aplicar diseño profesional
			AplicarEstiloDgvRecibos(frm.dgvRecibo);
			AgregarBotonQuitar();
			ActualizarResumen(dt);

			frm.dgvRecibo.ClearSelection();

			// =====================================
			// SIN RESULTADOS
			// =====================================

			if (dt.Rows.Count == 0)
			{
				MessageBox.Show(
					"No se encontraron recibos con los filtros seleccionados.",
					"Sin resultados",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
		}



		public DataTable ObtenerDesgloseDeducciones(
			string codigoEmpleado,
			string semana)
		{
			DataTable dt = new DataTable();
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				string query = @"
      
				;WITH Descuentos AS
				(
					SELECT
						c_codigo_emp,
						c_secuencia_per,
						c_codigo_ded,
						n_importe_dxs,
						n_saldo_dxs,
						c_consecutivop_din
					FROM AgroSmart_SanAndres.dbo.nomdeduccionsemana_hist

					UNION ALL

					SELECT
						c_codigo_emp,
						c_numsem_dxs AS c_secuencia_per,
						c_codigo_ded,
						n_importe_dxs,
						n_saldo_dxs,
						c_consecutivop_din
					FROM AgroSmart_SanAndres.dbo.nomdeduccionsemana
				)

				SELECT
					x.c_codigo_ded AS CodigoDescuento,
					d.v_descripcion_ded AS Concepto,

					CAST(
						ISNULL(x.n_importe_dxs, 0)
						AS DECIMAL(18,2)
					) AS Importe,

					CAST(
						ISNULL(x.n_saldo_dxs, 0)
						AS DECIMAL(18,2)
					) AS SaldoPendiente,

					x.c_consecutivop_din AS Consecutivo

				FROM Descuentos x

				INNER JOIN AgroSmart_SanAndres.dbo.nomdeduccion d
					ON d.c_codigo_ded = x.c_codigo_ded

				WHERE
					LTRIM(RTRIM(x.c_codigo_emp)) = @Empleado
					AND LTRIM(RTRIM(x.c_secuencia_per)) = @Semana
					AND ISNULL(x.n_importe_dxs, 0) > 0

				ORDER BY d.c_ordenrecibo_ded; ";


				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				{
					cmd.Parameters.Add("@Empleado",
						SqlDbType.VarChar, 20).Value =
						codigoEmpleado.Trim();

					cmd.Parameters.Add("@Semana",
						SqlDbType.VarChar, 20).Value =
						semana.Trim();

					using (SqlDataAdapter da = new SqlDataAdapter(cmd))
					{
						da.Fill(dt);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al obtener las deducciones:\n" + ex.Message,
					"Recibos",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				sql.CloseConectionWrite();
			}

			return dt;
		}

		public void AplicarEstiloDgvRecibos(DataGridView dgv)
		{
			dgv.SuspendLayout();

			// =====================================
			// CONFIGURACIÓN GENERAL
			// =====================================

			dgv.BorderStyle = BorderStyle.None;
			dgv.BackgroundColor = Color.White;
			dgv.GridColor = Color.FromArgb(225, 229, 233);

			dgv.RowHeadersVisible = false;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToResizeRows = false;
			dgv.MultiSelect = false;
			dgv.ReadOnly = true;

			dgv.SelectionMode =
				DataGridViewSelectionMode.FullRowSelect;

			dgv.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.None;

			dgv.AutoSizeRowsMode =
				DataGridViewAutoSizeRowsMode.None;

			// =====================================
			// ENCABEZADOS
			// =====================================

			dgv.EnableHeadersVisualStyles = false;

			dgv.ColumnHeadersDefaultCellStyle.BackColor =
				Color.FromArgb(220, 232, 245);

			dgv.ColumnHeadersDefaultCellStyle.ForeColor =
				Color.FromArgb(35, 65, 95);

			dgv.ColumnHeadersDefaultCellStyle.Font =
				new Font("Segoe UI", 9F, FontStyle.Bold);

			dgv.ColumnHeadersDefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor =
				Color.FromArgb(220, 232, 245);

			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor =
				Color.FromArgb(35, 65, 95);

			dgv.ColumnHeadersHeight = 40;

			// =====================================
			// FILAS
			// =====================================

			dgv.DefaultCellStyle.BackColor =
				Color.White;

			dgv.DefaultCellStyle.ForeColor =
				Color.FromArgb(45, 55, 65);

			dgv.DefaultCellStyle.Font =
				new Font("Segoe UI", 9F);

			dgv.DefaultCellStyle.SelectionBackColor =
				Color.FromArgb(211, 229, 247);

			dgv.DefaultCellStyle.SelectionForeColor =
				Color.FromArgb(35, 65, 95);

			dgv.AlternatingRowsDefaultCellStyle.BackColor =
				Color.FromArgb(243, 246, 250);

			dgv.GridColor =
				Color.FromArgb(225, 231, 238);

			// =====================================
			// BORDES Y SELECCIÓN
			// =====================================

			dgv.CellBorderStyle =
				DataGridViewCellBorderStyle.SingleHorizontal;

			dgv.ColumnHeadersBorderStyle =
				DataGridViewHeaderBorderStyle.None;

			dgv.AdvancedCellBorderStyle.Left =
				DataGridViewAdvancedCellBorderStyle.None;

			dgv.AdvancedCellBorderStyle.Right =
				DataGridViewAdvancedCellBorderStyle.None;

			dgv.AdvancedCellBorderStyle.Top =
				DataGridViewAdvancedCellBorderStyle.None;

			dgv.AdvancedCellBorderStyle.Bottom =
				DataGridViewAdvancedCellBorderStyle.Single;

			// =====================================
			// ANCHOS DE COLUMNAS
			// =====================================

			AjustarColumna(dgv, "Semana", 65);
			AjustarColumna(dgv, "Codigo", 85);
			AjustarColumna(dgv, "NombreCompleto", 220);
			AjustarColumna(dgv, "CodigoLugarPago", 95);
			AjustarColumna(dgv, "LugarPago", 145);
			AjustarColumna(dgv, "RegistroPatronal", 125);
			AjustarColumna(dgv, "NumeroIMSS", 120);
			AjustarColumna(dgv, "DiasTrabajados", 85);

			// Importes
			string[] importes =
			{
		"SueldoOrdinario",
		"SeptimoDia",
		"HorasExtras",
		"Domingo",
		"PrimaDominical",
		"Productividad",
		"ISPT",
		"OtrasDeducciones",
		"TotalPercepciones",
		"TotalDeducciones",
		"ImporteNeto",
		"ImporteCFDI"
	};

			foreach (string columna in importes)
			{
				AjustarColumna(dgv, columna, 105);

				if (dgv.Columns.Contains(columna))
				{
					dgv.Columns[columna].DefaultCellStyle.Alignment =
						DataGridViewContentAlignment.MiddleRight;

					dgv.Columns[columna].DefaultCellStyle.Format =
						"N2";
				}
			}

			// Datos fiscales
			AjustarColumna(dgv, "UUID", 220);
			AjustarColumna(dgv, "FechaTimbrado", 135);

			// =====================================
			// ALINEACIÓN DE DATOS
			// =====================================

			if (dgv.Columns.Contains("Codigo"))
				dgv.Columns["Codigo"].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleCenter;

			if (dgv.Columns.Contains("Semana"))
				dgv.Columns["Semana"].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleCenter;

			if (dgv.Columns.Contains("DiasTrabajados"))
				dgv.Columns["DiasTrabajados"].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleCenter;

			dgv.ResumeLayout();
		}

		private void AjustarColumna(
			DataGridView dgv,
			string nombre,
			int ancho)
		{
			if (dgv.Columns.Contains(nombre))
			{
				dgv.Columns[nombre].Width = ancho;
				dgv.Columns[nombre].MinimumWidth = ancho;
				dgv.Columns[nombre].SortMode =
					DataGridViewColumnSortMode.NotSortable;
			}
		}
		private void ActualizarResumen(DataTable dt)
		{
			int total = dt.Rows.Count;

			bool esCfdi = frm.rbCfdi.Checked;
			bool esNormal = frm.rbNormal.Checked;

			frm.lblEmpleados.Text =
				$" {total:N0}";

			frm.lblCfdi.Text =
				$" {(esCfdi ? total : 0):N0}";

			frm.lblNormal.Text =
				$" {(esNormal ? total : 0):N0}";
		}
		private void AgregarBotonQuitar()
		{
			DataGridView dgv = frm.dgvRecibo;

			if (dgv.Columns.Contains("Quitar"))
				dgv.Columns.Remove("Quitar");

			DataGridViewButtonColumn btn = new DataGridViewButtonColumn();

			btn.Name = "Quitar";
			btn.HeaderText = "";
			btn.Text = "−";
			btn.UseColumnTextForButtonValue = true;
			btn.Width = 35;
			btn.MinimumWidth = 35;
			btn.FlatStyle = FlatStyle.Flat;
			btn.ReadOnly = false;

			btn.DefaultCellStyle.Font =
				new Font("Segoe UI", 14, FontStyle.Bold);

			btn.DefaultCellStyle.ForeColor =
				Color.FromArgb(190, 55, 55);

			btn.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.Columns.Add(btn);

			// Colocar antes de Semana
			if (dgv.Columns.Contains("Semana"))
			{
				btn.DisplayIndex =
					dgv.Columns["Semana"].DisplayIndex;
			}
		}
		public void ActualizarResumenDesdeGrid()
		{
			DataTable dt = new DataTable();

			foreach (DataGridViewColumn columna in frm.dgvRecibo.Columns)
			{
				if (columna.Name != "Quitar")
					dt.Columns.Add(columna.Name);
			}

			foreach (DataGridViewRow fila in frm.dgvRecibo.Rows)
			{
				if (fila.IsNewRow)
					continue;

				DataRow nuevaFila = dt.NewRow();

				foreach (DataColumn columna in dt.Columns)
				{
					nuevaFila[columna.ColumnName] =
						fila.Cells[columna.ColumnName].Value ?? DBNull.Value;
				}

				dt.Rows.Add(nuevaFila);
			}

			ActualizarResumen(dt);
		}
		public void CargarLugarPago(ComboBox combo)
		{
			cargando = true;

			try
			{
				dtLugaresPago = CboLugarPago();

				combo.DataSource = null;
				combo.Items.Clear();

				combo.DataSource = null;
				combo.DropDownStyle = ComboBoxStyle.DropDown;
				combo.Text = "Selecciona lugares";
				combo.AutoCompleteMode = AutoCompleteMode.None;
				combo.AutoCompleteSource = AutoCompleteSource.None;

				CrearSelectorMultipleLugares(combo);
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al cargar lugares de pago:\n" + ex.Message);
			}
			finally
			{
				cargando = false;
			}
		}
		private void CrearSelectorMultipleLugares(ComboBox combo)
		{
			clbLugaresPago = new CheckedListBox();

			clbLugaresPago.CheckOnClick = true;
			clbLugaresPago.BorderStyle = BorderStyle.None;
			clbLugaresPago.IntegralHeight = false;
			clbLugaresPago.Width = 300;
			clbLugaresPago.Height = 250;
			clbLugaresPago.Font = new Font("Segoe UI", 9F);

			foreach (DataRow fila in dtLugaresPago.Rows)
			{
				clbLugaresPago.Items.Add(
					new LugarPagoItem
					{
						Codigo = fila["Código"].ToString().Trim(),
						Nombre = fila["Nombre"].ToString().Trim()
					});
			}

			clbLugaresPago.DisplayMember = "Nombre";

			hostLugares = new ToolStripControlHost(clbLugaresPago)
			{
				AutoSize = false,
				Size = new Size(305, 255),
				Padding = new Padding(3)
			};

			menuLugares = new ToolStripDropDown();
			menuLugares.Items.Add(hostLugares);

			clbLugaresPago.ItemCheck -= clbLugaresPago_ItemCheck;
			clbLugaresPago.ItemCheck += clbLugaresPago_ItemCheck;

			combo.DropDown -= cboLugarPago_DropDown;
			combo.DropDown += cboLugarPago_DropDown;
		}
		private class LugarPagoItem
		{
			public string Codigo { get; set; }
			public string Nombre { get; set; }

			public override string ToString()
			{
				return Nombre;
			}
		}
		private void cboLugarPago_DropDown(
	object sender,
	EventArgs e)
		{
			ComboBox combo = sender as ComboBox;

			if (combo == null || menuLugares == null)
				return;

			combo.DroppedDown = false;

			if (frm.IsHandleCreated)
			{
				frm.BeginInvoke(new Action(() =>
				{
					if (menuLugares != null)
					{
						menuLugares.Show(
							combo,
							0,
							combo.Height);
					}
				}));
			}
		}
		private void clbLugaresPago_ItemCheck(
	object sender,
	ItemCheckEventArgs e)
		{
			if (cargandoLugares)
				return;

			if (frm.IsHandleCreated)
			{
				frm.BeginInvoke(new Action(() =>
				{
					ActualizarLugaresSeleccionados();
				}));
			}
		}
		private void ActualizarLugaresSeleccionados()
		{
			codigosLugaresSeleccionados.Clear();

			List<string> nombres = new List<string>();

			foreach (LugarPagoItem item in clbLugaresPago.CheckedItems)
			{
				codigosLugaresSeleccionados.Add(item.Codigo);
				nombres.Add(item.Nombre);
			}

			if (nombres.Count == 0)
			{
				frm.cboLugarPago.Text = "------ selecciona lugares ------";
			}
			else if (nombres.Count == 1)
			{
				frm.cboLugarPago.Text = nombres[0];
			}
			else
			{
				frm.cboLugarPago.Text =
					nombres.Count + " lugares seleccionados";
			}
		}
		private void cboLugarPago_Click(object sender, EventArgs e)
		{
			ComboBox combo = sender as ComboBox;

			if (combo == null || menuLugares == null)
				return;

			menuLugares.Show(
				combo,
				0,
				combo.Height);
		}
	
		private List<string> ObtenerCodigosLugaresPago()
		{
			return new List<string>(codigosLugaresSeleccionados);
		}
	}
}