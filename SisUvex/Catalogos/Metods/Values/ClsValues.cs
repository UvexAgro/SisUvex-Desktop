using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Catalogos.Metods.Values
{
    internal class ClsValues
    {
        public static object IfEmptyToDBNull(string texto)
        {//SI EL VALOR ES NULL O EMPTY, ENTONCES AGREGA UN NULL EN LA BASE DE DATOS (PARA CUANDO LA COLUMNA ACEPTE NULO)
            return string.IsNullOrEmpty(texto) ? DBNull.Value : (object)texto;
        }
        public static string IfEmptyToZero(string texto)
        {//SI EL VALOR ES NULL O EMPTY, ENTONCES AGREGA 0 DEVUELVE (PARA CUANDO SE OCUPE AL MENOS UN NUMERO ENTERO)
            return string.IsNullOrEmpty(texto) ? "0" : texto;
        }
        public static string RemoveTrailingZeros(string input)
        {
            // Convertir el string a decimal
            if (decimal.TryParse(input, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal number))
            {
                // Convertir el decimal a string eliminando ceros innecesarios
                return number.ToString(CultureInfo.InvariantCulture).TrimEnd('0').TrimEnd('.');
            }
            else
            {
                // Si la conversión falla, devolver el string original o manejar el error
                return input;
            }
        }
        public static string FormatZeros(string numberString, string formatZeros)
        {
            string formatClean = formatZeros.Replace(".", string.Empty);

            string[] parts = formatClean.Split('.');
            int lengthInt = parts[0].Length;
            int lengthDecimal = parts.Length > 1 ? parts[1].Length : 0;

            string[] numeros = numberString.Split('.');
            string partiInt = numeros[0].PadLeft(lengthInt, '0');
            string partDecimal = numeros.Length > 1 ? numeros[1].PadRight(lengthDecimal, '0') : string.Empty;

            string result = partiInt;

            if (lengthDecimal > 0)
            {
                result += "." + partDecimal;
            }

            return result;
        }
    }
}
