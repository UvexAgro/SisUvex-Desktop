﻿using SisUvex.Catalogos;
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

        public DataTable ListadoEmpleados(string nombre)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "  SELECT id_employee AS 'Código', v_lastNamePat AS 'Apellido paterno ', v_lastNameMat AS 'Apellido materno', v_name AS 'Nombre', id_paymentPlace AS 'LP'FROM Nom_Employees";

                if (nombre.Length != 0)
                {
                    query += $" WHERE CONCAT(v_lastNamePat,' ',v_lastNameMat,' ', v_name) LIKE '%{nombre}%'";
                }

                sql.OpenConectionWrite();

                SqlDataAdapter da = new SqlDataAdapter(query, sql.cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo empleados");
                return dt;
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public bool DatosEmpleado (ref Label lblNombre, ref Label lblApellido, ref TextBox txbIdEmpleado)
        {            
            try
            {
                sql.OpenConectionWrite();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand($"SELECT id_employee AS 'Código', CONCAT(v_lastNamePat,' ',v_lastNameMat) AS 'Apellidos', v_name AS 'Nombre' FROM Nom_Employees WHERE id_employee = @codigo", sql.cnn);
                cmd.Parameters.AddWithValue("@codigo", txbIdEmpleado.Text);

                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    lblNombre.Text = rd["Nombre"].ToString();

                    lblApellido.Text = rd["Apellidos"].ToString();


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

        public string ImprimirSuperString(string codigo, int cantidad, string nombre, string apellido)
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
                    $"\r\n" +
                    $"^FX QR derecho\r\n" +
                    $"^FO490,35^BY2,2.0,10^BQN,2,5^FD230{codigo}^FS\r\n" +
                    $"^FO485,155^FD{codigo}^FS\r\n" +
                    $"\r\n" +
                    $"^FX Nombre derecho\r\n" +
                    $"^CF0,30\r\n" +
                    $"^FO620,70^FD{nombre}^FS\r\n" +
                    $"^FO620,110^FD{apellido}^FS\r\n" +
                    $"^XZ\r\n";


                superString += print;
            }
            return superString;
        }

        public void ImprimirCajaEmpleado(string codigo, int cantidad, string nombre, string apellido)
        {
            if (ClsConfPrinter.PrintCode.Length > 0)
            {
                RawPrinterHelper.SendStringToPrinter(ClsConfPrinter.PrintCode, ImprimirSuperString(codigo, cantidad, nombre, apellido));
            }
            else
            {
                MessageBox.Show("No se ha seleccionado una impresora", "Impresora no seleccionada");
            }
           
        }

        /*

        public void GetImpresora()
        {
            StreamReader leer;
            List<string> lista = new List<string>();
            string[] separador = { Environment.NewLine, "=" };
            string printCode = "";
            string pathFile = "C:\\SisUvex\\configPrinter.txt";

            try
            {
                leer = File.OpenText(pathFile);
                string cadenaTexto = leer.ReadToEnd();
                lista = cadenaTexto.Split(separador, StringSplitOptions.RemoveEmptyEntries).ToList();

                for (int i = 0; i < lista.Count - 1; i++)
                {
                    Console.WriteLine(lista[i]);
                    switch (lista[i].Trim())
                    {
                        case "printCode": printCode = lista[i + 1]; break;
                        default:; break;
                    }
                }
                leer.Close();

                _impresoraNombre = printCode;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Read Printers");
            }
        }  
        
        */
    }
}
