using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods;
using DocumentFormat.OpenXml.Presentation;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Archivo.Manifiesto;

namespace SisUvex.Nomina.Padron.SUA
{
    class ESuaConfig
    {
        public string idSuaConfig { get; set; }
        public string suaPath { get; set; }
        public string idGrower { get; set; }
        public string regPatGrower { get; set; }
        public string suaType { get; set; }
        public string computerName { get; set; }

        public static string GetNextIdSUAConfig()
        {
            string query = "SELECT RIGHT('00' + CAST(ISNULL(MAX(id_SUAConfig), 0) + 1 AS VARCHAR), 2) AS [Id] FROM Nom_SUAConfig";
            return ClsQuerysDB.GetData(query);
        }

        public void GetSuaConfig(string idSuaConfig)
        {
            string query = "select Nom_SUAConfig.*, Pack_Grower.v_regPat from Nom_SUAConfig LEFT JOIN Pack_Grower ON Pack_Grower.id_grower = Nom_SUAConfig.id_grower WHERE id_SUAConfig = @idSuaConfig";

            DataTable dt = ClsQuerysDB.ExecuteParameterizedQuery(query, new Dictionary<string, object> { { "@idSuaConfig", idSuaConfig } });

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                this.idSuaConfig = dr["id_SUAConfig"].ToString();
                this.suaPath = dr["v_suaPath"].ToString();
                this.idGrower = dr["id_grower"].ToString();
                this.regPatGrower = dr["v_regPat"].ToString();
                this.suaType = dr["v_suaType"].ToString();
                this.computerName = dr["v_computerName"].ToString();
            }
        }

        public bool UpdateSuaConfig(string idSuaConfig)
        {
            string query = $"UPDATE Nom_SUAConfig SET v_suaPath = @suaPath, id_grower = @idGrower, v_suaType = @suaType, v_computerName = @computerName, userUpdate = @userUpdate, d_update = CONVERT(DATE, GETDATE()) WHERE id_SUAConfig = @idSuaConfig";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@suaPath", suaPath },
                { "@idGrower", idGrower },
                { "@suaType", suaType },
                { "@computerName", computerName },
                { "@idSuaConfig", idSuaConfig },
                { "@userUpdate", User.GetUserName() }
            };

