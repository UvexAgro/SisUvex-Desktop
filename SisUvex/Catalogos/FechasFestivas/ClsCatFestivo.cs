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
			controlList.Add(frmDia.txbFecha, "Ingresa una Fecha");
		}
		private void LoadControlsModify()
		{
			DataTable dt = ClsQuerysDB.GetDataTable(
			$"SELECT * FROM Cat_Festivos WHERE id_festivo = '{idAddModify}'");

			if (dt.Rows.Count == 0) return;

		
			frmDia.txbId.Text = dt.Rows[0]["id_festivo"].ToString();

			
			frmDia.txbFecha.Text = Convert.ToDateTime(dt.Rows[0]["d_fecha"])
				.ToString("dd/MM/yyyy");

			frmDia.txbDescripccion.Text = dt.Rows[0]["v_descripcion"].ToString();

		}
		private ClsDiasFestivos SetEntity()
		{
			entity = new ClsDiasFestivos();

			entity.id_festivo = idAddModify;
			entity.v_descripcion = frmDia.txbDescripccion.Text;

			try
			{
				entity.d_fecha = DateTime.ParseExact(
					frmDia.txbFecha.Text.Trim(),
					"dd/MM/yyyy",
					CultureInfo.InvariantCulture
				);
			}
			catch
			{
				MessageBox.Show("La fecha no tiene el formato correcto (dd/MM/yyyy)");
				return null;
			}

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
			dtCatalog = ClsQuerysDB.GetDataTable(queryCatalog);
			dgv = new ClsDGVCatalog(frmCat.dgvCatalog, dtCatalog);
		}
	}
}

	