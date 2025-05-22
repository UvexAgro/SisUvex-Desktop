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
        public static void TxbApplyKeyPressEventInt(TextBox textBox)
        {
            textBox.KeyPress += (sender, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            };

            // Validar al pegar texto (Ctrl+V)
            textBox.TextChanged += (sender, e) =>
            {
                if (string.IsNullOrEmpty(textBox.Text))
                    return;

                // Si no es un número válido, eliminar caracteres no numéricos
                if (!int.TryParse(textBox.Text, out _))
                {
                    string cleanedText = new string(textBox.Text.Where(char.IsDigit).ToArray());
                    textBox.Text = cleanedText;
                    textBox.SelectionStart = textBox.Text.Length;
                }
            };
        }
        public static void TxbApplyKeyPressEventDecimal(TextBox textBox)
        {
            textBox.KeyPress += (sender, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

                // Solo permitir un punto decimal
                if (e.KeyChar == '.' && (sender as TextBox).Text.Contains('.'))
                {
                    e.Handled = true;
                }
            };

            // Validar al pegar texto (Ctrl+V)
            textBox.TextChanged += (sender, e) =>
            {
                if (string.IsNullOrEmpty(textBox.Text))
                    return;

                // Si no es un decimal válido, limpiar el texto
                if (!decimal.TryParse(textBox.Text, out _))
                {
                    // Permitir solo un punto y números
                    var sb = new StringBuilder();
                    bool hasDecimalPoint = false;

                    foreach (char c in textBox.Text)
                    {
                        if (char.IsDigit(c))
                        {
                            sb.Append(c);
                        }
                        else if (c == '.' && !hasDecimalPoint)
                        {
                            sb.Append(c);
                            hasDecimalPoint = true;
                        }
                    }

                    string cleanedText = sb.ToString();
                    if (cleanedText != textBox.Text)
                    {
                        int cursorPos = textBox.SelectionStart;
                        textBox.Text = cleanedText;
                        textBox.SelectionStart = Math.Min(cursorPos, cleanedText.Length);
                    }
                }
            };
        }
        public static void TxbApplyKeyPressEventNumericWithLimit(TextBox textBox, int maxIntDigits, int maxDecimalDigits)
        {
            textBox.KeyPress += (sender, e) =>
            {
                // Permitir solo dígitos, punto decimal y teclas de control (Backspace, etc.)
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true;
                    return;
                }

                // Evitar múltiples puntos decimales
                if (e.KeyChar == '.' && textBox.Text.Contains('.'))
                {
                    e.Handled = true;
                    return;
                }

                // Obtener el texto actual y la posición del cursor
                string currentText = textBox.Text;
                int selectionStart = textBox.SelectionStart;

                // Simular el nuevo texto que se generaría
                string newText = currentText.Substring(0, selectionStart)
                               + e.KeyChar
                               + currentText.Substring(selectionStart + textBox.SelectionLength);

                // Validar estructura del número
                string[] parts = newText.Split('.');

                // Validar parte entera
                if (parts[0].Length > maxIntDigits)
                {
                    e.Handled = true;
                    return;
                }

                // Validar parte decimal si existe
                if (parts.Length > 1 && parts[1].Length > maxDecimalDigits)
                {
                    e.Handled = true;
                }
            };

            // Validación al pegar texto
            textBox.TextChanged += (sender, e) =>
            {
                if (string.IsNullOrEmpty(textBox.Text)) return;

                // Verificar si el texto es un número válido
                if (!decimal.TryParse(textBox.Text, out decimal _))
                {
                    // Limpiar caracteres no válidos manteniendo el formato numérico
                    var sb = new StringBuilder();
                    bool hasDecimalPoint = false;

                    foreach (char c in textBox.Text)
                    {
                        if (char.IsDigit(c))
                        {
                            sb.Append(c);
                        }
                        else if (c == '.' && !hasDecimalPoint)
                        {
                            sb.Append(c);
                            hasDecimalPoint = true;
                        }
                    }

                    string cleanedText = sb.ToString();
                    if (cleanedText != textBox.Text)
                    {
                        int cursorPos = textBox.SelectionStart;
                        textBox.Text = cleanedText;
                        textBox.SelectionStart = Math.Min(cursorPos, cleanedText.Length);
                    }
                }

                // Validar límites después de limpieza
                string[] parts = textBox.Text.Split('.');

                // Truncar parte entera si excede el límite
                if (parts[0].Length > maxIntDigits)
                {
                    parts[0] = parts[0].Substring(0, maxIntDigits);
                    textBox.Text = parts.Length > 1 ? $"{parts[0]}.{parts[1]}" : parts[0];
                    textBox.SelectionStart = textBox.Text.Length;
                }

                // Truncar parte decimal si excede el límite
                if (parts.Length > 1 && parts[1].Length > maxDecimalDigits)
                {
                    parts[1] = parts[1].Substring(0, maxDecimalDigits);
                    textBox.Text = $"{parts[0]}.{parts[1]}";
                    textBox.SelectionStart = textBox.Text.Length;
                }
            };

            // Validación al perder el foco (opcional)
            textBox.Validating += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(textBox.Text) && !decimal.TryParse(textBox.Text, out _))
                {
                    textBox.Text = "";
                }
            };
        }

    }
}
