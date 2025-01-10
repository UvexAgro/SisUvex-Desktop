using SisUvex.Catalogos.GTIN_UPC;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.CheckBoxes;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using System.Data;
using System.Data.SqlClient;
using SisUvex.Catalogos.Metods.Values;
using System.Media;
using SisUvex.Catalogos.Metods.TextBoxes;
using SisUvex.Catalogos.Metods.Querys;
using static SisUvex.Catalogos.Metods.ClsObject;
using System.Windows.Forms;

namespace SisUvex.Catalogos.GTIN
{
    internal class ClsGTIN : ClsCatalogos
    {
        SQLControl sql = new SQLControl();
        ClsControls controlList;
        private FrmGtinAdd _frmAdd;
        public FrmGtinCat _frmCat;
        public Egtin eGtin;
        private string queryCatalog = $" SELECT vw.*, vw.Activo AS '{Gtin.ColumnActive}' FROM vw_PackGTINCat AS vw ";
        public DataTable dtCatalog;

        public ClsGTIN()
        {
            _frmCat = new FrmGtinCat(this);

            _frmAdd = new FrmGtinAdd(_frmCat, this);
        }
        public void BeginFormCat()
        {
            ClsComboBoxes.CboLoadActives(_frmCat.cboDistributor, Distributor.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboPresentation, Presentation.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboVariety, Variety.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboContainer, ClsObject.Container.Cbo);

            LoadDataGridViewCatalog();

            AjustarEncabezados(_frmCat.dgvCatalog);

            ClsDataGridViewCatalogs.DgvApplyCellFormattingEvent(_frmCat.dgvCatalog);
        }

        public void LoadDataGridViewCatalog()
        {
            dtCatalog = ClsQuerysDB.GetDataTable(SetQueryString());

            _frmCat.dgvCatalog.DataSource = dtCatalog;

            if (!_frmCat.chbRemoved.Checked)
                dtCatalog.DefaultView.RowFilter = $" {Gtin.ColumnActive} = '1' ";

            if (dtCatalog.Columns.Contains(Gtin.ColumnActive))
                _frmCat.dgvCatalog.Columns[Gtin.ColumnActive].Visible = false;
        }

