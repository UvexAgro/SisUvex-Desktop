using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.IdentityModel.Tokens;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;
using SisUvex.Nomina.Asistencia_de_empaque;
using SisUvex.Nomina.Conceptos_Ingresos_Diversos;
using SisUvex.Nomina.Reporte_de_Emp_UVA;


namespace SisUvex.Nomina.Ingresos_Diversos
{
	public partial class FrmListaAsitencia : Form
	{
		public FrmMenu frmMenu;
		private bool cargando = false;
		private bool esCampo = true;
		ClsIngresosDiversos cls;
		ClsDeducciones clsDeu;


		public string empleadoValor;

		public FrmListaAsitencia(FrmMenu frmMenu)
		{
			InitializeComponent();
			this.frmMenu = frmMenu;

			cls = new ClsIngresosDiversos();
			cls.frmMenu = this.frmMenu;
			cls.frmDia = this;

			clsDeu = new ClsDeducciones();
		}

		private void FrmListaAsitencia_Load(object sender, EventArgs e)
		{
			cls ??= new ClsIngresosDiversos();
			cls.frmDia ??= this;

			cls.CargarComboActividades();
			cls.ObtenerAsistenciaEmpaqueDia();
			cls.CargarCuadrillaCampo(cboCuadrillaCampo);
			cls.CargarCuadrillaEmpaque(cboCuadrillaEmpaque);

			dgvLista.CurrentCellDirtyStateChanged += (s, ev) =>
			{
				if (dgvLista.IsCurrentCellDirty)
					dgvLista.CommitEdit(DataGridViewDataErrorContexts.Commit);
			};
		}

