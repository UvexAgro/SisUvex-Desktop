﻿using Microsoft.IdentityModel.Tokens;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;
using SisUvex.Catalogos.Metods.TextBoxes;
using SisUvex.Catalogos.Metods.Values;
using SisUvex.Configuracion;
using SisUvex.Nomina;
using System.Drawing.Printing;
using System.Media;

namespace SisUvex.Archivo.Etiquetas.CajaEmpleado
{
    public partial class FrmCajaEmpleado : Form
    {
        ClsCajaEmpleado cls = new ClsCajaEmpleado();
        ClsSearchEmployees dt;
        PrintDocument pd = new PrintDocument();
        bool IsFirstClick = true;

        public FrmCajaEmpleado()
        {
            InitializeComponent();
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ImprimirCajaEmpleado();
        }
        private void FrmCajaEmpleado_Load(object sender, EventArgs e)
        {
            dt = new ClsSearchEmployees();
            ClsTextBoxes.TxbApplyKeyPressEventInt(txbCodigoEmp);

            ClsConfPrinter clsConfPrinter = new ClsConfPrinter();
            clsConfPrinter.Leer();
        }

        private void txbCodigoEmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoadEmployeeData(txbCodigoEmp.Text);
            }
        }
        public void LoadEmployeeData(string idEmployee)
        {
            FirstClick();

            dt.GetEmployeeData(idEmployee);
            txbCodigoEmp.Text = dt.id;
            lblName.Text = dt.name;
            lblLastNamePat.Text = dt.lastNamePat;
            lblLastNameMat.Text = dt.lastNameMat;
            if (dt.id.IsNullOrEmpty())
            {
                SystemSounds.Exclamation.Play();
                txbCodigoEmp.Focus();
                txbCodigoEmp.SelectAll();
            }
            else
            {
                nudCantidad.Focus();
                nudCantidad.Select(0, nudCantidad.Text.Length);
            }
        }
        private void btnBuscarCodigo_Click(object sender, EventArgs e)
        {
            ClsSelectionForm sel = new ClsSelectionForm();

            sel.OpenSelectionForm("EmployeeBasic", "Código");

            if (!sel.SelectedValue.IsNullOrEmpty())
                txbCodigoEmp.Text = sel.SelectedValue;

            LoadEmployeeData(txbCodigoEmp.Text);
        }
        private void nudCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ImprimirCajaEmpleado();
            }
        }
        private void ImprimirCajaEmpleado()
        {
            FirstClick();

            LoadEmployeeData(txbCodigoEmp.Text);

            if (dt.id.IsNullOrEmpty())
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("Ingrese un código de empleado", "Código de empleado");
            }
            else
            {
                if (!ClsConfPrinter.PrintCode.IsNullOrEmpty())
                {

                    //pd.PrinterSettings.PrinterName = ClsConfPrinter.PrintCode;

                    string superPrint = cls.GetStringZPL(dt.id, dt.name, dt.lastNamePat, dt.lastNameMat, (int)nudCantidad.Value);
                    //MessageBox.Show(superPrint);
                    RawPrinterHelper.SendStringToPrinter(ClsConfPrinter.PrintCode, superPrint);
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado una impresora", "Impresora no seleccionada");
                }
            }
        }
        private void FirstClick()
        {
            if (IsFirstClick)
            {
                dt.SetEmployeesTable();
                IsFirstClick = false;
            }
        }
    }
}
