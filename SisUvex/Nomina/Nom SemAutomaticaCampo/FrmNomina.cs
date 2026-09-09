using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisUvex.Nomina.Ingresos_Diversos;

namespace SisUvex.Nomina.Nom_SemAutomaticaCampo
{
	public partial class FrmNomina : Form
	{
		public ClsNomina cls;
		public FrmNomina()
		{
			InitializeComponent();
			cls ??= new ClsNomina();
			cls.frm ??= this;
		}

		private void FrmNomina_Load(object sender, EventArgs e)
		{

		}
	}
}
