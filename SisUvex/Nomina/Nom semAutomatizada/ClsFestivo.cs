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
		public FrmFestivo frmF;

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
		public DataTable ObtenerNominaFestiva()
		{
			SQLControl sql = new SQLControl();

			sql.OpenConectionWrite();

			SqlCommand cmd = new SqlCommand("sp_ReporteNomina_Festivo", sql.cnn);
			cmd.CommandType = CommandType.StoredProcedure;

			cmd.Parameters.AddWithValue("@Fecha", frm.dtpFecha.Value);
			cmd.Parameters.AddWithValue("@TipoFestivo", frm.TipoFestivoSeleccionado);
			cmd.Parameters.AddWithValue("@TipoNomina", cls.TipoNomina);
			cmd.Parameters.AddWithValue("@Usuario", User.GetUserName());

			DataTable dt = new DataTable();

			new SqlDataAdapter(cmd).Fill(dt);

			sql.CloseConectionWrite();

			return dt;
		}
		public string ObtenerDescripcionFestivo(string tipo)
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