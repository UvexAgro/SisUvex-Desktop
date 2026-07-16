using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Querys;
using System.Data;
using static SisUvex.Catalogos.Metods.ClsObject;
using SisUvex.Catalogos.Metods.Extentions;

namespace SisUvex.Nomina.Asistencia_contrato.Consulta
{
    internal class ClsPayrollAttendance
    {
        public FrmPayrollAttendance frm;
        DataTable? _dtAttendance;

        public void BeginFormCat()
        {
            frm.WindowState = FormWindowState.Maximized;
            SetControls();
            ClearLabels();
        }

        private void SetControls()
        {
            ClsComboBoxes.CboLoadActives(frm.cboPeriod, Payroll_AttendancePeriod.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboPaymentPlace, PlacePayment.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboContractor, Contractor.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboSeason, Season.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboWorkGroup, WorkGroup.Cbo);

            List<(ComboBox, string)> lscboWorkGroupFilter = new List<(ComboBox, string)>();
            lscboWorkGroupFilter.Add((frm.cboContractor, Contractor.ColumnId));
            lscboWorkGroupFilter.Add((frm.cboSeason, Season.ColumnId));

            ClsComboBoxes.Events.CboApplyEventFilterAllForOne(frm.cboWorkGroup, null, lscboWorkGroupFilter);
        }

