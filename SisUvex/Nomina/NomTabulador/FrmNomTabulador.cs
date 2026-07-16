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
using SisUvex.Nomina.PlacePaymentLP;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Nomina.NomTabulador
{
	public partial class FrmNomTabulador : Form
	{
		public ClsNomTabuladorCat cls;
		public FrmNomTabulador()
		{
			InitializeComponent();
		}

		private void FrmNomTabulador_Load(object sender, EventArgs e)
		{
			cls ??= new();
			cls.frm = this;
			cls.BeginFormCat();

			DataTable dtSeason = ClsQuerysDB.GetDataTable("SELECT id_seasonType, v_nameSeasonType FROM Pack_SeasonType");


			DataRow row = dtSeason.NewRow();
			row["id_seasonType"] = "";
			row["v_nameSeasonType"] = "Todos";
			dtSeason.Rows.InsertAt(row, 0);

			cboSeason.DataSource = dtSeason;
			cboSeason.DisplayMember = "v_nameSeasonType";
			cboSeason.ValueMember = "id_seasonType";
			cboSeason.SelectedValue = "05";
	
			FiltrarGrid();
			HasEditCatalogsPermission(); //metodo para dar permisos al usuario 
		}
		private void HasEditCatalogsPermission() //metodo para dar permisos al usuario 
		{
			if (User.HasEditCatalogsPermission())
				return;

			btnModify.Enabled = false;
		}

		private void btnModify_Click(object sender, EventArgs e)
		{
			if (dgvCatalog.SelectedRows.Count == 0)
			{
				System.Media.SystemSounds.Exclamation.Play();
				MessageBox.Show("Selecciona un registro");
				return;
			}


			string id = dgvCatalog.SelectedRows[0].Cells["Código"].Value.ToString().Trim();


			cls.OpenFrmModify(id);


			if (cls.IsModifyUpdate)
			{
				cls.ModifyRowByIdInDGVCatalog();
			}
		}
		public void FiltrarGrid()
		{
			string filtro = cboSeason.SelectedValue?.ToString();

			string query = cls.queryTabulador;

			if (!string.IsNullOrEmpty(filtro))
			{
				query += " WHERE id_seasonType = '" + filtro + "'";
			}

			DataTable dt = ClsQuerysDB.GetDataTable(query);

			dgvCatalog.DataSource = dt;
		}

		private void cboSeason_SelectedIndexChanged(object sender, EventArgs e)
		{
			FiltrarGrid();
		}
	}
}
