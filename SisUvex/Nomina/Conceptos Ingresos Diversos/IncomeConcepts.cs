using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using static SisUvex.Catalogos.Metods.ClsObject;
using System.Data;
using SisUvex.Catalogos.Metods.Querys;
using System.Media;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods;

namespace SisUvex.Nomina.Conceptos_Ingresos_Diversos
{
	public class ClsIncomeConcepts
	{
		public FrmIncomeConcepts frm;
		ClsControls controlList;
		public FrmAdd _FrmAdd;
		public CatConcepto entityConcepto;
		private string queryCatalog = @" SELECT id_concept AS [Código], v_concept AS [Concepto],n_amount AS [Monto],n_unit AS [Horas Extras] FROM Nom_concept";
		ClsDGVCatalog? dgv;
		DataTable dtCatalog;
		public bool IsAddOrModify = true, IsAddUpdate = false, IsModifyUpdate = false;
		public string? idAddModify;


		public void BeginFormCat()
		{
			frm.cls ??= this;

			dtCatalog = ClsQuerysDB.GetDataTable(queryCatalog);
			dgv = new ClsDGVCatalog(frm.dgvCatalog, dtCatalog);
		}
		public void OpenFrmModify(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				MessageBox.Show("Seleccione un concepto");
				return;
			}

			IsAddOrModify = false;
			idAddModify = id;

			_FrmAdd = new();
			_FrmAdd.cls = this;
			_FrmAdd.Text = "Modificar concepto";
			_FrmAdd.lblAdd.Text = "Modificar Concepto";
			_FrmAdd.ShowDialog();
		}
		public void OpenFrmAdd()
		{
			IsAddOrModify = true;
			IsAddUpdate = false;
			idAddModify = null;

			_FrmAdd = new();
			_FrmAdd.cls = this;
			_FrmAdd.Text = "Añadir concepto";
			_FrmAdd.ShowDialog();
		}
		public void BeginFormAdd()
		{
			AddControlsToList();

			if (IsAddOrModify)
			{
				_FrmAdd.txbId.Text = ClsQuerysDB.GetData($"SELECT FORMAT(COALESCE(MAX([id_concept]), 0) + 1, '000') FROM[Nom_concept]");
		
			}
			else
			{
				LoadControlsModify();
			}
		}
		private void AddControlsToList()
		{
			controlList = new ClsControls();

			controlList.ChangeHeadMessage("Para guardar el concepto debe:\n");
			controlList.Add(_FrmAdd.txbConcepto, "Ingresar el concepto");
		}
		private void LoadControlsModify()
		{
			DataTable dt = ClsQuerysDB.GetDataTable(
				$"SELECT * FROM Nom_concept WHERE id_concept = '{idAddModify}'");

			if (dt.Rows.Count == 0) return;

			_FrmAdd.txbId.Text = dt.Rows[0]["id_concept"].ToString();
			_FrmAdd.txbConcepto.Text = dt.Rows[0]["v_concept"].ToString();
			_FrmAdd.txbMonto.Text = dt.Rows[0]["n_amount"].ToString();
			_FrmAdd.txbHoras.Text = dt.Rows[0]["n_unit"].ToString();
		}
		private CatConcepto SetEntity()
		{
			entityConcepto = new CatConcepto();

			entityConcepto.idConcept = _FrmAdd.txbId.Text;
			entityConcepto.concept = _FrmAdd.txbConcepto.Text.Trim();

			decimal value;

			// MONTO (opcional)
			entityConcepto.amount = decimal.TryParse(_FrmAdd.txbMonto.Text, out value)
									? value
									: null;

			// HORAS / UNIDAD (opcional)
			entityConcepto.unit = decimal.TryParse(_FrmAdd.txbHoras.Text, out value)
								  ? value
								  : null;

			return entityConcepto;
		}
		public void AddProcedure()
		{
			var result = SetEntity().AddProcedure();
			IsAddUpdate = result.Item1;
			idAddModify = result.Item2;
		}
		public void ModifyProcedure()
		{
			IsModifyUpdate = SetEntity().ModifyProcedure();
		}
		public void BtnAccept()
		{
			if (!controlList.ValidateControls())
				return;

			if (!string.IsNullOrEmpty(_FrmAdd.txbMonto.Text) &&
		!string.IsNullOrEmpty(_FrmAdd.txbHoras.Text))
			{
				MessageBox.Show("Solo puede capturar Monto o Horas Extras, no ambos");
				return;
			}

			if (IsAddOrModify)
			{
				AddProcedure();

				if (IsAddUpdate)
				{
					MessageBox.Show("Concepto agregado correctamente");

					_FrmAdd.DialogResult = DialogResult.OK;
					_FrmAdd.Close();
				}
				else
					MessageBox.Show("No se pudo agregar");
			}
			else
			{
				ModifyProcedure();

				if (IsModifyUpdate)
				{
					MessageBox.Show("Concepto modificado correctamente");

					_FrmAdd.DialogResult = DialogResult.OK;
					_FrmAdd.Close();
				}
				else
					MessageBox.Show("No se pudo modificar");
			}
		}


		public void BtnDelete(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				MessageBox.Show("Seleccione un concepto");
				return;
			}

			DialogResult r = MessageBox.Show(
				"¿Desea eliminar el concepto seleccionado?",
				"Eliminar",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			if (r == DialogResult.No)
				return;

			entityConcepto = new CatConcepto();

			bool result = entityConcepto.DeleteProcedure(id);

			if (result)
			{
				MessageBox.Show("Concepto eliminado correctamente");
				dgv.DeleteRowInDGV(id);   // lo quita sin recargar todo
			}
			else
			{
				MessageBox.Show("No se pudo eliminar el concepto");
			}
		}

		 public void AddNewRowByIdInDGVCatalog()
        {
            DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalog + $" WHERE [id_concept] = '{idAddModify}'");
            dgv.AddNewRowToDGV(newIdRow);
        }

        public void ModifyRowByIdInDGVCatalog()
        {
            DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalog + $" WHERE [id_concept] = '{idAddModify}'");
            dgv.ModifyIdRowInDGV(newIdRow);
        }
	}
}
