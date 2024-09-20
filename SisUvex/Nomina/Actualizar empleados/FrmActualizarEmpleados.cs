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
            SQLControl sql = new SQLControl();

                try
                {
                    sql.OpenConectionWrite();
                    SqlCommand cmd = new SqlCommand("sp_SincEmployees", sql.cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Se ha actualizado la tabla de empleados.", "Actualizar Empleados");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Actualizar empleados");
                }

                finally
                {
                    sql.CloseConectionWrite();
                }
            
        }
    }
}

