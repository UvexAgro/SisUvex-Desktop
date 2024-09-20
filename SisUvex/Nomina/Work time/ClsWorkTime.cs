using SisUvex.Catalogos.GTIN_UPC;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using System.Data;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.TextBoxes;
using SisUvex.Catalogos.Metods.CheckBoxes;
using SisUvex.Catalogos.Metods.Values;
using System.Data.SqlClient;
using System.Media;
using System.Reflection.Metadata.Ecma335;


namespace SisUvex.Nomina.Work_time
{
    internal class ClsWorkTime
    {
        SQLControl sql = new SQLControl();
        ClsControls controlList;
        private FrmWorkTimeAdd _frmAdd;
        public FrmWorkTimeCat _frmCat;
        public FrmBoxesPackedPerEmployee frmReport;
        public EWorkTime eWorkTime;
        public ClsDataGridViewCatalogs dgv = new ClsDataGridViewCatalogs();

        private const string ColumnDateWtm = "idFecha";
        private string queryCatalog = $" SELECT [id_workTime] AS '{ClsObject.Column.id}' , FORMAT(d_workTime, 'yyyy-MMM-dd, dddd', 'es-MX') AS 'Fecha' ,FORMAT([d_workTime], 'yyyy-MM-dd') AS '{ColumnDateWtm}', id_ProductionLine AS '{ClsObject.ProductionLine.ColumnName}', [id_workGroup] AS '{ClsObject.WorkGroup.ColumnName}' ,FORMAT([d_dateHourBeginNormal],'yy/MM/dd hh:mm tt', 'es-MX') AS 'Incio hora normal' ,FORMAT([d_dateHourEndNormal],'yy/MM/dd hh:mm tt', 'es-MX') AS 'Fin hora normal' ,FORMAT([d_dateHourBeginExtra],'yy/MM/dd hh:mm tt', 'es-MX') AS 'Inicio hora extra' ,FORMAT([d_dateHourEndExtra],'yy/MM/dd hh:mm tt', 'es-MX') AS 'Fin hora extra', i_workers AS 'Trabajadores' FROM [Nom_WorkTime]";
        private string queryOrderBy = " ORDER BY [d_workTime] DESC";
        public DataTable dtCatalog;
        public DataTable dtCatalogActives;
        public ClsWorkTime()
        {
            _frmCat = new FrmWorkTimeCat(this);

            // _frmAdd = new FrmGtinAdd(_frmCat, this);
        }
        public void BeginFormCat()
        {
            ClsComboBoxes.CboLoadActives(_frmCat.cboProductionLine, ClsObject.ProductionLine.Cbo);
            ClsComboBoxes.CboApplyClickEvent(_frmCat.cboProductionLine, _frmCat.chbActiveProductionLine);

            dgv.queryCatalog = queryCatalog;
            dgv.dgvCatalog = _frmCat.dgvCatalog;

            LoadDgvCatalog();

            _frmCat.dgvCatalog.Columns[ClsObject.Column.id].Visible = false;
            _frmCat.dgvCatalog.Columns[ColumnDateWtm].Visible = false;
        }
        public void LoadDgvCatalog()
        {
            string queryCat = queryCatalog;

            if (_frmCat.cboProductionLine.SelectedIndex > 0)
                queryCat += $" WHERE [id_ProductionLine] = '{_frmCat.cboProductionLine.SelectedValue}'";

            queryCat += queryOrderBy;

            _frmCat.dgvCatalog.DataSource = ClsQuerysDB.GetDataTable(queryCat);
        }
        public void OpenFrmAdd()
        {
            _frmAdd = new FrmWorkTimeAdd(_frmCat, this);
            _frmAdd.Text = "Añadir horario de empaque";
            _frmAdd.lblTitle.Text = "Añadir horario de empaque";
            _frmAdd.IsAddModify = true;

            _frmAdd.ShowDialog();
        }
        public void OpenFrmModify()
        {
            if (_frmCat.dgvCatalog.SelectedRows.Count != 0)
            {
                _frmAdd = new FrmWorkTimeAdd(_frmCat, this);
                _frmAdd.Text = "Modificar horario de empaque";
                _frmAdd.lblTitle.Text = "Modificar horario de empaque";
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

            SetControls();

            if (_frmAdd.IsAddModify)
            {
                //LoadControlsAdd(); //NO SE OCUPA EN AQUÍ
                _frmAdd.dtpDay.Value = DateTime.Today;
            }
            else
                LoadControlsModify();
        }
        public void btnAcceptAddModify()
        {
            if (!controlList.ValidateControls())
                return;

            if (_frmAdd.IsAddModify)
                if (IsWorkTimeEnable())
                    AddProcedure();
                else if (AskForModification())
                    ModifyProcedure();
                else
                    return;
            else
                ModifyProcedure();

            if (_frmAdd.AddIsUpdate)
            {
                LoadDgvCatalog();
                _frmAdd.Close();
            }
        }
        private void LoadControlsModify()
        {
            eWorkTime = new EWorkTime();
            eWorkTime.SetWorkTime(_frmAdd.idModify);

            _frmAdd.dtpDay.Value = eWorkTime.dateWorkTime;
            _frmAdd.dtpBeginNormal.Value = eWorkTime.dateHourBeginNormal;
            _frmAdd.dtpEndNormal.Value = eWorkTime.dateHourEndNormal;
            _frmAdd.dtpEndExtra.Value = eWorkTime.dateHourEndExtra;
            _frmAdd.txbWorkers.Text = eWorkTime.workers;

            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboProductionLine, eWorkTime.idProductionLine);
        }
        private void SetControls()
        {
            ClsComboBoxes.CboLoadActives(_frmAdd.cboProductionLine, ClsObject.ProductionLine.Cbo);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboProductionLine, _frmAdd.chbActiveProductionLine);

