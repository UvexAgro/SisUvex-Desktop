using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Nomina.Nom_semAutomatizada
{
	public partial class FrmSemiAutomatedPayroll : Form
	{
		ClsSemiAutomatedPayroll cls;

		public FrmSemiAutomatedPayroll()
		{
			InitializeComponent();
		}

		private void FrmSemiAutomatedPayroll_Load(object sender, EventArgs e)
		{
			cls ??= new();
			cls.frm ??= this;
			cls.BeginForm();
		}

		private void btnCVS_Click(object sender, EventArgs e)
		{

		}
	}
}
