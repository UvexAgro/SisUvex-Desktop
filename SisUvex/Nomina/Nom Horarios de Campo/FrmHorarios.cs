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
using SisUvex.Nomina.NomCuadrillasCampo;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Nomina.Nom_Horarios_de_Campo
{
	public partial class FrmHorarios : Form
	{
		public ClsHorarios cls;
		public ClsGrupoHorario clsH;
		public bool modificando = false;
		public FrmHorarios()
		{
			InitializeComponent();
			cls = new ClsHorarios();
			cls.frm = this;

			clsH = new ClsGrupoHorario();
			clsH.frm = this;
		}
		private void HasEditCatalogsPermission() //metodo para dar permisos al usuario 
		{
			if (User.HasEditCatalogsPermission())
				return;

			btnAdd.Enabled = false;
			btnModify.Enabled = false;
			btnRemove.Enabled = false;
		}
		private void FrmHorarios_Load(object sender, EventArgs e)
		{
			HasEditCatalogsPermission();
			clsH.DeshabilitarCampos();
			clsH.CargarDgvGrupo();
			clsH.ConfigurarDgvGrupo();
			cls.CargarGrupos();
			cls.CargarCuadrillasDisponibles();
			cls.ConfigurarDgvCuadrillaDisponible();
			cls.CargarCuadrillasAsignadas();
			cls.ConfigurarDgvCuadrillaAsignada();
			cls.CargarHorarios();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			clsH.AñadirHorario();
		}

		private void btnModify_Click(object sender, EventArgs e)
		{
			clsH.ModificarHorario();
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			clsH.EliminarHorario();
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			if (!clsH.ValidarHorario())
				return;

			if (modificando)
			{
				clsH.ActualizarHorario();
			}
			else
			{
				clsH.GuardarHorario();
			}

			// Actualizar el combo de grupos
			cls.CargarGrupos();
		}

		private void dgvGrupo_SelectionChanged(object sender, EventArgs e)
		{
			clsH.CargarDatosGrupo();
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			clsH.CancelarHorario();
		}

		private void cboGrupos_SelectedIndexChanged(object sender, EventArgs e)
		{
			cls.CargarCuadrillasDisponibles();
			cls.CargarCuadrillasAsignadas();
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
			// Validar que haya un grupo seleccionado
			if (cboGrupos.SelectedIndex == -1)
			{
				MessageBox.Show(
					"Seleccione un grupo de horario.",
					"Aviso",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			// Validar que haya una cuadrilla seleccionada
			if (dgvCuadrillaDisponible.CurrentRow == null)
			{
				MessageBox.Show(
					"Seleccione una cuadrilla.",
					"Aviso",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			DataTable dtAsignadas =
				(DataTable)dgvCuadrillaAsignada.DataSource;

			DataGridViewRow fila =
				dgvCuadrillaDisponible.CurrentRow;

			DataRow nuevaFila =
				dtAsignadas.NewRow();

			nuevaFila["ID"] =
				fila.Cells["ID"].Value;

			nuevaFila["Nombre de la cuadrilla"] =
				fila.Cells["Nombre de la cuadrilla"].Value;

			dtAsignadas.Rows.Add(nuevaFila);

			// Quitar de disponibles
			DataTable dtDisponibles =
				(DataTable)dgvCuadrillaDisponible.DataSource;

			DataRowView filaView =
				(DataRowView)fila.DataBoundItem;

			dtDisponibles.Rows.Remove(filaView.Row);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			cls.GuardarGrupo();
		}

		private void btnQuitar_Click(object sender, EventArgs e)
		{

			if (dgvCuadrillaAsignada.CurrentRow == null)
			{
				MessageBox.Show(
					"Seleccione una cuadrilla.",
					"Aviso",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			DataTable dtDisponibles =
				(DataTable)dgvCuadrillaDisponible.DataSource;

			DataGridViewRow fila =
				dgvCuadrillaAsignada.CurrentRow;

			DataRow nuevaFila =
				dtDisponibles.NewRow();

			nuevaFila["ID"] =
				fila.Cells["ID"].Value;

			nuevaFila["Nombre de la cuadrilla"] =
				fila.Cells["Nombre de la cuadrilla"].Value;

			dtDisponibles.Rows.Add(nuevaFila);

			DataTable dtAsignadas =
				(DataTable)dgvCuadrillaAsignada.DataSource;

			DataRowView filaView =
				(DataRowView)fila.DataBoundItem;

			dtAsignadas.Rows.Remove(filaView.Row);
		}
	}
}
