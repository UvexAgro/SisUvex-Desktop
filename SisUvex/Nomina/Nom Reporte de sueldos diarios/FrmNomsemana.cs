using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;
using SisUvex.Catalogos.Metods.Querys;
using static SisUvex.Catalogos.Metods.ClsObject;
using Excel = Microsoft.Office.Interop.Excel;

namespace SisUvex.Nomina.Nom_Reporte_de_sueldos_diarios
{
	public partial class FrmNomsemana : Form
	{
		ClsNomSemana cls;
		List<string> empleadosSeleccionados = new List<string>();
		bool datosCargados = false;

		public FrmNomsemana()
		{
			InitializeComponent();

		}

		private void FrmNomsemana_Load(object sender, EventArgs e)
		{
			

			cls ??= new();
			cls.frmNom ??= this;
			cls.EstilizarDGV(dgvListaEmpleado);
			cls.EstilizarDGVEmployee(dgvEmployee);
			dgvListaEmpleado.DataBindingComplete += (s, e) =>
			{
				cls.ConfigurarColumnas(dgvListaEmpleado);
			};

			cls.CargarPeriodos();
		

		}

		private void btnEmpleado_Click(object sender, EventArgs e)
		{
			List<string> empleados = new List<string>();

			foreach (DataGridViewRow row in dgvListaEmpleado.Rows)
			{
				if (row.Cells["IdEmpleado"].Value != null)
				{
					empleados.Add(row.Cells["IdEmpleado"].Value.ToString());
				}
			}

			// validar si no hay empleados
			if (empleados.Count == 0)
			{
				MessageBox.Show(
					"No hay empleados en la lista.",
					"Aviso",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return;
			}

			cls.empleadosSeleccionados = empleados;

			DataTable dt = cls.ObtenerSueldosSemanaVarios();
			if (dt == null)
				return;

			dgvEmployee.DataSource = dt;

			cls.VerificarEmpleadosSinDatos(dt);
		}

		private void btnEmployee_Click(object sender, EventArgs e)
		{
			ClsSelectionForm sel = new ClsSelectionForm();
			sel.OpenSelectionForm("EmployeeBasic", "Código");

			if (string.IsNullOrEmpty(sel.SelectedValue) ||
				sel.dtQuery == null ||
				sel.dtQuery.Rows.Count == 0)
				return;

			var row = sel.dtQuery.Rows[0];

			txbCodigo.Text = sel.SelectedValue;
			txbNombre.Text =
			row["A. paterno"].ToString() + " " +
			row["A. materno"].ToString() + " " +
			row["Nombre"].ToString();

		}

		private void btncargar_Click(object sender, EventArgs e)
		{
			dgvEmployee.DataSource = cls.ObtenerSueldosSemana();
			datosCargados = true;
		}

		private void btnExcelBandas_Click(object sender, EventArgs e)
		{
			if (!datosCargados)
			{
				MessageBox.Show("Primero debes cargar los datos.");
				return;
			}

			if (dgvEmployee.Rows.Count == 0)
			{
				MessageBox.Show("No hay datos para exportar");
				return;
			}

			cls.ExportarExcel(dgvEmployee);
		}

		private void btnExcel_Click(object sender, EventArgs e)
		{
			if (dgvEmployee.Rows.Count == 0)
			{
				MessageBox.Show(
					"Primero realiza la consulta.",
					"Sin datos",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return;
			}

			cls.ExportarExcelEmpleado((DataTable)dgvEmployee.DataSource);
		}

		private void btnAñadir_Click(object sender, EventArgs e)
		{
			if (!cls.ValidarEmpleadoSemana())
				return;

			cls.AgregarEmpleado();

			txbCodigo.Clear();   // limpia el textbox
			txbCodigo.Focus();   // regresa el cursor al textbox
		}

		private void dgvListaEmpleado_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dgvListaEmpleado.CurrentRow == null)
				return;

			string id = dgvListaEmpleado.CurrentRow.Cells["IdEmpleado"].Value.ToString();
			string nombre = dgvListaEmpleado.CurrentRow.Cells["Nombre"].Value.ToString();

			DialogResult resultado = MessageBox.Show(
				$"¿Deseas eliminar a {nombre} de la lista?",
				"Confirmar eliminación",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			if (resultado == DialogResult.No)
				return;

			// eliminar de la lista
			empleadosSeleccionados.Remove(id);

			// eliminar del grid
			dgvListaEmpleado.Rows.RemoveAt(dgvListaEmpleado.CurrentRow.Index);
		}
		
	}
}
