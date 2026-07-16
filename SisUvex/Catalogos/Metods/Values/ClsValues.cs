using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Catalogos.Metods.Values
{
    internal class ClsValues
    {
        public static object IfEmptyToDBNull(string? texto)
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
			// Separar formato en parte entera y decimal
			string[] formatParts = formatZeros.Split('.');
			int lengthInt = formatParts[0].Length;
			int lengthDecimal = formatParts.Length > 1 ? formatParts[1].Length : 0;

			// Separar número en parte entera y decimal
			string[] numberParts = numberString.Split('.');
			string partInt = numberParts[0].PadLeft(lengthInt, '0');

			string partDecimal = "";

			if (lengthDecimal > 0)
			{
				partDecimal = numberParts.Length > 1
					? numberParts[1].PadRight(lengthDecimal, '0')
					: "".PadRight(lengthDecimal, '0');
			}

			// Construir resultado
			return lengthDecimal > 0
				? partInt + "." + partDecimal
				: partInt;
		}

		// Reemplaza el método TryGetDecimal por una versión corregida y más flexible
		public static decimal? TryGetDecimal(object? value)
        {
            if (value == null)
                return null;

            string strValue = value.ToString();
            if (!string.IsNullOrWhiteSpace(strValue) && decimal.TryParse(strValue, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
                return result;

            return null;
        }

        public static object GetDecimalOrNullDB(object? value)
        {
            if (value == null)
                return DBNull.Value;

            string strValue = value.ToString();
            if (string.IsNullOrWhiteSpace(strValue))
                return DBNull.Value;

            if (decimal.TryParse(strValue, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
                return result;

            return DBNull.Value;
        }

        public static string ToTitleCase(string? text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            return textInfo.ToTitleCase(text.ToLower());
        }
    }
}
