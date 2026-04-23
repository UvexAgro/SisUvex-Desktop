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

namespace SisUvex.Catalogos.Nom_Deducciones
{
	public class ClsDeducciones
	{
		public string? id_Deductions { get; set; }
		public string? v_descripcion_ded { get; set; }
		public decimal? n_importeFijo_ded { get; set; }
		public string? v_userCreate { get; set; }
		
		public ClsAddDeducciones clsAdd;

		public (bool, string) AddNomDeductions()
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				SqlCommand cmd = new SqlCommand("sp_Add_Nom_Deductions", sql.cnn);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@id_Deductions", id_Deductions);
				cmd.Parameters.AddWithValue("@v_descripcion_ded", v_descripcion_ded ?? (object)DBNull.Value);
				cmd.Parameters.AddWithValue("@n_importeFijo_ded", n_importeFijo_ded ?? (object)DBNull.Value);
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
		public (bool, string) UpdateNomDeductions()
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				SqlCommand cmd = new SqlCommand("sp_Update_Nom_Deductions", sql.cnn);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@id_Deductions", id_Deductions);
				cmd.Parameters.AddWithValue("@v_descripcion_ded", v_descripcion_ded ?? (object)DBNull.Value);
				cmd.Parameters.AddWithValue("@n_importeFijo_ded", n_importeFijo_ded ?? (object)DBNull.Value);

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
		public (bool, string) DeleteNomDeductions()
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				SqlCommand cmd = new SqlCommand("sp_Delete_Nom_Deductions", sql.cnn);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@id_Deductions", id_Deductions);

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
	}
}
