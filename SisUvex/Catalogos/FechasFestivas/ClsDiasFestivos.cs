using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisUvex.Catalogos.Metods.Querys;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods.Values;

namespace SisUvex.Catalogos.FechasFestivas
{
	public class ClsDiasFestivos
	{
		public string? id_festivo { get; set; }

		public DateTime? d_fecha { get; set; }

		public string? v_descripcion { get; set; }

		public string? v_userCreate { get; set; }

		public DateTime? d_create { get; set; }

		public string? v_userUpdate { get; set; }

		public DateTime? d_update { get; set; }


		public (bool, string) AddFestivo()
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				SqlCommand cmd = new SqlCommand("sp_ADDFestivo", sql.cnn);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@id_festivo", id_festivo); 
				cmd.Parameters.AddWithValue("@d_fecha", d_fecha);
				cmd.Parameters.AddWithValue("@v_descripcion", (object?)v_descripcion ?? DBNull.Value);
				cmd.Parameters.AddWithValue("@v_userCreate", User.GetUserName());

				int rows = cmd.ExecuteNonQuery();

				return (rows > 0, "");
			}
			catch (Exception ex)
			{
				return (false, ex.Message);
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public bool UpdateFestivo()
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				SqlCommand cmd = new SqlCommand("dbo.sp_UpdateFestivo", sql.cnn);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@id_festivo", id_festivo);
				cmd.Parameters.AddWithValue("@d_fecha", d_fecha);
				cmd.Parameters.AddWithValue("@v_descripcion", (object?)v_descripcion ?? DBNull.Value);
				cmd.Parameters.AddWithValue("@v_userUpdate", User.GetUserName());

				cmd.ExecuteNonQuery(); 
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Actualizar festivo");
				return false;
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}

		public bool DeleteFestivo(string id)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				SqlCommand cmd = new SqlCommand("dbo.sp_DeleteFestivo", sql.cnn);
				cmd.CommandType = CommandType.StoredProcedure;

				
				string idFormateado = id.Trim().PadLeft(4, '0');

				cmd.Parameters.AddWithValue("@id_festivo", idFormateado);

				cmd.ExecuteNonQuery();

				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Eliminar festivo");
				return false;
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
	}

}

