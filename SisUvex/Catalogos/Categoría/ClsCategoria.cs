using SisUvex.Catalogos.Presentacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DocumentFormat.OpenXml.Office2010.CustomUI;
using System.Media;

namespace SisUvex.Catalogos.Categoría
{
    internal class ClsCategoria : ClsCatalogos
    {
        SQLControl sql = new SQLControl();
        private FrmCategoriaAñadir frmAdd;
        public FrmCategoriaCat frmCat;
        private bool EsAñadir = true;
        public bool SeActualiza = false;
        private bool EsModificar = false;
        public ClsCategoria(FrmCategoriaAñadir formulario)
        {
            frmAdd = formulario;
        }
        public ClsCategoria(FrmCategoriaCat formCat)
        {
            frmCat = formCat;
        }
        #region VISTAS CATALOGO
        public void ActualizarCatalogoCategoriaBotonActivosEliminados()
        {
            if (frmCat.btnEliminados.Text == "Eliminados")
            {
                frmCat.dgvCatalogo.DataSource = ObtenerCatalogoConEliminadosCategoriaDataGridView();
                frmCat.btnEliminados.Text = "Activos";
            }
            else
            {
                frmCat.dgvCatalogo.DataSource = ObtenerCatalogoActivosCategoriaDataGridView();
                frmCat.btnEliminados.Text = "Eliminados";
            }
        }

        public void ActualizarCatalogoCategoriaSeleccionado()
        {
            if (frmCat.btnEliminados.Text == "Eliminados")
                frmCat.dgvCatalogo.DataSource = ObtenerCatalogoActivosCategoriaDataGridView();
            else
                frmCat.dgvCatalogo.DataSource = ObtenerCatalogoConEliminadosCategoriaDataGridView();
        }
        public void ActualizarCatalogoCategoriaSeleccionado(DataGridView dgv, string texto)
        {
            if (texto == "Eliminados")
                dgv.DataSource = ObtenerCatalogoActivosCategoriaDataGridView();
            else
                dgv.DataSource = ObtenerCatalogoConEliminadosCategoriaDataGridView();
        }
        public DataTable ObtenerCatalogoActivosCategoriaDataGridView()
        {
            DataTable dt = new DataTable();
            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT c_active AS 'Activo', id_category AS 'Código', v_nameCategory AS 'Categoría' FROM Pack_Category WHERE c_active = '1'", sql.cnn);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo activos");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
            return dt;
        }

        public DataTable ObtenerCatalogoConEliminadosCategoriaDataGridView()
        {
            DataTable dt = new DataTable();
            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT c_active AS 'Activo', id_category AS 'Código', v_nameCategory AS 'Categoría' FROM Pack_Category", sql.cnn);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo activos");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
            return dt;
        }

        #endregion VISTAS CATALOGO END


        public void AbrirFrmCategoriaAñadir()
        {
            frmAdd = new FrmCategoriaAñadir(EsAñadir, frmCat);
            frmAdd.Text = "Añadir Categoría";
            frmAdd.lblTitulo.Text = "Añadir Categoría";
            frmAdd.ShowDialog();

            if (SeActualiza) //Si si se añade se cambia el valor a true
                ActualizarCatalogoCategoriaSeleccionado();
            SeActualiza = false;
        }
        public void AbrirFrmCategoriaModificar()
        {
            if (frmCat.dgvCatalogo.SelectedRows.Count > 0)
            {
                frmAdd = new FrmCategoriaAñadir(EsModificar, frmCat);
                frmAdd.Text = "Modificar Categoría";
                frmAdd.lblTitulo.Text = "Modificar Categoría";
                frmAdd.txbId.Enabled = false;

                //ESTE ASI PARA NO LEER EN BD
                frmAdd.txbId.Text = frmCat.dgvCatalogo.SelectedRows[0].Cells["Código"].Value.ToString();
                frmAdd.txbNombre.Text = frmCat.dgvCatalogo.SelectedRows[0].Cells["Categoría"].Value.ToString();
                frmAdd.cboActivo.SelectedIndex = Convert.ToInt32(frmCat.dgvCatalogo.SelectedRows[0].Cells["Activo"].Value);
                frmAdd.ShowDialog();
            }
            else
            {
                SystemSounds.Exclamation.Play();
            }

            if (SeActualiza)
                ActualizarCatalogoCategoriaSeleccionado();
            SeActualiza = false;
        }
        public void AñadirNuevaCategoria()
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackCategoryAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", frmAdd.txbId.Text.ToUpper());
                cmd.Parameters.AddWithValue("@name", frmAdd.txbNombre.Text);
                cmd.Parameters.AddWithValue("@userCreate", User.GetUserName());
                cmd.Parameters.AddWithValue("@active", frmAdd.cboActivo.SelectedIndex.ToString());
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo añadir");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public void ModificarCategoria()
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackCategoryModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", frmAdd.txbId.Text);
                cmd.Parameters.AddWithValue("@active", frmAdd.cboActivo.SelectedIndex.ToString());
                cmd.Parameters.AddWithValue("@name", frmAdd.txbNombre.Text);
                cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo modificar");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public void EliminarCategoria()
        {
            if (frmCat.dgvCatalogo.SelectedRows.Count > 0)
            {
                if (EsActivo())
                {
                    string id = frmCat.dgvCatalogo.SelectedRows[0].Cells["Código"].Value.ToString();

                    try
                    {
                        sql.OpenConectionWrite();
                        SqlCommand cmd = new SqlCommand("sp_PackCategoryDelete", sql.cnn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());

                        cmd.ExecuteNonQuery();

                        frmCat.dgvCatalogo.CurrentRow.Cells["Activo"].Value = "0";
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
        public void RecuperarCategoria()
        {
            if (frmCat.dgvCatalogo.SelectedRows.Count > 0)
            {
                if (!EsActivo())
                {
                    string id = frmCat.dgvCatalogo.SelectedRows[0].Cells["Código"].Value.ToString();

                    try
                    {
                        sql.OpenConectionWrite();
                        SqlCommand cmd = new SqlCommand("sp_PackCategoryRecover", sql.cnn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());

                        cmd.ExecuteNonQuery();

                        frmCat.dgvCatalogo.CurrentRow.Cells["Activo"].Value = "1";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Catálogo eliminar");
                    }
                    finally
                    {
                        sql.CloseConectionWrite();
                    }
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                }
            }
            else
            {
                SystemSounds.Exclamation.Play();
            }
        }
        public bool ValidarIdCategoria(string idCategoria)
        {
            bool existeIdCategoria = false;
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT COUNT(id_category) FROM Pack_Category WHERE id_category = '{idCategoria}'", sql.cnn);
                int count = (int)cmd.ExecuteScalar();
                existeIdCategoria = count == 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo modificar");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
            return existeIdCategoria;
        }
        public bool EsActivo()
        {//USAR SOLO DESPUÉS DE VALIDAR SI TIENE FILAS
            return "1" == frmCat.dgvCatalogo.SelectedRows[0].Cells["Activo"].Value.ToString();
        }
    }
}
