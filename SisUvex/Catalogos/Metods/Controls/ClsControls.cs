﻿using System;
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
                    if (textBox.Tag == null)
                    {
                        if (string.IsNullOrEmpty(textBox.Text.Trim()))
                        {
                            isValid = false;
                            showMessage += "\n    " + message;
                        }
                    }
                    else if (textBox.Tag?.ToString() == "integerNoEmpty")
                    {
                        if (string.IsNullOrEmpty(textBox.Text.Trim()) || !int.TryParse(textBox.Text, out _))
                        {
                            isValid = false;
                            showMessage += "\n    " + message;
                        }
                    }
                    else if (textBox.Tag?.ToString() == "integerEmpty")
                    {
                        if (!int.TryParse(textBox.Text, out _))
                        {
                            isValid = false;
                            showMessage += "\n    " + message;
                        }
                    }
                    else if (textBox.Tag?.ToString() == "decimalNoEmpty")
                    {
                        if (string.IsNullOrEmpty(textBox.Text.Trim()) || !decimal.TryParse(textBox.Text, out _))
                        {
                            isValid = false;
                            showMessage += "\n    " + message;
                        }
                    }
                    else if (textBox.Tag?.ToString() == "decimalEmpty")
                    {
                        if (!decimal.TryParse(textBox.Text, out _) && !string.IsNullOrEmpty(textBox.Text))
                        {
                            isValid = false;
                            showMessage += "\n    " + message;
                        }
                    }
                }
                else if (control is ComboBox comboBox)
                {
                    if (comboBox.Tag == null)
                    {
                        if (comboBox.SelectedIndex == -1 || comboBox.Text == ClsObject.String.SelectText)
                        {
                            isValid = false;
                            showMessage += "\n    " + message;
                        }
                    }
                    else
                    {
                        if (comboBox.Tag.ToString() == "text")
                        {
                            if (string.IsNullOrEmpty(comboBox.Text))
                            {
                                isValid = false;
                                showMessage += "\n    " + message;
                            }
                        }
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
                else if (control is NumericUpDown numericUpDown)
                {
                    if (numericUpDown.Value == 0)
                    {
                        isValid = false;
                        showMessage += "\n    " + message;
                    }
                }
                else if (control is MaskedTextBox maskedTextBox && maskedTextBox.Tag?.ToString() == "fourInts")
                {
                    if (maskedTextBox.Text.Length != 4 || !maskedTextBox.Text.All(char.IsDigit))
                    {
                        isValid = false;
                        showMessage += "\n    " + message;
                    }
                }
                else if (control is CheckBox checkBox)
                {
                    if (!checkBox.Checked)
                    {
                        isValid = false;
                        showMessage += "\n    " + message;
                    }
                }
                else if (control is DataGridView dataGridView)
                {
                    if (dataGridView.Rows.Count == 0 || dataGridView.Rows.Cast<DataGridViewRow>().All(row => row.IsNewRow))
                    {
                        isValid = false;
                        showMessage += "\n    " + message;
                    }
                }
                // Add more control types if needed
            }

            if (!isValid)
            {
                MessageBox.Show(errorMessage + showMessage, "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isValid;
        }
    }
}
