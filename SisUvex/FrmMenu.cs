using SisUvex.Archivo.Desestibar;
using SisUvex.Archivo.Etiquetas.CajaEmpleado;
using SisUvex.Archivo.Etiquetas.FrmNombreYCodigo2x1;
using SisUvex.Archivo.Etiquetas.PrintLabels;
using SisUvex.Archivo.Manifiesto;
using SisUvex.Archivo.Mixteada;
using SisUvex.Archivo.Reestibado;
using SisUvex.Archivo.Reimprimir;
using SisUvex.Archivo.WorkPlan;
using SisUvex.Archivo.WorkPlan.ConvertPallet;
using SisUvex.Assets.Vehicle.Vehicle;
using SisUvex.Assets.Vehicle.VehicleType;
using SisUvex.Catalogos.Consignatario;
using SisUvex.Catalogos.Productor;
using SisUvex.Catalogos.RegistroMaterial;
using SisUvex.Configuracion;
using SisUvex.Consultas.Manifest;
using SisUvex.Consultas.Manifest.QueryPerManifest;
using SisUvex.Consultas.Pallets;
using SisUvex.DesertGhost;
using SisUvex.Material.MaterialCatalog;
using SisUvex.Material.MaterialForeignDest;
using SisUvex.Material.MaterialProvider;
using SisUvex.Material.MaterialRegister.Entry;
using SisUvex.Material.MaterialRegister.Exit;
using SisUvex.Material.MaterialRegister.FieldExit;
using SisUvex.Material.MaterialType;
using SisUvex.Material.MaterialWarehouses;
using SisUvex.Nomina;
using SisUvex.Nomina.Actualizar_datos_empelado;
using SisUvex.Nomina.Actualizar_empleados;
using SisUvex.Nomina.Comedores.DiningHall;
using SisUvex.Nomina.Comedores.DiningReports;
using SisUvex.Nomina.Comedores.DiningReports.AbsenceReport;
using SisUvex.Nomina.Comedores.EmployeeDiningHallAssignment;
using SisUvex.Nomina.Comedores.Registers.SyncRegisters;
using SisUvex.Nomina.EmployeeCredentials;
using SisUvex.Nomina.Padron.SUA;
using SisUvex.Nomina.Prices.Prices;
using SisUvex.Nomina.Registration.NewEmployeeRegistrationSA;
using SisUvex.Nomina.Work_time;
using SisUvex.Operacion;
using SisUvex.Packing.Maintenance;
using SisUvex.Reports;

namespace SisUvex
{
    public partial class FrmMenu : Form
    {
        public static FrmMenu FrmMenuInstance;

        public FrmMenu()
        {
            InitializeComponent();
            FrmMenuInstance = this;
        }

        public void AbrirVentanaHijo(Form f, int acs) //PARA CUANDO ES CON EL NIVEL DE ACCESO
        {
            if (User.GetAccessLevel() >= acs)
            {
                AbrirVentanaHijo(f);
            }
        }

        public void AbrirVentanaHijo(Form f) //PARA CUANDO NO ES CON EL NIVEL DE ACCESO, SINO POR LOS PERMISOS
        {
            bool va = false;

            foreach (Form ven in MdiChildren)
            {
                if (ven.Name.Equals(f.Name))
                {
                    ven.Focus();
                    va = true;
                }
            }

            if (!va)
            {
                f.MdiParent = this;
                f.Show();
            }
        }

        private void AbrirFormulario(Form f, int acs)
        {
            if (User.GetAccessLevel() >= acs)
            {
                bool va = false;

                foreach (Form ven in Application.OpenForms)
                {
                    if (ven.Name.Equals(f.Name))
                    {
                        ven.Focus();
                        va = true;
                        break;
                    }
                }

                if (!va)
                {
                    f.Show();
                }
            }
        }

        public void AbrirFormularioDialog(Form f, int acs)
        {
            if (User.GetAccessLevel() >= acs)
            {
                bool va = false;

                foreach (Form ven in Application.OpenForms)
                {
                    if (ven.Name.Equals(f.Name))
                    {
                        ven.Focus();
                        va = true;
                        break;
                    }
                }

                if (!va)
                {
                    f.ShowDialog();
                }
            }
        }

        private void productorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProductorCat cat = new FrmProductorCat();
            AbrirVentanaHijo(cat, 1);
        }

