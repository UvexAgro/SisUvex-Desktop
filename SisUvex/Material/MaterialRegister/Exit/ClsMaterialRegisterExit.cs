using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using static SisUvex.Catalogos.Metods.ClsObject;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Material.MaterialRegister.Entry;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.Querys;
using Microsoft.IdentityModel.Tokens;
using System.Media;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.TextBoxes;
using SisUvex.Material.MaterialCatalog;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;
using SisUvex.Catalogos.TransportLine;
using SisUvex.Catalogos.Driver;
using SisUvex.Catalogos.FreightContainer;
using SisUvex.Material.MaterialForeignDest;
using SisUvex.Material.MaterialType;

namespace SisUvex.Material.MaterialRegister.Exit
{
    internal class ClsMaterialRegisterExit
    {
        ClsControls? controlListOutput;
        ClsControls? controlListMaterial;
        DataTable? dtUnit;
        private SingleImageManager? frontImageManager, backImageManager, downImageManager, upImageManager;
        private string? imagesPathCatalogFolder = string.Empty;
        public FrmMaterialRegisterExit _frmAdd;
        public FrmMaterialRegisterExitCat _frmCat;
        public EMaterialRegisterExit? entity;
        private string queryCatalog = " SELECT cat.* FROM vw_PackMatOutputExitCat AS cat ";
        private string queryCatalogExists = " WHERE EXISTS (SELECT 1 FROM Pack_MatOutput outp " +
                                          "JOIN Pack_MatOutputMaterials mat ON mat.id_matOutbound = outp.id_matOutbound " +
                                          "JOIN Pack_MaterialCatalog matC ON matC.id_matCatalog = mat.id_materialCat " +
                                          "LEFT JOIN Pack_MaterialType matT ON matT.id_matType = matC.id_matType " +
                                          "WHERE outp.id_matOutbound = cat.[Código] ";
        ClsDGVCatalog dgv;
        DataTable? dtCatalog, dtInboundMaterials, dtEmployees;
        public bool IsAddOrModify = true, IsAddUpdate = false, IsModifyUpdate = false;
        public string? idAddModify;
        private string employeeCboQuery = $" SELECT DISTINCT emp.id_employee AS [{Column.id}], CONCAT_WS(' ',emp.v_lastNamePat, emp.v_lastNameMat, emp.v_name) AS [{Column.name}] FROM Nom_Employees emp ";
        private string employeeCboQueryJoin = $" JOIN Pack_MatOutput mat ON mat.id_employee = emp.id_employee ";
        public void BtnSearchFilter()
        {
            dtCatalog = SearchFilter();
            dgv = new ClsDGVCatalog(_frmCat.dgvCatalog, dtCatalog); //Para agregar las Filas
        }

        private DataTable SearchFilter()
        {
            Dictionary<string, object> parameters = new();
            StringBuilder qry = new StringBuilder(queryCatalog);
            StringBuilder existsConditions = new StringBuilder(queryCatalogExists);

            // Fecha siempre aplica y el valor de id_outputtype
            existsConditions.Append(" AND outp.d_date BETWEEN @date1 AND @date2 AND outp.id_outputType = '02' ");
            parameters.Add("@date1", _frmCat.dtpDate1.Value.ToString("yyyy-MM-dd"));
            parameters.Add("@date2", _frmCat.dtpDate2.Value.ToString("yyyy-MM-dd"));

            // Filtros condicionales
            if (_frmCat.cboDistributor.SelectedIndex > 0)
            {
                existsConditions.Append(" AND mat.id_distributor = @idDistributor ");
                parameters.Add("@idDistributor", _frmCat.cboDistributor.SelectedValue);
            }

            if (_frmCat.cboGrower.SelectedIndex > 0)
            {
                existsConditions.Append(" AND mat.id_grower = @idGrower ");
                parameters.Add("@idGrower", _frmCat.cboGrower.SelectedValue);
            }

            if (_frmCat.cboWareHouse.SelectedIndex > 0)
            {
                existsConditions.Append(" AND outp.id_warehouses = @idWarehouse ");
                parameters.Add("@idWarehouse", _frmCat.cboWareHouse.SelectedValue);
            }

            if (_frmCat.cboMaterialType.SelectedIndex > 0)
            {
                existsConditions.Append(" AND matC.id_matType = @idMaterialType ");
                parameters.Add("@idMaterialType", _frmCat.cboMaterialType.SelectedValue);
            }
            if (_frmCat.cboMaterial.SelectedIndex > 0)
            {
                existsConditions.Append(" AND matC.id_matCatalog = @idMaterial ");
                parameters.Add("@idMaterial", _frmCat.cboMaterial.SelectedValue);
            }

            if (_frmCat.cboTransportLine.SelectedIndex > 0)
            {
                existsConditions.Append(" AND outp.id_transportLine = @idTransportLine ");
                parameters.Add("@idTransportLine", _frmCat.cboTransportLine.SelectedValue);
            }

            if (_frmCat.cboFreightContainer.SelectedIndex > 0)
            {
                existsConditions.Append(" AND outp.id_freightContainer = @idFreightContainer ");
                parameters.Add("@idFreightContainer", _frmCat.cboFreightContainer.SelectedValue);
            }

            if (_frmCat.cboForeignDest.SelectedIndex > 0)
            {
                existsConditions.Append(" AND outp.id_foreignDest = @idForeignDest ");
                parameters.Add("@idForeignDest", _frmCat.cboForeignDest.SelectedValue);
            }

            if (_frmCat.cboStatus.SelectedIndex > 0)
            {
                existsConditions.Append(" AND outp.id_exitStatus = @idStatus ");
                parameters.Add("@idStatus", _frmCat.cboStatus.SelectedValue);
            }

            // Cierra la subconsulta EXISTS
            existsConditions.Append(")");
            qry.Append(existsConditions);

            // Ordenar por Fecha, Código y c_position (sin mostrarlo en los resultados)
            qry.Append(" ORDER BY cat.[Fecha], cat.[Código], ");
            qry.Append("(SELECT TOP 1 mat.c_position FROM Pack_MatInboundMaterials mat ");
            qry.Append("WHERE mat.id_matInbound = cat.[Código])");

            return ClsQuerysDB.ExecuteParameterizedQuery(qry.ToString(), parameters);
        }

