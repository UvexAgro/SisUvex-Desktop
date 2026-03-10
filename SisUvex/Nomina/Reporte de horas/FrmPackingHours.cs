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
		public FrmPackingHours()
		{
			InitializeComponent();
		}

		private void FrmPackingHours_Load(object sender, EventArgs e)
		{
			cls ??= new();
			cls.frmPacki ??= this;

			cls.CargarPeriodos();

			cls.CargarTemporada();
		}

		private void btncargar_Click(object sender, EventArgs e)
		{
			ClSPackingHours cls = new ClSPackingHours();
			int temporada = Convert.ToInt32(cboTemporada.Text.Split('|')[1].Trim());

			int? periodo = null;
			int? semanaNum = null;

			if (cboSemana.SelectedValue != null && cboSemana.SelectedValue.ToString().Contains("|"))
			{
				string[] semana = cboSemana.SelectedValue.ToString().Split('|');

				if (!string.IsNullOrWhiteSpace(semana[0]))
					periodo = Convert.ToInt32(semana[0]);

				if (!string.IsNullOrWhiteSpace(semana[1]))
					semanaNum = Convert.ToInt32(semana[1]);
			}

			DataTable dt = cls.ObtenerHorasEmpaque(temporada, periodo, semanaNum);

			dgvHoras.DataSource = dt;
		}
	}
}
