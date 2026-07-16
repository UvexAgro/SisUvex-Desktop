using System.Data;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods;
using System.Data.SqlClient;
using SisUvex.Catalogos.Metods.Querys;
using System.Media;
using SisUvex.Catalogos.Metods.CheckBoxes;
using SisUvex.Catalogos.Metods.Values;

namespace SisUvex.Nomina.Prices.Prices
{
    internal class ClsPrices
    {
        SQLControl sql = new SQLControl();
        ClsControls controlList;
        private FrmPricesAdd _frmAdd;
        public FrmPricesCat _frmCat;
        public EPrices ePrice;
        private string queryCatalogo = $"SELECT id_price AS '{ClsObject.Column.id}', v_descriptionPrice AS '{ClsObject.Price.ColumnName}', n_priceFieldNormal AS 'Campo', n_priceFieldOver 'Campo extra', n_priceFacilityNormal AS 'Empaque', n_priceFacilityOver AS 'Empaque extra' FROM Pack_Price";
        public DataTable dtCatalogo;

        public ClsPrices()
        {
            _frmCat = new FrmPricesCat(this);

            _frmAdd = new FrmPricesAdd(_frmCat, this);
        }
        public void BeginFormCat()
        {
            dtCatalogo = ClsQuerysDB.GetDataTable(queryCatalogo);

            _frmCat.dgvCatalog.DataSource = dtCatalogo;
        }
        public void OpenFrmAdd()
        {
            _frmAdd = new FrmPricesAdd(_frmCat, this);
            _frmAdd.Text = "Añadir precio";
            _frmAdd.lblTitle.Text = "Añadir precio";
            _frmAdd.IsAddModify = true;

            _frmAdd.ShowDialog();
        }
        public void btnAcceptAddModify()
        {
            if (!controlList.ValidateControls())
                return;

            if (_frmAdd.IsAddModify)
                AddProcedure();
            else
                ModifyProcedure();

            if (_frmAdd.AddIsUpdate)
            {
                BeginFormCat(); //AQUI ESTE SOLO PORQUE LO UNICO QUE HACE ES ACTUALIZAR EL DATAGRIDVIEW
                _frmAdd.Close();
            }
        }
        public void OpenFrmModify()
        {
            if (_frmCat.dgvCatalog.SelectedRows.Count != 0)
            {
                _frmAdd = new FrmPricesAdd(_frmCat, this);
                _frmAdd.Text = "Modificar precio";
                _frmAdd.lblTitle.Text = "Modificar precio";
                _frmAdd.IsAddModify = false;

                _frmAdd.idModify = _frmCat.dgvCatalog.SelectedRows[0].Cells[ClsObject.Column.id].Value.ToString();

                _frmAdd.ShowDialog();
            }
            else
                SystemSounds.Exclamation.Play();
        }
        public void BeginFormAdd()
        {
            AddControlsToList();

            //SetControls(); //EN ESTE FORMULARIO NO APLICA

            if (_frmAdd.IsAddModify)
            {
                _frmAdd.txbId.Text = ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX(id_price), 0) + 1, '00') FROM Pack_Price").ToString();
            }
            else
            {
                LoadControlsModify();
            }



            if (_frmAdd.AddIsUpdate)
                BeginFormCat(); //AQUI ESTE SOLO PORQUE LO UNICO QUE HACE ES ACTUALIZAR EL DATAGRIDVIEW
        }
        private void AddControlsToList()
        {
            controlList = new ClsControls();

            controlList.ChangeHeadMessage("Para dar de alta un precio debe:\n");

            controlList.Add(_frmAdd.txbDescription, "Escribir una descripción al precio.");
        }
        private void LoadControlsModify()
        {
            ePrice = new EPrices();

            ePrice.SetPrice(_frmAdd.idModify);

            _frmAdd.txbId.Text = ePrice.idPrice;
            _frmAdd.txbDescription.Text = ePrice.description;
            _frmAdd.nudPriceFacilityNormal.Value = ePrice.priceFacilityNormal;
            _frmAdd.nudPriceFacilityOver.Value = ePrice.priceFacilityOver;
            _frmAdd.nudPriceFieldNormal.Value = ePrice.priceFieldNormal;
            _frmAdd.nudPriceFieldOver.Value = ePrice.priceFieldOver;
        }
        public void AddProcedure()
        {
            try
            {
                string id = string.Empty;

                // Suscribir al evento InfoMessage
                sql.cnn.InfoMessage += (sender, e) => {
                    foreach (SqlError info in e.Errors)
                    {
                        id += info.Message + Environment.NewLine;
                    }
                };

                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackPriceAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descriptionPrice", _frmAdd.txbDescription.Text);
                cmd.Parameters.AddWithValue("@priceFieldNormal", _frmAdd.nudPriceFieldNormal.Text);
                cmd.Parameters.AddWithValue("@priceFieldOver", _frmAdd.nudPriceFieldOver.Text);
                cmd.Parameters.AddWithValue("@priceFacilityNormal", _frmAdd.nudPriceFacilityNormal.Text);
                cmd.Parameters.AddWithValue("@priceFacilityOver", _frmAdd.nudPriceFacilityOver.Text);
                cmd.Parameters.AddWithValue("@userCreate", User.GetUserName());

                _frmAdd.AddIsUpdate = true;

                cmd.ExecuteScalar();

                MessageBox.Show("Se agregó el precio: " + id.Trim(), "Catálogo añadir", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                SqlCommand cmd = new SqlCommand("sp_PackPriceModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPrice", _frmAdd.txbId.Text);
                cmd.Parameters.AddWithValue("@descriptionPrice", _frmAdd.txbDescription.Text);
                cmd.Parameters.AddWithValue("@priceFieldNormal", _frmAdd.nudPriceFieldNormal.Text);
                cmd.Parameters.AddWithValue("@priceFieldOver", _frmAdd.nudPriceFieldOver.Text);
                cmd.Parameters.AddWithValue("@priceFacilityNormal", _frmAdd.nudPriceFacilityNormal.Text);
                cmd.Parameters.AddWithValue("@priceFacilityOver", _frmAdd.nudPriceFacilityOver.Text);
                cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());

                _frmAdd.AddIsUpdate = true;

                cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo modifiar");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
    }
}