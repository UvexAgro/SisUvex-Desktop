using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Catalogos.Metods.TextBoxes
{
    internal class ClsTextBoxes
    {
        public static void DgvApplyCellFormattingEvent(DataGridView dataGridView)
        {
            dataGridView.CellFormatting += (sender, e) =>
            {
                if (dataGridView.Columns[e.ColumnIndex].Name == ClsObject.Column.active)
                {
                    if (e.Value.ToString() == "0")
                    {
                        e.CellStyle.BackColor = System.Drawing.Color.Tomato;
                        e.CellStyle.ForeColor = System.Drawing.Color.Red;
                    }
                    if (e.Value.ToString() == "1")
                    {
                        e.CellStyle.BackColor = System.Drawing.Color.LightGreen;
                        e.CellStyle.ForeColor = System.Drawing.Color.Green;
                    }
                }
            };
        }

        public static void TxbApplyKeyPressEventInt(TextBox textBox)
        {
            textBox.KeyPress += (sender, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            };
        }
        public static void TxbApplyKeyPressEventDecimal(TextBox textBox)
        {
            textBox.KeyPress += (sender, e) =>
            {
                if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
                {
                    e.Handled = true;
                    return;
                }

                if (e.KeyChar == 46)
                {
                    if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                        e.Handled = true;

                }
            };
        }
        public static void TxbApplyKeyPressEventNumericWithLimit(TextBox textBox, int maxInt, int maxDecimal)
        {
            textBox.KeyPress += (sender, e) =>
            {
                // Si el carácter no es un control, dígito o punto decimal, lo rechaza
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true;
                    return;
                }

                // Si el carácter es un punto decimal y ya hay un punto decimal en el TextBox, lo rechaza
                if (e.KeyChar == '.' && textBox.Text.Contains('.'))
                {
                    e.Handled = true;
                    return;
                }

                // Dividir el texto en la parte entera y decimal
                string[] parts = textBox.Text.Split('.');

                // Si hay más de una parte decimal, no permitir más caracteres decimales
                if (parts.Length > 1 && e.KeyChar == '.')
                {
                    e.Handled = true;
                    return;
                }

                // Limitar la longitud de la parte decimal
                if (parts.Length == 2 && parts[1].Length >= maxDecimal && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                    return;
                }

                // Validar la longitud de la parte entera y del número completo
                if (!char.IsControl(e.KeyChar))
                {
                    string newText = textBox.Text.Insert(textBox.SelectionStart, e.KeyChar.ToString());
                    string[] newParts = newText.Split('.');

                    // Verificar que la parte entera no exceda el tamaño máximo
                    if (newParts[0].Length > maxInt)
                    {
                        e.Handled = true;
                        return;
                    }

                    // Verificar que el número completo no exceda el tamaño total permitido (incluyendo punto decimal y decimales)
                    if (newText.Length > maxInt + maxDecimal + 1)
                    {
                        e.Handled = true;
                        return;
                    }
                }
            };
        }

    }
}
