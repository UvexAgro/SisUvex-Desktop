using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Catalogos.Nom_Deducciones
{
	public partial class FrmAddDeducciones : Form
	{
		public ClsAddDeducciones cls;
		public FrmAddDeducciones()
		{
			InitializeComponent();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void FrmAddDeducciones_Load(object sender, EventArgs e)
		{
			cls.BeginFormAdd();
		}

		private void btnAccept_Click(object sender, EventArgs e)
		{
			cls.BtnAccept();
		}
	}
}
