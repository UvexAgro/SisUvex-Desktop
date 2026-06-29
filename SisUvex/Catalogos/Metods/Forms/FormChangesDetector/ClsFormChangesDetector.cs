using MathNet.Numerics.Distributions;
using SisUvex.Cuadro_de_herramientas;
using System;
using System.Windows.Forms;

namespace SisUvex.Catalogos.Metods.Forms.FormChangesDetector
{
    internal class ClsFormChangesDetector
    {
        private readonly Form _form;

        /// <summary>
        /// Indica si el formulario tiene cambios pendientes.
        /// </summary>
        public bool HasChanges { get; private set; }

        /// <summary>
        /// Indica si el formulario ya fue guardado.
        /// </summary>
        public bool Saved { get; private set; }

        public ClsFormChangesDetector(Form form)
        {
            _form = form;
        }

        /// <summary>
        /// Aplica la detección de cambios a todos los controles del formulario.
        /// Llamar una sola vez, después de cargar los datos.
        /// </summary>
        public void ApplyDetectControlsChanges()
        {
            ApplyDetectControlsChanges(_form);

            // Reinicia el estado ya que cargar los datos puede disparar eventos.
            ResetChanges();
        }

        private void ApplyDetectControlsChanges(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                SubscribeControl(control);

                if (control.HasChildren)
                    ApplyDetectControlsChanges(control);
            }
        }

        private void SubscribeControl(Control control)
        {
            switch (control)
            {
                case TextBox txt:
                    txt.TextChanged -= ControlChanged;
                    txt.TextChanged += ControlChanged;
                    break;

                case ComboBox cbo:
                    cbo.SelectedIndexChanged -= ControlChanged;
                    cbo.SelectedIndexChanged += ControlChanged;
                    break;

                case CheckBox chk: //APLICA PARA TOGGLEBUTTON
                    chk.CheckedChanged -= ControlChanged;
                    chk.CheckedChanged += ControlChanged;
                    break;

                case RadioButton rb:
                    rb.CheckedChanged -= ControlChanged;
                    rb.CheckedChanged += ControlChanged;
                    break;

                case DateTimePicker dtp:
                    dtp.ValueChanged -= ControlChanged;
                    dtp.ValueChanged += ControlChanged;
                    break;

                case NumericUpDown num:
                    num.ValueChanged -= ControlChanged;
                    num.ValueChanged += ControlChanged;
                    break;

                case DataGridView dgv:
                    dgv.CellValueChanged -= DataGridViewChanged;
                    dgv.RowsAdded -= DataGridViewRowsChanged;
                    dgv.RowsRemoved -= DataGridViewRowsChanged;

                    dgv.CellValueChanged += DataGridViewChanged;
                    dgv.RowsAdded += DataGridViewRowsChanged;
                    dgv.RowsRemoved += DataGridViewRowsChanged;
                    break;

                    // Agrega aquí tus controles personalizados
                    // case ToggleButton tgl:
                    //     tgl.CheckedChanged -= ControlChanged;
                    //     tgl.CheckedChanged += ControlChanged;
                    //     break;
            }
        }

        private void ControlChanged(object? sender, EventArgs e)
        {
            HasChanges = true;
            Saved = false;
        }

        private void DataGridViewChanged(object? sender, DataGridViewCellEventArgs e)
        {
            HasChanges = true;
            Saved = false;
        }

        private void DataGridViewRowsChanged(object? sender, EventArgs e)
        {
            HasChanges = true;
            Saved = false;
        }

        /// <summary>
        /// Reinicia el estado del detector.
        /// </summary>
        public void ResetChanges()
        {
            HasChanges = false;
            Saved = false;
        }

        /// <summary>
        /// Marca el formulario como guardado.
        /// </summary>
        public void MarkSaved()
        {
            HasChanges = false;
            Saved = true;
        }

        /// <summary>
        /// Devuelve si existen cambios pendientes.
        /// </summary>
        public bool HasPendingChanges()
        {
            return HasChanges;
        }

        /// <summary>
        /// Si existen cambios pregunta al usuario si desea continuar.
        /// Devuelve true si puede continuar.
        /// </summary>
        public bool AskIfHasChanges(
            string message = "Hay cambios sin guardar.\n\n¿Deseas continuar?",
            string title = "Cambios sin guardar")
        {
            if (!HasChanges)
                return true;

            return MessageBox.Show(
                message,
                title,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }
    }
}