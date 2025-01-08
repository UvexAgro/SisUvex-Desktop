using Microsoft.IdentityModel.Tokens;
using SisUvex.Archivo.Etiquetas.NombreYCodigo2x1;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;

namespace SisUvex.Archivo.Etiquetas.FrmNombreYCodigo2x1
{
    public partial class FrmNombreYCodigo2x1 : Form
    {
        ClsNombreYCodigo2x1 cls = new ClsNombreYCodigo2x1();
        public FrmNombreYCodigo2x1()
        {
            InitializeComponent();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ImprimirEtiquetaEmpleado();
        }

        private void btnBuscarCodigo_Click(object sender, EventArgs e)
        {
            ClsSelectionForm sel = new ClsSelectionForm();

            sel.OpenSelectionForm("EmployeeBasic", "Código");

            if (!sel.SelectedValue.IsNullOrEmpty())
                txbCodigoEmp.Text = sel.SelectedValue;

            BuscarEmpleadoCodigo();
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
    }
}
