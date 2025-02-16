using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Win32.SafeHandles;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Querys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Catalogos.Metods.DataGridViews
{
    internal class ClsDataGridViewCatalogs : ClsCatalogos
    {
        //EN UN FUTURO CAMBIARLO POR METERLE EL FILTRO DE UNA NUEVA COLUMNA DE ACTIVOS2 DONDE SE OCULTE ESA COLUMNA Y NO TENER QUE TENER UNA SEGUNDA TABLA PARA EL CATALOGO
        public DataTable dtCatalog;
        public DataTable dtCatalogActives;
        public DataGridView dgvCatalog;
        public Button btnRemoved;
        public string queryCatalog;
        public string idColumn = ClsObject.Column.id;
        public string activeColumn = ClsObject.Column.active;

        SQLControl sql = new SQLControl();

        public void DeleteInDataTable(string id)
        {
            DataRow[] rows = dtCatalog.Select($"{idColumn} = '{id}'");
            if (rows.Length > 0)
            {
                rows[0][activeColumn] = "0";
            }
            dtCatalog.AcceptChanges();
        }

        public void RecoverInDataTable(string id)
        {
            DataRow[] rows = dtCatalog.Select($"{idColumn} = '{id}'");
            if (rows.Length > 0)
            {
                rows[0][activeColumn] = "1";
            }
            dtCatalog.AcceptChanges();
        }

        public bool IsActive()
        {
            if (dgvCatalog.SelectedRows.Count > 0)
            {
                return "1" == dgvCatalog.SelectedRows[0].Cells[activeColumn].Value.ToString();
            }
            return false;
        }

        public void LoadDataTableCatalog()
        {
            dtCatalog = ClsQuerysDB.GetDataTable(queryCatalog);

            LoadDataTableCatalogActives();
        }

        public DataTable GetDataTableCatalogDeletes()
        {
            return dtCatalog;
        }

        public DataTable GetDataTableCatalogActives()
        {
            DataTable dtCatalogoActivos = dtCatalog.Clone();

            foreach (DataRow row in dtCatalog.Rows)
            {
                if (row[activeColumn].ToString() == "1")
                {
                    dtCatalogoActivos.ImportRow(row);
                }
            }

            return dtCatalogoActivos;
        }

        public void UpdateCatalogButtonActivesDeletes()
        {
            if (btnRemoved.Text == "Eliminados")
            {
                dgvCatalog.DataSource = GetDataTableCatalogDeletes();
                btnRemoved.Text = "Activos";
            }
            else
            {
                LoadDataTableCatalogActives();
                dgvCatalog.DataSource = GetDataTableCatalogActives();
                btnRemoved.Text = "Eliminados";
            }
        }

        public void LoadDataTableCatalogActives()
        {
            dtCatalogActives = dtCatalog.Clone();

            foreach (DataRow row in dtCatalog.Rows)
            {
                if (row[activeColumn].ToString() == "1")
                {
                    dtCatalogActives.ImportRow(row);
                }
            }
        }

        public void UpdateCatalogAfterAddModify(bool seActualiza)
        {
            if (seActualiza)
            {
                LoadDataTableCatalog();

                if (btnRemoved.Text == "Eliminados")
                {
                    dgvCatalog.DataSource = GetDataTableCatalogActives();
                }
                else
                {
                    dgvCatalog.DataSource = GetDataTableCatalogDeletes();
                }
            }
        }

        public void ProcedureRecover(string procedureName)
        {
            if (dgvCatalog.SelectedRows.Count > 0)
            {
                if (!IsActive())
                {
                    string id = dgvCatalog.SelectedRows[0].Cells[idColumn].Value.ToString();

                    try
                    {
                        sql.OpenConectionWrite();
                        SqlCommand cmd = new SqlCommand(procedureName, sql.cnn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());

                        cmd.ExecuteNonQuery();

                        dgvCatalog.SelectedRows[0].Cells[activeColumn].Value = "1";

                        RecoverInDataTable(id);
                    }
                    catch (Exception ex)
                    {
                        SystemSounds.Exclamation.Play();
                        MessageBox.Show(ex.ToString(), "Catálogo recuperar");
                    }
                    finally
                    {
                        sql.CloseConectionWrite();
                    }
                }
            }
            else
                SystemSounds.Exclamation.Play();
        }
        public void ProcedureRemove(string procedureName)
        {
            if (dgvCatalog.SelectedRows.Count > 0)
            {
                if (IsActive())
                {
                    string id = dgvCatalog.SelectedRows[0].Cells[idColumn].Value.ToString();

                    try
                    {
                        sql.OpenConectionWrite();
                        SqlCommand cmd = new SqlCommand(procedureName, sql.cnn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());

                        cmd.ExecuteNonQuery();

                        dgvCatalog.SelectedRows[0].Cells[activeColumn].Value = "0";

                        DeleteInDataTable(id);
                    }
                    catch (Exception ex)
                    {
                        SystemSounds.Exclamation.Play();
                        MessageBox.Show(ex.ToString(), "Catálogo eliminar");
                    }
                    finally
                    {
                        sql.CloseConectionWrite();
                    }
                }
            }
            else
                SystemSounds.Exclamation.Play();
        }
        public static void DgvApplyCellFormattingEvent(DataGridView dataGridView)
        {
            DgvApplyCellFormattingEvent(dataGridView, ClsObject.Column.active);
        }

        public static void DgvApplyCellFormattingEvent(DataGridView dataGridView, string activeColumnName)
        {
            dataGridView.CellFormatting += (sender, e) =>
            {
                if (dataGridView.Columns[e.ColumnIndex].Name == activeColumnName)
                {
                    if (e.Value.ToString() == "0")
                    {
                        e.CellStyle.BackColor = System.Drawing.Color.Tomato;
                        e.CellStyle.ForeColor = System.Drawing.Color.Red;
                    }
                    if (e.Value.ToString() == "1")
                    {
                        e.CellStyle.BackColor = System.Drawing.Color.LightGreen;
                        e.CellStyle.ForeColor = System.Drawing.Color.Green;
                    }
                }
            };
        }
    }
}
