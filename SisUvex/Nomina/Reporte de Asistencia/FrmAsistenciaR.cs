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
using SisUvex.Catalogos.Metods.Forms.SelectionForms;
using SisUvex.Catalogos.Metods.Values;
using static NPOI.HSSF.Util.HSSFColor;
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
		string codigo;
		string lastNamePat;
		string lastNameMat;
		string name;
		bool cuadrilla_Empleado = false; //false es empleados y true es cuadrilla 



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
			dtEmpleados = new DataTable();
			dtEmpleados.Columns.Add("Codigo");
			dtEmpleados.Columns.Add("Nombre");
			dgvEmployee.DataSource = dtEmpleados;
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
			dtEmpleados.Rows.Clear();
			cls.CargarAsistencia();
			clsDgv.CargarDgvAsistencia();
			cuadrilla_Empleado = true;

		}

		private void btnAcceptarEmpleado_Click(object sender, EventArgs e)
		{
			DateTime? fechaInicio = cls.GetFechaInicio();
			DateTime? fechaFin = cls.GetFechaFin();

			if (fechaInicio == null || fechaFin == null)
				return;

			DataTable dt = clsDgv.ObtenerAsistenciaDesdeGrid(
				fechaInicio.Value,
				fechaFin.Value
			);

			dgvAsistencia.DataSource = dt;
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

		private void btnSearch_Click(object sender, EventArgs e)
		{

			ClsSelectionForm sel = new ClsSelectionForm();
			sel.OpenSelectionForm("EmployeeBasic", "Código");

			if (string.IsNullOrEmpty(sel.SelectedValue) ||
				sel.dtQuery == null ||
				sel.dtQuery.Rows.Count == 0)
				return;

			txbCodigo.Text = sel.SelectedValue;
			btnAgregarEmpleado();

		}

		private void btnAgregarListado_Click(object sender, EventArgs e)
		{
			btnAgregarEmpleado();
		}
		public void btnAgregarEmpleado()
		{

			if (cuadrilla_Empleado)
				dtEmpleados.Rows.Clear();

			string idEmpleado = ClsValues.FormatZeros(txbCodigo.Text, "000000");
			if (ExisteEmpleado(idEmpleado))
			{
				MessageBox.Show("El empleado ya esta en la lista");
				return;
			}

			txbEmpleado.Text = "";
			txbCodigo.Focus();
			txbCodigo.SelectAll();

			DateTime? fechaInicio = cls.GetFechaInicio();
			DateTime? fechaFin = cls.GetFechaFin();

			cls.Empleado(idEmpleado, fechaInicio, fechaFin);

			cuadrilla_Empleado = false;
		}
		public bool ExisteEmpleado(string idEmpleado)
		{
			if (dtEmpleados == null || dtEmpleados.Rows.Count == 0)
				return false;

			return dtEmpleados.AsEnumerable()
				.Any(row => row["Codigo"].ToString() == idEmpleado);
		}
	}
}
