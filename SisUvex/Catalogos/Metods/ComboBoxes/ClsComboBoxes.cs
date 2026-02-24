using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2021.Excel.NamedSheetViews;
using DocumentFormat.OpenXml.Presentation;
using MathNet.Numerics.Distributions;
using Microsoft.Extensions.DependencyModel;
using Microsoft.IdentityModel.Tokens;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
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

        public static void CboSelectIndexWithTextInValueMemberKeepingFilter(ComboBox cbo, string? ValueMemberText)
        {
            if (cbo.DataSource != null && !string.IsNullOrEmpty(ValueMemberText))
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

        public class Events()
        {
            /// <summary>
            /// Aplica un filtro a varios ComboBox dependientes basado en la selección de un ComboBox principal. Si el índice seleccionado del ComboBox principal es mayor a 0, se filtran los ComboBox dependientes para mostrar solo los elementos relacionados con la selección del ComboBox principal. Si el índice seleccionado es 0 o menor, se eliminan los filtros y se muestran todos los elementos en los ComboBox dependientes.
            /// </summary>
            public static void CboApplyEventFilterOneForAll(ComboBox comboBoxOnePrincipal, string? idColumnPrincipal, CheckBox? checkBoxPrincipal, List<Tuple<ComboBox, CheckBox?>> comboBoxesList)
            {
                //TERMINAR DE CHECARLO BIEN, EN LO QUE SE HACE EL EVENTO CONTRARIO 
                foreach (var item in comboBoxesList)
                {
                    ComboBox dependentCbo = item.Item1;
                    CheckBox? dependentChb = item.Item2;

                    comboBoxOnePrincipal.SelectedValueChanged += (sender, e) =>
                    {
                        if (comboBoxOnePrincipal.SelectedIndex > 0)
                        {
                            //DataTable? dt = (DataTable?)dependentCbo.DataSource;
                            //if (dt != null)
                            //{
                            //    dt.DefaultView.RowFilter = $" 1=1 {idColumnPrincipal} = '{comboBoxOnePrincipal.SelectedValue}' AND {ClsObject.Column.active} = '1' OR {ClsObject.Column.name} = '{textSelect}'";
                            //    dependentCbo.DataSource = dt;
                            //    dependentCbo.SelectedIndex = 0;
                            //}
                        }
                        else
                        {
                            //DataTable? dt = (DataTable?)dependentCbo.DataSource;
                            //if (dt != null)
                            //{
                            //    dt.DefaultView.RowFilter = null;
                            //    dependentCbo.DataSource = dt;
                            //    dependentCbo.SelectedIndex = 0;
                            //}
                        }
                    };
                }
            }


            /// <summary>
            /// Aplica un filtro a un ComboBox principal basado en la selección de varios ComboBox dependientes. Si el índice seleccionado de cada ComboBox dependiente es mayor a 0, se filtra el ComboBox principal para mostrar solo los elementos relacionados con las selecciones de los ComboBox dependientes. Si el índice seleccionado de algún ComboBox dependiente es 0 o menor, se eliminan los filtros y se muestran todos los elementos en el ComboBox principal.
            /// </summary>
            /// <param name="comboBoxPrincipal"></param>
            /// <param name="checkBoxPrincipal"></param>
            /// <param name="comboBoxesDependents"></param>
            public static void CboApplyEventFilterAllForOne(ComboBox comboBoxPrincipal, CheckBox? checkBoxPrincipal, List<(ComboBox Cbo, string IdColumnFilter)>/*idColumnFilter*/ comboBoxesDependents)
            {
                foreach (var item in comboBoxesDependents) //Aplicarle a cada combobox dependiente el Evento para calcular el filtro al principal por cada cambio en los dependientes
                {
                    ComboBox dependentCbo = item.Cbo;
                    string idColumnFilter = item.IdColumnFilter;

                    //En caso de que ya se haya asignado este evento, se elimina para no duplicarlo
                    EventHandler handler = (s, e) =>
                    {
                        Metods.CboFilterAllForOne(comboBoxPrincipal, checkBoxPrincipal, comboBoxesDependents);
                        comboBoxPrincipal.SelectedIndex = 0;
                    };

                    dependentCbo.SelectedValueChanged -= handler;
                    dependentCbo.SelectedValueChanged += handler;

                    if (checkBoxPrincipal != null) //Aplicar metodos si hay un chb que cambie de valor
                    {
                        checkBoxPrincipal.CheckedChanged -= handler;
                        checkBoxPrincipal.CheckedChanged += handler;
                    }
                }
            }

        }
        public class Metods()
        {
            public static void CboFilterAllForOne(ComboBox comboBoxPrincipal, CheckBox? checkBoxPrincipal, List<(ComboBox Cbo, string IdColumnFilter)>/*idColumnFilter*/ comboBoxesDependents)
            {//EL CboPrincipal NO OCUPA LOS CHECKBOX DE LOS DEMAS, SOLO EL SUYO
                DataTable? dt = (DataTable?)comboBoxPrincipal.DataSource;
                if (dt == null) return;

                string? filter = StringFilterActives_Principal(dt, checkBoxPrincipal);

                foreach (var item in comboBoxesDependents) //Filtro por cada columna de cboDependiente
                {
                    ComboBox dependentCbo = item.Cbo;
                    string idColumnFilter = item.IdColumnFilter;

                    if (dependentCbo.SelectedIndex < 1 || !dt.Columns.Contains(idColumnFilter))
                        continue;

                    if (!string.IsNullOrEmpty(filter))
                        filter += " AND ";

                    filter += $" {idColumnFilter} = '{dependentCbo.SelectedValue}' ";
                }

                if (!string.IsNullOrEmpty(filter)) //Añadir texto seleccion si hay otro filtro por columna
                    filter += $" OR {ClsObject.Column.name} = '{textSelect}' ";
                dt.DefaultView.RowFilter = filter;
            }

            /// <summary>
            ///Aplica un filtro a varios ComboBox dependientes basado en la selección de un ComboBox principal. Si el índice seleccionado del ComboBox principal es mayor a 0, se filtran los ComboBox dependientes para mostrar solo los elementos relacionados con la selección del ComboBox principal. Si el índice seleccionado es 0 o menor, se eliminan los filtros y se muestran todos los elementos en los ComboBox dependientes.
            /// </summary>
            public static void CboFilterOneForAll(ComboBox comboBoxPrincipal, List<Tuple<ComboBox, string, CheckBox?>> comboBoxesDependents)
            {
                if (comboBoxPrincipal.SelectedIndex > 0)
                {
                    foreach (var item in comboBoxesDependents)
                    {
                        ComboBox dependentCbo = item.Item1;
                        string columnFilterName = item.Item2;
                        DataTable? dt = (DataTable?)dependentCbo.DataSource;
                        if (dt != null)
                        {
                            dt.DefaultView.RowFilter = $"{columnFilterName} = '{comboBoxPrincipal.SelectedValue}' AND {ClsObject.Column.active} = '1' OR {ClsObject.Column.name} = '{textSelect}'";
                            dependentCbo.DataSource = dt;
                            dependentCbo.SelectedIndex = 0;
                        }
                    }
                }
                else //Dejar de mostrar filtros / (conservando del cboPrincipal activos o mostrando todos)
                {
                    foreach (var item in comboBoxesDependents)
                    {
                        ComboBox dependentCbo = item.Item1;
                        CheckBox? checkBox = item.Item3;
                        CboActivesFilter(dependentCbo, checkBox);
                    }
                }
            }

            private static void CboActivesFilter(ComboBox cbo, CheckBox? checkBox)
            {
                DataTable? dt = (DataTable?)cbo.DataSource;
                if (dt != null)
                {
                    string? filterActives = StringFilterActives_Principal(dt, checkBox);
                    dt.DefaultView.RowFilter = filterActives;
                    cbo.DataSource = dt;
                    cbo.SelectedIndex = 0;
                }
            }

            private static string? StringFilterActives_Principal(DataTable? dataTable, CheckBox? checkBox)
            {//Si el CheckBox es nulo o el DataTable no tiene la columna de activos, no se aplica ningún filtro y se muestran todos los elementos
             //Intentar dejar antes de aquí el 1 = 1;
                if (checkBox == null || dataTable == null || !dataTable.Columns.Contains(ClsObject.Column.active))
                    return null;

                if (checkBox.Checked)   //Mostrar solo activos '1'
                {
                    string? filterAnd = string.Empty;
                    if (!string.IsNullOrEmpty(dataTable.DefaultView.RowFilter))
                        filterAnd = " AND ";

                    return $"{filterAnd} [{ClsObject.Column.active}] = '1' ";
                }
                else
                    return null;
            }
        }
    }
}