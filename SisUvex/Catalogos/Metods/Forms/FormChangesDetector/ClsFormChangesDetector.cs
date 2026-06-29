using MathNet.Numerics.Distributions;
using SisUvex.Cuadro_de_herramientas;
using System;
using System.Windows.Forms;

namespace SisUvex.Catalogos.Metods.Forms.FormChangesDetector
{
    internal class ClsFormChangesDetector
    {
        private readonly Form _form;
        private readonly HashSet<Control> _subscribedControls = new();

        public bool HasChanges { get; private set; }
        public bool Saved { get; private set; }

        public ClsFormChangesDetector(Form form)
        {
            _form = form;
        }

        public void ApplyDetectControlsChanges()
        {
            ApplyDetectControlsChangesInternal(_form.Controls, onlyControls: null, exceptControls: null);
            ResetChanges();
        }

        public void ApplyDetectControlsChangesOnly(params Control[] controls)
        {
            ApplyDetectControlsChangesInternal(_form.Controls, onlyControls: controls.ToHashSet(), exceptControls: null);
            ResetChanges();
        }

        public void ApplyDetectControlsChangesExcept(params Control[] controls)
        {
            ApplyDetectControlsChangesInternal(_form.Controls, onlyControls: null, exceptControls: controls.ToHashSet());
            ResetChanges();
        }

        private void ApplyDetectControlsChangesInternal(
            Control.ControlCollection controls,
            HashSet<Control>? onlyControls,
            HashSet<Control>? exceptControls)
        {
            foreach (Control control in controls)
            {
                bool apply =
                    (onlyControls == null || onlyControls.Contains(control)) &&
                    (exceptControls == null || !exceptControls.Contains(control));

                if (apply)
                    SubscribeControl(control);

                if (control.HasChildren)
                    ApplyDetectControlsChangesInternal(control.Controls, onlyControls, exceptControls);
            }
        }

        private void SubscribeControl(Control control)
        {
            if (_subscribedControls.Contains(control))
                return;

            switch (control)
            {
                case TextBox txt:
                    txt.TextChanged += ControlChanged;
                    break;

                case RichTextBox rtxt:
                    rtxt.TextChanged += ControlChanged;
                    break;

                case MaskedTextBox mtxt:
                    mtxt.TextChanged += ControlChanged;
                    break;

                case ComboBox cbo:
                    cbo.SelectedIndexChanged += ControlChanged;
                    cbo.TextChanged += ControlChanged;
                    break;

                case CheckBox chk:
                    chk.CheckedChanged += ControlChanged;
                    break;

                case RadioButton rb:
                    rb.CheckedChanged += ControlChanged;
                    break;

                case CheckedListBox clb:
                    clb.ItemCheck += CheckedListBoxChanged;
                    break;

                case DateTimePicker dtp:
                    dtp.ValueChanged += ControlChanged;
                    break;

                case NumericUpDown num:
                    num.ValueChanged += ControlChanged;
                    break;

                case DomainUpDown domain:
                    domain.SelectedItemChanged += ControlChanged;
                    domain.TextChanged += ControlChanged;
                    break;

                case ListBox list:
                    list.SelectedIndexChanged += ControlChanged;
                    break;

                case DataGridView dgv:
                    dgv.CellValueChanged += DataGridViewChanged;
                    dgv.RowsAdded += DataGridViewRowsChanged;
                    dgv.RowsRemoved += DataGridViewRowsChanged;
                    dgv.UserDeletedRow += DataGridViewRowsChanged;
                    dgv.CurrentCellDirtyStateChanged += DataGridViewDirtyChanged;
                    break;

                case FlowLayoutPanel:
                    break;

                case Button:
                    break;
            }

            _subscribedControls.Add(control);
        }

        private void ControlChanged(object? sender, EventArgs e)
        {
            MarkChanged();
        }

        private void CheckedListBoxChanged(object? sender, ItemCheckEventArgs e)
        {
            MarkChanged();
        }

        private void DataGridViewChanged(object? sender, DataGridViewCellEventArgs e)
        {
            MarkChanged();
        }

        private void DataGridViewRowsChanged(object? sender, EventArgs e)
        {
            MarkChanged();
        }

        private void DataGridViewDirtyChanged(object? sender, EventArgs e)
        {
            if (sender is DataGridView dgv && dgv.IsCurrentCellDirty)
                dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void MarkChanged()
        {
            HasChanges = true;
            Saved = false;
        }

        public bool HasPendingChanges()
        {
            return HasChanges;
        }

        public void ResetChanges()
        {
            HasChanges = false;
            Saved = false;
        }

        public void MarkSaved()
        {
            HasChanges = false;
            Saved = true;
        }

        public bool AskIfHasChanges(
            string message = "Hay cambios sin guardar.\n\n¿Deseas continuar sin guardar?",
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