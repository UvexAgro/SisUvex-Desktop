using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisUvex.Catalogos.GTIN;
using SisUvex.Catalogos.Metods;

namespace SisUvex.Nomina.Work_time
{
	internal partial class FrmWorkTimeCat : Form
	{
		bool cambiando = false;
		bool isLoaded = false;
		ClsWorkTime cls;
		public Color colorComida = Color.FromArgb(200, 225, 255);
		public Color colorCena = Color.FromArgb(220, 235, 255);
		public Color colorDescanso = Color.FromArgb(240, 245, 255);
		public Color colorDescanso2 = Color.FromArgb(225, 240, 255);

		public FrmWorkTimeCat(ClsWorkTime clsClass)
		{
			InitializeComponent();
			cls = (clsClass);
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			cls.OpenFrmAdd();
		}

		private void btnModify_Click(object sender, EventArgs e)
		{
			cls.OpenFrmModify();
		}

		private void FrmWorkTimeCat_Load(object sender, EventArgs e)
		{
			cls.BeginFormCat();
			cls.CargarTemporada();

			dgvCatalog.CellPainting += dgvCatalog_CellPainting;

			dgvCatalog.DataBindingComplete -= dgvCatalog_DataBindingComplete;
			dgvCatalog.DataBindingComplete += dgvCatalog_DataBindingComplete;

			isLoaded = true;

			cls.LoadDgvCatalog();
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			cls.LoadDgvCatalog();
		}

		private void dgvCatalog_DoubleClick(object sender, EventArgs e)
		{
			cls.OpenFrmModify();
		}

		private void btnReportField_Click(object sender, EventArgs e)
		{
			cls.OpenFrmReport(1); //1 PARA REPORTE EN PRECIOS DE CAMPO
		}

		private void btnReportFacility_Click(object sender, EventArgs e)
		{
			cls.OpenFrmReport(2); //2 PARA REPORTE CON PRECIOS DE EMPAQUE
		}

		private void dgvCatalog_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			cls.PintarEncabezadosAgrupados((DataGridView)sender, e);
		}

		private void cboFechaInicio_SelectedIndexChanged(object sender, EventArgs e)
		{

			if (!isLoaded || cambiando) return;

			cambiando = true;

			
			if (cboFinal.SelectedIndex < cboFechaInicio.SelectedIndex)
			{
				cboFinal.SelectedIndex = cboFechaInicio.SelectedIndex;
			}

			cambiando = false;

			cls.LoadDgvCatalog();
		}

		private void cboFinal_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!isLoaded || cambiando) return;

			cambiando = true;

			
			if (cboFinal.SelectedIndex < cboFechaInicio.SelectedIndex)
			{
				cboFinal.SelectedIndex = cboFechaInicio.SelectedIndex;
			}

			cambiando = false;

			cls.LoadDgvCatalog();
		}

		private void dgvCatalog_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			dgvCatalog.BeginInvoke(new Action(() =>
			{
				cls.OrdenarColumnas();
				cls.AjustarEncabezados();
				cls.ColorearColumnas();
				cls.FormatearColumnasHora(dgvCatalog);

				if (dgvCatalog.Columns.Contains(ClsObject.Column.id))
					dgvCatalog.Columns[ClsObject.Column.id].Visible = false;

				if (dgvCatalog.Columns.Contains(ClsWorkTime.ColumnDateWtm))
					dgvCatalog.Columns[ClsWorkTime.ColumnDateWtm].Visible = false;

				if (dgvCatalog.Columns.Contains("d_workTime"))
					dgvCatalog.Columns["d_workTime"].Visible = false;

				dgvCatalog.Refresh();
			}));
		}
	}

}
