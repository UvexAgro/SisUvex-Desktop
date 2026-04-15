using SisUvex.Cuadro_de_herramientas;

namespace SisUvex.Usuarios.Role
{
    internal partial class FrmUserRoleAdd : Form
    {
        public ClsUserRole cls = null!;
        public ToggleButton tgbPrintLabels = new();
        public ToggleButton tgbViewCatalogs = new();
        public ToggleButton tgbEditCatalogs = new();
        public ToggleButton tgbCreateRecords = new();
        public ToggleButton tgbOwnFilter = new();
        public ToggleButton tgbProductionReports = new();
        public ToggleButton tgbCostReports = new();
        public ToggleButton tgbAudit = new();
        public ToggleButton tgbSysAdmin = new();

        public FrmUserRoleAdd()
        {
            InitializeComponent();

            AddToggleButtonToPanel(tgbPrintLabels, pnlChbPrintLabels);
            AddToggleButtonToPanel(tgbViewCatalogs, pnlChbViewCatalogs);
            AddToggleButtonToPanel(tgbEditCatalogs, pnlChbEditCatalogs);
            AddToggleButtonToPanel(tgbCreateRecords, pnlChbCreateRecords);
            AddToggleButtonToPanel(tgbOwnFilter, pnlTgbOwnFilter);
            AddToggleButtonToPanel(tgbProductionReports, pnlChbProductionReports);
            AddToggleButtonToPanel(tgbCostReports, pnlChbCostReports);
            AddToggleButtonToPanel(tgbAudit, pnlChbAudit);
            AddToggleButtonToPanel(tgbSysAdmin, pnlChbSysAdmin);
        }

        private void AddToggleButtonToPanel(ToggleButton toggleButton, Panel panel)
        {
            toggleButton.Dock = DockStyle.Fill;
            panel.Controls.Add(toggleButton);
        }

        private void FrmUserRoleAdd_Load(object sender, EventArgs e)
        {
            cls ??= new();
            cls._frmAdd ??= this;
            cls.BeginFormAdd();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            cls.BtnAccept();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
