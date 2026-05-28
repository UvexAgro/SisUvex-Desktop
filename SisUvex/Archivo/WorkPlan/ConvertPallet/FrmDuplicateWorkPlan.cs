using SisUvex.Catalogos.Metods.ComboBoxes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Archivo.WorkPlan.ConvertPallet
{
    public partial class FrmDuplicateWorkPlan : Form
    {
        public bool IsDuplicate = false;
        public FrmDuplicateWorkPlan()
        {
            InitializeComponent();
        }

        private void FrmDuplicateWorkPlan_Load(object sender, EventArgs e)
        {
            ClsComboBoxes.CboLoadActives(cboSeason, Season.CboWithDates);
            ClsComboBoxes.CboLoadActives(cboContractor, Contractor.Cbo);
            ClsComboBoxes.CboLoadActives(cboWorkGroup, WorkGroup.Cbo);

            List<(ComboBox Cbo, string IdColumnFilter)> lsWGDep = new();
            lsWGDep.Add((cboSeason, Season.ColumnId));
            lsWGDep.Add((cboContractor, Contractor.ColumnId));
            ClsComboBoxes.Events.CboApplyEventFilterAllForOne(cboWorkGroup, null, lsWGDep);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
