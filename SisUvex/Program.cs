
using SisUvex.Archivo.Desestibar;
using SisUvex.Archivo.Etiquetas;
using SisUvex.Archivo.Etiquetas.CajaEmpleado;
using SisUvex.Archivo.Etiquetas.NombreYCodigo2x1;
using SisUvex.Archivo.Etiquetas.PrintLabels;
using SisUvex.Archivo.Manifiesto;
using SisUvex.Archivo.Manifiesto.ConfManifest;
using SisUvex.Archivo.Manifiesto.ManifestTemplates;
using SisUvex.Archivo.Mixteada;
using SisUvex.Archivo.Reestibado;
using SisUvex.Assets.Vehicle.Vehicle;
using SisUvex.Catalogos.Categoría;
using SisUvex.Catalogos.Consignatario;
using SisUvex.Catalogos.GTIN;
using SisUvex.Catalogos.Lot;
using SisUvex.Catalogos.PlanTrabajo;
using SisUvex.Catalogos.Presentacion;
using SisUvex.Catalogos.Productor;
using SisUvex.Configuracion;
using SisUvex.Consultas.Pallets;
using SisUvex.Grow.PlantsRowLot;
using SisUvex.Grow.PlantsRowLotLoadExcel;
using SisUvex.Inicio;
using SisUvex.Material.MaterialCatalog;
using SisUvex.Material.MaterialProvider;
using SisUvex.Material.MaterialRegister;
using SisUvex.Material.MaterialRegister.Entry;
using SisUvex.Material.MaterialRegister.Exit;
using SisUvex.Material.MaterialType;
using SisUvex.Material.MaterialWarehouses;
using SisUvex.Nomina.Actualizar_datos_empelado;
using SisUvex.Nomina.Actualizar_empleados;
using SisUvex.Nomina.Comedores.DiningReports;
using SisUvex.Nomina.EmployeeCredentials;
using SisUvex.Nomina.Padron.SUA;
using SisUvex.Nomina.Poda.Reporte_lineas;
using SisUvex.Nomina.Prices.PricesGtin;
using SisUvex.Operacion;
using SisUvex.Reports;
using System.Xml.XPath;

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
            //Application.Run(new FrmManifestCat());
            Application.Run(new PantallaCarga());

        }
    }
}