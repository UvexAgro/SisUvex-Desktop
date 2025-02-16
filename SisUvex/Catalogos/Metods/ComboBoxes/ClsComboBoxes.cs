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
    }
}
