using System;
using System.Data;
using System.Media;
using System.Text;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.Querys;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Catalogos.FreightContainer
{
    internal class ClsFreightContainer
    {
        ClsControls controlList = null!;
        public FrmFreightContainerAdd _frmAdd = null!;
        public FrmFreightContainerCat _frmCat = null!;
        public EFreightContainer entity = null!;

        /// <summary>
        /// Requiere vista <c>vw_PackFreightContainerCat</c> con columnas ocultas
        /// <see cref="ClsObject.TransportLine.ColumnId"/> y <see cref="ClsObject.TransportLine.ColumnActive"/> (p. ej. <c>tln.c_active AS [ActiveTransportLine]</c>).
        /// </summary>
        private readonly string queryCatalog = $" SELECT cat.*  FROM vw_PackFreightContainerCat cat ";

        ClsDGVCatalog? dgv;
        DataTable dtCatalog = null!;

        public bool IsAddOrModify = true, IsAddUpdate = false, IsModifyUpdate = false;
        public string? idAddModify;

        private static string EscapeRowFilterValue(string? value)
        {
            return (value ?? string.Empty).Replace("'", "''");
        }

        #region Filtros Catálogo activos, cboTransportLine y btnSearchFco
        private string SetStringRowFilterCatalog()
        {
            if (dtCatalog == null)
                return string.Empty;

            var parts = new StringBuilder();

            if (!_frmCat.chbRemoved.Checked && dtCatalog.Columns.Contains(Column.active + "2"))
            {
                if (parts.Length > 0)
                    parts.Append(" AND ");
                parts.Append($" [{Column.active}2] = '1' ");
            }

            string? lineId = _frmCat.cboTransportLine.ComboValueOrNull();
            if (!string.IsNullOrEmpty(lineId) && dtCatalog.Columns.Contains(ClsObject.TransportLine.ColumnId))
            {
                if (parts.Length > 0)
                    parts.Append(" AND ");
                parts.Append($" [{ClsObject.TransportLine.ColumnId}] = '{EscapeRowFilterValue(lineId)}' ");
            }
            else
            {
                if (!_frmCat.chbFreightContainerTransportLineRemoved.Checked && dtCatalog.Columns.Contains(ClsObject.TransportLine.ColumnActive))
                {
                    if (parts.Length > 0)
                        parts.Append(" AND ");
                    parts.Append($" [{ClsObject.TransportLine.ColumnActive}] = '1' ");
                }
            }

            return parts.ToString();
        }

        /// <summary>
        /// Búsqueda o filtro de catálogo, no ambos: con texto, <see cref="ClsDGVCatalog.CatalogDataViewTextSearch.GetAlphanumericRowFilterExpression"/>
        /// (columna interna <c>__textSearchKey</c>); 77UA1Z y 77-UA-1Z comparten clave. Sin texto, <see cref="SetStringRowFilterCatalog"/>.
        /// </summary>
        public void SetFilterCatalogBySearchFreightContainer()
        {
            if (dtCatalog == null)
                return;

            if (dgv != null && !string.IsNullOrWhiteSpace(_frmCat.txbSearchFreightContainer?.Text))
            {
                string t = _frmCat.txbSearchFreightContainer.Text;
                if (string.IsNullOrEmpty(ClsDGVCatalog.CatalogDataViewTextSearch.ToAlphanumericKey(t)))
                {
                    dgv.TextSearch.ResetForRowFilterAfterTextSearch();
                    dtCatalog.DefaultView.RowFilter = SetStringRowFilterCatalog();
                }
                else
                {
                    string onlySearch = dgv.TextSearch.GetAlphanumericRowFilterExpression(t);
                    dtCatalog.DefaultView.RowFilter = string.IsNullOrEmpty(onlySearch) ? SetStringRowFilterCatalog() : onlySearch;
                }
                return;
            }

            dgv?.TextSearch.ResetForRowFilterAfterTextSearch();
            dtCatalog.DefaultView.RowFilter = SetStringRowFilterCatalog();
        }

        /// <summary>Reaplica búsqueda; con textbox vacío vuelve al filtro de catálogo (combo/checkbox activos, etc.).</summary>
        public void BtnSearchFreightContainer() => SetFilterCatalogBySearchFreightContainer();
        public void SetFilterCatalog()
        {
            if (dtCatalog == null)
                return;
            dgv?.TextSearch.ResetForRowFilterAfterTextSearch();
            dtCatalog.DefaultView.RowFilter = SetStringRowFilterCatalog();
        }
        #endregion filtros

        public void BeginFormCat()
        {
            _frmCat ??= new();
            _frmCat.cls ??= this;

            dtCatalog = ClsQuerysDB.GetDataTable(queryCatalog + " WHERE 1 = 1 ");
            dgv = new ClsDGVCatalog(_frmCat.dgvCatalog, dtCatalog);
            dgv.TextSearch.AddColumns(Column.id, "N. Económico", "Placas US", "Placas MX", "Línea de transporte");
            dgv.TextSearch.PopulateTextSearchKeyColumnInBackground(_frmCat);
            dgv.AddHideColumn(ClsDGVCatalog.CatalogDataViewTextSearch.TextSearchKeyColumn);

            dgv.AddHideColumn(ClsObject.TransportLine.ColumnId);
            dgv.AddHideColumn(ClsObject.TransportLine.ColumnActive);
            dgv.HideColumnsList();

            ClsComboBoxes.CboLoadActives(_frmCat.cboTransportLine, ClsObject.TransportLine.Cbo);
            ClsComboBoxes.CboApplyClickEvent(_frmCat.cboTransportLine, _frmCat.chbTransportLineRemoved);

            _frmCat.cboTransportLine.SelectedIndexChanged += (_, _) => SetFilterCatalog();

            ClsDGVCatalog.DgvApplyCellFormattingEventSecundarySoftInactive(_frmCat.dgvCatalog, ClsObject.TransportLine.ColumnActive, ClsObject.TransportLine.ColumnName); //COLOR ROSADO PARA LINEAS DE TRANSPORTE INACTIVAS

            ChbRemovedFilter();
        }

        public void BeginFormAdd()
        {
            AddControlsToList();
            LoadControls();

            if (IsAddOrModify)
            {
                _frmAdd.cboActive.SelectedIndex = 1;
                _frmAdd.txbId.Text = EFreightContainer.GetNextId();
            }
            else
            {
                LoadControlsModify();
            }
        }

        private void AddControlsToList()
        {
            controlList = new ClsControls();

            controlList.ChangeHeadMessage("Para dar de alta una caja refrigerada debe:\n");
            controlList.Add(_frmAdd.txbId, "Ingresar el código de la caja.");
            controlList.Add(_frmAdd.txbIdTransportLine, "Seleccionar la línea de transporte.");
            controlList.Add(_frmAdd.txbEcoNumber, "Ingresar el número económico.");
        }

        private void LoadControls()
        {
            _frmAdd.cboTypeContainer.Tag = "text";
            ClsComboBoxes.CboLoadAllWithoutTextSelect(_frmAdd.cboTypeContainer, ClsObject.FreightContainer.CboTypeContainer);
            _frmAdd.cboTypeContainer.SelectedIndex = -1;

            ClsComboBoxes.CboLoadActives(_frmAdd.cboTransportLine, ClsObject.TransportLine.Cbo);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboTransportLine, _frmAdd.chbTransportLineRemoved);
            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboTransportLine, _frmAdd.txbIdTransportLine);
        }

        public void OpenFrmAdd()
        {
            IsAddOrModify = true;
            IsAddUpdate = false;
            idAddModify = null;
            _frmAdd = new();
            _frmAdd.cls = this;
            _frmAdd.Text = "Añadir caja refrigerada";
            _frmAdd.lblTitle.Text = "Añadir caja refrigerada";
            _frmAdd.ShowDialog();
        }

        public void OpenFrmModify(string? idModify)
        {
            IsAddOrModify = false;
            IsModifyUpdate = false;
            if (string.IsNullOrEmpty(idModify))
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se ha seleccionado una caja para modificar.", "Modificar caja refrigerada");
                return;
            }

            idAddModify = idModify;
            _frmAdd = new();
            _frmAdd.cls = this;
            _frmAdd.Text = "Modificar caja refrigerada";
            _frmAdd.lblTitle.Text = "Modificar caja refrigerada";
            _frmAdd.ShowDialog();
        }

        private void LoadControlsModify()
        {
            entity = new();
            entity.GetFreightContainer(idAddModify);

            _frmAdd.txbId.Text = entity.idFreightContainer;
            _frmAdd.txbEcoNumber.Text = entity.ecoNumber;
            _frmAdd.txbPlateUS.Text = entity.plateUS;
            _frmAdd.txbPlateMX.Text = entity.plateMX;
            _frmAdd.txbYear.Text = entity.year;
            _frmAdd.txbBrand.Text = entity.brand;
            _frmAdd.cboTypeContainer.Text = entity.typeContainer;
            _frmAdd.txbSize.Text = entity.size?.ToString() ?? string.Empty;
            _frmAdd.txbThermometer.Text = entity.thermometer;
            _frmAdd.cboActive.SelectedIndex = entity.active;
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboTransportLine, entity.idTransportLine);
        }

        private EFreightContainer SetEntity()
        {
            entity = new();
            entity.idFreightContainer = _frmAdd.txbId.Text;
            entity.ecoNumber = _frmAdd.txbEcoNumber.Text;
            entity.plateUS = _frmAdd.txbPlateUS.Text;
            entity.plateMX = _frmAdd.txbPlateMX.Text;
            entity.year = _frmAdd.txbYear.Text;
            entity.brand = _frmAdd.txbBrand.Text;
            entity.typeContainer = _frmAdd.cboTypeContainer.Text;
            string? sizeText = _frmAdd.txbSize.Text?.Trim();
            if (string.IsNullOrEmpty(sizeText))
                entity.size = null;
            else
                entity.size = int.TryParse(sizeText, out int s) ? s : null;
            entity.thermometer = _frmAdd.txbThermometer.Text.Trim();
            entity.active = _frmAdd.cboActive.SelectedIndex;
            entity.idTransportLine = _frmAdd.txbIdTransportLine.Text;

            return entity;
        }

        public void AddProcedure()
        {
            EFreightContainer addEntity = new();
            addEntity = SetEntity();
            var result = addEntity.AddProcedure();
            IsAddUpdate = result.Item1;
            idAddModify = result.Item2;
        }

        public void ModifyProcedure()
        {
            EFreightContainer modifyEntity = new();
            modifyEntity = SetEntity();
            var result = modifyEntity.ModifyProcedure();
            IsModifyUpdate = result.Item1;
            idAddModify = result.Item2;
        }

        public void BtnAccept()
        {
            if (!controlList.ValidateControls())
                return;

            if (IsAddOrModify)
            {
                AddProcedure();
                if (IsAddUpdate)
                {
                    _frmAdd.txbId.Text = idAddModify;
                    MessageBox.Show($"Se ha agregado la caja con código: {idAddModify}", "Añadir caja refrigerada");
                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo agregar la caja.", "Añadir caja refrigerada");
                }
            }
            else
            {
                ModifyProcedure();

                if (IsModifyUpdate)
                {
                    MessageBox.Show($"Se ha modificado la caja con el código: {idAddModify}", "Modificar caja refrigerada");
                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo modificar la caja.", "Modificar caja refrigerada");
                }
            }
        }

        public void CloseFrmAddModify()
        {
            _frmAdd.Close();
        }

        public void BtnActiveProcedure(string id, string activeValue)
        {
            bool result = EFreightContainer.ActiveProcedure(id, activeValue);

            if (result)
                dgv!.ChangeActiveCell(_frmCat.dgvCatalog, activeValue);
        }

        public void AddNewRowByIdInDGVCatalog()
        {
            string esc = idAddModify?.Replace("'", "''") ?? "";
            DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalog + $" WHERE [{Column.id}] = '{esc}'");
            dgv!.AddNewRowToDGV(newIdRow);
            SetFilterCatalog();
        }

        public void ModifyRowByIdInDGVCatalog()
        {
            string esc = idAddModify?.Replace("'", "''") ?? "";
            DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalog + $" WHERE [{Column.id}] = '{esc}'");
            dgv!.ModifyIdRowInDGV(newIdRow);
            SetFilterCatalog();
        }

        public void ChbRemovedFilter()
        {
            if (dgv == null)
                return;

            if (!_frmCat.chbRemoved.Checked)
                dgv.CopyActiveValuesToHiddenColumn();

            SetFilterCatalog();
        }

        public void BtnTransportLineFilter()
        {
            SetFilterCatalog();
        }
    }
}
