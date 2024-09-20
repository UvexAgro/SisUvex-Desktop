using System.Data;
using System.Data.SqlClient;
using SisUvex.Catalogos;

namespace SisUvex.Archivo.Desestibar
{
    internal class ClsDesestibar
    {
        SQLControl sql = new SQLControl();

        public DataTable BuscarEstiba(string idEstiba)
        {
            DataTable dt = new DataTable();
            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT Pallet, Mix, Estiba, Programa, Cajas, Libras, Tamaño, Presentación, Variedad, Distribuidor, Manifiesto, Rack, Fecha, Lote ,[Libras Pallet] ,Contenedor, gtn.i_palletBoxes AS 'Cajas por pallet' FROM vw_PackPalletCon vpal LEFT JOIN gtn ON gtn.id_GTIN = vpal.Programa WHERE Estiba =  {idEstiba}", sql.cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Destibar estiba");
                return dt;
            }

            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public void ProcDesestibarEstiba(string idEstiba)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackPalletDeleteStowage", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idStowage", idEstiba);
                cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());
                cmd.ExecuteNonQuery();

                MessageBox.Show("Se desestibó la estiba: " + idEstiba);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Mixteada pallet");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public bool EnColumna(DataGridView dataGridView, string nombreColumna)
        {
            int indiceColumna = dataGridView.Columns[nombreColumna].Index;

            foreach (DataGridViewRow fila in dataGridView.Rows)
            {
                if (fila.Cells[indiceColumna].Value != null && fila.Cells[indiceColumna].Value.ToString().Length > 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