            return ClsQuerysDB.GetBoolExecuteParameterizedQuery(query, parameters);
        }

        public bool InsertSuaConfig()
        {
            string query = "INSERT INTO Nom_SUAConfig (id_SUAConfig, v_suaPath, id_grower, v_suaType, v_computerName, userCreate, d_create) VALUES (@idSuaConfig, @suaPath, @idGrower, @suaType, @computerName, @userCreate, CONVERT(DATE, GETDATE()))";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@idSuaConfig", GetNextIdSUAConfig() },
                { "@suaPath", suaPath },
                { "@idGrower", idGrower },
                { "@suaType", suaType },
                { "@computerName", computerName },
                { "@userCreate", User.GetUserName() }
            };

            return ClsQuerysDB.GetBoolExecuteParameterizedQuery(query, parameters);
        }

        public static bool DeleteSuaConfig(string idSuaConfig) 
        {
            string query = "DELETE FROM Nom_SUAConfig WHERE id_SUAConfig = @idSuaConfig";
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@idSuaConfig", idSuaConfig } };
            return ClsQuerysDB.GetBoolExecuteParameterizedQuery(query, parameters);
        }

        //public static DataTable GetSuaConfig()
        //{
        //    string query = "select Nom_SUAConfig.*, Pack_Grower.v_regPat from Nom_SUAConfig LEFT JOIN Pack_Grower ON Pack_Grower.id_grower = Nom_SUAConfig.id_grower";
        //    //return ClsQuerysDB.ExecuteQuery(query);
        //}
    }

    class ClsSuaConfig
    {
        public FrmSuaConfigCat _frmCat;
        ESuaConfig eSuaConfig;
        ClsControls controlList;

        public void BeginCat()
        {
            _frmCat ??= new FrmSuaConfigCat();
            _frmCat.cls ??= this;

            ClsComboBoxes.CboLoadActives(_frmCat.cboGrower, ClsObject.Grower.Cbo);

            _frmCat.cboGrower.SelectedIndexChanged += CboGrower_SelectedIndexChanged;

            _frmCat.txbPC.Text = Environment.MachineName;

            if (_frmCat.IsAddModify)
            {
                BeginAdd();
            }
            else
            {
                BeginModify();
            }

            AddControlsToList();
        }

        private void AddControlsToList()
        {
            controlList = new ClsControls();

            controlList.ChangeHeadMessage("Para dar de la configuración de SUA:\n");
            controlList.Add(_frmCat.txbId, "Cargar id de configuración de SUA.");
            controlList.Add(_frmCat.txbPC, "Cargar el nombre del equipo.");
            controlList.Add(_frmCat.txbSUAPath, "Seleccionar la ruta de la aplicación.");
            controlList.Add(_frmCat.txbSUAType, "Escribir el tipo de SUA.");
            controlList.Add(_frmCat.cboGrower, "Seleccionar la razón social.");
            controlList.Add(_frmCat.txbRegPatGrower, "La razón social debe tener registro patronal.");
        }

        public void BeginAdd()
        {
            _frmCat.Text = "Añadir configuración de SUA";
            _frmCat.lblTitle.Text = "Añadir configuración de SUA";
            _frmCat.IsAddModify = true;
            _frmCat.txbId.Text = ESuaConfig.GetNextIdSUAConfig();
            _frmCat.txbSUAPath.Text = string.Empty;
            _frmCat.txbSUAType.Text = string.Empty;
            _frmCat.txbRegPatGrower.Text = string.Empty;
            _frmCat.txbPC.Text = Environment.MachineName;
        }

        public void BeginModify()
        {
            _frmCat.Text = "Modificar configuración de SUA";
            _frmCat.lblTitle.Text = "Modificar configuración de SUA";
            _frmCat.IsAddModify = false;
            eSuaConfig = new ESuaConfig();

            eSuaConfig.GetSuaConfig(_frmCat.idModify);

            _frmCat.txbId.Text = eSuaConfig.idSuaConfig;
            _frmCat.txbSUAPath.Text = eSuaConfig.suaPath;
            _frmCat.txbSUAType.Text = eSuaConfig.suaType;

            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmCat.cboGrower, eSuaConfig.idGrower);
            //RegPat con el selectedIndexChanged

            _frmCat.txbPC.Text = eSuaConfig.computerName;
        }

        private void CboGrower_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_frmCat.cboGrower.SelectedItem is DataRowView selectedRow)
            {
                _frmCat.txbRegPatGrower.Text = selectedRow[ClsObject.Grower.ColumnRegPat].ToString();
            }
        }

        public void BtnSearchSUAPath()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Executable files (*.exe)|*.exe";
                openFileDialog.Title = "Select an EXE file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _frmCat.txbSUAPath.Text = openFileDialog.FileName;
                }
            }
        }

        public void BtnAccept()
        {
            if (!controlList.ValidateControls())
                return;

            ESuaConfig suaConfig = new ESuaConfig
            {
                idSuaConfig = _frmCat.txbId.Text,
                suaPath = _frmCat.txbSUAPath.Text,
                idGrower = _frmCat.cboGrower.SelectedValue.ToString(),
                suaType = _frmCat.txbSUAType.Text,
                computerName = _frmCat.txbPC.Text
            };

            if (_frmCat.IsAddModify)
            {
                _frmCat.IsFrmUpdate = suaConfig.InsertSuaConfig();


                if (_frmCat.IsFrmUpdate)
                    MessageBox.Show("Se guardó la ruta de SUA.", "Configuración SUA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Hubo un error al guardar la ruta de SUA.", "Configuración SUA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _frmCat.IsFrmUpdate = suaConfig.UpdateSuaConfig(suaConfig.idSuaConfig);

                if (_frmCat.IsFrmUpdate)
                    MessageBox.Show("Se guardó la ruta de SUA.", "Configuración SUA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Hubo un error al guardar la ruta de SUA.", "Configuración SUA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (_frmCat.IsFrmUpdate)
                _frmCat.Close();
        }
    }
}
