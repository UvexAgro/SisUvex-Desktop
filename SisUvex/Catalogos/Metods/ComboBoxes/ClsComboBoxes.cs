using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Presentation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Catalogos.Metods.ComboBoxes
{
    internal class ClsComboBoxes : ClsComboBoxFiles//: ClsColumnName : ClsTableName
    {
        public static string textSelect = "---Seleccionar---";
        public static void LoadComboBoxDataSource(ComboBox comboBox, DataTable dt)
        {
            DataRow defaultRow = dt.NewRow();
            defaultRow[ClsObject.Column.name] = textSelect;
            defaultRow[ClsObject.Column.id] = string.Empty;
            if (dt.Columns.Contains(ClsObject.Column.active))
                defaultRow[ClsObject.Column.active] = "1";

            dt.Rows.InsertAt(defaultRow, 0);

            comboBox.DataSource = dt;
            comboBox.DisplayMember = ClsObject.Column.name;
            comboBox.ValueMember = ClsObject.Column.id;

            comboBox.SelectedIndex = 0;
        }
        public static void CboLoadActives(ComboBox comboBox, string tableNameDB)
        {
            DataTable dt = GetCboCatalogDataTable(tableNameDB);

            if (dt.Rows.Count == 0)
                return;

            if (dt.Columns.Contains(ClsObject.Column.active))
                dt.DefaultView.RowFilter = $"{ClsObject.Column.active} = '1'";

            LoadComboBoxDataSource(comboBox, dt);
        }

        public static void CboLoadAll(ComboBox comboBox, string tableNameDB)
        {
            DataTable dt = GetCboCatalogDataTable(tableNameDB);

            if (dt.Rows.Count == 0)
                return;

            LoadComboBoxDataSource(comboBox, dt);
        }

        public static void CboLoadAllWithoutTextSelect(ComboBox comboBox, string keyName)
        {
            DataTable dt = GetCboCatalogDataTable(keyName);

            if (dt.Rows.Count == 0)
                return;

            comboBox.DataSource = dt;
            comboBox.DisplayMember = ClsObject.Column.name;
            comboBox.ValueMember = ClsObject.Column.id;
        }

        public static void CboApplyTextChangedEvent(ComboBox comboBox, TextBox textBox)
        {
            comboBox.TextChanged += (sender, e) =>
            {
                textBox.Text = comboBox.SelectedValue?.ToString();
            };

            comboBox.SelectedValueChanged += (sender, e) =>
            {
                textBox.Text = comboBox.SelectedValue?.ToString();
            };
        }
        public static void CboApplyClickEvent(ComboBox comboBox, CheckBox checkBox)
        {
            checkBox.Click += (sender, e) =>
            {
                DataTable dt = (DataTable)comboBox.DataSource;

                if (checkBox.Checked)
                {
                    dt.DefaultView.RowFilter = null;
                }
                else
                {
                    if (dt.Columns.Contains(ClsObject.Column.active))           
                        dt.DefaultView.RowFilter = $"{ClsObject.Column.active} = '1'";
                }

                comboBox.DataSource = dt;
                comboBox.SelectedIndex = 0;
                comboBox.DroppedDown = true;
            };
        }

        public static void CboSelectIndexWithTextInValueMember(ComboBox cbo, TextBox txbValueMember)
        {
            CboSelectIndexWithTextInValueMember(cbo, txbValueMember.Text);
        }

        public static void CboSelectIndexWithTextInValueMember(ComboBox cbo, string? ValueMemberText)
        {
            try
            {
                if (cbo.DataSource == null || cbo.Items.Count == 0)
                {
                    cbo.SelectedIndex = -1;
                    return;
                }

                if (string.IsNullOrEmpty(ValueMemberText))
                {
                    cbo.SelectedIndex = 0;
                    return;
                }

                DataTable dt = (DataTable)cbo.DataSource;
                string columnNameValueMember = cbo.ValueMember;

                if (dt.Columns.Contains(ClsObject.Column.active))
                {
                    dt.DefaultView.RowFilter = $"{columnNameValueMember} = '{ValueMemberText}' OR {ClsObject.Column.active} = '1'";
                }

                bool encontrado = false;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][columnNameValueMember].ToString() == ValueMemberText)
                    {
                        string valorBuscado = dt.Rows[i][ClsObject.Column.name].ToString();
                        int indice = cbo.FindStringExact(valorBuscado);

                        if (indice != -1)
                        {
                            cbo.SelectedIndex = indice;
                            encontrado = true;
                            break;
                        }
                    }
                }

                if (!encontrado)
                    cbo.SelectedIndex = cbo.Items.Count > 0 ? 0 : -1;
            }
            catch (Exception ex)
            {
                cbo.SelectedIndex = -1;
            }
        }

        public static void CboSelectIndexWithTextInValueMemberKeepingFilter(ComboBox cbo, string ValueMemberText)
        {
            if (cbo.DataSource != null && ValueMemberText != string.Empty)
            {
                DataTable dt = (DataTable)cbo.DataSource;
                string columnNameValueMember = cbo.ValueMember;

                if (!string.IsNullOrEmpty(dt.DefaultView.RowFilter))
                    dt.DefaultView.RowFilter += $" OR {columnNameValueMember} = '{ValueMemberText}' ";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][columnNameValueMember].ToString() == ValueMemberText)
                    {
                        string valorBuscado = dt.Rows[i][ClsObject.Column.name].ToString();

                        int indice = cbo.FindStringExact(valorBuscado);

                        if (indice != -1)
                        {
                            cbo.SelectedIndex = indice;
                        }
                    }
                }
            }
        }
        public static void CboSelectIndexWithTextInDisplayMember(ComboBox cbo, string DisplayMemberText)
        {
            if (cbo.DataSource != null && DisplayMemberText != string.Empty)
            {
                DataTable dt = (DataTable)cbo.DataSource;
                string columnNameDisplayMember = cbo.DisplayMember;

                if (dt.Columns.Contains(ClsObject.Column.active))
                {
                    dt.DefaultView.RowFilter = $"{columnNameDisplayMember} = '{DisplayMemberText}' OR {ClsObject.Column.active} = '1'";
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][columnNameDisplayMember].ToString() == DisplayMemberText)
                    {
                        string valorBuscado = dt.Rows[i][ClsObject.Column.name].ToString();

                        int indice = cbo.FindStringExact(valorBuscado);

                        if (indice != -1)
                        {
                            cbo.SelectedIndex = indice;
                        }
                    }
                }
            }
        }

        public static void CboApplyEventCboSelectedValueChangedWithCboDependensColumn(ComboBox cboPrincipal, List<Tuple<ComboBox, CheckBox?, string>> cboFilterCboDependens, TextBox? idTextBox)
        {
            cboPrincipal.SelectedValueChanged += (sender, e) =>
            {
                Metod_CboSelectedValueChangedWithCboDependensColumn(cboPrincipal, cboFilterCboDependens);

                if (idTextBox != null)
                    idTextBox.Text = cboPrincipal.SelectedValue?.ToString();
            };
        }

        public static void Metod_CboSelectedValueChangedWithCboDependensColumn(ComboBox cboPrincipal, List<Tuple<ComboBox, CheckBox?, string>> cboFilterCboDependens, TextBox? idTextBox)
        {
            Metod_CboSelectedValueChangedWithCboDependensColumn(cboPrincipal, cboFilterCboDependens);

            if (idTextBox != null)
                idTextBox.Text = cboPrincipal.SelectedValue?.ToString();
        }

        public static void Metod_CboSelectedValueChangedWithCboDependensColumn(ComboBox cboPrincipal, List<Tuple<ComboBox, CheckBox?, string>> cboFilterCboDependens)
        {
            if (cboPrincipal.SelectedIndex > 0)
            {
                foreach (var item in cboFilterCboDependens)
                {
                    ComboBox dependentCbo = item.Item1;
                    CheckBox? filterCheckBox = item.Item2;
                    string columnFilterName = item.Item3;

                    DataTable? dt = (DataTable?)dependentCbo.DataSource;
                    if (dt != null)
                    {
                        if (filterCheckBox == null || !filterCheckBox.Checked)
                            dt.DefaultView.RowFilter = $"{columnFilterName} = '{cboPrincipal.SelectedValue}' AND {ClsObject.Column.active} = '1' OR {ClsObject.Column.name} = '{textSelect}'";
                        else
                            dt.DefaultView.RowFilter = $"{columnFilterName} = '{cboPrincipal.SelectedValue}' OR {ClsObject.Column.name} = '{textSelect}'";

                        dependentCbo.DataSource = dt;
                        dependentCbo.SelectedIndex = 0;
                    }
                }
            }
            else
            {
                foreach (var item in cboFilterCboDependens)
                {
                    ComboBox dependentCbo = item.Item1;
                    CheckBox? filterCheckBox = item.Item2;

                    DataTable? dt = (DataTable?)dependentCbo.DataSource;
                    if (dt != null)
                    {
                        if (filterCheckBox == null || !filterCheckBox.Checked)
                            dt.DefaultView.RowFilter = null;
                        else
                            dt.DefaultView.RowFilter = $"{ClsObject.Column.active} = '1'";

                        dependentCbo.DataSource = dt;
                        dependentCbo.SelectedIndex = 0;
                    }
                }
            }
        }

        public static void CboApplyEventCboSelectedValueChangedWithCboDependensColumnTemplates(ComboBox cboPrincipal, Dictionary<ComboBox, string> dicCboDependends, TextBox? txbId)
        {
            cboPrincipal.SelectedValueChanged += (sender, e) =>
            {
                Metod_CboSelectedValueChangedWithCboDependensColumnTemplates(cboPrincipal, dicCboDependends, txbId);
            };
        }

        public static void Metod_CboSelectedValueChangedWithCboDependensColumnTemplates(ComboBox cboPrincipal, Dictionary<ComboBox, string> dicCboDependends, TextBox? txbId)
        {
            if (cboPrincipal.SelectedItem == null) return;

            // Si el ComboBox principal está en el índice 0, todos los dependientes también se ponen en 0
            if (cboPrincipal.SelectedIndex == 0)
            {
                if (txbId != null)
                    txbId.Text = string.Empty; // Limpia el TextBox

                foreach (var cmbDepended in dicCboDependends.Keys)
                {
                    cmbDepended.SelectedIndex = 0; // Reinicia los ComboBox secundarios
                }
                return; // Sale de la función
            }

            // Obtener la fila seleccionada del ComboBox principal
            DataRowView selectedRow = cboPrincipal.SelectedItem as DataRowView;

            if (selectedRow != null)
            {
                // Asignar el ID seleccionado al TextBox
                if (txbId != null)
                    txbId.Text = selectedRow[cboPrincipal.ValueMember].ToString();

                // Actualizar los ComboBox dependientes
                foreach (var kvp in dicCboDependends)
                {
                    ComboBox cmbSecundario = kvp.Key;
                    string column = kvp.Value;

                    // Verificar si la columna existe en la fila seleccionada
                    if (selectedRow.Row.Table.Columns.Contains(column))
                    {
                        object value = selectedRow[column]; // Obtener el valor correspondiente
                        CboSelectIndexWithTextInValueMember(cmbSecundario, value.ToString() ?? "");
                        //cmbSecundario.SelectedValue = value; // Seleccionar el valor en el ComboBox dependiente
                    }
                }
            }
        }
        public static void CboApplyChbClickEventWithCboDependensColumn(ComboBox comboBoxDependent, CheckBox checkBox, string columnFilterName, TextBox textBoxIdFilter)
        {
            checkBox.Click += (sender, e) =>
            {
                Metod_CboApplyChbClickEventWithCboDependensColumn(comboBoxDependent, checkBox, columnFilterName, textBoxIdFilter.Text);
            };
        }
        public static void CboApplyChbClickEventWithCboDependensColumn(ComboBox comboBoxDependent, CheckBox checkBox, string columnFilterName, ComboBox comboBoxPrincipal)
        {
            checkBox.Click += (sender, e) =>
            {
                Metod_CboApplyChbClickEventWithCboDependensColumn(comboBoxDependent, checkBox, columnFilterName, comboBoxPrincipal.SelectedValue?.ToString());
            };
        }
        public static void Metod_CboApplyChbClickEventWithCboDependensColumn(ComboBox comboBoxDependent, CheckBox checkBox, string columnFilterName, string? idFilter)
        {
            DataTable? dt = (DataTable?)comboBoxDependent.DataSource;

            if (dt == null)
                return;

            if (!idFilter.IsNullOrEmpty())
            {
                if (checkBox.Checked)
                    dt.DefaultView.RowFilter = $"[{columnFilterName}] = '{idFilter}' OR [{ClsObject.Column.name}] = '{textSelect}'";
                else
                    dt.DefaultView.RowFilter = $"{columnFilterName} = '{idFilter}' AND {ClsObject.Column.active} = '1' OR {ClsObject.Column.name} = '{textSelect}'";
            }
            else
            {
                if (checkBox.Checked)
                    dt.DefaultView.RowFilter = null;
                else
                    dt.DefaultView.RowFilter = $"{ClsObject.Column.active} = '1'";
            }

            comboBoxDependent.DataSource = dt;
            comboBoxDependent.SelectedIndex = 0;
            comboBoxDependent.DroppedDown = true;
        }
    }
}
