using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using static SisUvex.Catalogos.Metods.ClsObject;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace SisUvex.Nomina.Reporte_de_horas
{
	internal class ClSPackingHours
	{
		public FrmPackingHours frmPacki;

		public void CargarPeriodos()
		{
			ClsComboBoxes.CboLoadActives(frmPacki.cboSemana, Payroll_AttendancePeriod.Cbo);

			DateTime hoy = DateTime.Today;

			for (int i = 0; i < frmPacki.cboSemana.Items.Count; i++)
			{
				DataRowView row = (DataRowView)frmPacki.cboSemana.Items[i];

				if (row[Payroll_AttendancePeriod.ColumnStartDate] == DBNull.Value ||
					row[Payroll_AttendancePeriod.ColumnEndDate] == DBNull.Value)
				{
					continue;
				}

				DateTime fechaInicio = Convert.ToDateTime(row[Payroll_AttendancePeriod.ColumnStartDate]);
				DateTime fechaFin = Convert.ToDateTime(row[Payroll_AttendancePeriod.ColumnEndDate]);

				if (hoy >= fechaInicio && hoy <= fechaFin)
				{
					frmPacki.cboSemana.SelectedIndex = i;
					break;
				}
			}
		}
		public void CargarTemporada()
		{
			ClsComboBoxes.CboLoadActives(frmPacki.cboTemporada, Season.CboWithDates);
			
			DateTime hoy = DateTime.Today;

			for (int i = 0; i < frmPacki.cboTemporada.Items.Count; i++)
			{
				DataRowView row = frmPacki.cboTemporada.Items[i] as DataRowView;

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
					frmPacki.cboTemporada.SelectedIndex = i;
					return;
				}
			}
		}
		public DataTable ObtenerHorasEmpaque(int temporada, int? periodo, int? semana)
		{
			SQLControl sql = new SQLControl();
			DataTable dt = new DataTable();

			try
			{
				sql.OpenConectionWrite();

				string query = "SELECT * FROM dbo.fn_PackHorasEmpaque(@Temporada,@Periodo,@Semana)";

				SqlCommand cmd = new SqlCommand(query, sql.cnn);

				// ESTE ES EL BLOQUE QUE TE DI
				cmd.Parameters.AddWithValue("@Temporada", temporada);

				if (semana == null)
				{
					cmd.Parameters.AddWithValue("@Periodo", DBNull.Value);
					cmd.Parameters.AddWithValue("@Semana", DBNull.Value);
				}
				else
				{
					cmd.Parameters.AddWithValue("@Periodo", periodo);
					cmd.Parameters.AddWithValue("@Semana", semana);
				}

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(dt);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Reporte horas");
			}
			finally
			{
				sql.OpenConectionWrite();
			}

			return dt;
		}
	}
}