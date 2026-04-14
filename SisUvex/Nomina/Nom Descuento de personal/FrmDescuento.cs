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
	public partial class FrmDescuento : Form
	{
		public ClsAddDesc cls;
		public FrmDescuento()
		{
			InitializeComponent();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{

		}

		private void FrmDescuento_Load(object sender, EventArgs e)
		{

			cls ??= new();
			cls.frm ??= this;
		}
	}
}
