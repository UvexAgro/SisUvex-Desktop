using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SisUvex.Catalogos.Nomina.LOAD
{
    internal class ClsNomina
    {
        SQLControl sql = new SQLControl();

        public DataTable CboIDComedor()
        {
            DataTable ds = new DataTable();

            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter("SELECT id_dinerProvider AS 'Código', CONCAT(id_dinerProvider,' | ', v_nameDinerProvider) AS 'Nombre' FROM Nom_DinerProvider", sql.cnn);
                da.Fill(ds);
                sql.CloseConectionWrite();
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo listado variedad");
                return ds;
            }
            finally
            {
                sql.CloseConectionWrite();
            }

        }
        public string FormatoCeros(string numeroString, string formato)
        {
            if (decimal.TryParse(numeroString, out decimal numeroDecimal))
            {
                string formatoLimpio = formato.Replace(".", string.Empty);
                int numeroEntero = (int)numeroDecimal;
                int longitudCeros = formatoLimpio.Length - numeroEntero.ToString().Length;

                string resultado = numeroEntero.ToString("D" + longitudCeros);
                if (formato.Contains("."))
                {
                    resultado += formato.Substring(formato.IndexOf("."));
                }

                return resultado;
            }
            else
            {
                throw new ArgumentException("El valor ingresado no es un número válido.");
            }
        }
    }
}
