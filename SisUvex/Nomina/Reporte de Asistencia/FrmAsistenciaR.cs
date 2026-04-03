using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SisUvex.Catalogos.Metods.ClsObject;
using DrawingColor = System.Drawing.Color;

namespace SisUvex.Nomina.Reporte_de_Asistencia
{
	public partial class FrmAsistenciaR : Form
	{
		ClsRasistencia cls;
		bool cargando = false;
		bool navegando = false;
		bool seleccionando = false;
		bool bloqueando = false;
		bool escribiendo = false;
		public DataTable dtEmpleados;
		ClsDgvAsistncia clsDgv;


		public FrmAsistenciaR()
		{
			InitializeComponent();
		}


		private void FrmAsistenciaR_Load(object sender, EventArgs e)
		{
			cargando = true;

			cls = new ClsRasistencia();
			cls.frmR = this;

			clsDgv = new ClsDgvAsistncia(this);

			cls.EstiloTabla(dgvEmployee);
			clsDgv.EstiloDGVAsistencia(dgvAsistencia);


			cls.CargarCuadrillas();
			cls.CargarPeriodos();
			cls.CargarCombo();
			cboEmployee.DroppedDown = false;
			cboEmployee.Text = "";
			cboEmployee.SelectedIndex = -1;
			cargando = false;

		}


		private void cboSemanaFinal_SelectedIndexChanged(object sender, EventArgs e)
		{
			cls.ValidarRangoSemanas();


		}

		private void cboSemanaInicial_SelectedIndexChanged(object sender, EventArgs e)
		{
			cls.ValidarRangoSemanas();
		}

		private void btnAceptarCuadrilla_Click(object sender, EventArgs e)
		{
			
			cls.CargarAsistencia();
			clsDgv.CargarDgvAsistencia();

		}

		private void btnAcceptarEmpleado_Click(object sender, EventArgs e)
		{
			cls.CargarEmpleadoEnDgv();
			clsDgv.CargarAsistenciaDesdeDGV();
		}

		private void btnImprimir_Click(object sender, EventArgs e)
		{
			try
			{
				//  Validar datos
				if (dgvAsistencia.DataSource == null)
				{
					MessageBox.Show("No hay datos para imprimir");
					return;
				}

				DataTable datos = (DataTable)dgvAsistencia.DataSource;

				if (datos.Rows.Count == 0)
				{
					MessageBox.Show("No hay registros para imprimir");
					return;
				}

				// Generar PDF
			
				MemoryStream ms = clsDgv.GenerarPdfAsistenciaPorEmpleado(datos);

				//  Mostrar PDF
				clsDgv.ShowPdfViewer(ms);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al generar el PDF: " + ex.Message);
			}
		}
	}

}