        public void BeginFormCat()
        {
            _frmCat ??= new();
            _frmCat.cls ??= this;

            dtCatalog = SearchFilter();
            dgv = new ClsDGVCatalog(_frmCat.dgvCatalog, dtCatalog); //Para agregar las Filas

            LoadComboBoxesCatalog();
        }

        private void LoadComboBoxesCatalog()
        {
            LoadSearchByCbo();

            ClsComboBoxes.CboLoadActives(_frmCat.cboDistributor, Distributor.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboWareHouse, MaterialWarehouse.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboTransportLine, TransportLine.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboFreightContainer, FreightContainer.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboGrower, Grower.Cbo);
            ClsComboBoxes.CboLoadAll(_frmCat.cboMaterialType, ClsObject.MaterialType.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboForeignDest, ForeignDest.Cbo);
            ClsComboBoxes.LoadComboBoxDataSource(_frmCat.cboStatus, EMaterialRegisterExit.GetDTExitStatus());

            //Material/Tipo material
            List<Tuple<ComboBox, CheckBox?, string>> cboMaterialTypeDepends = new List<Tuple<ComboBox, CheckBox?, string>>();
            cboMaterialTypeDepends.Add(new Tuple<ComboBox, CheckBox?, string>(_frmCat.cboMaterial, _frmCat.chbMaterialRemoved, ClsObject.MaterialType.ColumnId));
            ClsComboBoxes.CboApplyEventCboSelectedValueChangedWithCboDependensColumn(_frmCat.cboMaterialType, cboMaterialTypeDepends, null);

            _frmCat.cboMaterialType.SelectedIndexChanged += (s, e) =>
            {
                if (_frmCat.cboMaterial.Items.Count == 0)
                    ClsComboBoxes.CboLoadActives(_frmCat.cboMaterial, ClsObject.MaterialCatalog.Cbo);

                ClsComboBoxes.Metod_CboSelectedValueChangedWithCboDependensColumn(_frmCat.cboMaterialType, cboMaterialTypeDepends);
            };

            //Línea de transporte/Caja
            List<Tuple<ComboBox, CheckBox?, string>> cboTransportLineDepends = new List<Tuple<ComboBox, CheckBox?, string>>();
            cboTransportLineDepends.Add(new Tuple<ComboBox, CheckBox?, string>(_frmCat.cboFreightContainer, _frmCat.chbFreightContainerRemoved, TransportLine.ColumnId));
            ClsComboBoxes.CboApplyEventCboSelectedValueChangedWithCboDependensColumn(_frmCat.cboTransportLine, cboTransportLineDepends, null);

            //CHECKBOXES
            ClsComboBoxes.CboApplyClickEvent(_frmCat.cboDistributor, _frmCat.chbDistributorRemoved);
            ClsComboBoxes.CboApplyClickEvent(_frmCat.cboWareHouse, _frmCat.chbWareHouseRemoved);
            ClsComboBoxes.CboApplyClickEvent(_frmCat.cboGrower, _frmCat.chbGrowerRemoved);
            ClsComboBoxes.CboApplyClickEvent(_frmCat.cboTransportLine, _frmCat.chbTransportLineRemoved);
            ClsComboBoxes.CboApplyChbClickEventWithCboDependensColumn(_frmCat.cboFreightContainer, _frmCat.chbFreightContainerRemoved, TransportLine.ColumnId, _frmCat.cboTransportLine);
            ClsComboBoxes.CboApplyChbClickEventWithCboDependensColumn(_frmCat.cboMaterial, _frmCat.chbMaterialRemoved, ClsObject.MaterialType.ColumnId, _frmCat.cboMaterialType);
        }

