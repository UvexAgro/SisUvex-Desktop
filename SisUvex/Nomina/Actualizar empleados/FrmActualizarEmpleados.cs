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
            var procedimientos = new Dictionary<string, string>
            {
                { "sp_Nom_EmployeesSinc", "Empleados SA" },
                { "sp_Nom_PlacePayment", "Lugares de pago SA" },
                { "sp_Nom_EmployeesSincDL", "Empleados DL" },
                { "sp_Nom_DinerProviderAddDL", "Añadir comedores DL" },
                { "sp_Nom_DiningHallAddDL", "Añadir ventanillas DL" }
            };

            var resultados = procedimientos.ToDictionary(
                proc => proc.Value,
                proc => ClsQuerysDB.ExecuteQuery(proc.Key)
            );

            var exitosos = resultados.Where(r => r.Value).Select(r => r.Key).ToList();
            var fallidos = resultados.Where(r => !r.Value).Select(r => r.Key).ToList();

            var mensaje = new StringBuilder();
            if (exitosos.Any())
            {
                mensaje.AppendLine("Se han actualizado correctamente los siguientes procedimientos:");
                exitosos.ForEach(proc => mensaje.AppendLine(proc));
            }
            if (fallidos.Any())
            {
                mensaje.AppendLine("No se han actualizado correctamente los siguientes procedimientos:");
                fallidos.ForEach(proc => mensaje.AppendLine(proc));
            }

            MessageBox.Show(mensaje.ToString());
            if (!fallidos.Any())
            {
                this.Close();
            }
        }
    }
}