        public void BtnLoadAttendance()
        {
            if (frm.cboPeriod.SelectedIndex < 1 || frm.cboPeriod.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una semana.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SetLblAttendanceDetails();

            SetDgvAttendance();
        }

        private void SetLblAttendanceDetails()
        {
            ClearLabels();
            if (frm.cboPeriod.SelectedIndex > 0)
                frm.lblPeriod.Text = frm.cboPeriod.Text; //Porque así está mejor en este caso
            if (frm.cboContractor.SelectedIndex > 0)
                frm.lblContractor.Text = frm.cboContractor.GetColumnValue(Contractor.ColumnName).ToString();
            if (frm.cboWorkGroup.SelectedIndex > 0)
            {
                frm.lblWorkGroup.Text = frm.cboWorkGroup.GetColumnValue(WorkGroup.ColumnName).ToString();
                frm.lblContractor.Text = frm.cboWorkGroup.GetColumnValue(Contractor.ColumnName).ToString();
            }
            if (frm.cboPaymentPlace.SelectedIndex > 0)
                frm.lblPaymentPlace.Text = frm.cboPaymentPlace.SelectedValue + " - " + frm.cboPaymentPlace.GetColumnValue(PlacePayment.ColumnName).ToString();

        }
        private void ClearLabels()
        {
            frm.lblPeriod.Text = string.Empty;
            frm.lblContractor.Text = string.Empty;
            frm.lblWorkGroup.Text = string.Empty;
            frm.lblPaymentPlace.Text = string.Empty;
        }

        private void SetDgvAttendance()
        {
            string query = GetQueryAttendance();
            DataTable? dt = ClsQuerysDB.GetDataTable(query);

            _dtAttendance = dt;
            frm.dgvAttendence.DataSource = dt;
        }

        private string GetQueryAttendance()
        {
            string idContractor = frm.cboContractor.SelectedValue?.ToString()?.Replace("'", "''") ?? string.Empty;
            string idWorkGroup = frm.cboWorkGroup.SelectedValue?.ToString()?.Replace("'", "''") ?? string.Empty;
            string idPaymentPlace = frm.cboPaymentPlace.SelectedValue?.ToString()?.Replace("'", "''") ?? string.Empty;
            string cSemana = frm.cboPeriod.GetColumnValue(Payroll_AttendancePeriod.ColumnSequence).ToString() ?? string.Empty; //*Secuencia es el numero de semana (duda con el id_periodo)

            string where = " WHERE 1=1 ";
            if (!string.IsNullOrWhiteSpace(idWorkGroup))  //Aquí van con dos comillas '' porque se van a insertar dentro de una cadena que también va entre comillas simples en la consulta SQL dinámica.
                where += $"\n AND Base.id_workGroup = ''{idWorkGroup}'' ";
            if (!string.IsNullOrWhiteSpace(idContractor))
                where += $"\n AND wgp.id_contractor = ''{idContractor}'' ";
            if (!string.IsNullOrWhiteSpace(idPaymentPlace))
                where += $"\n AND Base.id_paymentPlace = ''{idPaymentPlace}'' ";

            return $@"  DECLARE @Semana varchar(10) = '{cSemana}';

                        DECLARE @StartDate date;
                        
                        --------Obtener la fecha de inicio de la semana seleccionada
                        SELECT TOP (1) 
                                @StartDate = CAST(d_startDate_per AS date)
                            FROM Payroll_AttendancePeriod
                            WHERE c_sequence_per = @Semana
                            ORDER BY id_period DESC, d_startDate_per DESC;

                        -----Para que DATENAME salga en español:
                         SET LANGUAGE Spanish;

                        DECLARE @sql nvarchar(max) = N'';
                        DECLARE @cols nvarchar(max) = N'';

                        ;WITH Days AS (
                            SELECT 0 AS n, DATEADD(day, 0, @StartDate) AS d
                            UNION ALL SELECT 1, DATEADD(day, 1, @StartDate)
                            UNION ALL SELECT 2, DATEADD(day, 2, @StartDate)
                            UNION ALL SELECT 3, DATEADD(day, 3, @StartDate)
                            UNION ALL SELECT 4, DATEADD(day, 4, @StartDate)
                            UNION ALL SELECT 5, DATEADD(day, 5, @StartDate)
                            UNION ALL SELECT 6, DATEADD(day, 6, @StartDate)
                        )
                        SELECT @cols = STRING_AGG(
                            N',
                            MAX(CASE WHEN attDate = ''' + CONVERT(varchar(10), d, 120) + N''' THEN PresentValue END) AS ' 
                            --+ QUOTENAME(DATENAME(WEEKDAY, d) + ' ' + CONVERT(varchar(10), d, 103))
                            + QUOTENAME(DATENAME(WEEKDAY, d) + ', ' + CAST(DAY(d) AS varchar(2)))
                        , N'')
                        FROM Days;

                        SET @sql = N'
                        ;WITH Base AS (
                            SELECT
                                att.id_employee,
                                emp.id_paymentPlace,
                                att.id_workGroup,
                                CAST(att.d_attendance_date AS date) AS attDate,
                                CASE att.c_present
                                    WHEN ''S'' THEN 1
                                    WHEN ''M'' THEN 0.5
                                    ELSE 0
                                END AS PresentValue
                            FROM Payroll_Attendance att
                            LEFT JOIN Nom_Employees emp ON emp.id_employee = att.id_employee
                            WHERE att.c_semana_cp = @Semana
                        )
                        SELECT
                            wgp.v_nameWorkGroup AS [Cuadrilla],
                            Base.id_employee    AS [Código],
                            CONCAT_WS(''/'',emp.v_lastNamePat, emp.v_lastNameMat, emp.v_name) AS [Nombre],
                            Base.id_paymentPlace AS [LP]'
                            + @cols + N'
                        FROM Base
                            LEFT JOIN Nom_Employees     emp ON emp.id_employee = Base.id_employee
                            LEFT JOIN Pack_WorkGroup    wgp ON wgp.id_workGroup = Base.id_workGroup
                            LEFT JOIN Pack_Contractor   cnt ON cnt.id_contractor = wgp.id_contractor
                        {where}
                        GROUP BY Base.id_employee, Base.id_paymentPlace, Base.id_workGroup, wgp.v_nameWorkGroup, emp.v_lastNamePat, emp.v_lastNameMat, emp.v_name
                        ORDER BY wgp.v_nameWorkGroup, emp.v_lastNamePat, emp.v_lastNameMat, emp.v_name;';

                        EXEC sp_executesql
                            @sql,
                            N'@Semana varchar(10)',
                            @Semana = @Semana;";
        }

        public void BtnGenerateExcelReport()
        {
            if (_dtAttendance == null || _dtAttendance.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No hay datos de asistencia para generar el reporte.",
                    "Asistencia contrato",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            // Crear instancia de la clase de Excel y generar reporte
            ClsExcelPayrollAttendance excelGenerator = new ClsExcelPayrollAttendance();
            excelGenerator.GenerateExcelReport(_dtAttendance, frm.lblPeriod.Text, frm.lblContractor.Text, frm.lblWorkGroup.Text, frm.lblPaymentPlace.Text);
        }
    }
}
