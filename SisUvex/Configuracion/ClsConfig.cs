


namespace SisUvex.Configuracion
{
    using System.Security.Cryptography;
    using System.Text;
    using System.Xml.Linq;
    internal class ClsConfig
    {
        public static string Server { get; set; }
        public static string DbConn { get; set; }
        public static string UserConn { get; set; }
        public static string PassConn { get; set; }
        public static string DbWrite { get; set; }
        public static string UserWrite { get; set; }
        public static string PassWrite { get; set; }
        public static string PrinDocuments { get; set; }
        public static string PrintTags { get; set; }
        public static string PrintPallet { get; set; }
        public static string PrintCode { get; set; }
        public static string DbEmployees { get; set; }
        public static string lastLogin{ get; set; }

        public static int CurrentServer { get; set; } = 1;
        public static ConexionServidor Servidor1 { get; } = new ConexionServidor();
        public static ConexionServidor Servidor2 { get; } = new ConexionServidor();

        //este si jalostring path2 = Path.Combine("Configuracion", "configuracion.xml");

        private string path1 = ClsXmlArchivos.rutaTemp;
        // ESTA SI JALÓ: private string path1 = @"C:\\Users\\Daniel\\SisUvex\\SisUvex\\..\\..\\..\\Configuracion\\configuracion.xml";
        //string path = @"C:\\Users\\Daniel\\SisUvex\\SisUvex\\bin\\Debug\\net6.0-windows\\Configuracion\\configuracion.xml";

        public ClsConfig()
        {
        }
        public void Leer()
        {
            XDocument doc = XDocument.Load(path1);
            var configuracion = doc.Element("Configuracion");
            if (configuracion == null)
                return;

            XElement servidor1 = configuracion.Element("servidor1");
            XElement servidor2 = configuracion.Element("servidor2");

            if (servidor1 != null || servidor2 != null)
            {
                LeerGrupo(servidor1, Servidor1);
                LeerGrupo(servidor2, Servidor2);
                CurrentServer = configuracion.Element("currentServer")?.Value == "2" ? 2 : 1;
            }
            else
            {
                LeerGrupo(configuracion, Servidor1);
                CurrentServer = 1;
            }

            lastLogin = Valor(configuracion, "lastLogin");
            PrinDocuments = Valor(configuracion, "prinDocuments");
            PrintTags = Valor(configuracion, "printTags");
            PrintPallet = Valor(configuracion, "printPallet");
            PrintCode = Valor(configuracion, "printCode");

            AplicarServidorActivo();
        }

        public void Guardar()
        {
            ConexionServidor activo = CurrentServer == 2 ? Servidor2 : Servidor1;
            activo.Server = Server ?? "";
            activo.DbConn = DbConn ?? "";
            activo.UserConn = UserConn ?? "";
            activo.PassConn = PassConn ?? "";
            activo.DbWrite = DbWrite ?? "";
            activo.UserWrite = UserWrite ?? "";
            activo.PassWrite = PassWrite ?? "";
            activo.DbEmployees = DbEmployees ?? "";

            var doc = new XDocument(
                new XElement("Configuracion",
                    new XElement("currentServer", CurrentServer == 2 ? "2" : "1"),
                    GrupoXml("servidor1", Servidor1),
                    GrupoXml("servidor2", Servidor2),
                    new XElement("prinDocuments", PrinDocuments ?? ""),
                    new XElement("printTags", PrintTags ?? ""),
                    new XElement("printPallet", PrintPallet ?? ""),
                    new XElement("printCode", PrintCode ?? ""),
                    new XElement("lastLogin", lastLogin ?? "")
                )
            );

            //string directoryPath = Path.GetDirectoryName(path2);
            //Directory.CreateDirectory(directoryPath);
            //MessageBox.Show("Configuracion guardada en: " + path2+"\nel directory es: "+directoryPath+"\nEl path1 es:"+path1);
            doc.Save(path1);
        }

