using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Values;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Archivo.Etiquetas.PrintLabels
{
    internal  class ClsReprintPallet
    {
        public static void ReprintPalletTag(string idPallet, int copies, bool reverseOrientation, bool showDate)
        {
            string workPlan;
            SQLControl sql = new SQLControl();
            int palletBoxes;

            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT [Plan de Trabajo], Cajas FROM vw_PackPalletCon WHERE Pallet = @idPallet", sql.cnn);
                cmd.Parameters.AddWithValue("@idPallet", idPallet);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    workPlan = reader[0].ToString();
                    palletBoxes = Convert.ToInt32(reader[1].ToString());
                }
                else
                {
                    MessageBox.Show("No se encontró el pallet", "Error");
                    return;
                }

                ETagInfo eTagInfo = new ETagInfo();
                eTagInfo.SetTagInfo(workPlan);

                eTagInfo.showDate = !showDate; //MOSTRAR U OCULTAR FECHA DEL PALLET

                ClsPrintPtiTag print = new();
                print.SendToPrintPalletTag(idPallet, eTagInfo, copies, palletBoxes, reverseOrientation, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
