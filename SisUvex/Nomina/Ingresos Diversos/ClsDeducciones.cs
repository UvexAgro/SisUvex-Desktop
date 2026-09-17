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
			string idDeductionsNuevo =
				frmDeu.cboDeducciones.SelectedValue?.ToString();

			if (string.IsNullOrWhiteSpace(idDeductionsNuevo))
			{
				MessageBox.Show("Debe seleccionar un Descuento válido");
				return;
			}

			DataTable dt = ClsQuerysDB.GetDataTable(
				$"SELECT 1 FROM Nom_Deductions " +
				$"WHERE id_Deductions = '{idDeductionsNuevo}'");

			if (dt.Rows.Count == 0)
			{
				MessageBox.Show("Seleccione un Descuento válido");
				return;
			}

			decimal Descuento;

			if (!string.IsNullOrWhiteSpace(frmDeu.txbMmodificarD.Text))
			{
				if (!decimal.TryParse(
					frmDeu.txbMmodificarD.Text,
					out Descuento))
				{
					MessageBox.Show("Monto modificado inválido");
					return;
				}
			}
			else
			{
				if (!decimal.TryParse(
					frmDeu.txbMontoDeduccion.Text,
					out Descuento))
				{
					MessageBox.Show("La deducción no tiene monto válido");
					return;
				}
			}

			string idAttendence = "NULL";
			string idWorkGroupEmployeeDaily = "NULL";

			if (frmDeu.EsCampo)
			{
				// CAMPO
				idWorkGroupEmployeeDaily =
					$"'{frmDeu.IdWorkGroupEmployeeDaily}'";
			}
			else
			{
				// EMPAQUE
				idAttendence =
					$"'{frmDeu.IdAttendence}'";
			}

			string query = $@"
			EXEC sp_Nom_Deductions_Update
				{idAttendence},
				{idWorkGroupEmployeeDaily},
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
				MessageBox.Show("Seleccione una Deducción válida");
				return;
			}

			string idDeductions = val.ToString();


			// ============================================
			// VALIDAR SI YA EXISTE
			// ============================================

			string idAttendence = null;
			string idWorkGroupEmployeeDaily = null;

			if (frmDeu.EsCampo)
			{
				// CAMPO
				idWorkGroupEmployeeDaily =
					frmDeu.IdWorkGroupEmployeeDaily;
			}
			else
			{
				// EMPAQUE
				idAttendence =
					frmDeu.IdAttendence;
			}


			if (ExisteDeduccionEnAsistencia(
				idAttendence,
				idWorkGroupEmployeeDaily,
				idDeductions))
			{
				MessageBox.Show(
					"Este Descuento ya fue agregado a esta asistencia");

				return;
			}



			// OBTENER MONTO


			decimal Descuento;

			if (!string.IsNullOrWhiteSpace(
				frmDeu.txbMmodificarD.Text))
			{
				if (!decimal.TryParse(
					frmDeu.txbMmodificarD.Text,
					out Descuento))
				{
					MessageBox.Show("Monto modificado inválido");
					return;
				}
			}
			else
			{
				if (!decimal.TryParse(
					frmDeu.txbMontoDeduccion.Text,
					out Descuento))
				{
					MessageBox.Show("No tiene monto válido");
					return;
				}
			}


			// PREPARAR IDs


			string idAttendenceSQL =
				string.IsNullOrEmpty(idAttendence)
				? "NULL"
				: $"'{idAttendence}'";

			string idWorkGroupEmployeeDailySQL =
				string.IsNullOrEmpty(idWorkGroupEmployeeDaily)
				? "NULL"
				: $"'{idWorkGroupEmployeeDaily}'";


			// INSERTAR

			string query = $@"
		EXEC sp_Nom_Deductions_Insert
			{idAttendenceSQL},
			{idWorkGroupEmployeeDailySQL},
			'{idDeductions}',
			{Descuento},
			'SYSTEM'";

			ClsQuerysDB.ExecuteQuery(query);
		}

		private bool ExisteDeduccionEnAsistencia(string idAttendence,string idWorkGroupEmployeeDaily,string idDeductions)
		{
			string filtro;

			if (!string.IsNullOrEmpty(idWorkGroupEmployeeDaily))
			{
				// CAMPO
				filtro =
					$"id_workGroupEmployeeDaily = '{idWorkGroupEmployeeDaily}'";
			}
			else
			{
				// EMPAQUE
				filtro =
					$"id_attendence = '{idAttendence}'";
			}

			string query = $@"
		SELECT COUNT(*)
		FROM Nom_MiscellaneousIncome
		WHERE {filtro}
		  AND id_Deductions = '{idDeductions}'";

			object result = ClsQuerysDB.GetData(query);

			return Convert.ToInt32(result) > 0;
		}
		public void EliminarDeduccionDesdeGrid(DataGridView dgv, ClsIngresosDiversos clsIngresos)
		{
			if (dgv.CurrentRow == null)
			{
				MessageBox.Show("Seleccione un registro");
				return;
			}

			if (dgv.CurrentRow.Cells["id_Deductions"].Value == null ||
				dgv.CurrentRow.Cells["id_Deductions"].Value == DBNull.Value)
			{
				MessageBox.Show(
					"Esta asistencia no tiene Descuento para eliminar");
				return;
			}

			string idDeductions =
				dgv.CurrentRow.Cells["id_Deductions"].Value.ToString();

			string idAttendence = null;
			string idWorkGroupEmployeeDaily = null;


			// DETERMINAR SI ES CAMPO O EMPAQUE


			if (dgv.Columns.Contains("id_workGroupEmployeeDaily"))
			{
				// CAMPO
				object valor =
					dgv.CurrentRow.Cells["id_workGroupEmployeeDaily"].Value;

				if (valor != null && valor != DBNull.Value)
				{
					idWorkGroupEmployeeDaily = valor.ToString();
				}
			}
			else if (dgv.Columns.Contains("id_attendence"))
			{
				// EMPAQUE
				object valor =
					dgv.CurrentRow.Cells["id_attendence"].Value;

				if (valor != null && valor != DBNull.Value)
				{
					idAttendence = valor.ToString();
				}
			}

			if (string.IsNullOrEmpty(idAttendence) &&
				string.IsNullOrEmpty(idWorkGroupEmployeeDaily))
			{
				MessageBox.Show(
					"No se encontró el identificador de la asistencia");
				return;
			}

			if (MessageBox.Show(
				"¿Desea eliminar el Descuento seleccionado?",
				"Confirmar",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question) == DialogResult.No)
			{
				return;
			}

			string idAttendenceSQL =
				string.IsNullOrEmpty(idAttendence)
				? "NULL"
				: $"'{idAttendence}'";

			string idWorkGroupEmployeeDailySQL =
				string.IsNullOrEmpty(idWorkGroupEmployeeDaily)
				? "NULL"
				: $"'{idWorkGroupEmployeeDaily}'";

			string query = $@"
		EXEC sp_Nom_Deductions_Delete
			{idAttendenceSQL},
			{idWorkGroupEmployeeDailySQL},
			'{idDeductions}'";

			ClsQuerysDB.ExecuteQuery(query);


			// ACTUALIZAR GRID

			if (!string.IsNullOrEmpty(idWorkGroupEmployeeDaily))
			{
				clsIngresos.ObtenerEmpleadosCampoDia();
			}
			else
			{
				clsIngresos.ObtenerAsistenciaEmpaqueDia();
			}
		}

	}
}
