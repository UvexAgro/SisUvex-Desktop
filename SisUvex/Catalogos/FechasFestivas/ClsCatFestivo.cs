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
using SisUvex.Nomina.Conceptos_Ingresos_Diversos;
using static SisUvex.Catalogos.Metods.ClsObject;
using System.Globalization;

namespace SisUvex.Catalogos.FechasFestivas
{
	public class ClsCatFestivo
	{
		public FrmCatFestivo frmCat;
		ClsControls controlList;
		public FrmDiasFestivos frmDia;
		private string queryCatalog = @" SELECT id_festivo AS [Código], d_fecha AS [Fecha],v_descripcion AS [Descripccion] FROM Cat_Festivos ";
		public bool IsAddOrModify = true, IsAddUpdate = false, IsModifyUpdate = false;
		public string? idAddModify;
		ClsDGVCatalog? dgv;
		DataTable dtCatalog;
		public ClsDiasFestivos entity;


		public void BeginFormCat()
		{
			frmCat.cls ??= this;

			dtCatalog = ClsQuerysDB.GetDataTable(queryCatalog);
			dgv = new ClsDGVCatalog(frmCat.dgvCatalog, dtCatalog);
		}

		public void OpenFrmDia()
		{
			IsAddOrModify = true;
			IsAddUpdate = false;
			idAddModify = null;

			frmDia = new();
			frmDia.cls = this;
			frmDia.Text = "Añadir Feacha";
			frmDia.ShowDialog();
		}
		public void OpenFrmModify(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				MessageBox.Show("Seleccione una Fecha"); 
				return;
			}

			IsAddOrModify = false;
			idAddModify = id;

			frmDia = new();
			frmDia.cls = this;
			frmDia.Text = "Modificar Fecha";
			frmDia.lblAdd.Text = "Modificar Fecha";
			frmDia.ShowDialog();
		}
		public void BeginFormAdd()
		{
			AddControlsToList();

			if (IsAddOrModify)
			{
				frmDia.txbId.Text = ClsQuerysDB.GetData($"SELECT FORMAT(COALESCE(MAX([id_festivo]), 0) + 1, '0000') FROM[Cat_Festivos]");

			}
			else
			{
				LoadControlsModify();
			}
		}
		private void AddControlsToList()
		{
			controlList = new ClsControls();

			controlList.ChangeHeadMessage("Para guardar la fecha  debe:\n");
			controlList.Add(frmDia.dtpDay, "Ingresa una Fecha");
		}
		private void LoadControlsModify()
		{
			DataTable dt = ClsQuerysDB.GetDataTable(
			$"SELECT * FROM Cat_Festivos WHERE id_festivo = '{idAddModify}'");

			if (dt.Rows.Count == 0) return;

		
			frmDia.txbId.Text = dt.Rows[0]["id_festivo"].ToString();


			frmDia.dtpDay.Value = Convert.ToDateTime(dt.Rows[0]["d_fecha"]);

			frmDia.txbDescripccion.Text = dt.Rows[0]["v_descripcion"].ToString();

		}
		private ClsDiasFestivos SetEntity()
		{
			entity = new ClsDiasFestivos();

			entity.id_festivo = frmDia.txbId.Text;
			entity.v_descripcion = frmDia.txbDescripccion.Text;

			entity.d_fecha = frmDia.dtpDay.Value;

			return entity;
		}
		public void AddProcedure()
		{
			var data = SetEntity();
			if (data == null) return;

			var result = data.AddFestivo();
			IsAddUpdate = result.Item1;
			idAddModify = data.id_festivo;
		}
		
		public void ModifyProcedure()
		{
			var data = SetEntity();
			if (data == null) return;

			IsModifyUpdate = data.UpdateFestivo();
		}
		public void BtnAccept()
		{
			if (IsAddOrModify) 
			{
				AddProcedure();

				if (IsAddUpdate)
				{
					MessageBox.Show("Fecha agregada correctamente");

					RefreshGrid();

					frmDia.DialogResult = DialogResult.OK;
					frmDia.Close();
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
					MessageBox.Show("Fecha modificada correctamente");

					ModifyRowByIdInDGVCatalog();

					frmDia.DialogResult = DialogResult.OK;
					frmDia.Close();
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
				MessageBox.Show("Seleccione una fecha");
				return;
			}

			DialogResult r = MessageBox.Show(
				"¿Desea eliminar la Fecha seleccionada?",
				"Eliminar",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			if (r == DialogResult.No)
				return;

			entity = new ClsDiasFestivos();
			entity.id_festivo = id;
			bool result = entity.DeleteFestivo(id);

			if (result)
			{
				MessageBox.Show("Fecha eliminada correctamente");
				dgv.DeleteRowInDGV(id);
				RefreshGrid();
			}
			else
			{
				MessageBox.Show("No se pudo eliminar el concepto");
			}
		}

		public void AddNewRowByIdInDGVCatalog()
		{
			DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalog + $" WHERE [id_festivo] = '{idAddModify}'");
			dgv.AddNewRowToDGV(newIdRow);
		}

		public void ModifyRowByIdInDGVCatalog()
		{
			DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalog + $" WHERE [id_festivo] = '{idAddModify}'");
			dgv.ModifyIdRowInDGV(newIdRow);
		}
		public void RefreshGrid()
		{
			frmCat.dgvCatalog.DataSource = null;

			dtCatalog = ClsQuerysDB.GetDataTable(queryCatalog);

			
			frmCat.dgvCatalog.DataSource = dtCatalog;
		}
		
		public void EstiloGrid()
		{
			var dgv = frmCat.dgvCatalog;

			//  Líneas
			dgv.BorderStyle = BorderStyle.None;
			dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
			dgv.GridColor = System.Drawing.Color.LightGray;

			dgv.EnableHeadersVisualStyles = false;

			//  Encabezado
			dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(210, 230, 250);
			dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
			dgv.ColumnHeadersHeight = 35;

			//  EVITA QUE SE PINTE AL SELECCIONAR
			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgv.ColumnHeadersDefaultCellStyle.BackColor;
			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = dgv.ColumnHeadersDefaultCellStyle.ForeColor;

			//  Filas
			dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
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

	