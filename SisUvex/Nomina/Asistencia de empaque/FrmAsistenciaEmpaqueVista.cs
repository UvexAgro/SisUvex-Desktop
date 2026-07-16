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
    public partial class FrmAsistenciaEmpaqueVista : Form
    {
        ClsAsistenciaEmpaqueVista cls;
        public FrmAsistenciaEmpaqueVista()
        {
            InitializeComponent();
            cls = new ClsAsistenciaEmpaqueVista(this);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvLista.DataSource = cls.ObtenerAsistenciaEmpaqueDia();
        }

        private void FrmAsistenciaEmpaqueVista_Load(object sender, EventArgs e)
        {
            dgvLista.DataSource = cls.ObtenerAsistenciaEmpaqueDia();
        }
    }
}
