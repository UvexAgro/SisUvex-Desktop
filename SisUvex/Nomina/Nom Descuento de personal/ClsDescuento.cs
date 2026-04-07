using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Nomina.Conceptos_Ingresos_Diversos;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Nomina.Nom_Descuento_de_personal
{
	public class ClsDescuento
	{
		public FrmDescuento frmDesc;
		ClsControls controlList;
		private string queryCatalog = @" SELECT id_Deduction AS [Código], d_StartDate AS [Fecha Inicio], d_EndDate AS [Fecha Fin], id_productionLine AS [Banda], c_Quantity AS [Cantidad],  v_Description AS [Descripción], FROM Nom_SorterDeductionPacking";
		ClsDGVCatalog? dgv;
		DataTable dtCatalog;
		public bool IsAddOrModify = true, IsAddUpdate = false, IsModifyUpdate = false;
		public string? idAddModify;

	}
}
