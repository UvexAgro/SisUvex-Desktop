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
			// Cargar combos
			ClsComboBoxes.CboLoadActives(frmPacki.cboSemana, Payroll_AttendancePeriod.Cbo);
			ClsComboBoxes.CboLoadActives(frmPacki.cboFinal, Payroll_AttendancePeriod.Cbo);

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
					frmPacki.cboFinal.SelectedIndex = i; 
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
		
		public void CargarHoras()
		{
			try
			{
				if (frmPacki.cboTemporada.SelectedValue == null ||
					frmPacki.cboSemana.SelectedItem == null ||
					frmPacki.cboFinal.SelectedItem == null)
					return;

				DataRowView rowInicio = (DataRowView)frmPacki.cboSemana.SelectedItem;
				DataRowView rowFin = (DataRowView)frmPacki.cboFinal.SelectedItem;

				int temporada = Convert.ToInt32(frmPacki.cboTemporada.SelectedValue);

				int periodo = Convert.ToInt32(rowInicio[Payroll_AttendancePeriod.ColumnId]);        
				int semanaInicio = Convert.ToInt32(rowInicio[Payroll_AttendancePeriod.ColumnSequence]); 
				int semanaFin = Convert.ToInt32(rowFin[Payroll_AttendancePeriod.ColumnSequence]);

				DataTable dt = new DataTable();

				SQLControl sql = new SQLControl();
				sql.OpenConectionWrite();

				SqlCommand cmd = new SqlCommand(
					"SELECT * FROM dbo.fn_PackHorasEmpaque(@Temporada, @Periodo, @SemanaInicio, @SemanaFin)",
					sql.cnn);

				cmd.Parameters.AddWithValue("@Temporada", temporada);
				cmd.Parameters.AddWithValue("@Periodo", periodo);
				cmd.Parameters.AddWithValue("@SemanaInicio", semanaInicio);
				cmd.Parameters.AddWithValue("@SemanaFin", semanaFin);

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(dt);

				frmPacki.dgvHoras.DataSource = dt;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}