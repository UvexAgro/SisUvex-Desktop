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
		public string IdCuadrilla { get; set; }
		public DateTime Fecha { get; set; }
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
			dgv.Columns.Add("Lote", "Lote");

			// Códigos reales para guardar en BD
			dgv.Columns.Add("IdLugarPago", "IdLugarPago");
			dgv.Columns.Add("IdActividad", "IdActividad");
			dgv.Columns.Add("IdLote", "IdLote");

			dgv.Columns["IdLugarPago"].Visible = false;
			dgv.Columns["IdActividad"].Visible = false;
			dgv.Columns["IdLote"].Visible = false;
		}
		public void CargarEmpleadosCuadrilla(string idCuadrilla,DateTime fecha)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();


				using (SqlCommand cmd = new SqlCommand(
				"sp_GetEmpleadosCuadrilla",sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(
						"@fecha",
						fecha.Date);

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

								row["Actividad"] == DBNull.Value
									? ""
									: row["Actividad"].ToString(),

								row["Lote"] == DBNull.Value
									? ""
									: row["Lote"].ToString(),

								row["id_paymentPlace"] == DBNull.Value
									? ""
									: row["id_paymentPlace"].ToString(),

								row["id_activity"] == DBNull.Value
									? ""
									: row["id_activity"].ToString(),

								row["id_lot"] == DBNull.Value
									? ""
									: row["id_lot"].ToString()
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
		public bool EliminarEmpleadoCuadrilla(string idEmpleado,string idCuadrilla,DateTime fecha)
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

				using (SqlCommand cmd = new SqlCommand(
					"sp_GetEmpleadoCuadrillaModificar",
					sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

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

						frmA.txbCodigo.Text =
							dr["id_employee"].ToString();

						frmA.txbEmpleado.Text =
							dr["Empleado"].ToString();

						if (dr["id_activity"] != DBNull.Value)
						{
							frmA.cboActividad.SelectedValue =
								Convert.ToInt32(dr["id_activity"]);
						}

						if (dr["id_lot"] != DBNull.Value)
						{
							frmA.cboLote.SelectedValue =
								Convert.ToInt32(dr["id_lot"]);
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
		public void ActualizarEmpleadosCuadrilla(string idCuadrilla,DateTime fecha,DataGridView dgvEmpleados)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				using (SqlTransaction transaction =
					sql.cnn.BeginTransaction())
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

							string idActividad =
								fila.Cells["IdActividad"].Value?.ToString();

							string idLote =
								fila.Cells["IdLote"].Value?.ToString();

							if (string.IsNullOrWhiteSpace(idActividad))
							{
								MessageBox.Show(
									"La actividad del empleado " + codigo +
									" no tiene un código válido.",
									"Actualizar",
									MessageBoxButtons.OK,
									MessageBoxIcon.Warning);

								transaction.Rollback();
								return;
							}

							if (string.IsNullOrWhiteSpace(idLote))
							{
								MessageBox.Show(
									"El lote del empleado " + codigo +
									" no tiene un código válido.",
									"Lote",
									MessageBoxButtons.OK,
									MessageBoxIcon.Warning);

								transaction.Rollback();
								return;
							}

							// =========================================
							// CONSULTAR EMPLEADO
							// =========================================

							string cuadrillaAnterior = "";
							string actividadAnterior = "";
							string loteAnterior = "";

							using (SqlCommand cmd = new SqlCommand(
								"sp_GetEmpleadoWorkGroupDaily",
								sql.cnn,
								transaction))
							{
								cmd.CommandType =
									CommandType.StoredProcedure;

								cmd.Parameters.AddWithValue(
									"@id_employee",
									codigo);

								cmd.Parameters.AddWithValue(
									"@fecha",
									fecha.Date);

								using (SqlDataReader reader =
									cmd.ExecuteReader())
								{
									if (reader.Read())
									{
										if (reader["id_workGroup"] != DBNull.Value)
										{
											cuadrillaAnterior =
												reader["id_workGroup"].ToString();
										}

										if (reader["id_activity"] != DBNull.Value)
										{
											actividadAnterior =
												reader["id_activity"].ToString();
										}

										if (reader["id_lot"] != DBNull.Value)
										{
											loteAnterior =
												reader["id_lot"].ToString();
										}
									}
								}
							}

							// =========================================
							// NO EXISTE → INSERTAR
							// =========================================

							if (string.IsNullOrWhiteSpace(cuadrillaAnterior))
							{
								using (SqlCommand cmd = new SqlCommand(
									"sp_AddEmpleadoWorkGroupDaily",
									sql.cnn,
									transaction))
								{
									cmd.CommandType =
										CommandType.StoredProcedure;

									cmd.Parameters.AddWithValue(
										"@fecha",
										fecha.Date);

									cmd.Parameters.AddWithValue(
										"@id_employee",
										codigo);

									cmd.Parameters.AddWithValue(
										"@id_workGroup",
										idCuadrilla);

									cmd.Parameters.AddWithValue(
										"@id_activity",
										idActividad);

									cmd.Parameters.AddWithValue(
										"@id_lot",
										idLote);

									cmd.Parameters.AddWithValue(
										"@userCreate",
										User.GetUserName());

									cmd.ExecuteNonQuery();
								}

								continue;
							}

							// =========================================
							// OTRA CUADRILLA
							// =========================================

							if (cuadrillaAnterior != idCuadrilla)
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
									continue;

								using (SqlCommand cmd = new SqlCommand(
									"sp_MoverEmpleadoWorkGroupDaily",
									sql.cnn,
									transaction))
								{
									cmd.CommandType =
										CommandType.StoredProcedure;

									cmd.Parameters.AddWithValue(
										"@fecha",
										fecha.Date);

									cmd.Parameters.AddWithValue(
										"@id_employee",
										codigo);

									cmd.Parameters.AddWithValue(
										"@id_workGroup",
										idCuadrilla);

									cmd.Parameters.AddWithValue(
										"@id_activity",
										idActividad);

									cmd.Parameters.AddWithValue(
										"@id_lot",
										idLote);

									cmd.Parameters.AddWithValue(
										"@userUpdate",
										User.GetUserName());

									cmd.ExecuteNonQuery();
								}

								continue;
							}

							// =========================================
							// MISMA CUADRILLA
							// =========================================

							bool cambioActividad =
								actividadAnterior != idActividad;

							bool cambioLote =
								loteAnterior != idLote;

							if (cambioActividad || cambioLote)
							{
								string mensaje =
									"El empleado " + codigo +
									" ya pertenece a esta cuadrilla.\n\n";

								if (cambioActividad)
								{
									mensaje +=
										"Actividad anterior: " +
										actividadAnterior +
										"\nNueva actividad: " +
										idActividad +
										"\n\n";
								}

								if (cambioLote)
								{
									mensaje +=
										"Lote anterior: " +
										loteAnterior +
										"\nNuevo lote: " +
										idLote +
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
									continue;
							}

							// =========================================
							// ACTUALIZAR
							// =========================================

							using (SqlCommand cmd = new SqlCommand(
								"sp_UpdateEmpleadoWorkGroupDaily",
								sql.cnn,
								transaction))
							{
								cmd.CommandType =
									CommandType.StoredProcedure;

								cmd.Parameters.AddWithValue(
									"@fecha",
									fecha.Date);

								cmd.Parameters.AddWithValue(
									"@id_employee",
									codigo);

								cmd.Parameters.AddWithValue(
									"@id_workGroup",
									idCuadrilla);

								cmd.Parameters.AddWithValue(
									"@id_activity",
									idActividad);

								cmd.Parameters.AddWithValue(
									"@id_lot",
									idLote);

								cmd.Parameters.AddWithValue(
									"@userUpdate",
									User.GetUserName());

								cmd.ExecuteNonQuery();
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
		public bool ActualizarCuadrillas(DateTime fechaActual)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(
					"sp_ActualizarCuadrillasDia",
					sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@FechaActual", fechaActual.Date);
					cmd.Parameters.AddWithValue("@Usuario", User.GetUserName());

					cmd.ExecuteNonQuery();
				}

				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Error al actualizar cuadrillas",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return false;
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public bool ExistenEmpleadosFecha(DateTime fecha)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				string query = @"
			SELECT COUNT(*)
			FROM [SisUvex].[dbo].[Nom_WorkGroupEmployeeDaily]
			WHERE d_date = @Fecha";

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				{
					cmd.Parameters.AddWithValue("@Fecha", fecha.Date);

					int cantidad = Convert.ToInt32(cmd.ExecuteScalar());

					return cantidad > 0;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
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

			int anchoCodigo = 70;
			int anchoEmpleado = 280;
			int anchoLugarPago = 220;
			int anchoActividad = 220;
			int anchoLote = ancho -
				anchoCodigo -
				anchoEmpleado -
				anchoLugarPago -
				anchoActividad;

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
			g.DrawString(
				"Lote",
				fuenteEncabezado,
				brushBlanco,
				x + anchoCodigo +
				anchoEmpleado +
				anchoLugarPago +
				anchoActividad + 12,
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
				string lote =
					fila.Cells["Lote"].Value?.ToString() ?? "";

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
				g.DrawString(
					lote,
					texto,
					Brushes.Black,
					x + anchoCodigo +
					anchoEmpleado +
					anchoLugarPago +
					anchoActividad + 12,
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

			dgv.Columns["Codigo"].FillWeight = 12;
			dgv.Columns["Nombre"].FillWeight = 30;
			dgv.Columns["LugarPago"].FillWeight = 22;
			dgv.Columns["Actividad"].FillWeight = 18;
			dgv.Columns["Lote"].FillWeight = 30;

			dgv.Columns["Codigo"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.Columns["Nombre"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleLeft;

			dgv.Columns["LugarPago"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleLeft;

			dgv.Columns["Actividad"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleLeft;

			dgv.Columns["Lote"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleLeft;
		}
	}
}
