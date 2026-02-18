using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Presentation;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;

namespace SisUvex.Nomina.Conceptos_Ingresos_Diversos
{
	public partial class FrmAdd : Form
	{
		public ClsIncomeConcepts cls;

		public FrmAdd()
		{
			InitializeComponent();
		}

		private void FrmAdd_Load(object sender, EventArgs e)
		{
			cls.BeginFormAdd();
		}
		private void btnAccept_Click(object sender, EventArgs e)
		{
			cls.BtnAccept();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
	     this.Close();
		}
	}
}

