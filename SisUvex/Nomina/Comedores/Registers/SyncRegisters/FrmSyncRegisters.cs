using SisUvex.Catalogos.Metods.Querys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Nomina.Comedores.Registers.SyncRegisters
{
    public partial class FrmSyncRegisters : Form
    {
        public FrmSyncRegisters()
        {
            InitializeComponent();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var procedimientos = new Dictionary<string, string>
            {
                { "sp_Nom_FoodRegister", "Sincroniza registros comedor DL-SA" }
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

        private void FrmSyncRegisters_Load(object sender, EventArgs e)
        {

        }
    }
}
