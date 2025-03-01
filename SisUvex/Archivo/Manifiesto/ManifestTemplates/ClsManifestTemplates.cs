using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.Querys;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisUvex.Catalogos.Lot;
using SisUvex.Catalogos.Metods.Values;
using System.Media;

namespace SisUvex.Archivo.Manifiesto.ManifestTemplates
{
    internal class ClsManifestTemplates
    {
        SQLControl sql = new SQLControl();
        ClsControls controlList;
        public FrmManifestTemplatesAdd _frmAdd;
        public FrmManifestTemplatesCat _frmCat;
        public EManifestTemplate eManifestTemplate;
        //public ClsDataGridViewCatalogs dgv = new ClsDataGridViewCatalogs();
        private string queryCatalogo = $" SELECT mtpl.id_template AS [{ClsObject.Column.id}], mtpl.v_nameTemplate AS [{ClsObject.Column.name}], gro.v_nameGrower AS [Productor], dis.v_nameDistributor AS [Distribuidor], cons.id_consignee AS [Consignatario], agUS.v_nameAgency AS [Ag. Aduanal US], agMX.v_nameAgency AS [Ag. Aduanal MX], CONCAT_WS(' ', ctyCr.v_nameCity, ctyCr.v_state, ctyCr.v_country)  AS [Ciudad de cruce], CONCAT_WS(' ', ctyDe.v_nameCity, ctyDe.v_state, ctyDe.v_country)  AS [Ciudad destino], mtpl.v_description  AS [Descripción] FROM Pack_ManifestTemplates mtpl LEFT JOIN Pack_Distributor dis ON dis.id_distributor = mtpl.id_distributor LEFT JOIN Pack_Grower gro ON gro.id_grower = mtpl.id_grower LEFT JOIN Pack_Consignee cons ON cons.id_consignee = mtpl.id_consignee LEFT JOIN Pack_AgencyTrade agUS ON agUS.id_agencyTrade = mtpl.id_USAgencyTrade LEFT JOIN Pack_AgencyTrade agMX ON agMX.id_agencyTrade = mtpl.id_MXAgencyTrade LEFT JOIN Pack_City ctyCr ON ctyCr.id_city = mtpl.id_cityCrossPoint LEFT JOIN Pack_City ctyDe ON ctyDe.id_city = mtpl.id_cityDestiny ";
        public DataView _dvCatalog;
        private CheckBox _IsACboSelected = new();
        public void BeginFormCat()
        {
            _dvCatalog = new DataView(ClsQuerysDB.GetDataTable(queryCatalogo));

            _frmCat.dgvCatalog.DataSource = _dvCatalog;
        }

