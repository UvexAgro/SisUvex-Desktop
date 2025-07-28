using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static SisUvex.Catalogos.Metods.ClsObject;
using System.Data;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Material.MaterialRegister.Exit;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.TextBoxes;
using System.Media;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;
using SisUvex.Material.MaterialCatalog;
using Microsoft.IdentityModel.Tokens;
using SisUvex.Catalogos.FreightContainer;
using SisUvex.Assets.Vehicle.Vehicle;

namespace SisUvex.Material.MaterialRegister.FieldExit
{
    internal class ClsMaterialRegisterFieldExit
    {
        ClsControls? controlListOutput;
        ClsControls? controlListMaterial;
        DataTable? dtUnit;
        private SingleImageManager? frontImageManager, backImageManager, downImageManager, upImageManager;
        private string? imagesPathCatalogFolder = string.Empty;
        public FrmMaterialRegisterFieldExit _frmAdd;
        public FrmMaterialRegisterFieldExitCat _frmCat;
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
            ApplyFilderCatalog();
        }

        private void ApplyFilderCatalog()
        {
            dtCatalog = SearchFilter();
            dgv = new ClsDGVCatalog(_frmCat.dgvCatalog, dtCatalog); //Para agregar las Filas
            DgvHideColumnsToExitCatalog();
        }

