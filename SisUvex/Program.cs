
using SisUvex.Catalogos.Consignatario;
using SisUvex.Catalogos.GTIN;
using SisUvex.Archivo.Manifiesto;
using SisUvex.Catalogos.Material;
using SisUvex.Catalogos.PlanTrabajo;
using SisUvex.Catalogos.Productor;
using SisUvex.Consultas.Pallets;
using SisUvex.Inicio;
using SisUvex.Reports;
using SisUvex.Archivo.Etiquetas.CajaEmpleado;
using SisUvex.Configuracion;
using SisUvex.Archivo.Reestibado;
using SisUvex.Archivo.Mixteada;
using SisUvex.Archivo.Desestibar;
using SisUvex.Archivo.Etiquetas.NombreYCodigo2x1;
using SisUvex.Nomina.Actualizar_empleados;
using SisUvex.Nomina.Actualizar_datos_empelado;
using SisUvex.Operacion;
using SisUvex.Catalogos.Categor�a;
using SisUvex.Catalogos.Presentacion;
using SisUvex.Catalogos.PlantillaV1;
using SisUvex.Nomina.Prices.PricesGtin;

namespace SisUvex
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new PantallaCarga());
            //Application.Run(new FrmMenu());
        }
    }
}