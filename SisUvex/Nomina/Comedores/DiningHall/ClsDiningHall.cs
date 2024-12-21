using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Presentacion;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.CheckBoxes;
using System.Media;

namespace SisUvex.Nomina.Comedores.DiningHall
{
    internal class ClsDiningHall
    {
        /// <summary>
        /// ESTA CLS NO TIENE EL _frmAdd = new FrmAdd(this); EN EL CONSTRUCTOR
        /// </summary>

        SQLControl sql = new SQLControl();
        ClsControls controlList;
        private FrmDiningHallAdd _frmAdd;
        public FrmDiningHallCat _frmCat;
        public EDiningHall eDiningHall;
        public ClsDataGridViewCatalogs dgv = new ClsDataGridViewCatalogs();
        private string queryCatalogo = $"SELECT dhl.[c_active] AS '{ClsObject.Column.active}' ,dhl.[id_dinningHall] AS '{ClsObject.Column.id}' ,dhl. [v_nameDiningHall] AS '{ClsObject.Column.name}' ,dpr.v_nameDinerProvider AS 'Comedor' FROM [SisUvex].[dbo].[Nom_DiningHall] dhl JOIN Nom_DinerProvider dpr ON dpr.id_dinerProvider = dhl.id_dinerProvider";
        public DataTable dtCatalogo;
        public DataTable dtCatalogoActivos;

        public ClsDiningHall()
        {
            _frmCat = new FrmDiningHallCat();
            _frmCat.cls = this;
        }

        public void BeginFormCat()
        {
            dgv.queryCatalog = queryCatalogo;
            dgv.dgvCatalog = _frmCat.dgvCatalog;
            dgv.btnRemoved = _frmCat.btnRemoved;

            dgv.LoadDataTableCatalog();

            _frmCat.dgvCatalog.DataSource = dgv.GetDataTableCatalogActives();

            ClsDataGridViewCatalogs.DgvApplyCellFormattingEvent(_frmCat.dgvCatalog);
        }

        public void RemoveProcedure()
        {
            dgv.ProcedureRemove("sp_NomDiningHallRemove");
        }

        public void RecoverProcedure()
        {
            dgv.ProcedureRecover("sp_NomDiningHallRecover");
        }

        public void OpenFrmAdd()
        {
            _frmAdd = new FrmDiningHallAdd();
            _frmAdd.cls = this;

            _frmAdd.Text = "Añadir ventanilla comedor";
            _frmAdd.lblTitle.Text = "Añadir Ventanilla";
            _frmAdd.IsAddModify = true;

            _frmAdd.ShowDialog();

            dgv.UpdateCatalogAfterAddModify(_frmAdd.AddIsUpdate);
        }

        public void BeginFormAdd()
        {
            AddControlsToList();

            CargarComboBoxes();

            if (_frmAdd.IsAddModify)
            {
                _frmAdd.chbActive.Checked = true;
                _frmAdd.txbId.Text = ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX(id_dinningHall), 0) +1, '000') FROM Nom_DiningHall").ToString();
            }
            else
            {
                LoadControlsModify();
            }
        }

        private void AddControlsToList()
        {
            controlList = new ClsControls();

            controlList.ChangeHeadMessage("Para dar de alta una ventanilla de comedor debe:\n");

            controlList.Add(_frmAdd.txbName, "Ingresar nombre de la ventanilla.");
            controlList.Add(_frmAdd.txbIdProvider, "Seleccionar un comedor.");
        }

        private void CargarComboBoxes()
        {
            //Cargar proveedores (EN ESTE CASO PARA NO HACER UN DOCUMENTO XML PARA QUE LO GUARDE COMO EN LOS OTROS CATALOGOS POR MIENTRAS SE ARREGLA LO DEL BYTECONVERTER O ALGO ASI)
            string queryProvider = $"SELECT id_dinerProvider AS '{ClsObject.Column.id}', CONCAT(v_nameDinerProvider, ' | ', id_dinerProvider, ' | (', c_active, ')') AS '{ClsObject.Column.name}', c_active AS '{ClsObject.Column.active}' FROM Nom_DinerProvider ORDER BY '{ClsObject.Column.name}'";

            DataTable dtProvider = ClsQuerysDB.GetDataTable(queryProvider);
            
            dtProvider.DefaultView.RowFilter = $"{ClsObject.Column.active} = '1'";

            ClsComboBoxes.LoadComboBoxDataSource(_frmAdd.cboProvider, dtProvider);

            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboProvider, _frmAdd.txbIdProvider);

            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboProvider, _frmAdd.chbProvider);
        }

        private void LoadControlsModify()
        {
            eDiningHall = new EDiningHall();

            eDiningHall.SetDiningHall(_frmAdd.idModify);

            _frmAdd.txbId.Text = eDiningHall.IdDiningHall;
            _frmAdd.txbName.Text = eDiningHall.NameDiningHall;
            _frmAdd.txbIdProvider.Text = eDiningHall.IdDinerProvider;
            _frmAdd.chbActive.Checked = eDiningHall.Active == 1;

            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboProvider, _frmAdd.txbIdProvider);
        }

        public void btnAcceptAddModify()
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

        public void AddProcedure()
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_NomDiningHallAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", _frmAdd.txbName.Text);
                cmd.Parameters.AddWithValue("@idProvider", _frmAdd.txbIdProvider.Text);
                cmd.Parameters.AddWithValue("@userCreate", User.GetUserName());
                cmd.Parameters.AddWithValue("@active", ClsCheckBoxes.GetCheckedValue(_frmAdd.chbActive));

                string id = cmd.ExecuteScalar().ToString();

                MessageBox.Show("Se agregó el comedor: " + id, "Catálogo añadir", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                SqlCommand cmd = new SqlCommand("sp_NomDiningHallModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", _frmAdd.txbId.Text);
                cmd.Parameters.AddWithValue("@name", _frmAdd.txbName.Text);
                cmd.Parameters.AddWithValue("@idProvider", _frmAdd.txbIdProvider.Text);
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

        public void OpenFrmModify()
        {
            if (_frmCat.dgvCatalog.SelectedRows.Count != 0)
            {
                _frmAdd = new FrmDiningHallAdd();
                _frmAdd.cls = this;

                _frmAdd.Text = "Modificar ventanilla comedor";
                _frmAdd.lblTitle.Text = "Modificar Ventanilla";
                _frmAdd.IsAddModify = false;

                _frmAdd.idModify = _frmCat.dgvCatalog.SelectedRows[0].Cells[ClsObject.Column.id].Value.ToString();

                _frmAdd.ShowDialog();

                dgv.UpdateCatalogAfterAddModify(_frmAdd.AddIsUpdate);
            }
            else
            {
                SystemSounds.Exclamation.Play();
            }
        }
    }
}