		private void btnBuscar_Click(object sender, EventArgs e)
		{
			if (esCampo)
			{
				cls.ObtenerEmpleadosCampoDia();
			}
			else
			{
				cls.ObtenerAsistenciaEmpaqueDia();
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			List<string> ids = new List<string>();

			foreach (DataGridViewRow row in dgvLista.Rows)
			{
				if (row.IsNewRow)
					continue;

				bool marcado = row.Cells["Seleccionar"].Value != null &&
							   Convert.ToBoolean(row.Cells["Seleccionar"].Value);

				if (marcado)
				{
					// EMPAQUE
					if (!esCampo)
					{
						if (dgvLista.Columns.Contains("id_attendence"))
						{
							if (row.Cells["id_attendence"].Value != null &&
								row.Cells["id_attendence"].Value != DBNull.Value)
							{
								ids.Add(
									row.Cells["id_attendence"].Value.ToString()
								);
							}
						}
					}

					// CAMPO
					else
					{
						if (dgvLista.Columns.Contains("id_attendance"))
						{
							if (row.Cells["id_attendance"].Value != null &&
								row.Cells["id_attendance"].Value != DBNull.Value)
							{
								ids.Add(
									row.Cells["id_attendance"].Value.ToString()
								);
							}
						}
					}
				}
			}

			if (ids.Count == 0)
			{
				MessageBox.Show("Seleccione al menos una asistencia");
				return;
			}

			// SE MANDA EL ID Y SI ES CAMPO O EMPAQUE
			FrmAddIngresos frm = new FrmAddIngresos(ids, esCampo);

			if (frm.ShowDialog() == DialogResult.OK)
			{
				if (esCampo)
				{
					cls.ObtenerEmpleadosCampoDia();
				}
				else
				{
					cls.ObtenerAsistenciaEmpaqueDia();
				}
			}
		}

		private void btnModify_Click(object sender, EventArgs e)
		{
			if (dgvLista.CurrentRow == null)
			{
				MessageBox.Show("Seleccione un registro");
				return;
			}

			if (dgvLista.CurrentRow.Cells["id_concept"].Value == DBNull.Value ||
				dgvLista.CurrentRow.Cells["id_concept"].Value == null)
			{
				MessageBox.Show("Este registro no tiene ingreso para modificar");
				return;
			}

			string idConcepto =
				dgvLista.CurrentRow.Cells["id_concept"].Value.ToString();

			decimal monto =
				Convert.ToDecimal(dgvLista.CurrentRow.Cells["Monto"].Value);

			string idAttendence = null;
			string idWorkGroupEmployeeDaily = null;

			// CAMPO
			if (esCampo)
			{
				if (!dgvLista.Columns.Contains("id_attendance"))
				{
					MessageBox.Show("No se encontró el identificador de asistencia de campo.");
					return;
				}

				if (dgvLista.CurrentRow.Cells["id_attendance"].Value == null ||
					dgvLista.CurrentRow.Cells["id_attendance"].Value == DBNull.Value)
				{
					MessageBox.Show("El registro no tiene asistencia.");
					return;
				}

				idWorkGroupEmployeeDaily =
					dgvLista.CurrentRow.Cells["id_attendance"]
					.Value.ToString();
			}
			// EMPAQUE
			else
			{
				if (!dgvLista.Columns.Contains("id_attendence"))
				{
					MessageBox.Show("No se encontró el identificador de asistencia.");
					return;
				}

				if (dgvLista.CurrentRow.Cells["id_attendence"].Value == null ||
					dgvLista.CurrentRow.Cells["id_attendence"].Value == DBNull.Value)
				{
					MessageBox.Show("El registro no tiene asistencia.");
					return;
				}

				idAttendence =
					dgvLista.CurrentRow.Cells["id_attendence"]
					.Value.ToString();
			}

			FrmAddIngresos frm = new FrmAddIngresos(
				idAttendence,
				idWorkGroupEmployeeDaily,
				idConcepto,
				monto,
				esCampo);

			if (frm.ShowDialog() == DialogResult.OK)
			{
				if (esCampo)
				{
					cls.ObtenerEmpleadosCampoDia();
				}
				else
				{
					cls.ObtenerAsistenciaEmpaqueDia();
				}
			}
		}
		private void btnEliminar_Click(object sender, EventArgs e)
		{
			cls.EliminarIngresoDesdeGrid(dgvLista);
		}

		private void btnAñadirD_Click(object sender, EventArgs e)
		{
			if (dgvLista.CurrentRow == null)
			{
				MessageBox.Show("Seleccione una asistencia");
				return;
			}

			string idAttendence = dgvLista.CurrentRow.Cells["id_attendence"].Value.ToString();

			FrmDeducciones frm = new FrmDeducciones(idAttendence);

			if (frm.ShowDialog() == DialogResult.OK)
			{
				cls.ObtenerAsistenciaEmpaqueDia();
			}
		}

		private void btnModificarDed_Click(object sender, EventArgs e)
		{
			if (dgvLista.CurrentRow == null)
			{
				MessageBox.Show("Seleccione un registro");
				return;
			}

			if (dgvLista.CurrentRow.Cells["id_Deductions"].Value == null ||
				dgvLista.CurrentRow.Cells["id_Deductions"].Value == DBNull.Value)
			{
				MessageBox.Show("Esta asistencia no tiene descuento para modificar");
				return;
			}

			string idDeductions =
				dgvLista.CurrentRow.Cells["id_Deductions"].Value.ToString();

			decimal montoD =
				dgvLista.CurrentRow.Cells["Descuento"].Value == DBNull.Value
				? 0
				: Convert.ToDecimal(
					dgvLista.CurrentRow.Cells["Descuento"].Value);

			// Saber si el grid es CAMPO o EMPAQUE
			bool esCampo =
				dgvLista.Columns.Contains("id_workGroupEmployeeDaily");

			string idAttendence = null;
			string idWorkGroupEmployeeDaily = null;

			if (esCampo)
			{

				// CAMPO


				object valor =
					dgvLista.CurrentRow.Cells[
						"id_workGroupEmployeeDaily"].Value;

				if (valor != null && valor != DBNull.Value)
				{
					idWorkGroupEmployeeDaily = valor.ToString();
				}
			}
			else
			{
				// EMPAQUE


				object valor =
					dgvLista.CurrentRow.Cells[
						"id_attendence"].Value;

				if (valor != null && valor != DBNull.Value)
				{
					idAttendence = valor.ToString();
				}
			}

			if (string.IsNullOrEmpty(idAttendence) &&
				string.IsNullOrEmpty(idWorkGroupEmployeeDaily))
			{
				MessageBox.Show(
					"No se encontró el identificador de la asistencia");

				return;
			}

			// ABRIR FORMULARIO

			FrmDeducciones frm = new FrmDeducciones(idAttendence, idWorkGroupEmployeeDaily, idDeductions, montoD, esCampo);

			if (frm.ShowDialog() == DialogResult.OK)
			{
				if (esCampo)
				{
					cls.ObtenerEmpleadosCampoDia();
				}
				else
				{
					cls.ObtenerAsistenciaEmpaqueDia();
				}
			}
		}

		private void cboActividad_SelectedIndexChanged(object sender, EventArgs e)
		{
			cls.ObtenerAsistenciaEmpaqueDia();

		}

		private void cboCuadrillaCampo_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cargando)
				return;

			if (cboCuadrillaCampo.SelectedIndex > 0)
			{
				cboCuadrillaEmpaque.SelectedIndex = 0;
			}
		}

		private void cboCuadrillaEmpaque_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cargando)
				return;

			if (cboCuadrillaEmpaque.SelectedIndex > 0)
			{
				cboCuadrillaCampo.SelectedIndex = 0;
			}
		}

		private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
		{
			bool seleccionar = chkSeleccionar.Checked;

			foreach (DataGridViewRow fila in dgvLista.Rows)
			{
				if (!fila.IsNewRow)
				{
					fila.Cells["Seleccionar"].Value = seleccionar;
				}
			}

			dgvLista.EndEdit();
		}

		private void cboCuadrillaCampo_Enter(object sender, EventArgs e)
		{
			esCampo = true;
		}

		private void cboCuadrillaEmpaque_Enter(object sender, EventArgs e)
		{
			esCampo = false;
		}
	}

}
