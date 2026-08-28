using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Nomina.Nom_Horarios_de_Campo
{
	public partial class FrmAgregar : Form
	{
		public ClsHorarios cls;

		public bool IsAddOrModify = true,
					IsAddUpdate = false,
					IsModifyUpdate = false;

		public string idAddModify;


		public FrmAgregar()
		{
			InitializeComponent();
		}


		public FrmAgregar(FrmHorarios frm, ClsHorarios cls)
		{
			InitializeComponent();
			StartPosition = FormStartPosition.CenterScreen;
			this.cls = cls;
		}

		private void FrmAgregar_Load(object sender, EventArgs e)
		{
			// Cargar cuadrillas
			cls.CargarCuadrillas();

			// MODIFICAR
			if (!IsAddOrModify)
			{
				// Habilitar fecha final
				dtpFechaFin.Enabled = true;
				dtpFechaFin.ShowCheckBox = true;

				cls.CargarHorarioModificar(
					Convert.ToInt32(idAddModify)
				);
			}
			else
			{
				// AGREGAR
				dtpFechaFin.ShowCheckBox = true;
				dtpFechaFin.Checked = false;
				dtpFechaFin.Enabled = false;
			}
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			cls.Guardar();
		}

		private void chkSeleccionarTodas_CheckedChanged(object sender, EventArgs e)
		{
			for (int i = 0; i < clbCuadrilla.Items.Count; i++)
			{
				clbCuadrilla.SetItemChecked(
					i,
					chkSeleccionarTodas.Checked
				);
			}
		}
	}
}
