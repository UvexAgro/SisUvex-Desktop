using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Nomina.NomCampoAgregarListados
{
	public class ClsModificar
	{
		public FrmModificar frmM;
		public bool cargandoCombos = false;
		public void CrearTablaSemana()
		{
			frmM.tlpSemana.Controls.Clear();

			frmM.tlpSemana.AutoSize = false;
			frmM.tlpSemana.Dock = DockStyle.None;

			frmM.tlpSemana.GrowStyle =
				TableLayoutPanelGrowStyle.FixedSize;

			frmM.tlpSemana.ColumnCount = 8;
			frmM.tlpSemana.RowCount = 4;

			// ==========================================
			// COLUMNAS
			// ==========================================

			frmM.tlpSemana.ColumnStyles.Clear();

			frmM.tlpSemana.ColumnStyles.Add(
				new ColumnStyle(SizeType.Absolute, 75));

			for (int i = 0; i < 7; i++)
			{
				frmM.tlpSemana.ColumnStyles.Add(
					new ColumnStyle(
						SizeType.Percent,
						100f / 7f));
			}

			// ==========================================
			// FILAS
			// ==========================================

			frmM.tlpSemana.RowStyles.Clear();

			frmM.tlpSemana.RowStyles.Add(
				new RowStyle(SizeType.Absolute, 30));

			frmM.tlpSemana.RowStyles.Add(
				new RowStyle(SizeType.Absolute, 40));

			frmM.tlpSemana.RowStyles.Add(
				new RowStyle(SizeType.Absolute, 35));

			frmM.tlpSemana.RowStyles.Add(
				new RowStyle(SizeType.Absolute, 40));

			// ==========================================
			// ENCABEZADOS DE DÍAS
			// ==========================================

			string[] dias =
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
				Label lblDia = new Label();

				lblDia.Text = dias[i];

				lblDia.Dock =
					DockStyle.Fill;

				lblDia.TextAlign =
					ContentAlignment.MiddleCenter;

				lblDia.Font =
					new Font(
						"Segoe UI",
						9,
						FontStyle.Bold);

				frmM.tlpSemana.Controls.Add(
					lblDia,
					i + 1,
					0);
			}

			// ==========================================
			// ETIQUETA ACTIVIDAD
			// ==========================================

			Label lblActividad =
				CrearLabelFila("Actividad");

			frmM.tlpSemana.Controls.Add(
				lblActividad,
				0,
				1);

			// ==========================================
			// ETIQUETA LOTE
			// ==========================================

			Label lblLote =
				CrearLabelFila("Lote");

			frmM.tlpSemana.Controls.Add(
				lblLote,
				0,
				3);

			// ==========================================
			// CREAR COMBOBOX
			// ==========================================

			for (int i = 0; i < 7; i++)
			{
				// ======================================
				// ACTIVIDAD
				// ======================================

				frmM.cboActividad[i] = CrearComboBox();
				frmM.cboActividad[i].Tag = i;

				frmM.cboActividad[i].Enter += ComboBox_Enter;

				frmM.tlpSemana.Controls.Add(
					frmM.cboActividad[i],
					i + 1,
					1);

				// ======================================
				// LOTE
				// ======================================

				frmM.cboLote[i] = CrearComboBox();
				frmM.cboLote[i].Tag = i;

				frmM.cboLote[i].Enter += ComboBox_Enter;

				frmM.tlpSemana.Controls.Add(
					frmM.cboLote[i],
					i + 1,
					3);
			}
		}
		private ComboBox CrearComboBox()
		{
			ComboBox cbo = new ComboBox();

			cbo.Dock = DockStyle.Fill;

			// Permitir escribir
			cbo.DropDownStyle = ComboBoxStyle.DropDown;

			cbo.AutoCompleteMode = AutoCompleteMode.None;
			cbo.AutoCompleteSource = AutoCompleteSource.None;

			cbo.Margin = new Padding(2, 5, 2, 5);

			// BUSCAR MIENTRAS ESCRIBES
			cbo.TextUpdate += ComboBox_TextUpdate;

			return cbo;
		}
		private void ComboBox_Enter(object sender, EventArgs e)
		{
			ComboBox cbo = (ComboBox)sender;

			cbo.SelectionStart = cbo.Text.Length;
			cbo.SelectionLength = 0;
		}
		private Label CrearLabelFila(string texto)
		{
			Label lbl = new Label();

			lbl.Text = texto;
			lbl.Dock = DockStyle.Fill;
			lbl.TextAlign =
				ContentAlignment.MiddleLeft;

			lbl.Font =
				new Font(
					"Segoe UI",
					9,
					FontStyle.Bold);

			lbl.Margin =
				new Padding(3);

			return lbl;
		}
		public void CargarCombosSemana()
		{
			try
			{

				cargandoCombos = true;
				// =====================================================
				// ACTIVIDADES
				// =====================================================

				DataTable dtActividades = ObtenerActividades();

				if (!dtActividades.Columns.Contains("Descripcion"))
				{
					dtActividades.Columns.Add(
						"Descripcion",
						typeof(string));
				}

				foreach (DataRow fila in dtActividades.Rows)
				{
					string codigo =
						fila["c_codigo_tab"]?.ToString().Trim() ?? "";

					string descripcion =
						fila["v_descripcion_tab"]?.ToString().Trim() ?? "";

					fila["Descripcion"] =
						$"{codigo} - {descripcion}";
				}

				for (int i = 0; i < 7; i++)
				{
					frmM.cboActividad[i].DataSource = null;

					frmM.cboActividad[i].Tag =
						dtActividades.Copy();

					frmM.cboActividad[i].DisplayMember =
						"Descripcion";

					frmM.cboActividad[i].ValueMember =
						"c_codigo_tab";

					frmM.cboActividad[i].DataSource =
						dtActividades.Copy();

					frmM.cboActividad[i].SelectedIndex = -1;
					frmM.cboActividad[i].Text = "";
				}


				// =====================================================
				// LOTES
				// =====================================================

				DataTable dtLotes = ObtenerLotes();

				if (!dtLotes.Columns.Contains("LoteCompleto"))
				{
					dtLotes.Columns.Add(
						"LoteCompleto",
						typeof(string));
				}

				foreach (DataRow fila in dtLotes.Rows)
				{
					string codigo =
						fila["c_codigo_lot"]?.ToString().Trim() ?? "";

					string nombre =
						fila["v_nameLot"]?.ToString().Trim() ?? "";

					string variedad =
						fila["NombreVariedad"]?.ToString().Trim() ?? "";

					fila["LoteCompleto"] =
						$"{codigo} - {nombre} - {variedad}";
				}

				for (int i = 0; i < 7; i++)
				{
					frmM.cboLote[i].DataSource = null;

					frmM.cboLote[i].Tag =
						dtLotes.Copy();

					frmM.cboLote[i].DisplayMember =
						"LoteCompleto";

					frmM.cboLote[i].ValueMember =
						"c_codigo_lot";

					frmM.cboLote[i].DataSource =
						dtLotes.Copy();

					frmM.cboLote[i].SelectedIndex = -1;
					frmM.cboLote[i].Text = "";
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al cargar actividades y lotes:\n" +
					ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				cargandoCombos = false;
			}
		}
		public DataTable ObtenerActividades()
		{
			SQLControl sql = new SQLControl();
			DataTable dt = new DataTable();

			try
			{
				sql.OpenConectionWrite();

				string query = @"
            SELECT
                c_codigo_tab,
                v_descripcion_tab
            FROM Nom_Tabulador
            ORDER BY c_codigo_tab;";

				using (SqlCommand cmd = new SqlCommand(query, sql.cnn))
				{
					using (SqlDataAdapter da = new SqlDataAdapter(cmd))
					{
						da.Fill(dt);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al obtener las actividades:\n" +
					ex.Message,
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
		public DataTable ObtenerLotes()
		{
			SQLControl sql = new SQLControl();
			DataTable dt = new DataTable();

			try
			{
				sql.OpenConectionWrite();

				string query = @"
            SELECT
                L.c_codigo_lot,
                L.v_nameLot,
                L.id_variety,
                V.v_nameComercial AS NombreVariedad
            FROM dbo.Pack_Lot AS L
            INNER JOIN dbo.Pack_Variety AS V
                ON L.id_variety = V.id_variety
            WHERE L.c_active = '1'
              AND NULLIF(
                    LTRIM(RTRIM(L.c_codigo_lot)), ''
                  ) IS NOT NULL
            ORDER BY
                L.c_codigo_lot ASC;";

				using (SqlCommand cmd =
					   new SqlCommand(query, sql.cnn))
				{
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
					"Error al obtener los lotes:\n" +
					ex.Message,
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
		private void ComboBox_TextUpdate(object sender, EventArgs e)
		{
			if (cargandoCombos)
				return;

			ComboBox cbo = (ComboBox)sender;

			// ==========================================
			// VALIDACIONES
			// ==========================================

			if (cbo.Tag == null)
				return;

			DataTable dtOriginal =
				cbo.Tag as DataTable;

			if (dtOriginal == null)
				return;

			// Evitar que se ejecute mientras se está cargando
			if (cbo.Items.Count == 0)
				return;


			// ==========================================
			// TEXTO ESCRITO
			// ==========================================

			string texto = cbo.Text.Trim();

			int posicionCursor = 0;

			if (cbo.DropDownStyle != ComboBoxStyle.DropDownList)
			{
				posicionCursor = cbo.SelectionStart;
			}


			// ==========================================
			// FILTRAR
			// ==========================================

			DataTable dtFiltrado =
				dtOriginal.Clone();

			foreach (DataRow fila in dtOriginal.Rows)
			{
				string textoBusqueda = "";

				// ======================================
				// ACTIVIDAD
				// ======================================

				if (dtOriginal.Columns.Contains("Descripcion"))
				{
					textoBusqueda =
						fila["Descripcion"]?.ToString() ?? "";
				}

				// ======================================
				// LOTE
				// ======================================

				if (dtOriginal.Columns.Contains("LoteCompleto"))
				{
					textoBusqueda =
						fila["LoteCompleto"]?.ToString() ?? "";
				}


				if (string.IsNullOrWhiteSpace(texto) ||
					textoBusqueda.IndexOf(
						texto,
						StringComparison.OrdinalIgnoreCase) >= 0)
				{
					dtFiltrado.ImportRow(fila);
				}
			}


			// ==========================================
			// ACTUALIZAR COMBO
			// ==========================================

			cbo.BeginUpdate();

			try
			{
				cbo.DataSource = null;

				cbo.DisplayMember =
					dtOriginal.Columns.Contains("Descripcion")
						? "Descripcion"
						: "LoteCompleto";

				if (dtOriginal.Columns.Contains("c_codigo_tab"))
				{
					cbo.ValueMember = "c_codigo_tab";
				}
				else if (dtOriginal.Columns.Contains("c_codigo_lot"))
				{
					cbo.ValueMember = "c_codigo_lot";
				}

				cbo.DataSource = dtFiltrado;

				cbo.Text = texto;

				if (cbo.DropDownStyle != ComboBoxStyle.DropDownList)
				{
					cbo.SelectionStart =
						Math.Min(
							posicionCursor,
							cbo.Text.Length);

					cbo.SelectionLength = 0;
				}

				if (!string.IsNullOrWhiteSpace(texto) &&
					dtFiltrado.Rows.Count > 0)
				{
					cbo.DroppedDown = true;
				}
			}
			finally
			{
				cbo.EndUpdate();
			}
		}
		public void CargarDatosEmpleadoSemana(string codigoEmpleado,string secuenciaSemana)
		{
			SQLControl sql = new SQLControl();
			DataTable dt = new DataTable();

			try
			{
				sql.OpenConectionWrite();

				string query = @"
            SELECT
                id_activity_vie,
                id_lot_vie,

                id_activity_sab,
                id_lot_sab,

                id_activity_dom,
                id_lot_dom,

                id_activity_lun,
                id_lot_lun,

                id_activity_mar,
                id_lot_mar,

                id_activity_mie,
                id_lot_mie,

                id_activity_jue,
                id_lot_jue

            FROM dbo.Nom_EmployeeAttendanceWeekly
            WHERE id_employee = @id_employee
              AND c_sequence_per = @c_sequence_per;";

				using (SqlCommand cmd =
					   new SqlCommand(query, sql.cnn))
				{
					cmd.Parameters.Add(
						"@id_employee",
						SqlDbType.VarChar).Value =
						codigoEmpleado.Trim();

					cmd.Parameters.Add(
						"@c_sequence_per",
						SqlDbType.VarChar).Value =
						secuenciaSemana.Trim();

					using (SqlDataAdapter da =
						   new SqlDataAdapter(cmd))
					{
						da.Fill(dt);
					}
				}

				if (dt.Rows.Count == 0)
				{
					return;
				}

				DataRow fila = dt.Rows[0];

				// ==========================================
				// VIE
				// ==========================================

				SeleccionarCombo(
					frmM.cboActividad[0],
					fila["id_activity_vie"]);

				SeleccionarCombo(
					frmM.cboLote[0],
					fila["id_lot_vie"]);


				// ==========================================
				// SÁB
				// ==========================================

				SeleccionarCombo(
					frmM.cboActividad[1],
					fila["id_activity_sab"]);

				SeleccionarCombo(
					frmM.cboLote[1],
					fila["id_lot_sab"]);


				// ==========================================
				// DOM
				// ==========================================

				SeleccionarCombo(
					frmM.cboActividad[2],
					fila["id_activity_dom"]);

				SeleccionarCombo(
					frmM.cboLote[2],
					fila["id_lot_dom"]);


				// ==========================================
				// LUN
				// ==========================================

				SeleccionarCombo(
					frmM.cboActividad[3],
					fila["id_activity_lun"]);

				SeleccionarCombo(
					frmM.cboLote[3],
					fila["id_lot_lun"]);


				// ==========================================
				// MAR
				// ==========================================

				SeleccionarCombo(
					frmM.cboActividad[4],
					fila["id_activity_mar"]);

				SeleccionarCombo(
					frmM.cboLote[4],
					fila["id_lot_mar"]);


				// ==========================================
				// MIÉ
				// ==========================================

				SeleccionarCombo(
					frmM.cboActividad[5],
					fila["id_activity_mie"]);

				SeleccionarCombo(
					frmM.cboLote[5],
					fila["id_lot_mie"]);


				// ==========================================
				// JUE
				// ==========================================

				SeleccionarCombo(
					frmM.cboActividad[6],
					fila["id_activity_jue"]);

				SeleccionarCombo(
					frmM.cboLote[6],
					fila["id_lot_jue"]);
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al cargar los datos del empleado:\n" +
					ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		private void SeleccionarCombo(
	ComboBox combo,
	object valor)
		{
			if (valor == null ||
				valor == DBNull.Value ||
				string.IsNullOrWhiteSpace(valor.ToString()))
			{
				combo.SelectedIndex = -1;
				combo.Text = "";
				return;
			}

			string valorBuscado =
				valor.ToString().Trim();

			combo.SelectedValue = valorBuscado;

			if (combo.SelectedIndex < 0)
			{
				combo.Text = valorBuscado;
			}
		}

	}
}