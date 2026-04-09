using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisUvex.Cuadro_de_herramientas;

namespace SisUvex.Usuarios.Role
{
    public partial class FrmUserRoleAdd : Form
    {
        public ToggleButton tgbPrintLabels = new();
        public ToggleButton tgbViewCatalogs = new();
        public ToggleButton tgbEditCatalogs = new();
        public ToggleButton tgbCreateRecords = new();
        public ToggleButton tgbOwnFilter = new();
        public ToggleButton tgbProductionReports = new();
        public ToggleButton tgbCostReports = new();
        public ToggleButton tgbAudit = new();

        public FrmUserRoleAdd()
        {
            InitializeComponent();

            tgbAudit.Enabled = false;
            tgbCostReports.Enabled = false;

            AddToggleButtonToPanel(tgbPrintLabels, pnlChbPrintLabels);
            AddToggleButtonToPanel(tgbViewCatalogs, pnlChbViewCatalogs);
            AddToggleButtonToPanel(tgbEditCatalogs, pnlChbEditCatalogs);
            AddToggleButtonToPanel(tgbCreateRecords, pnlChbCreateRecords);
            AddToggleButtonToPanel(tgbOwnFilter, pnlTgbOwnFilter);
            AddToggleButtonToPanel(tgbProductionReports, pnlChbProductionReports);
            AddToggleButtonToPanel(tgbCostReports, pnlChbCostReports);
            AddToggleButtonToPanel(tgbAudit, pnlChbAudit);
        }

        private void AddToggleButtonToPanel(ToggleButton toggleButton, Panel panel)
        {
            toggleButton.Dock = DockStyle.Fill; // Hace que el ToggleButton ocupe todo el espacio del panel
            panel.Controls.Add(toggleButton);
        }
    }
}
