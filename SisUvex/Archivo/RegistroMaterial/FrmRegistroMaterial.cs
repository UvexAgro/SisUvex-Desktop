using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Extensiones;
using SisUvex.Catalogos.Nomina.LOAD;
using SisUvex.Catalogos.RegistroMaterial;
using SisUvex.Catalogos.Variedad;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SisUvex.Archivo.RegistroMaterial
{
    public partial class FrmRegistroMaterial : Form
    {
        public string usrCreador = "USUARIO", fechaCreacion = "2023-01-01";

        public bool añadirModificar = true;
        ClsRegistroMaterial cls = new ClsRegistroMaterial();
        List<ComboBox> ComboBoxes = new List<ComboBox>();
        List<Control> Obligatorios = new List<Control>();
        DateTime fechaAnterior;
        public FrmRegistroMaterial(FrmRegistroMaterialCat catalogo)
        {
            InitializeComponent();
            ComboBoxes.Add(cboTipoMat);
            ComboBoxes.Add(cboMaterial);
            ComboBoxes.Add(cboLote);
            ComboBoxes.Add(cboProveedor);
            ComboBoxes.Add(cboLineaTran);
            SetObligatorios();

        }
        #region METODOS CARGAR DGVHIJO
        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;
        public class UpdateEventArgs : EventArgs
        {
            public string Data { get; set; }
        }
        protected void ActualizarCatalogoHijo()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler.Invoke(this, args);
        }
        #endregion
        private void FrmRegistroMaterial_Load(object sender, EventArgs e)
        {
            cls.CargarComboBoxes(ComboBoxes);
            if (añadirModificar)
            {
                txbItem.Text = "01";
            }
            else
            {
                txbItem.Text = cls.SiguienteItem(dgvMateriales);
            }
        }

        #region TIPO DE MATERIAL
        private void btnBuscarTipoMat_Click(object sender, EventArgs e)
        {
            txbIdTipoMat.Text = cls.BtnBuscarMatTipo(cboTipoMat);
        }
        private void cboTipoMat_MouseClick(object sender, MouseEventArgs e)
        {
            cls.CboPrimerClic(cboTipoMat);
        }
        private void cboTipoMat_TextChanged(object sender, EventArgs e)
        {
            txbIdTipoMat.Text = cls.CboValueDelSeleccionado(cboTipoMat);
            cls.CboCargarInicio(cboMaterial, cls.CboMaterial(txbIdTipoMat.Text, ""));
            txbIdMaterial.Text = string.Empty;
        }
        #endregion FIN TIPO DE MATERIAL

        #region MATERIAL
        private void cboMaterial_MouseClick(object sender, MouseEventArgs e)
        {
            cls.CboPrimerClic(cboMaterial);
        }
        private void cboMaterial_TextChanged(object sender, EventArgs e)
        {
            txbIdMaterial.Text = cls.CboValueDelSeleccionado(cboMaterial);
        }
        private void btnBuscarMaterial_Click(object sender, EventArgs e)
        {
            txbIdMaterial.Text = cls.BtnBuscarMaterial(cboMaterial, txbIdTipoMat.Text);
        }
        private void btnTodoMaterial_Click(object sender, EventArgs e)
        {
            txbIdMaterial.Text = cls.BtnTodoMaterial(cboMaterial);
            cls.CboCargarEnBlanco(cboTipoMat, cls.CboTipoMaterial(""));
        }
        #endregion FIN MATERIAL
        private void SetObligatorios()
        {
            Obligatorios.Add(txbIdMaterial);
            txbIdMaterial.SetMensajeVacio("Selecciona un material.");
            txbIdMaterial.SetControlRelacionado(txbIdMaterial);
            Obligatorios.Add(txbItem);
            txbItem.SetMensajeVacio("Falta Item.");
            txbItem.SetControlRelacionado(txbItem);
            Obligatorios.Add(txbCantidad);
            txbCantidad.SetMensajeVacio("Introducir cantidad.");
            txbCantidad.SetControlRelacionado(txbCantidad);
            Obligatorios.Add(cboCampo);
            cboCampo.SetMensajeVacio("Introducir campo (ubicación).");
            cboCampo.SetControlRelacionado(cboCampo);
            Obligatorios.Add(txbFolio);
            txbFolio.SetMensajeVacio("Introducir folio de documentación.");
            txbFolio.SetControlRelacionado(txbFolio);
            Obligatorios.Add(dtpFecha);
            dtpFecha.SetMensajeVacio("Seleccionar fecha.");
            dtpFecha.SetControlRelacionado(dtpFecha);
        }

        #region CANTIDAD
        private void txbCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            cls.TxbTeclasDecimales(sender, e);
        }
        private void txbCantidad_TextChanged(object sender, EventArgs e)
        {
            cls.TxbFormatoNumeric((TextBox)sender, 100000000);
        }
        private void txbIdMaterial_TextChanged(object sender, EventArgs e)
        {
            txbUnidad.Text = cls.TxbUnidad(txbIdMaterial.Text);
        }

        #endregion FIN CANTIDAD

        #region LOTE
        private void btnTodoLote_Click(object sender, EventArgs e)
        {
            txbIdLote.Text = cls.BtnTodoLote(cboLote);
            if (cls.ActLot)
                btnTodoLote.Text = "Activos";
            else
                btnTodoLote.Text = "Todo";
        }
        private void btnBuscarLote_Click(object sender, EventArgs e)
        {
            cls.BtnBuscarLote(cboLote);
        }
        private void cboLote_TextChanged(object sender, EventArgs e)
        {
            txbIdLote.Text = cls.CboValueDelSeleccionado(cboLote);
        }
        private void cboLote_MouseClick(object sender, MouseEventArgs e)
        {
            cls.CboPrimerClic(cboLote);
        }
        #endregion FIN LOTE

        #region PROVEEDOR
        private void btnTodoProveedor_Click(object sender, EventArgs e)
        {
            cls.BtnTodoMatProveedor(cboProveedor);
        }
        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            cls.BtnBuscarMatProveedor(cboProveedor);
        }
        #endregion FIN PROVEEDOR

        #region LINEA DE TRANSPORTE
        private void btnBuscarLineaTran_Click(object sender, EventArgs e)
        {
            cls.BtnBuscarMatLineaTransporte(cboLineaTran);
        }
        private void btnTodoLineaTran_Click(object sender, EventArgs e)
        {
            cls.BtnTodoMatLineaTransporte(cboLineaTran);
        }
        #endregion LINEA DE TRANSPORTE

        private void DgvMaterialesAñadir()
        {
            dgvMateriales.Rows.Add(txbId.Text, txbItem.Text, txbIdMaterial.Text, cboMaterial.Text, txbCantidad.Text, txbUnidad.Text, cboCampo.Text, txbIdLote.Text, cboLote.Text, txbFolio.Text, dtpFecha.Value.ToString("yyyy-MM-dd"), cboProveedor.Text, cboLineaTran.Text, txbChofer.Text, txbCaja.Text, txbPlacas.Text, txbObservaciones.Text);

            // Obtener el número de item siguiente
            txbItem.Text = cls.SiguienteItem(dgvMateriales);

            //vaciar campos nuevos
            cboTipoMat.Text = string.Empty;
            txbIdTipoMat.Text = string.Empty;
            cboMaterial.Text = string.Empty;
            txbIdMaterial.Text = string.Empty;
            txbUnidad.Text = string.Empty;
            txbCantidad.Text = string.Empty;
            txbObservaciones.Text = string.Empty;
            //dtpFecha.Enabled = false;
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            string vacios = "";
            foreach (Control control in Obligatorios)
            {
                if (control.Text == string.Empty)
                {
                    vacios = vacios + control.GetMensajeVacio() + "\r\n";
                    control.GetControlRelacionado().Focus();
                }
            }

            if (vacios != "")
            {
                MessageBox.Show("Debe ingresar:\n\n" + vacios, "Añadir material", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (añadirModificar)
                {
                    cls.BorrarFilaConItem(dgvMateriales, txbItem.Text);

                    DgvMaterialesAñadir();
                }
                else
                {
                    cls.BorrarFilaConItem(dgvMateriales, txbItem.Text);
                    DgvMaterialesAñadir();
                }
            }
        }

        private void btnEliminarSel_Click(object sender, EventArgs e)
        {
            if (dgvMateriales.SelectedRows.Count > 0)
                dgvMateriales.Rows.Remove(dgvMateriales.SelectedRows[0]);

            if (dgvMateriales.SelectedRows.Count == 0)
            {
                //dtpFecha.Enabled = true;
                txbItem.Text = "01";
            }
            //falta metodo para que se borre de base de datos con idViaje e idItem
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dgvMateriales.Rows.Count > 0)
            {
                if (añadirModificar)
                {
                    cls.CambiarValoresColumnaId(dgvMateriales, txbId.Text.Substring(0, 1));
                }
                else
                {
                    cls.EliminarRegistroMaterial(txbId.Text);
                }

                DataTable data = cls.ConvertirDataGridViewADataTable(dgvMateriales);
                try
                {
                    new LoadDataRegistroMaterial(this).DataLoad(data);

                    ActualizarCatalogoHijo();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar los datos: " + ex.ToString());
                }
            }
        }
        private void dgvMateriales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnModificarSel_Click(object sender, EventArgs e)
        {
            cls.BtnModificarSelRegistroMat(dgvMateriales, txbId, txbItem, dtpFecha, cboCampo, txbIdLote, cboLote, txbFolio, cboProveedor, cboLineaTran, txbChofer, txbCaja, txbPlacas, txbIdMaterial, cboMaterial, cboMaterial_TextChanged, txbCantidad, txbUnidad, txbObservaciones, txbIdTipoMat, cboTipoMat);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            //if (dgvMateriales.Rows.Count > 0)
            //{
            //    DateTimePicker dateTimePicker = (DateTimePicker)sender;
            //    DateTime nuevaFecha = dateTimePicker.Value;

            //    // Mostrar el MessageBox con botones "Sí" y "No"
            //    DialogResult result = MessageBox.Show("¿Desea cambiar la fecha?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //    // Verificar el resultado del MessageBox
            //    if (result == DialogResult.No)
            //    {
            //        // Restaurar la fecha anterior
            //        dateTimePicker.ValueChanged -= dtpFecha_ValueChanged;
            //        dateTimePicker.Value = fechaAnterior;
            //        dateTimePicker.ValueChanged += dtpFecha_ValueChanged;
            //    }
            //    else
            //    {
            //        // Actualizar el valor anterior
            //        fechaAnterior = nuevaFecha;
            //    }
            //}
        }

        private void dtpFecha_Leave(object sender, EventArgs e)
        {
            if (dgvMateriales.Rows.Count > 0)
            {
                DateTimePicker dateTimePicker = (DateTimePicker)sender;
                DateTime nuevaFecha = dateTimePicker.Value;

                if (nuevaFecha != fechaAnterior)
                {
                    // Mostrar el MessageBox con botones "Sí" y "No"
                    DialogResult result = MessageBox.Show("Se cambiará la fecha de todos los items del registro ¿Desea cambiar la fecha?", "Confirmación fecha", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // Verificar el resultado del MessageBox
                    if (result == DialogResult.No)
                    {
                        // Restaurar la fecha anterior
                        dateTimePicker.Value = fechaAnterior;
                    }
                    else
                    {
                        // Actualizar el valor anterior
                        fechaAnterior = nuevaFecha;
                        cls.CambiarValoresColumnaFecha(dgvMateriales, nuevaFecha.ToString("yyyy-MM-dd"));
                    }
                }
            }
        }


        private void dtpFecha_Enter(object sender, EventArgs e)
        {
            if (dgvMateriales.Rows.Count > 0)
            {
                DateTimePicker dateTimePicker = (DateTimePicker)sender;
                fechaAnterior = dateTimePicker.Value;
            }
        }
    }
}
