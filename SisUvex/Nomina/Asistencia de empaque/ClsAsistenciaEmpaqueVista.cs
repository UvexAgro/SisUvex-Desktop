using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisUvex.Catalogos;
using SisUvex.Catalogos.Metods.Querys;

namespace SisUvex.Nomina.Asistencia_de_empaque
{
    internal class ClsAsistenciaEmpaqueVista : ClsCatalogos
    {
        public FrmAsistenciaEmpaqueVista frm;
        string query = "SELECT CONVERT(DATE, d_attendence) Fecha, lst.id_employee 'Empleado', emp.v_lastNamePat 'Apellido paterno', emp.v_lastNameMat 'Apellido materno', emp.v_name 'Nombre', lst.c_codigo_tab 'Actividad', tab.v_descripcion_tab 'Descripción actividad' FROM Nom_AttendenceList lst JOIN Nom_Employees emp ON emp.id_employee = lst.id_employee JOIN Nom_Tabulador tab ON tab.c_codigo_tab = lst.c_codigo_tab";
        string queryOrder = "ORDER BY emp.v_lastNamePat, emp.v_lastNameMat, emp.v_name";
        public ClsAsistenciaEmpaqueVista(FrmAsistenciaEmpaqueVista frmAsistenciaEmpaqueVista)
        {
            this.frm = frmAsistenciaEmpaqueVista;
        }

        public DataTable ObtenerAsistenciaEmpaqueDia()
        {
            string fecha = frm.dtpDia.Value.ToString("yyyy-MM-dd");

            string queryFinal = $"{query} WHERE lst.d_attendence = '{fecha}' {queryOrder}";
            return ClsQuerysDB.GetDataTable(queryFinal);
        }
    }
}
