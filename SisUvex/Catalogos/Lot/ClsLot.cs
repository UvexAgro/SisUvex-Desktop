using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using System.Data;
using SisUvex.Catalogos.Metods;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.CheckBoxes;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.WorkGroup;
using System.Media;
using static SisUvex.Catalogos.Metods.ClsObject;
using Microsoft.IdentityModel.Tokens;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using iText.Kernel.Pdf;

namespace SisUvex.Catalogos.Lot
{
    internal class ClsLot
    {
        private static string _columnActive2 = ClsObject.Column.active + "2";
        private static string _columnVariety = "var";
        SQLControl sql = new SQLControl();
        ClsControls controlList;
        public FrmLotAdd _frmAdd;
        public FrmLotCat _frmCat;
        public ELot eLot;
        //public ClsDataGridViewCatalogs dgv = new ClsDataGridViewCatalogs();
        private string queryCatalogo = $" SELECT Activo AS '{_columnActive2}', * FROM vw_PackLotCat ";
        public DataView _dvCatalogo;

        public void BeginFormCat()
        {
            _dvCatalogo = new DataView(ClsQuerysDB.GetDataTable(queryCatalogo));
            _dvCatalogo.RowFilter = $"{_columnActive2} = '1'";
            _frmCat.dgvCatalog.DataSource = _dvCatalogo;
            _frmCat.dgvCatalog.Columns[_columnActive2].Visible = false;
            _frmCat.dgvCatalog.Columns[_columnVariety].Visible = false;

            ClsDataGridViewCatalogs.DgvApplyCellFormattingEvent(_frmCat.dgvCatalog);

            ClsComboBoxes.CboLoadActives(_frmCat.cboVariety, ClsObject.Variety.Cbo);
            ClsComboBoxes.CboApplyClickEvent(_frmCat.cboVariety, _frmCat.chbRemovedVariety);

            _frmCat.cboVariety.SelectedIndexChanged += (sender, e) =>
            {
                SetFilterCatalog();
            };
        }

