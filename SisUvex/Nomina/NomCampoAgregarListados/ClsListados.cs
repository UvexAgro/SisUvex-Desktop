using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.Formula.Functions;
using SisUvex.Nomina.Conceptos_Ingresos_Diversos;

namespace SisUvex.Nomina.NomCampoAgregarListados
{
	public class ClsListados
	{
		public FrmListados frm;
		public FrmAgregar frmA;
		public ClsAgregar clsA;
		private PrintDocument printDocument = new PrintDocument();
		private int filaImprimir = 0;
		public bool IsAddOrModify = true, IsAddUpdate = false, IsModifyUpdate = false;
		public string? idAddModify;
		public string IdCuadrilla { get; set; }
		public DateTime FechaInicio { get; set; }
		public DateTime FechaFin { get; set; }
		public string IdLote { get; set; }
		public ClsListados()
		{
			// HOJA CARTA
			printDocument.DefaultPageSettings.PaperSize =
				new PaperSize("Carta", 850, 1100);

			// HORIZONTAL
			printDocument.DefaultPageSettings.Landscape = true;

			// MÁRGENES
			printDocument.DefaultPageSettings.Margins =
				new Margins(50, 50, 50, 50);

			printDocument.PrintPage += PrintDocument_PrintPage;
		}
		public void CargarCuadrillas()
		{
			SQLControl sql = new SQLControl();
			DataTable dt = new DataTable();

			try
			{
				sql.OpenConectionWrite();

				string query = @"
				SELECT
					id_workGroup AS Codigo,
					v_nameWorkGroup AS [Cuadrilla]
				FROM Nom_WorkGroup
				WHERE c_active = 1
				ORDER BY id_workGroup";

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				using (SqlDataAdapter da = new SqlDataAdapter(cmd))
				{
					da.Fill(dt);
				}

				frm.dgvCuadrilla.DataSource = dt;
				// Cargar datos en el DataGridView
				frm.dgvCuadrilla.DataSource = dt;

				// Agregar CheckBox solamente una vez
				if (!frm.dgvCuadrilla.Columns.Contains("Seleccionar"))
				{
					DataGridViewCheckBoxColumn seleccionar =
					new DataGridViewCheckBoxColumn();

					seleccionar.Name = "Imprimir";
					seleccionar.HeaderText = "";
					seleccionar.ReadOnly = false;
					seleccionar.Width = 55;

					frm.dgvCuadrilla.Columns.Insert(0, seleccionar);
				}

				// Aplicar el estilo después de agregar las columnas
				EstiloDgvCuadrilla();
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Error al cargar cuadrillas",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public void CargarSemanas()
		{
			SQLControl sql = new SQLControl();

			string query = @"
		SELECT
			id_period,
			c_sequence_per,
			d_startDate_per,
			d_endDate_per,
			v_name_per
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

			// Crear texto que se mostrará en el ComboBox
			if (!dt.Columns.Contains("SemanaMostrar"))
			{
				dt.Columns.Add("SemanaMostrar", typeof(string));
			}

			foreach (DataRow row in dt.Rows)
			{
				DateTime fechaInicio =
					Convert.ToDateTime(row["d_startDate_per"]).Date;

				DateTime fechaFin =
					Convert.ToDateTime(row["d_endDate_per"]).Date;

				row["SemanaMostrar"] =
					"Semana " + row["c_sequence_per"].ToString().Trim() +
					" | " +
					fechaInicio.ToString("dd/MM/yyyy") +
					" - " +
					fechaFin.ToString("dd/MM/yyyy");
			}

			frm.cboSemana.DataSource = null;

			frm.cboSemana.DisplayMember = "SemanaMostrar";
			frm.cboSemana.ValueMember = "c_sequence_per";

			frm.cboSemana.DataSource = dt;

			SeleccionarSemanaActual(dt);
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
		public void CrearColumnasListado()
		{
			DataGridView dgv = frm.dgvListado;

			dgv.Columns.Clear();

			dgv.Columns.Add("Codigo", "Código");
			dgv.Columns.Add("Nombre", "Empleado");
			dgv.Columns.Add("LugarPago", "Lugar de Pago");

			// Código real para guardar en BD
			dgv.Columns.Add("IdLugarPago", "IdLugarPago");

			dgv.Columns["IdLugarPago"].Visible = false;
		}
		public void CargarEmpleadosCuadrilla(string idCuadrilla, string secuenciaSemana, DateTime fechaInicio, DateTime fechaFin)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"sp_GetEmployeeWeeklyList",
					sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(
						"@c_sequence_per",
						secuenciaSemana);

					cmd.Parameters.AddWithValue(
						"@d_startDate",
						fechaInicio.Date);

					cmd.Parameters.AddWithValue(
						"@d_endDate",
						fechaFin.Date);

					cmd.Parameters.AddWithValue(
						"@id_workGroup",
						idCuadrilla);

					using (SqlDataAdapter da =
						new SqlDataAdapter(cmd))
					{
						DataTable dt = new DataTable();

						da.Fill(dt);

						frm.dgvListado.Rows.Clear();

						foreach (DataRow row in dt.Rows)
						{
							frm.dgvListado.Rows.Add(
								row["id_employee"].ToString(),

								row["Empleado"].ToString(),

								row["LugarPago"] == DBNull.Value
									? ""
									: row["LugarPago"].ToString(),

								row["id_paymentPlace"] == DBNull.Value
									? ""
									: row["id_paymentPlace"].ToString()
							);
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Error al cargar empleados",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public bool EliminarEmpleadoCuadrilla(string idEmpleado,string idCuadrilla,string secuenciaSemana,DateTime fechaInicio,DateTime fechaFin)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				string query = @"
            DELETE FROM dbo.Nom_EmployeeAttendenceList
            WHERE id_employee = @idEmpleado
              AND id_workGroup = @idCuadrilla
              AND c_sequence_per = @secuenciaSemana
              AND d_startDate_per = @fechaInicio
              AND d_endDate_per = @fechaFin;
        ";

				int filasEliminadas;

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				{
					cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
					cmd.Parameters.AddWithValue("@idCuadrilla", idCuadrilla);
					cmd.Parameters.AddWithValue("@secuenciaSemana", secuenciaSemana);
					cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio.Date);
					cmd.Parameters.AddWithValue("@fechaFin", fechaFin.Date);

					filasEliminadas = cmd.ExecuteNonQuery();
				}

				if (filasEliminadas > 0)
				{
					string queryWeekly = @"
                DELETE FROM dbo.Nom_EmployeeAttendanceWeekly
                WHERE id_employee = @idEmpleado
                  AND c_sequence_per = @secuenciaSemana
                  AND d_startDate_per = @fechaInicio;
            ";

					using (SqlCommand cmdWeekly =
						new SqlCommand(queryWeekly, sql.cnn))
					{
						cmdWeekly.Parameters.AddWithValue("@idEmpleado", idEmpleado);
						cmdWeekly.Parameters.AddWithValue("@secuenciaSemana", secuenciaSemana);
						cmdWeekly.Parameters.AddWithValue("@fechaInicio", fechaInicio.Date);

						cmdWeekly.ExecuteNonQuery();
					}
				}

				return filasEliminadas > 0;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Error al quitar empleado",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return false;
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		
		public void ActualizarEmpleadosCuadrilla(string idCuadrilla,string secuenciaSemana,DateTime fechaInicio,DateTime fechaFin,DataGridView dgvEmpleados)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				using (SqlTransaction transaction = sql.cnn.BeginTransaction())
				{
					try
					{
						foreach (DataGridViewRow fila in dgvEmpleados.Rows)
						{
							if (fila.IsNewRow)
								continue;

							string codigo =
								fila.Cells["Codigo"].Value?.ToString()?.Trim();

							if (string.IsNullOrWhiteSpace(codigo))
								continue;

							// VALIDAR SI EL EMPLEADO YA ESTÁ EN LA CUADRILLA

							using (SqlCommand cmdExiste = new SqlCommand(@"
							SELECT COUNT(*)
							FROM dbo.Nom_EmployeeAttendenceList
							WHERE id_employee = @id_employee
							  AND id_workGroup = @id_workGroup",
								sql.cnn,
								transaction))
							{
								cmdExiste.Parameters.Add(
									"@id_employee",
									SqlDbType.Char,
									6).Value = codigo;

								cmdExiste.Parameters.Add(
									"@id_workGroup",
									SqlDbType.Char,
									3).Value = idCuadrilla;

								int existe =
									Convert.ToInt32(
										cmdExiste.ExecuteScalar());

								// Ya existe en esta cuadrilla
								if (existe > 0)
								{
									continue;
								}
							}

							// INSERTAR EMPLEADO

							using (SqlCommand cmd = new SqlCommand(
								"sp_AddEmployeeWeeklyList",
								sql.cnn,
								transaction))
							{
								cmd.CommandType =
									CommandType.StoredProcedure;

								cmd.Parameters.Add(
									"@c_sequence_per",
									SqlDbType.Char,
									2).Value =
									secuenciaSemana;

								cmd.Parameters.Add(
									"@d_startDate_per",
									SqlDbType.Date).Value =
									fechaInicio.Date;

								cmd.Parameters.Add(
									"@d_endDate_per",
									SqlDbType.Date).Value =
									fechaFin.Date;

								cmd.Parameters.Add(
									"@id_employee",
									SqlDbType.Char,
									6).Value =
									codigo;

								cmd.Parameters.Add(
									"@id_workGroup",
									SqlDbType.Char,
									3).Value =
									idCuadrilla;

								cmd.Parameters.Add(
									"@userCreate",
									SqlDbType.VarChar,
									100).Value =
									User.GetUserName();

								cmd.ExecuteNonQuery();
							}
						}

						transaction.Commit();

						MessageBox.Show(
							"Los empleados se guardaron correctamente.",
							"Lista semanal",
							MessageBoxButtons.OK,
							MessageBoxIcon.Information);
					}
					catch
					{
						transaction.Rollback();
						throw;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Error al guardar empleados",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public bool ExisteEmpleadoEnCuadrilla(string idEmpleado,string idCuadrilla,string secuenciaSemana,DateTime fechaInicio,DateTime fechaFin)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				string query = @"
				SELECT COUNT(*)
				FROM dbo.Nom_EmployeeAttendenceList
				WHERE id_employee = @id_employee
				  AND id_workGroup = @id_workGroup
				  AND c_sequence_per = @c_sequence_per
				  AND CAST(d_startDate_per AS DATE) = @d_startDate
				  AND CAST(d_endDate_per AS DATE) = @d_endDate";

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				{
					cmd.Parameters.Add(
						"@id_employee",
						SqlDbType.Char,
						6).Value = idEmpleado;

					cmd.Parameters.Add(
						"@id_workGroup",
						SqlDbType.Char,
						3).Value = idCuadrilla;

					cmd.Parameters.Add(
						"@c_sequence_per",
						SqlDbType.Char,
						2).Value = secuenciaSemana;

					cmd.Parameters.Add(
						"@d_startDate",
						SqlDbType.Date).Value = fechaInicio.Date;

					cmd.Parameters.Add(
						"@d_endDate",
						SqlDbType.Date).Value = fechaFin.Date;

					int cantidad =
						Convert.ToInt32(cmd.ExecuteScalar());

					return cantidad > 0;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al verificar el empleado:\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return false;
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public void ActualizarTotalEmpleados()
		{
			int total = frm.dgvListado.Rows.Count;

			frm.lblNumeroTotal.Text = total.ToString();
		}
		
		public void MostrarEmpleados()
		{
			int total = frm.dgvListado.Rows.Count;

			if (frm.dgvListado.AllowUserToAddRows)
				total--;

			if (total > 0)
			{
				// Hay empleados → quitar panel
				frm.pnlSinEmpleados.Visible = false;
			}
			else
			{
				// No hay empleados → mostrar panel
				frm.pnlSinEmpleados.Visible = true;
			}
		}
		public bool CopiarEmpleadosSemanaAnterior(string secuenciaSemanaAnterior, DateTime fechaInicioAnterior, DateTime fechaFinAnterior, string secuenciaSemanaNueva, DateTime fechaInicioNueva, DateTime fechaFinNueva)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"sp_CopyEmployeesFromPreviousWeek",
					sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(
						"@c_sequence_per_anterior",
						secuenciaSemanaAnterior);

					cmd.Parameters.AddWithValue(
						"@d_startDate_anterior",
						fechaInicioAnterior.Date);

					cmd.Parameters.AddWithValue(
						"@d_endDate_anterior",
						fechaFinAnterior.Date);

					cmd.Parameters.AddWithValue(
						"@c_sequence_per_nueva",
						secuenciaSemanaNueva);

					cmd.Parameters.AddWithValue(
						"@d_startDate_nueva",
						fechaInicioNueva.Date);

					cmd.Parameters.AddWithValue(
						"@d_endDate_nueva",
						fechaFinNueva.Date);

					cmd.Parameters.AddWithValue(
						"@userCreate",
						User.GetUserName());

					int resultado = Convert.ToInt32(
						cmd.ExecuteScalar());

					return resultado == 1;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Error al copiar empleados",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return false;
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public List<string> ObtenerCuadrillasSeleccionadas()
		{
			List<string> cuadrillas = new List<string>();

			foreach (DataGridViewRow fila in frm.dgvCuadrilla.Rows)
			{
				if (fila.IsNewRow)
					continue;

				bool seleccionada = Convert.ToBoolean(
					fila.Cells["Imprimir"].Value ?? false
				);

				if (seleccionada)
				{
					string idCuadrilla = fila.Cells["Codigo"].Value
						?.ToString();

					if (!string.IsNullOrWhiteSpace(idCuadrilla))
					{
						cuadrillas.Add(idCuadrilla);
					}
				}
			}

			return cuadrillas;
		}
		public DataTable ObtenerEmpleadosCuadrilla(
	string idCuadrilla,
	string idSemana)
		{
			SQLControl sql = new SQLControl();
			DataTable dt = new DataTable();

			string query = @"
			   SELECT
			A.id_workGroup,
			W.v_nameWorkGroup AS Cuadrilla,
			A.id_employee AS Codigo,

			CONCAT(
				E.v_lastNamePat, ' ',
				E.v_lastNameMat, ' ',
				E.v_name
			) AS Nom_Employee,

			A.c_sequence_per,
			A.d_startDate_per,
			A.d_endDate_per

		FROM dbo.Nom_EmployeeAttendenceList AS A

		INNER JOIN dbo.Nom_Employees AS E
			ON E.id_employee = A.id_employee

		INNER JOIN dbo.Nom_WorkGroup AS W
			ON W.id_workGroup = A.id_workGroup

		WHERE A.id_workGroup = @id_workGroup
		  AND A.c_sequence_per = @c_sequence_per

		ORDER BY
			E.v_lastNamePat,
			E.v_lastNameMat,
			E.v_name";

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				{
					cmd.CommandType = CommandType.Text;

					cmd.Parameters.AddWithValue(
						"@id_workGroup",
						idCuadrilla);

					cmd.Parameters.AddWithValue(
						"@c_sequence_per",
						idSemana);

					using (SqlDataAdapter da = new SqlDataAdapter(cmd))
					{
						da.Fill(dt);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Error al consultar empleados de la cuadrilla",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				sql.CloseConectionWrite();
			}

			return dt;
		}
		public MemoryStream GenerarPdfListasCuadrillas(List<string> cuadrillasSeleccionadas,string idSemana)
		{
			MemoryStream ms = new MemoryStream();

			iText.Kernel.Pdf.PdfWriter writer =
				new iText.Kernel.Pdf.PdfWriter(ms);

			writer.SetCloseStream(false);

			iText.Kernel.Pdf.PdfDocument pdf =
				new iText.Kernel.Pdf.PdfDocument(writer);

			pdf.SetDefaultPageSize(
				iText.Kernel.Geom.PageSize.LETTER);

			iText.Layout.Document document =
				new iText.Layout.Document(pdf);

			document.SetMargins(25, 25, 25, 25);

			bool primeraLista = true;

			foreach (string idCuadrilla in cuadrillasSeleccionadas)
			{
				DataTable dt =
					ObtenerEmpleadosCuadrilla(
						idCuadrilla,
						idSemana);

				if (dt.Rows.Count == 0)
					continue;

				// Espacio entre una lista y la siguiente
				if (!primeraLista)
				{
					document.Add(
						new iText.Layout.Element.Paragraph(" ")
							.SetMarginTop(8)
							.SetMarginBottom(8)
							.SetFontSize(5));
				}

				CrearPaginaAsistenciaCuadrilla(
					document,
					dt);

				primeraLista = false;
			}

			document.Close();

			ms.Position = 0;

			return ms;
		}
		private void CrearPaginaAsistenciaCuadrilla(iText.Layout.Document document,DataTable dt)
		{
			iText.Kernel.Colors.DeviceRgb colorHeader =
				new iText.Kernel.Colors.DeviceRgb(25, 35, 48);

			iText.Kernel.Colors.DeviceRgb colorBorde =
				new iText.Kernel.Colors.DeviceRgb(90, 90, 90);

			iText.Kernel.Colors.DeviceRgb colorAzul =
				new iText.Kernel.Colors.DeviceRgb(0, 102, 204);

			// ==========================================
			// TÍTULO
			// ==========================================

			iText.Layout.Element.Paragraph titulo =
				new iText.Layout.Element.Paragraph(
					"ASISTENCIA PARA REVISIÓN");

			titulo
				.SetFontSize(16)
				.SetTextAlignment(
					iText.Layout.Properties.TextAlignment.CENTER);

			document.Add(titulo);

			// ==========================================
			// INFORMACIÓN DE LA CUADRILLA
			// ==========================================

			string cuadrilla =
				dt.Rows[0]["id_workGroup"].ToString()
				+ " - "
				+ dt.Rows[0]["Cuadrilla"].ToString();

			string semana =
				dt.Rows[0]["c_sequence_per"].ToString();

			string fechaInicio =
				Convert.ToDateTime(
					dt.Rows[0]["d_startDate_per"])
				.ToString("dd/MM/yyyy");

			string fechaFin =
				Convert.ToDateTime(
					dt.Rows[0]["d_endDate_per"])
				.ToString("dd/MM/yyyy");

			iText.Layout.Element.Table info =
				new iText.Layout.Element.Table(
					iText.Layout.Properties.UnitValue
						.CreatePercentArray(
							new float[] { 1, 1 }))
				.UseAllAvailableWidth();

			info.AddCell(
				new iText.Layout.Element.Cell()
					.SetBorder(
						iText.Layout.Borders.Border.NO_BORDER)
					.Add(
						new iText.Layout.Element.Paragraph(
							"Cuadrilla: " + cuadrilla)
							.SetFontSize(9)));

			info.AddCell(
				new iText.Layout.Element.Cell()
					.SetBorder(
						iText.Layout.Borders.Border.NO_BORDER)
					.Add(
						new iText.Layout.Element.Paragraph(
							"Semana: " + semana)
							.SetFontSize(9)));

			document.Add(info);

			document.Add(
				new iText.Layout.Element.Paragraph(" ")
					.SetFontSize(3));

			// ==========================================
			// TABLA
			// ==========================================

			float[] anchos =
			{
				55,
				250,
				37,
				37,
				37,
				37,
				37,
				37,
				37
			};

			iText.Layout.Element.Table tabla =
				new iText.Layout.Element.Table(anchos);

			tabla.SetWidth(
				iText.Layout.Properties.UnitValue
					.CreatePercentValue(100));

			string[] encabezados =
			{
		"CÓDIGO",
		"EMPLEADO",
		"VIE",
		"SÁB",
		"DOM",
		"LUN",
		"MAR",
		"MIÉ",
		"JUE"
	};

			foreach (string encabezado in encabezados)
			{
				iText.Layout.Element.Cell celda =
					new iText.Layout.Element.Cell()
						.SetBackgroundColor(colorHeader)
						.SetFontColor(
							iText.Kernel.Colors.ColorConstants.WHITE)
						.SetTextAlignment(
							iText.Layout.Properties.TextAlignment.CENTER)
						.SetVerticalAlignment(
							iText.Layout.Properties.VerticalAlignment.MIDDLE)
						.SetPadding(3)
						.SetBorder(
							new iText.Layout.Borders.SolidBorder(
								colorBorde,
								0.5f));

				celda.Add(
					new iText.Layout.Element.Paragraph(
						encabezado)
						.SetFontSize(8));

				tabla.AddHeaderCell(celda);
			}

			// ==========================================
			// EMPLEADOS
			// ==========================================

			foreach (DataRow fila in dt.Rows)
			{
				string[] valores =
				{
				fila["Codigo"].ToString(),
				fila["Nom_Employee"].ToString(),
				"", // VIE
				"", // SÁB
				"", // DOM
				"", // LUN
				"", // MAR
				"", // MIÉ
				""  // JUE
			};

				for (int i = 0; i < valores.Length; i++)
				{
					iText.Layout.Element.Cell celda =
						new iText.Layout.Element.Cell()
							.SetPadding(3)
							.SetBorder(
								new iText.Layout.Borders.SolidBorder(
									colorBorde,
									0.5f))
							.SetVerticalAlignment(
								iText.Layout.Properties.VerticalAlignment.MIDDLE);

					if (i >= 2)
					{
						celda.SetTextAlignment(
							iText.Layout.Properties.TextAlignment.CENTER);
					}

					celda.Add(
						new iText.Layout.Element.Paragraph(
							valores[i])
							.SetFontSize(7));

					tabla.AddCell(celda);
				}
			}
			// ==========================================
			// FILAS VACÍAS
			// ==========================================

			for (int fila = 0; fila < 2; fila++)
			{
				for (int i = 0; i < 9; i++)
				{
					iText.Layout.Element.Cell celda =
						new iText.Layout.Element.Cell()
							.SetMinHeight(22)
							.SetPadding(3)
							.SetBorder(
								new iText.Layout.Borders.SolidBorder(
									colorBorde,
									0.5f));

					if (i >= 2)
					{
						celda.SetTextAlignment(
							iText.Layout.Properties.TextAlignment.CENTER);
					}

					celda.Add(
						new iText.Layout.Element.Paragraph(" ")
							.SetFontSize(7));

					tabla.AddCell(celda);
				}
			}

			document.Add(tabla);
		}
		public bool ExisteEmpleadosSemana(string secuenciaSemana,DateTime fechaInicio,DateTime fechaFin)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				string query = @"
            SELECT COUNT(*)
            FROM dbo.Nom_EmployeeAttendenceList
            WHERE c_sequence_per = @secuenciaSemana
              AND d_startDate_per = @fechaInicio
              AND d_endDate_per = @fechaFin ";

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				{
					cmd.Parameters.AddWithValue(
						"@secuenciaSemana",
						secuenciaSemana);

					cmd.Parameters.AddWithValue(
						"@fechaInicio",
						fechaInicio.Date);

					cmd.Parameters.AddWithValue(
						"@fechaFin",
						fechaFin.Date);

					int cantidad = Convert.ToInt32(
						cmd.ExecuteScalar());

					return cantidad > 0;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Error al verificar semana",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return false;
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public void btnCopiarDatosDeLaSemanaAnterior() 
		{
			if (frm.cboSemana.SelectedIndex < 0)
			{
				MessageBox.Show(
					"Seleccione una semana.",
					"Semana",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				return;
			}

			// Obtener semana seleccionada (DESTINO)
			if (!frm.ObtenerSemanaSeleccionada(
				out string secuenciaSemanaNueva,
				out DateTime fechaInicioNueva,
				out DateTime fechaFinNueva))
			{
				return;
			}

			// Obtener semana anterior
			int indiceSemanaAnterior =
				frm.cboSemana.SelectedIndex + 1;

			if (indiceSemanaAnterior >= frm.cboSemana.Items.Count)
			{
				MessageBox.Show(
					"No existe una semana anterior.",
					"Semana",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				return;
			}

			DataRowView semanaAnterior = frm.cboSemana.Items[indiceSemanaAnterior] as DataRowView;

			if (semanaAnterior == null)
			{
				MessageBox.Show(
					"No se pudo obtener la semana anterior.",
					"Semana",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			string secuenciaSemanaAnterior =
				semanaAnterior["c_sequence_per"]?.ToString();

			DateTime fechaInicioAnterior =
				Convert.ToDateTime(
					semanaAnterior["d_startDate_per"]);

			DateTime fechaFinAnterior =
				Convert.ToDateTime(
					semanaAnterior["d_endDate_per"]);


			// Verificar si la semana actual ya tiene empleados
			bool existeDatos = ExisteEmpleadosSemana(
				secuenciaSemanaNueva,
				fechaInicioNueva,
				fechaFinNueva);


			// Si ya tiene datos, pedir confirmación
			if (existeDatos)
			{
				DialogResult resultado = MessageBox.Show(
					"La semana seleccionada ya tiene empleados registrados.\n\n" +
					"¿Está seguro de volver a realizar la acción?\n\n" +
					"Esto copiará nuevamente TODOS los datos de la semana anterior " +
					"y se perderán los cambios que haya realizado en la semana actual.",
					"Actualizar semana",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Warning,
					MessageBoxDefaultButton.Button2);

				if (resultado != DialogResult.Yes)
				{
					return;
				}
			}


			// Copiar semana anterior → semana seleccionada
			bool copiado = CopiarEmpleadosSemanaAnterior(
				secuenciaSemanaAnterior,
				fechaInicioAnterior,
				fechaFinAnterior,
				secuenciaSemanaNueva,
				fechaInicioNueva,
				fechaFinNueva);


			if (copiado)
			{
				MessageBox.Show(
					"Los empleados de la semana anterior fueron copiados correctamente.",
					"Actualizar semana",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);


				// Mostrar la semana seleccionada
				if (frm.dgvCuadrilla.CurrentRow != null)
				{
					string idCuadrilla =
						frm.dgvCuadrilla.CurrentRow.Cells["Codigo"].Value?.ToString();

					CargarEmpleadosCuadrilla(
						idCuadrilla,
						secuenciaSemanaNueva,
						fechaInicioNueva,
						fechaFinNueva);

					ActualizarTotalEmpleados();
					MostrarEmpleados();
				}
			}
		}
		public void PrintDocument_PrintPage(
		object sender,
		PrintPageEventArgs e)
		{
			Graphics g = e.Graphics;

			// FUENTES

			using Font titulo = new Font(
				"Segoe UI",
				16,
				FontStyle.Bold);

			using Font subtitulo = new Font(
				"Segoe UI",
				10,
				FontStyle.Bold);

			using Font texto = new Font(
				"Segoe UI",
				9);

			// ÁREA REAL DE IMPRESIÓN

			int x = e.MarginBounds.Left;
			int y = e.MarginBounds.Top;

			int ancho = e.MarginBounds.Width;


			// TÍTULO

			g.DrawString(
				"LISTADO DE EMPLEADOS",
				titulo,
				Brushes.Black,
				x,
				y);

			y += 35;

			// Línea debajo del título

			g.DrawLine(
				Pens.Black,
				x,
				y,
				x + ancho,
				y);

			y += 25;


			// INFORMACIÓN

			g.DrawString(
				"Cuadrilla:",
				subtitulo,
				Brushes.Black,
				x,
				y);

			g.DrawString(
				frm.lblCuadrilla.Text,
				texto,
				Brushes.Black,
				x + 75,
				y);

			y += 20;

			g.DrawString(
				"Fecha:",
				subtitulo,
				Brushes.Black,
				x,
				y);

			g.DrawString(
				$"{FechaInicio:dd/MM/yyyy} - {FechaFin:dd/MM/yyyy}",
				texto,
				Brushes.Black,
				x + 75,
				y);

			y += 20;

			g.DrawString(
				"Total de empleados:",
				subtitulo,
				Brushes.Black,
				x,
				y);

			g.DrawString(
				frm.dgvListado.Rows
					.Cast<DataGridViewRow>()
					.Count(r => !r.IsNewRow)
					.ToString(),
				texto,
				Brushes.Black,
				x + 120,
				y);

			y += 30;

			// ANCHOS DE COLUMNAS

			int anchoCodigo = 80;
			int anchoEmpleado = 300;
			int anchoLugarPago =
				ancho - anchoCodigo - anchoEmpleado;

			// ENCABEZADO TABLA

			int altoEncabezado = 30;

			using (Brush fondoEncabezado =
				new SolidBrush(Color.FromArgb(47, 72, 132)))
			{
				g.FillRectangle(
					fondoEncabezado,
					x,
					y,
					ancho,
					altoEncabezado);
			}

			using Font fuenteEncabezado =
				new Font(
					"Segoe UI",
					9,
					FontStyle.Bold);

			Brush brushBlanco = Brushes.White;


			g.DrawString(
				"Código",
				fuenteEncabezado,
				brushBlanco,
				x + 12,
				y + 8);

			g.DrawString(
				"Empleado",
				fuenteEncabezado,
				brushBlanco,
				x + anchoCodigo + 12,
				y + 8);

			g.DrawString(
				"Lugar de Pago",
				fuenteEncabezado,
				brushBlanco,
				x + anchoCodigo +
				anchoEmpleado + 12,
				y + 8);

			y += altoEncabezado;

			// EMPLEADOS

			int altoFila = 32;

			while (filaImprimir < frm.dgvListado.Rows.Count)
			{
				DataGridViewRow fila =
					frm.dgvListado.Rows[filaImprimir];

				if (fila.IsNewRow)
				{
					filaImprimir++;
					continue;
				}

				string codigo =
					fila.Cells["Codigo"].Value?.ToString() ?? "";

				string empleado =
					fila.Cells["Nombre"].Value?.ToString() ?? "";

				string lugarPago =
					fila.Cells["LugarPago"].Value?.ToString() ?? "";


				// CAMBIO DE PÁGINA

				if (y + altoFila > e.MarginBounds.Bottom)
				{
					e.HasMorePages = true;
					return;
				}


				// FONDO ALTERNO

				if (filaImprimir % 2 == 1)
				{
					using Brush fondo =
						new SolidBrush(
							Color.FromArgb(247, 249, 253));

					g.FillRectangle(
						fondo,
						x,
						y,
						ancho,
						altoFila);
				}


				// LÍNEA INFERIOR

				using Pen linea =
					new Pen(
						Color.FromArgb(220, 220, 220));

				g.DrawLine(
					linea,
					x,
					y + altoFila,
					x + ancho,
					y + altoFila);


				// TEXTO

				int textoY = y + 9;

				g.DrawString(
					codigo,
					texto,
					Brushes.Black,
					x + 12,
					textoY);

				g.DrawString(
					empleado,
					texto,
					Brushes.Black,
					x + anchoCodigo + 12,
					textoY);

				g.DrawString(
					lugarPago,
					texto,
					Brushes.Black,
					x + anchoCodigo +
					anchoEmpleado + 12,
					textoY);


				y += altoFila;

				filaImprimir++;
			}


			// FIN

			e.HasMorePages = false;

			filaImprimir = 0;
		}

		public void EstiloDgvCuadrilla()
		{
			DataGridView dgv = frm.dgvCuadrilla;

			// CONFIGURACIÓN GENERAL
			dgv.BackgroundColor = Color.White;
			dgv.BorderStyle = BorderStyle.None;
			dgv.CellBorderStyle =
				DataGridViewCellBorderStyle.SingleHorizontal;

			dgv.GridColor =
				Color.FromArgb(225, 228, 235);

			dgv.EnableHeadersVisualStyles = false;

			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToResizeRows = false;
			dgv.AllowUserToResizeColumns = false;

			// Permitir edición para que funcione el CheckBox
			dgv.ReadOnly = false;

			dgv.RowHeadersVisible = false;

			dgv.SelectionMode =
				DataGridViewSelectionMode.FullRowSelect;

			dgv.MultiSelect = false;

			dgv.EditMode =
				DataGridViewEditMode.EditOnEnter;

			// ENCABEZADO
			dgv.ColumnHeadersDefaultCellStyle.BackColor =
				Color.FromArgb(42, 67, 128);

			dgv.ColumnHeadersDefaultCellStyle.ForeColor =
				Color.White;

			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor =
				Color.FromArgb(42, 67, 128);

			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor =
				Color.White;

			dgv.ColumnHeadersDefaultCellStyle.Font =
				new Font("Segoe UI", 8F, FontStyle.Bold);

			dgv.ColumnHeadersDefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.ColumnHeadersHeight = 26;

			// FILAS
			dgv.DefaultCellStyle.Font =
				new Font("Segoe UI", 8F);

			dgv.DefaultCellStyle.Padding =
				new Padding(1, 0, 1, 0);

			dgv.DefaultCellStyle.SelectionBackColor =
				Color.FromArgb(220, 229, 250);

			dgv.DefaultCellStyle.SelectionForeColor =
				Color.FromArgb(30, 45, 80);

			dgv.RowTemplate.Height = 20;

			dgv.AlternatingRowsDefaultCellStyle.BackColor =
				Color.FromArgb(247, 249, 253);

			dgv.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.Fill;

			// =====================================================
			// CHECKBOX - ÚNICA COLUMNA QUE SE PUEDE EDITAR
			// =====================================================

			if (dgv.Columns.Contains("Imprimir"))
			{
				dgv.Columns["Imprimir"].ReadOnly = false;

				dgv.Columns["Imprimir"].FillWeight = 35;

				dgv.Columns["Imprimir"].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleCenter;
			}

			// =====================================================
			// CÓDIGO - SOLO LECTURA
			// =====================================================

			if (dgv.Columns.Contains("Codigo"))
			{
				dgv.Columns["Codigo"].ReadOnly = true;

				dgv.Columns["Codigo"].FillWeight = 35;

				dgv.Columns["Codigo"].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleCenter;
			}

			// =====================================================
			// CUADRILLA - SOLO LECTURA
			// =====================================================

			if (dgv.Columns.Contains("Cuadrilla"))
			{
				dgv.Columns["Cuadrilla"].ReadOnly = true;

				dgv.Columns["Cuadrilla"].FillWeight = 75;

				dgv.Columns["Cuadrilla"].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleLeft;
			}
		}
		public void EstiloDgvListado()
		{
			DataGridView dgv = frm.dgvListado;

			// GENERAL

			dgv.BackgroundColor = Color.White;

			dgv.BorderStyle =
				BorderStyle.None;

			dgv.CellBorderStyle =
				DataGridViewCellBorderStyle.SingleHorizontal;

			dgv.GridColor =
				Color.FromArgb(225, 228, 235);

			dgv.EnableHeadersVisualStyles = false;

			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToResizeRows = false;
			dgv.AllowUserToResizeColumns = false;

			dgv.ReadOnly = true;


			// SELECCIÓN

			dgv.SelectionMode =
				DataGridViewSelectionMode.FullRowSelect;

			dgv.MultiSelect = true;

			dgv.AllowUserToAddRows = false;


			// ENCABEZADO

			dgv.ColumnHeadersDefaultCellStyle.BackColor =
				Color.FromArgb(42, 67, 128);

			dgv.ColumnHeadersDefaultCellStyle.ForeColor =
				Color.White;

			dgv.ColumnHeadersDefaultCellStyle.Font =
				new Font(
					"Segoe UI",
					9F,
					FontStyle.Bold);

			dgv.ColumnHeadersDefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.ColumnHeadersHeight = 36;

			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor =
				Color.FromArgb(42, 67, 128);

			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor =
				Color.White;


			// FILAS

			dgv.DefaultCellStyle.Font =
				new Font("Segoe UI", 9F);

			dgv.DefaultCellStyle.ForeColor =
				Color.FromArgb(45, 45, 55);

			dgv.DefaultCellStyle.BackColor =
				Color.White;


			// SELECCIÓN

			dgv.DefaultCellStyle.SelectionBackColor =
				Color.FromArgb(220, 229, 250);

			dgv.DefaultCellStyle.SelectionForeColor =
				Color.FromArgb(30, 45, 80);

			dgv.DefaultCellStyle.Padding =
				new Padding(6, 0, 6, 0);

			dgv.RowTemplate.Height = 32;


			// ALTERNADAS

			dgv.AlternatingRowsDefaultCellStyle.BackColor =
				Color.FromArgb(247, 249, 253);

			// COLUMNAS

			dgv.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.Fill;

			dgv.Columns["Codigo"].FillWeight = 15;

			dgv.Columns["Nombre"].FillWeight = 50;

			dgv.Columns["LugarPago"].FillWeight = 35;

			// ALINEACIÓN

			dgv.Columns["Codigo"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.Columns["Nombre"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleLeft;

			dgv.Columns["LugarPago"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleLeft;
		}
	}
}
