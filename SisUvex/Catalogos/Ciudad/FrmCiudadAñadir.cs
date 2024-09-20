using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SisUvex.Catalogos.Ciudad
{
    public partial class FrmCiudadAñadir : Form
    {
        public bool añadirModificar = true; //Verdadero para nuevo, falso para modificar
        ClsCiudad cls = new ClsCiudad();
        public FrmCiudadAñadir(FrmCiudadCat catalogo)
        {
            InitializeComponent();
        }

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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txbNomCiudad.Text == string.Empty)
            {
                txbNomCiudad.Focus();
                MessageBox.Show("Debe ingresar el nombre del ciudad.");
            }
            else
            {
                if (añadirModificar)
                    cls.AñadirCiudad(txbNomCiudad.Text, txbNomEstado.Text, txbNomPais.Text, cboActivo.SelectedIndex.ToString());
                else
                    cls.ModificarCiudad(txbId.Text, cboActivo.SelectedIndex.ToString(), txbNomCiudad.Text, txbNomEstado.Text, txbNomPais.Text);

                cls.LimpiarTextBox(this);
                ActualizarCatalogoHijo();
                this.Close();
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cls.LimpiarTextBox(this);
            this.Close();
        }

        private void FrmCiudadAñadir_Load(object sender, EventArgs e)
        {

        }

        private void FrmCiudadAñadir_FormClosing(object sender, FormClosingEventArgs e)
        {
            cls.LimpiarTextBox(this);
        }
    }
}