        private static void AplicarServidorActivo()
        {
            ConexionServidor origen = CurrentServer == 2 ? Servidor2 : Servidor1;
            Server = origen.Server;
            DbConn = origen.DbConn;
            UserConn = origen.UserConn;
            PassConn = origen.PassConn;
            DbWrite = origen.DbWrite;
            UserWrite = origen.UserWrite;
            PassWrite = origen.PassWrite;
            DbEmployees = origen.DbEmployees;
        }

        private static void LeerGrupo(XElement nodo, ConexionServidor destino)
        {
            if (nodo == null)
                return;

            destino.Server = Valor(nodo, "server");
            destino.DbConn = Valor(nodo, "dbConn");
            destino.UserConn = Valor(nodo, "userConn");
            destino.PassConn = Valor(nodo, "passConn");
            destino.DbWrite = Valor(nodo, "dbWrite");
            destino.UserWrite = Valor(nodo, "userWrite");
            destino.PassWrite = Valor(nodo, "passWrite");
            destino.DbEmployees = Valor(nodo, "dbEmployees");
        }

        private static XElement GrupoXml(string nombre, ConexionServidor conexion)
        {
            return new XElement(nombre,
                new XElement("server", conexion.Server ?? ""),
                new XElement("dbConn", conexion.DbConn ?? ""),
                new XElement("userConn", conexion.UserConn ?? ""),
                new XElement("passConn", conexion.PassConn ?? ""),
                new XElement("dbWrite", conexion.DbWrite ?? ""),
                new XElement("userWrite", conexion.UserWrite ?? ""),
                new XElement("passWrite", conexion.PassWrite ?? ""),
                new XElement("dbEmployees", conexion.DbEmployees ?? "")
            );
        }

        private static string Valor(XElement nodo, string nombre)
        {
            return nodo.Element(nombre)?.Value ?? "";
        }

        public static string GetPrinterOrientation(string printerName)
        {
            // Obtiene la configuración de la impresora
            var printerSettings = new System.Drawing.Printing.PrinterSettings();
            printerSettings.PrinterName = printerName;

            // Obtiene la orientación de la página predeterminada
            var pageSettings = new System.Drawing.Printing.PageSettings();
            pageSettings.PrinterSettings = printerSettings;
            var orientation = pageSettings.Landscape ? "Horizontal" : "Vertical";

            return orientation;
        }


        //---------------NOTAS LEER------------------


        // (1)
        // PARA CAMBIAR EL VALOR DE LAS VARIABLES EN UN FORM O UNA CLASE SE HACE ALGO COMO LO SIGUIENTE
        //SE DEBE INICIAR UNA INSTANCIA DE ESTA CLASE DE CONFIGURACION Y DE AHI CAMBIAR EL VALOR DE LA VARIABLE Y LLAMAR EL METODO DE GUARDAR();

        //public partial class MiFormulario : Form
        //{
        //    private Configuracion _configuracion;

        //    public MiFormulario()
        //    {
        //        InitializeComponent();
        //        _configuracion = new Configuracion();
        //    }

        //    private void CambiarValor()
        //    {
        //        // Cambiar el valor de una variable
        //        _configuracion.Server = "nuevoValor";

        //        // Guardar los cambios
        //        _configuracion.Guardar();
        //    }
        //}

        //------------------
        //(2)
        //PARA ACCEDER A LAS VARIABLES SE HARIA ALGO ASI TAMBIEN
        //PRIMERO LA INSTANCIA Y DESPUES SE LLAMA LA VARIABLE PODIENDOLE ASIGNAR A OTRAS O UTILIZANDO DIRECTAMENTE
        //public partial class MiFormulario : Form
        //{
        //    private Configuracion _configuracion;

        //    public MiFormulario()
        //    {
        //        InitializeComponent();

        //        _configuracion = new Configuracion();

        //        // Ahora puedes acceder a las variables de configuración
        //        string server = _configuracion.Server;
        //        string dbConn = _configuracion.DbConn;
        //        // etc.
        //    }
        //}
    }

    internal class ConexionServidor
    {
        public string Server { get; set; }
        public string DbConn { get; set; }
        public string UserConn { get; set; }
        public string PassConn { get; set; }
        public string DbWrite { get; set; }
        public string UserWrite { get; set; }
        public string PassWrite { get; set; }
        public string DbEmployees { get; set; }
    }
}
