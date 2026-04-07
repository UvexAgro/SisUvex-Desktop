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

namespace SisUvex.Nomina.Nom_Descuento_de_personal
{
	internal class ClsAddDesc
	{
		public string id_Deduction { get; set; } = null!;
		public DateTime d_StartDate { get; set; }
		public DateTime? d_EndDate { get; set; }
		public string id_productionLine { get; set; } = null!;
		public string c_Quantity { get; set; } = null!;
		public string? v_Description { get; set; }
		public string? v_userCreate { get; set; }
		public DateTime? d_create { get; set; }
		public string? v_userUpdate { get; set; }
		public DateTime? d_update { get; set; }


		public (bool, string?) AddSorter()
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				SqlCommand cmd = new SqlCommand("sp_AddNomSorterDeductionPacking", sql.cnn);
				cmd.CommandType = CommandType.StoredProcedure;

				// Parámetros
				cmd.Parameters.AddWithValue("@id_Deduction", id_Deduction);
				cmd.Parameters.AddWithValue("@d_StartDate", d_StartDate);
				cmd.Parameters.AddWithValue("@d_EndDate", (object?)d_EndDate ?? DBNull.Value);
				cmd.Parameters.AddWithValue("@id_productionLine", id_productionLine);
				cmd.Parameters.AddWithValue("@c_Quantity", c_Quantity);
				cmd.Parameters.AddWithValue("@v_Description", (object?)v_Description ?? DBNull.Value);
				cmd.Parameters.AddWithValue("@v_userCreate", User.GetUserName());

				// Ejecutar
				SqlDataReader dr = cmd.ExecuteReader();

				if (dr.Read())
				{
					id_Deduction = dr["id_Deduction"].ToString();
					return (true, id_Deduction);
				}

				return (false, null);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Agregar Descuwnto de Sorteador");
				return (false, null);
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public bool ModifySorter()
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				SqlCommand cmd = new SqlCommand("sp_UpdateNomSorterDeductionPacking", sql.cnn);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@id_Deduction", id_Deduction);
				cmd.Parameters.AddWithValue("@d_StartDate", d_StartDate);
				cmd.Parameters.AddWithValue("@d_EndDate", (object?)d_EndDate ?? DBNull.Value);
				cmd.Parameters.AddWithValue("@id_productionLine", id_productionLine);
				cmd.Parameters.AddWithValue("@c_Quantity", c_Quantity);
				cmd.Parameters.AddWithValue("@v_Description", (object?)v_Description ?? DBNull.Value);
				cmd.Parameters.AddWithValue("@v_userUpdate", User.GetUserName());

				SqlDataReader dr = cmd.ExecuteReader();

				if (dr.Read())
				{
					int rows = Convert.ToInt32(dr["rowsAffected"]);
					return rows > 0;
				}

				return false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Modificar Descuento de Sorteador");
				return false;
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public bool DeleteSorter(string id)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				SqlCommand cmd = new SqlCommand("sp_DeleteNomSorterDeductionPacking", sql.cnn);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@id_Deduction", id);

				SqlDataReader dr = cmd.ExecuteReader();

				if (dr.Read())
				{
					int rows = Convert.ToInt32(dr["rowsAffected"]);
					return rows > 0;
				}

				return false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Eliminar Descuento de Sorteador");
				return false;
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
	}
}
