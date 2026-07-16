using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Nomina.Nom_Descuento_de_personal
{
	public partial class FrmAddDesc : Form
	{
		public ClsDescuento cls;
		public FrmAddDesc()
		{
			InitializeComponent();
		}

		private void FrmAddDesc_Load(object sender, EventArgs e)
		{
			cls.BeginFormAdd();
			cls.BeginForm();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnAcept_Click(object sender, EventArgs e)
		{
			cls.BtnAccept();
		}
	}
}
