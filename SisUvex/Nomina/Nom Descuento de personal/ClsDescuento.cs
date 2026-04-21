using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Media;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Presentation;
using iText.Kernel.Pdf;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Nomina.Conceptos_Ingresos_Diversos;
using SisUvex.Nomina.Reporte_de_horas;
using static SisUvex.Catalogos.Metods.ClsObject;
using System.Drawing;

namespace SisUvex.Nomina.Nom_Descuento_de_personal
{
	public class ClsDescuento
	{
		public FrmDescuento frm;
		ClsDescuento cls;
		public FrmAddDesc frmAdd;
		public bool IsAddOrModify = true, IsAddUpdate = false, IsModifyUpdate = false;
		public string? idAddModify;
		ClsControls controlList;
		public CatConcepto entity;
		ClsDGVCatalog? dgv;
		DataTable dtCatalog;
		private string queryCatalog = @"
		SELECT 
			id_Deduction AS [Código],
			id_productionLine AS [Banda],
			v_Description AS [Descripción],
			CONVERT(VARCHAR, d_StartDate, 23) AS [Fecha Inicio],
			CONVERT(VARCHAR, d_EndDate, 23) AS [Fecha Fin],
			c_Quantity AS [Cantidad]
		FROM Nom_SorterDeductionPacking";
		public void BeginFormCat()
		{
			dtCatalog = ClsQuerysDB.GetDataTable(queryCatalog);
			dgv = new ClsDGVCatalog(frm.dgvCatalog, dtCatalog);
			EstiloGrid();
		}

		public void OpenFrmAdd()
		{
			IsAddOrModify = true;
			IsAddUpdate = false;
			idAddModify = null;

			frmAdd = new();
			frmAdd.cls = this;
			frmAdd.Text = "Añadir";
			frmAdd.lblAdd.Text = "Añadir";
			frmAdd.ShowDialog();
		}
		public void OpenFrmModify(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				MessageBox.Show("Seleccione un Descuento");
				return;
			}

			IsAddOrModify = false;
			idAddModify = id;

			frmAdd = new();
			frmAdd.cls = this;
			frmAdd.Text = "Modificar";
			frmAdd.lblAdd.Text = "Modificar";
			frmAdd.ShowDialog();
		}
		public void BeginFormAdd()
		{
			AddControlsToList();

			if (IsAddOrModify)
			{
				frmAdd.txbId.Text = ClsQuerysDB.GetData($"SELECT FORMAT(COALESCE(MAX([id_Deduction]), 0) + 1, '000') FROM Nom_SorterDeductionPacking");

				frmAdd.dtpFinal.ShowCheckBox = true;
				frmAdd.dtpFinal.Checked = false;

			}
			else
			{
				LoadControlsModify();
			}
		}
		private void AddControlsToList()
		{
			controlList = new ClsControls();

			controlList.ChangeHeadMessage("Para guardar el Descuento de personal debe:\n");
			controlList.Add(frmAdd.txbConcepto, "Ingresar la descripcion");
		}
		private void LoadControlsModify()
		{
			DataTable dt = ClsQuerysDB.GetDataTable(
				$"SELECT * FROM  Nom_SorterDeductionPacking WHERE id_Deduction = '{idAddModify}'");

			if (dt.Rows.Count == 0) return;

			frmAdd.txbId.Text = dt.Rows[0]["id_Deduction"].ToString();
			frmAdd.txbConcepto.Text = dt.Rows[0]["v_Description"].ToString();
			frmAdd.nudOvertime.Value = Convert.ToDecimal(dt.Rows[0]["c_Quantity"]);

			frmAdd.dtpInicio.Value = Convert.ToDateTime(dt.Rows[0]["d_StartDate"]);
			frmAdd.dtpFinal.ShowCheckBox = true;

			if (dt.Rows[0]["d_EndDate"] == DBNull.Value)
			{
				frmAdd.dtpFinal.Checked = false; 
			}
			else
			{
				frmAdd.dtpFinal.Value = Convert.ToDateTime(dt.Rows[0]["d_EndDate"]);
				frmAdd.dtpFinal.Checked = true; 
			}

			// ComboBox (Banda)
			frmAdd.cboProductionLine.SelectedValue = dt.Rows[0]["id_productionLine"];
		}
		private ClsAddDesc SetEntity()
		{
			var entity = new ClsAddDesc();
			entity.id_Deduction = frmAdd.txbId.Text;
			entity.id_productionLine = frmAdd.cboProductionLine.SelectedValue?.ToString();

			entity.v_Description = string.IsNullOrWhiteSpace(frmAdd.txbConcepto.Text)
				? null
				: frmAdd.txbConcepto.Text.Trim();

			entity.d_StartDate = frmAdd.dtpInicio.Value;

			// Fecha fin opcional
			entity.d_EndDate = frmAdd.dtpFinal.Checked
				? frmAdd.dtpFinal.Value
				: null;

			entity.c_Quantity = frmAdd.nudOvertime.Value.ToString();

			return entity;
		}
		public void AddProcedure()
		{
			var result = SetEntity().AddSorter();
			IsAddUpdate = result.Item1;
			idAddModify = result.Item2;
		}
		public void ModifyProcedure()
		{
			IsModifyUpdate = SetEntity().ModifySorter();
		}
		public void BtnAccept()
		{
			if (!controlList.ValidateControls())
				return;

			//  Validar Banda
			if (frmAdd.cboProductionLine.SelectedValue == null ||
				frmAdd.cboProductionLine.SelectedIndex == 0)
			{
				MessageBox.Show("Debe seleccionar una banda");
				return;
			}
			if (frmAdd.dtpFinal.Checked &&
				frmAdd.dtpFinal.Value < frmAdd.dtpInicio.Value)
			{
				MessageBox.Show("La fecha fin no puede ser menor a la fecha inicio");
				return;
			}

			//  Validar cantidad
			if (frmAdd.nudOvertime.Value <= 0)
			{
				MessageBox.Show("La cantidad debe ser mayor a 0");
				return;
			}

			if (IsAddOrModify)
			{
				AddProcedure();

				if (IsAddUpdate)
				{
					MessageBox.Show("Registro agregado correctamente");

					frmAdd.DialogResult = DialogResult.OK;
					frmAdd.Close();
				}
				else
				{
					MessageBox.Show("No se pudo agregar");
				}
			}
			else
			{
				ModifyProcedure();

				if (IsModifyUpdate)
				{
					MessageBox.Show("Registro modificado correctamente");

					frmAdd.DialogResult = DialogResult.OK;
					frmAdd.Close();
				}
				else
				{
					MessageBox.Show("No se pudo modificar");
				}
			}
		}
		public void BtnDelete(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				MessageBox.Show("Seleccione un registro");
				return;
			}

