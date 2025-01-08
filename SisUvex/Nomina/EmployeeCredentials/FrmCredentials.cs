using Microsoft.IdentityModel.Tokens;
using PdfiumViewer;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;

namespace SisUvex.Nomina.EmployeeCredentials
{
    public partial class FrmCredentials : Form
    {
        ClsCredentials cls;

        public FrmCredentials()
        {
            InitializeComponent();
            cls = new ClsCredentials();
            cls.frm = this;
        }
        private void FrmCredentials_Load(object sender, EventArgs e)
        {
            cls.cboPaymentPlaceList();
        }

        private void btnGenerarListado_Click(object sender, EventArgs e)
        {
            cls.btnEmployeesList();

            chbSelectAll.CheckedChanged -= chbSelectAll_CheckedChanged;
            chbSelectAll.Checked = true;
            chbSelectAll.CheckedChanged += chbSelectAll_CheckedChanged;
        }

        private void btnAgregarListado_Click(object sender, EventArgs e)
        {
            InsertOneEmployee();
        }

        private void btnCargarCredenciales_Click(object sender, EventArgs e)
        {
            cls.btnLoadPdfEmployeesCards();
        }

        private void btnRegisterAsPrinterCards_Click(object sender, EventArgs e)
        {
            cls.btnSetSelectedAsPrinterCards();
        }

        private void chbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            cls.SetImprimirColumnValues(chbSelectAll.Checked);
        }

        private void InsertOneEmployee()
        {
            cls.btnAddOneEmployeeToList();
            txbCodigoEmpleado.Focus();
            txbCodigoEmpleado.SelectAll();
        }

        private void txbCodigoEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                InsertOneEmployee();
                e.Handled = true;
            }
        }

        private void FrmCredentials_FormClosing(object sender, FormClosingEventArgs e)
        {
            cls.ClsFrmClosing();
        }

        private void btnFrmSearchEmployeeId_Click(object sender, EventArgs e)
        {
            ClsSelectionForm sel = new ClsSelectionForm();

            sel.OpenSelectionForm("EmployeeBasic", "Código");

            if (!sel.SelectedValue.IsNullOrEmpty())
                txbCodigoEmpleado.Text = sel.SelectedValue;

            txbCodigoEmpleado.Focus();

            txbCodigoEmpleado.SelectAll();
        }
    }
}