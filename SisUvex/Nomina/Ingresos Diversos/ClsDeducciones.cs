using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Presentation;
using SisUvex.Catalogos;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Nomina.Asistencia_de_empaque;
using static SisUvex.Catalogos.Metods.ClsObject;
using System.Data.SqlClient;

namespace SisUvex.Nomina.Ingresos_Diversos
{
	internal class ClsDeducciones
	{
		ClsIngresosDiversos cls;
		public FrmMenu frmMenu;
		public FrmAsistenciaEmpleado frmAsitencia;
		public FrmIngresosDiversos frmIngresos;
		public FrmListaAsitencia frmDia;
		public FrmAddIngresos frmAdd;
		public FrmDeducciones frmDeu;

		public void CboDeducciones(ComboBox cbo)
		{
			DataTable dtDeu = ClsQuerysDB.GetDataTable(
				"SELECT id_Deductions AS [" + Column.id + "], " +
				"v_descripcion_ded AS [" + Column.name + "], " +
				"ISNULL(n_importefijo_ded, 0) AS Descuento " +
				"FROM Nom_Deductions");

			ClsComboBoxes.LoadComboBoxDataSource(cbo, dtDeu);
		}
		public void ActualizarDeducciones()
		{

			string idDeductionsNuevo = frmDeu.cboDeducciones.SelectedValue?.ToString();

			if (string.IsNullOrWhiteSpace(idDeductionsNuevo))
			{
				MessageBox.Show("Debe seleccionar un Descuento válido");
				return;
			}


			DataTable dt = ClsQuerysDB.GetDataTable(
				$"SELECT 1 FROM Nom_Deductions WHERE id_Deductions = '{idDeductionsNuevo}'");

			if (dt.Rows.Count == 0)
			{
				MessageBox.Show("Seleccione un Descuento válido");
				return;
			}


			decimal Descuento;

			if (!string.IsNullOrWhiteSpace(frmDeu.txbMmodificarD.Text))
			{
				if (!decimal.TryParse(frmDeu.txbMmodificarD.Text, out Descuento))
				{
					MessageBox.Show("Monto modificado inválido");
					return;
				}
			}
			else
			{
				if (!decimal.TryParse(frmDeu.txbMontoDeduccion.Text, out Descuento))
				{
					MessageBox.Show("lA Deduccion no tiene monto válido");
					return;
				}
			}
			string query = $@"
			EXEC sp_Nom_Deductions_Update
			'{frmDeu.IdAttendence}',
			'{frmDeu.IdDeductions}',
			'{idDeductionsNuevo}',
			{Descuento},
			'SYSTEM'";

			ClsQuerysDB.ExecuteQuery(query);
		}
		public void InsertarDeducciones()
		{
			object val = frmDeu.cboDeducciones.SelectedValue;

			if (val == null || val is DataRowView)
			{
				MessageBox.Show("Seleccione una Deduccion válida");
				return;
			}

			string IdDeductions = val.ToString();

			if (ExisteDeduccionEnAsistencia(frmDeu.IdAttendence, IdDeductions))
			{
				MessageBox.Show("Este Descuento ya fue agregado a esta asistencia");
				return;
			}

			decimal Descuento;

			if (!string.IsNullOrWhiteSpace(frmDeu.txbMmodificarD.Text))
			{
				if (!decimal.TryParse(frmDeu.txbMmodificarD.Text, out Descuento))
				{
					MessageBox.Show("Monto modificado inválido");
					return;
				}
			}
			else
			{
				if (!decimal.TryParse(frmDeu.txbMontoDeduccion.Text, out Descuento))
				{
					MessageBox.Show("No tiene monto válido");
					return;
				}
			}

			string query = $@"
			EXEC sp_Nom_Deductions_Insert
			'{frmDeu.IdAttendence}',
			'{IdDeductions}',
			{Descuento},
			'SYSTEM'";

			ClsQuerysDB.ExecuteQuery(query);
		}
		
		private bool ExisteDeduccionEnAsistencia(string idAttendence, string idConcepto)
		{
			string query = $@"
			SELECT COUNT(*) 
			FROM Nom_MiscellaneousIncome
			WHERE id_attendence = '{idAttendence}' and id_Deductions is not null ";

			object result = ClsQuerysDB.GetData(query);

			return Convert.ToInt32(result) > 0;
		}
		public void EliminarDeduccionDesdeGrid(
					DataGridView dgv,
					ClsIngresosDiversos clsIngresos)
		{
			if (dgv.CurrentRow == null)
			{
				MessageBox.Show("Seleccione un registro");
				return;
			}

			if (dgv.CurrentRow.Cells["id_Deductions"].Value == DBNull.Value)
			{
				MessageBox.Show("Esta asistencia no tiene Descuento para eliminar");
				return;
			}

			string idAttendence = dgv.CurrentRow.Cells["id_attendence"].Value.ToString();
			string idDeductions = dgv.CurrentRow.Cells["id_Deductions"].Value.ToString();

			if (MessageBox.Show("¿Desea eliminar el Descuento seleccionado?",
				"Confirmar",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question) == DialogResult.No)
				return;

			string query = $@"
			EXEC sp_Nom_Deductions_Delete
			'{idAttendence}',
			'{idDeductions}'";

			ClsQuerysDB.ExecuteQuery(query);

			clsIngresos.ObtenerAsistenciaEmpaqueDia();
		}

	}
}
