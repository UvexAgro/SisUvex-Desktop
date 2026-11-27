 using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.Values;
using SisUvex.Configuracion;

namespace SisUvex.Nomina.Nom_SemAutomaticaCampo
{
	public class ClsNomina
	{
		public FrmNomina frm;
		private bool cargando = false;
		public class CuadrillaItem
		{
			public string ID { get; set; }
			public string Codigo { get; set; }
			public string Nombre { get; set; }

			public override string ToString()
			{
				return $"{Codigo} - {Nombre}";
			}
		}
		public void CargarCuadrillaCampoCheck(ClsListaCuadrillas lista)
		{
			cargando = true;

			try
			{
				DataTable dt =
					CboCuadrillaCampo();

				lista.Limpiar();

				foreach (DataRow row in dt.Rows)
				{
					CuadrillaItem cuadrilla =
						new CuadrillaItem
						{
							ID =
								row["ID"].ToString(),

							Codigo =
								row["Código"].ToString(),

							Nombre =
								row["Nombre"].ToString()
						};

					lista.AgregarCuadrilla(
						cuadrilla);
				}
			}
			finally
			{
				cargando = false;
			}
		}

		public void CargarCuadrillaCampo(ComboBox combo)
		{
			cargando = true;

			try
			{
				DataTable dt = CboCuadrillaCampo();

				DataRow dr = dt.NewRow();
				dr["ID"] = "";
				dr["Código"] = "";
				dr["Nombre"] = " ------ Selecciona ------ ";

				dt.Rows.InsertAt(dr, 0);

				combo.DataSource = dt.Copy();
				combo.DisplayMember = "Nombre";
				combo.ValueMember = "ID";
				combo.SelectedIndex = 0;
			}
			finally
			{
				cargando = false;
			}
		}
		public DataTable CboCuadrillaCampo()
		{
			SQLControl sql = new SQLControl();
			DataTable dt = new DataTable();

			sql.OpenConectionWrite();

			string query = @"
			SELECT 
				g.id_workGroup AS ID,
				g.c_order AS Código,
				g.v_nameWorkGroup AS Nombre
			FROM Nom_WorkGroup g
			WHERE g.c_active = 1
			ORDER BY
				CASE 
					WHEN g.c_order IS NULL OR g.c_order = '' THEN 1
					ELSE 0
				END,
				g.c_order,
				g.id_workGroup";

			SqlCommand cmd =
				new SqlCommand(query, sql.cnn);

			SqlDataAdapter da =
				new SqlDataAdapter(cmd);

			da.Fill(dt);

			sql.CloseConectionWrite();

			return dt;
		}
		public List<string> ObtenerIdsCuadrillasSeleccionadas()
		{
			return frm.cuadrillasSeleccionadas
				.Cast<CuadrillaItem>()
				.Select(x => x.ID)
				.ToList();
		}
		public void ConsultarNomina()
		{
			SQLControl sql = new SQLControl();

			try
			{
				DateTime fecha =
					frm.dtpFecha.Value.Date;

				// =====================================================
				// OBTENER CUADRILLAS SELECCIONADAS
				// =====================================================

				List<string> idsCuadrillas =
					ObtenerIdsCuadrillasSeleccionadas();

				// =====================================================
				// VALIDAR QUE HAYA SELECCIÓN
				// =====================================================

				if (idsCuadrillas.Count == 0)
				{
					MessageBox.Show(
						"Seleccione al menos una cuadrilla.",
						"Cuadrillas",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);

					return;
				}

				// =====================================================
				// VALIDAR TODAS LAS CUADRILLAS
				// =====================================================

				foreach (string idCuadrilla in idsCuadrillas)
				{
					bool datosCompletos =
						ValidarLoteYActividad(
							fecha,
							idCuadrilla
						);

					if (!datosCompletos)
					{
						return;
					}
				}

				// =====================================================
				// ABRIR CONEXIÓN
				// =====================================================

				sql.OpenConectionWrite();

				DataTable dtFinal =
					new DataTable();

				// =====================================================
				// CONSULTAR CADA CUADRILLA
				// =====================================================

				foreach (string idCuadrilla in idsCuadrillas)
				{
					using (SqlCommand cmd =
						new SqlCommand(
							"sp_ReporteNominadeCampo",
							sql.cnn))
					{
						cmd.CommandType =
							CommandType.StoredProcedure;

						cmd.Parameters.Add(
							"@FechaNomina",
							SqlDbType.Date
						).Value = fecha;

						cmd.Parameters.Add(
							"@IdWorkGroup",
							SqlDbType.VarChar,
							3
						).Value = idCuadrilla;

						using (SqlDataAdapter da =
							new SqlDataAdapter(cmd))
						{
							DataTable dt =
								new DataTable();

							da.Fill(dt);

							// =========================================
							// AGREGAR RESULTADOS
							// =========================================

							if (dtFinal.Columns.Count == 0)
							{
								dtFinal = dt.Clone();

								// Columna interna para saber a qué cuadrilla pertenece cada registro
								dtFinal.Columns.Add(
									"id_workGroup_CSV",
									typeof(string));
							}

							foreach (DataRow row in dt.Rows)
							{
								dtFinal.ImportRow(row);

								// Guardar el ID real de la cuadrilla
								dtFinal.Rows[dtFinal.Rows.Count - 1]["id_workGroup_CSV"] =
									idCuadrilla;
							}
						}
					}
				}

				// =====================================================
				// MOSTRAR RESULTADO
				// =====================================================

				frm.dgvNomina.DataSource = dtFinal;

				// Ocultar columna interna
				if (frm.dgvNomina.Columns.Contains("id_workGroup_CSV"))
				{
					frm.dgvNomina.Columns["id_workGroup_CSV"].Visible = false;
				}

				// =====================================================
				// MOSTRAR U OCULTAR PAGO FESTIVO
				// =====================================================

				bool esFestivo = EsDiaFestivo(fecha);

				if (frm.dgvNomina.Columns.Contains("Pago Festivo"))
				{
					frm.dgvNomina.Columns["Pago Festivo"].Visible = esFestivo;
				}

				ConfigurarDgvNomina();

				frm.dgvNomina.ClearSelection();
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al consultar la nómina:\n" +
					ex.Message,
					"Consulta de nómina",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}

		private void ConfigurarDgvNomina()
		{
			DataGridView dgv = frm.dgvNomina;

			Color texto = Color.FromArgb(35, 65, 90);
			Color encabezado = Color.FromArgb(226, 235, 243);
			Color filaAlterna = Color.FromArgb(243, 247, 251);
			Color seleccion = Color.FromArgb(216, 233, 246);
			Color borde = Color.FromArgb(232, 238, 244);

			dgv.AutoGenerateColumns = true;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToResizeRows = false;
			dgv.ReadOnly = true;

			// Fondo general
			dgv.BackgroundColor = Color.White;
			dgv.BorderStyle = BorderStyle.None;
			dgv.GridColor = borde;

			// Quitar encabezado lateral
			dgv.RowHeadersVisible = false;

			// Filas
			dgv.RowTemplate.Height = 30;
			dgv.RowHeadersWidthSizeMode =
				DataGridViewRowHeadersWidthSizeMode.DisableResizing;

			// Selección
			dgv.SelectionMode =
				DataGridViewSelectionMode.FullRowSelect;
			dgv.MultiSelect = false;

			// Evitar el estilo predeterminado de Windows
			dgv.EnableHeadersVisualStyles = false;

			// Encabezados
			dgv.ColumnHeadersDefaultCellStyle.BackColor = encabezado;
			dgv.ColumnHeadersDefaultCellStyle.ForeColor = texto;
			dgv.ColumnHeadersDefaultCellStyle.Font =
				new Font("Segoe UI", 9F, FontStyle.Bold);

			dgv.ColumnHeadersDefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleLeft;

			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = encabezado;
			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = texto;
			dgv.ColumnHeadersDefaultCellStyle.Padding =
				new Padding(7, 0, 4, 0);

			dgv.ColumnHeadersHeight = 42;
			dgv.ColumnHeadersHeightSizeMode =
				DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

			// Celdas normales
			dgv.DefaultCellStyle.BackColor = Color.White;
			dgv.DefaultCellStyle.ForeColor = texto;
			dgv.DefaultCellStyle.Font =
				new Font("Segoe UI", 9F);

			dgv.DefaultCellStyle.SelectionBackColor = seleccion;
			dgv.DefaultCellStyle.SelectionForeColor = texto;
			dgv.DefaultCellStyle.Padding =
				new Padding(6, 2, 6, 2);

			// Filas alternadas
			dgv.AlternatingRowsDefaultCellStyle.BackColor = filaAlterna;
			dgv.AlternatingRowsDefaultCellStyle.ForeColor = texto;
			dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = seleccion;
			dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = texto;

			// Líneas horizontales discretas
			dgv.CellBorderStyle =
				DataGridViewCellBorderStyle.SingleHorizontal;

			dgv.ColumnHeadersBorderStyle =
				DataGridViewHeaderBorderStyle.Single;

			dgv.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.Fill;

			dgv.AutoSizeRowsMode =
				DataGridViewAutoSizeRowsMode.None;
		}



		public void GenerarArchivoCsv()
		{
			DataTable dtNomina = GetDtNomina();

			if (dtNomina == null || dtNomina.Rows.Count == 0)
			{
				MessageBox.Show(
					"No hay datos para generar.",
					"Reporte CSV",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);
				return;
			}

			bool esFestivo = frm.rbFestivo.Checked;

			// REFERENCIAS
			string referenciaNormal = frm.txbReferencia.Text.Trim();
			string referenciaFestivo = frm.txbReferenciaFestivo.Text.Trim();
			string actividadFestivo = frm.txbActividad.Text.Trim();
			string loteFestivo = frm.txbLote.Text.Trim();

			if (string.IsNullOrWhiteSpace(referenciaNormal))
			{
				MessageBox.Show("Captura la referencia de la nómina normal.");
				return;
			}

			if (esFestivo)
			{
				if (string.IsNullOrWhiteSpace(referenciaFestivo))
				{
					MessageBox.Show("Captura la referencia de la nómina festiva.");
					return;
				}

				if (string.IsNullOrWhiteSpace(actividadFestivo))
				{
					MessageBox.Show("Captura la actividad del pago festivo.");
					return;
				}

				if (string.IsNullOrWhiteSpace(loteFestivo))
				{
					MessageBox.Show("Captura el lote del pago festivo.");
					return;
				}
			}

			DateTime fechaNomina =
				Convert.ToDateTime(dtNomina.Rows[0]["Fecha"]);

			// =========================================
			// PREPARAR LOS CSV
			// =========================================

			DataTable dtNormal;
			DataTable dtFestivo = null;

			if (esFestivo)
			{
				// PRIMER CSV: SALARIO DIARIO
				dtNormal = GetDtCSV(
					true,
					false,
					referenciaNormal,
					"");

				// SEGUNDO CSV: PAGO FESTIVO
				dtFestivo = GetDtCSV(
					true,
					true,
					referenciaFestivo,
					actividadFestivo);

				if (dtNormal == null || dtNormal.Rows.Count == 0)
				{
					MessageBox.Show(
						"No existen salarios para generar el primer archivo.");
					return;
				}

				if (dtFestivo == null || dtFestivo.Rows.Count == 0)
				{
					MessageBox.Show(
						"No existen importes de pago festivo para generar el segundo archivo.");
					return;
				}
			}
			else
			{
				// DÍA NORMAL: TOTAL
				dtNormal = GetDtCSV(
					false,
					false,
					referenciaNormal,
					"");

				if (dtNormal == null || dtNormal.Rows.Count == 0)
				{
					MessageBox.Show("No existen datos para generar el CSV.");
					return;
				}
			}

			// =========================================
			// SELECCIONAR UBICACIÓN
			// =========================================

			string rutaNormal;
			string rutaFestivo = "";

			using (SaveFileDialog sfd = new SaveFileDialog())
			{
				sfd.Filter = "Archivo CSV (*.csv)|*.csv";
				sfd.FileName = $"{referenciaNormal}.csv";

				if (sfd.ShowDialog() != DialogResult.OK)
					return;

				rutaNormal = sfd.FileName;

				if (esFestivo)
				{
					rutaFestivo = Path.Combine(
					Path.GetDirectoryName(rutaNormal),
					$"{referenciaFestivo}.csv");
				}
			}

			try
			{
				// =========================================
				// GENERAR PRIMER CSV
				// =========================================

				GuardarArchivoCsv(dtNormal, rutaNormal);

				// =========================================
				// GENERAR SEGUNDO CSV FESTIVO
				// =========================================

				if (esFestivo)
				{
					GuardarArchivoCsv(dtFestivo, rutaFestivo);
				}

				// =========================================
				// OBTENER CUADRILLAS
				// =========================================

				if (!dtNomina.Columns.Contains("id_workGroup_CSV"))
				{
					MessageBox.Show(
						"El listado no contiene el ID de las cuadrillas.",
						"CSV",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					return;
				}

				List<string> idsCuadrillas =
					dtNomina.AsEnumerable()
						.Select(r =>
							r["id_workGroup_CSV"]?.ToString()?.Trim())
						.Where(x => !string.IsNullOrWhiteSpace(x))
						.Distinct()
						.ToList();

				// =========================================
				// REGISTRAR CSV GENERADO
				// =========================================

				SQLControl sql = new SQLControl();

				try
				{
					sql.OpenConectionWrite();

					foreach (string idCuadrilla in idsCuadrillas)
					{
						using (SqlCommand cmd = new SqlCommand(
							"sp_AddCsvGenerated", sql.cnn))
						{
							cmd.CommandType = CommandType.StoredProcedure;

							cmd.Parameters.Add(
								"@IdWorkGroup",
								SqlDbType.Char,
								3).Value = idCuadrilla;

							cmd.Parameters.Add(
								"@FechaNomina",
								SqlDbType.Date).Value = fechaNomina.Date;

							cmd.ExecuteNonQuery();
						}
					}
				}
				finally
				{
					sql.CloseConectionWrite();
				}

				// =========================================
				// MENSAJE FINAL
				// =========================================

				string mensaje;

				if (esFestivo)
				{
					mensaje =
						"Se generaron los dos archivos correctamente.\n\n" +

						"PRIMER CSV - SALARIO DIARIO\n" +
						"Referencia: " + referenciaNormal + "\n" +
						"Importe: Salario Diario\n" +
						"Lote: Código Lote\n" +
						"Actividad: Código Actividad\n" +
						"Archivo: " + Path.GetFileName(rutaNormal) + "\n\n" +

						"SEGUNDO CSV - PAGO FESTIVO\n" +
						"Referencia: " + referenciaFestivo + "\n" +
						"Importe: Pago Festivo\n" +
						"Lote: " + loteFestivo + "\n" +
						"Actividad: " + actividadFestivo + "\n" +
						"Archivo: " + Path.GetFileName(rutaFestivo);
				}
				else
				{
					mensaje =
						"El archivo CSV se generó correctamente.\n\n" +
						"Referencia: " + referenciaNormal + "\n" +
						"Importe: Total\n" +
						"Archivo: " + Path.GetFileName(rutaNormal);
				}

				DialogResult resultado = MessageBox.Show(
					mensaje + "\n\n¿Deseas abrir los archivos?",
					"CSV generado",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Information);

				if (resultado == DialogResult.Yes)
				{
					AbrirArchivoCsv(rutaNormal);

					if (esFestivo)
						AbrirArchivoCsv(rutaFestivo);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al generar los archivos CSV:\n\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}






		private DataTable GetDtCSV(
			bool esDiaFestivo,
			bool soloFestivo,
			string referencia,
			string actividadFestivo)
		{
			DataTable dtNomina = GetDtNomina();

			if (dtNomina == null || dtNomina.Rows.Count == 0)
				return null;

			DataTable dtCsv = new DataTable();

			dtCsv.Columns.Add("Fecha", typeof(string));
			dtCsv.Columns.Add("Referencia", typeof(string));
			dtCsv.Columns.Add("Codigo", typeof(string));
			dtCsv.Columns.Add("Sueldo", typeof(string));
			dtCsv.Columns.Add("Lote", typeof(string));
			dtCsv.Columns.Add("Actividad", typeof(string));
			dtCsv.Columns.Add("TotalCajas", typeof(string));
			dtCsv.Columns.Add("HorasTrabajadas", typeof(string));

			string jornada = frm.txbJornada.Text.Trim();

			string destajo = string.IsNullOrWhiteSpace(frm.txbDestajo.Text)
				? "0"
				: frm.txbDestajo.Text.Trim();

			// Lote capturado para el segundo CSV festivo
			string loteFestivo = frm.txbLote.Text.Trim();

			foreach (DataRow dr in dtNomina.Rows)
			{
				decimal sueldo = 0;

				// =====================================
				// DETERMINAR SUELDO
				// =====================================

				if (esDiaFestivo)
				{
					if (soloFestivo)
					{
						// SEGUNDO CSV: PAGO FESTIVO
						sueldo = Convert.ToDecimal(
							dr["Pago Festivo"] == DBNull.Value
								? 0
								: dr["Pago Festivo"]);
					}
					else
					{
						// PRIMER CSV: SALARIO DIARIO
						sueldo = Convert.ToDecimal(
							dr["Salario Diario"] == DBNull.Value
								? 0
								: dr["Salario Diario"]);
					}

					if (sueldo <= 0)
						continue;
				}
				else
				{
					// DÍA NORMAL: TOTAL
					sueldo = Convert.ToDecimal(
						dr["Total"] == DBNull.Value
							? 0
							: dr["Total"]);
				}

				// =====================================
				// FECHA
				// =====================================

				string fechaFormateada =
					Convert.ToDateTime(dr["Fecha"])
						.ToString("yyyy/MM/dd");

				// =====================================
				// ACTIVIDAD
				// =====================================

				string actividad;

				if (esDiaFestivo && soloFestivo)
				{
					// SEGUNDO CSV: ACTIVIDAD CAPTURADA
					actividad = actividadFestivo;
				}
				else
				{
					// PRIMER CSV Y DÍA NORMAL:
					// ACTIVIDAD DE LA COLUMNA
					actividad = dr["Código Actividad"].ToString();
				}

				// =====================================
				// LOTE
				// =====================================

				string lote;

				if (esDiaFestivo && soloFestivo)
				{
					// SEGUNDO CSV: LOTE DEL TXBLOTE
					lote = loteFestivo;
				}
				else
				{
					// PRIMER CSV Y DÍA NORMAL:
					// LOTE DE LA COLUMNA
					lote = dr["Código Lote"].ToString();
				}

				// =====================================
				// AGREGAR REGISTRO
				// =====================================

				dtCsv.Rows.Add(
					fechaFormateada,
					referencia,
					dr["Código Empleado"].ToString(),
					ClsValues.FormatZeros(
						sueldo.ToString("0.00"),
						"0000.00"),
					lote,
					actividad,
					destajo,
					jornada
				);
			}

			return dtCsv;
		}




		private void AbrirArchivoCsv(string ruta)
		{
			System.Diagnostics.Process.Start(
				new System.Diagnostics.ProcessStartInfo
				{
					FileName = "notepad.exe",
					Arguments = $"\"{ruta}\"",
					UseShellExecute = true
				});
		}

		private void GuardarArchivoCsv(DataTable dt, string ruta)
		{
			string separador =
				CultureInfo.CurrentCulture.TextInfo.ListSeparator;

			using (StreamWriter sw = new StreamWriter(
				ruta,
				false,
				Encoding.UTF8))
			{
				foreach (DataRow row in dt.Rows)
				{
					string[] campos = row.ItemArray.Select(campo =>
					{
						string valor = campo?.ToString() ?? "";

						if (valor.Contains(separador) ||
							valor.Contains("\""))
						{
							valor = valor.Replace("\"", "\"\"");
							valor = $"\"{valor}\"";
						}

						return valor;

					}).ToArray();

					sw.WriteLine(string.Join(separador, campos));
				}
			}

			if (!File.Exists(ruta))
			{
				throw new Exception(
					"No se pudo guardar el archivo:\n" + ruta);
			}
		}

		private DataTable GetDtNomina()
		{
			return frm.dgvNomina.DataSource as DataTable;
		}

		public void CargarLugarPago(ComboBox combo)
		{
			cargando = true;

			DataTable dt = CboLugarPago();

			DataRow dr = dt.NewRow();
			dr["Código"] = "";
			dr["Nombre"] = " ------ selecciona ------ ";
			dt.Rows.InsertAt(dr, 0);

			combo.DataSource = dt.Copy();
			combo.DisplayMember = "Nombre";
			combo.ValueMember = "Código";
			combo.SelectedIndex = 0;

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
		public void CargarSemanas()
		{
			SQLControl sql = new SQLControl();
			DataTable dt = new DataTable();

			try
			{
				if (frm.cboPeriodo.SelectedValue == null)
					return;

				string periodo = frm.cboPeriodo.SelectedValue.ToString();

				sql.OpenConectionWrite();

				string query = @"
            SELECT
                id_period,
                c_sequence_per,
                d_startDate_per,
                d_endDate_per,
                v_name_per
            FROM dbo.Payroll_AttendancePeriod
            WHERE c_active = '1'
              AND id_period = @Periodo
            ORDER BY d_startDate_per DESC;";

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				{
					cmd.Parameters.AddWithValue("@Periodo", periodo);

					using (SqlDataAdapter da = new SqlDataAdapter(cmd))
					{
						da.Fill(dt);
					}
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

			if (!dt.Columns.Contains("SemanaMostrar"))
				dt.Columns.Add("SemanaMostrar", typeof(string));

			foreach (DataRow row in dt.Rows)
			{
				DateTime inicio = Convert.ToDateTime(row["d_startDate_per"]);
				DateTime fin = Convert.ToDateTime(row["d_endDate_per"]);

				row["SemanaMostrar"] =
					"Semana " + row["c_sequence_per"].ToString().Trim() +
					" | " +
					inicio.ToString("dd/MM/yyyy") +
					" - " +
					fin.ToString("dd/MM/yyyy");
			}

			frm.cboSemana.DataSource = null;
			frm.cboSemana.DisplayMember = "SemanaMostrar";
			frm.cboSemana.ValueMember = "c_sequence_per";
			frm.cboSemana.DataSource = dt;

			if (dt.Rows.Count > 0)
				SeleccionarSemanaActual(dt);
			else
				frm.cboSemana.SelectedIndex = -1;
		}
		public void CargarPeriodos()
		{
			SQLControl sql = new SQLControl();
			DataTable dt = new DataTable();

			try
			{
				sql.OpenConectionWrite();

				string query = @"
            SELECT
                c_codigo_tem,
                v_nombre_tem,
                CONCAT(c_codigo_tem, ' - ', v_nombre_tem) AS Periodo
            FROM dbo.Nom_AgriculturalCycle
            ORDER BY c_codigo_tem DESC;";

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				using (SqlDataAdapter da = new SqlDataAdapter(cmd))
				{
					da.Fill(dt);
				}

				frm.cboPeriodo.SelectedIndexChanged -= frm.cboPeriodo_SelectedIndexChanged;
				frm.cboPeriodo.SelectedIndexChanged += frm.cboPeriodo_SelectedIndexChanged;

				frm.cboPeriodo.DataSource = null;
				frm.cboPeriodo.DisplayMember = "Periodo"; // CAMBIO
				frm.cboPeriodo.ValueMember = "c_codigo_tem";
				frm.cboPeriodo.DataSource = dt;

				if (dt.Rows.Count > 0)
					frm.cboPeriodo.SelectedIndex = 0;
				else
					frm.cboPeriodo.SelectedIndex = -1;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al cargar periodos: " + ex.Message);
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		private void SeleccionarSemanaActual(DataTable dt)
		{
			DateTime fechaActual = DateTime.Today;

			foreach (DataRow row in dt.Rows)
			{
				DateTime fechaInicio =
					Convert.ToDateTime(
						row["d_startDate_per"]).Date;

				DateTime fechaFin =
					Convert.ToDateTime(
						row["d_endDate_per"]).Date;

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
		public DataTable ConsultarNominaSemana()
		{
			string semana = frm.cboSemana.SelectedValue?.ToString().Trim() ?? "";
			string lugarPago = "";
			string cuadrilla = "";

			if (frm.cboLugarPago.SelectedIndex > 0)
			{
				lugarPago = frm.cboLugarPago.SelectedValue?.ToString().Trim() ?? "";
			}
			else if (frm.cboCuadrillaRevisar.SelectedIndex > 0)
			{
				cuadrilla = frm.cboCuadrillaRevisar.SelectedValue?.ToString().Trim() ?? "";
			}

			var parameters = new Dictionary<string, object>
			{
				["@Semana"] = semana,
				["@LugarPago"] = lugarPago,
				["@Cuadrilla"] = cuadrilla
			};

			string query = @"
			 USE [SisUvex];

			EXEC dbo.sp_RevisarNomina
            @Semana,
            @LugarPago,
            @Cuadrilla;";

			return ClsQuerysDB.ExecuteParameterizedQuery(query, parameters);
		}
		private bool ValidarLoteYActividad(DateTime fecha, string idCuadrilla)
		{
			List<string> empleadosConError = new List<string>();

			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				// =====================================================
				// OBTENER LA SEMANA CORRESPONDIENTE A LA FECHA
				// =====================================================

				string querySemana = @"
			SELECT TOP 1
				c_sequence_per
			FROM dbo.Payroll_AttendancePeriod
			WHERE @Fecha BETWEEN d_startDate_per AND d_endDate_per
			  AND c_active = 1
			ORDER BY d_startDate_per DESC;
		";

				string semana = "";

				using (SqlCommand cmdSemana =
					new SqlCommand(querySemana, sql.cnn))
				{
					cmdSemana.Parameters.Add(
						"@Fecha",
						SqlDbType.Date).Value = fecha;

					object resultado =
						cmdSemana.ExecuteScalar();

					if (resultado != null &&
						resultado != DBNull.Value)
					{
						semana =
							resultado.ToString().Trim();
					}
				}

				if (string.IsNullOrWhiteSpace(semana))
				{
					MessageBox.Show(
						"No se encontró una semana para la fecha seleccionada.",
						"Validación",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					return false;
				}


				// =====================================================
				// DETERMINAR EL PREFIJO SEGÚN EL DÍA
				// =====================================================

				string prefijo;

				switch (fecha.DayOfWeek)
				{
					case DayOfWeek.Friday:
						prefijo = "vie";
						break;

					case DayOfWeek.Saturday:
						prefijo = "sab";
						break;

					case DayOfWeek.Sunday:
						prefijo = "dom";
						break;

					case DayOfWeek.Monday:
						prefijo = "lun";
						break;

					case DayOfWeek.Tuesday:
						prefijo = "mar";
						break;

					case DayOfWeek.Wednesday:
						prefijo = "mie";
						break;

					case DayOfWeek.Thursday:
						prefijo = "jue";
						break;

					default:
						return false;
				}


				// =====================================================
				// CONSULTA DE VALIDACIÓN
				// =====================================================

				string query = $@"

			SELECT
				aw.id_employee,

				emp.v_lastNamePat,
				emp.v_lastNameMat,
				emp.v_name,

				aw.id_activity_{prefijo},
				aw.id_lot_{prefijo},

				-- ID REAL DE LA CUADRILLA
				aw.id_workGroup_{prefijo} AS id_workGroup,

				-- DATOS DE LA CUADRILLA
				wg.c_order,
				wg.v_nameWorkGroup

			FROM dbo.Nom_EmployeeAttendanceWeekly aw

			LEFT JOIN dbo.Nom_Employees emp
				ON emp.id_employee = aw.id_employee

			LEFT JOIN dbo.Nom_WorkGroup wg
				ON wg.id_workGroup =
				   aw.id_workGroup_{prefijo}

			WHERE TRY_CONVERT(INT, aw.c_sequence_per) =
				  TRY_CONVERT(INT, @Semana)

			 AND aw.c_{prefijo} = '1'
		";


				// =====================================================
				// SI SE SELECCIONÓ CUADRILLA
				// =====================================================

				if (!string.IsNullOrWhiteSpace(idCuadrilla))
				{
					query += $@"

				AND aw.id_workGroup_{prefijo} =
					@IdWorkGroup
			";
				}


				// =====================================================
				// EJECUTAR CONSULTA
				// =====================================================

				DataTable dtValidacion =
					new DataTable();

				using (SqlCommand cmd =
					new SqlCommand(query, sql.cnn))
				{
					cmd.Parameters.Add(
						"@Semana",
						SqlDbType.VarChar,
						4).Value = semana;

					if (!string.IsNullOrWhiteSpace(idCuadrilla))
					{
						cmd.Parameters.Add(
							"@IdWorkGroup",
							SqlDbType.VarChar,
							4).Value =
								idCuadrilla;
					}

					using (SqlDataAdapter da =
						new SqlDataAdapter(cmd))
					{
						da.Fill(dtValidacion);
					}
				}


				// =====================================================
				// REVISAR EMPLEADOS
				// =====================================================

				foreach (DataRow row in dtValidacion.Rows)
				{
					// =================================================
					// EMPLEADO
					// =================================================

					string folio =
						row["id_employee"]?
						.ToString()
						.Trim() ?? "";

					string nombre =
						(
							row["v_lastNamePat"]?
							.ToString()
							.Trim() + " " +

							row["v_lastNameMat"]?
							.ToString()
							.Trim() + " " +

							row["v_name"]?
							.ToString()
							.Trim()
						).Trim();


					// =================================================
					// ACTIVIDAD
					// =================================================

					string actividad =
						row[$"id_activity_{prefijo}"]?
						.ToString()
						.Trim() ?? "";


					// =================================================
					// LOTE
					// =================================================

					string lote =
						row[$"id_lot_{prefijo}"]?
						.ToString()
						.Trim() ?? "";


					// =================================================
					// CUADRILLA
					// =================================================

					string codigoCuadrilla =
						row["c_order"]?
						.ToString()
						.Trim() ?? "";

					string nombreCuadrilla =
						row["v_nameWorkGroup"]?
						.ToString()
						.Trim() ?? "";

					string cuadrilla =
						$"{codigoCuadrilla} - {nombreCuadrilla}";


					// =================================================
					// VALIDAR
					// =================================================

					bool faltaActividad =
						string.IsNullOrWhiteSpace(actividad);

					bool faltaLote =
						string.IsNullOrWhiteSpace(lote);


					if (faltaActividad ||
						faltaLote)
					{
						string faltante;

						if (faltaActividad &&
							faltaLote)
						{
							faltante =
								"Actividad y Lote";
						}
						else if (faltaActividad)
						{
							faltante =
								"Actividad";
						}
						else
						{
							faltante =
								"Lote";
						}


						// =================================================
						// AGREGAR EMPLEADO CON ERROR
						// =================================================

						empleadosConError.Add(
							$"{folio} - {nombre} " +
							$"→ Cuadrilla: {cuadrilla} " +
							$"→ Falta {faltante}"
						);
					}
				}


				// =====================================================
				// SI HAY ERRORES
				// =====================================================

				if (empleadosConError.Count > 0)
				{
					StringBuilder mensaje =
						new StringBuilder();

					mensaje.AppendLine(
						"NO SE PUEDE GENERAR LA NÓMINA."
					);

					mensaje.AppendLine();

					mensaje.AppendLine(
						$"Fecha: {fecha:dd/MM/yyyy}"
					);

					mensaje.AppendLine();

					mensaje.AppendLine(
						"Los siguientes empleados no tienen " +
						"Lote y/o Actividad:"
					);

					mensaje.AppendLine();


					foreach (string empleado
						in empleadosConError)
					{
						mensaje.AppendLine(
							"• " + empleado);
					}


					MessageBox.Show(
						mensaje.ToString(),
						"Información incompleta",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					return false;
				}


				// =====================================================
				// TODO CORRECTO
				// =====================================================

				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al validar Lote y Actividad:\n" +
					ex.Message,
					"Validación",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return false;
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public void CargarCuadrillasConCsv(ListBox ckbCSV,DateTime fecha)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				string query = @"
			SELECT DISTINCT
				wg.c_order,
				wg.v_nameWorkGroup
			FROM Nom_CsvGenerated cg
			INNER JOIN Nom_WorkGroup wg
				ON cg.id_workGroup = wg.id_workGroup
			WHERE CONVERT(date, cg.d_fechaNomina) = @Fecha
			ORDER BY wg.c_order";

				using (SqlCommand cmd =
					new SqlCommand(query, sql.cnn))
				{
					cmd.Parameters.Add(
						"@Fecha",
						SqlDbType.Date).Value =
						fecha.Date;

					using (SqlDataReader dr =
						cmd.ExecuteReader())
					{
						ckbCSV.Items.Clear();

						while (dr.Read())
						{
							string codigo =
								dr["c_order"]?.ToString()?.Trim() ?? "";

							string nombre =
								dr["v_nameWorkGroup"]?.ToString()?.Trim() ?? "";

							ckbCSV.Items.Add(
								$"{codigo} - {nombre}");
						}
					}
				}
				frm.pnlCSV.Visible = ckbCSV.Items.Count > 0;

				frm.lblCuadrillas.Text =ckbCSV.Items.Count.ToString();
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public void ActualizarListaCSV()
		{
			CargarCuadrillasConCsv(
				frm.lbCSV,
				frm.dtpFecha.Value
			);
		}
		public void ConfigurarDgvNominaReevisar()
		{
			frm.dgvNomina.AutoGenerateColumns = true;

			frm.dgvNomina.AllowUserToAddRows = false;
			frm.dgvNomina.AllowUserToDeleteRows = false;
			frm.dgvNomina.ReadOnly = true;

			frm.dgvNomina.RowHeadersVisible = false;
			frm.dgvNomina.SelectionMode =
				DataGridViewSelectionMode.FullRowSelect;

			frm.dgvNomina.MultiSelect = false;

			frm.dgvNomina.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.None;

			frm.dgvNomina.RowTemplate.Height = 38;

			frm.dgvNomina.DefaultCellStyle.Font =
				new Font("Segoe UI", 9F);

			frm.dgvNomina.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			frm.dgvNomina.DefaultCellStyle.SelectionBackColor =
				Color.FromArgb(190, 225, 245);

			frm.dgvNomina.DefaultCellStyle.SelectionForeColor =
				Color.FromArgb(25, 60, 85);

			frm.dgvNomina.ColumnHeadersDefaultCellStyle.BackColor =
				Color.FromArgb(35, 103, 149);

			frm.dgvNomina.ColumnHeadersDefaultCellStyle.ForeColor =
				Color.White;

			frm.dgvNomina.ColumnHeadersDefaultCellStyle.Font =
				new Font("Segoe UI", 9F, FontStyle.Bold);

			frm.dgvNomina.EnableHeadersVisualStyles = false;

			frm.dgvNomina.ColumnHeadersHeight = 38;
			frm.dgvNomina.ColumnHeadersHeightSizeMode =
				DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
		}
		public bool EsDiaFestivo(DateTime fecha)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				string query = @"
            SELECT CASE
                WHEN EXISTS
                (
                    SELECT 1
                    FROM dbo.Cat_Festivos
                    WHERE CONVERT(DATE, d_fecha) = @Fecha
                )
                THEN 1
                ELSE 0
            END";

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				{
					cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = fecha.Date;

					return Convert.ToInt32(cmd.ExecuteScalar()) == 1;
				}
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
	}
}