        public void BtnRemove()
        {
            if (_frmCat.dgvCatalog.SelectedRows.Count > 0)
            {
                string id = _frmCat.dgvCatalog.SelectedRows[0].Cells[0].Value.ToString();
                string query = $"DELETE FROM Pack_ManifestTemplates WHERE id_template = {id}";

                Dictionary<string, object> parameters = new();
                parameters.Add("@id_template", id);

                ClsQuerysDB.ExecuteParameterizedQuery(query, parameters);

                _frmCat.dgvCatalog.Rows.Remove(_frmCat.dgvCatalog.SelectedRows[0]);
            }
            else
            {
                SystemSounds.Exclamation.Play();
            }
        }
        public void OpenFrmAdd()
        {
            _frmAdd = new FrmManifestTemplatesAdd();
            _frmAdd.cls = this;
            _frmAdd.Text = "Añadir plantilla de manifiesto";
            _frmAdd.lblTitle.Text = "Añadir plantilla de manifiesto";
            _frmAdd.IsAddModify = true;

            _frmAdd.ShowDialog();
        }
        public void OpenFrmModify()
        {
            if (_frmCat.dgvCatalog.SelectedRows.Count != 0)
            {
                _frmAdd = new FrmManifestTemplatesAdd();
                _frmAdd.cls = this;
                _frmAdd.Text = "Modificar plantilla de manifiesto";
                _frmAdd.lblTitle.Text = "Modificar plantilla de manifiesto";
                _frmAdd.IsAddModify = false;

                _frmAdd.idLotModify = _frmCat.dgvCatalog.SelectedRows[0].Cells[ClsObject.Column.id].Value.ToString();

                _frmAdd.ShowDialog();
            }
            else
            {
                SystemSounds.Exclamation.Play();
            }
        }
        public void BeginFormAdd()
        {
            AddControlsToList();

            CargarComboBoxes();

            if (_frmAdd.IsAddModify)
            {
                _frmAdd.txbId.Text = ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX(id_template), 0) +1, '00') FROM Pack_ManifestTemplates").ToString();
            }
            else
            {
                LoadControlsModify();
            }
        }
        private void AddControlsToList()
        {
            controlList = new ClsControls();

            controlList.ChangeHeadMessage("Para dar de alta una plantilla de manifiesto debe:\n");
            controlList.Add(_frmAdd.txbName, "Ingresar el nombre de la plantilla.");
            controlList.Add(_IsACboSelected, "Seleccionar al menos una opción.");
        }

        private void CargarComboBoxes()
        {
            ClsComboBoxes.CboLoadActives(_frmAdd.cboDistributor, ClsObject.Distributor.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboConsignee, ClsObject.Consignee.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboGrower, ClsObject.Grower.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboAgencyMX, ClsObject.AgencyTradeMX.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboAgencyUS, ClsObject.AgencyTradeUS.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboCityCrossPoint, ClsObject.City.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboCityDestination, ClsObject.City.Cbo);

            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboDistributor, _frmAdd.txbIdDistributor);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboConsignee, _frmAdd.txbIdConsignee);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboGrower, _frmAdd.txbIdGrower);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboAgencyUS, _frmAdd.txbIdAgencyUS);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboAgencyMX, _frmAdd.txbIdAgencyMX);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboCityCrossPoint, _frmAdd.txbIdCityCrossPoint);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboCityDestination, _frmAdd.txbIdCityDestination);

            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboDistributor, _frmAdd.chbRemovedDistributor);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboConsignee, _frmAdd.chbRemovedConsignee);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboGrower, _frmAdd.chbRemovedGrower);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboAgencyUS, _frmAdd.chbRemovedAgencyUS);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboAgencyMX, _frmAdd.chbRemovedAgencyMX);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboCityCrossPoint, _frmAdd.chbRemovedCityCrossPoint);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboCityDestination, _frmAdd.chbRemovedCityDestination);
        }

        private void LoadControlsModify()
        {
            eManifestTemplate = new EManifestTemplate();
            eManifestTemplate.SetManifestTemplate(_frmAdd.idLotModify);

            _frmAdd.txbId.Text = eManifestTemplate.idManifestTemplate;
            _frmAdd.txbName.Text = eManifestTemplate.nameManifestTemplate;
            _frmAdd.txbDescription.Text = eManifestTemplate.description;
            _frmAdd.txbIdDistributor.Text = eManifestTemplate.idDistributor;
            _frmAdd.txbIdConsignee.Text = eManifestTemplate.idConsignee;
            _frmAdd.txbIdGrower.Text = eManifestTemplate.idGrower;
            _frmAdd.txbIdAgencyUS.Text = eManifestTemplate.idUSAgencyTrade;
            _frmAdd.txbIdAgencyMX.Text = eManifestTemplate.idMXAgencyTrade;
            _frmAdd.txbIdCityCrossPoint.Text = eManifestTemplate.idCityCrossPoint;
            _frmAdd.txbIdCityDestination.Text = eManifestTemplate.idCityDestiny;

            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboDistributor, _frmAdd.txbIdDistributor);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboConsignee, _frmAdd.txbIdConsignee);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboGrower, _frmAdd.txbIdGrower);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboAgencyUS, _frmAdd.txbIdAgencyUS);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboAgencyMX, _frmAdd.txbIdAgencyMX);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboCityCrossPoint, _frmAdd.txbIdCityCrossPoint);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboCityDestination, _frmAdd.txbIdCityDestination);
        }

        private bool IsTxbIdCboEmpty()
        {
            if (string.IsNullOrEmpty(_frmAdd.txbIdDistributor.Text) &&
                string.IsNullOrEmpty(_frmAdd.txbIdConsignee.Text) &&
                string.IsNullOrEmpty(_frmAdd.txbIdGrower.Text) &&
                string.IsNullOrEmpty(_frmAdd.txbIdAgencyUS.Text) &&
                string.IsNullOrEmpty(_frmAdd.txbIdAgencyMX.Text) &&
                string.IsNullOrEmpty(_frmAdd.txbIdCityCrossPoint.Text) &&
                string.IsNullOrEmpty(_frmAdd.txbIdCityDestination.Text))
            {
                return true;
            }

            return false;
        }

        public void btnAcceptAddModify()
        {
            _IsACboSelected.Checked = !IsTxbIdCboEmpty();

            if (!controlList.ValidateControls())
                return;

            if (_frmAdd.IsAddModify)
                AddProcedure();
            else
                ModifyProcedure();

            if (_frmAdd.AddIsUpdate)
                InsertTemplateInDGV();

            _frmAdd.Close();
        }

        public void AddProcedure()
        {
            try
            {
                string query = "INSERT INTO Pack_ManifestTemplates (id_template, v_nameTemplate, v_description, id_distributor, id_consignee, id_grower, id_USAgencyTrade, id_MXAgencyTrade, id_cityCrossPoint, id_cityDestiny, userCreate, d_create) VALUES ( (SELECT FORMAT(COALESCE(MAX(id_template), 0) +1, '00') FROM Pack_ManifestTemplates), @v_nameTemplate, @v_description, @id_distributor, @id_consignee, @id_grower, @id_USAgencyTrade, @id_MXAgencyTrade, @id_cityCrossPoint, @id_cityDestiny, @userCreate, CAST(GETDATE() AS DATE))";

                sql.OpenConectionWrite();

                SqlCommand cmd = new SqlCommand(query, sql.cnn);
                cmd.Parameters.AddWithValue("@v_nameTemplate", _frmAdd.txbName.Text);
                cmd.Parameters.AddWithValue("@v_description", ClsValues.IfEmptyToDBNull(_frmAdd.txbDescription.Text));
                cmd.Parameters.AddWithValue("@id_distributor", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdDistributor.Text));
                cmd.Parameters.AddWithValue("@id_consignee", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdConsignee.Text));
                cmd.Parameters.AddWithValue("@id_grower", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdGrower.Text));
                cmd.Parameters.AddWithValue("@id_USAgencyTrade", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdAgencyUS.Text));
                cmd.Parameters.AddWithValue("@id_MXAgencyTrade", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdAgencyMX.Text));
                cmd.Parameters.AddWithValue("@id_cityCrossPoint", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdCityCrossPoint.Text));
                cmd.Parameters.AddWithValue("@id_cityDestiny", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdCityDestination.Text));
                cmd.Parameters.AddWithValue("@userCreate", User.GetUserName());

                cmd.ExecuteNonQuery();

                _frmAdd.AddIsUpdate = true;

                MessageBox.Show("Se añadió la plantilla de manifiesto: " + _frmAdd.txbId.Text + "\n con nombre: " + _frmAdd.txbName.Text, "Catálogo añadir", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string query = "UPDATE Pack_ManifestTemplates SET v_nameTemplate = @v_nameTemplate, v_description = @v_description, id_distributor = @id_distributor, id_consignee = @id_consignee, id_grower = @id_grower, id_USAgencyTrade = @id_USAgencyTrade, id_MXAgencyTrade = @id_MXAgencyTrade, id_cityCrossPoint = @id_cityCrossPoint, id_cityDestiny = @id_cityDestiny, userUpdate = @userUpdate, d_update = CAST(GETDATE() AS DATE) WHERE id_template = @id_template";

                sql.OpenConectionWrite();

                SqlCommand cmd = new SqlCommand(query, sql.cnn);
                cmd.Parameters.AddWithValue("@id_template", _frmAdd.txbId.Text);
                cmd.Parameters.AddWithValue("@v_nameTemplate", _frmAdd.txbName.Text);
                cmd.Parameters.AddWithValue("@v_description", ClsValues.IfEmptyToDBNull(_frmAdd.txbDescription.Text));
                cmd.Parameters.AddWithValue("@id_distributor", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdDistributor.Text));
                cmd.Parameters.AddWithValue("@id_consignee", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdConsignee.Text));
                cmd.Parameters.AddWithValue("@id_grower", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdGrower.Text));
                cmd.Parameters.AddWithValue("@id_USAgencyTrade", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdAgencyUS.Text));
                cmd.Parameters.AddWithValue("@id_MXAgencyTrade", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdAgencyMX.Text));
                cmd.Parameters.AddWithValue("@id_cityCrossPoint", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdCityCrossPoint.Text));
                cmd.Parameters.AddWithValue("@id_cityDestiny", ClsValues.IfEmptyToDBNull(_frmAdd.txbIdCityDestination.Text));
                cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());

                cmd.ExecuteNonQuery();

                _frmAdd.AddIsUpdate = true;

                MessageBox.Show("Se modificó la plantilla de manifiesto: " + _frmAdd.txbId.Text + "\n con nombre: " + _frmAdd.txbName.Text, "Catálogo modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void InsertTemplateInDGV()
        {
            string qry = $"{queryCatalogo} WHERE mtpl.id_template = @idTemplate";

            Dictionary<string, object> parameters = new()
            {
                { "@idTemplate", _frmAdd.txbId.Text }
            };

            DataTable dt = ClsQuerysDB.ExecuteParameterizedQuery(qry, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                DataRowView drv = null;
                bool found = false;

                // Buscar si la fila ya existe en el DataView (_dvCatalog)
                foreach (DataRowView rowView in _dvCatalog)
                {
                    if (rowView["Código"].ToString() == dr["Código"].ToString())
                    {
                        drv = rowView;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    // Si no se encuentra, agregar una nueva fila al DataView
                    drv = _dvCatalog.AddNew();
                }

                if (drv != null)
                {
                    for (int i = 0; i < dr.ItemArray.Length; i++)
                    {
                        drv[i] = dr[i]; // Copiar valores de DataRow a DataRowView
                    }

                    drv.EndEdit();
                }

                // Seleccionar la última fila del DataGridView
                _frmCat.dgvCatalog.ClearSelection();
                _frmCat.dgvCatalog.Rows[_frmCat.dgvCatalog.Rows.Count - 1].Selected = true;
                _frmCat.dgvCatalog.FirstDisplayedScrollingRowIndex = _frmCat.dgvCatalog.Rows.Count - 1;
            }
        }


    }
}
