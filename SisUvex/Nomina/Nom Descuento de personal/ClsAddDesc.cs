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
	public class ClsAddDesc
	{
		public string id_Deduction { get; set; } 
		public DateTime d_StartDate { get; set; }
		public DateTime? d_EndDate { get; set; }
		public string id_productionLine { get; set; }
		public string c_Quantity { get; set; }
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

				using (SqlCommand cmd = new SqlCommand("sp_AddNomSorterDeductionPacking", sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					// Parámetros tipados (MEJOR)
					cmd.Parameters.Add("@id_Deduction", SqlDbType.VarChar).Value = id_Deduction;
					cmd.Parameters.Add("@d_StartDate", SqlDbType.Date).Value = d_StartDate;
					cmd.Parameters.Add("@d_EndDate", SqlDbType.Date).Value = (object?)d_EndDate ?? DBNull.Value;
					cmd.Parameters.Add("@id_productionLine", SqlDbType.VarChar).Value = id_productionLine;
					cmd.Parameters.Add("@c_Quantity", SqlDbType.Int).Value = c_Quantity;
					cmd.Parameters.Add("@v_Description", SqlDbType.VarChar).Value = (object?)v_Description ?? DBNull.Value;
					cmd.Parameters.Add("@v_userCreate", SqlDbType.VarChar).Value = User.GetUserName();

					
					object result = cmd.ExecuteScalar();

					if (result != null)
					{
						id_Deduction = result.ToString();
						return (true, id_Deduction);
					}

					return (false, null);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Agregar Descuento de Sorteador");
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

				using (SqlCommand cmd = new SqlCommand("sp_UpdateNomSorterDeductionPacking", sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					// Parámetros tipados
					cmd.Parameters.Add("@id_Deduction", SqlDbType.Char).Value = id_Deduction.Trim();
					cmd.Parameters.Add("@d_StartDate", SqlDbType.Date).Value = d_StartDate;
					cmd.Parameters.Add("@d_EndDate", SqlDbType.Date).Value = (object?)d_EndDate ?? DBNull.Value;
					cmd.Parameters.Add("@id_productionLine", SqlDbType.Char).Value = id_productionLine;
					cmd.Parameters.Add("@c_Quantity", SqlDbType.Char).Value = c_Quantity; // 👈 ojo aquí
					cmd.Parameters.Add("@v_Description", SqlDbType.VarChar).Value = (object?)v_Description ?? DBNull.Value;
					cmd.Parameters.Add("@v_userUpdate", SqlDbType.VarChar).Value = User.GetUserName();

					
					object result = cmd.ExecuteScalar();

					return result != null && Convert.ToInt32(result) > 0;
				}
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

				using (SqlCommand cmd = new SqlCommand("sp_DeleteNomSorterDeductionPacking", sql.cnn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@id_Deduction", SqlDbType.Char).Value = id.Trim();

					object result = cmd.ExecuteScalar();

					return result != null && Convert.ToInt32(result) > 0;
				}
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
