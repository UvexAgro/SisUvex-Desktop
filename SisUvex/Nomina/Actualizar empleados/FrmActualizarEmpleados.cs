using SisUvex.Catalogos.Metods.Querys;
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

namespace SisUvex.Nomina.Actualizar_empleados
{
    public partial class FrmActualizarEmpleados : Form
    {
        public FrmActualizarEmpleados()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ClsQuerysDB.ExecuteQuery("sp_Nom_EmployeesSinc"))
                if (ClsQuerysDB.ExecuteQuery("sp_Nom_PlacePayment"))
                {
                    MessageBox.Show("Se han actualizado los datos de los empleados exitosamente.");
                    this.Close();
                    return;
                }

            MessageBox.Show("Error al actualizar los datos de los empleados.");
        }
    }
}