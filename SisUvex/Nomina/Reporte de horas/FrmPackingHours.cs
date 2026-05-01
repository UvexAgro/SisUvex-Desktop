using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Nomina.Reporte_de_horas
{
	public partial class FrmPackingHours : Form
	{
		ClSPackingHours cls;
		ClsAñadir clsA;
		bool isLoaded = false;
		public Color colorComida = Color.FromArgb(200, 225, 255);
		public Color colorCena = Color.FromArgb(220, 235, 255);
		public Color colorDescanso = Color.FromArgb(225, 240, 255);
		public Color colorDescanso2 = Color.FromArgb(240, 245, 255); 


		public FrmPackingHours()
		{
			InitializeComponent();
		}

		private void FrmPackingHours_Load(object sender, EventArgs e)
		{
			cls ??= new();
			cls.frmPacki ??= this;


			clsA ??= new();
			clsA.frmPacki ??= this;

			cls.CargarPeriodos();

			cls.CargarTemporada();
			clsA.CargarHorasInicial();
			clsA.FormatearColumnasHora(dgvHoras);

			//  ESTILO HEADER
			dgvHoras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
			dgvHoras.ColumnHeadersHeight = 50;
			dgvHoras.EnableHeadersVisualStyles = false;

			//  CENTRAR TEXTO
			dgvHoras.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgvHoras.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

			//  EVENTO
			dgvHoras.CellPainting += dgvHoras_CellPainting;

			//  AJUSTAR NOMBRES
			clsA.AjustarEncabezados();

			isLoaded = true;

		}

		private void cboFinal_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboFinal.SelectedIndex < cboSemana.SelectedIndex)
			{
				cboFinal.SelectedIndex = cboSemana.SelectedIndex;
			}
			clsA.CargarHorasInicial();
		}

		private void cboSemana_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!isLoaded) return;

			if (cboFinal.Items.Count == 0) return;

			int index = cboSemana.SelectedIndex;

			if (index >= 0 && index < cboFinal.Items.Count)
			{
				cboFinal.SelectedIndex = index;
			}

			clsA.CargarHorasInicial();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			clsA.OpenFrmAdd();
		}

		private void btnModify_Click(object sender, EventArgs e)
		{
			clsA.OpenFrmModify();
		}

		private void btnExcel_Click(object sender, EventArgs e)
		{
			cls.ExportarDGVHorasExcel(dgvHoras);
		}

		private void btnEliminar_Click(object sender, EventArgs e)
		{
			clsA.DeleteProcedure();
		}

		private void dgvHoras_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			clsA.PintarEncabezadosAgrupados((DataGridView)sender, e);
		}
	}
}
