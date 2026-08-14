using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.RootFinding;
using Microsoft.VisualBasic;
using NPOI.SS.Formula.Functions;
using SisUvex.Catalogos.Metods.Querys;

namespace SisUvex.Nomina.Nom_semAutomatizada
{
	internal class ClsCierre
	{
		public FrmSemiAutomatedPayroll frm;
		internal ClsSemiAutomatedPayroll cls;
		public FrmNominaExistente frmN;
		public FrmCierre frmC;

		public DataTable ObtenerInfoCierreSemana(DateTime fecha)
		{
			SQLControl sql = new SQLControl();

			sql.OpenConectionWrite();

			SqlCommand cmd = new SqlCommand("sp_GetInfoCierreSemana", sql.cnn);
			cmd.CommandType = CommandType.StoredProcedure;

			cmd.Parameters.AddWithValue("@Fecha", fecha.Date);

			SqlDataAdapter da = new SqlDataAdapter(cmd);

			DataTable dt = new DataTable();

			da.Fill(dt);

			sql.CloseConectionWrite();

			return dt;
		}
		public void CargarInformacionCierre(FrmCierre frmC, DateTime fechaCierre)
		{
			DataTable dt = ObtenerInfoCierreSemana(fechaCierre);

			if (dt.Rows.Count == 0)
			{
				MessageBox.Show("No se encontró el período correspondiente.");
				return;
			}

			DataRow row = dt.Rows[0];

			frmC.lblTipoNomina.Text =
				cls.TipoNomina == "E" ? "Espárrago" : "Uva";

			frmC.lblSemana.Text =
				row["c_sequence_per"].ToString();

			DateTime inicio =
				Convert.ToDateTime(row["d_startDate_per"]);

			DateTime fin =
				Convert.ToDateTime(row["d_endDate_per"]);

			frmC.lblPeriodo.Text =
				$"{inicio:dd/MM/yyyy} al {fin:dd/MM/yyyy}";

			frmC.lblUsuario.Text =
				User.GetUserName();

			bool cerrada = SemanaCerrada(
				row["id_season"].ToString(),
				row["c_sequence_per"].ToString(),
				cls.TipoNomina);

			if (cerrada)
			{
				frmC.lblTitulo.Text = "SEMANA CERRADA";
				frmC.lblTitulo.ForeColor =
					Color.FromArgb(180, 45, 45);

				frmC.lblEstado.Text = "Cerrada";
				frmC.pbColor.Image =
					Properties.Resources.circuloRojo;

				frmC.btnCerrar.Enabled = false;
				frmC.btnCerrar.Text = "Semana Cerrada";

				// Mensaje cuando ya está cerrada
				frmC.lblMensaje.Text =
					"Esta semana ya está cerrada y no puede modificarse.";

				frmC.lblMensaje.Visible = true;
				frmC.pbAviso.Image =
					Properties.Resources.advertenciaRojo;

				// Panel de aviso
				frmC.pnlAviso.BackColor =
					Color.FromArgb(253, 242, 242);

				frmC.pnlLinea.BackColor = Color.FromArgb(190, 50, 50);
			}
			else
			{
				frmC.lblTitulo.Text = "CERRAR SEMANA";
				frmC.lblTitulo.ForeColor =
					Color.FromArgb(30, 120, 50);

				frmC.lblEstado.Text = "Abierta";
				frmC.pbColor.Image =
					Properties.Resources.circuloVerde;

				frmC.btnCerrar.Enabled = true;
				frmC.btnCerrar.Text = "Cerrar Semana";

				// Mensaje cuando todavía puede cerrarse
				frmC.lblMensaje.Text =
					"Importante: Verifique que toda la información de la semana sea correcta antes de realizar el cierre.";

				frmC.lblMensaje.Visible = true;
				frmC.pbAviso.Image =
					Properties.Resources.advertenciaVerde;

				// Panel de aviso
				frmC.pnlAviso.BackColor =
					Color.FromArgb(244, 250, 244);

				frmC.pnlLinea.BackColor = Color.FromArgb(42, 140, 65);
			}
		}
		
