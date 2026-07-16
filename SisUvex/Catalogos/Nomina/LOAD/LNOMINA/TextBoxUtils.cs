using System;
using System.Windows.Forms;

namespace SisUvex.Catalogos.Nomina.LOAD.LNOMINA
{
    internal static class TextBoxUtils
    {
        public static void LimitarDigitosYCompletarCeros(TextBox textBox, int digitos)
        {
            textBox.KeyPress += (sender, e) =>
            {
                // Verificar si la tecla presionada no es un número y no es la tecla Backspace
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                {
                    e.Handled = true; // Ignorar la tecla presionada
                }
            };

            textBox.LostFocus += (sender, e) =>
            {
                // Obtener el contenido del TextBox
                string contenido = textBox.Text;

                // Verificar si la longitud es menor a digitos
                if (contenido.Length < digitos)
                {
                    contenido = contenido.PadLeft(digitos, '0');
                    textBox.Text = contenido;
                }
            };
        
        }
    }
}
