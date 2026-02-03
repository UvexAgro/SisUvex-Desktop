using SisUvex.Catalogos.Metods.ComboBoxes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace SisUvex.Configuracion.Parameters
{
    internal class ClsParameterParser
    {
        //NOMBRE DE DATOS PARA QUE COINCIDA EN LA BASE DE DATOS Y EN EL CÓDIGO
        public const string pText = "Text";
        public const string pInt = "Int";
        public const string pDecimal = "Decimal";
        public const string pDate = "Date";
        public const string pTime = "Time";
        public const string pDateTime = "DateTime";
        public const string pBool = "Bool";
        public static void LoadDataTypeCombo(ComboBox cmbDataType)
        {
            cmbDataType.DataSource = new[]
                    {
                new { Id = "Int",      Name = "Entero",             Hint = "Ej: 123" },
                new { Id = "Text",     Name = "Texto",              Hint = "Cualquier texto" },
                new { Id = "Decimal",  Name = "Con decimales",      Hint = "Ej: 123.45 (usa punto, sin miles)" },
                new { Id = "Date",     Name = "Fecha",              Hint = "Formato: yyyy-MM-dd  (Ej: 2026-01-27)" },
                new { Id = "Time",     Name = "Hora",               Hint = "Formato: HH:mm:ss  (Ej: 04:00:00)" },
                new { Id = "DateTime", Name = "Fecha y hora",       Hint = "Formato: yyyy-MM-dd HH:mm:ss  (Ej: 2026-01-27 09:30:00)" },
                new { Id = "Bool",     Name = "Booleano (Sí/No)",   Hint = "Valores: true/false, 1/0, SI/NO" }
            };

            cmbDataType.DisplayMember = "Name";
            cmbDataType.ValueMember = "Id";
        }
    }
}
