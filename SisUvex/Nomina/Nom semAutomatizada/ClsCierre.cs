using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
		public void CargarInformacionCierre(FrmCierre frmC)
		{
			DataTable dt = ObtenerInfoCierreSemana(frm.dtpFecha.Value);

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
				frmC.lblEstado.Text = "Cerrada";
				frmC.pbColor.Image = Properties.Resources.circuloRojo;
				// Deshabilitar botón
				frmC.btnCerrar.Enabled = false;
				frmC.btnCerrar.Text = "Semana Cerrada";
				frmC.btnCerrar.Image = Properties.Resources.cerrado;
			}
			else
			{
				frmC.lblEstado.Text = "Abierta";
				frmC.pbColor.Image = Properties.Resources.circuloVerde;
				// Habilitar botón
				frmC.btnCerrar.Enabled = true;
				frmC.btnCerrar.Text = "Cerrar Semana";
				frmC.btnCerrar.Image = Properties.Resources.abierto;
			}
		}
		public bool SemanaCerrada(string temporada,
						  string semana,
						  string tipoNomina)
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
		public bool CerrarSemana()
		{
			DataTable dt = ObtenerInfoCierreSemana(frm.dtpFecha.Value);

			if (dt.Rows.Count == 0)
				return false;

			DataRow row = dt.Rows[0];
			DateTime inicio = Convert.ToDateTime(row["d_startDate_per"]);
			DateTime fin = Convert.ToDateTime(row["d_endDate_per"]);

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

				frmC.Close();
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
				'{row["id_season"]}',
				'{row["c_sequence_per"]}',
				'{cls.TipoNomina}',
				'{User.GetUserName()}',
				GETDATE()
			)";

			return ClsQuerysDB.ExecuteQuery(query);
		}
		public void BloquearSemanaCerrada()
		{
			// Bloquear acciones
			frm.btnGuardar.Enabled = false;
			frm.btnCalcularLibra.Enabled = false;
			frm.dgvEmployee.Columns["SueldoTotal"].ReadOnly = true;
		}
		public void DesbloquearSemana()
		{
			frm.btnGuardar.Enabled = true;
			frm.btnCalcularLibra.Enabled = true;

			frm.dgvEmployee.Columns["SueldoTotal"].ReadOnly = false;
		}
		public void ValidarSemanaCerrada()
		{
			DataTable dt = ObtenerInfoCierreSemana(frm.dtpFecha.Value);

			if (dt.Rows.Count == 0)
				return;

			bool cerrada = SemanaCerrada(
				dt.Rows[0]["id_season"].ToString(),
				dt.Rows[0]["c_sequence_per"].ToString(),
				cls.TipoNomina);

			if (cerrada)
				BloquearSemanaCerrada();
			else
				DesbloquearSemana();
		}
		public bool ValidarCierreSemanaAnterior(DateTime fecha)
		{
			// La semana anterior termina un día antes
			DateTime fechaAnterior = fecha.AddDays(-1);

			DataTable dt = ObtenerInfoCierreSemana(fechaAnterior);

			if (dt.Rows.Count == 0)
				return true;

			bool cerrada = SemanaCerrada(
				dt.Rows[0]["id_season"].ToString(),
				dt.Rows[0]["c_sequence_per"].ToString(),
				cls.TipoNomina);

			if (cerrada)
				return true;

			DialogResult r = MessageBox.Show(
				$"La semana anterior ({Convert.ToDateTime(dt.Rows[0]["d_startDate_per"]):dd/MM/yyyy} al {Convert.ToDateTime(dt.Rows[0]["d_endDate_per"]):dd/MM/yyyy}) aún no ha sido cerrada.\n\n" +
				"Debe cerrar esa semana antes de generar la nómina de la nueva semana.\n\n" +
				"¿Deseas Cerrar la Semana?",
				"Cierre de Semana Pendiente",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Warning);

			if (r == DialogResult.Yes)
			{
				FrmCierre frmCerrar = new FrmCierre();
				frmCerrar.clsC = this;
				frmCerrar.ShowDialog();
			}

			return false;
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
		
	}
}
