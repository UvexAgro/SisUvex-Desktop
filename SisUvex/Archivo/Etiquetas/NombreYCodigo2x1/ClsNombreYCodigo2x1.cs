using SisUvex.Catalogos;
using SisUvex.Configuracion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Archivo.Etiquetas.NombreYCodigo2x1
{
    internal class ClsNombreYCodigo2x1 : ClsCatalogos
    {


        SQLControl sql = new SQLControl();
        private string? _impresoraNombre = null;

        public bool DatosEmpleado (ref Label lblNombre, ref Label lblApellido, ref Label lblApellido2, ref TextBox txbIdEmpleado)
        {            
            try
            {
                sql.OpenConectionWrite();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand($"SELECT id_employee AS 'Código', v_lastNamePat AS 'Apellido', v_lastNameMat AS 'Apellido2', v_name AS 'Nombre' FROM Nom_Employees WHERE id_employee = @codigo", sql.cnn);
                cmd.Parameters.AddWithValue("@codigo", txbIdEmpleado.Text);

                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    lblNombre.Text = rd["Nombre"].ToString();

                    lblApellido.Text = rd["Apellido"].ToString();

                    lblApellido2.Text = rd["Apellido2"].ToString();

                    txbIdEmpleado.Text = FormatoCeros(rd["Código"].ToString(),"000000");

                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Datos del empleado");
                return false;
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public string ImprimirSuperString(string codigo, int cantidad, string nombre, string apellido, string apellido2)
        {
            string superString = "";
            cantidad = (int)Math.Ceiling(cantidad / 2.0);

            for (int i = 0; i < cantidad; i++)
            {
                string print = $"^XA\r\n" +
                    $"^FX QR izquierdo.\r\n" +
                    $"^FO40,35^BY2,2.0,10^BQN,2,5^FD230{codigo}^FS\r\n" +
                    $"^FO35,155^FD{codigo}^FS\r\n" +
                    $"\r\n" +
                    $"^FX Nombre izquierdo.\r\n" +
                    $"^CF0,30\r\n" +
                    $"^FO185,70^FD{nombre}^FS\r\n" +
                    $"^FO185,110^FD{apellido}^FS\r\n" +
                    $"^FO185,110^FD{apellido2}^FS\r\n" +
                    $"\r\n" +
                    $"^FX QR derecho\r\n" +
                    $"^FO490,35^BY2,2.0,10^BQN,2,5^FD230{codigo}^FS\r\n" +
                    $"^FO485,155^FD{codigo}^FS\r\n" +
                    $"\r\n" +
                    $"^FX Nombre derecho\r\n" +
                    $"^CF0,30\r\n" +
                    $"^FO620,50^FD{nombre}^FS\r\n" +
                    $"^FO620,90^FD{apellido}^FS\r\n" +
                    $"^FO620,130^FD{apellido2}^FS\r\n" +
                    $"^XZ\r\n";

                superString += print;
            }
            return superString;
        }

        public void ImprimirCajaEmpleado(string codigo, int cantidad, string nombre, string apellido, string apellido2)
        {
            if (ClsConfPrinter.PrintCode.Length > 0)
            {
                RawPrinterHelper.SendStringToPrinter(ClsConfPrinter.PrintCode, ImprimirSuperString(codigo, cantidad, nombre, apellido, apellido2));
            }
            else
            {
                MessageBox.Show("No se ha seleccionado una impresora", "Impresora no seleccionada");
            }
           
        }
    }
}
