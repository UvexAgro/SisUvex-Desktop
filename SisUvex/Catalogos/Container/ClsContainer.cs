using SisUvex.Catalogos.Metods.CheckBoxes;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Presentacion;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.Querys;
using System.Windows.Forms;

namespace SisUvex.Catalogos.Container
{
    internal class ClsContainer : ClsCatalogos
    {
        SQLControl sql = new SQLControl();
        ClsControls controlList;
        public FrmContainerAdd _frmAdd;
        public FrmContainerCat _frmCat;
        public EContainer eContainer;
        public ClsDataGridViewCatalogs dgv = new ClsDataGridViewCatalogs();
        private string queryCatalogo = "SELECT * FROM vw_PackContainerCat";
        public DataTable dtCatalogo;
        public DataTable dtCatalogoActivos;

        public ClsContainer()
        {
            _frmCat = new FrmContainerCat(this);

            _frmAdd = new FrmContainerAdd(_frmCat, this);
        }
        public void BeginFormAdd()
        {
            AddControlsToList();

            if (_frmAdd.IsAddModify)
            {
                _frmAdd.chbActive.Checked = true;
                _frmAdd.txbId.Text = ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX(id_container), 0) +1, '0000') FROM Pack_Container").ToString();
            }
            else
            {
                LoadControlsModify();
            }
        }

        public void BeginFormCat()
        {
            dgv.queryCatalog = queryCatalogo;
            dgv.dgvCatalog = _frmCat.dgvCatalog;
            dgv.btnRemoved = _frmCat.btnRemoved;

            dgv.LoadDataTableCatalog();

            _frmCat.dgvCatalog.DataSource = dgv.GetDataTableCatalogActives();
        }

        private void AddControlsToList()
        {
            controlList = new ClsControls();

            controlList.ChangeHeadMessage("Para dar de alta un contenedor debe:\n");

            controlList.Add(_frmAdd.txbName, "Ingresar nombre del contenedor.");
        }

        public void OpenFrmAdd()
        {
            _frmAdd = new FrmContainerAdd(_frmCat, this);
            _frmAdd.IsAddModify = true;
            _frmAdd.Text = "Añadir Contenedor";
            _frmAdd.lblTitle.Text = "Añadir Contenedor";

            _frmAdd.ShowDialog();

            dgv.UpdateCatalogAfterAddModify(_frmAdd.AddIsUpdate);
        }

        public void OpenFrmModify()
        {
            if (_frmCat.dgvCatalog.SelectedRows.Count != 0)
            {
                _frmAdd = new FrmContainerAdd(_frmCat, this);
                _frmAdd.IsAddModify = false;
                _frmAdd.Text = "Modificar Contenedor";
                _frmAdd.lblTitle.Text = "Modificar Contenedor";

                _frmAdd.idContainerModify = _frmCat.dgvCatalog.SelectedRows[0].Cells[ClsObject.Column.id].Value.ToString();

                _frmAdd.ShowDialog();

                dgv.UpdateCatalogAfterAddModify(_frmAdd.AddIsUpdate);
            }
            else
            {
                SystemSounds.Exclamation.Play();
            }
        }

        private void LoadControlsModify()
        {
            eContainer = new EContainer();

            eContainer.SetContainer(_frmAdd.idContainerModify);

            _frmAdd.txbId.Text = eContainer.IdContainer;
            _frmAdd.txbName.Text = eContainer.NameContainer;
            _frmAdd.chbActive.Checked = eContainer.Active == 1;
        }

        public void AddProcedure()
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackContainerAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", _frmAdd.txbName.Text);
                cmd.Parameters.AddWithValue("@userCreate", User.GetUserName());
                cmd.Parameters.AddWithValue("@active", ClsCheckBoxes.GetCheckedValue(_frmAdd.chbActive));

                string id = cmd.ExecuteScalar().ToString();

                MessageBox.Show("Se agregó el contenedor: " + id, "Catálogo añadir", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public void ModifyProcedure()
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackContainerModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", _frmAdd.txbId.Text);
                cmd.Parameters.AddWithValue("@name", _frmAdd.txbName.Text);
                cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());
                cmd.Parameters.AddWithValue("@active", ClsCheckBoxes.GetCheckedValue(_frmAdd.chbActive));

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

        public void RemoveProcedure()
        {
            dgv.ProcedureRemove("sp_PackContainerRemove");
        }

        public void RecoverProcedure()
        {
            dgv.ProcedureRecover("sp_PackContainerRecover");
        }

        public void btnAceptAddModify()
        {
            if (!controlList.ValidateControls())
                return;

            if (_frmAdd.IsAddModify)
            {
                AddProcedure();
            }
            else
            {
                ModifyProcedure();
            }

            _frmAdd.AddIsUpdate = true;

            _frmAdd.Close();
        }
    }
}
