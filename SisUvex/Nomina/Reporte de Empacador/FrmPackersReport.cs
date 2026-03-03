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
using ClosedXML.Excel;
using SisUvex.Catalogos.Metods.Querys;

namespace SisUvex.Nomina.Reporte_de_Empacador
{
	public partial class FrmPackersReport : Form
	{
		ClsPackersReport cls;

		public FrmPackersReport()
		{
			InitializeComponent();
		}

		private void FrmPackersReport_Load(object sender, EventArgs e)
		{
			cls ??= new();
			cls.frmPack ??= this;
			cls.LineadeProduccion();
		}

		private void btnEmpleado_Click(object sender, EventArgs e)
		{
			cls.ObtenerPackersReport();
		}

		private void btnExcelEmpleado_Click(object sender, EventArgs e)
		{
			cls.ExportarExcelPorEmpacador();

		}

		private void btnExcelBandas_Click(object sender, EventArgs e)
		{
			cls.ExportarExcelPorLinea();
		}
	}
}
