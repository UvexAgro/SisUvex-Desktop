using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods.Querys;

namespace SisUvex.Nomina.NomTabulador
{
	public partial class FrmAddTabulador : Form
	{
		public ClsNomTabuladorCat cls;
	
		public FrmAddTabulador()
		{
			InitializeComponent();
		}

		private void FrmAddTabulador_Load(object sender, EventArgs e)
		{
			
			DataTable dtSeason = ClsQuerysDB.GetDataTable(
				"SELECT id_seasonType, v_nameSeasonType FROM Pack_SeasonType"
			);

			cboSeason.DataSource = dtSeason;
			cboSeason.DisplayMember = "v_nameSeasonType";
			cboSeason.ValueMember = "id_seasonType";
			txbIdSeason.Text = cboSeason.SelectedValue?.ToString() ?? "";

			if (!string.IsNullOrEmpty(cls.idAddModify))
			{
				cls.CargarDatos(cls.idAddModify);
			}
		
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnAccept_Click(object sender, EventArgs e)
		{
			cls.BtnAccept();
		}
	}
}
