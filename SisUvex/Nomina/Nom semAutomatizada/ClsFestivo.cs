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
using SisUvex.Catalogos.Metods.TextBoxes;
using SisUvex.Nomina.Conceptos_Ingresos_Diversos;
using SisUvex.Nomina.Work_time;
using static SisUvex.Catalogos.Metods.ClsObject;
using DrawingColor = System.Drawing.Color;

namespace SisUvex.Nomina.Nom_semAutomatizada
{
	internal class ClsFestivo
	{
		public FrmSemiAutomatedPayroll frm;

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
			DateTime fecha = frm.dtpFecha.Value;

			//  VALIDAR PRIMERO SI ES FESTIVO
			if (!EsFestivo(fecha))
			{
				MessageBox.Show(
					"Este día NO es festivo.\n\nNo se abrirá ni se procesará información.",
					"Sistema",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return; 
			}

			string tipoFestivo = frm.TipoFestivoSeleccionado;

			if (string.IsNullOrEmpty(tipoFestivo))
			{
				MessageBox.Show(
					"Seleccione el tipo de día.",
					"Sistema",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return;
			}

			try
			{
				SQLControl sql = new SQLControl();
				sql.OpenConectionWrite();

						SqlCommand cmd = new SqlCommand(@"
				EXEC sp_ReporteNomina_Festivo
				@Fecha, 
				@TipoFestivo
				", sql.cnn);

				cmd.Parameters.AddWithValue("@Fecha", fecha);
				cmd.Parameters.AddWithValue("@TipoFestivo", tipoFestivo);

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();
				da.Fill(dt);

				if (dt.Rows.Count == 0)
				{
					MessageBox.Show("No existen registros para la fecha seleccionada.");
					return;
				}

				frm.dgvEmployee.DataSource = dt;

				sql.CloseConectionWrite();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}