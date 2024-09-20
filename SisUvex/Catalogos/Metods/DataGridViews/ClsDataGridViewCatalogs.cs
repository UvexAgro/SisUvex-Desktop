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
        public DataTable dtCatalog;
        public DataTable dtCatalogActives;
        public DataGridView dgvCatalog;
        public Button btnRemoved;
        public string queryCatalog;

        SQLControl sql = new SQLControl();

        public void DeleteInDataTable(string id)
        {
            DataRow[] rows = dtCatalog.Select($"{ClsObject.Column.id} = '{id}'");
            if (rows.Length > 0)
            {
                rows[0][ClsObject.Column.active] = "0";
            }
            dtCatalog.AcceptChanges();
        }

        public void RecoverInDataTable(string id)
        {
            DataRow[] rows = dtCatalog.Select($"{ClsObject.Column.id} = '{id}'");
            if (rows.Length > 0)
            {
                rows[0][ClsObject.Column.active] = "1";
            }
            dtCatalog.AcceptChanges();
        }

        public bool IsActive()
        {
            if (dgvCatalog.SelectedRows.Count > 0)
            {
                return "1" == dgvCatalog.SelectedRows[0].Cells[ClsObject.Column.active].Value.ToString();
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
                if (row[ClsObject.Column.active].ToString() == "1")
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
                if (row[ClsObject.Column.active].ToString() == "1")
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
                    string id = dgvCatalog.SelectedRows[0].Cells[ClsObject.Column.id].Value.ToString();

                    try
                    {
                        sql.OpenConectionWrite();
                        SqlCommand cmd = new SqlCommand(procedureName, sql.cnn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());

                        cmd.ExecuteNonQuery();

                        dgvCatalog.SelectedRows[0].Cells[ClsObject.Column.active].Value = "1";

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
                    string id = dgvCatalog.SelectedRows[0].Cells[ClsObject.Column.id].Value.ToString();

                    try
                    {
                        sql.OpenConectionWrite();
                        SqlCommand cmd = new SqlCommand(procedureName, sql.cnn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());

                        cmd.ExecuteNonQuery();

                        dgvCatalog.SelectedRows[0].Cells[ClsObject.Column.active].Value = "0";

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
            dataGridView.CellFormatting += (sender, e) =>
            {
                if (dataGridView.Columns[e.ColumnIndex].Name == ClsObject.Column.active)
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