        public void BeginFormAdd()
        {
            AddControlsToListExit();
            LoadControlsAddModify();
            InitializeDtInboundMaterials();
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboOutputType, "02");
            if (IsAddOrModify)
            {
                //_frmAdd.chbActive.Checked = true; //NO LLEVA
                _frmAdd.txbId.Text = EMaterialRegisterExit.GetNextId();
            }
            else
            {
                LoadControlsModify();
            }
        }

        private void AddControlsToListExit()
        {
            controlListOutput = new ClsControls();
            controlListOutput.ChangeHeadMessage("Para registrar una salida debe:\n");
            controlListOutput.Add(_frmAdd.txbId, "Seleccionar un tipo de salida.");
            controlListOutput.Add(_frmAdd.txbIdOutputType, "Seleccionar un tipo de salida.");
            controlListOutput.Add(_frmAdd.txbIdStatus, "Seleccionar el estado.");
            controlListOutput.Add(_frmAdd.txbIdWarehouse, "Seleccionar un almacén de salida.");
            controlListOutput.Add(_frmAdd.txbIdEmployee, "Seleccionar un empleado.");
            controlListOutput.Add(_frmAdd.txbIdForeignDest, "Ingresar dirección de destino.");
            controlListOutput.Add(_frmAdd.txbIdTransportLine, "Seleccionar una línea de transporte.");
            controlListOutput.Add(_frmAdd.txbIdFreightContainer, "Seleccionar una caja.");
            controlListOutput.Add(_frmAdd.dgvMaterialList, "Agregar materiales al listado.");

            controlListMaterial = new ClsControls();
            controlListMaterial.ChangeHeadMessage("Para agregar un material al listado debe:\n");
            controlListMaterial.Add(_frmAdd.txbInvoice, "Introducir folio/remisión/factura.");
            controlListMaterial.Add(_frmAdd.txbIdMaterial, "Seleccionar un material.");
            controlListMaterial.Add(_frmAdd.txbQuant, "Ingresar la cantidad.");
        }

        public void OpenFrmAdd()
        {
            idAddModify = null;
            entity = null;
            IsAddOrModify = true;
            IsAddUpdate = false;
            _frmAdd = new();
            _frmAdd.cls = this;
            _frmAdd.Text = "Añadir salida de material";
            _frmAdd.lblTitle.Text = "Añadir salida de material";
            _frmAdd.ShowDialog();
        }

