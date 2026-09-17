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
			n_aboutSalary     AS [Sobre Sueldo],
			CAST(
					CASE
						WHEN c_campo_tab = '1' THEN 1
						ELSE 0
					END
				AS bit) AS [Campo],

				CAST(
					CASE
						WHEN c_empaque_tab = '1' THEN 1
						ELSE 0
					END
				AS bit) AS [Empaque]

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
			frmAdd.Text = "Modificar Sueldo, Comisiones y Sobre Sueldos";

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

			dtCatalog =
				ClsQuerysDB.GetDataTable(queryTabulador);

			dgv =
				new ClsDGVCatalog(
					frm.dgvCatalog,
					dtCatalog);

			ConfigurarCheckboxCampoEmpaque();
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
				frmAdd.chkCampo.Checked = row["c_campo_tab"]?.ToString().Trim() == "1";
				frmAdd.chkEmpaque.Checked = row["c_empaque_tab"]?.ToString().Trim() == "1";
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
			entity.c_campo_tab = frmAdd.chkCampo.Checked;
			entity.c_empaque_tab = frmAdd.chkEmpaque.Checked;

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
		public void DiseñarDgvTabulador()
		{
			DataGridView dgv = frm.dgvCatalog;

			// =========================================================
			// CONFIGURACIÓN GENERAL
			// =========================================================

			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToResizeRows = false;

			dgv.ReadOnly = true;
			dgv.MultiSelect = false;
			dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

			dgv.RowHeadersVisible = false;

			dgv.BorderStyle = BorderStyle.None;
			dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;

			dgv.GridColor = System.Drawing.Color.LightGray;
			dgv.BackgroundColor = System.Drawing.Color.White;

			dgv.EnableHeadersVisualStyles = false;

			// =========================================================
			// ENCABEZADOS
			// =========================================================

			dgv.EnableHeadersVisualStyles = false;

			dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(42, 110, 151);

			dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;

			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(42, 110, 151);

			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;

			dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

			dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

			dgv.ColumnHeadersHeight = 35;

			// =========================================================
			// FILAS
			// =========================================================

			dgv.DefaultCellStyle.Font =
				new Font("Segoe UI", 9F);

			dgv.DefaultCellStyle.ForeColor =
				System.Drawing.Color.FromArgb(40, 40, 40);

			dgv.DefaultCellStyle.BackColor =
				System.Drawing.Color.White;

			dgv.DefaultCellStyle.SelectionBackColor =
				System.Drawing.Color.FromArgb(42, 110, 151);

			dgv.DefaultCellStyle.SelectionForeColor =
				System.Drawing.Color.White;

			dgv.AlternatingRowsDefaultCellStyle.BackColor =
				System.Drawing.Color.FromArgb(240, 247, 251);

			dgv.RowTemplate.Height = 28;

			// =========================================================
			// ALINEACIÓN DE COLUMNAS
			// =========================================================

			if (dgv.Columns.Contains("Código"))
				dgv.Columns["Código"].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleCenter;

			if (dgv.Columns.Contains("Temporada"))
				dgv.Columns["Temporada"].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleCenter;

			if (dgv.Columns.Contains("Sueldo Base"))
				dgv.Columns["Sueldo Base"].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleRight;

			if (dgv.Columns.Contains("Sueldo Base Domingo"))
				dgv.Columns["Sueldo Base Domingo"].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleRight;

			if (dgv.Columns.Contains("Sueldo Base Festivo"))
				dgv.Columns["Sueldo Base Festivo"].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleRight;

			if (dgv.Columns.Contains("Sueldo Festivo Domingo"))
				dgv.Columns["Sueldo Festivo Domingo"].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleRight;

			if (dgv.Columns.Contains("Comision"))
				dgv.Columns["Comision"].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleRight;

			if (dgv.Columns.Contains("Sobre Sueldo"))
				dgv.Columns["Sobre Sueldo"].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleRight;

			if (dgv.Columns.Contains("Campo"))
				dgv.Columns["Campo"].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleCenter;

			if (dgv.Columns.Contains("Empaque"))
				dgv.Columns["Empaque"].DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleCenter;

			// =========================================================
			// ANCHO DE COLUMNAS
			// =========================================================

			if (dgv.Columns.Contains("Código"))
				dgv.Columns["Código"].Width = 65;

			if (dgv.Columns.Contains("Nombre"))
				dgv.Columns["Nombre"].Width = 240;

			if (dgv.Columns.Contains("Temporada"))
				dgv.Columns["Temporada"].Width = 80;

			if (dgv.Columns.Contains("Sueldo Base"))
				dgv.Columns["Sueldo Base"].Width = 105;

			if (dgv.Columns.Contains("Sueldo Base Domingo"))
				dgv.Columns["Sueldo Base Domingo"].Width = 125;

			if (dgv.Columns.Contains("Sueldo Base Festivo"))
				dgv.Columns["Sueldo Base Festivo"].Width = 120;

			if (dgv.Columns.Contains("Sueldo Festivo Domingo"))
				dgv.Columns["Sueldo Festivo Domingo"].Width = 130;

			if (dgv.Columns.Contains("Comision"))
				dgv.Columns["Comision"].Width = 90;

			if (dgv.Columns.Contains("Sobre Sueldo"))
				dgv.Columns["Sobre Sueldo"].Width = 100;

			if (dgv.Columns.Contains("Campo"))
				dgv.Columns["Campo"].Width = 70;

			if (dgv.Columns.Contains("Empaque"))
				dgv.Columns["Empaque"].Width = 80;
		}
		public void ConfigurarCheckboxCampoEmpaque()
		{
			DataGridView dgv = frm.dgvCatalog;

			// =========================================================
			// CAMPO
			// =========================================================

			if (dgv.Columns.Contains("Campo"))
			{
				int indiceCampo =
					dgv.Columns["Campo"].Index;

				dgv.Columns.Remove("Campo");

				DataGridViewCheckBoxColumn chkCampo =
					new DataGridViewCheckBoxColumn();

				chkCampo.Name = "Campo";
				chkCampo.HeaderText = "Campo";
				chkCampo.DataPropertyName = "Campo";
				chkCampo.Width = 70;
				chkCampo.ReadOnly = true;

				chkCampo.DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleCenter;

				dgv.Columns.Insert(
					indiceCampo,
					chkCampo);
			}

			// =========================================================
			// EMPAQUE
			// =========================================================

			if (dgv.Columns.Contains("Empaque"))
			{
				int indiceEmpaque =
					dgv.Columns["Empaque"].Index;

				dgv.Columns.Remove("Empaque");

				DataGridViewCheckBoxColumn chkEmpaque =
					new DataGridViewCheckBoxColumn();

				chkEmpaque.Name = "Empaque";
				chkEmpaque.HeaderText = "Empaque";
				chkEmpaque.DataPropertyName = "Empaque";
				chkEmpaque.Width = 80;
				chkEmpaque.ReadOnly = true;

				chkEmpaque.DefaultCellStyle.Alignment =
					DataGridViewContentAlignment.MiddleCenter;

				dgv.Columns.Insert(
					indiceEmpaque,
					chkEmpaque);
			}
		}
	}
}
