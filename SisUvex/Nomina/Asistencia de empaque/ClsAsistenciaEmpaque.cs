using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using SisUvex.Catalogos;

namespace SisUvex.Nomina.Asistencia_de_empaque
{
    internal class ClsAsistenciaEmpaque : ClsCatalogos
    {
        public FrmAsistenciaEmpaque frmAsistenciaEmpaque;
        public FrmAsistenciaEmpaqueNuevo frmNuevo;
        public FrmAsistenciaEmpaqueVista frmVista;
        public FrmAsistenciaEmpaqueEmpleado frmEmpleado;
        public FrmMenu frmMenu;

        public ClsAsistenciaEmpaque()
        {
            frmAsistenciaEmpaque = new FrmAsistenciaEmpaque();
        }

        public void AbrirFrmAsistenciaEmpaque()
        {
            frmMenu.AbrirFormularioDialog(frmAsistenciaEmpaque,3);

            switch (frmAsistenciaEmpaque.abrir)
            {
                case "Nuevo":
                    frmNuevo = new FrmAsistenciaEmpaqueNuevo();
                    frmMenu.AbrirVentanaHijo(frmNuevo, 1); break;
                case "Día":
                    frmVista = new FrmAsistenciaEmpaqueVista();
                    frmVista.dtpDia.Value = frmAsistenciaEmpaque.dtpDia.Value;
                    frmMenu.AbrirVentanaHijo(frmVista, 1);
                    break;
                case "Empleado":
                    frmEmpleado = new FrmAsistenciaEmpaqueEmpleado();
                    frmEmpleado.txbIdEmpleado.Text = frmAsistenciaEmpaque.txbEmpleado.Text;
                    frmMenu.AbrirVentanaHijo(frmEmpleado, 1);
                    break;
                default:
                    frmAsistenciaEmpaque.Close();
                    break;
            }
        }
    }
}
