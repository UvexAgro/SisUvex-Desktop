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

namespace SisUvex.Nomina.NomTabulador
{
	public class ClsAddTabulador
	{
		public string? c_codigo_tab { get; set; }

		public string? v_descripcion_tab { get; set; }

		public string? id_seasonType { get; set; }

		public decimal? d_basesalary { get; set; }

		public decimal? d_commission { get; set; }

		public decimal? n_aboutSalary { get; set; }

		public decimal? n_SeventhDayPay { get; set; }

		public decimal? n_HolidayBasePay { get; set; }

		public decimal? n_WorkedRestHolidayPay { get; set; }

		public ClsNomTabuladorCat cls;

		public bool UpdateTabulador()
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				SqlCommand cmd = new SqlCommand("dbo.sp_UpdateNomTabulador", sql.cnn);
				cmd.CommandType = CommandType.StoredProcedure;

			
				cmd.Parameters.AddWithValue("@c_codigo_tab", c_codigo_tab?.Trim());

				cmd.Parameters.AddWithValue("@v_descripcion_tab", (object?)v_descripcion_tab ?? DBNull.Value);
				cmd.Parameters.AddWithValue("@id_seasonType", (object?)id_seasonType ?? DBNull.Value);

				cmd.Parameters.AddWithValue("@d_basesalary", (object?)d_basesalary ?? DBNull.Value);
				cmd.Parameters.AddWithValue("@d_commission", (object?)d_commission ?? DBNull.Value);
				cmd.Parameters.AddWithValue("@n_aboutSalary", (object?)n_aboutSalary ?? DBNull.Value);
				cmd.Parameters.AddWithValue("@n_SeventhDayPay", (object?)n_SeventhDayPay ?? DBNull.Value);
				cmd.Parameters.AddWithValue("@n_HolidayBasePay", (object?)n_HolidayBasePay ?? DBNull.Value);
				cmd.Parameters.AddWithValue("@n_WorkedRestHolidayPay", (object?)n_WorkedRestHolidayPay ?? DBNull.Value);

				cmd.Parameters.AddWithValue("@c_usuario_mod", User.GetUserName());

				cmd.ExecuteNonQuery();
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Actualizar tabulador");
				return false;
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
	}
}