        private void distribuidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.Distributor.FrmDistributorCat cat = new();
            AbrirVentanaHijo(cat, 1);
        }

        private void etiquetaPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintPalletBox cat = new PrintPalletBox();
            AbrirVentanaHijo(cat, 1);
        }

        private void registroDeMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistroMaterialCat cat = new FrmRegistroMaterialCat();
            AbrirVentanaHijo(cat, 1);
        }

        private void impresoraPalletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSetupPrint cat = new FrmSetupPrint();
            AbrirVentanaHijo(cat, 1);
        }

        private void planDeTrabajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmWorkPlanCat cat = new();
            AbrirVentanaHijo(cat, 1);
        }

        private void FrmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void palletsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPalletConsulta cat = new FrmPalletConsulta();
            AbrirVentanaHijo(cat, 3);
        }

        private void manifiestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManifestCat cat = new();
            AbrirVentanaHijo(cat, 3);
        }

        private void reestibarPalletsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReestibado cat = new FrmReestibado();
            AbrirFormulario(cat, 3);
        }

        private void mixtearPalletsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMixteado cat = new FrmMixteado();
            AbrirFormulario(cat, 3);
        }

        private void desestibarPalletsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDesestibar cat = new FrmDesestibar();
            AbrirFormulario(cat, 3);
        }

        private void reimprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRePrintPallet cat = new FrmRePrintPallet();
            AbrirVentanaHijo(cat, 1);
        }

        private void nombreYCódigo2x1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNombreYCodigo2x1 cat = new FrmNombreYCodigo2x1();
            AbrirFormulario(cat, 0);
        }

        private void actualizarEmpleadosSisUvexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmActualizarEmpleados cat = new FrmActualizarEmpleados();
            AbrirFormularioDialog(cat, 0);
        }

        private void actualizarDatosDeEmpleadosPorExcelAgrosmartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmActualizarDatosEmpleados cat = new FrmActualizarDatosEmpleados();
            AbrirVentanaHijo(cat, 4);
        }

        private void cajasAGranelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCajasGranelRegistroCat cat = new();
            AbrirVentanaHijo(cat, 1);
        }

        private void conexiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConfiguracion cat = new FrmConfiguracion();
            cat.isFrmLoginScreen = false;
            AbrirFormularioDialog(cat, 4);
        }

        private void consigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsignatarioCat cat = new FrmConsignatarioCat();
            AbrirVentanaHijo(cat, 1);
        }

        private void cajaPalletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPrintLabelsPtiPallets frm = new();
            AbrirVentanaHijo(frm, 1);
        }

        private void cargarEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddEmployees cat = new FrmAddEmployees();
            AbrirVentanaHijo(cat, 1);
        }

        private void códigoParaCajaÚnicaEspárragoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCajaEmpleado cat = new FrmCajaEmpleado();
            AbrirFormulario(cat, 1);
        }

        private void uvaNombreYCódigoDeEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNombreYCodigo2x1 cat = new FrmNombreYCodigo2x1();
            AbrirFormulario(cat, 1);
        }

        private void CajasPorEmlpeadosYHorariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsWorkTime cls = new ClsWorkTime();
            AbrirVentanaHijo(cls._frmCat, 1);
        }

        private void preciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsPrices cls = new ClsPrices();
            AbrirVentanaHijo(cls._frmCat, 1);
        }

        private void totalDeCajasEmbarcadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManifestQuery cat = new FrmManifestQuery();
            AbrirVentanaHijo(cat, 1);
        }

        private void totalesPorManifiestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmQueryPerManifest cat = new FrmQueryPerManifest();
            AbrirVentanaHijo(cat, 1);
        }

        private void convertirPalletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsConvertPallet cls = new ClsConvertPallet();
            AbrirFormulario(cls.frm, 2);
        }

        private void preciosPorGTINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SisUvex.Nomina.Prices.PricesGtin.FrmPricesGtinCat cat = new();
            AbrirVentanaHijo(cat, 1);
        }

        private void áreaComedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void asignarComedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UExcel cat = new UExcel();
            AbrirVentanaHijo(cat, 2);
        }

        private void reportesComedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmDiningReport frm = new FrmDiningReport();
            AbrirVentanaHijo(frm, 2);
        }

        private void credencialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCredentials cat = new FrmCredentials();
            AbrirVentanaHijo(cat, 1);
        }

        private void catálogoVentanillasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsDiningHall cls = new ClsDiningHall();
            AbrirVentanaHijo(cls._frmCat, 1);
        }

        private void sincronizarRegistrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSyncRegisters cat = new FrmSyncRegisters();
            AbrirFormularioDialog(cat, 1);
        }

        private void asistenciaEmpaqueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Nomina.Registro_de_Asistencia.FrmRegistroA cat = new();
            cat.WindowState = FormWindowState.Maximized;
            AbrirVentanaHijo(cat, 3);
        }

        private void altaDeEmpleadosSinRegistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNewEmployeeRegistrationMin cat = new FrmNewEmployeeRegistrationMin();
            AbrirVentanaHijo(cat, 3);
        }

        private void relaciónEmpleadoscomedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEmployeeDiningHallAsingment cat = new FrmEmployeeDiningHallAsingment();
            AbrirVentanaHijo(cat, 3);
        }

        private void sUAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSUALoad cat = new FrmSUALoad();
            AbrirVentanaHijo(cat, 3);
        }

        private void reporteAucensiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAbsenceReport cat = new FrmAbsenceReport();
            AbrirVentanaHijo(cat, 3);
        }

        private void mantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPackingMaintenance cat = new FrmPackingMaintenance();
            AbrirFormularioDialog(cat, 1);
        }

        private void entradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMaterialRegisterEntryCat cat = new();
            AbrirVentanaHijo(cat, 3);
        }

        private void tipoDeMaterialToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmMaterialTypeCat cat = new();
            AbrirVentanaHijo(cat, 3);
        }

        private void catálogoMaterialToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmMaterialCatalog cat = new();
            AbrirVentanaHijo(cat, 3);
        }

        private void almacenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMaterialWareHousesCat cat = new();
            AbrirVentanaHijo(cat, 3);
        }

        private void proovedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmMaterialProviderCat cat = new();
            AbrirVentanaHijo(cat, 3);
        }

        private void destinosExternosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMaterialForeignDestCat cat = new();
            AbrirVentanaHijo(cat, 3);
        }

        private void salidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMaterialRegisterExitCat cat = new();
            AbrirVentanaHijo(cat, 3);
        }

        private void tipoDeVehículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVehicleTypeCat cat = new();
            AbrirVentanaHijo(cat, 1);
        }

        private void salidasInternasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMaterialRegisterFieldExitCat cat = new();
            AbrirVentanaHijo(cat, 3);
        }

        private void vehículosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmVehicleCat cat = new();
            AbrirVentanaHijo(cat, 1);
        }

        private void generarReporteDePodaEnExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nomina.Poda.Reporte_lineas.FrmPayrollPruningReport cat = new();
            AbrirFormularioDialog(cat, 3);
        }

        private void parámetrosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Configuracion.Parameters.FrmParametersCat cat = new();
            cat.WindowState = FormWindowState.Maximized;
            AbrirVentanaHijo(cat, 4);
        }

        private void nominaEmpaqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void calculToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nomina.Nom_semAutomatizada.FrmSemiAutomatedPayroll cat = new();
            cat.WindowState = FormWindowState.Maximized;
            AbrirVentanaHijo(cat, 3);
        }

        private void salarioDiversosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nomina.Ingresos_Diversos.FrmListaAsitencia cat = new(this);
            cat.WindowState = FormWindowState.Maximized;
            AbrirVentanaHijo(cat, 3);
        }

        private void ingresosDiversosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nomina.Conceptos_Ingresos_Diversos.FrmIncomeConcepts cat = new();
            cat.WindowState = FormWindowState.Maximized;
            AbrirVentanaHijo(cat, 3);
        }

        private void plantasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Grow.PlantsRowLot.FrmPlantsRowLotView cat = new();
            cat.WindowState = FormWindowState.Maximized;
            AbrirVentanaHijo(cat, 1);
        }

        private void reporteDeAsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nomina.Asistencia_contrato.Consulta.FrmPayrollAttendance cat = new();
            cat.WindowState = FormWindowState.Maximized;
            AbrirVentanaHijo(cat, 3);
        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nomina.Poda.Reporte_lineas.FrmPayrollPruningReport cat = new();
            AbrirFormularioDialog(cat, 3);
        }

        private void reporteDeEmpacadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nomina.Reporte_de_Empacador.FrmPackersReport cat = new();
            cat.WindowState = FormWindowState.Maximized;
            AbrirVentanaHijo(cat, 3);
        }

        private void factorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Operacion_Factor.FrmFactor cat = new();
            cat.WindowState = FormWindowState.Maximized;
            AbrirVentanaHijo(cat, 3);
        }

        private void reporteDeHorariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nomina.Reporte_de_horas.FrmPackingHours cat = new();
            cat.WindowState = FormWindowState.Maximized;
            AbrirVentanaHijo(cat, 3);
        }

        private void reporteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Nomina.Nom_Reporte_de_sueldos_diarios.FrmNomsemana cat = new();
            cat.WindowState = FormWindowState.Maximized;
            AbrirVentanaHijo(cat, 3);
        }

        private void fechasFestivasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.FechasFestivas.FrmCatFestivo cat = new();
            cat.WindowState = FormWindowState.Maximized;
            AbrirVentanaHijo(cat, 3);
        }

        private void cajasPorEmpleadoYHorariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsWorkTime cls = new ClsWorkTime();
            AbrirVentanaHijo(cls._frmCat, 1);
        }

        private void reporteDeHorariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Nomina.Reporte_de_horas.FrmPackingHours cat = new();
            cat.WindowState = FormWindowState.Maximized;
            AbrirVentanaHijo(cat, 3);
        }

        private void reporteDeAsistenciaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Nomina.Reporte_de_Asistencia.FrmAsistenciaR cat = new();
            cat.WindowState = FormWindowState.Maximized;
            AbrirVentanaHijo(cat, 3);
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!User.HasSysAdminPermission())
                return;

            Usuarios.UserCrud.FrmUserCat cat = new();
            AbrirVentanaHijo(cat);
        }

        private void rolesDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!User.HasSysAdminPermission())
                return;

            Usuarios.Role.FrmUserRoleCat cat = new();
            AbrirVentanaHijo(cat);
        }

        private void cambiarTuContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Usuarios.UserCrud.FrmUserConfirmPass.OpenValidateUserPassword())
                return;

            Usuarios.UserCrud.ClsUserCrud.OpenFrmChangePassword(User.GetUserName());
        }

        private void lugarDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!User.HasViewCatalogsPermission())
                return;

            Nomina.PlacePaymentLP.FrmPlacePaymentCat cat = new();
            cat.WindowState = FormWindowState.Maximized;
            AbrirVentanaHijo(cat);
        }

        private void descuentoDePrsonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nomina.Nom_Descuento_de_personal.FrmDescuento cat = new();
            cat.WindowState = FormWindowState.Maximized;
            AbrirVentanaHijo(cat, 3);
        }

        private void tabuladorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!User.HasViewCatalogsPermission())
                return;

            Nomina.NomTabulador.FrmNomTabulador cat = new();
            cat.WindowState = FormWindowState.Maximized;
            AbrirVentanaHijo(cat);
        }

        private void dedudccionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!User.HasViewCatalogsPermission())
                return;

            Catalogos.Nom_Deducciones.FrmDeduccion cat = new();
            cat.WindowState = FormWindowState.Maximized;
            AbrirVentanaHijo(cat);
        }

        private void líneaDeTransporteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Catalogos.TransportLine.FrmTransportLineCat cat = new();
            AbrirVentanaHijo(cat, 1);
        }

        private void choferToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Catalogos.Driver.FrmDriverCat cat = new();
            AbrirVentanaHijo(cat, 1);
        }

        private void troqueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Catalogos.Truck.FrmTruckCat cat = new();
            AbrirVentanaHijo(cat, 1);
        }

        private void cajaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Catalogos.FreightContainer.FrmFreightContainerCat cat = new();
            AbrirVentanaHijo(cat, 1);
        }

        private void agenciaAduanalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Catalogos.AgenciaAduanal.FrmAgenciaAduanalCat cat = new();
            AbrirVentanaHijo(cat, 1);
        }

        private void ciudadDestinocruceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.Ciudad.FrmCiudadCat cat = new();
            AbrirVentanaHijo(cat, 1);
        }

        private void variedadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.Variedad.FrmVariedadCat cat = new();
            AbrirVentanaHijo(cat, 1);
        }

        private void loteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.Lot.FrmLotCat cat = new();
            AbrirVentanaHijo(cat, 1);
        }

        private void tamañoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Catalogos.Tamaño.FrmTamañoCat cat = new();
            AbrirVentanaHijo(cat, 1);
        }

        private void categoríaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Catalogos.Categoría.FrmCategoriaCat cat = new();
            AbrirVentanaHijo(cat, 1);
        }

        private void presentaciónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Catalogos.Presentacion.ClsPresentation cls = new();
            AbrirVentanaHijo(cls._frmCat, 1);
        }

        private void contenedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Catalogos.Container.ClsContainer cls = new();
            AbrirVentanaHijo(cls._frmCat, 1);
        }

        private void gTINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.GTIN.ClsGTIN cls = new();
            AbrirVentanaHijo(cls._frmCat, 1);
        }

        private void contratistaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Catalogos.Contratista.FrmContratistaCat cat = new();
            AbrirVentanaHijo(cat, 1);
        }

        private void cuadrillaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Catalogos.WorkGroup.FrmWorkGroupCat cat = new();
            AbrirVentanaHijo(cat, 1);
        }

        private void relaciónDeEmpaquePorColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!User.HasViewCatalogsPermission())
                return;

            Facility.FaciIityPackagingTracking.Catalog.FrmFaciIityPackagingTrackingCat cat = new();
            AbrirVentanaHijo(cat);
        }

        private void zPLPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cuadro_de_herramientas.ZPL.FrmZPLPreview cat = new();
            //cat.Show();
            AbrirVentanaHijo(cat, 0);
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            zPLPreviewToolStripMenuItem.Visible = User.HasSysAdminPermission();
        }
    }
}