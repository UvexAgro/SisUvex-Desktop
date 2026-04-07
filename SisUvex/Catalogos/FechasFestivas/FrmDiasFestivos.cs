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
using SisUvex.Catalogos.Metods.TextBoxes;

namespace SisUvex.Catalogos.FechasFestivas
{
	public partial class FrmDiasFestivos : Form
	{
		public ClsCatFestivo cls;

		public FrmDiasFestivos()
		{
			InitializeComponent();
			this.Shown += FrmDiasFestivos_Shown;
		}
		private void FrmDiasFestivos_Shown(object sender, EventArgs e)
		{
			txbFecha.Focus();   
		}

		private void FrmDiasFestivos_Load(object sender, EventArgs e)
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