            ClsTextBoxes.TxbApplyKeyPressEventInt(_frmAdd.txbWorkers);
        }
        private void AddControlsToList()
        {
            controlList = new ClsControls();

            controlList.ChangeHeadMessage("Para capturar el horario se debe:\n");

            controlList.Add(_frmAdd.cboProductionLine, "Seleccionar banda.");
            controlList.Add(_frmAdd.txbWorkers, "Introducir cantidad de trabajadores.");
        }
        public void AddProcedure()
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_Nom_WorkTimeAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProductionLine", _frmAdd.cboProductionLine.SelectedValue);
                cmd.Parameters.AddWithValue("@Day", _frmAdd.dtpDay.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@dateHourBeginNormal", _frmAdd.dtpBeginNormal.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@dateHourEndNormal", _frmAdd.dtpEndNormal.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@dateHourBeginExtra", _frmAdd.dtpEndExtra.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@dateHourEndExtra", _frmAdd.dtpEndExtra.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@workers", _frmAdd.txbWorkers.Text);
                cmd.Parameters.AddWithValue("@userCreate", User.GetUserName());

                cmd.ExecuteNonQuery();
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
                SqlCommand cmd = new SqlCommand("sp_Nom_WorkTimeModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idWorkTime", _frmAdd.idModify);
                cmd.Parameters.AddWithValue("@idProductionLine", _frmAdd.cboProductionLine.SelectedValue);
                cmd.Parameters.AddWithValue("@Day", _frmAdd.dtpDay.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@dateHourBeginNormal", _frmAdd.dtpBeginNormal.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@dateHourEndNormal", _frmAdd.dtpEndNormal.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@dateHourBeginExtra", _frmAdd.dtpEndNormal.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@dateHourEndExtra", _frmAdd.dtpEndExtra.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@workers", _frmAdd.txbWorkers.Text);
                cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());

                cmd.ExecuteNonQuery();
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
        public void OpenFrmReport(int reportType)
        {//reportType 1 para reporte de campo, 2 para reporte de empaque
            if (_frmCat.dgvCatalog.SelectedRows.Count != 0)
            {
                frmReport = new FrmBoxesPackedPerEmployee();
                frmReport.cls = this;
                frmReport.reportType = reportType;
                frmReport.idProductionLine = _frmCat.dgvCatalog.SelectedRows[0].Cells[ClsObject.ProductionLine.ColumnName].Value.ToString();
                frmReport.dWorkTime = _frmCat.dgvCatalog.SelectedRows[0].Cells[ColumnDateWtm].Value.ToString();
                frmReport.MdiParent = FrmMenu.FrmMenuInstance;
                frmReport.Show();
            }
            else
                SystemSounds.Exclamation.Play();
        }

        public void BeginFrmReport(int reportType)
        {//reportType 1 para reporte de campo, 2 para reporte de empaque
            string rType = reportType.ToString();
            string date = DateTime.Parse(frmReport.dWorkTime).ToString("dddd, dd-MMMM-yyyy");
            string priceType = "Campo";
            if (reportType == 2)
                priceType = "Empaque";

            frmReport.lblSubTitle.Text = $"Banda: {frmReport.idProductionLine}       Fecha: {date}       Precios para: {priceType}";
            frmReport.dgvCatalog.DataSource = ClsQuerysDB.GetDataTable($"EXEC sp_NomPackedBoxEmployeePerDay '{frmReport.idProductionLine}', '{frmReport.dWorkTime}', '{rType}'");
        }

        private bool IsWorkTimeEnable()
        {
            string date = _frmAdd.dtpDay.Value.ToString("yyyy-MM-dd");
            string idProductionLine = _frmAdd.cboProductionLine.SelectedValue.ToString();
            string qry = $"SELECT id_workTime FROM Nom_WorkTime WHERE d_workTime = '{date}' AND id_ProductionLine = '{idProductionLine}'";
            string workTimeId = ClsQuerysDB.GetData(qry);
            if (!string.IsNullOrEmpty(workTimeId))
            {
                _frmAdd.idModify = workTimeId; //PARA EL DE MODIFICAR
                return false;
            }
            else
                return true;
        }

        private bool AskForModification()
        {
            string dateName = _frmAdd.dtpDay.Value.ToString("dddd, dd-MMMM-yyyy");
            string nameProductionLine = _frmAdd.cboProductionLine.Text.ToString();

            DialogResult result = MessageBox.Show($"El horario con para la banda {nameProductionLine} con fecha {dateName} ya existe. ¿Desea sobrescribirlo?", "Horarios de empaque", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }
    }
}
