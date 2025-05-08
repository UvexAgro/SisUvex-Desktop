using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.Querys;
using static SisUvex.Catalogos.Metods.ClsObject;
using System.Media;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;
using Microsoft.IdentityModel.Tokens;
using SisUvex.Material.MaterialCatalog;
using SisUvex.Catalogos.Metods.TextBoxes;


namespace SisUvex.Material.MaterialRegister.Entry
{
    internal class ClsMaterialRegisterEntry
    {
        SQLControl sql = new SQLControl();
        ClsControls? controlListInbound;
        ClsControls? controlListMaterial;
        DataTable? dtUnit;

        public FrmMaterialRegisterEntry _frmAdd;
        public FrmMaterialRegisterEntryCat _frmCat;
        public EMaterialRegisterEntry entity;
        private string queryCatalog = $" SELECT cat.* FROM vw_PackMatInbondEntryCat AS cat";
        ClsDGVCatalog dgv;
        DataTable? dtCatalog, dtInboundMaterials, dtEmployees;
        public bool IsAddOrModify = true, IsAddUpdate = false, IsModifyUpdate = false;
        public string? idAddModify;
        private string employeeCboQuery = $" SELECT DISTINCT emp.id_employee AS [{Column.id}], CONCAT_WS(' ',emp.v_lastNamePat, emp.v_lastNameMat, emp.v_name) AS [{Column.name}] FROM Nom_Employees emp ";
        private string employeeCboQueryJoin = $" JOIN Pack_MatInbound mat ON mat.id_employee = emp.id_employee ";
        public void BeginFormCat()
        {
            _frmCat ??= new FrmMaterialRegisterEntryCat();
            _frmCat.cls ??= this;

            dtCatalog = ClsQuerysDB.GetDataTable(queryCatalog);
            dgv = new ClsDGVCatalog(_frmCat.dgvCatalog, dtCatalog);

            LoadComboBoxesCatalog();
        }
        private void LoadComboBoxesCatalog()
        {
            ClsComboBoxes.CboLoadActives(_frmCat.cboDistributor, Distributor.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboWareHouse, MaterialWarehouse.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboTransportLine, TransportLine.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboFreightContainer, FreightContainer.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboGrower, Grower.Cbo);
            ClsComboBoxes.CboLoadAll(_frmCat.cboMaterialType, ClsObject.MaterialType.Cbo);
            ClsComboBoxes.CboLoadActives(_frmCat.cboProvider, ClsObject.MaterialProvider.Cbo);

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
            ClsComboBoxes.CboApplyClickEvent(_frmCat.cboProvider, _frmCat.chbProviderRemoved);
            ClsComboBoxes.CboApplyClickEvent(_frmCat.cboTransportLine, _frmCat.chbTransportLineRemoved);
            ClsComboBoxes.CboApplyChbClickEventWithCboDependensColumn(_frmCat.cboFreightContainer, _frmCat.chbFreightContainerRemoved, TransportLine.ColumnId, _frmCat.cboTransportLine);
            ClsComboBoxes.CboApplyChbClickEventWithCboDependensColumn(_frmCat.cboMaterial, _frmCat.chbMaterialRemoved, ClsObject.MaterialType.ColumnId, _frmCat.cboMaterialType);
        }
        public void BeginFormAdd()
        {
            AddControlsToListEntry();
            LoadControlsAddModify();
            if (IsAddOrModify)
            {
                //_frmAdd.chbActive.Checked = true; //NO LLEVA
                _frmAdd.txbId.Text = ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX(id_matInbound), 0) +1, '000000000000000') AS [Id] FROM Pack_MatInbound").ToString();
            }
            else
            {
                LoadControlsModify();
            }