        private void ProcedureRemoveRecover(bool active)
        {
            try
            {
                string idLot, idVariety;

                if (_frmCat.dgvCatalog.Rows.Count == 0)
                    return;
                else
                {
                    idLot = _frmCat.dgvCatalog.SelectedRows[0].Cells[ClsObject.Column.id].Value.ToString();
                    idVariety = _frmCat.dgvCatalog.SelectedRows[0].Cells[_columnVariety].Value.ToString();
                }

                string procedureName = "sp_PackLotRemove";

                if (active)
                    procedureName = "sp_PackLotRecover";

                sql.OpenConectionWrite();
                SqlCommand cmd = new(procedureName, sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idLot", idLot);
                cmd.Parameters.AddWithValue("@idVariety", idVariety);
                cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());

                cmd.ExecuteNonQuery();

                _frmCat.dgvCatalog.SelectedRows[0].Cells[ClsObject.Column.active].Value = active ? "1" : "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo eliminar");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public void BtnRecover()
        {
            ProcedureRemoveRecover(true);
        }

        public void BtnRemove()
        {
            ProcedureRemoveRecover(false);
        }

        public void BtnRemoved()
        {
            SetFilterCatalog();
        }

        private void SetFilterCatalog()
        {
            string filter = string.Empty;

            foreach (DataRowView rowView in _dvCatalogo)
            {
                rowView[_columnActive2] = rowView[ClsObject.Column.active];
            }

            if (_frmCat.cboVariety.SelectedIndex > 0)
            {
                filter = $"var = '{_frmCat.cboVariety.SelectedValue}'";
            }

            if (!_frmCat.chbRemoved.Checked)
            {
                if (filter != string.Empty)
                    filter += " AND ";

                filter += "Activo = 1";
            }

            _dvCatalogo.RowFilter = filter;
        }

        public void OpenFrmAdd()
        {
            _frmAdd = new FrmLotAdd();
            _frmAdd.cls = this;
            _frmAdd.Text = "Añadir lote";
            _frmAdd.lblTitle.Text = "Añadir lote";
            _frmAdd.IsAddModify = true;

            _frmAdd.ShowDialog();
        }
        public void BeginFormAdd()
        {
            AddControlsToList();

            CargarComboBoxes();

            if (_frmAdd.IsAddModify)
            {
                _frmAdd.chbActive.Checked = true;
                _frmAdd.spnId.Text = ClsQuerysDB.GetData("SELECT FORMAT( (SELECT MIN(t1.id_lot + 1) FROM Pack_Lot t1 WHERE NOT EXISTS ( SELECT 1 FROM Pack_Lot t2 WHERE t2.id_lot = t1.id_lot + 1 ) ), '0000' ) AS 'Id'").ToString();
            }
            else
            {
                _frmAdd.spnId.Enabled = false;

                _frmAdd.txbIdVariety.Enabled = false;
                _frmAdd.cboVariety.Enabled = false;
                _frmAdd.chbActiveVariety.Enabled = false;
                _frmAdd.btnSearchVariety.Enabled = false;

                LoadControlsModify();
            }
        }

        private void AddControlsToList()
        {
            controlList = new ClsControls();

            controlList.ChangeHeadMessage("Para dar de alta una cuadrilla debe:\n");
            controlList.Add(_frmAdd.spnId, "Ingresar el código de lote de 4 números.");
            controlList.Add(_frmAdd.txbName, "Ingrese el nombre del lote");
            controlList.Add(_frmAdd.txbIdVariety, "Seleccionar una variedad.");
            controlList.Add(_frmAdd.nudHa, "Ingresar las hectáreas.");
            controlList.Add(_frmAdd.dtpDate, "Seleccionar una fecha.");
        }

        private void CargarComboBoxes()
        {
            ClsComboBoxes.CboLoadActives(_frmAdd.cboVariety, ClsObject.Variety.Cbo);

            ClsComboBoxes.CboApplyTextChangedEvent(_frmAdd.cboVariety, _frmAdd.txbIdVariety);

            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboVariety, _frmAdd.chbActiveVariety);
        }

        public void OpenFrmModify()
        {
            if (_frmCat.dgvCatalog.SelectedRows.Count != 0)
            {
                _frmAdd = new FrmLotAdd();
                _frmAdd.cls = this;
                _frmAdd.Text = "Modificar lote";
                _frmAdd.lblTitle.Text = "Modificar lote";
                _frmAdd.IsAddModify = false;

                _frmAdd.idLotModify = _frmCat.dgvCatalog.SelectedRows[0].Cells[ClsObject.Column.id].Value.ToString();
                _frmAdd.idVarietyModify = _frmCat.dgvCatalog.SelectedRows[0].Cells[_columnVariety].Value.ToString();

                _frmAdd.ShowDialog();
            }
            else
            {
                SystemSounds.Exclamation.Play();
            }
        }

        private void LoadControlsModify()
        {
            eLot = new ELot();
            eLot.SetLot(_frmAdd.idLotModify, _frmAdd.idVarietyModify);

            _frmAdd.spnId.Text = eLot.idLot;
            _frmAdd.txbName.Text = eLot.nameLot;
            _frmAdd.nudHa.Value = eLot.ha;
            _frmAdd.txbIdVariety.Text = eLot.idVariety;
            _frmAdd.chbActive.Checked = eLot.active == 1;
            _frmAdd.dtpDate.Value = eLot.date;

            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboVariety, _frmAdd.txbIdVariety);
        }

        public void btnSearchNameWithIdLot()
        {
            string qryName = " SELECT TOP (1) v_nameLot FROM Pack_Lot WHERE id_lot = @idLot ";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@idLot", _frmAdd.spnId.Text },
            };

            DataTable dt = ClsQuerysDB.ExecuteParameterizedQuery(qryName, parameters);

