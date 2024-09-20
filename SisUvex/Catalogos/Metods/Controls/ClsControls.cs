using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Catalogos.Metods.Controls
{
    internal class ClsControls
    {
        private List<(Control control, string message)> controls = new List<(Control control, string message)>();
        private string errorMessage = "Error al ejecutar el formulario, hacen falta lo siguiente:";

        public void Add(Control control, string message)
        {
            controls.Add((control, message));
        }

        public void ChangeHeadMessage(string message)
        {
            errorMessage = message;
        }

        public bool ValidateControls()
        {
            bool isValid = true;
            string showMessage = string.Empty;
            foreach (var (control, message) in controls)
            {
                if (control is TextBox textBox)
                {
                    if (string.IsNullOrEmpty(textBox.Text.Trim()))
                    {
                        isValid = false;
                        showMessage += "\n    " + message;

                    }
                }
                else if (control is ComboBox comboBox)
                {
                    if (comboBox.SelectedIndex == -1 || comboBox.Text == ClsObject.String.SelectText)
                    {
                        isValid = false;
                        showMessage += "\n    " + message;
                    }
                }
                else if (control is DateTimePicker dateTimePicker)
                {
                    if (dateTimePicker.Value == DateTimePicker.MinimumDateTime)
                    {
                        isValid = false;
                        showMessage += "\n    " + message;
                    }
                }
                // Add more control types if needed
            }

            if (!isValid)
            {
                MessageBox.Show(errorMessage + showMessage , "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isValid;
        }
    }
}
