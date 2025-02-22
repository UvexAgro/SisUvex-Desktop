using System.Data.SqlClient;
using System.Data;
using SisUvex.Catalogos;
using SisUvex.Catalogos.Metods.Values;

namespace SisUvex.Archivo.Etiquetas.CajaEmpleado
{
    internal class ClsCajaEmpleado : ClsCatalogos
    {
        SQLControl sql = new SQLControl();
        public string CrearCajaEmpleado(string codigo)
        {
            try
            {
                sql.OpenConectionWrite();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("sp_PackPackedBoxAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idEmployed", ClsValues.FormatZeros(codigo, "000000"));
                cmd.Parameters.AddWithValue("@userCreate", User.GetUserName());

                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //DataTable ds = new DataTable();
                //da.Fill(dt);

                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    return rd["idBox"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Crear caja empleado");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
            return string.Empty;
        }

        public string GetStringZPL(string codigo, string name, string lastNamePat, string lastNameMat, int cantidad)
        {
            string lastNames = string.Join(" ", lastNamePat, lastNameMat);
            string superString = "";
            cantidad = (int)Math.Ceiling(cantidad / 2.0);

            for (int i = 0; i < cantidad; i++)
            {

                string idBox1 = CrearCajaEmpleado(codigo);

                string idBox2 = CrearCajaEmpleado(codigo);

                string print = $"^XA\r\n" +
                    $"^FX QR izquierdo.\r\n" +
                    $"^FO40,35^BY2,2.0,10^BQN,2,5^FD230{idBox1}^FS\r\n" +
                    $"^FO35,155^FD{idBox1}^FS\r\n" +
                    $"\r\n" +
                    $"^FX Nombre izquierdo.\r\n" +
                    $"^CF0,30\r\n" +
                    $"^FO185,70^FD{name}^FS\r\n" +
                    $"^FO185,110^FD{lastNamePat}^FS\r\n" +
                    $"^FO185,110^FD{lastNameMat}^FS\r\n" +
                    $"\r\n" +
                    $"^FX QR derecho\r\n" +
                    $"^FO490,35^BY2,2.0,10^BQN,2,5^FD230{idBox2}^FS\r\n" +
                    $"^FO485,155^FD{idBox2}^FS\r\n" +
                    $"\r\n" +
                    $"^FX Nombre derecho\r\n" +
                    $"^CF0,30\r\n" +
                    $"^FO620,50^FD{name}^FS\r\n" +
                    $"^FO620,90^FD{lastNamePat}^FS\r\n" +
                    $"^FO620,130^FD{lastNameMat}^FS\r\n" +
                    $"^XZ\r\n";

                
                superString += print;
            }
            return superString;
        }
    }
}