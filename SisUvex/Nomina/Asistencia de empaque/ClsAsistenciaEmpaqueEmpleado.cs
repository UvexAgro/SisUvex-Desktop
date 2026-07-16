using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SisUvex.Catalogos;
using DocumentFormat.OpenXml.Wordprocessing;
using SisUvex.Catalogos.Metods.Querys;

namespace SisUvex.Nomina.Asistencia_de_empaque
{
    internal class ClsAsistenciaEmpaqueEmpleado : ClsCatalogos
    {
        FrmAsistenciaEmpaqueEmpleado frm;
        string query = "SELECT FORMAT(lst.d_attendence,'yyyy-MM-dd, dddd', 'es-es') Fecha, lst.c_codigo_tab 'Actividad', tab.v_descripcion_tab 'Descripción actividad' FROM Nom_AttendenceList lst JOIN Nom_Employees emp ON emp.id_employee = lst.id_employee JOIN Nom_Tabulador tab ON tab.c_codigo_tab = lst.c_codigo_tab";
        string queryOrder = "ORDER BY lst.d_attendence";

        public ClsAsistenciaEmpaqueEmpleado(FrmAsistenciaEmpaqueEmpleado frmEmpleado)
        {
            this.frm = frmEmpleado;
        }

        public void ObtenerAsistenciaEmpaqueEmpleado()
        {
            string empleado = FormatoCeros(frm.txbIdEmpleado.Text,"000000");
            
            if (empleado != "000000")
            {
                string queryFinal = $"{query} WHERE lst.id_employee = '{empleado}' {queryOrder}";

                frm.dgvLista.DataSource = ClsQuerysDB.GetDataTable(queryFinal);
            }
        }

        public string ObtenerNombreEmpleadoTxb()
        {
            string empleado = FormatoCeros(frm.txbIdEmpleado.Text,"000000");

            string nombreEmpleado = string.Empty;

            if (empleado != "000000")
            {
                string queryNombre = $"SELECT CONCAT(v_lastNamePat,' ',v_lastNameMat,' ',v_name) Nombre FROM Nom_Employees WHERE id_employee = '{empleado}'";

                nombreEmpleado = ObtenerDatoConsulta(queryNombre);
            }

            return nombreEmpleado;
        }

        public void CargarDatosAsistenciaEmpleado()
        {

            string nombreEmpleado = ObtenerNombreEmpleadoTxb();

            if (nombreEmpleado.Equals(string.Empty))
            {
                MessageBox.Show("El emplaedo no se ha encontrado.");
            }
            else
            {
                frm.txbNombreEmpleado.Text = nombreEmpleado;

                ObtenerAsistenciaEmpaqueEmpleado();
            }
        }
    }
}