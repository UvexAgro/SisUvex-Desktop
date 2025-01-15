


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
            //var doc = XDocument.Load("Configuracion/configuracion.xml");
            var configuracion = doc.Element("Configuracion");

            Server = configuracion.Element("server").Value;
            DbConn = configuracion.Element("dbConn").Value;
            UserConn = configuracion.Element("userConn").Value;
            PassConn = configuracion.Element("passConn").Value;
            DbWrite = configuracion.Element("dbWrite").Value;
            UserWrite = configuracion.Element("userWrite").Value;
            PassWrite = configuracion.Element("passWrite").Value;
            lastLogin = configuracion.Element("lastLogin").Value;
            DbEmployees = configuracion.Element("dbEmployees").Value;
        }

        public void Guardar()
        {
            var doc = new XDocument(
                new XElement("Configuracion",
                    new XElement("server", Server),
                    new XElement("dbConn", DbConn),
                    new XElement("userConn", UserConn),
                    new XElement("passConn", PassConn),
                    new XElement("dbWrite", DbWrite),
                    new XElement("userWrite", UserWrite),
                    new XElement("passWrite", PassWrite),
                    new XElement("prinDocuments", PrinDocuments),
                    new XElement("printTags", PrintTags),
                    new XElement("printPallet", PrintPallet),
                    new XElement("printCode", PrintCode),
                    new XElement("lastLogin", lastLogin),
                    new XElement("dbEmployees", DbEmployees)
                )
            );

            //string directoryPath = Path.GetDirectoryName(path2);
            //Directory.CreateDirectory(directoryPath);
            //MessageBox.Show("Configuracion guardada en: " + path2+"\nel directory es: "+directoryPath+"\nEl path1 es:"+path1);
            doc.Save(path1);
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
}
