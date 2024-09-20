using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Nomina.Asistencia_de_empaque
{
    public partial class FrmAsistenciaEmpaqueEmpleado : Form
    {
        ClsAsistenciaEmpaqueEmpleado cls;
        public FrmAsistenciaEmpaqueEmpleado()
        {
            InitializeComponent();
            cls = new ClsAsistenciaEmpaqueEmpleado(this);
        }

        private void btnBuscarAsistencias_Click(object sender, EventArgs e)
        {
            cls.CargarDatosAsistenciaEmpleado();
        }

        private void FrmAsistenciaEmpaqueEmpleado_Load(object sender, EventArgs e)
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
