using SisUvex.Archivo.Etiquetas.NombreYCodigo2x1;

namespace SisUvex.Archivo.Etiquetas.FrmNombreYCodigo2x1
{
    public partial class FrmNombreYCodigo2x1 : Form
    {
        ClsNombreYCodigo2x1 cls = new ClsNombreYCodigo2x1();
        public FrmNombreYCodigo2x1()
        {
            InitializeComponent();

            //dgvEmpleados.DataSource = cls.ListadoEmpleados("");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvEmpleados.DataSource = cls.ListadoEmpleados(txbNombreEmpleado.Text);

        }

        private void dgvEmpleados_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarEmpleado();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ImprimirEtiquetaEmpleado();
        }

        private void btnBuscarCodigo_Click(object sender, EventArgs e)
        {
            BuscarEmpleadoCodigo();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            SeleccionarEmpleado();
        }

        private void SeleccionarEmpleado()
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                DataGridViewRow dgv = dgvEmpleados.SelectedRows[0];
                string id = dgv.Cells["Código"].Value.ToString();
                txbCodigoEmp.Text = id;

                cls.DatosEmpleado(ref lblNombre, ref lblApellido, ref txbCodigoEmp);

                nudCantidad.Focus();
                nudCantidad.Select(0, nudCantidad.Text.Length);
            }
            else
            {
                txbCodigoEmp.Focus();
                txbCodigoEmp.SelectAll();
            }
        }


        private void ImprimirEtiquetaEmpleado()
        {
            if (cls.DatosEmpleado(ref lblNombre, ref lblApellido, ref txbCodigoEmp))
            {
                cls.ImprimirCajaEmpleado(txbCodigoEmp.Text, Convert.ToInt32(nudCantidad.Value), lblNombre.Text, lblApellido.Text);
            }
            else
            {
                lblNombre.Text = string.Empty;
                lblApellido.Text = string.Empty;

                MessageBox.Show("No se encontró el empleado con el código: " + txbCodigoEmp.Text, "Datos del empleado");
            }
            txbCodigoEmp.Focus();
            txbCodigoEmp.SelectAll();
        }

        private void BuscarEmpleadoCodigo()
        {
            if (!cls.DatosEmpleado(ref lblNombre, ref lblApellido, ref txbCodigoEmp))
            {
                lblNombre.Text = string.Empty;
                lblApellido.Text = string.Empty;

                MessageBox.Show("No se encontró el empleado con el código: " + txbCodigoEmp.Text, "Datos del empleado");

                txbCodigoEmp.Focus();
                txbCodigoEmp.SelectAll();
            }
            else
            {
                nudCantidad.Focus();
                nudCantidad.Select(0, nudCantidad.Text.Length);
            }
        }

        private void txbCodigoEmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BuscarEmpleadoCodigo();
            }
        }

        private void nudCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ImprimirEtiquetaEmpleado();
            }
        }

        private void txbNombreEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                dgvEmpleados.DataSource = cls.ListadoEmpleados(txbNombreEmpleado.Text);
            }
        }
    }
}