        public string  SetQueryString()
        {
            string query = queryCatalog + " JOIN Pack_GTIN g ON g.id_GTIN = vw.[Código] WHERE 1 = 1 ";

            if (_frmCat.cboDistributor.SelectedIndex > 0)
                query += $" AND g.id_distributor = '{_frmCat.cboDistributor.SelectedValue}' ";

            if (_frmCat.cboPresentation.SelectedIndex > 0)
                query += $" AND g.id_presentation = '{_frmCat.cboPresentation.SelectedValue}'";

            if (_frmCat.cboVariety.SelectedIndex > 0)
                query += $" AND g.id_variety = '{_frmCat.cboVariety.SelectedValue}'";

             
            if (_frmCat.cboContainer.SelectedIndex > 0)
                query += $" AND g.id_container = '{_frmCat.cboContainer.SelectedValue}'";

            return query;
        }
        public void ChbRemovedChecked()
        {
            if (_frmCat.chbRemoved.Checked)
                dtCatalog.DefaultView.RowFilter = null;
            else
                dtCatalog.DefaultView.RowFilter = $" {Column.active} = '1' ";
        }
        public void BtnSearch()
        {
            LoadDataGridViewCatalog();
        }
        public bool IsActive()
        {
            if (_frmCat.dgvCatalog.SelectedRows.Count > 0)
            {
                return "1" == _frmCat.dgvCatalog.SelectedRows[0].Cells[Column.active].Value.ToString();
            }
            return false;
        }
        public void RemoveProcedure()
        {
            if (_frmCat.dgvCatalog.SelectedRows.Count > 0)
            {
                if (IsActive())
                {
                    string id = _frmCat.dgvCatalog.SelectedRows[0].Cells[Column.id].Value.ToString();

                    try
                    {
                        sql.OpenConectionWrite();
                        SqlCommand cmd = new SqlCommand("sp_PackGTINRemove", sql.cnn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());

                        cmd.ExecuteNonQuery();

                        _frmCat.dgvCatalog.SelectedRows[0].Cells[Column.active].Value = "0";
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
        public void RecoverProcedure()
        {
            if (_frmCat.dgvCatalog.SelectedRows.Count > 0)
            {
                if (!IsActive())
                {
                    string id = _frmCat.dgvCatalog.SelectedRows[0].Cells[Column.id].Value.ToString();

                    try
                    {
                        sql.OpenConectionWrite();
                        SqlCommand cmd = new SqlCommand("sp_PackGTINRecover", sql.cnn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());

                        cmd.ExecuteNonQuery();

                        _frmCat.dgvCatalog.SelectedRows[0].Cells[Column.active].Value = "1";
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

        public void OpenFrmAdd()
        {
            _frmAdd = new FrmGtinAdd(_frmCat, this);
            _frmAdd.Text = "Añadir GTIN";
            _frmAdd.lblTitle.Text = "Añadir GTIN";
            _frmAdd.IsAddModify = true;

            _frmAdd.ShowDialog();
        }

        public void BeginFormAdd()
        {
            AddControlsToList();

            SetControls();

            if (_frmAdd.IsAddModify)
            {
                _frmAdd.chbActive.Checked = true;
                _frmAdd.txbId.Text = ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX(id_GTIN), 0) + 1, '00000') FROM Pack_GTIN").ToString();
            }
            else
                LoadControlsModify();
        }
        public void OpenFrmModify()
        {
            if (_frmCat.dgvCatalog.SelectedRows.Count != 0)
            {
                _frmAdd = new FrmGtinAdd(_frmCat, this);
                _frmAdd.Text = "Modificar GTIN";
                _frmAdd.lblTitle.Text = "Modificar GTIN";
                _frmAdd.IsAddModify = false;

                _frmAdd.idModify = _frmCat.dgvCatalog.SelectedRows[0].Cells[Column.id].Value.ToString();

                _frmAdd.ShowDialog();
            }
            else
                SystemSounds.Exclamation.Play();
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
                LoadDataGridViewCatalog();
                _frmAdd.Close();
            }
        }
        private void AddControlsToList()
        {
            controlList = new ClsControls();

            controlList.ChangeHeadMessage("Para dar de alta un GTIN debe:\n");

            controlList.Add(_frmAdd.txbGTINNum, "Ingresar número GTIN.");
            controlList.Add(_frmAdd.txbIdVariety, "Seleccionar una variedad.");
            controlList.Add(_frmAdd.txbIdDistribuitor, "Seleccionar un distribuidor.");
            controlList.Add(_frmAdd.txbIdContainer, "Seleccionar un contenedor.");
            controlList.Add(_frmAdd.txbIdPresentation, "Seleccionar una presentación.");
            controlList.Add(_frmAdd.txbLbs, "Ingresar las libras por caja.");
            controlList.Add(_frmAdd.txbBoxes, "Ingresar las cajas por pallet.");

        }

        private void SetControls()
        {
            ClsComboBoxes.CboLoadActives(_frmAdd.cboDistributor, ClsObject.Distributor.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboContainer, ClsObject.Container.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboPresentation, ClsObject.Presentation.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboVariety, ClsObject.Variety.Cbo);
            ClsComboBoxes.CboLoadAll(_frmAdd.cboColorVariety, ClsObject.Color.Cbo);
            ClsComboBoxes.CboLoadAll(_frmAdd.cboPrice, ClsObject.Price.Cbo);
            ClsComboBoxes.CboLoadAll(_frmAdd.cboPtiTag, ClsObject.Pti.Cbo);

            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboDistributor, _frmAdd.txbIdDistribuitor);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboContainer, _frmAdd.txbIdContainer);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboPresentation, _frmAdd.txbIdPresentation);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboVariety, _frmAdd.txbIdVariety);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboColorVariety, _frmAdd.txbIdColorVariety);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboPrice, _frmAdd.txbIdPrice);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboPtiTag, _frmAdd.txbIdPtiTag);

            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboDistributor, _frmAdd.chbActiveDistributor);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboContainer, _frmAdd.chbActiveContainer);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboPresentation, _frmAdd.chbActivePresentation);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboVariety, _frmAdd.chbActiveVariety);

            ClsTextBoxes.TxbApplyKeyPressEventInt(_frmAdd.txbGTINNum);
            ClsTextBoxes.TxbApplyKeyPressEventInt(_frmAdd.txbUPCNum);
            ClsTextBoxes.TxbApplyKeyPressEventInt(_frmAdd.txbPLU);
            ClsTextBoxes.TxbApplyKeyPressEventNumericWithLimit(_frmAdd.txbLbs, 9, 2);
            ClsTextBoxes.TxbApplyKeyPressEventInt(_frmAdd.txbBoxes);
            ClsTextBoxes.TxbApplyKeyPressEventInt(_frmAdd.txbLoadPallets);

            //SIGUE VER PARA METERLE EL FILTRO DEL COLOR A LA VARIEDAD DESDE EL OTRO CBO
            //PERO PRIMERO HACER QUE GUARDE EL FRMULARIO

            _frmAdd.txbGTINNum.MaxLength = 14;
            _frmAdd.txbUPCNum.MaxLength = 14;
            _frmAdd.txbPLU.MaxLength = 4;
            _frmAdd.txbPreLabel.MaxLength = 12;
            _frmAdd.txbPostLabel.MaxLength = 12;
            _frmAdd.txbBoxes.MaxLength = 11;
            _frmAdd.txbLoadPallets.MaxLength = 11;
        }
        private void LoadControlsModify()
        {
            eGtin = new Egtin();

            eGtin.SetGtin(_frmAdd.idModify);

            _frmAdd.txbId.Text = eGtin.IdGtin;
            _frmAdd.txbGTINNum.Text = eGtin.GtinNumber;
            _frmAdd.txbUPCNum.Text = eGtin.UpcNumber;
            _frmAdd.txbPLU.Text = eGtin.Plu;
            _frmAdd.txbIdVariety.Text = eGtin.IdVariety;
            _frmAdd.txbIdDistribuitor.Text = eGtin.IdDistributor;
            _frmAdd.txbIdContainer.Text = eGtin.IdContainer;
            _frmAdd.txbIdPresentation.Text = eGtin.IdPresentation;
            _frmAdd.txbLbs.Text = eGtin.Lbs;
            _frmAdd.txbBoxes.Text = eGtin.PalletBoxes.ToString();
            _frmAdd.txbPreLabel.Text = eGtin.PreLabel;
            _frmAdd.txbPostLabel.Text = eGtin.PostLabel;
            _frmAdd.txbIdPrice.Text = eGtin.Price;
            _frmAdd.txbIdPtiTag.Text = eGtin.PtiTag;
            _frmAdd.txbLoadPallets.Text = eGtin.LoadPallets;

            _frmAdd.chbActive.Checked = eGtin.Active == 1;

            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboVariety, _frmAdd.txbIdVariety);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboDistributor, _frmAdd.txbIdDistribuitor);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboPresentation, _frmAdd.txbIdPresentation);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboContainer, _frmAdd.txbIdContainer);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboPrice, _frmAdd.txbIdPrice);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboPtiTag, _frmAdd.txbIdPtiTag);
        }

        public void AddProcedure()
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackGTINAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@gtinNumber", _frmAdd.txbGTINNum.Text);
                cmd.Parameters.AddWithValue("@upcNumber", ClsValues.IfEmptyToDBNull(_frmAdd.txbUPCNum.Text));
                cmd.Parameters.AddWithValue("@idVariety", _frmAdd.txbIdVariety.Text);
                cmd.Parameters.AddWithValue("@idDistributor", _frmAdd.txbIdDistribuitor.Text);
                cmd.Parameters.AddWithValue("@plu", ClsValues.IfEmptyToDBNull(_frmAdd.txbPLU.Text));
                cmd.Parameters.AddWithValue("@idPresentation", _frmAdd.txbIdPresentation.Text);
                cmd.Parameters.AddWithValue("@idContainer", _frmAdd.txbIdContainer.Text);
                cmd.Parameters.AddWithValue("@lbs", _frmAdd.txbLbs.Text);
                cmd.Parameters.AddWithValue("@palletBoxes", _frmAdd.txbBoxes.Text);
                cmd.Parameters.AddWithValue("@active", ClsCheckBoxes.GetCheckedValue(_frmAdd.chbActive));
                cmd.Parameters.AddWithValue("@preLabel", ClsValues.IfEmptyToDBNull(_frmAdd.txbPreLabel.Text));
                cmd.Parameters.AddWithValue("@postLabel", ClsValues.IfEmptyToDBNull(_frmAdd.txbPostLabel.Text));
                cmd.Parameters.AddWithValue("@idPrice", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdPrice.Text));
                cmd.Parameters.AddWithValue("@idPtiType", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdPtiTag.Text));
                cmd.Parameters.AddWithValue("@loadPallets", ClsValues.IfEmptyToDBNull(_frmAdd.txbLoadPallets.Text));
                cmd.Parameters.AddWithValue("@userCreate", User.GetUserName());

                string id = cmd.ExecuteScalar().ToString();

                MessageBox.Show("Se agregó el GTIN: " + id, "Catálogo añadir", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _frmAdd.AddIsUpdate = true;
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
                SqlCommand cmd = new SqlCommand("sp_PackGTINModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", _frmAdd.txbId.Text);
                cmd.Parameters.AddWithValue("@gtinNumber", _frmAdd.txbGTINNum.Text);
                cmd.Parameters.AddWithValue("@upcNumber", ClsValues.IfEmptyToDBNull(_frmAdd.txbUPCNum.Text));
                cmd.Parameters.AddWithValue("@idVariety", _frmAdd.txbIdVariety.Text);
                cmd.Parameters.AddWithValue("@idDistributor", _frmAdd.txbIdDistribuitor.Text);
                cmd.Parameters.AddWithValue("@plu", ClsValues.IfEmptyToDBNull(_frmAdd.txbPLU.Text));
                cmd.Parameters.AddWithValue("@idPresentation", _frmAdd.txbIdPresentation.Text);
                cmd.Parameters.AddWithValue("@idContainer", _frmAdd.txbIdContainer.Text);
                cmd.Parameters.AddWithValue("@lbs", _frmAdd.txbLbs.Text);
                cmd.Parameters.AddWithValue("@palletBoxes", _frmAdd.txbBoxes.Text);
                cmd.Parameters.AddWithValue("@active", ClsCheckBoxes.GetCheckedValue(_frmAdd.chbActive));
                cmd.Parameters.AddWithValue("@preLabel", ClsValues.IfEmptyToDBNull(_frmAdd.txbPreLabel.Text));
                cmd.Parameters.AddWithValue("@postLabel", ClsValues.IfEmptyToDBNull(_frmAdd.txbPostLabel.Text));
                cmd.Parameters.AddWithValue("@idPrice", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdPrice.Text));
                cmd.Parameters.AddWithValue("@idPtiType", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdPtiTag.Text));
                cmd.Parameters.AddWithValue("@loadPallets", ClsValues.IfEmptyToDBNull(_frmAdd.txbLoadPallets.Text));

                cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());

                cmd.ExecuteNonQuery();

                MessageBox.Show("Se modificó el GTIN: " + _frmAdd.txbId.Text, "Catálogo añadir", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _frmAdd.AddIsUpdate = true;
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

        private void AjustarEncabezados(DataGridView dataGridView)
        {
            // Habilitar texto multilínea en los encabezados
            dataGridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Ajustar automáticamente las alturas de los encabezados y las columnas
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // Recorrer todas las columnas y ajustar los encabezados
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.HeaderText = InsertarSaltosDeLinea(column.HeaderText);
            }
        }

        // Método para dividir automáticamente el texto de los encabezados largos
        private string InsertarSaltosDeLinea(string texto)
        {
            // Dividir el texto por palabras
            string[] palabras = texto.Split(' ');
            // Insertar saltos de línea entre las palabras
            return string.Join("\n", palabras);
        }

    }
}