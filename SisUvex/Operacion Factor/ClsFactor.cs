using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office.Word;
using SisUvex.Catalogos.Metods.Querys;
using static SisUvex.Catalogos.Metods.ClsObject;
using System.Data.SqlClient;


namespace SisUvex.Operacion_Factor
{
	public class ClsFactor
	{
		public FrmFactor frm;
		private string GetQueryPromedioLbs()
		{
			string fecha = frm.dtpFecha.Value.ToString("yyyy-MM-dd");

			string query = $@"
			SELECT 
			ISNULL(SUM([Lbs Netas]) / NULLIF(SUM(Cajas),0),0) AS PromedioLbsPorCaja
			FROM dbo.vw_Pack_BulkReception
			WHERE Fecha = '{fecha}'";

			return query;
		}
		public void CargarPromedioLbs()
		{
			decimal promedio = 0.00m;
			DataTable dt = ClsQuerysDB.GetDataTable(GetQueryPromedioLbs());

			if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["PromedioLbsPorCaja"] != DBNull.Value)
			{
				promedio = Convert.ToDecimal(dt.Rows[0]["PromedioLbsPorCaja"]);
			}

			frm.txbPesodeCaja.Text = promedio.ToString("0.00");
		}
		public void CargarTablaPackingHouse()
		{
			string query = @"SELECT 
			id_workdayRecord AS Fecha,
			id_season AS Temporada,
			i_receivedBoxes AS [Cajas Recibidas],
			n_receivedPounds AS [Libras Recibidas],
			i_workedBoxes AS [Cajas Trabajadas],
			n_workedPounds AS [Libras Trabajadas],
			i_carryoverBoxes AS [Cajas en Piso],
			n_carryoverPounds AS [Libras en Piso],
			i_packedBoxes AS [Cajas Empacadas],
			n_packedPounds AS [Libras Empacadas],
			n_conversionFactor AS Factor
			FROM Pack_PackingHouseData
			ORDER BY id_workdayRecord DESC";

			DataTable dt = ClsQuerysDB.GetDataTable(query);

			frm.dgvFactor.DataSource = null;
			frm.dgvFactor.DataSource = dt;
		}
		
		public void GuardarPackingHouse(DateTime fecha, decimal cajasPiso, decimal libras)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				SqlCommand cmd = new SqlCommand("sp_PackPackingHouseData", sql.cnn);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@id_workdayRecord", fecha);
				cmd.Parameters.AddWithValue("@i_carryOverBoxes", cajasPiso);
				cmd.Parameters.AddWithValue("@n_carryoverPounds", libras);

				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Guardar datos");
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public bool ExisteRegistro(DateTime fecha)
		{
			string query = $@"
			SELECT COUNT(*)
			FROM Pack_PackingHouseData
			WHERE id_workdayRecord = '{fecha:yyyy-MM-dd}'";

			DataTable dt = ClsQuerysDB.GetDataTable(query);

			return Convert.ToInt32(dt.Rows[0][0]) > 0;
		}
		public void ReprocesarSiNoTrabajo(DateTime fecha)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand("sp_CorregirPackingSinTrabajo", sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					// Parámetro tipado correctamente
					cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha;

					cmd.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Reproceso");
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
	}	
}