        public void OpenFrmModify(string? idModify)
        {
            IsAddOrModify = false;
            IsModifyUpdate = false;

            if (idModify.IsNullOrEmpty())
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se ha seleccionado una salida para modificar.", "Modificar salida de material");
                return;
            }
            idAddModify = idModify;
            _frmAdd = new();
            _frmAdd.cls = this;
            _frmAdd.Text = "Modificar salida de material";
            _frmAdd.lblTitle.Text = "Modificar salida de material";
            _frmAdd.ShowDialog();
        }
        private void LoadControlsAddModify()
        {
            _frmAdd.txbQuant.Tag = "integerNoEmpty";
            ClsTextBoxes.TxbApplyKeyPressEventInt(_frmAdd.txbQuant);
            _frmAdd.txbUSD.Tag = "decimalEmpty";
            ClsTextBoxes.TxbApplyKeyPressEventDecimal(_frmAdd.txbUSD);
            _frmAdd.txbMXN.Tag = "decimalEmpty";
            ClsTextBoxes.TxbApplyKeyPressEventDecimal(_frmAdd.txbMXN);
            ClsComboBoxes.CboLoadAll(_frmAdd.cboForeignDest, ForeignDest.Cbo);
            dtUnit = ClsQuerysDB.GetDataTable(Unit.QueryCbo);
            dtEmployees = ClsQuerysDB.GetDataTable(employeeCboQuery + employeeCboQueryJoin);
            ClsComboBoxes.LoadComboBoxDataSource(_frmAdd.cboEmployee, dtEmployees);
            ClsComboBoxes.LoadComboBoxDataSource(_frmAdd.cboOutputType, EMaterialRegisterExit.GetDTOutputType());
            ClsComboBoxes.LoadComboBoxDataSource(_frmAdd.cboStatus, EMaterialRegisterExit.GetDTExitStatus());
            ClsComboBoxes.CboLoadActives(_frmAdd.cboWarehouse, MaterialWarehouse.Cbo);
            ClsComboBoxes.CboLoadAll(_frmAdd.cboMaterialType, ClsObject.MaterialType.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboTransportLine, TransportLine.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboFreightContainer, FreightContainer.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboDriver, Driver.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboDistributor, Distributor.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboGrower, Grower.Cbo);

            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboEmployee, _frmAdd.txbIdEmployee);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboOutputType, _frmAdd.txbIdOutputType);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboStatus, _frmAdd.txbIdStatus);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboWarehouse, _frmAdd.txbIdWarehouse);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboEmployee, _frmAdd.txbIdEmployee);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboDriver, _frmAdd.txbIdDriver);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboFreightContainer, _frmAdd.txbIdFreightContainer);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboDistributor, _frmAdd.txbIdDistributor);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboGrower, _frmAdd.txbIdGrower);

            //Material/Tipo material
            List<Tuple<ComboBox, CheckBox?, string>> cboMaterialTypeDepends = new List<Tuple<ComboBox, CheckBox?, string>>();
            cboMaterialTypeDepends.Add(new Tuple<ComboBox, CheckBox?, string>(_frmAdd.cboMaterial, _frmAdd.chbMaterialRemoved, ClsObject.MaterialType.ColumnId));
            ClsComboBoxes.CboApplyEventCboSelectedValueChangedWithCboDependensColumn(_frmAdd.cboMaterialType, cboMaterialTypeDepends, null);

            _frmAdd.cboMaterialType.SelectedIndexChanged += (s, e) =>
            {//AL SELECCIONAR UN TIPO DE MATERIAL, CAMBIA SU TXBID Y CARGA Y FILTRA LOS MATERIALES
                if (_frmAdd.cboMaterial.Items.Count == 0)
                    ClsComboBoxes.CboLoadActives(_frmAdd.cboMaterial, ClsObject.MaterialCatalog.Cbo);

                ClsComboBoxes.Metod_CboSelectedValueChangedWithCboDependensColumn(_frmAdd.cboMaterialType, cboMaterialTypeDepends);

                _frmAdd.txbIdMaterialType.Text = _frmAdd.cboMaterialType.SelectedValue?.ToString();
            };

            _frmAdd.cboMaterial.SelectedIndexChanged += (s, e) =>
            {//AL SELECCIONAR UN MATERIAL, CAMBIA SU TXBID Y EL TXB UNIDAD

                if (_frmAdd.cboMaterial.SelectedIndex > 0)
                {
                    string? idMaterialSelected = _frmAdd.cboMaterial.SelectedValue?.ToString();
                    _frmAdd.txbIdMaterial.Text = idMaterialSelected;

                    if (_frmAdd.cboMaterial.SelectedItem is DataRowView selectedRowView)
                    {
                        object? idUnit = selectedRowView[Unit.ColumnId].ToString();
                        if (idUnit != null)
                            _frmAdd.txbUnit.Text = dtUnit?.GetValue(Unit.ColumnName, Column.id, idUnit)?.ToString() ?? string.Empty;
                        else
                            _frmAdd.txbUnit.Text = string.Empty;
                    }


                    if (string.IsNullOrEmpty(imagesPathCatalogFolder))
                        imagesPathCatalogFolder = ClsQuerysDB.GetData("SELECT v_valueParameters FROM Conf_Parameters WHERE id_typeParameter = '02' AND id_parameter = '007'");
                    LoadAllImages(idMaterialSelected);
                }
                else
                {
                    _frmAdd.txbUnit.Text = string.Empty;
                    _frmAdd.txbIdMaterial.Text = string.Empty;

                    Dispose(); //PARA IMAGENES
                }
            };

            _frmAdd.cboForeignDest.SelectedIndexChanged += (s, e) =>
            {
                if (_frmAdd.cboForeignDest.SelectedIndex > 0)
                {
                    _frmAdd.txbIdForeignDest.Text = _frmAdd.cboForeignDest.SelectedValue?.ToString();
                    _frmAdd.txbForeignDestCity.Text = _frmAdd.cboForeignDest.GetColumnValue(ForeignDest.ColumnCity).ToString();
                    _frmAdd.txbForeignDestState.Text = _frmAdd.cboForeignDest.GetColumnValue(ForeignDest.ColumnState).ToString();
                }
                else
                    _frmAdd.txbIdForeignDest.Text = string.Empty;
            };

            List<Tuple<ComboBox, CheckBox?, string>> cboTransportLineDepends = new List<Tuple<ComboBox, CheckBox?, string>>();
            cboTransportLineDepends.Add(new Tuple<ComboBox, CheckBox?, string>(_frmAdd.cboDriver, _frmAdd.chbDriverRemoved, TransportLine.ColumnId));
            cboTransportLineDepends.Add(new Tuple<ComboBox, CheckBox?, string>(_frmAdd.cboFreightContainer, _frmAdd.chbFreightContainerRemoved, TransportLine.ColumnId));
            ClsComboBoxes.CboApplyEventCboSelectedValueChangedWithCboDependensColumn(_frmAdd.cboTransportLine, cboTransportLineDepends, _frmAdd.txbIdTransportLine);


            //CHECKBOXES
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboWarehouse, _frmAdd.chbWarehouseRemoved);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboTransportLine, _frmAdd.chbTransportLineRemoved);
            ClsComboBoxes.CboApplyChbClickEventWithCboDependensColumn(_frmAdd.cboDriver, _frmAdd.chbDriverRemoved, TransportLine.ColumnId, _frmAdd.txbIdTransportLine);
            ClsComboBoxes.CboApplyChbClickEventWithCboDependensColumn(_frmAdd.cboFreightContainer, _frmAdd.chbFreightContainerRemoved, TransportLine.ColumnId, _frmAdd.txbIdTransportLine);
            ClsComboBoxes.CboApplyChbClickEventWithCboDependensColumn(_frmAdd.cboMaterial, _frmAdd.chbMaterialRemoved, ClsObject.MaterialType.ColumnId, _frmAdd.txbIdMaterialType);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboDistributor, _frmAdd.chbDistributorRemoved);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboGrower, _frmAdd.chbGrowerRemoved);

        }
        private void LoadControlsModify()
        {
            entity = new();
            entity.GetMaterialOutbound(idAddModify);
            entity.GetMaterialOutboundMaterials(idAddModify);

            _frmAdd.txbId.Text = entity.idMatOutbound;
            _frmAdd.dtpDate.Value = entity.dateOutbound;

            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboOutputType, entity.idOutputType);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboStatus, entity.idExitStatus);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboWarehouse, entity.idWarehouse); ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboEmployee, entity.idEmployee);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboForeignDest, entity.idForeignDest);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboTransportLine, entity.idTransportLine);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboDriver, entity.idDriver);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboFreightContainer, entity.idFreightContainer);

            dtInboundMaterials.CopyDataFrom(entity.dtMaterials);

            _frmAdd.dgvMaterialList.DataSource = dtInboundMaterials;
        }

        private EMaterialRegisterExit SetEntity()
        {
            entity = new();
            entity.idMatOutbound = _frmAdd.txbId.Text;
            entity.dateOutbound = _frmAdd.dtpDate.Value;
            entity.idOutputType = _frmAdd.txbIdOutputType.Text;
            entity.idExitStatus = _frmAdd.txbIdStatus.Text;
            entity.idWarehouse = _frmAdd.txbIdWarehouse.Text;
            entity.idEmployee = _frmAdd.txbIdEmployee.Text;
            entity.idForeignDest = _frmAdd.txbIdForeignDest.Text;
            entity.idTransportLine = _frmAdd.txbIdTransportLine.Text;
            entity.idDriver = _frmAdd.txbIdDriver.Text;
            entity.idFreightContainer = _frmAdd.txbIdFreightContainer.Text;

            entity.dtMaterials = dtInboundMaterials;

            return entity;
        }

        public void AddProcedure()
        {
            EMaterialRegisterExit eAdd = new();
            eAdd = SetEntity();
            var result = eAdd.AddProcedureWithMaterials();
            IsAddUpdate = result.Item1;
            idAddModify = result.Item2;
        }

        public void ModifyProcedure()
        {
            EMaterialRegisterExit eModify = new();
            eModify = SetEntity();
            var result = eModify.ModifyProcedureWithMaterials();
            IsModifyUpdate = result.Item1;
            idAddModify = result.Item2;
        }

        public void BtnAccept()
        {
            if (!controlListOutput.ValidateControls())
                return;

            if (IsAddOrModify)
            {
                AddProcedure();
                if (IsAddUpdate)
                {
                    _frmAdd.txbId.Text = idAddModify;
                    MessageBox.Show($"Se ha agregado la salida con código: {idAddModify}", "Añadir salida de material");

                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo agregar la salida.", "Añadir salida de material");
                }
            }
            else
            {
                ModifyProcedure();

                if (IsModifyUpdate)
                {
                    MessageBox.Show($"Se ha modificado la salida con el código: {idAddModify}", "Modificar salida de material");

                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo modificar la salida.", "Modificar salida de material");
                }
            }
        }

        public void CloseFrmAddModify()
        {
            _frmAdd.Close();
        }
        public void AddNewRowByIdInDGVCatalog()
        {
            DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalog + $" WHERE [{Column.id}] = '{idAddModify}'");

            dgv.AddNewRowToDGV(newIdRow);
        }
        public void ModifyRowByIdInDGVCatalog()
        {
            DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalog + $" WHERE [{Column.id}] = '{idAddModify}'");

            dgv.ModifyIdRowInDGV(newIdRow);
        }

        private void InitializeDtInboundMaterials()
        {
            dtInboundMaterials = new DataTable();
            dtInboundMaterials.Columns.Add("Código", typeof(string));
            dtInboundMaterials.Columns.Add("Tipo", typeof(string));
            dtInboundMaterials.Columns.Add("Material", typeof(string));
            dtInboundMaterials.Columns.Add("Cantidad", typeof(string));
            dtInboundMaterials.Columns.Add("Unidad", typeof(string));
            dtInboundMaterials.Columns.Add("Folio", typeof(string));
            dtInboundMaterials.Columns.Add("Distribuidor", typeof(string));
            dtInboundMaterials.Columns.Add("Productor", typeof(string));
            dtInboundMaterials.Columns.Add("$MXN", typeof(string));
            dtInboundMaterials.Columns.Add("$USD", typeof(string));
            dtInboundMaterials.Columns.Add(EMaterialRegisterExit.cPosition, typeof(string));
            dtInboundMaterials.Columns.Add(EMaterialRegisterExit.cIdMatOutbound, typeof(string));
            dtInboundMaterials.Columns.Add(Distributor.ColumnId, typeof(string));
            dtInboundMaterials.Columns.Add(Grower.ColumnId, typeof(string));
            dtInboundMaterials.Columns.Add(ClsObject.MaterialType.ColumnId, typeof(string));

            _frmAdd.dgvMaterialList.DataSource = dtInboundMaterials;

            _frmAdd.dgvMaterialList.Columns[EMaterialRegisterExit.cPosition].Visible = false;
            _frmAdd.dgvMaterialList.Columns[EMaterialRegisterExit.cIdMatOutbound].Visible = false;
            _frmAdd.dgvMaterialList.Columns[Distributor.ColumnId].Visible = false;
            _frmAdd.dgvMaterialList.Columns[Grower.ColumnId].Visible = false;
            _frmAdd.dgvMaterialList.Columns[ClsObject.MaterialType.ColumnId].Visible = false;
        }

        public void BtnAddRowMaterialsInExit()
        {
            if (!controlListMaterial.ValidateControls())
                return;
            if (dtInboundMaterials == null)
                InitializeDtInboundMaterials();

            AddRowToInboundMaterials();

            if (_frmAdd.cboMaterial.Items.Count > 0)
                _frmAdd.cboMaterial.SelectedIndex = 0;

            _frmAdd.txbQuant.Text = string.Empty;
            _frmAdd.txbUSD.Text = string.Empty;
            _frmAdd.txbMXN.Text = string.Empty;
        }

        private void AddRowToInboundMaterials()
        {
            DataRow newRow = dtInboundMaterials.NewRow();
            newRow["Código"] = _frmAdd.txbIdMaterial.Text;
            newRow["Tipo"] = _frmAdd.cboMaterialType.GetColumnValue(ClsObject.MaterialType.ColumnName);
            newRow["Material"] = _frmAdd.cboMaterial.GetColumnValue(ClsObject.MaterialCatalog.ColumnName);
            newRow["Cantidad"] = _frmAdd.txbQuant.Text;
            newRow["Unidad"] = _frmAdd.txbUnit.Text;
            newRow["Folio"] = _frmAdd.txbInvoice.Text;
            newRow["Distribuidor"] = _frmAdd.cboDistributor.GetColumnValue(Distributor.ColumnShortName);
            newRow["Productor"] = _frmAdd.cboGrower.GetColumnValue(Grower.ColumnShortName);
            if (decimal.TryParse(_frmAdd.txbMXN.Text, out decimal mxnValue))
                newRow["$MXN"] = mxnValue.ToString("N2");
            if (decimal.TryParse(_frmAdd.txbUSD.Text, out decimal usdValue))
                newRow["$USD"] = usdValue.ToString("N2");
            newRow[EMaterialRegisterExit.cPosition] = ""; //no ocupa ir nada
            newRow[EMaterialRegisterExit.cIdMatOutbound] = ""; //no ocupa ir nada
            newRow[Distributor.ColumnId] = _frmAdd.cboDistributor.SelectedValue?.ToString();
            newRow[Grower.ColumnId] = _frmAdd.cboGrower.SelectedValue?.ToString();
            newRow[ClsObject.MaterialType.ColumnId] = _frmAdd.txbIdMaterialType.Text;

            dtInboundMaterials.Rows.Add(newRow);
        }

        public void BtnRemoveRowMaterialsInExit()
        {
            if (_frmAdd.dgvMaterialList.SelectedRows.Count > 0)
            {
                RemoveRowMaterialsInExit();
            }
            else
                SystemSounds.Exclamation.Play();
        }

        private void RemoveRowMaterialsInExit()
        {
            int selectedIndex = _frmAdd.dgvMaterialList.SelectedRows[0].Index;
            dtInboundMaterials.Rows.RemoveAt(selectedIndex);
        }

        public void BtnModifyRowMaterialsSelected()
        {
            if (_frmAdd.dgvMaterialList.SelectedRows.Count == 0)
            {
                SystemSounds.Exclamation.Play();
                return;
            }

            int selectedIndex = _frmAdd.dgvMaterialList.SelectedRows[0].Index;
            DataRow rowToModify = dtInboundMaterials.Rows[selectedIndex];
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboMaterialType, rowToModify[ClsObject.MaterialType.ColumnId].ToString());
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboMaterial, rowToModify["Código"].ToString());
            _frmAdd.txbQuant.Text = rowToModify["Cantidad"].ToString();
            _frmAdd.txbInvoice.Text = rowToModify["Folio"].ToString();
            _frmAdd.txbMXN.Text = rowToModify["$MXN"].ToString();
            _frmAdd.txbUSD.Text = rowToModify["$USD"].ToString();
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboDistributor, rowToModify[Distributor.ColumnId].ToString());
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboGrower, rowToModify[Grower.ColumnId].ToString());

            RemoveRowMaterialsInExit();
        }

        public void BtnDeleteSelectedRowFromDGVCatalog(DataGridViewRow selectedRow)
        {
            string? idMatOutputExit = selectedRow.Cells[Column.id].Value?.ToString();

            if (!string.IsNullOrEmpty(idMatOutputExit))
            {
                DialogResult result = MessageBox.Show($"¿Está seguro de que desea eliminar la salida de material {idMatOutputExit}?", "Eliminar salida de material", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                    return;

                bool isDeleted = DeleteMatOutputExit(idMatOutputExit);

                if (isDeleted)
                {
                    for (int i = _frmCat.dgvCatalog.Rows.Count - 1; i >= 0; i--)
                    {
                        DataGridViewRow row = _frmCat.dgvCatalog.Rows[i];
                        if (row.Cells[Column.id].Value?.ToString() == idMatOutputExit)
                        {
                            _frmCat.dgvCatalog.Rows.Remove(row);
                        }
                    }
                    MessageBox.Show($"Se ha eliminado la salida de material con el código: {idMatOutputExit}", "Eliminar salida de material");
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se eliminó la salida de material.", "Eliminar salida de material");
                }
            }
            else
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("El código de la salida de material no es válido.", "Eliminar salida de material");
            }
        }

        private bool DeleteMatOutputExit(string idMatOutputExit)
        {
            if (string.IsNullOrEmpty(idMatOutputExit))
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se ha seleccionado una salida para eliminar.", "Eliminar salida de material");
                return false;
            }

            return EMaterialRegisterExit.DeleteProcedure(idMatOutputExit);
        }

        private void LoadSearchByCbo()
        {
            _frmCat.cboSearchBy.Items.Clear();
            _frmCat.cboSearchBy.Items.Add("Folio");
            _frmCat.cboSearchBy.Items.Add("Código de salida");
            _frmCat.cboSearchBy.SelectedIndex = 0;
        }
        public void BtnSearchBy(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                SystemSounds.Exclamation.Play();
                return;
            }

            Dictionary<string, object> parameters = new();
            string queryWhere = string.Empty;
            switch (_frmCat.cboSearchBy.Text)
            {
                case "Folio":
                    queryWhere = " WHERE cat.[Folio] LIKE @text ";
                    parameters.Add("@text", "%" + text + "%");
                    break;
                case "Código de salida":
                    if (long.TryParse(text, out long idInbound))
                        text = idInbound.ToString("000000000000000");
                    else
                    {
                        SystemSounds.Exclamation.Play();
                        return;
                    }
                    queryWhere = " WHERE cat.[Código] LIKE @text ";
                    parameters.Add("@text", text);
                    break;
                default:
                    SystemSounds.Exclamation.Play();
                    return;
            }

            dtCatalog = ClsQuerysDB.ExecuteParameterizedQuery(queryCatalog + queryWhere, parameters);
            dgv = new(_frmCat.dgvCatalog, dtCatalog);
            Clipboard.SetText(queryCatalog + queryWhere);
        }


        /////IMAGENES
        public void ChbImagesClic(CheckBox chb)
        {
            if (!IsImagesFolderPathValide())
                return;

            _frmAdd.chbImageFront.Checked = false;
            _frmAdd.chbImageBack.Checked = false;
            _frmAdd.chbImageDown.Checked = false;
            _frmAdd.chbImageUp.Checked = false;
            chb.Checked = true;

            if (_frmAdd.cboMaterial.SelectedIndex < 1)
                return;

            if (chb == _frmAdd.chbImageFront)
                _frmAdd.pbxMaterial.Image = frontImageManager.CurrentImage;
            else if (chb == _frmAdd.chbImageBack)
                _frmAdd.pbxMaterial.Image = backImageManager.CurrentImage;
            else if (chb == _frmAdd.chbImageDown)
                _frmAdd.pbxMaterial.Image = downImageManager.CurrentImage;
            else if (chb == _frmAdd.chbImageUp)
                _frmAdd.pbxMaterial.Image = upImageManager.CurrentImage;
        }

        private bool IsImagesFolderPathValide()
        {
            if (string.IsNullOrEmpty(imagesPathCatalogFolder) || !Directory.Exists(imagesPathCatalogFolder))
                return false;

            return true;
        }
        private void LoadAllImages(string idMaterial)
        {
            if (!IsImagesFolderPathValide())
                return;

            InicializateImagesManagers();

            frontImageManager.LoadImage($"{idMaterial}_Front");
            backImageManager.LoadImage($"{idMaterial}_Back");
            upImageManager.LoadImage($"{idMaterial}_Up");
            downImageManager.LoadImage($"{idMaterial}_Down");

            ChbImagesClic(_frmAdd.chbImageFront);
        }
        private void InicializateImagesManagers()
        {
            if (!IsImagesFolderPathValide())
                return;

            frontImageManager = new SingleImageManager(imagesPathCatalogFolder);
            backImageManager = new SingleImageManager(imagesPathCatalogFolder);
            downImageManager = new SingleImageManager(imagesPathCatalogFolder);
            upImageManager = new SingleImageManager(imagesPathCatalogFolder);
        }

        public void Dispose() //PARA QUE FUNCIONE CON EL DISPOSE DEL FORM
        {
            if (!IsImagesFolderPathValide())
                return;

            frontImageManager?.Dispose();
            backImageManager?.Dispose();
            downImageManager?.Dispose();
            upImageManager?.Dispose();

            _frmAdd.pbxMaterial.Image = null;
        }

        /////////btnSearch 
        public void BtnMaterialCatalogSearch(ComboBox cboMatType, ComboBox cboMaterialCat)
        {
            //METODO ESPECIFICO PARA ESTOS CASOS CON CboMaterialType con CboMaterialCatalog çomo dependiente
            ClsSelectionForm sel = new();
            sel.OpenSelectionForm("MaterialCatalog", "Código");

            if (!string.IsNullOrEmpty(sel.SelectedValue))
            {
                if (cboMaterialCat.Items.Count == 0)
                    ClsComboBoxes.CboLoadActives(cboMaterialCat, ClsObject.MaterialCatalog.Cbo);

                DataTable? dtSearch = cboMaterialCat.DataSource as DataTable;

                string idMatType = dtSearch.GetValue(ClsObject.MaterialType.ColumnId, Column.id, sel.SelectedValue)?.ToString() ?? string.Empty;

                ClsComboBoxes.CboSelectIndexWithTextInValueMember(cboMatType, idMatType);

                ClsComboBoxes.CboSelectIndexWithTextInValueMemberKeepingFilter(cboMaterialCat, sel.SelectedValue);
            }
            else
                cboMatType.SelectedIndex = 0;
        }

        public void btnSearchEmployee()
        {
            ClsSelectionForm sel = new ClsSelectionForm();
            sel.OpenSelectionForm("EmployeeBasic", "Código");

            if (!string.IsNullOrEmpty(sel.SelectedValue))
            {
                Dictionary<string, object> parameters = new();
                parameters.Add("@idEmployee", sel.SelectedValue);

                string q = employeeCboQuery + " WHERE emp.id_employee = @idEmployee ";

                DataTable dtEmp = ClsQuerysDB.ExecuteParameterizedQuery(q, parameters);

                if (dtEmp.Rows.Count > 0)
                {
                    DataRow newRow = dtEmp.Rows[0];

                    DataTable currentDt = (DataTable)_frmAdd.cboEmployee.DataSource;

                    bool exists = false;
                    foreach (DataRow row in currentDt.Rows)
                    {
                        if (row[Column.id].ToString() == newRow[Column.id].ToString() &&
                            row[Column.id].ToString() != string.Empty) // Excluir la fila "---Seleccionar---"
                        {
                            exists = true;
                            break;
                        }
                    }

                    if (!exists)
                    {
                        DataRow rowToAdd = currentDt.NewRow();
                        rowToAdd[Column.id] = newRow[Column.id];
                        rowToAdd[Column.name] = newRow[Column.name];

                        currentDt.Rows.Add(rowToAdd);
                    }

                    _frmAdd.cboEmployee.SelectedValue = newRow[Column.id];
                }
            }
        }
        /////////Btns de añadir
        public void BtnAddMaterialCatalog()
        {
            FrmMaterialAdd materialAdd = new();
            materialAdd.ShowDialog();
            if (materialAdd.cls.IsAddUpdate)
            {
                ClsComboBoxes.CboLoadActives(_frmAdd.cboMaterial, ClsObject.MaterialCatalog.Cbo);
                _frmAdd.chbMaterialRemoved.Checked = false;
                ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboMaterial, materialAdd.cls.idAddModify);
            }
        }
        public void BtnAddTransportLine()
        {
            FrmTransportLineAdd transportLineAdd = new();
            transportLineAdd.ShowDialog();
            if (transportLineAdd.cls.IsAddUpdate)
            {
                ClsComboBoxes.CboLoadActives(_frmAdd.cboTransportLine, TransportLine.Cbo);
                _frmAdd.chbTransportLineRemoved.Checked = false;
                ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboTransportLine, transportLineAdd.cls.idAddModify);
            }
        }
        public void BtnAddDriver()
        {
            FrmDriverAdd driverAdd = new();
            driverAdd.ShowDialog();
            if (driverAdd.cls.IsAddUpdate)
            {
                ClsComboBoxes.CboLoadActives(_frmAdd.cboDriver, Driver.Cbo);
                _frmAdd.chbDriverRemoved.Checked = false;
                ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboDriver, driverAdd.cls.idAddModify);
            }
        }
        public void BtnAddFreighContainer()
        {
            FrmFreightContainerAdd freightContainerAdd = new();
            freightContainerAdd.ShowDialog();
            if (freightContainerAdd.cls.IsAddUpdate)
            {
                ClsComboBoxes.CboLoadActives(_frmAdd.cboFreightContainer, FreightContainer.Cbo);
                _frmAdd.chbFreightContainerRemoved.Checked = false;
                ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboFreightContainer, freightContainerAdd.cls.idAddModify);
            }
        }
        public void BtnAddForeignDest()
        {
            FrmMaterialForeignDestAdd foreignDestAdd = new();
            foreignDestAdd.ShowDialog();
            if (foreignDestAdd.cls.IsAddUpdate)
            {
                ClsComboBoxes.CboLoadAll(_frmAdd.cboForeignDest, ForeignDest.Cbo);
                ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboForeignDest, foreignDestAdd.cls.idAddModify);
            }
        }
    }
}
