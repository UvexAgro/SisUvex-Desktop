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


namespace SisUvex.Material.MaterialRegister.Entry
{
    internal class ClsMaterialRegisterEntry
    {
        SQLControl sql = new SQLControl();
        ClsControls? controlListEntry;
        ClsControls? controlListMaterial;
        DataTable? dtUnit;

        public FrmMaterialRegisterEntry _frmAdd;
        public FrmMaterialRegisterEntryCat _frmCat;
        public EMaterialRegisterEntry entity;
        private string queryCatalog = $" SELECT *, [{Column.active}] AS [{Column.active + "2"}] FROM vw_PackWareHousesCat ";
        ClsDGVCatalog dgv;
        DataTable dtCatalog;
        public bool IsAddOrModify = true, IsAddUpdate = false, IsModifyUpdate = false;
        public string? idAddModify;
        private DataTable? dtEmployees;
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
            LoadComboBoxes();
            if (IsAddOrModify)
            {
                //_frmAdd.chbActive.Checked = true; //NO LLEVA
                _frmAdd.txbId.Text = ClsQuerysDB.GetData("SELECT FORMAT(COALESCE(MAX(id_matInbound), 0) +1, '000000000000000') AS [Id] FROM Pack_MatInbound").ToString();
            }
            else
            {
                LoadControlsModify();
            }
        }
        private void AddControlsToListEntry()
        {
            controlListEntry = new ClsControls();
            controlListEntry.ChangeHeadMessage("Para registrar una entrada debe:\n");
            controlListEntry.Add(_frmAdd.txbId, "Ingresar un número de entrada.");
            controlListEntry.Add(_frmAdd.txbInvoice, "Ingresar un folio de entrada.");
            controlListEntry.Add(_frmAdd.txbIdTransportLine, "Seleccionar una línea de transporte.");
            controlListEntry.Add(_frmAdd.txbIdFreightContainer, "Seleccionar una caja.");
            controlListEntry.Add(_frmAdd.dgvMaterialList, "Agregar materiales al listado.");

            controlListMaterial = new ClsControls();
            controlListMaterial.ChangeHeadMessage("Para agregar un material al listado debe:\n");
            controlListMaterial.Add(_frmAdd.txbId, "Seleccionar un material.");
            controlListMaterial.Add(_frmAdd.txbQuant, "Ingresar la cantidad.");
        }

        private void LoadComboBoxes()
        {
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
            cboTransportLineDepends.Add(new Tuple<ComboBox, CheckBox?, string>(_frmAdd.cboFreightContainer, _frmAdd.chbFreightContainerRemoved,                 TransportLine.ColumnId));
            ClsComboBoxes.CboApplyEventCboSelectedValueChangedWithCboDependensColumn(_frmAdd.cboTransportLine, cboTransportLineDepends, _frmAdd.txbIdTransportLine);
        }

        private void LoadControlsModify()
        {
            entity = new EMaterialRegisterEntry();
            entity.GetMaterialEntry(idAddModify ?? "0");

            _frmAdd.txbId.Text = entity.idMatInbound;
            _frmAdd.dtpDate.Value = entity.date;

            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboWarehouse, entity.idWarehouse); ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboTransportLine, entity.idTransportLine);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboDriver, entity.idDriver);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboFreightContainer, entity.idFreightContainer);
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboEmployee, entity.idEmployee);

            //TABLA dtMaterials
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

            //TABLA dtMaterials

            return entity;
        }

        public void AddProcedure()
        {
            EMaterialRegisterEntry eAdd = new();
            eAdd = SetEntity();
            //Tabla dtMaterials
            var result = eAdd.AddProcedure();
            IsAddUpdate = result.Item1;
            idAddModify = result.Item2;
        }

        public void ModifyProcedure()
        {
            EMaterialRegisterEntry eModify = new();
            eModify = SetEntity();
            //Tabla dtMaterials
            var result = eModify.ModifyProcedure();
            IsModifyUpdate = result.Item1;
            idAddModify = result.Item2;
        }

        public void BtnAccept()
        {
            if (!controlListEntry.ValidateControls())
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

        public void OpenFrmAdd()
        {
            IsAddOrModify = true;
            _frmAdd = new FrmMaterialRegisterEntry();
            _frmAdd.cls = this;
            _frmAdd.Text = "Añadir entrada de material";
            _frmAdd.lblTitle.Text = "Añadir entrada de material";
            _frmAdd.ShowDialog();
        }

            public void btnSearchEmployeeO()
            {
                ClsSelectionForm sel = new ClsSelectionForm();

                sel.OpenSelectionForm("EmployeeBasic", "Código");

                if (!string.IsNullOrEmpty(sel.SelectedValue))
                {
                    //_frmAdd.txbIdEmployee.Text = sel.SelectedValue;

                    Dictionary<string, object> parameters = new();
                    parameters.Add("@idEmployee", sel.SelectedValue);

                    string q = employeeCboQuery + " WHERE emp.id_employee = @idEmployee ";

                    DataTable dtEmp = ClsQuerysDB.ExecuteParameterizedQuery(q, parameters);

                    if (dtEmp.Rows.Count > 0)
                    {
                        DataRow row = dtEmp.Rows[0];
                        string employeeData = $"ID: {row[Column.id]}\n" +
                                              $"Nombre: {row[Column.name]}";
                        MessageBox.Show(employeeData, "Datos del Empleado");
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron datos para el empleado seleccionado.", "Datos del Empleado");
                    }

                    dtEmployees?.Rows.Add(dtEmp);

                    //_frmAdd.cboEmployee.SelectedIndex = _frmAdd.cboEmployee.Items.Count - 1;
                }
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

                    // Obtener el DataTable actual del ComboBox
                    DataTable currentDt = (DataTable)_frmAdd.cboEmployee.DataSource;

                    // Verificar si el empleado ya existe en el DataTable
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
                        // Clonar la estructura del nuevo registro para evitar problemas de referencia
                        DataRow rowToAdd = currentDt.NewRow();
                        rowToAdd[Column.id] = newRow[Column.id];
                        rowToAdd[Column.name] = newRow[Column.name];

                        // Añadir la nueva fila al final
                        currentDt.Rows.Add(rowToAdd);

                        // No necesitamos reasignar el DataSource porque ya está referenciado
                    }

                    // Seleccionar el empleado (ya sea el recién añadido o el existente)
                    _frmAdd.cboEmployee.SelectedValue = newRow[Column.id];

                    string employeeData = $"ID: {newRow[Column.id]}\n" +
                                        $"Nombre: {newRow[Column.name]}";
                    MessageBox.Show(employeeData, "Datos del Empleado");
                }
                else
                {
                    MessageBox.Show("No se encontraron datos para el empleado seleccionado.", "Datos del Empleado");
                }
            }
        }
    }
}
