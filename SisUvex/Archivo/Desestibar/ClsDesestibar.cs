using System.Data;
using System.Data.SqlClient;
using SisUvex.Archivo.Etiquetas.LabelInterface;
using SisUvex.Catalogos;
using SisUvex.Catalogos.Metods.Querys;

namespace SisUvex.Archivo.Desestibar
{
    internal class ClsDesestibar
    {
        SQLControl sql = new SQLControl();

        public DataTable BuscarEstiba(string idEstiba)
        {   
            string qry = " SELECT Pallet, Mix, Estiba, Programa, Cajas, Contenedor, Libras, Tamaño, Pre, Presentación, Pos, Variedad, Distribuidor, Manifiesto, Rack, Fecha, Lote ,[Libras Pallet] , gtn.i_palletBoxes AS 'Cajas por pallet' FROM vw_PackPalletCon vpal LEFT JOIN gtn ON gtn.id_GTIN = vpal.Programa WHERE Estiba =  @idEstiba ";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@idEstiba", idEstiba);
            return ClsQuerysDB.ExecuteParameterizedQuery(qry, parameters);
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

        public string SearchPalletStowage(string idPallet)
        {
            string qry = " SELECT c_stowage FROM Pack_Pallet WHERE id_pallet = @idPallet ";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@idPallet", idPallet);
            return ClsQuerysDB.GetStringExecuteParameterizedQuery(qry, parameters);
        }
    }
}
