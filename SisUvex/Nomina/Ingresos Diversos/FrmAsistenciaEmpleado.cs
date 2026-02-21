using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisUvex.Nomina.Asistencia_de_empaque;

namespace SisUvex.Nomina.Ingresos_Diversos
{
	public partial class FrmAsistenciaEmpleado : Form
	{
		ClsAsistenciaEmpleado cls;
		public FrmAsistenciaEmpleado()
		{
			InitializeComponent();
			cls = new ClsAsistenciaEmpleado(this);
		}

		private void FrmAsistenciaEmpleado_Load(object sender, EventArgs e)
		{
			cls.CargarDatosAsistenciaEmpleado();
		}

		private void btnBuscar_Click(object sender, EventArgs e)
		{
			cls.CargarDatosAsistenciaEmpleado();
		}

		private void txbIdEmpleado_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				cls.CargarDatosAsistenciaEmpleado();
			}
		}

		
	}
}
