

namespace SisUvex.Configuracion
{
    using System.Security.Cryptography;
    using System.Text;
    using System.Xml.Linq;
    internal class ClsConfig
    {
        // Datos "planos" del servidor EN USO (los que lee el resto del programa).
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

        /// <summary>Posición (empezando en 1) del servidor en uso dentro de <see cref="Servidores"/>.</summary>
        public static int CurrentServer { get; set; } = 1;

        /// <summary>Todos los servidores guardados en este equipo (mínimo 1).</summary>
        public static List<ConexionServidor> Servidores { get; } = new List<ConexionServidor>();

        public static readonly string[] PaletaColores =
        {
            "#7A2CA6", "#808080", "#0E9AA7", "#F28C28", "#D63031", "#2D6CDF", "#E84393", "#489E2C"
        };

        public static ConexionServidor ServidorActivo
        {
            get
            {
                AsegurarServidor();
                return Servidores[NumeroServidorActivo - 1];
            }
        }

        public static int NumeroServidorActivo
        {
            get
            {
                AsegurarServidor();
                return Math.Min(Math.Max(CurrentServer, 1), Servidores.Count);
            }
        }

        private string path1 = ClsXmlArchivos.rutaTemp;

        public ClsConfig()
        {
        }

        public static ConexionServidor NuevoServidor(int posicion)
        {
            return new ConexionServidor
            {
                Nombre = $"Servidor {posicion}",
                Color = PaletaColores[(posicion - 1) % PaletaColores.Length]
            };
        }

        private static void AsegurarServidor()
        {
            if (Servidores.Count == 0)
                Servidores.Add(NuevoServidor(1));
        }

        public void Leer()
        {
            XDocument doc = XDocument.Load(path1);
            var configuracion = doc.Element("Configuracion");
            if (configuracion == null)
                return;

            Servidores.Clear();
            bool migrar = false;

            XElement contenedor = configuracion.Element("servidores");
            XElement servidor1 = configuracion.Element("servidor1");
            XElement servidor2 = configuracion.Element("servidor2");

            if (contenedor != null)
            {
                // Formato actual: lista de servidores.
                foreach (XElement nodo in contenedor.Elements("servidor"))
                {
                    ConexionServidor s = new ConexionServidor();
                    LeerGrupo(nodo, s);
                    Servidores.Add(s);
                }
                int actual;
                CurrentServer = int.TryParse(configuracion.Element("currentServer")?.Value, out actual) ? actual : 1;
            }
            else if (servidor1 != null || servidor2 != null)
            {
                // Formato intermedio: exactamente dos servidores fijos.
                ConexionServidor s1 = new ConexionServidor();
                ConexionServidor s2 = new ConexionServidor();
                LeerGrupo(servidor1, s1);
                LeerGrupo(servidor2, s2);
                s2.Color = "#808080"; // antes el servidor 2 se veía en blanco y negro
                Servidores.Add(s1);
                Servidores.Add(s2);
                CurrentServer = configuracion.Element("currentServer")?.Value == "2" ? 2 : 1;
                migrar = true;
            }
            else
            {
                // Formato antiguo: los parámetros están directamente bajo <Configuracion>.
                ConexionServidor s1 = new ConexionServidor();
                LeerGrupo(configuracion, s1);
                Servidores.Add(s1);
                CurrentServer = 1;
                migrar = true;
            }

            AsegurarServidor();
            for (int i = 0; i < Servidores.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(Servidores[i].Nombre))
                    Servidores[i].Nombre = $"Servidor {i + 1}";
                if (string.IsNullOrWhiteSpace(Servidores[i].Color))
                    Servidores[i].Color = PaletaColores[i % PaletaColores.Length];
            }
            CurrentServer = NumeroServidorActivo;

            lastLogin = Valor(configuracion, "lastLogin");
            PrinDocuments = Valor(configuracion, "prinDocuments");
            PrintTags = Valor(configuracion, "printTags");
            PrintPallet = Valor(configuracion, "printPallet");
            PrintCode = Valor(configuracion, "printCode");

            AplicarServidorActivo();

            if (migrar)
                MigrarArchivoAntiguo();
        }

        /// <summary>
        /// Convierte el archivo de configuración de un formato anterior al actual (lista de servidores).
        /// Deja una copia del archivo original y, si algo falla, no interrumpe la lectura (los datos ya quedaron en memoria).
        /// </summary>
        private void MigrarArchivoAntiguo()
        {
            try
            {
                string respaldo = ClsXmlArchivos.rutaConf + ".antiguo.bak";
                if (File.Exists(ClsXmlArchivos.rutaConf) && !File.Exists(respaldo))
                    File.Copy(ClsXmlArchivos.rutaConf, respaldo);

                Guardar();                             // escribe el XML temporal con el formato nuevo
                new ClsXmlArchivos().PutInConfFile();  // lo cifra sobre configuracion.xml y borra el temporal
            }
            catch (Exception)
            {
                // Si no se pudo reescribir, se volverá a intentar en la siguiente lectura.
            }
        }

        public void Guardar()
        {
            // Los datos planos pertenecen al servidor en uso: se sincronizan antes de escribir.
            ConexionServidor activo = ServidorActivo;
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
                    new XElement("currentServer", NumeroServidorActivo.ToString()),
                    new XElement("servidores", Servidores.Select(s => GrupoXml("servidor", s))),
                    new XElement("prinDocuments", PrinDocuments ?? ""),
                    new XElement("printTags", PrintTags ?? ""),
                    new XElement("printPallet", PrintPallet ?? ""),
                    new XElement("printCode", PrintCode ?? ""),
                    new XElement("lastLogin", lastLogin ?? "")
                )
            );

            doc.Save(path1);
        }

        /// <summary>Copia los datos del servidor en uso a los datos planos que usa el resto del programa.</summary>
        public static void AplicarServidorActivo()
        {
            ConexionServidor origen = ServidorActivo;
            CurrentServer = NumeroServidorActivo;
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

            destino.Nombre = Valor(nodo, "nombre");
            destino.Color = Valor(nodo, "color");
            destino.Server = Valor(nodo, "server");
            destino.DbConn = Valor(nodo, "dbConn");
            destino.UserConn = Valor(nodo, "userConn");
            destino.PassConn = Valor(nodo, "passConn");
            destino.DbWrite = Valor(nodo, "dbWrite");
            destino.UserWrite = Valor(nodo, "userWrite");
            destino.PassWrite = Valor(nodo, "passWrite");
            destino.DbEmployees = Valor(nodo, "dbEmployees");
        }

        public static XElement GrupoXml(string nombre, ConexionServidor conexion)
        {
            return new XElement(nombre,
                new XElement("nombre", conexion.Nombre ?? ""),
                new XElement("color", conexion.Color ?? ""),
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
        public string Nombre { get; set; } = "";
        /// <summary>Color de identificación en formato #RRGGBB.</summary>
        public string Color { get; set; } = "";
        public string Server { get; set; }
        public string DbConn { get; set; }
        public string UserConn { get; set; }
        public string PassConn { get; set; }
        public string DbWrite { get; set; }
        public string UserWrite { get; set; }
        public string PassWrite { get; set; }
        public string DbEmployees { get; set; }

        public System.Drawing.Color ObtenerColor()
        {
            try
            {
                return System.Drawing.ColorTranslator.FromHtml(string.IsNullOrWhiteSpace(Color) ? "#7A2CA6" : Color);
            }
            catch (Exception)
            {
                return System.Drawing.Color.FromArgb(122, 44, 166);
            }
        }

        public ConexionServidor Clonar()
        {
            return (ConexionServidor)MemberwiseClone();
        }
    }
}