            if (dt.Rows.Count > 0)
                _frmAdd.txbName.Text = dt.Rows[0][0].ToString();
            else
                SystemSounds.Exclamation.Play();
        }

        public void btnAcceptAddModify()
        {
            if (!controlList.ValidateControls())
                return;

            if (_frmAdd.IsAddModify)
            {
                if (!IsLotDisponible())
                {
                    MessageBox.Show("El lote con esa variedad ya existe", "Catálogo añadir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                AddProcedure();
            }
            else
            {
                ModifyProcedure();
            }

            if (_frmAdd.AddIsUpdate)
                InsertLotInDGV();

            _frmAdd.Close();
        }

        public bool IsLotDisponible()
        {
            string qryName = " SELECT COUNT(id_lot) 'Id' FROM Pack_Lot WHERE id_lot = @idLot AND id_variety  = @idVariety ";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@idLot", _frmAdd.spnId.Text },
                { "@idVariety", _frmAdd.txbIdVariety.Text }
            };

            string count = ClsQuerysDB.GetStringExecuteParameterizedQuery(qryName, parameters);

            int.TryParse(count, out int result);

            if (result > 0)
                return false;
            else
                return true;
        }

        public void AddProcedure()
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackLotAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", _frmAdd.spnId.Text);
                cmd.Parameters.AddWithValue("@active", _frmAdd.chbActive.Checked ? "1" : "0");
                cmd.Parameters.AddWithValue("@name", _frmAdd.txbName.Text);
                cmd.Parameters.AddWithValue("@idVariety", _frmAdd.txbIdVariety.Text);
                cmd.Parameters.AddWithValue("@ha", _frmAdd.nudHa.Value.ToString());
                cmd.Parameters.AddWithValue("@year", _frmAdd.dtpDate.Value);

                cmd.Parameters.AddWithValue("@userCreate", User.GetUserName());

                cmd.ExecuteNonQuery();

                _frmAdd.AddIsUpdate = true;

                MessageBox.Show("Se añadió el lote: " + _frmAdd.spnId.Text + "\n con variedad: " + _frmAdd.txbIdVariety.Text, "Catálogo añadir", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                SqlCommand cmd = new SqlCommand("sp_PackLotModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", _frmAdd.spnId.Text);
                cmd.Parameters.AddWithValue("@name", _frmAdd.txbName.Text);
                cmd.Parameters.AddWithValue("@idVariety", _frmAdd.txbIdVariety.Text);
                cmd.Parameters.AddWithValue("@ha", _frmAdd.nudHa.Value.ToString());
                cmd.Parameters.AddWithValue("@year", _frmAdd.dtpDate.Value);
                cmd.Parameters.AddWithValue("@active", _frmAdd.chbActive.Checked ? "1" : "0");

                cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());

                cmd.ExecuteNonQuery();

                _frmAdd.AddIsUpdate = true;

                MessageBox.Show("Se modificó el lote: " + _frmAdd.spnId.Text + "\n con variedad: " + _frmAdd.txbIdVariety.Text, "Catálogo añadir", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void InsertLotInDGV()
        {
            string qry = $"SELECT Activo AS [{_columnActive2}], * FROM vw_PackLotCat WHERE [{ClsObject.Column.id}] = @idLot AND [{_columnVariety}] = @idVariety";

            Dictionary<string, object> parameters = new()
            {
                { "@idLot", _frmAdd.spnId.Text },
                { "@idVariety", _frmAdd.txbIdVariety.Text }
            };

            DataTable dt = ClsQuerysDB.ExecuteParameterizedQuery(qry, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                DataRowView drv = null;
                bool found = false;

                // Buscar si la fila ya existe en el DataView (_dvCatalog)
                foreach (DataRowView rowView in _dvCatalogo)
                {
                    if (rowView[ClsObject.Column.id].ToString() == dr[ClsObject.Column.id].ToString() &&
                        rowView[_columnVariety].ToString() == dr[_columnVariety].ToString())
                    {
                        drv = rowView;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    // Si no se encuentra, agregar una nueva fila al DataView
                    drv = _dvCatalogo.AddNew();
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
