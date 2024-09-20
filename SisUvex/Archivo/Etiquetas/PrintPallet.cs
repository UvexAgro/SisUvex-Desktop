using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing.Printing;

namespace SisUvex.Archivo.Etiquetas
{
    internal class PrintPallet
    {
        SQLControl sqlControl = new SQLControl();
        string lastPallet;

        public string code, variety, distributor, boxes, pounds, presentation, datePacking, size, lote, print;


        public string LastPallet()
        {
            lastPallet = "";
            sqlControl.OpenConectionWrite();
            SqlCommand cmd = new SqlCommand("USE [SisUvex]\r\nGO\r\n\r\nSELECT TOP(1) id_pallet from Pack_Pallet\r\nORDER BY id_pallet DESC", sqlControl.cnn);
            object result = cmd.ExecuteScalar();

            if (result != null)
            {
                string lastPallet = result.ToString();
            }
            return lastPallet;

        }

        public void InsertPallet(int boxex, string workPlan, DateTime date, string user, string paperWork)
        {
                
            sqlControl.OpenConectionWrite();
            SqlCommand cmd = new SqlCommand("sp_PackPalletAdd", sqlControl.cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@boxes", boxex);
            cmd.Parameters.AddWithValue("@idWorkPlan", workPlan);
            cmd.Parameters.AddWithValue("@dPacked", date.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@userCreate", user);
            cmd.Parameters.AddWithValue("@invoice", paperWork);


            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                code = reader["Código"].ToString();
                variety = reader["Variedad"].ToString();
                distributor = reader["Distribuidor"].ToString();
                boxes = reader["Cajas"].ToString();
                pounds = reader["Libras"].ToString();
                presentation = reader["Presentación"].ToString();
                datePacking = Convert.ToDateTime(reader["Fecha"]).ToString("yyyy-MM-dd");
                size = reader["Tamaño"].ToString();
                lote = reader["Lote"].ToString();

            }
        }

        public void ReprintPallet(string pallet)
        {
            try
            {
                sqlControl.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_Pack_ReprintPallet", sqlControl.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pallet", pallet);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    code = reader["Código"].ToString();
                    variety = reader["Variedad"].ToString();
                    distributor = reader["Distribuidor"].ToString();
                    boxes = reader["Cajas"].ToString();
                    pounds = reader["Libras"].ToString();
                    presentation = reader["Presentación"].ToString();
                    datePacking = Convert.ToDateTime(reader["Fecha"]).ToString("yyyy-MM-dd");
                    lote = reader["Lote"].ToString();

                }
                sqlControl.CloseConectionWrite();
            }catch (Exception ex) { 
            
                MessageBox.Show(ex.Message);
            }
        }
    }
}
