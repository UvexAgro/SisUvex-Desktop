using SisUvex.Usuarios;
using SisUvex.Catalogos.Variedad;
using SisUvex.Catalogos.Tamaño;
using SisUvex.Catalogos.Ciudad;
using SisUvex.Catalogos.Productor;
using SisUvex.Catalogos.LineaTransporte;
using SisUvex.Catalogos.AgenciaAduanal;
using SisUvex.Catalogos.TipoMaterial;
using SisUvex.Catalogos.Contratista;
using SisUvex.Catalogos.Material;
using SisUvex.Catalogos.Distribuidor;
using SisUvex.Catalogos.Lote;
using SisUvex.Catalogos.Chofer;
using SisUvex.Nomina;
using SisUvex.Catalogos.Caja;
using SisUvex.Catalogos.Troque;
using SisUvex.Catalogos.Consignatario;
using SisUvex.Reports;
using SisUvex.Catalogos.RegistroMaterial;
using SisUvex.Archivo.Impresoras;
using SisUvex.Catalogos.GTIN;
using SisUvex.Configuracion;
using SisUvex.Consultas.Pallets;
using SisUvex.Archivo.Etiquetas.CajaEmpleado;
using SisUvex.Archivo.Manifiesto;
using SisUvex.Archivo.Reestibado;
using SisUvex.Archivo.Mixteada;
using SisUvex.Archivo.Desestibar;
using SisUvex.Archivo.Reimprimir;
using SisUvex.Archivo.Etiquetas.FrmNombreYCodigo2x1;
using SisUvex.Nomina.Actualizar_empleados;
using SisUvex.Nomina.Actualizar_datos_empelado;
using SisUvex.Operacion;
using SisUvex.Nomina.Asistencia_de_empaque;
using SisUvex.Catalogos.Container;
using SisUvex.Catalogos.Presentacion;
using SisUvex.Archivo.WorkPlan;
using SisUvex.Archivo.Etiquetas.PrintLabels;
using SisUvex.DesertGhost;
using SisUvex.Catalogos.Categoría;
using SisUvex.Nomina.Work_time;
using SisUvex.Nomina.Prices.Prices;
using SisUvex.Consultas.Manifest;
using SisUvex.Consultas.Manifest.QueryPerManifest;
using SisUvex.Archivo.WorkPlan.ConvertPallet;
using SisUvex.Nomina.Prices.PricesGtin;
using SisUvex.Nomina.EmployeeCredentials;
using SisUvex.Nomina.Comedores.DiningHall;
using SisUvex.Nomina.Comedores.DiningReports;
using SisUvex.Nomina.Comedores.Registers.SyncRegisters;
using SisUvex.Catalogos.WorkGroup;
using SisUvex.Nomina.Registration.NewEmployeeRegistrationSA;
using SisUvex.Nomina.Comedores.EmployeeDiningHallAssignment;
using SisUvex.Catalogos.Lot;
using SisUvex.Nomina.Comedores.DiningReports.AbsenceReport;
using SisUvex.Nomina.Padron.SUA;

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
        public void AbrirVentanaHijo(Form f, int acs)
        {
            if (User.GetAccessLevel() >= acs)
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
        }
        private void nuevoUsuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreacionUsuario cat = new CreacionUsuario();
            AbrirVentanaHijo(cat, 4);
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {

        }

        private void variedadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVariedadCat cat = new FrmVariedadCat();
            AbrirVentanaHijo(cat, 1);
        }

        private void tamañoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTamañoCat cat = new FrmTamañoCat();
            AbrirVentanaHijo(cat, 1);
        }

        private void ciudadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCiudadCat cat = new FrmCiudadCat();
            AbrirVentanaHijo(cat, 1);
        }

        private void productorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProductorCat cat = new FrmProductorCat();
            AbrirVentanaHijo(cat, 1);
        }

        private void líneaDeTransporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLineaTransporteCat cat = new FrmLineaTransporteCat();
            AbrirVentanaHijo(cat, 1);
        }

        private void agenciaAduanalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAgenciaAduanalCat cat = new FrmAgenciaAduanalCat();
            AbrirVentanaHijo(cat, 1);
        }

        private void tipoDeMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTipoMaterialCat cat = new FrmTipoMaterialCat();
            AbrirVentanaHijo(cat, 1);
        }

        private void contratistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmContratistaCat cat = new FrmContratistaCat();
            AbrirVentanaHijo(cat, 1);
        }

        private void materialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMaterialCat cat = new FrmMaterialCat();
            AbrirVentanaHijo(cat, 1);
        }

        private void distribuidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDistribuidorCat cat = new FrmDistribuidorCat();
            AbrirVentanaHijo(cat, 1);
        }

        private void lotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLotCat cat = new FrmLotCat();
            AbrirVentanaHijo(cat, 1);
        }

        private void cuadrillaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmCuadrillaCat cat = new FrmCuadrillaCat();
            //AbrirVentanaHijo(cat, 1);
            FrmWorkGroupCat cat = new FrmWorkGroupCat();
            AbrirVentanaHijo(cat, 1);
        }

        private void gTINUPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsGTIN cls = new ClsGTIN();
            AbrirVentanaHijo(cls._frmCat, 1);
        }

        private void choferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChoferCat cat = new FrmChoferCat();
            AbrirVentanaHijo(cat, 1);
        }
        private void cajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCajaCat cat = new FrmCajaCat();
            AbrirVentanaHijo(cat, 1);
        }

        private void troqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTroqueCat cat = new FrmTroqueCat();
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

        private void configurarImpresorasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSelectPrinter cat = new FrmSelectPrinter();

            AbrirVentanaHijo(cat, 1);
        }

        private void reportesComedorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
        }

        private void impresoraPalletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSetupPrint cat = new FrmSetupPrint();
            AbrirVentanaHijo(cat, 1);
        }

        private void planDeTrabajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsWorkPlan cls = new ClsWorkPlan();
            AbrirVentanaHijo(cls._frmCat, 1);
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

        private void cajasAGranelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCajasGranelRegistro cls = new ClsCajasGranelRegistro();
            AbrirVentanaHijo(cls.frmCat, 1);
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


        private void asistenciaEmpaqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void presentaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsPresentation cls = new ClsPresentation();
            AbrirVentanaHijo(cls._frmCat, 1);
        }

        private void contenedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsContainer cls = new ClsContainer();
            AbrirVentanaHijo(cls._frmCat, 1);
        }

        private void cajaPalletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsPrintLabelsPtiPallets cls = new ClsPrintLabelsPtiPallets();
            AbrirVentanaHijo(cls.frm, 1);
        }

        private void cargarEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddEmployees cat = new FrmAddEmployees();
            AbrirVentanaHijo(cat, 1);
        }

        private void categoríaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategoriaCat cat = new FrmCategoriaCat();
            AbrirVentanaHijo(cat, 1);
        }

        private void códigoParaCajaÚnicaEspárragoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCajaEmpleado cat = new FrmCajaEmpleado();
            AbrirVentanaHijo(cat, 1);
        }

        private void uvaNombreYCódigoDeEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNombreYCodigo2x1 cat = new FrmNombreYCodigo2x1();
            AbrirVentanaHijo(cat, 1);
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
            ClsPricesGtin cls = new ClsPricesGtin();
            AbrirVentanaHijo(cls._frmCat, 1);
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
            //REPORTECOMEDOR cat = new REPORTECOMEDOR();
            //AbrirVentanaHijo(cat, 2);

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

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void asistenciaEmpaqueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClsAsistenciaEmpaque cls = new ClsAsistenciaEmpaque();
            cls.frmMenu = this;

            cls.AbrirFrmAsistenciaEmpaque();
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
    }
}