            InitializeDtInboundMaterials();
        }
        private void AddControlsToListEntry()
        {
            controlListInbound = new ClsControls();
            controlListInbound.ChangeHeadMessage("Para registrar una entrada debe:\n");
            controlListInbound.Add(_frmAdd.txbId, "Ingresar un número de entrada.");
            controlListInbound.Add(_frmAdd.txbIdWarehouse, "Seleccionar un almacén.");
            controlListInbound.Add(_frmAdd.txbIdTransportLine, "Seleccionar una línea de transporte.");
            controlListInbound.Add(_frmAdd.txbIdFreightContainer, "Seleccionar una caja.");
            controlListInbound.Add(_frmAdd.dgvMaterialList, "Agregar materiales al listado.");

            controlListMaterial = new ClsControls();
            controlListMaterial.ChangeHeadMessage("Para agregar un material al listado debe:\n");
            controlListMaterial.Add(_frmAdd.txbInvoice, "Introducir folio/remisión/factura.");
            controlListMaterial.Add(_frmAdd.txbIdMaterial, "Seleccionar un material.");
            controlListMaterial.Add(_frmAdd.txbQuant, "Ingresar la cantidad.");
            controlListMaterial.Add(_frmAdd.txbUSD, "Ser un núméro válido");
            controlListMaterial.Add(_frmAdd.txbMXN, "Ser un núméro válido");
        }

        public void OpenFrmAdd()
        {
            IsAddOrModify = true;
            _frmAdd = new FrmMaterialRegisterEntry();
            _frmAdd.cls = this;
            _frmAdd.Text = "Añadir entrada de material";
            _frmAdd.lblTitle.Text = "Añadir entrada de material";
            _frmAdd.ShowDialog();
        }

        public void OpenFrmModify(string? idModify)
        {
            IsAddOrModify = false;

            if (idModify.IsNullOrEmpty())
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se ha seleccionado una entrada para modificar.", "Modificar entrada de material");
                return;
            }

            idAddModify = idModify;
            _frmAdd = new FrmMaterialRegisterEntry();
            _frmAdd.cls = this;
            _frmAdd.Text = "Modificar entrada de material";
            _frmAdd.lblTitle.Text = "Modificar entrada de material";
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

            dtUnit = ClsQuerysDB.GetDataTable(Unit.QueryCbo);
            dtEmployees = ClsQuerysDB.GetDataTable(employeeCboQuery + employeeCboQueryJoin);
            ClsComboBoxes.LoadComboBoxDataSource(_frmAdd.cboEmployee, dtEmployees);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboWarehouse, MaterialWarehouse.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboProvider, ClsObject.MaterialProvider.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboDistributor, Distributor.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboGrower, Grower.Cbo);
            ClsComboBoxes.CboLoadAll(_frmAdd.cboMaterialType, ClsObject.MaterialType.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboTransportLine, TransportLine.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboFreightContainer, FreightContainer.Cbo);
            ClsComboBoxes.CboLoadActives(_frmAdd.cboDriver, Driver.Cbo);

            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboEmployee, _frmAdd.txbIdEmployee);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboWarehouse, _frmAdd.txbIdWarehouse);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboProvider, _frmAdd.txbIdProvider);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboEmployee, _frmAdd.txbIdEmployee);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboDriver, _frmAdd.txbIdDriver);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboFreightContainer, _frmAdd.txbIdFreightContainer);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboProvider, _frmAdd.txbIdProvider);
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
                _frmAdd.txbIdMaterial.Text = _frmAdd.cboMaterial.SelectedValue?.ToString();

                if (_frmAdd.cboMaterial.SelectedIndex > 0)
                {
                    _frmAdd.txbIdMaterial.Text = _frmAdd.cboMaterial.SelectedValue?.ToString();

                    if (_frmAdd.cboMaterial.SelectedItem is DataRowView selectedRowView)
                    {
                        object? idUnit = selectedRowView[Unit.ColumnId].ToString();
                        if (idUnit != null)
                            _frmAdd.txbUnit.Text = dtUnit?.GetValue(Unit.ColumnName, Column.id, idUnit)?.ToString() ?? string.Empty;
                        else
                            _frmAdd.txbUnit.Text = string.Empty;
                    }
                }
                else
                {
                    _frmAdd.txbUnit.Text = string.Empty;
                    _frmAdd.txbIdMaterial.Text = string.Empty;
                }
            };

            List<Tuple<ComboBox, CheckBox?, string>> cboTransportLineDepends = new List<Tuple<ComboBox, CheckBox?, string>>();
            cboTransportLineDepends.Add(new Tuple<ComboBox, CheckBox?, string>(_frmAdd.cboDriver, _frmAdd.chbDriverRemoved, TransportLine.ColumnId));
            cboTransportLineDepends.Add(new Tuple<ComboBox, CheckBox?, string>(_frmAdd.cboFreightContainer, _frmAdd.chbFreightContainerRemoved, TransportLine.ColumnId));
            ClsComboBoxes.CboApplyEventCboSelectedValueChangedWithCboDependensColumn(_frmAdd.cboTransportLine, cboTransportLineDepends, _frmAdd.txbIdTransportLine);


            //CHECKBOXES
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboWarehouse, _frmAdd.chbWarehouseRemoved);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboProvider, _frmAdd.chbProviderRemoved);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboDistributor, _frmAdd.chbDistributorRemoved);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboGrower, _frmAdd.chbGrowerRemoved);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboTransportLine, _frmAdd.chbTransportLineRemoved);
            ClsComboBoxes.CboApplyChbClickEventWithCboDependensColumn(_frmAdd.cboDriver, _frmAdd.chbDriverRemoved, TransportLine.ColumnId, _frmAdd.txbIdTransportLine);
            ClsComboBoxes.CboApplyChbClickEventWithCboDependensColumn(_frmAdd.cboFreightContainer, _frmAdd.chbFreightContainerRemoved, TransportLine.ColumnId, _frmAdd.txbIdTransportLine);
            ClsComboBoxes.CboApplyChbClickEventWithCboDependensColumn(_frmAdd.cboMaterial, _frmAdd.chbMaterialRemoved, ClsObject.MaterialType.ColumnId, _frmAdd.txbIdMaterialType);
        }

        private void LoadControlsModify()
        {
            entity = new EMaterialRegisterEntry();
            entity.GetMaterialEntry(idAddModify);
            entity.GetMaterialEntryMaterials(idAddModify);

            _frmAdd.txbId.Text = entity.idMatInbound;
            _frmAdd.dtpDate.Value = entity.date;

            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboWarehouse, entity.idWarehouse);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboTransportLine, entity.idTransportLine);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboDriver, entity.idDriver);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboFreightContainer, entity.idFreightContainer);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboEmployee, entity.idEmployee);

            dtInboundMaterials = entity.dtMaterials;
        }

        private EMaterialRegisterEntry SetEntity()
        {
            entity = new EMaterialRegisterEntry();
            entity.idMatInbound = _frmAdd.txbId.Text;
            entity.date = _frmAdd.dtpDate.Value;
            entity.idTransportLine = _frmAdd.txbIdTransportLine.Text;
            entity.idFreightContainer = _frmAdd.txbIdFreightContainer.Text;
            entity.idDriver = _frmAdd.txbIdDriver.Text;
            entity.idWarehouse = _frmAdd.txbIdWarehouse.Text;
            entity.idEmployee = _frmAdd.txbIdEmployee.Text;

            entity.dtMaterials = dtInboundMaterials;

            return entity;
        }

        public void AddProcedure()
        {
            EMaterialRegisterEntry eAdd = new();
            eAdd = SetEntity();
            var result = eAdd.AddProcedureWithMaterials();
            IsAddUpdate = result.Item1;
            idAddModify = result.Item2;
        }

        public void ModifyProcedure()
        {
            EMaterialRegisterEntry eModify = new();
            eModify = SetEntity();
            var result = eModify.ModifyProcedureWithMaterials();
            IsModifyUpdate = result.Item1;
            idAddModify = result.Item2;
        }

        public void BtnAccept()
        {
            if (!controlListInbound.ValidateControls())
                return;

            if (IsAddOrModify)
            {
                AddProcedure();
                if (IsAddUpdate)
                {
                    _frmAdd.txbId.Text = idAddModify;
                    MessageBox.Show($"Se ha agregado la entrada con código: {idAddModify}", "Añadir entrada de material");

                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo agregar la entrada.", "Añadir entrada de material");
                }
            }
            else
            {
                ModifyProcedure();

                if (IsModifyUpdate)
                {
                    MessageBox.Show($"Se ha modificado la entrada con el código: {idAddModify}", "Modificar entrada de material");

                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo modificar la entrada.", "Modificar entrada de material");
                }
            }
        }

        public void CloseFrmAddModify()
        {
            _frmAdd.Close();
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

            // Añadir columnas al DataTable
            //Partes donde se debe cambiar si se modifica:
            //"AddRowToInboundMaterials()", "BtnModifyRowMaterialsSelected()" 
            //dtInboundMaterials.Columns.Add("Tipo", typeof(string));
            dtInboundMaterials.Columns.Add("Código", typeof(string));
            dtInboundMaterials.Columns.Add("Material", typeof(string));
            dtInboundMaterials.Columns.Add("Cantidad", typeof(string));
            dtInboundMaterials.Columns.Add("Unidad", typeof(string));
            dtInboundMaterials.Columns.Add("Folio", typeof(string));
            dtInboundMaterials.Columns.Add("Proveedor", typeof(string));
            dtInboundMaterials.Columns.Add("Distribuidor", typeof(string));
            dtInboundMaterials.Columns.Add("Productor", typeof(string));
            dtInboundMaterials.Columns.Add("$USD", typeof(string));
            dtInboundMaterials.Columns.Add("$MXN", typeof(string));
            dtInboundMaterials.Columns.Add("Obs.", typeof(string));
            dtInboundMaterials.Columns.Add(ClsObject.MaterialProvider.ColumnId, typeof(string));
            dtInboundMaterials.Columns.Add(Distributor.ColumnId, typeof(string));
            dtInboundMaterials.Columns.Add(Grower.ColumnId, typeof(string));

            _frmAdd.dgvMaterialList.DataSource = dtInboundMaterials;

            _frmAdd.dgvMaterialList.Columns[ClsObject.MaterialProvider.ColumnId].Visible = false;
            _frmAdd.dgvMaterialList.Columns[Distributor.ColumnId].Visible = false;
            _frmAdd.dgvMaterialList.Columns[Grower.ColumnId].Visible = false;
            //----[METODOS PARA EL DATAGRIDVIEW DEL ADD/MODIFY]----

            //ConfigureEditableColumns();
        }

        private void ConfigureEditableColumns()
        {
            DataGridViewTextBoxColumn cantidadColumn = (DataGridViewTextBoxColumn)_frmAdd.dgvMaterialList.Columns["Cantidad"];
            cantidadColumn.ValueType = typeof(int);
            cantidadColumn.DefaultCellStyle.Format = "N0";
            cantidadColumn.ReadOnly = false;

            DataGridViewTextBoxColumn usdColumn = (DataGridViewTextBoxColumn)_frmAdd.dgvMaterialList.Columns["$USD"];
            usdColumn.ValueType = typeof(decimal);
            usdColumn.DefaultCellStyle.Format = "N2";
            usdColumn.ReadOnly = false;

            DataGridViewTextBoxColumn mxnColumn = (DataGridViewTextBoxColumn)_frmAdd.dgvMaterialList.Columns["$MXN"];
            mxnColumn.ValueType = typeof(decimal);
            mxnColumn.DefaultCellStyle.Format = "N2";
            mxnColumn.ReadOnly = false;

            _frmAdd.dgvMaterialList.CellValidating += (s, e) =>
            {
                if (e.ColumnIndex == cantidadColumn.Index)
                {
                    if (!int.TryParse(e.FormattedValue.ToString(), out _))
                    {
                        e.Cancel = true;
                        MessageBox.Show("Por favor, ingrese un número entero válido en la columna 'Cantidad'.", "Validación de entrada");
                    }
                }
                else if (e.ColumnIndex == usdColumn.Index || e.ColumnIndex == mxnColumn.Index)
                {
                    if (!decimal.TryParse(e.FormattedValue.ToString(), out _))
                    {
                        e.Cancel = true;
                        MessageBox.Show($"Por favor, ingrese un valor decimal válido en la columna '{_frmAdd.dgvMaterialList.Columns[e.ColumnIndex].HeaderText}'.", "Validación de entrada");
                    }
                }
            };
        }

        public void BtnAddRowMaterialsInEntry()
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
            _frmAdd.txbObs.Text = string.Empty;
        }

        private void AddRowToInboundMaterials()
        {
            DataRow newRow = dtInboundMaterials.NewRow();
            //newRow["Tipo"] = _frmAdd.txbIdMaterial.Text.Substring(0, 2);
            newRow["Código"] = _frmAdd.txbIdMaterial.Text;
            newRow["Material"] = _frmAdd.cboMaterial.GetColumnValue(ClsObject.MaterialCatalog.ColumnName);
            newRow["Cantidad"] = _frmAdd.txbQuant.Text;
            newRow["Unidad"] = _frmAdd.txbUnit.Text;
            newRow["Folio"] = _frmAdd.txbInvoice.Text;
            newRow["Proveedor"] = _frmAdd.cboProvider.GetColumnValue(ClsObject.MaterialProvider.ColumnName);
            newRow["Distribuidor"] = _frmAdd.cboDistributor.GetColumnValue(Distributor.ColumnName);
            newRow["Productor"] = _frmAdd.cboGrower.GetColumnValue(Grower.ColumnName);
            newRow["$USD"] = _frmAdd.txbUSD.Text; //.ToString("N2");
            newRow["$MXN"] = _frmAdd.txbMXN.Text; //.ToString("N2");
            newRow["Obs."] = _frmAdd.txbObs.Text;
            newRow["idProvedor"] = _frmAdd.txbIdProvider.Text;
            newRow["idDistribuidor"] = _frmAdd.txbIdDistributor.Text;
            newRow["idProductor"] = _frmAdd.txbIdGrower.Text;

            dtInboundMaterials.Rows.Add(newRow);
        }

        public void BtnRemoveRowMaterialsInEntry()
        {
            if (_frmAdd.dgvMaterialList.SelectedRows.Count > 0)
            {
                RemoveRowMaterialsInEntry();
            }
            else
                SystemSounds.Exclamation.Play();
        }

        private void RemoveRowMaterialsInEntry()
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
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboMaterialType, rowToModify["Código"].ToString().Substring(0, 2));
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboMaterial, rowToModify["Código"].ToString());
            _frmAdd.txbQuant.Text = rowToModify["Cantidad"].ToString();
            _frmAdd.txbInvoice.Text = rowToModify["Folio"].ToString();
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboProvider, rowToModify[ClsObject.MaterialProvider.ColumnId].ToString());
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboDistributor, rowToModify[Distributor.ColumnId].ToString());
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboGrower, rowToModify[Grower.ColumnId].ToString());
            _frmAdd.txbUSD.Text = rowToModify["$USD"].ToString();
            _frmAdd.txbMXN.Text = rowToModify["$MXN"].ToString();
            _frmAdd.txbObs.Text = rowToModify["Obs."].ToString();

            RemoveRowMaterialsInEntry();
        }
    }
}