			DialogResult r = MessageBox.Show(
				"¿Desea eliminar el registro seleccionado?",
				"Eliminar",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			if (r == DialogResult.No)
				return;

			var entity = new ClsAddDesc();

			bool result = entity.DeleteSorter(id);

			if (result)
			{
				MessageBox.Show("Registro eliminado correctamente");
				dgv.DeleteRowInDGV(id); // elimina sin recargar
			}
			else
			{
				MessageBox.Show("No se pudo eliminar el registro");
			}
		}
		public void AddNewRowByIdInDGVCatalog()
		{
			DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalog + $" WHERE [id_Deduction] = '{idAddModify}'");
			dgv.AddNewRowToDGV(newIdRow);
		}

		public void ModifyRowByIdInDGVCatalog()
		{
			DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalog + $" WHERE [id_Deduction] = '{idAddModify}'");
			dgv.ModifyIdRowInDGV(newIdRow);
		}
		public void BeginForm()
		{
			ClsComboBoxes.CboLoadActives(frmAdd.cboProductionLine, ClsObject.ProductionLine.Cbo);
		}
		public void EstiloGrid()
		{
			var dgv = frm.dgvCatalog;

			//  Líneas
			dgv.BorderStyle = BorderStyle.None;
			dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
			dgv.GridColor = System.Drawing.Color.LightGray;

			dgv.EnableHeadersVisualStyles = false;

			//  Encabezado
			dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(210, 230, 250);
			dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
			dgv.ColumnHeadersHeight = 35;

			//  EVITA QUE SE PINTE AL SELECCIONAR
			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgv.ColumnHeadersDefaultCellStyle.BackColor;
			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = dgv.ColumnHeadersDefaultCellStyle.ForeColor;

			//  Filas
			dgv.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
			dgv.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 120, 215);
			dgv.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;

			//  Alternar filas
			dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);

			//  Ajustes
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgv.RowTemplate.Height = 30;
			dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgv.MultiSelect = false;
			dgv.ReadOnly = true;
			dgv.AllowUserToAddRows = false;
		}
	}
}