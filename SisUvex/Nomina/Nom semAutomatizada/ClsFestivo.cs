using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.Formula.Functions;
using SisUvex.Catalogos;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.TextBoxes;
using SisUvex.Nomina.Conceptos_Ingresos_Diversos;
using SisUvex.Nomina.Work_time;
using static SisUvex.Catalogos.Metods.ClsObject;
using DrawingColor = System.Drawing.Color;

namespace SisUvex.Nomina.Nom_semAutomatizada
{
	public class ClsFestivo
	{
		public FrmSemiAutomatedPayroll frm;
		internal ClsSemiAutomatedPayroll cls;

		public bool EsFestivo(DateTime fecha)
		{
			bool resultado = false;

			try
			{
				SQLControl sql = new SQLControl();
				sql.OpenConectionWrite();

				SqlCommand cmd = new SqlCommand(
					"SELECT COUNT(*) FROM dbo.Cat_Festivos WHERE d_fecha = @Fecha",
					sql.cnn);


				cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = fecha.Date;

				int count = (int)cmd.ExecuteScalar();

				resultado = count > 0;

				sql.CloseConectionWrite();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			return resultado;
		}
		public void BtnCargarDatos()
		{
			string tipoNomina = frm.rbtEsparrago.Checked ? "E" : "U";

			DateTime fecha = frm.dtpFecha.Value;

			string tipoFestivo = frm.TipoFestivoSeleccionado;

			if (ExisteNominaFestiva(fecha))
			{
				DialogResult r = MessageBox.Show(
					"Ya existe una nómina guardada para esta fecha.\n\n" +
					"¿Qué desea hacer?\n\n" +
					"Sí  → Volver a generar la nómina.\n" +
					"No → Mostrar la nómina guardada.",
					"Nómina existente",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question);

				if (r == DialogResult.No)
				{
					string query = tipoNomina == "E"
						? $"EXEC sp_GetReporteNominaDiaria_Esparrago '{fecha:yyyy-MM-dd}'"
						: $"EXEC sp_GetReporteNominaDiaria_Uva '{fecha:yyyy-MM-dd}'";

					frm.dgvEmployee.DataSource = ClsQuerysDB.GetDataTable(query);
					return;
				}
			}

			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				SqlCommand cmd = new SqlCommand("sp_ReporteNomina_Festivo", sql.cnn);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@Fecha", fecha);
				cmd.Parameters.AddWithValue("@TipoFestivo", tipoFestivo);
				cmd.Parameters.AddWithValue("@TipoNomina", tipoNomina);
				cmd.Parameters.AddWithValue("@Usuario", User.GetUserName());

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();
				da.Fill(dt);

				if (dt.Rows.Count == 0)
				{
					MessageBox.Show(
						"No existen registros para la fecha seleccionada.",
						"Sistema",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information);
					return;
				}

				// Actualizar el tipo de nómina
				cls.TipoNomina = frm.rbtEsparrago.Checked ? "E" : "U";

				// Cargar datos
				frm.dgvEmployee.DataSource = dt;

				// Aplicar colores y estilo
				cls.AplicarColores(cls.TipoNomina);

				// Solo lectura
				foreach (DataGridViewColumn col in frm.dgvEmployee.Columns)
					col.ReadOnly = true;

				frm.dgvEmployee.Columns["SueldoTotal"].ReadOnly = false;

				// Guardar sueldos originales
				cls.GuardarSueldosOriginales();

				// Activar estilo
				cls.ActivarEstiloGrid(frm.dgvEmployee);

				string cultivo = cls.TipoNomina == "E"
					? "Espárrago"
					: "Uva";

				frm.lblencabezado.Text = $"Nómina de Empaque - {cultivo}";

				frm.lblTipoProceso.Text = ObtenerDescripcionFestivo(tipoFestivo);
				frm.lblTipoProceso.Visible = !string.IsNullOrWhiteSpace(frm.lblTipoProceso.Text);

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Sistema");
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		private bool ExisteNominaFestiva(DateTime fecha)
		{
			string tabla = frm.rbtEsparrago.Checked
				? "HistNom_ReporteDiarioEsparrago"
				: "HistNom_ReporteDiarioUva";

			string query = $@"
			SELECT COUNT(*)
			FROM {tabla}
			WHERE Fecha = '{fecha:yyyy-MM-dd}'";

			int registros = Convert.ToInt32(ClsQuerysDB.GetData(query));

			return registros > 0;
		}
		private string ObtenerDescripcionFestivo(string tipo)
		{
			switch (tipo)
			{
				case "DESCANSO_TRABAJADO":
					return "Descanso trabajado (Festivo)";
					frm.lblTipoProceso.Visible = false;

				case "TRABAJADO":
					return "Festivo trabajado";
					frm.lblTipoProceso.Visible = false;

				case "NO_TRABAJADO":
					return "Festivo no trabajado";
					frm.lblTipoProceso.Visible = false;

				default:
					return "";
			}
		}
	}
}