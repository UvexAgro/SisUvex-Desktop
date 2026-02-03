using iText.Kernel.Pdf;
using Microsoft.IdentityModel.Tokens;
using NPOI.OpenXmlFormats.Dml.Spreadsheet;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.SS.Formula.Functions;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.TextBoxes;
using SisUvex.Catalogos.Metods.Values;
using SisUvex.Catalogos.TransportLine;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace SisUvex.Configuracion.Parameters
{
    internal class ClsParameters
    {
        public FrmParametersCat _frmCat;
        public FrmParametersAdd _frmAdd;
        ClsControls controlList;
        public EParameters entity;
        private string queryCatalog = $" SELECT vw.*, vw.[{ClsObject.Column.active}] AS [{ClsObject.Column.active + "2"}] FROM vw_ConfParameters vw JOIN Conf_Parameters par ON vw.Código = id_parameter AND par.id_typeParameter = vw.id_typeParameter ";
        public static string queryColumnIdTypeParameter = "id_typeParameter";
        ClsDGVCatalog? dgv;
        DataTable dtCatalog;
        public bool IsAddOrModify = true, IsAddUpdate = false, IsModifyUpdate = false;
        public string? idAddModify, id2AddModify, nameParameter; //id2 para el segundo id (tipo de parámetro)
        public string? modifyIdOriginal, modifyIdTypeOriginal;
        /*Nota modificacion:    Si se desea modificar el id del parámetro, preguntar al momento de dar clic en el botón de "Editar" 
                                Si se acepta, entonces desbloqueará el textbox del idParametro y el combobox del tipo de parametro
                                Luego se almacenarán los ids originales para así modificarlos en el procedimiento, aquí en la solución,
                                se debe añadir otro método para manejar cuando se estén modificando los IDs originales del parámetro */
        public void SetFilterDGVCatalog()
        {
            string filter = $" 1 = 1 ";

            if (!_frmCat.chbRemoved.Checked)
                filter += $" AND {ClsObject.Column.active+2} = '1'";

            if (_frmCat.cboType.SelectedIndex > 0)
                filter += $" AND {queryColumnIdTypeParameter} = '{_frmCat.cboType.SelectedValue}'";

            dtCatalog.DefaultView.RowFilter = filter;
        }

        public void BeginFormCat()
        {
            _frmCat ??= new();
            _frmCat.cls ??= this;

            dtCatalog = ClsQuerysDB.GetDataTable(queryCatalog);
            dgv = new ClsDGVCatalog(_frmCat.dgvCatalog, dtCatalog);
            dgv.id2Column = queryColumnIdTypeParameter; //DARLE EL NOMBRE A LA COLUMNA PARA LA SEGUNDA id DEL TIPO DE PARAMETRO

            if (_frmCat.dgvCatalog.Columns.Contains(queryColumnIdTypeParameter)) //OCULTAR Columna id_typeParameter
                _frmCat.dgvCatalog.Columns[queryColumnIdTypeParameter].Visible = false;

            DataTable cboDt = ClsQuerysDB.GetDataTable(EParameters.queryTypeParameters);
            ClsComboBoxes.LoadComboBoxDataSource(_frmCat.cboType, cboDt);
        }
        public void ChbRemovedFilter()
        {
            if (_frmCat.chbRemoved.Checked)
                dgv.CopyActiveValuesToHiddenColumn();

            SetFilterDGVCatalog();
        }
        public void BtnActiveProcedure(string activeValue)
        {
            if (_frmCat.dgvCatalog.SelectedRows.Count != 0)
            {
                string id = _frmCat.dgvCatalog.Rows[_frmCat.dgvCatalog.SelectedRows[0].Index].Cells[ClsObject.Column.id].Value.ToString();
                string id2 = _frmCat.dgvCatalog.Rows[_frmCat.dgvCatalog.SelectedRows[0].Index].Cells["id_typeParameter"].Value.ToString();

                bool result = EParameters.ActiveProcedure(id, id2, activeValue);

                if (result)
                    dgv.ChangeActiveCell(id, id2, activeValue);
            }
            else
                SystemSounds.Exclamation.Play();
        }
        public void BeginFormAdd()
        {
            AddControlsToList();

            LoadControls();

            if (IsAddOrModify)
            {
                _frmAdd.cboActive.SelectedIndex = 1;
                _frmAdd.cboDataType.SelectedValue = "Text";
            }
            else
            {
                LoadControlsModify();
            }
        }
        private void AddControlsToList()
        {
            _frmAdd.txbId.Tag = "integerNoEmpty";

            controlList = new ClsControls();

            controlList.ChangeHeadMessage("Para dar un parámetro debe:\n");
            controlList.Add(_frmAdd.txbIdType, "Seleccionar un tipo de parámetro.");
            controlList.Add(_frmAdd.txbId, "Ingresar el código del parámetro.");
            controlList.Add(_frmAdd.txbName, "Ingresar el nombre del parámetro.");
            controlList.Add(_frmAdd.txbDetail, "Ingresar una descripción.");
            controlList.Add(_frmAdd.txbValue, "Ingresar un valor.");
        }
        private void LoadControls()
        {
            ClsTextBoxes.TxbApplyKeyPressEventInt(_frmAdd.txbId);

            DataTable cboDt = ClsQuerysDB.GetDataTable(EParameters.queryTypeParameters);
            ClsComboBoxes.LoadComboBoxDataSource(_frmAdd.cboType, cboDt);

            //CARGAR COMBOBOX TIPO DE PARÁMETRO Y ASIGNAR EVENTO PARA SU ID Y SIGUIENTE ID DEL PARAMETRO
            _frmAdd.cboType.SelectedValueChanged += (sender, e) =>
            {
                string idType = _frmAdd.cboType.SelectedValue?.ToString() ?? "Text";
                _frmAdd.txbIdType.Text = idType;

                _frmAdd.txbId.Text =  EParameters.GetNextId(idType);
            };

            //CARGAR COMBOBOX DE VALORES
            ClsParameterParser.LoadDataTypeCombo(_frmAdd.cboDataType);
            SetEventsControlsDataType(); //Cambiar Control del valor tipo de dato con ComboBox de tipo de dato
        }

        public void OpenFrmAdd()
        {
            IsAddOrModify = true;
            IsAddUpdate = false;
            idAddModify = null;
            id2AddModify = null;
            _frmAdd = new();
            _frmAdd.cls = this;
            _frmAdd.Text = "Añadir parámetro";
            _frmAdd.lblTitle.Text = "Añadir parámetro";
            _frmAdd.ShowDialog();
        }

        public void OpenFrmModify(string? idModify, string? id2Modify)
        {
            IsAddOrModify = false;
            IsModifyUpdate = false;
            if (idModify.IsNullOrEmpty() || id2Modify.IsNullOrEmpty())
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se ha seleccionado un parámetro para modificar.", "Modificar parámetro");
                return;
            }

            idAddModify = idModify;
            id2AddModify = id2Modify;
            modifyIdOriginal = idModify;    // Estos dos para el control si se desea modificar los Ids del parámetro
            modifyIdTypeOriginal = id2Modify;  //
            _frmAdd = new();
            _frmAdd.cboType.Enabled = false;
            _frmAdd.cls = this;
            _frmAdd.Text = "Modificar parámetro";
            _frmAdd.lblTitle.Text = "Modificar parámetro";
            _frmAdd.ShowDialog();
        }

        private void LoadControlsModify()
        {
            entity = new();
            entity.GetParameter(idAddModify, id2AddModify);

            _frmAdd.cboActive.SelectedIndex = entity.active ?? 1; //EN CASO QUE NO TENGA VALOR =1
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboType, entity.idTypeParameter);
            _frmAdd.txbId.Text = entity.idParameter;
            _frmAdd.txbName.Text = entity.nameParameters;
            _frmAdd.txbDetail.Text = entity.detailParameter;
            //TIPO DE DATO PARA EL VALOR
            //_frmAdd.txbValue.Text = entity.valueParameters;
            _currentDataType = entity.dataTypeParameters;   // "Date", "Int", etc.
            _frmAdd.cboDataType.SelectedValue = _currentDataType;
            SetCurrentValueSafe(entity.valueParameters?.ToString()); //Se elige el tipo de Control dependiendo de el tipo de dato y se le da su valor
        }

        public EParameters SetEntity()
        {
            entity = new();
            entity.idParameter = _frmAdd.txbId.Text;
            entity.idTypeParameter = _frmAdd.txbIdType.Text;
            entity.idOriginalParameter = modifyIdOriginal;
            entity.idOriginalTypeParameter = modifyIdTypeOriginal;
            entity.nameParameters = _frmAdd.txbName.Text;
            entity.detailParameter = _frmAdd.txbDetail.Text;
            entity.dataTypeParameters = _currentDataType; //Es el nombre del tipo de dato
            entity.valueParameters = GetCurrentRawValue();
            entity.active = _frmAdd.cboActive.SelectedIndex;

            return entity;
        }

        public void AddProcedure()
        {
            EParameters addEntity = new();
            addEntity = SetEntity();
            var result = addEntity.AddProcedure();
            IsAddUpdate = result.Item1;
            idAddModify = result.Item2;
            id2AddModify = result.Item3;
            nameParameter = result.Item4; //asi para comprobarlo de la consulta
        }

        public void ModifyProcedure()
        {
            EParameters modifyEntity = new();
            modifyEntity = SetEntity();
            var result = modifyEntity.ModifyProcedure();
            IsModifyUpdate = result.Item1;
            idAddModify = result.Item2;
            id2AddModify = result.Item3;
            nameParameter = result.Item4;
        }

        public void BtnAccept()
        {
            if (!controlList.ValidateControls())
                return;

            string idParameter = ClsValues.FormatZeros(_frmAdd.txbId.Text, "000"),
                   idType = ClsValues.FormatZeros(_frmAdd.txbIdType.Text, "00");
            _frmAdd.txbId.Text = idParameter;
            _frmAdd.txbIdType.Text = idType;

            if (IsAddOrModify)
            {

                if (EParameters.ExistsId(idParameter, idType))
                {
                    MessageBox.Show($"El parámetro con código {idParameter} y Tipo {idType} ya existe.\n\n\tCambie el código o modifique el otro parámetro.", "Añadir parámetro.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                AddProcedure();
                if (IsAddUpdate)
                {
                    _frmAdd.txbId.Text = idAddModify;
                    MessageBox.Show($"Se ha agregado el parámetro: {nameParameter}\ncon código: {idAddModify} y código de tipo: {id2AddModify}", "Añadir parámetro");

                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo agregar el parámetro.", "Añadir parámetro");
                }
            }
            else
            {
                if (EParameters.ExistsIdForModify(idParameter, idType, modifyIdOriginal, modifyIdTypeOriginal))
                {
                    MessageBox.Show($"El parámetro con código {idParameter} y Tipo {idType} ya existe.\n\n-Cambie el código o modifique el otro parámetro.", "Modificar parámetro.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ModifyProcedure();

                if (IsModifyUpdate)
                {
                    MessageBox.Show($"Se ha modificado el parámetro: {nameParameter}\ncon código: {idAddModify} y código de tipo: {id2AddModify}", "Modificar parámetro");

                    _frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo modificar el parámetro.", "Modificar parámetro");
                }
            }
        }

        public void AddNewRowByIdInDGVCatalog()
        {
            string qry = queryCatalog + $" WHERE [{ClsObject.Column.id}] = '{idAddModify}' AND vw.id_typeParameter = '{id2AddModify}'";
            
            DataTable IdRow = ClsQuerysDB.GetDataTable(qry);

            dgv.AddNewRowToDGV(IdRow);
        }

        public void ModifyRowByIdInDGVCatalog()
        {
            string qry = queryCatalog + $" WHERE [{ClsObject.Column.id}] = '{idAddModify}' AND vw.id_typeParameter = '{id2AddModify}'";

            DataTable IdRow = ClsQuerysDB.GetDataTable(qry);

            if (idAddModify != modifyIdOriginal || id2AddModify != modifyIdTypeOriginal)
                ChangeIdByTwoKeys(); //Cambiar los ids en el DGV antes de modificar la fila para asi si no se tienen los mismos (original y nuevo) que se puedan cambiar con el metodo de modificar filas en DGV

            dgv.ModifyIdRowInDGV_With2Ids(IdRow);
        }
        public void ChangeIdByTwoKeys()
        {
            if (!dtCatalog.Columns.Contains(ClsObject.Column.id) || !dtCatalog.Columns.Contains(queryColumnIdTypeParameter))
                return;

            // Escape para DataTable.Select
            static string Esc(string v) => (v ?? "").Replace("'", "''");

            string filter =
                $"{ClsObject.Column.id} = '{Esc(entity.idOriginalParameter)}' AND {queryColumnIdTypeParameter} = '{Esc(entity.idOriginalTypeParameter)}'";

            DataRow[] rows = dtCatalog.Select(filter);

            foreach (DataRow r in rows)
            {
                r[ClsObject.Column.id] = entity.idParameter;
                r[queryColumnIdTypeParameter] = entity.idTypeParameter;
            }

            dtCatalog.AcceptChanges();
        }

        //////////// CONTROL DINÁMICO TIPO DE DATO ////////////
        ///
        private Control? _currentInputControl;   // referencia al control actual (TextBox, DateTimePicker, etc.)
        private string? _currentDataType = "Text"; // opcional: guardar el tipo actual

        private void SetEventsControlsDataType()
        {
            _frmAdd.cboDataType.SelectedValueChanged += (sender, e) =>
            {
                string type = _frmAdd.cboDataType.SelectedValue?.ToString() ?? "Text";
                _currentDataType = type;

                BuildInputControl(type);
                UpdateHintLabel(type); // si quieres seguir usando tu etiqueta de sugerencia
            };
        }

        ///DATOS TAMAÑOS Y FUENTE
        Font _uiFont = new Font("Segoe UI", 12f, FontStyle.Regular);
        Size _sizeTextBox = new Size(300, 29);
        Size _sizeText = new Size(490, 29);
        Size _sizeDate = new Size(130, 29);
        Size _sizeTime = new Size(90, 29);
        Size _sizeDateTime = new Size(180, 29);
        Size _sizeCheckBox = new Size(200, 29);

        //Construir control dinámico según tipo de dato
        private void BuildInputControl(string dataType)
        {
            // Quitar control anterior
            if (_currentInputControl != null)
            {
                _frmAdd.pnlInputHost.Controls.Remove(_currentInputControl);
                _currentInputControl.Dispose();
                _currentInputControl = null;
            }

            Control newControl;

            switch (dataType)
            {
                case "Date":
                    var dtpDate = new DateTimePicker();
                    dtpDate.Format = DateTimePickerFormat.Custom;
                    dtpDate.CustomFormat = "yyyy-MM-dd";
                    dtpDate.Size = _sizeDate;
                    newControl = dtpDate;
                    break;

                case "Time":
                    var dtpTime = new DateTimePicker();
                    dtpTime.Format = DateTimePickerFormat.Custom;
                    dtpTime.CustomFormat = "HH:mm:ss";
                    dtpTime.ShowUpDown = true;
                    dtpTime.Size = _sizeTime;
                    newControl = dtpTime;
                    break;

                case "DateTime":
                    var dtpDateTime = new DateTimePicker();
                    dtpDateTime.Format = DateTimePickerFormat.Custom;
                    dtpDateTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
                    dtpDateTime.ShowUpDown = true;
                    dtpDateTime.Size = _sizeDateTime;
                    newControl = dtpDateTime;
                    break;

                case "Bool":
                    var chk = new CheckBox();
                    chk.Text = "Verdadero / Sí";
                    chk.AutoSize = false;
                    chk.Size = _sizeCheckBox;
                    newControl = chk;
                    break;

                case "Int":
                    var txtInt = new TextBox();
                    txtInt.Size = _sizeTextBox;
                    txtInt.KeyPress += OnlyInteger_KeyPress;
                    newControl = txtInt;
                    break;

                case "Decimal":
                    var txtDec = new TextBox();
                    txtDec.Size = _sizeTextBox;
                    txtDec.KeyPress += OnlyDecimal_KeyPress;
                    newControl = txtDec;
                    break;

                case "Text":
                default:
                    var txt = new TextBox();
                    txt.Size = _sizeText;
                    txt.MaxLength = 70;
                    newControl = txt;
                    break;
            }

            // 🔥 Fuente
            newControl.Font = _uiFont;

            //// 🔥 Posición: centrado en el panel
            //newControl.Left = (_frmAdd.pnlInputHost.Width - newControl.Width) / 2;
            //newControl.Top = (_frmAdd.pnlInputHost.Height - newControl.Height) / 2;

            _frmAdd.pnlInputHost.Controls.Add(newControl);
            _currentInputControl = newControl;
            newControl.Focus();
        }


        //Esto te sirve para guardar a v_valueParameters en el formato del Tipo de dato DataType
        private string? GetCurrentRawValue()
        {
            if (_currentInputControl == null) return null;

            switch (_currentDataType)
            {
                case "Date":
                    return ((DateTimePicker)_currentInputControl).Value.ToString("yyyy-MM-dd");

                case "Time":
                    return ((DateTimePicker)_currentInputControl).Value.ToString("HH:mm:ss");

                case "DateTime":
                    return ((DateTimePicker)_currentInputControl).Value.ToString("yyyy-MM-dd HH:mm:ss");

                case "Bool":
                    return ((CheckBox)_currentInputControl).Checked ? "1" : "0";

                default:
                    return _currentInputControl.Text; // TextBox y otros
            }
        }

        //mostrar sugerencia en label
        private void UpdateHintLabel(string dataType)
        {
            _frmAdd.lblDataTypeExample.Text = dataType switch
            {
                "Int" => "Ej: 123",
                "Decimal" => "Ej: 123.45 (usa punto)",
                "Date" => "Formato: yyyy-MM-dd (Ej: 2026-01-27)",
                "Time" => "Formato: HH:mm:ss (Ej: 04:00:00)",
                "DateTime" => "Formato: yyyy-MM-dd HH:mm:ss (Ej: 2026-01-27 09:30:00)",
                "Bool" => "Valores: true/false (o usar checkbox)",
                _ => "Texto libre"
            };
        }

        //KeyPress para Int y Decimal
        private void OnlyInteger_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        //Decimales con punto(.)
        private void OnlyDecimal_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;

            var tb = sender as TextBox;
            if (tb == null) return;

            if (char.IsDigit(e.KeyChar)) return;

            // permite solo un punto
            if (e.KeyChar == '.' && !tb.Text.Contains('.')) return;

            e.Handled = true;
        }


        //METODOS PARA VERIFICAR TIPO DE DATO Y EVITAR ERRROR SI NO CORRESPONDE
        private void SetCurrentValueSafe(string? rawValue)
        {
            if (_currentInputControl == null)
                return;

            // Normalizar NULL
            if (string.IsNullOrWhiteSpace(rawValue) ||
                rawValue.Trim().Equals("NULL", StringComparison.OrdinalIgnoreCase))
                rawValue = null;

            try
            {
                // Intento normal
                SetCurrentValueInternal(rawValue);
            }
            catch
            {
                _frmAdd.cboDataType.SelectedValue = "Text"; //Si no se puede, cambia a texto
                _currentInputControl.Text = rawValue;
            }
        }

        //VALIDA SI EL VALOR DEL PARAMETRO CORRESPONDE AL DEL TIPO DE DATO DEL PARAMETRO, SINO, SIGUE MOSTRANDOLO COMO TEXTO/STRING
        private void SetCurrentValueInternal(string? rawValue)
        {
            switch (_currentDataType)
            {
                case "Date":
                    var dtpDate = (DateTimePicker)_currentInputControl!;
                    dtpDate.Value = DateTime.ParseExact(rawValue!, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    break;

                case "Time":
                    var dtpTime = (DateTimePicker)_currentInputControl!;
                    var ts = TimeSpan.ParseExact(rawValue!, "hh\\:mm\\:ss", CultureInfo.InvariantCulture);
                    dtpTime.Value = DateTime.Today.Add(ts);
                    break;

                case "DateTime":
                    var dtpDateTime = (DateTimePicker)_currentInputControl!;
                    dtpDateTime.Value = DateTime.ParseExact( rawValue!, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    break;

                case "Bool":
                    var chk = (CheckBox)_currentInputControl!;
                    chk.Checked = rawValue == "1" || rawValue!.Equals("true", StringComparison.OrdinalIgnoreCase) || rawValue.Equals("SI", StringComparison.OrdinalIgnoreCase);
                    break;

                case "Int":
                case "Decimal":
                case "Text":
                default:
                    _currentInputControl!.Text = rawValue ?? string.Empty;
                    break;
            }
        }
    }
}