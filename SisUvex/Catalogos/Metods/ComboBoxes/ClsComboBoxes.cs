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
            dt.DefaultView.RowFilter = $"{ClsObject.Column.active} = '1'";

            LoadComboBoxDataSource(comboBox, dt);
        }

        public static void CboLoadAll(ComboBox comboBox, string tableNameDB)
        {
            DataTable dt = GetCboCatalogDataTable(tableNameDB);

            LoadComboBoxDataSource(comboBox, dt);
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

        public static void CboSelectIndexWithTextInValueMember(ComboBox cbo, string ValueMemberText)
        {
            if (cbo.DataSource != null && ValueMemberText != string.Empty)
            {
                DataTable dt = (DataTable)cbo.DataSource;
                string columnNameValueMember = cbo.ValueMember;

                if (dt.Columns.Contains(ClsObject.Column.active))
                {
                    dt.DefaultView.RowFilter = $"{columnNameValueMember} = '{ValueMemberText}' OR {ClsObject.Column.active} = '1'";
                }

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

        public static void CboApplyEventCboSelectedValueChangedWithCboDependensColumn(ComboBox cbo, List<Tuple<ComboBox, CheckBox?>> cboFilterCboDependens, string columnFilterName, TextBox idTextBox)
        {
            cbo.SelectedValueChanged += (sender, e) =>
            {
                if (cbo.SelectedIndex > 0)
                {
                    foreach (var item in cboFilterCboDependens)
                    {
                        ComboBox dependentCbo = item.Item1;
                        CheckBox? filterCheckBox = item.Item2;

                        DataTable? dt = (DataTable?)dependentCbo.DataSource;
                        if (dt != null)
                        {
                            if (filterCheckBox == null || !filterCheckBox.Checked)
                                dt.DefaultView.RowFilter = $"{columnFilterName} = '{cbo.SelectedValue}' AND {ClsObject.Column.active} = '1' OR {ClsObject.Column.name} = '{textSelect}'";
                            else
                                dt.DefaultView.RowFilter = $"{columnFilterName} = '{cbo.SelectedValue}' OR {ClsObject.Column.name} = '{textSelect}'";

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

                idTextBox.Text = cbo.SelectedValue?.ToString();
            };
        }

        public static void CboApplyChbClickEventWithCboDependensColumn(ComboBox comboBox, CheckBox checkBox, string columnFilterName, TextBox textBoxIdFilter)
        {
            checkBox.Click += (sender, e) =>
            {
                DataTable dt = (DataTable)comboBox.DataSource;

                if (!textBoxIdFilter.Text.IsNullOrEmpty())
                {
                    if (checkBox.Checked)
                        dt.DefaultView.RowFilter = $"{columnFilterName} = '{textBoxIdFilter.Text}' OR {ClsObject.Column.name} = '{textSelect}'";
                    else
                        dt.DefaultView.RowFilter = $"{columnFilterName} = '{textBoxIdFilter.Text}' AND {ClsObject.Column.active} = '1' OR {ClsObject.Column.name} = '{textSelect}'";
                }
                else
                {
                    if (checkBox.Checked)
                        dt.DefaultView.RowFilter = null;
                    else
                        dt.DefaultView.RowFilter = $"{ClsObject.Column.active} = '1'";
                }

                comboBox.DataSource = dt;
                comboBox.SelectedIndex = 0;
                comboBox.DroppedDown = true;
            };
        }
    }
}