        private DataTable SearchFilter()
        {
            Dictionary<string, object> parameters = new();
            StringBuilder qry = new StringBuilder(queryCatalog);
            StringBuilder existsConditions = new StringBuilder(queryCatalogExists);

            // Fecha siempre aplica y el valor de id_outputtype
            existsConditions.Append(" AND outp.d_date BETWEEN @date1 AND @date2 AND outp.id_outputType = '01' ");
            parameters.Add("@date1", _frmCat.dtpDate1.Value.ToString("yyyy-MM-dd"));
            parameters.Add("@date2", _frmCat.dtpDate2.Value.ToString("yyyy-MM-dd"));

            // Filtros condicionales
            if (_frmCat.cboDistributor.SelectedIndex > 0)
            {
                existsConditions.Append(" AND mat.id_distributor = @idDistributor ");
                parameters.Add("@idDistributor", _frmCat.cboDistributor.SelectedValue);
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
            
            if (_frmCat.cboLot.SelectedIndex > 0) //SACAR IDLOT Y VARIEDAD DEL cboLot
            {
                existsConditions.Append(" AND outp.id_lot = @idLot ");
                parameters.Add("@idLot", _frmCat.cboLot.GetColumnValue(ClsObject.Lot.ColumnId));

                existsConditions.Append(" AND outp.id_variety = @idVariety ");
                parameters.Add("@idVariety", _frmCat.cboLot.GetColumnValue(Variety.ColumnId));
            }
            else if (_frmCat.cboVariety.SelectedIndex > 0) //SACAR idVariety solo si el cboLot no tiene nada seleccionado y esté si, para no intercalar
            {
                existsConditions.Append(" AND outp.id_variety = @idVariety ");
                parameters.Add("@idVariety", _frmCat.cboVariety.SelectedValue);
            }

            if (_frmCat.cboVehicle.SelectedIndex > 0)
            {
                existsConditions.Append(" AND outp.id_vehiculos = @idVehicle ");
                parameters.Add("@idVehicle", _frmCat.cboVehicle.SelectedValue);
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

            ApplyFilderCatalog();

            LoadComboBoxesCatalog();
        }

        private void DgvHideColumnsToExitCatalog()
        {
            if (dtCatalog.Columns.Contains("Línea T."))
                _frmCat.dgvCatalog.Columns["Línea T."].Visible = false;
            if (dtCatalog.Columns.Contains("Caja"))
                _frmCat.dgvCatalog.Columns["Caja"].Visible = false;
            if (dtCatalog.Columns.Contains("Productor"))
                _frmCat.dgvCatalog.Columns["Productor"].Visible = false;
            if (dtCatalog.Columns.Contains("Estado S."))
                _frmCat.dgvCatalog.Columns["Estado S."].Visible = false;
            if (dtCatalog.Columns.Contains("Dirección"))
                _frmCat.dgvCatalog.Columns["Dirección"].Visible = false;
            if (dtCatalog.Columns.Contains("Ciudad"))
                _frmCat.dgvCatalog.Columns["Ciudad"].Visible = false;
            if (dtCatalog.Columns.Contains("Estado"))
                _frmCat.dgvCatalog.Columns["Estado"].Visible = false;
        }
        private void LoadComboBoxesCatalog()
        {
            LoadSearchByCbo();

            ClsComboBoxes.CboLoadActives(_frmCat.cboDistributor, Distributor.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboWareHouse, MaterialWarehouse.Cbo);
            ClsComboBoxes.CboLoadAll(_frmCat.cboMaterialType, ClsObject.MaterialType.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboVariety, Variety.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboLot, Lot.Cbo);
            ClsComboBoxes.CboLoadAll(_frmCat.cboVehicle, Vehicle.Cbo);

            //Tipo material/Material
            List<Tuple<ComboBox, CheckBox?, string>> cboMaterialTypeDepends = new List<Tuple<ComboBox, CheckBox?, string>>();
            cboMaterialTypeDepends.Add(new Tuple<ComboBox, CheckBox?, string>(_frmCat.cboMaterial, _frmCat.chbMaterialRemoved, ClsObject.MaterialType.ColumnId));
            ClsComboBoxes.CboApplyEventCboSelectedValueChangedWithCboDependensColumn(_frmCat.cboMaterialType, cboMaterialTypeDepends, null);

            _frmCat.cboMaterialType.SelectedIndexChanged += (s, e) =>
            {
                if (_frmCat.cboMaterial.Items.Count == 0)
                    ClsComboBoxes.CboLoadActives(_frmCat.cboMaterial, ClsObject.MaterialCatalog.Cbo);

                ClsComboBoxes.Metod_CboSelectedValueChangedWithCboDependensColumn(_frmCat.cboMaterialType, cboMaterialTypeDepends);
            };
            //Variedad/Lote
            List<Tuple<ComboBox, CheckBox?, string>> cboVarietyDepends = new List<Tuple<ComboBox, CheckBox?, string>>();
            cboVarietyDepends.Add(new Tuple<ComboBox, CheckBox?, string>(_frmCat.cboLot, _frmCat.chbLotRemoved, Variety.ColumnId));
            ClsComboBoxes.CboApplyEventCboSelectedValueChangedWithCboDependensColumn(_frmCat.cboVariety, cboVarietyDepends, null);


            //CHECKBOXES
            ClsComboBoxes.CboApplyClickEvent(_frmCat.cboDistributor, _frmCat.chbDistributorRemoved);
            ClsComboBoxes.CboApplyClickEvent(_frmCat.cboWareHouse, _frmCat.chbWareHouseRemoved);
            ClsComboBoxes.CboApplyChbClickEventWithCboDependensColumn(_frmCat.cboMaterial, _frmCat.chbMaterialRemoved, ClsObject.MaterialType.ColumnId, _frmCat.cboMaterialType);
            ClsComboBoxes.CboApplyChbClickEventWithCboDependensColumn(_frmCat.cboLot, _frmCat.chbLotRemoved, Variety.ColumnId, _frmCat.cboVariety);
            ClsComboBoxes.CboApplyClickEvent(_frmCat.cboVehicle, _frmCat.chbVehicleRemoved);
        }

        public void BeginFormAdd()
        {
            AddControlsToListExit();
            LoadControlsAddModify();
            InitializeDtInboundMaterials();
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboOutputType, "01");
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
        private void LoadSearchByCbo()
        {
            _frmCat.cboSearchBy.Items.Clear();
            _frmCat.cboSearchBy.Items.Add("Folio");
            _frmCat.cboSearchBy.Items.Add("Código de salida");
            _frmCat.cboSearchBy.SelectedIndex = 0;
        }
        private void AddControlsToListExit()
        {
            controlListOutput = new ClsControls();
            controlListOutput.ChangeHeadMessage("Para registrar una salida interna debe:\n");
            controlListOutput.Add(_frmAdd.txbId, "Introducir un código de salida.");
            controlListOutput.Add(_frmAdd.txbIdOutputType, "Seleccionar un tipo de salida.");
            controlListOutput.Add(_frmAdd.txbIdWarehouse, "Seleccionar un almacén de salida.");
            controlListOutput.Add(_frmAdd.txbIdLot, "Seleccionar un lote.");
            controlListOutput.Add(_frmAdd.txbIdEmployee, "Seleccionar un empleado.");
            controlListOutput.Add(_frmAdd.txbIdVehicle, "Seleccionar un vehículo.");
            controlListOutput.Add(_frmAdd.cboMatDeliveryMan, "Introducir nombre del repartidor.");
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
            _frmAdd.Text = "Añadir salida interna de material";
            _frmAdd.lblTitle.Text = "Añadir salida interna de material";
            _frmAdd.ShowDialog();
        }
        public void OpenFrmModify(string? idModify)
        {
            IsAddOrModify = false;
            IsModifyUpdate = false;

            if (idModify.IsNullOrEmpty())
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se ha seleccionado una salida interna para modificar.", "Modificar salida interna de material");
                return;
            }
            idAddModify = idModify;
            _frmAdd = new();
            _frmAdd.cls = this;
            _frmAdd.Text = "Modificar salida interna de material";
            _frmAdd.lblTitle.Text = "Modificar salida interna de material";
            _frmAdd.ShowDialog();
        }
        private void LoadControlsAddModify()
        {
            _frmAdd.cboMatDeliveryMan.Tag = "text";
            _frmAdd.cboMatDeliveryMan.DataSource = EMaterialRegisterExit.GetDTMatDeliveryMan();
            _frmAdd.cboMatDeliveryMan.ValueMember = Column.name;

            _frmAdd.txbQuant.Tag = "integerNoEmpty";
            ClsTextBoxes.TxbApplyKeyPressEventInt(_frmAdd.txbQuant);
            dtUnit = ClsQuerysDB.GetDataTable(Unit.QueryCbo);
            dtEmployees = ClsQuerysDB.GetDataTable(employeeCboQuery + employeeCboQueryJoin);
            ClsComboBoxes.LoadComboBoxDataSource(_frmAdd.cboEmployee, dtEmployees);
            ClsComboBoxes.LoadComboBoxDataSource(_frmAdd.cboOutputType, EMaterialRegisterExit.GetDTOutputType());
            ClsComboBoxes.CboLoadActives(_frmAdd.cboWarehouse, MaterialWarehouse.Cbo);
            ClsComboBoxes.CboLoadAll(_frmAdd.cboMaterialType, ClsObject.MaterialType.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboVariety, Variety.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboLot, Lot.Cbo);
            ClsComboBoxes.CboLoadAll(_frmAdd.cboVehicleType, VehicleType.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboVehicle, Vehicle.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboDistributor, Distributor.Cbo);

            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboEmployee, _frmAdd.txbIdEmployee);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboOutputType, _frmAdd.txbIdOutputType);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboWarehouse, _frmAdd.txbIdWarehouse);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboEmployee, _frmAdd.txbIdEmployee);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboDistributor, _frmAdd.txbIdDistributor);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboLot, _frmAdd.txbIdLot);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboVehicle, _frmAdd.txbIdVehicle);

            //Material/Tipo material
            List<Tuple<ComboBox, CheckBox?, string>> cboMaterialTypeDepends = new List<Tuple<ComboBox, CheckBox?, string>>();
            cboMaterialTypeDepends.Add(new Tuple<ComboBox, CheckBox?, string>(_frmAdd.cboMaterial, _frmAdd.chbMaterialRemoved, ClsObject.MaterialType.ColumnId));
            ClsComboBoxes.CboApplyEventCboSelectedValueChangedWithCboDependensColumn(_frmAdd.cboMaterialType, cboMaterialTypeDepends, _frmAdd.txbIdMaterialType);

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

            //Variedad/Lote
            List<Tuple<ComboBox, CheckBox?, string>> cboVarietyDepends = new List<Tuple<ComboBox, CheckBox?, string>>();
            cboVarietyDepends.Add(new Tuple<ComboBox, CheckBox?, string>(_frmAdd.cboLot, _frmAdd.chbLotRemoved, Variety.ColumnId));
            ClsComboBoxes.CboApplyEventCboSelectedValueChangedWithCboDependensColumn(_frmAdd.cboVariety, cboVarietyDepends, _frmAdd.txbIdVariety);

            //Tipo de Vehiculo/Vehiculo
            List<Tuple<ComboBox, CheckBox?, string>> cboVehicleTypeDepends = new List<Tuple<ComboBox, CheckBox?, string>>();
            cboVehicleTypeDepends.Add(new Tuple<ComboBox, CheckBox?, string>(_frmAdd.cboVehicle, _frmAdd.chbVehicleRemoved, VehicleType.ColumnId));
            ClsComboBoxes.CboApplyEventCboSelectedValueChangedWithCboDependensColumn(_frmAdd.cboVehicleType, cboVehicleTypeDepends, _frmAdd.txbIdVehicleType);


            //CHECKBOXES
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboWarehouse, _frmAdd.chbWarehouseRemoved);
            ClsComboBoxes.CboApplyChbClickEventWithCboDependensColumn(_frmAdd.cboMaterial, _frmAdd.chbMaterialRemoved, ClsObject.MaterialType.ColumnId, _frmAdd.txbIdMaterialType);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboVariety, _frmAdd.chbVarietyRemoved);
            ClsComboBoxes.CboApplyChbClickEventWithCboDependensColumn(_frmAdd.cboLot, _frmAdd.chbLotRemoved, Variety.ColumnId, _frmAdd.txbIdVariety);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboVehicleType, _frmAdd.chbVehicleTypeRemoved);
            ClsComboBoxes.CboApplyChbClickEventWithCboDependensColumn(_frmAdd.cboVehicle, _frmAdd.chbVehicleRemoved, VehicleType.ColumnId, _frmAdd.txbIdVehicleType);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboDistributor, _frmAdd.chbDistributorRemoved);
        }
        private void LoadControlsModify()
        {
            entity = new();
            entity.GetMaterialOutbound(idAddModify);
            entity.GetMaterialOutboundMaterials(idAddModify);

            _frmAdd.txbId.Text = entity.idMatOutbound;
            _frmAdd.dtpDate.Value = entity.dateOutbound;
            _frmAdd.cboMatDeliveryMan.Text = entity.matDeliveryMan;

            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboOutputType, entity.idOutputType);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboWarehouse, entity.idWarehouse);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboEmployee, entity.idEmployee);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboVariety, entity.idVariety);
            string idLotVariety = entity.idLot + "|" + entity.idVariety;
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboLot, idLotVariety);
            ClsComboBoxes.CboSelectIndexWithTextInValueMemberKeepingFilter(_frmAdd.cboVehicle, entity.idVehicle);

            dtInboundMaterials.CopyDataFrom(entity.dtMaterials);

            _frmAdd.dgvMaterialList.DataSource = dtInboundMaterials;
        }
        private EMaterialRegisterExit SetEntity()
        {
            entity = new();
            entity.idMatOutbound = _frmAdd.txbId.Text;
            entity.dateOutbound = _frmAdd.dtpDate.Value;
            entity.matDeliveryMan = _frmAdd.cboMatDeliveryMan.Text;
            entity.idOutputType = _frmAdd.txbIdOutputType.Text;
            entity.idWarehouse = _frmAdd.txbIdWarehouse.Text;
            entity.idEmployee = _frmAdd.txbIdEmployee.Text;
            if(_frmAdd.txbIdLot.Text.Length == 7)
            {
                entity.idLot = _frmAdd.txbIdLot.Text.Substring(0,4);
                entity.idVariety = _frmAdd.txbIdLot.Text.Substring(5, 2);
            }
            entity.idVehicle = _frmAdd.txbIdVehicle.Text;

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
                    MessageBox.Show($"Se ha agregado la salida de campo con código: {idAddModify}", "Añadir salida de material");

                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo agregar la salida de campo.", "Añadir salida de material");
                }
            }
            else
            {
                ModifyProcedure();

                if (IsModifyUpdate)
                {
                    MessageBox.Show($"Se ha modificado la salida de campo con el código: {idAddModify}", "Modificar salida de material");

                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo modificar la salida de campo.", "Modificar salida de material");
                }
            }
        }

        public void CloseFrmAddModify()
        {
            Dispose(); //LIBERAR IMAGENES
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
            //AQUI SE DEJAN TODAS LAS COLUMNAS Y LUEGO SE OCULTAN, PARA PODER TRABAJAR CON LA MISMA VISTA DE LA BASE DE DATOS (vw_PackMatOutputExitMaterials)
            dtInboundMaterials = new DataTable();
            dtInboundMaterials.Columns.Add("Código", typeof(string));
            dtInboundMaterials.Columns.Add("Tipo", typeof(string));
            dtInboundMaterials.Columns.Add("Material", typeof(string));
            dtInboundMaterials.Columns.Add("Cantidad", typeof(string));
            dtInboundMaterials.Columns.Add("Unidad", typeof(string));
            dtInboundMaterials.Columns.Add("Folio", typeof(string));
            dtInboundMaterials.Columns.Add("Distribuidor", typeof(string));
            dtInboundMaterials.Columns.Add("Productor", typeof(string)); //**EXTERNA
            dtInboundMaterials.Columns.Add("$MXN", typeof(string)); //**EXTERNA
            dtInboundMaterials.Columns.Add("$USD", typeof(string)); //**EXTERNA
            dtInboundMaterials.Columns.Add(EMaterialRegisterExit.cPosition, typeof(string));
            dtInboundMaterials.Columns.Add(EMaterialRegisterExit.cIdMatOutbound, typeof(string));
            dtInboundMaterials.Columns.Add(Distributor.ColumnId, typeof(string));
            dtInboundMaterials.Columns.Add(Grower.ColumnId, typeof(string));
            dtInboundMaterials.Columns.Add(ClsObject.MaterialType.ColumnId, typeof(string));

            _frmAdd.dgvMaterialList.DataSource = dtInboundMaterials;

            _frmAdd.dgvMaterialList.Columns[EMaterialRegisterExit.cPosition].Visible = false;
            _frmAdd.dgvMaterialList.Columns[EMaterialRegisterExit.cIdMatOutbound].Visible = false;
            _frmAdd.dgvMaterialList.Columns[Distributor.ColumnId].Visible = false;
            _frmAdd.dgvMaterialList.Columns[Grower.ColumnId].Visible = false; //**EXTERNA
            _frmAdd.dgvMaterialList.Columns[ClsObject.MaterialType.ColumnId].Visible = false;
            _frmAdd.dgvMaterialList.Columns["Productor"].Visible = false; //**EXTERNA
            _frmAdd.dgvMaterialList.Columns["$MXN"].Visible = false; //**EXTERNA
            _frmAdd.dgvMaterialList.Columns["$USD"].Visible = false; //**EXTERNA
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
            newRow[EMaterialRegisterExit.cPosition] = ""; //no ocupa ir nada
            newRow[EMaterialRegisterExit.cIdMatOutbound] = ""; //no ocupa ir nada
            newRow[Distributor.ColumnId] = _frmAdd.cboDistributor.SelectedValue?.ToString();
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
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboDistributor, rowToModify[Distributor.ColumnId].ToString());

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
        public void BtnLotCatalogSearch(ComboBox cboVariety, ComboBox cboLot)
        {
            //METODO ESPECIFICO PARA ESTOS CASOS CON CboMaterialType con CboMaterialCatalog çomo dependiente
            ClsSelectionForm sel = new();
            sel.OpenSelectionForm("Lot", "Código");

            if (!string.IsNullOrEmpty(sel.SelectedValue))
            {
                if (cboLot.Items.Count == 0)
                    ClsComboBoxes.CboLoadActives(cboLot, ClsObject.MaterialCatalog.Cbo);

                string idVariety = sel.SelectedRow.GetValue("var", Column.id, sel.SelectedValue)?.ToString() ?? string.Empty;

                string idLotVar = sel.SelectedValue + '|' + idVariety; //id compuesta

                ClsComboBoxes.CboSelectIndexWithTextInValueMember(cboVariety, idVariety);

                ClsComboBoxes.CboSelectIndexWithTextInValueMemberKeepingFilter(cboLot, idLotVar);
            }
            else
                cboVariety.SelectedIndex = 0;
        }
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
        public void BtnAddVehicle()
        {
            FrmVehicleAdd vehicleAdd = new();
            vehicleAdd.ShowDialog();
            if (vehicleAdd.cls.IsAddUpdate)
            {
                ClsComboBoxes.CboLoadActives(_frmAdd.cboVehicle, FreightContainer.Cbo);
                _frmAdd.chbVehicleRemoved.Checked = false;
                ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboVehicle, vehicleAdd.cls.idAddModify);
            }
        }
    }
}
