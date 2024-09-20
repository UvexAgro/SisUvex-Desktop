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
    public partial class FrmAsistenciaEmpaqueNuevo : Form
    {
        ClsAsistenciaEmpaqueNuevo cls;
        public string idEmpleado = "EMPLEADO", idActividad = "ACTIVIDAD", horasExtras = "HORAS EXTRAS";
        public FrmAsistenciaEmpaqueNuevo()
        {
            InitializeComponent();
            cls = new ClsAsistenciaEmpaqueNuevo(this);

        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            cls.BuscarExcel();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            cls.CargarHojaExcelEnDatagridView();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dgvLista.Rows.Clear();
            dgvLista.Columns.Clear();
            dtpDia.Refresh();
            cboHoja.Items.Clear();
            txbExaminar.Text = string.Empty;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            cls.BotonAceptar();
        }

        private void btnInstrucciones_Click(object sender, EventArgs e)
        {
            FrmInstruccionesExcelAsistencia f = new FrmInstruccionesExcelAsistencia();
            f.ShowDialog();
        }
    }
}
