using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Querys;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Nomina.NomTabulador
{
	public class ClsNomTabuladorCat
	{
		public ClsAddTabulador clsAdd;
		public FrmNomTabulador frm;
		public bool IsAddOrModify = true, IsAddUpdate = false, IsModifyUpdate = false;
		public string? idAddModify;
		public FrmAddTabulador frmAdd;
		ClsDGVCatalog? dgv;
		ClsControls controlList;
		DataTable dtCatalog;
		public string queryTabulador = @"
		SELECT 
			c_codigo_tab      AS [Código],
			v_descripcion_tab AS [Nombre],
			id_seasonType     AS [Temporada],
			d_basesalary      AS [Sueldo Base],
			n_SeventhDayPay   AS [Sueldo Base Domingo],
			n_HolidayBasePay  AS [Sueldo Base Festivo],
			n_WorkedRestHolidayPay AS [Sueldo Festivo Domingo],
			d_commission      AS [Comision],
			n_aboutSalary     AS [Sobre Sueldo]
		FROM dbo.Nom_Tabulador
		";

		public void OpenFrmModify(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				MessageBox.Show("Seleccione una Fecha");
				return;
			}

			IsAddOrModify = false;
			idAddModify = id;

			frmAdd = new();
			frmAdd.cls = this;
			frmAdd.Text = "Modificar Fecha";

			frmAdd.ShowDialog();
		}
		public void ModifyRowByIdInDGVCatalog()
		{
			DataTable newIdRow = ClsQuerysDB.GetDataTable(
				queryTabulador + $" WHERE c_codigo_tab = '{idAddModify}'"
			);

			dgv.ModifyIdRowInDGV(newIdRow);
		}
		public void BeginFormCat()
		{
			frm.cls ??= this;

		
			dtCatalog = ClsQuerysDB.GetDataTable(queryTabulador);

			dgv = new ClsDGVCatalog(frm.dgvCatalog, dtCatalog);
		}
		public void CargarDatos(string id)
		{
			DataTable dt = ClsQuerysDB.GetDataTable(
				"SELECT * FROM Nom_Tabulador WHERE c_codigo_tab = '" + id + "'"
			);

			if (dt.Rows.Count > 0)
			{
				DataRow row = dt.Rows[0];

				frmAdd.txbActividad.Text = row["c_codigo_tab"].ToString().Trim();
				frmAdd.txbName.Text = row["v_descripcion_tab"]?.ToString() ?? "";

				frmAdd.cboSeason.SelectedValue = row["id_seasonType"]?.ToString();
				frmAdd.txbIdSeason.Text = row["id_seasonType"]?.ToString() ?? "";

				frmAdd.txbSueldoBase.Text = row["d_basesalary"]?.ToString() ?? "";
				frmAdd.txbComision.Text = row["d_commission"]?.ToString() ?? "";
				frmAdd.txbSobreSueldo.Text = row["n_aboutSalary"]?.ToString() ?? "";
				frmAdd.txbSueldoDomingo.Text = row["n_SeventhDayPay"]?.ToString() ?? "";
				frmAdd.txbSueldoFestivo.Text = row["n_HolidayBasePay"]?.ToString() ?? "";
				frmAdd.txbFestivoDomingo.Text = row["n_WorkedRestHolidayPay"]?.ToString() ?? "";
			}
		}
		private ClsAddTabulador SetEntity()
		{
			var entity = new ClsAddTabulador();

			entity.c_codigo_tab = frmAdd.txbActividad.Text;
			entity.v_descripcion_tab = frmAdd.txbName.Text;
			entity.id_seasonType = frmAdd.cboSeason.SelectedValue?.ToString();

			entity.d_basesalary = string.IsNullOrWhiteSpace(frmAdd.txbSueldoBase.Text) ? null : decimal.Parse(frmAdd.txbSueldoBase.Text);
			entity.d_commission = string.IsNullOrWhiteSpace(frmAdd.txbComision.Text) ? null : decimal.Parse(frmAdd.txbComision.Text);
			entity.n_aboutSalary = string.IsNullOrWhiteSpace(frmAdd.txbSobreSueldo.Text) ? null : decimal.Parse(frmAdd.txbSobreSueldo.Text);
			entity.n_SeventhDayPay = string.IsNullOrWhiteSpace(frmAdd.txbSueldoDomingo.Text) ? null : decimal.Parse(frmAdd.txbSueldoDomingo.Text);
			entity.n_HolidayBasePay = string.IsNullOrWhiteSpace(frmAdd.txbSueldoFestivo.Text) ? null : decimal.Parse(frmAdd.txbSueldoFestivo.Text);
			entity.n_WorkedRestHolidayPay = string.IsNullOrWhiteSpace(frmAdd.txbFestivoDomingo.Text) ? null : decimal.Parse(frmAdd.txbFestivoDomingo.Text);
				
			return entity;
		}
		public void ModifyProcedure()
		{
			var data = SetEntity();
			if (data == null) return;

			IsModifyUpdate = data.UpdateTabulador();
		}
		public void BtnAccept()
		{
			ModifyProcedure();

			if (IsModifyUpdate)
			{
				
				RefrescarGrid();

				MessageBox.Show("Tabulador modificado correctamente");

				frmAdd.DialogResult = DialogResult.OK;
				frmAdd.Close();
			}
			else
			{
				MessageBox.Show("No se pudo modificar");
			}
		}
		public void RefrescarGrid()
		{
			string filtro = frm.cboSeason.SelectedValue?.ToString();

			string query = queryTabulador;

			if (!string.IsNullOrEmpty(filtro))
			{
				query += " WHERE id_seasonType = '" + filtro + "'";
			}

			dtCatalog = ClsQuerysDB.GetDataTable(query);
			frm.dgvCatalog.DataSource = dtCatalog;
		}
	}
}
