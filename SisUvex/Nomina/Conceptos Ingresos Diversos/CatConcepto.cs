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

namespace SisUvex.Nomina.Conceptos_Ingresos_Diversos
{
	 public class CatConcepto
	{
		public string? idConcept { get; set; }
		public string? concept { get; set; }
		public decimal? amount { get; set; }
		public decimal? unit { get; set; }
		public string? userCreate { get; set; }

		// Insertar concepto
		public (bool, string?) AddProcedure()
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				SqlCommand cmd = new SqlCommand("sp_NomConceptAdd", sql.cnn);
				cmd.CommandType = CommandType.StoredProcedure;

				// Parámetros
				cmd.Parameters.AddWithValue("@concept", concept);
				cmd.Parameters.AddWithValue("@amount", (object?)amount ?? DBNull.Value);
				cmd.Parameters.AddWithValue("@unit", (object?)unit ?? DBNull.Value);
				cmd.Parameters.AddWithValue("@userCreate", User.GetUserName());
				// Ejecutar y leer ID generado
				SqlDataReader dr = cmd.ExecuteReader();

				if (dr.Read())
				{
					idConcept = dr["id_concept"].ToString();
					return (true, idConcept);
				}

				return (false, null);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Agregar concepto");
				return (false, null);
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		  //Modificar concepto
		public bool ModifyProcedure()
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				SqlCommand cmd = new SqlCommand("sp_NomConceptModify", sql.cnn);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@id_concept", idConcept);
				cmd.Parameters.AddWithValue("@concept", concept);
				cmd.Parameters.AddWithValue("@amount", (object?)amount ?? DBNull.Value);
				cmd.Parameters.AddWithValue("@unit", (object?)unit ?? DBNull.Value);
				cmd.Parameters.AddWithValue("@userCreate", User.GetUserName());

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
				MessageBox.Show(ex.Message, "Modificar concepto");
				return false;
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}

		//Eliminar concepto
		public bool DeleteProcedure(string id)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				SqlCommand cmd = new SqlCommand("sp_NomConceptDelete", sql.cnn);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@id_concept", id);

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
				MessageBox.Show(ex.Message, "Eliminar concepto");
				return false;
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
	}
}

		
	



	

