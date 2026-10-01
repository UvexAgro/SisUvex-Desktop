using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.SS.Formula.Functions;
using SisUvex.Nomina.Nom_Consulta_de_Actividad_por_empleado;

namespace SisUvex.Nomina.NomCampoAgregarListados
{
	public partial class FrmModificar : Form
	{
		public ClsAgregarLoteyActividad clsCAL;
		public ClsModificar clsM;
		public ComboBox[] cboActividad = new ComboBox[7];
		public ComboBox[] cboLote = new ComboBox[7];
		public string CodigoEmpleado { get; set; }
		public string NombreEmpleado { get; set; }
		public string Semana { get; set; }
		public DateTime FechaInicio { get; set; }
		public DateTime FechaFin { get; set; }
		public string IdCuadrilla { get; set; }
		public string IdWorkGroup { get; set; }
		public FrmModificar()
		{
			InitializeComponent();

			clsM ??= new ClsModificar();
			clsM.frmM ??= this;

			clsCAL ??= new ClsAgregarLoteyActividad();
			clsCAL.frmM ??= this;

			this.StartPosition = FormStartPosition.CenterScreen;
		}

		private void FrmModificar_Load(object sender, EventArgs e)
		{
			txbCodigo.Text = CodigoEmpleado;
			txbEmpleado.Text = NombreEmpleado;
			txbSemana.Text = Semana;

			dtpInicio.Value = FechaInicio;
			dtpFinal.Value = FechaFin;

			// SOLO PARA MOSTRAR
			txbCuadrilla.Text = IdCuadrilla;

			// ==========================================
			// SOLO LECTURA
			// ==========================================

			txbCodigo.ReadOnly = true;
			txbEmpleado.ReadOnly = true;
			txbSemana.ReadOnly = true;
			txbCuadrilla.ReadOnly = true;

			dtpInicio.Enabled = false;
			dtpFinal.Enabled = false;


			clsM.CrearTablaSemana();
			clsM.CargarCombosSemana();
			clsM.CargarDatosEmpleadoSemana(CodigoEmpleado,Semana);
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnContinuar_Click(object sender, EventArgs e)
		{
			try
			{
				string codigoEmpleado =
					CodigoEmpleado.Trim();

				string secuenciaSemana =
					Semana.Trim();

				string idCuadrilla =
					 IdWorkGroup.Trim();

				DateTime fechaInicio =
					FechaInicio;

				DateTime fechaFin =
					FechaFin;


				// ==========================================
				// VALIDAR EMPLEADO
				// ==========================================

				if (string.IsNullOrWhiteSpace(codigoEmpleado))
				{
					MessageBox.Show(
						"No se encontró el empleado.",
						"Modificar",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					return;
				}


				// ==========================================
				// VALIDAR SEMANA
				// ==========================================

				if (string.IsNullOrWhiteSpace(secuenciaSemana))
				{
					MessageBox.Show(
						"No se encontró la semana.",
						"Modificar",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					return;
				}


				// ==========================================
				// VALIDAR CUADRILLA
				// ==========================================

				if (string.IsNullOrWhiteSpace(idCuadrilla))
				{
					MessageBox.Show(
						"No se encontró la cuadrilla.",
						"Modificar",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					return;
				}


				// ==========================================
				// DÍAS
				// ==========================================

				string[] dias =
				{
					"vie",
					"sab",
					"dom",
					"lun",
					"mar",
					"mie",
					"jue"
				};


				int diasGuardados = 0;


				// ==========================================
				// RECORRER LOS 7 DÍAS
				// ==========================================

				for (int i = 0; i < 7; i++)
				{
					string idActividad = "";
					string idLote = "";
					string idVariedad = "";


					// ======================================
					// ACTIVIDAD
					// ======================================

					if (cboActividad[i].SelectedValue != null)
					{
						idActividad =
							cboActividad[i]
							.SelectedValue
							.ToString()
							.Trim();
					}


					// ======================================
					// LOTE
					// ======================================

					if (cboLote[i].SelectedItem is DataRowView filaLote)
					{
						idLote =
							filaLote["c_codigo_lot"]
							?.ToString()
							.Trim() ?? "";

						idVariedad =
							filaLote["id_variety"]
							?.ToString()
							.Trim() ?? "";
					}


					// ======================================
					// SABER QUÉ TIENE EL DÍA
					// ======================================

					bool tieneActividad =
						!string.IsNullOrWhiteSpace(idActividad);

					bool tieneLote =
						!string.IsNullOrWhiteSpace(idLote);

					bool tieneVariedad =
						!string.IsNullOrWhiteSpace(idVariedad);


					// ======================================
					// DÍA COMPLETAMENTE VACÍO
					// ======================================
					// NO HACEMOS NADA.
					//
					// Esto es lo que evita que un día vacío
					// borre información existente.
					// ======================================

					if (!tieneActividad &&
						!tieneLote &&
						!tieneVariedad)
					{
						continue;
					}


					// ======================================
					// COMBINACIONES PERMITIDAS
					// ======================================

					bool actividadSola =
						tieneActividad &&
						!tieneLote &&
						!tieneVariedad;

					bool loteConVariedad =
						!tieneLote
							? false
							: !tieneActividad &&
							  tieneLote &&
							  tieneVariedad;

					bool actividadLoteVariedad =
						tieneActividad &&
						tieneLote &&
						tieneVariedad;


					// ======================================
					// VALIDAR COMBINACIÓN
					// ======================================

					if (!actividadSola &&
						!loteConVariedad &&
						!actividadLoteVariedad)
					{
						MessageBox.Show(
							$"La información del día {dias[i].ToUpper()} " +
							"no tiene una combinación válida.\n\n" +
							"Puede guardar:\n" +
							"• Actividad sola\n" +
							"• Lote + variedad\n" +
							"• Actividad + lote + variedad",
							"Información inválida",
							MessageBoxButtons.OK,
							MessageBoxIcon.Warning);

						return;
					}


					// ======================================
					// GUARDAR DÍA
					// ======================================

					clsCAL.GuardarActividadLoteCuadrilla(
						codigoEmpleado,
						secuenciaSemana,
						fechaInicio,
						fechaFin,
						dias[i],
						idCuadrilla,
						idActividad,
						idVariedad,
						idLote);

					diasGuardados++;
				}


				// ==========================================
				// VALIDAR SI SE GUARDÓ ALGO
				// ==========================================

				if (diasGuardados == 0)
				{
					MessageBox.Show(
						"No hay información para guardar.",
						"Modificar",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					return;
				}


				// ==========================================
				// ÉXITO
				// ==========================================

				MessageBox.Show(
					"La información se guardó correctamente.",
					"Guardar",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al guardar los cambios:\n" +
					ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}
	}
}
