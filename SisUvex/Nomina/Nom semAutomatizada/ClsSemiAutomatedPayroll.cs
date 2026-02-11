using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;

namespace SisUvex.Nomina.Nom_semAutomatizada
{
	internal class ClsSemiAutomatedPayroll
	{
		 public FrmSemiAutomatedPayroll frm;

		public void BeginForm()
		{ 
			ClsComboBoxes.CboLoadActives(frm.cmbLote, ClsObject.Lot.Cbo); 
		}
	}
}
