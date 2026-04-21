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
using SisUvex.Nomina.Asistencia_de_empaque;
using static SisUvex.Catalogos.Metods.ClsObject;
using SisUvex.Configuracion;
using System.Data.SqlClient;

namespace SisUvex.Nomina.Registro_de_Asistencia
{
	public partial class FrmRegistroA : Form
	{
		public ClsManual clsM;
		public ClsRegistroA cls;
		public OpenFileDialog ofdExcel = new OpenFileDialog();
		public string idEmpleado = "EMPLEADO", idActividad = "ACTIVIDAD", idBanda = "BANDA";

		public FrmRegistroA()
		{
			InitializeComponent();

		}

		private void btnExaminar_Click(object sender, EventArgs e)
		{
			cls.BuscarExcel();
		}

		private void FrmRegistroA_Load(object sender, EventArgs e)
		{
			cls ??= new();
			cls.frm ??= this;
			clsM ??= new();
			clsM.frm ??= this;
			clsM.BeginForm();
			clsM.InicializarDgv();
			clsM.EstiloDgv();
			clsM.CargarComboActividades();
			cls.CargarAsistenciasPorFecha();
			cls.CargarCuadrillas(cboCuadrilla);

		}

		private void btnMostrar_Click(object sender, EventArgs e)
		{
			cls.CargarHojaExcelEnDatagridView();
			clsM.ConvertirIdsANombres();
		}

		private void btnExcelAceptar_Click(object sender, EventArgs e)
		{
			cls.BotonAceptar();
			cls.CargarAsistenciasPorFecha();
		}

		private void btnInstrucciones_Click(object sender, EventArgs e)
		{
			FrmInstruccionesExcelAsistencia f = new FrmInstruccionesExcelAsistencia();
			f.ShowDialog();
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			dgvAsistencia.Rows.Clear();
			dgvAsistencia.Columns.Clear();
			dtpDay.Refresh();
			cboHoja.Items.Clear();
			txbRuta.Text = string.Empty;
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			ClsSelectionForm sel = new ClsSelectionForm();

			sel.OpenSelectionForm("EmployeeBasic", "Código");

			if (!string.IsNullOrEmpty(sel.SelectedValue))
			{
				txbCodigo.Text = sel.SelectedValue;
				string lastNamePat = sel.dtQuery.Rows[0]["A. paterno"].ToString();
				string lastNameMat = sel.dtQuery.Rows[0]["A. materno"].ToString();
				string name = sel.dtQuery.Rows[0]["Nombre"].ToString();
				txbEmpleado.Text = lastNamePat + " " + lastNameMat + " " + name;

			}
		}

		private void btnAgregarListado_Click(object sender, EventArgs e)
		{
			clsM.btnAgregarEmpleado();
		}

		private void btnMostrarEmpleado_Click(object sender, EventArgs e)
		{
			clsM.AgregarADgv();
		}

		private void dgvAsistencia_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (dgvAsistencia.Columns[e.ColumnIndex].Name == "idEmpleado")
			{
				if (e.Value != null)
				{
					string codigo = e.Value.ToString();


					string nombre = clsM.ObtenerNombreEmpleado(codigo);

					if (!string.IsNullOrEmpty(nombre))
					{
						e.Value = nombre;
						e.FormattingApplied = true;
					}
				}
			}
		}

		private void btnAcceptarEmpleado_Click(object sender, EventArgs e)
		{
			cls.BotonAceptar();
		}

		private void dtpDay_ValueChanged(object sender, EventArgs e)
		{
			cls.CargarAsistenciasPorFecha();
		}

		private void btnEliminar_Click(object sender, EventArgs e)
		{
			cls.EliminarAsistenciaPorCuadrilla(dtpDay.Value, cboCuadrilla.SelectedValue);
			cls.CargarAsistenciasPorFecha();
		}

		private void cboCuadrilla_SelectedIndexChanged(object sender, EventArgs e)
		{
			cls.CargarAsistenciasPorFecha();
		}
	}
}