		public bool SemanaCerrada(string temporada, string semana, string tipoNomina)
		{
			string query = $@"
			SELECT COUNT(*)
			FROM Nom_PayrollClose
			WHERE id_season = '{temporada}'
			AND c_sequence_per = '{semana}'
			AND c_typePayroll = '{tipoNomina}'";

			int registros =
				Convert.ToInt32(ClsQuerysDB.GetData(query));

			return registros > 0;
		}
		public bool CerrarSemana(DateTime fechaCierre)
		{
			DataTable dt =
				ObtenerInfoCierreSemana(fechaCierre);

			if (dt.Rows.Count == 0)
				return false;

			DataRow row = dt.Rows[0];

			string temporada =
				row["id_season"].ToString();

			string semana =
				row["c_sequence_per"].ToString();


			bool yaCerrada = SemanaCerrada(
				temporada,
				semana,
				cls.TipoNomina);

			if (yaCerrada)
			{
				MessageBox.Show(
					"La semana ya se encuentra cerrada.",
					"Cierre de Semana",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				return true;
			}

			DateTime inicio =
				Convert.ToDateTime(row["d_startDate_per"]);

			DateTime fin =
				Convert.ToDateTime(row["d_endDate_per"]);

			string mensaje;

			if (!ValidarDiasSemana(
				cls.TipoNomina,
				inicio,
				fin,
				out mensaje))
			{
				MessageBox.Show(
					mensaje,
					"Semana incompleta",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return false;
			}

			string query = $@"
        INSERT INTO Nom_PayrollClose
        (
            id_season,
            c_sequence_per,
            c_typePayroll,
            c_userClosed,
            d_dateClosed
        )
        VALUES
        (
            '{temporada}',
            '{semana}',
            '{cls.TipoNomina}',
            '{User.GetUserName()}',
            GETDATE()
        )";

			bool resultado =
				ClsQuerysDB.ExecuteQuery(query);

			return resultado;
		}
		public void BloquearSemanaCerrada()
		{
			// Bloquear botones que modifican la nómina
			frm.btnGuardar.Enabled = false;
			frm.btnCalcularLibra.Enabled = false;

			// Bloquear edición de sueldo
			if (frm.dgvEmployee.Columns.Contains("SueldoTotal"))
			{
				frm.dgvEmployee.Columns["SueldoTotal"].ReadOnly = true;
			}
		}
		
		public void DesbloquearSemana()
		{
			frm.btnGuardar.Enabled = true;
			frm.btnCalcularLibra.Enabled = true;

			if (frm.dgvEmployee.Columns.Contains("SueldoTotal"))
			{
				frm.dgvEmployee.Columns["SueldoTotal"].ReadOnly = false;
			}
		}
		
		public void ValidarSemanaCerrada()
		{
			DataTable dt = ObtenerInfoCierreSemana(frm.dtpFecha.Value);

			if (dt.Rows.Count == 0)
				return;

			string temporada = dt.Rows[0]["id_season"].ToString();
			string semana = dt.Rows[0]["c_sequence_per"].ToString();
			string tipo = cls.TipoNomina;

			bool cerrada = SemanaCerrada(
				temporada,
				semana,
				tipo);

			if (cerrada)
			{
				BloquearSemanaCerrada();
			}
			else
			{
				DesbloquearSemana();
			}
		}
		
		public bool ValidarDiasSemana(
			string tipoNomina,
			DateTime fechaInicio,
			DateTime fechaFin,
			out string mensaje)
		{
			mensaje = "";

			string tablaHistorial =
				tipoNomina == "E"
				? "HistNom_ReporteDiarioEsparrago"
				: "HistNom_ReporteDiarioUva";

			string query = $@"
			SELECT DISTINCT
				CAST(a.d_attendence AS DATE) AS Fecha
			FROM Nom_AttendenceList a
			WHERE
				a.c_payrollType = '{tipoNomina}'
				AND CAST(a.d_attendence AS DATE)
					BETWEEN '{fechaInicio:yyyy-MM-dd}'
					AND '{fechaFin:yyyy-MM-dd}'
				AND NOT EXISTS
				(
					SELECT 1
					FROM {tablaHistorial} h
					WHERE h.Fecha = CAST(a.d_attendence AS DATE)
				)
			ORDER BY Fecha";

			DataTable dt = ClsQuerysDB.GetDataTable(query);

			if (dt.Rows.Count == 0)
				return true;

			StringBuilder sb = new StringBuilder();

			sb.AppendLine("Faltan generar los siguientes días:");

			foreach (DataRow row in dt.Rows)
			{
				DateTime fecha = Convert.ToDateTime(row["Fecha"]);
				sb.AppendLine($"• {fecha:dd/MM/yyyy}");
			}

			mensaje = sb.ToString();

			return false;
		}

		public DataRow ObtenerSemanaPendiente(DateTime fecha, string tipoNomina)
		{
			// 1. Obtener el período de la fecha seleccionada
			DataTable dtActual =
				ObtenerInfoCierreSemana(fecha);

			if (dtActual.Rows.Count == 0)
				return null;

			DataRow periodoActual =
				dtActual.Rows[0];

			string temporada =
				periodoActual["id_season"].ToString();

			DateTime inicioPeriodoActual =
				Convert.ToDateTime(
					periodoActual["d_startDate_per"]);

			// 2. Buscar el último período anterior
			//    que tenga asistencia del mismo tipo
			string query = $@"
			SELECT TOP 1
				p.id_season,
				p.c_sequence_per,
				p.d_startDate_per,
				p.d_endDate_per
			FROM Payroll_AttendancePeriod p
			WHERE p.id_season = '{temporada}'
			  AND p.d_endDate_per < '{inicioPeriodoActual:yyyy-MM-dd}'
			  AND EXISTS
			  (
				  SELECT 1
				  FROM Nom_AttendenceList a
				  WHERE a.c_payrollType = '{tipoNomina}'
					AND CAST(a.d_attendence AS DATE)
						BETWEEN
							CAST(p.d_startDate_per AS DATE)
						AND
							CAST(p.d_endDate_per AS DATE)
			  )
			ORDER BY p.d_endDate_per DESC";

			DataTable dtAnterior =
				ClsQuerysDB.GetDataTable(query);

			if (dtAnterior.Rows.Count == 0)
				return null;

			DataRow semanaAnterior =
				dtAnterior.Rows[0];

			// 3. Verificar si ese período ya está cerrado
			bool cerrada =
				SemanaCerrada(
					semanaAnterior["id_season"].ToString(),
					semanaAnterior["c_sequence_per"].ToString(),
					tipoNomina);

			// Si ya está cerrada, no hay pendiente
			if (cerrada)
				return null;

			// 4. Está abierta → devolver el período
			return semanaAnterior;
		}
	}
}
