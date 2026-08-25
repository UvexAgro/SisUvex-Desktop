using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
		public int IdCuadrilla { get; set; }
		public DateTime Fecha { get; set; }
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
					v_nameWorkGroup AS [Nombre de Cuadrilla]
				FROM Nom_WorkGroup
				WHERE c_active = 1
				ORDER BY id_workGroup";

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				using (SqlDataAdapter da = new SqlDataAdapter(cmd))
				{
					da.Fill(dt);
				}

				frm.dgvCuadrilla.DataSource = dt;
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
		public void CrearColumnasListado()
		{
			DataGridView dgv = frm.dgvListado;

			dgv.Columns.Clear();

			dgv.Columns.Add("Codigo", "Código");
			dgv.Columns.Add("Nombre", "Empleado");
			dgv.Columns.Add("LugarPago", "Lugar de Pago");
			dgv.Columns.Add("Actividad", "Actividad");

			// Códigos reales para guardar en BD
			dgv.Columns.Add("IdLugarPago", "IdLugarPago");
			dgv.Columns.Add("IdActividad", "IdActividad");

			dgv.Columns["IdLugarPago"].Visible = false;
			dgv.Columns["IdActividad"].Visible = false;
		}
		public void CargarEmpleadosCuadrilla(int idCuadrilla, DateTime fecha)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				string query = @"
			SELECT
				D.id_employee,

				E.v_name + ' ' +
				E.v_lastNamePat + ' ' +
				E.v_lastNameMat AS Empleado,

				D.id_paymentPlace,

				CONVERT(varchar(20), D.id_paymentPlace) +
				' - ' +
				P.v_namePlace AS LugarPago,

				D.id_activity,

				T.c_codigo_tab + ' - ' +
				T.v_descripcion_tab AS Actividad

			FROM dbo.Nom_WorkGroupEmployeeDaily D

			INNER JOIN dbo.Nom_Employees E
				ON E.id_employee = D.id_employee

			LEFT JOIN dbo.Nom_PlacePayment P
				ON P.id_placePayment = D.id_paymentPlace

			LEFT JOIN dbo.Nom_Tabulador T
				ON T.c_codigo_tab = D.id_activity

			WHERE D.d_date = @fecha
			  AND D.id_workGroup = @idCuadrilla

			ORDER BY
				E.v_name,
				E.v_lastNamePat;";

				using (SqlCommand cmd =
					new SqlCommand(query, sql.cnn))
				{
					cmd.Parameters.AddWithValue(
						"@fecha",
						fecha.Date);

					cmd.Parameters.AddWithValue(
						"@idCuadrilla",
						idCuadrilla);

					using (SqlDataAdapter da =
						new SqlDataAdapter(cmd))
					{
						DataTable dt = new DataTable();

						da.Fill(dt);

						frm.dgvListado.Rows.Clear();

						foreach (DataRow row in dt.Rows)
						{
							int indice = frm.dgvListado.Rows.Add(
								row["id_employee"].ToString(),
								row["Empleado"].ToString(),
								row["LugarPago"] == DBNull.Value
									? ""
									: row["LugarPago"].ToString(),
								row["Actividad"] == DBNull.Value
									? ""
									: row["Actividad"].ToString(),
								row["id_paymentPlace"] == DBNull.Value
									? ""
									: row["id_paymentPlace"].ToString(),
								row["id_activity"] == DBNull.Value
									? ""
									: row["id_activity"].ToString()
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
		public bool EliminarEmpleadoCuadrilla(int idEmpleado, int idCuadrilla, DateTime fecha)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				string query = @"
			DELETE FROM dbo.Nom_WorkGroupEmployeeDaily
			WHERE id_employee = @idEmpleado
			  AND id_workGroup = @idCuadrilla
			  AND d_date = @fecha;";

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				{
					cmd.Parameters.AddWithValue(
						"@idEmpleado",
						idEmpleado);

					cmd.Parameters.AddWithValue(
						"@idCuadrilla",
						idCuadrilla);

					cmd.Parameters.AddWithValue(
						"@fecha",
						fecha.Date);

					int filasAfectadas = cmd.ExecuteNonQuery();

					return filasAfectadas > 0;
				}
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
		private void FrmA_Shown(object sender, EventArgs e)
		{
			CargarEmpleadoModificar();

			// Evita que el evento se ejecute nuevamente
			frmA.Shown -= FrmA_Shown;
		}
		public void OpenFrmModify(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				MessageBox.Show(
					"Seleccione un empleado.",
					"Modificar empleado",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				return;
			}

			IsAddOrModify = false;
			idAddModify = id;

			frmA = new FrmAgregar();

			frmA.cls = this;

			frmA.Text = "Modificar empleado";
			frmA.lblTitulo.Text = "MODIFICAR EMPLEADO";
			frmA.lblSubtitulo.Text =
				"Modifica la información del empleado";

			frmA.IdCuadrilla = IdCuadrilla;
			frmA.Fecha = Fecha;

			// MUY IMPORTANTE
			frmA.ModoModificar = true;

			// Conectar el evento
			frmA.Shown += FrmA_Shown;

			frmA.ShowDialog();
		}
		public void CargarEmpleadoModificar()
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				string query = @"
		SELECT
			D.id_employee,

			E.v_name + ' ' +
			E.v_lastNamePat + ' ' +
			E.v_lastNameMat AS Empleado,

			D.id_paymentPlace,

			CONVERT(varchar(20), D.id_paymentPlace)
			+ ' - ' +
			P.v_namePlace AS LugarPago,

			D.id_activity,

			T.c_codigo_tab + ' - ' +
			T.v_descripcion_tab AS Actividad

		FROM dbo.Nom_WorkGroupEmployeeDaily D

		INNER JOIN dbo.Nom_Employees E
			ON E.id_employee = D.id_employee

		LEFT JOIN dbo.Nom_PlacePayment P
			ON P.id_placePayment = D.id_paymentPlace

		LEFT JOIN dbo.Nom_Tabulador T
			ON T.c_codigo_tab = D.id_activity

		WHERE D.id_employee = @idEmpleado
		  AND D.id_workGroup = @idCuadrilla
		  AND D.d_date = @fecha;";

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				{
					cmd.Parameters.AddWithValue(
						"@idEmpleado",
						idAddModify);

					cmd.Parameters.AddWithValue(
						"@idCuadrilla",
						frmA.IdCuadrilla);

					cmd.Parameters.AddWithValue(
						"@fecha",
						frmA.Fecha.Date);

					using (SqlDataReader dr = cmd.ExecuteReader())
					{
						if (!dr.Read())
						{
							MessageBox.Show(
								"No se encontró el empleado en la cuadrilla.",
								"Empleado",
								MessageBoxButtons.OK,
								MessageBoxIcon.Information);

							return;
						}

						// =========================
						// CÓDIGO
						// =========================

						frmA.txbCodigo.Text =
							dr["id_employee"].ToString();


						// =========================
						// NOMBRE
						// =========================

						frmA.txbEmpleado.Text =
							dr["Empleado"].ToString();


						// =========================
						// LUGAR DE PAGO
						// =========================

						if (dr["id_paymentPlace"] != DBNull.Value)
						{
							int idLugarPago =
								Convert.ToInt32(dr["id_paymentPlace"]);

							for (int i = 0; i < frmA.cboLugarPago.Items.Count; i++)
							{
								DataRowView item =
									frmA.cboLugarPago.Items[i] as DataRowView;

								if (item != null &&
									Convert.ToInt32(item["IdLugarPago"]) == idLugarPago)
								{
									frmA.cboLugarPago.SelectedIndex = i;
									break;
								}
							}
						}


						// =========================
						// ACTIVIDAD
						// =========================

						if (dr["id_activity"] != DBNull.Value)
						{
							int idActividad =
								Convert.ToInt32(dr["id_activity"]);

							frmA.cboActividad.SelectedValue =
								idActividad;
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Error al cargar empleado",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public void ActualizarEmpleadosCuadrilla(int idCuadrilla, DateTime fecha, DataGridView dgvEmpleados)
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
								fila.Cells["Codigo"].Value?.ToString();

							if (string.IsNullOrWhiteSpace(codigo))
								continue;


							// -----------------------------------------
							// OBTENER IDs REALES DEL DGV
							// -----------------------------------------

							string idLugarPago =
								fila.Cells["IdLugarPago"].Value?.ToString();

							string idActividad =
								fila.Cells["IdActividad"].Value?.ToString();


							// -----------------------------------------
							// FORMATO LUGAR DE PAGO
							// -----------------------------------------

							if (!string.IsNullOrWhiteSpace(idLugarPago))
							{
								idLugarPago =
									idLugarPago.PadLeft(4, '0');
							}


							// -----------------------------------------
							// VALIDAR
							// -----------------------------------------

							if (string.IsNullOrWhiteSpace(idLugarPago))
							{
								MessageBox.Show(
									"El lugar de pago del empleado " +
									codigo +
									" no tiene un código válido.",
									"Actualizar",
									MessageBoxButtons.OK,
									MessageBoxIcon.Warning);

								transaction.Rollback();
								return;
							}

							if (string.IsNullOrWhiteSpace(idActividad))
							{
								MessageBox.Show(
									"La actividad del empleado " +
									codigo +
									" no tiene un código válido.",
									"Actualizar",
									MessageBoxButtons.OK,
									MessageBoxIcon.Warning);

								transaction.Rollback();
								return;
							}


							// -----------------------------------------
							// BUSCAR AL EMPLEADO ESE DÍA
							// SIN IMPORTAR LA CUADRILLA
							// -----------------------------------------

							string queryEmpleado = @"
                        SELECT
                            id_workGroup,
                            id_paymentPlace,
                            id_activity
                        FROM dbo.Nom_WorkGroupEmployeeDaily
                        WHERE d_date = @fecha
                          AND id_employee = @id_employee";


							int existeCuadrilla = 0;
							string lugarPagoAnterior = "";
							string actividadAnterior = "";

							using (SqlCommand cmd =
								new SqlCommand(
									queryEmpleado,
									sql.cnn,
									transaction))
							{
								cmd.Parameters.AddWithValue(
									"@fecha",
									fecha.Date);

								cmd.Parameters.AddWithValue(
									"@id_employee",
									codigo);

								using (SqlDataReader reader =
									cmd.ExecuteReader())
								{
									if (reader.Read())
									{
										existeCuadrilla =
											Convert.ToInt32(
												reader["id_workGroup"]);

										lugarPagoAnterior =
											reader["id_paymentPlace"] == DBNull.Value
												? ""
												: reader["id_paymentPlace"].ToString();

										actividadAnterior =
											reader["id_activity"] == DBNull.Value
												? ""
												: reader["id_activity"].ToString();
									}
								}
							}


							// =========================================
							// NO EXISTE → INSERTAR
							// =========================================

							if (existeCuadrilla == 0)
							{
								string queryInsert = @"
                            INSERT INTO dbo.Nom_WorkGroupEmployeeDaily
                            (
                                d_date,
                                id_employee,
                                id_paymentPlace,
                                id_workGroup,
                                id_activity,
                                d_create,
                                userCreate
                            )
                            VALUES
                            (
                                @fecha,
                                @id_employee,
                                @id_paymentPlace,
                                @id_workGroup,
                                @id_activity,
                                GETDATE(),
                                @userCreate
                            )";

								using (SqlCommand cmdInsert =
									new SqlCommand(
										queryInsert,
										sql.cnn,
										transaction))
								{
									cmdInsert.Parameters.AddWithValue(
										"@fecha",
										fecha.Date);

									cmdInsert.Parameters.AddWithValue(
										"@id_employee",
										codigo);

									cmdInsert.Parameters.AddWithValue(
										"@id_paymentPlace",
										idLugarPago);

									cmdInsert.Parameters.AddWithValue(
										"@id_workGroup",
										idCuadrilla);

									cmdInsert.Parameters.AddWithValue(
										"@id_activity",
										idActividad);

									cmdInsert.Parameters.AddWithValue(
										"@userCreate",
										User.GetUserName());

									cmdInsert.ExecuteNonQuery();
								}

								continue;
							}


							// =========================================
							// YA EXISTE EN OTRA CUADRILLA
							// =========================================

							if (existeCuadrilla != idCuadrilla)
							{
								DialogResult respuesta =
									MessageBox.Show(
										"El empleado " + codigo +
										" ya pertenece a otra cuadrilla " +
										"el día " +
										fecha.ToString("dd/MM/yyyy") +
										".\n\n" +
										"¿Desea cambiarlo a la cuadrilla actual?",

										"Empleado en otra cuadrilla",

										MessageBoxButtons.YesNo,
										MessageBoxIcon.Question);


								if (respuesta == DialogResult.No)
								{
									continue;
								}


								// -------------------------------------
								// CAMBIAR DE CUADRILLA
								// -------------------------------------

								string queryMover = @"
                            UPDATE dbo.Nom_WorkGroupEmployeeDaily
                            SET
                                id_workGroup = @id_workGroup,
                                id_paymentPlace = @id_paymentPlace,
                                id_activity = @id_activity,
                                d_update = GETDATE(),
                                userUpdate = @userUpdate
                            WHERE d_date = @fecha
                              AND id_employee = @id_employee";


								using (SqlCommand cmd =
									new SqlCommand(
										queryMover,
										sql.cnn,
										transaction))
								{
									cmd.Parameters.AddWithValue(
										"@id_workGroup",
										idCuadrilla);

									cmd.Parameters.AddWithValue(
										"@id_paymentPlace",
										idLugarPago);

									cmd.Parameters.AddWithValue(
										"@id_activity",
										idActividad);

									cmd.Parameters.AddWithValue(
										"@userUpdate",
										User.GetUserName());

									cmd.Parameters.AddWithValue(
										"@fecha",
										fecha.Date);

									cmd.Parameters.AddWithValue(
										"@id_employee",
										codigo);

									cmd.ExecuteNonQuery();
								}

								continue;
							}


							// =========================================
							// MISMA CUADRILLA
							// =========================================

							lugarPagoAnterior =
								lugarPagoAnterior.PadLeft(4, '0');


							bool cambioLugarPago =
								lugarPagoAnterior != idLugarPago;

							bool cambioActividad =
								actividadAnterior != idActividad;


							// =========================================
							// ¿CAMBIÓ INFORMACIÓN?
							// =========================================

							if (cambioLugarPago || cambioActividad)
							{
								string mensaje =
									"El empleado " + codigo +
									" ya pertenece a esta cuadrilla.\n\n";

								if (cambioLugarPago)
								{
									mensaje +=
										"Lugar de pago anterior: " +
										lugarPagoAnterior +
										"\nNuevo lugar de pago: " +
										idLugarPago +
										"\n\n";
								}

								if (cambioActividad)
								{
									mensaje +=
										"Actividad anterior: " +
										actividadAnterior +
										"\nNueva actividad: " +
										idActividad +
										"\n\n";
								}

								mensaje +=
									"¿Desea actualizar los datos?";


								DialogResult respuesta =
									MessageBox.Show(
										mensaje,
										"Cambio de información",
										MessageBoxButtons.YesNo,
										MessageBoxIcon.Question);


								if (respuesta == DialogResult.No)
								{
									continue;
								}
							}


							// =========================================
							// ACTUALIZAR
							// =========================================

							string queryUpdate = @"
                        UPDATE dbo.Nom_WorkGroupEmployeeDaily
                        SET
                            id_paymentPlace = @id_paymentPlace,
                            id_activity = @id_activity,
                            d_update = GETDATE(),
                            userUpdate = @userUpdate
                        WHERE d_date = @fecha
                          AND id_employee = @id_employee
                          AND id_workGroup = @id_workGroup";


							using (SqlCommand cmdUpdate =
								new SqlCommand(
									queryUpdate,
									sql.cnn,
									transaction))
							{
								cmdUpdate.Parameters.AddWithValue(
									"@id_paymentPlace",
									idLugarPago);

								cmdUpdate.Parameters.AddWithValue(
									"@id_activity",
									idActividad);

								cmdUpdate.Parameters.AddWithValue(
									"@userUpdate",
									User.GetUserName());

								cmdUpdate.Parameters.AddWithValue(
									"@fecha",
									fecha.Date);

								cmdUpdate.Parameters.AddWithValue(
									"@id_employee",
									codigo);

								cmdUpdate.Parameters.AddWithValue(
									"@id_workGroup",
									idCuadrilla);

								cmdUpdate.ExecuteNonQuery();
							}
						}


						transaction.Commit();


						MessageBox.Show(
							"Los empleados se guardaron correctamente.",
							"Actualizar",
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
		public void ActualizarTotalEmpleados()
		{
			int total = frm.dgvListado.Rows.Count;

			frm.lblNumeroTotal.Text = total.ToString();
		}
		public void ImprimirListado()
		{
			filaImprimir = 0;

			using (PrintPreviewDialog preview =
				new PrintPreviewDialog())
			{
				preview.Document = printDocument;

				preview.Width = 1000;
				preview.Height = 700;

				preview.ShowDialog();
			}
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
		public void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
		{
			Graphics g = e.Graphics;

			// -----------------------------------------
			// FUENTES
			// -----------------------------------------

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

			// -----------------------------------------
			// ÁREA REAL DE IMPRESIÓN
			// -----------------------------------------

			int x = e.MarginBounds.Left;
			int y = e.MarginBounds.Top;

			int ancho = e.MarginBounds.Width;

			// -----------------------------------------
			// TÍTULO
			// -----------------------------------------

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

			// -----------------------------------------
			// INFORMACIÓN
			// -----------------------------------------

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
				frm.dtpFecha.Value.ToString("dd/MM/yyyy"),
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

			// -----------------------------------------
			// ANCHOS DE COLUMNAS
			// -----------------------------------------

			int anchoCodigo = 90;
			int anchoEmpleado = 320;
			int anchoLugarPago = 300;

			// El resto se lo damos a actividad

			int anchoActividad =
				ancho -
				anchoCodigo -
				anchoEmpleado -
				anchoLugarPago;

			// -----------------------------------------
			// ENCABEZADO TABLA
			// -----------------------------------------

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
				new Font("Segoe UI", 9, FontStyle.Bold);

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
				x + anchoCodigo + anchoEmpleado + 12,
				y + 8);

			g.DrawString(
				"Actividad",
				fuenteEncabezado,
				brushBlanco,
				x + anchoCodigo +
				anchoEmpleado +
				anchoLugarPago + 12,
				y + 8);

			y += altoEncabezado;

			// -----------------------------------------
			// EMPLEADOS
			// -----------------------------------------

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

				string actividad =
					fila.Cells["Actividad"].Value?.ToString() ?? "";

				// -----------------------------------------
				// CAMBIO DE PÁGINA
				// -----------------------------------------

				if (y + altoFila > e.MarginBounds.Bottom)
				{
					e.HasMorePages = true;
					return;
				}

				// -----------------------------------------
				// FONDO ALTERNO
				// -----------------------------------------

				if (filaImprimir % 2 == 1)
				{
					using Brush fondo =
						new SolidBrush(Color.FromArgb(247, 249, 253));

					g.FillRectangle(
						fondo,
						x,
						y,
						ancho,
						altoFila);
				}

				// -----------------------------------------
				// LÍNEA INFERIOR
				// -----------------------------------------

				using Pen linea =
					new Pen(Color.FromArgb(220, 220, 220));

				g.DrawLine(
					linea,
					x,
					y + altoFila,
					x + ancho,
					y + altoFila);

				// -----------------------------------------
				// TEXTO
				// -----------------------------------------

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

				g.DrawString(
					actividad,
					texto,
					Brushes.Black,
					x + anchoCodigo +
					anchoEmpleado +
					anchoLugarPago + 12,
					textoY);

				y += altoFila;

				filaImprimir++;
			}

			// -----------------------------------------
			// FIN
			// -----------------------------------------

			e.HasMorePages = false;

			filaImprimir = 0;
		}

		public void EstiloDgvCuadrilla()
		{
			DataGridView dgv = frm.dgvCuadrilla;

			// GENERAL
			dgv.BackgroundColor = Color.White;
			dgv.BorderStyle = BorderStyle.None;
			dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
			dgv.GridColor = Color.FromArgb(225, 228, 235);

			dgv.EnableHeadersVisualStyles = false;

			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToResizeRows = false;
			dgv.AllowUserToResizeColumns = false;

			dgv.ReadOnly = true;

			dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgv.MultiSelect = false;

			dgv.RowHeadersVisible = false;

			// ENCABEZADO
			dgv.ColumnHeadersDefaultCellStyle.BackColor =
				Color.FromArgb(42, 67, 128);

			dgv.ColumnHeadersDefaultCellStyle.ForeColor =
				Color.White;

			dgv.ColumnHeadersDefaultCellStyle.Font =
				new Font("Segoe UI", 9F, FontStyle.Bold);

			dgv.ColumnHeadersDefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleLeft;

			dgv.ColumnHeadersHeight = 34;

			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(42, 67, 128);

			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor =
				Color.White;

			// FILAS
			dgv.DefaultCellStyle.Font =
				new Font("Segoe UI", 9F);

			dgv.DefaultCellStyle.ForeColor =
				Color.FromArgb(45, 45, 55);

			dgv.DefaultCellStyle.BackColor =
				Color.White;

			// SELECCIONADA
			dgv.DefaultCellStyle.SelectionBackColor =
				Color.FromArgb(220, 229, 250);

			dgv.DefaultCellStyle.SelectionForeColor =
				Color.FromArgb(30, 45, 80);

			dgv.DefaultCellStyle.Padding =
				new Padding(5, 0, 5, 0);

			dgv.RowTemplate.Height = 30;

			// ALTERNADAS
			dgv.AlternatingRowsDefaultCellStyle.BackColor =
				Color.FromArgb(247, 249, 253);

			// -----------------------------
			// COLUMNAS
			// -----------------------------
			dgv.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.Fill;

			dgv.Columns[0].FillWeight = 25; // Código
			dgv.Columns[1].FillWeight = 75; // Nombre

			// -----------------------------
			// ALINEACIÓN
			// -----------------------------
			dgv.Columns[0].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.Columns[1].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleLeft;
		}
		public void EstiloDgvListado()
		{
			DataGridView dgv = frm.dgvListado;

			// GENERAL
			dgv.BackgroundColor = Color.White;
			dgv.BorderStyle = BorderStyle.None;

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

			dgv.RowHeadersVisible = false;

			// ENCABEZADO
			dgv.ColumnHeadersDefaultCellStyle.BackColor =
				Color.FromArgb(42, 67, 128);

			dgv.ColumnHeadersDefaultCellStyle.ForeColor =
				Color.White;

			dgv.ColumnHeadersDefaultCellStyle.Font =
				new Font("Segoe UI", 9F, FontStyle.Bold);

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
			dgv.Columns["Nombre"].FillWeight = 40;
			dgv.Columns["LugarPago"].FillWeight = 25;
			dgv.Columns["Actividad"].FillWeight = 25;

			dgv.Columns["Codigo"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.Columns["Nombre"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleLeft;

			dgv.Columns["LugarPago"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleLeft;

			dgv.Columns["Actividad"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleLeft;
		}
	}
}
