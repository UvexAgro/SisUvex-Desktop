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
using ClosedXML.Excel;
using SisUvex.Catalogos.Metods.Querys;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Nomina.Nom_semAutomatizada
{
	public partial class FrmSemiAutomatedPayroll : Form
	{
		ClsSemiAutomatedPayroll cls;
		ClsFestivo clsF;
		public string TipoFestivoSeleccionado = "";

		public FrmSemiAutomatedPayroll()
		{
			InitializeComponent();
		}

		private void FrmSemiAutomatedPayroll_Load(object sender, EventArgs e)
		{
			cls ??= new();
			cls.frm ??= this;
			clsF ??= new ClsFestivo();
			clsF.frm = this;
			cls.BeginForm();

		}

		private void btnCVS_Click(object sender, EventArgs e)
		{
			cls.BtnCsv();
		}



		public void dtpFecha_ValueChanged(object sender, EventArgs e)
		{
			cls.SetTxbReferencia();
		}

		private void btncargar_Click(object sender, EventArgs e)
		{
			cls.BtnCargarDatos();

		}

		private void btnExcel_Click(object sender, EventArgs e)
		{
			if (dgvEmployee.Rows.Count > 0)
			{
				DataTable dt = (DataTable)dgvEmployee.DataSource;
				cls.ExportarExcel(dt);
			}
			else
				SystemSounds.Exclamation.Play();
		}

		private void btnCalcularLibra_Click(object sender, EventArgs e)
		{
			cls.EjecutarCalculoProduccion();
		}

		private void btnFestivos_Click(object sender, EventArgs e)
		{
			DateTime fecha = dtpFecha.Value;

			if (!clsF.EsFestivo(fecha))
			{
				MessageBox.Show("No es un día festivo.");
				return;
			}
			FrmFestivo frmFestivo = new FrmFestivo();

			if (frmFestivo.ShowDialog() == DialogResult.OK)
			{
				TipoFestivoSeleccionado = frmFestivo.TipoSeleccionado;

			}

			clsF.BtnCargarDatos();
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			cls.GuardarCambiosSueldos();
		}

		private void dgvEmployee_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
				return;

			if (dgvEmployee.Columns[e.ColumnIndex].Name != "SueldoTotal")
				return;

			DataGridViewCell cell = dgvEmployee.Rows[e.RowIndex].Cells["SueldoTotal"];

			decimal original = Convert.ToDecimal(cell.Tag);
			decimal nuevo = Convert.ToDecimal(cell.Value);

			if (original != nuevo)
			{
				cell.Style.BackColor = System.Drawing.Color.FromArgb(255, 248, 200);
				cell.Style.SelectionBackColor = System.Drawing.Color.FromArgb(255, 248, 200);

				cell.Style.ForeColor = System.Drawing.Color.Red;
				cell.Style.SelectionForeColor = System.Drawing.Color.Red;

				cell.Style.Font = new Font(dgvEmployee.Font, FontStyle.Bold);
			}
			else
			{
				cell.Style.BackColor = System.Drawing.Color.White;
				cell.Style.SelectionBackColor = dgvEmployee.DefaultCellStyle.SelectionBackColor;

				cell.Style.ForeColor = System.Drawing.Color.Black;
				cell.Style.SelectionForeColor = dgvEmployee.DefaultCellStyle.SelectionForeColor;

				cell.Style.Font = dgvEmployee.Font;
			}
		}
	}
}

