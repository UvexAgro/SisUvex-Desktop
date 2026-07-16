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

namespace SisUvex.Catalogos.Nom_Deducciones
{
	public class ClsAddDeducciones
	{
		public FrmDeduccion frm;
		public FrmAddDeducciones frmAdd;
		ClsControls controlList;
		public bool IsAddOrModify = true, IsAddUpdate = false, IsModifyUpdate = false;
		public string? idAddModify;
		ClsDGVCatalog? dgv;
		DataTable dtCatalog;
		public ClsDeducciones entity;
		private string queryCatalog = @"
		SELECT 
			id_Deductions AS [Código], 
			v_descripcion_ded AS [Descripción], 
			n_importeFijo_ded AS [Importe]
		FROM Nom_Deductions";
		public void BeginFormCat()
		{
			frm.cls ??= this;

			dtCatalog = ClsQuerysDB.GetDataTable(queryCatalog);
			dgv = new ClsDGVCatalog(frm.dgvCatalog, dtCatalog);
		}

		public void OpenFrmDia()
		{
			IsAddOrModify = true;
			IsAddUpdate = false;
			idAddModify = null;

			frmAdd = new();
			frmAdd.cls = this;
			frmAdd.Text = "Añadir Deduccion";
			frmAdd.ShowDialog();
		}
		public void OpenFrmModify(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				MessageBox.Show("Seleccione una Deduccion");
				return;
			}

			IsAddOrModify = false;
			idAddModify = id;

			frmAdd = new();
			frmAdd.cls = this;
			frmAdd.Text = "Modificar Deduccion";
			frmAdd.lblAdd.Text = "Modificar Deduccion";
			frmAdd.ShowDialog();
		}
		public void BeginFormAdd()
		{
			AddControlsToList();

			if (IsAddOrModify)
			{
				frmAdd.txbId.Text = ClsQuerysDB.GetData("SELECT RIGHT('000' + CAST(COALESCE(MAX(CAST(id_Deductions AS INT)),0)+1 AS VARCHAR),3) FROM Nom_Deductions");

			}
			else
			{
				LoadControlsModify();
			}
		}
		public void AddControlsToList()
		{
			controlList = new ClsControls();

			controlList.ChangeHeadMessage("Para guardar la Deduccion debes :\n");
			controlList.Add(frmAdd.txbDescripccion, "Ingresa una Descripcion");
		}
		public void LoadControlsModify()
		{
			DataTable dt = ClsQuerysDB.GetDataTable(
			$"SELECT * FROM Nom_Deductions WHERE id_Deductions = '{idAddModify}'");

			if (dt.Rows.Count == 0) return;

			frmAdd.txbId.Text = dt.Rows[0]["id_Deductions"].ToString();
			frmAdd.txbDescripccion.Text = dt.Rows[0]["v_descripcion_ded"].ToString();
			frmAdd.txbCantidad.Text = dt.Rows[0]["n_importeFijo_ded"].ToString();
		}
		public ClsDeducciones SetEntity()
		{
			entity = new ClsDeducciones();

			entity.id_Deductions = frmAdd.txbId.Text;
			entity.v_descripcion_ded = frmAdd.txbDescripccion.Text;
			decimal importe;
			entity.n_importeFijo_ded = decimal.TryParse(frmAdd.txbCantidad.Text, out importe)
				? importe
				: (decimal?)null;
			return entity;
		}
		public void AddProcedure()
		{
			var data = SetEntity();
			if (data == null) return;

			var result = data.AddNomDeductions();
			IsAddUpdate = result.Item1;
			idAddModify = data.id_Deductions;
		}

		public void ModifyProcedure()
		{
			var data = SetEntity();
			if (data == null) return;

			var result = data.UpdateNomDeductions();
			IsModifyUpdate = result.Item1;
		}
		public void BtnAccept()
		{
			if (IsAddOrModify)
			{
				AddProcedure();

				if (IsAddUpdate)
				{
					MessageBox.Show("Deducción agregada correctamente");

					RefreshGrid();

					frmAdd.DialogResult = DialogResult.OK;
					frmAdd.Close();
				}
				else
				{
					MessageBox.Show("No se pudo agregar la deducción");
				}
			}
			else
			{
				ModifyProcedure();

				if (IsModifyUpdate)
				{
					MessageBox.Show("Deducción modificada correctamente");

					ModifyRowByIdInDGVCatalog();

					frmAdd.DialogResult = DialogResult.OK;
					frmAdd.Close();
				}
				else
				{
					MessageBox.Show("No se pudo modificar la deducción");
				}
			}
		}

		public void BtnDelete(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				MessageBox.Show("Seleccione una Deducción");
				return;
			}

			DialogResult r = MessageBox.Show(
				"¿Desea eliminar la Deducción seleccionada?",
				"Eliminar",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			if (r == DialogResult.No)
				return;

			entity = new ClsDeducciones();
			entity.id_Deductions = id;

			var result = entity.DeleteNomDeductions();

			if (result.Item1)
			{
				MessageBox.Show("Deducción eliminada correctamente");
				dgv.DeleteRowInDGV(id);
				RefreshGrid();
			}
			else
			{
				MessageBox.Show("No se pudo eliminar");
			}
		}
		public void AddNewRowByIdInDGVCatalog()
		{
			DataTable newIdRow = ClsQuerysDB.GetDataTable(
				queryCatalog + $" WHERE id_Deductions = '{idAddModify}'");
			dgv.AddNewRowToDGV(newIdRow);
		}

		public void ModifyRowByIdInDGVCatalog()
		{
			DataTable newIdRow = ClsQuerysDB.GetDataTable(
				queryCatalog + $" WHERE id_Deductions = '{idAddModify}'");
			dgv.ModifyIdRowInDGV(newIdRow);
		}
		public void RefreshGrid()
		{
			frm.dgvCatalog.DataSource = null;

			dtCatalog = ClsQuerysDB.GetDataTable(queryCatalog);


			frm.dgvCatalog.DataSource = dtCatalog;
		}
	}
}
