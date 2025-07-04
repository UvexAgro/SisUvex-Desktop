
using SisUvex.Catalogos.Consignatario;
using SisUvex.Catalogos.GTIN;
using SisUvex.Archivo.Manifiesto;
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
using SisUvex.Catalogos.Categoría;
using SisUvex.Catalogos.Presentacion;
using SisUvex.Nomina.Prices.PricesGtin;
using SisUvex.Nomina.EmployeeCredentials;
using SisUvex.Grow.PlantsRowLot;
using SisUvex.Grow.PlantsRowLotLoadExcel;
using SisUvex.Nomina.Comedores.DiningReports;
using SisUvex.Archivo.Manifiesto.ConfManifest;
using SisUvex.Catalogos.Lot;
using SisUvex.Archivo.Manifiesto.ManifestTemplates;
using SisUvex.Nomina.Padron.SUA;
using SisUvex.Material.MaterialRegister;
using SisUvex.Material.MaterialRegister.Entry;
using SisUvex.Material.MaterialProvider;
using SisUvex.Material.MaterialWarehouses;
using SisUvex.Material.MaterialCatalog;
using SisUvex.Material.MaterialType;
using SisUvex.Material.MaterialRegister.Exit;
using System.Xml.XPath;
using SisUvex.Assets.Vehicle.Vehicle;
using SisUvex.Archivo.Etiquetas.PrintLabels;
using SisUvex.Archivo.Etiquetas;

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