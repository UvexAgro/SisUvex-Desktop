using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using MathNet.Numerics.LinearAlgebra.Factorization;
using SisUvex.Catalogos.Metods.Querys;
using static SisUvex.Catalogos.Metods.ClsObject;

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

			cls.CargarPeriodos();

		}

		private void btnEmpleado_Click(object sender, EventArgs e)
		{
			cls.ObtenerPackersReport();
		}

		private void btnExcelEmpleado_Click(object sender, EventArgs e)
		{
			cls.ExportarPdfPorEmpacador();

		}

		private void btnExcelBandas_Click(object sender, EventArgs e)
		{
			cls.ExportarPdfPorLinea();
		}

		private void cboSemana_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}
