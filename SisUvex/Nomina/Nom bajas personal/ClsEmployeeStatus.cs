using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisUvex.Catalogos.Metods.ComboBoxes;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Nomina.Nom_bajas_personal
{
	public class ClsEmployeeStatus
	{
		public FrmEmployeeStatus frm;
		public DataTable dtEmpleados;
		public bool cargando = false;

		public void CargarCuadrillas(ComboBox combo, int idSeason)
		{
			cargando = true;

			DataTable dt = CboCuadrilla(idSeason);

			DataRow dr = dt.NewRow();
			dr["Código"] = DBNull.Value;
			dr["Nombre"] = " ------ Seleccionar ------ ";
			dt.Rows.InsertAt(dr, 0);

			combo.DataSource = dt;
			combo.DisplayMember = "Nombre";
			combo.ValueMember = "Código";
			combo.SelectedIndex = 0;

			cargando = false;
		}
		public DataTable CboCuadrilla(int idSeason)
		{
			SQLControl sql = new SQLControl();
			DataTable dt = new DataTable();

			sql.OpenConectionWrite();

			string query = @"
        SELECT
            g.id_workGroup AS Código,
            g.v_nameWorkGroup + ' - ' + c.v_nameContractor AS Nombre
        FROM Pack_WorkGroup g
        INNER JOIN Pack_Contractor c
            ON g.id_contractor = c.id_contractor
        WHERE g.id_season = @Season
          AND g.c_active = 1
        ORDER BY g.v_nameWorkGroup";

			SqlCommand cmd = new SqlCommand(query, sql.cnn);
			cmd.Parameters.AddWithValue("@Season", idSeason);

			SqlDataAdapter da = new SqlDataAdapter(cmd);
			da.Fill(dt);

			sql.CloseConectionWrite();

			return dt;
		}
		public void CargarTemporada()
		{
			ClsComboBoxes.CboLoadActives(frm.cboTemporada, Season.CboWithDates);

			DateTime hoy = DateTime.Today;

			for (int i = 0; i < frm.cboTemporada.Items.Count; i++)
			{
				DataRowView row = frm.cboTemporada.Items[i] as DataRowView;

				if (row == null)
					continue;

				if (!row.Row.Table.Columns.Contains(Season.ColumnStartDate) ||
					!row.Row.Table.Columns.Contains(Season.ColumnEndDate))
					continue;

				if (row[Season.ColumnStartDate] == DBNull.Value ||
					row[Season.ColumnEndDate] == DBNull.Value)
					continue;

				DateTime fechaInicio = Convert.ToDateTime(row[Season.ColumnStartDate]);
				DateTime fechaFin = Convert.ToDateTime(row[Season.ColumnEndDate]);

				if (hoy >= fechaInicio && hoy <= fechaFin)
				{
					frm.cboTemporada.SelectedIndex = i;
					return;
				}
			}
		}
		public DataTable GetEmpleadosCuadrilla(string idWorkGroup)
		{
			SQLControl sql = new SQLControl();
			DataTable dt = new DataTable();

			sql.OpenConectionWrite();

			string query = @"
				SELECT
					id_employee AS Código,
					v_lastNamePat + ' ' + v_lastNameMat + ' ' + v_name AS Nombre,
					id_paymentPlace AS [Lugar Pago],
					id_workGroup AS Cuadrilla,
					d_startDate AS [Fecha Ingreso],
					d_exitDate AS [Fecha Baja]
				FROM Nom_Employees
				WHERE id_workGroup = @WorkGroup
				ORDER BY v_lastNamePat, v_lastNameMat, v_name;";

			SqlCommand cmd = new SqlCommand(query, sql.cnn);
			cmd.Parameters.AddWithValue("@WorkGroup", idWorkGroup);

			SqlDataAdapter da = new SqlDataAdapter(cmd);
			da.Fill(dt);

			sql.CloseConectionWrite();

			return dt;
		}
		public void ActualizarFechaBaja(string idEmployee, DateTime fechaBaja)
		{
			SQLControl sql = new SQLControl();

			sql.OpenConectionWrite();

			string query = @"
			UPDATE Nom_Employees
			SET d_exitDate = @FechaBaja
			WHERE id_employee = @IdEmployee";

			SqlCommand cmd = new SqlCommand(query, sql.cnn);
			cmd.Parameters.AddWithValue("@FechaBaja", fechaBaja);
			cmd.Parameters.AddWithValue("@IdEmployee", idEmployee);

			cmd.ExecuteNonQuery();

			sql.CloseConectionWrite();
		}
		public void BuscarEmpleado(string texto)
		{
			if (dtEmpleados == null)
				return;

			DataView dv = dtEmpleados.DefaultView;

			texto = texto.Replace("'", "''");

			if (string.IsNullOrWhiteSpace(texto))
			{
				dv.RowFilter = "";
			}
			else
			{
				dv.RowFilter =
					$"CONVERT([Código], 'System.String') LIKE '%{texto}%' " +
					$"OR Nombre LIKE '%{texto}%'";
			}
			PintarBajas();
		}
		public void EliminarFechaBaja(string idEmployee)
		{
			SQLControl sql = new SQLControl();

			sql.OpenConectionWrite();

			string query = @"
        UPDATE Nom_Employees
        SET d_exitDate = NULL
        WHERE id_employee = @IdEmployee";

			SqlCommand cmd = new SqlCommand(query, sql.cnn);
			cmd.Parameters.AddWithValue("@IdEmployee", idEmployee);

			cmd.ExecuteNonQuery();

			sql.CloseConectionWrite();
		}
		public void CargarEmpleados()
		{
			if (frm.cboCuadrilla.SelectedValue == null)
			{
				MessageBox.Show("Seleccione una cuadrilla.");
				return;
			}

			string idWorkGroup = frm.cboCuadrilla.SelectedValue.ToString();

			dtEmpleados = GetEmpleadosCuadrilla(idWorkGroup);
			// Agregar la columna Seleccionar al DataTable
			if (!dtEmpleados.Columns.Contains("Seleccionar"))
			{
				dtEmpleados.Columns.Add("Seleccionar", typeof(bool));
			}

			frm.dgvCatalog.DataSource = dtEmpleados;

			PintarBajas();
		}
		public void PintarBajas()
		{
			foreach (DataGridViewRow row in frm.dgvCatalog.Rows)
			{
				object fechaBaja = row.Cells["Fecha Baja"].Value;

				if (fechaBaja != null &&
					fechaBaja != DBNull.Value &&
					!string.IsNullOrWhiteSpace(fechaBaja.ToString()))
				{
					row.DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose;
				}
				else
				{
					row.DefaultCellStyle.BackColor = System.Drawing.Color.White;
				}
			}
		}
	}
}