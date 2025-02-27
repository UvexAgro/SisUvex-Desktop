using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Image;
using iText.Kernel.Geom;
using iText.Barcodes; // Importar para Barcode128
using iText.Kernel.Colors; // Para definir colores
using iText.Kernel.Pdf.Canvas; // Para rectángulo
using System.Data;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using PdfiumViewer;
using SisUvex.Catalogos.Metods.Querys;
using System.Media;
using SisUvex.Catalogos.Metods.Values;

namespace SisUvex.Nomina.EmployeeCredentials
{
    internal class ClsCredentials
    {
        //********NOTAS****** 1. La ruta de la carpeta de las fotos de momento esta fija en la que se muestra (photoPath), 2. La ruta del pdf es por carpeta como nombre de equipo para que no se empalme en caso de que se este trabajando al mismo tiempo en diferentes computadoras

        public FrmCredentials frm;
        private PdfViewer? pdfViewer;
        PageSize credentialSize = new PageSize(242.64f, 153.72f); //tamaño de la credencial (85.6 mm x 54 mm en puntos)
        string photoPath = "\\\\SVRCAMPOSANAN\\Inventum\\FOTOS"; // Cambia esta 
        string outputPathVarias = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", Environment.MachineName, "EmployeesCardsPrinting.pdf");

        string queryColumns = " SELECT '1' 'Imprimir', emp.id_employee 'Código', emp.v_lastNamePat 'A. Paterno', emp.v_lastNameMat 'A. Materno', emp.v_name 'Nombre',  FORMAT(emp.d_dateBirth, 'dd-MM-yyyy') 'F. Nacimiento', FORMAT(COALESCE(emp.d_reentrydDate, emp.d_startDate), 'dd-MM-yyyy') 'F. Ingreso', FORMAT(emp.d_printingDate, 'dd-MM-yyyy') 'F. Impresion' FROM Nom_Employees emp LEFT JOIN Nom_PlacePayment lp ON lp.id_placePayment = emp.id_paymentPlace LEFT JOIN Pack_Contractor con ON con.id_contractor = lp.id_contractor LEFT JOIN Pack_Grower gro ON gro.id_grower = lp.id_grower ";
        private string GetLogoPath(string logoName)
        {
            if (string.IsNullOrEmpty(logoName))
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "UVEXLogo.png");

            return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", logoName + "Logo.png");
        }

        public void btnLoadPdfEmployeesCards()
        {
            List<string> idEmployees = GetIdEmployeesListToPrint();

            if (idEmployees.Count == 0)
            {
                SystemSounds.Exclamation.Play();
                return;
            }

            DataTable empleados = GetDataTableToPrintCards(idEmployees);
            if (pdfViewer != null)
            {
                pdfViewer?.Document?.Dispose();
                pdfViewer.Document = null;
            }

            CreateEmployeesCards(empleados);

            ShowPdfViewer();

            HideDgvEmployeesList();
        }

        private void ShowPdfViewer()
        {
            pdfViewer = new PdfViewer
            {
                Visible = true,
                Dock = DockStyle.Fill,
                TabIndex = 9
            };
            frm.pnlPrincipal.Controls.Add(pdfViewer);

            pdfViewer.Document?.Dispose(); // Libera el documento anterior
            pdfViewer.Document = PdfiumViewer.PdfDocument.Load(outputPathVarias); // Cargar el nuevo PDF
            pdfViewer.ZoomMode = PdfViewerZoomMode.FitHeight;

            frm.btnCargarCredenciales.Enabled = false;
        }

        void CreateEmployeesCards(DataTable empleados)
        {

            string directoryPath = System.IO.Path.GetDirectoryName(outputPathVarias);
            if (!System.IO.Directory.Exists(directoryPath))
                System.IO.Directory.CreateDirectory(directoryPath);

            // Inicializa el escritor y el documento PDF
            using PdfWriter writer = new PdfWriter(outputPathVarias);
            using iText.Kernel.Pdf.PdfDocument pdf = new iText.Kernel.Pdf.PdfDocument(writer);
            Document document = new Document(pdf);

            foreach (DataRow empleado in empleados.Rows)
            {
                pdf.AddNewPage(1, credentialSize);

                // Llama a la función para agregar contenido de la credencial
                AgregarDatosCredencial(document, empleado, pdf);
            }

            document.Close(); // Cierra el documento
        }

        void AgregarDatosCredencial(Document document, DataRow empleado, iText.Kernel.Pdf.PdfDocument pdf)
        {
            float fontName = 12f, fontMedium = 8f, fontSubtitles = 5f;
            float logoX = 10f, logoY = 128f;
            float photoX = 10f, photoY = 50f;
            float nombreX = 61f, nombreY = 106f, anchoNombre = 200f; ;
            float nombre2X = 61f, nombre2Y = 91f;
            float nSSX = 85f, nSSY = 81f, nSSFont = fontMedium;
            float idX = 85f, idY = 26f, idFont = 11;
            float barcodeX = 86f, barcodeY = 41f, barcodeSizeX = 150, barcodeSizeY = 37;

            float empresaX = 155f, empresaY = 133f, anchoTexto = 80f, empresaFont = fontMedium; ;
            float registroPatronalX = 155f, registroPatronalY = 124f, registroPatronalFont = fontMedium, anchoRegistroPatronal = 80f;

            float lpX = 10f, lpY = 36f, lpFont = fontMedium;
            float contratistaX = 10f, contratistaY = 30f, contratistaFont = fontSubtitles;

            float reingresoX = 10f, reingresoY = 23f;
            float fechaImpresionX = 10f, fechaImpresionY = 16f;

            float rectX = -1f, rectY = -2f, rectWidth = 250f, rectHeight = 16f;
            iText.Kernel.Colors.Color UvexPurple = new DeviceRgb(88, 82, 119);  // Valores RGB para #585277
            iText.Kernel.Colors.Color UvexRed = new DeviceRgb(138, 56, 64);     // Valores RGB para #8A3840
            iText.Kernel.Colors.Color UvexGreen = new DeviceRgb(163, 214, 93);  // Valores RGB para #A3D65D

            string _logoPath = GetLogoPath(empleado["logo"].ToString());

            iText.Layout.Element.Image logo = new iText.Layout.Element.Image(ImageDataFactory.Create(_logoPath))
                .ScaleToFit(50, 25).SetFixedPosition(logoX, logoY);
            document.Add(logo);

            string _idEmployee = empleado["Id"].ToString();

            iText.Layout.Element.Image photo;
            string photoFilePath = System.IO.Path.Combine(photoPath, $"{_idEmployee}.jpg");
            if (System.IO.File.Exists(photoFilePath))
            {
                photo = new iText.Layout.Element.Image(ImageDataFactory.Create(photoFilePath)).ScaleAbsolute(70, 70).SetFixedPosition(photoX, photoY);
                document.Add(photo);
            }

            Paragraph nombre = new Paragraph(empleado["Nombre"].ToString()).SetFontSize(fontName)
                .SetTextAlignment(TextAlignment.CENTER) // Alineación centrada
                .SetFixedPosition(nombreX, nombreY, anchoNombre); // Posición con ancho específico
            document.Add(nombre);

            Paragraph nombre2 = new Paragraph(empleado["Apellidos"].ToString()).SetFontSize(fontName)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFixedPosition(nombre2X, nombre2Y, anchoNombre);
            document.Add(nombre2);

            string? _Empresa = empleado["Empresa"].ToString();
            if (!string.IsNullOrEmpty(_Empresa))
            {
                PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD); //Fuente en negritas
                Text empresaText = new Text(_Empresa)
                    .SetFont(boldFont)      // Aplicar negritas
                    .SetFontSize(10)        // Tamaño de fuente
                    .SetFontColor(UvexRed); // Aplicar color

                Paragraph empresa = new Paragraph(empresaText)          // Crear el párrafo y agregar el texto
                .SetTextAlignment(TextAlignment.RIGHT)              // Alineación a la derecha
                .SetFixedPosition(empresaX, empresaY, anchoTexto);  // Posición fija con ancho específico
                document.Add(empresa);

                string? _RP = empleado["RegistroPatronal"].ToString();
                if (!string.IsNullOrEmpty(_RP))
                {
                    Paragraph registroPatronal = new Paragraph("RP: " + _RP).SetFontSize(registroPatronalFont)
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetFixedPosition(registroPatronalX, registroPatronalY, anchoRegistroPatronal);
                    document.Add(registroPatronal);
                }

            }

            string? _Ingreso = empleado["Ingreso"].ToString();
            if (!string.IsNullOrEmpty(_Ingreso))
            {
                Paragraph reingreso = new Paragraph("Ingreso: " + Convert.ToDateTime(empleado["Ingreso"]).ToString("dd-MMM-yyyy")).SetFontSize(fontSubtitles)
                .SetFixedPosition(reingresoX, reingresoY, 200);
                document.Add(reingreso);
            }

            string? _Impresion = empleado["Impresion"].ToString();
            if (!string.IsNullOrEmpty(_Impresion))
            {
                Paragraph fechaImpresion = new Paragraph("Impresion: " + Convert.ToDateTime(_Impresion).ToString("dd-MMM-yyyy")).SetFontSize(fontSubtitles)
                .SetFixedPosition(fechaImpresionX, fechaImpresionY, 200);
                document.Add(fechaImpresion);
            }

            string? _nSS = empleado["NSS"].ToString();
            if (!string.IsNullOrEmpty(_nSS.Trim()))
            {
                Paragraph nSS = new Paragraph("NSS: " + _nSS).SetFontSize(nSSFont)
                .SetTextAlignment(TextAlignment.CENTER) // Alineación centrada
                .SetFixedPosition(nSSX, nSSY, 152);     //posicion y tamaño de ancho para centrar
                document.Add(nSS);
            }

            // Código de barras con el ID del empleado
            string idEmpleado = _idEmployee.ToString();
            Barcode128 barcode = new Barcode128(pdf);
            barcode.SetCode(idEmpleado);
            barcode.SetFont(null); // Sin texto debajo del código de barras
            iText.Layout.Element.Image barcodeImage = new iText.Layout.Element.Image(barcode.CreateFormXObject(pdf))
                .SetFixedPosition(barcodeX, barcodeY)
                .ScaleAbsolute(barcodeSizeX, barcodeSizeY); // Ajusta el tamaño del código de barras
            document.Add(barcodeImage);

            Paragraph id = new Paragraph(_idEmployee.ToString()).SetFontSize(idFont)
                .SetTextAlignment(TextAlignment.CENTER) // Alineación centrada
                .SetFixedPosition(idX, idY, 152);       //posicion y tamaño de ancho para centrar
            document.Add(id);

            Paragraph lp = new Paragraph("LP: " + empleado["LP"].ToString()).SetFontSize(lpFont)
                .SetFixedPosition(lpX, lpY, 200);
            document.Add(lp);

            string? _contractor = empleado["Contratista"].ToString();
            if (!string.IsNullOrEmpty(_contractor))
            {
                Paragraph contratista = new Paragraph("Contratista: " + _contractor).SetFontSize(contratistaFont)
                    .SetFixedPosition(contratistaX, contratistaY, 200);
                document.Add(contratista);
            }

            // Crear el rectángulo de color
            iText.Kernel.Geom.Rectangle rectangle = new iText.Kernel.Geom.Rectangle(rectX, rectY, rectWidth, rectHeight);
            PdfCanvas canvas = new PdfCanvas(pdf.GetFirstPage());
            canvas.SetFillColor(UvexGreen); // Color morado
            canvas.Rectangle(rectangle);
            canvas.Fill();
        }

        private DataTable GetDataTableToEmployeesList()
        {
            string query = queryColumns + $" WHERE emp.id_paymentPlace = '{frm.cboLP.SelectedValue}' AND COALESCE(emp.d_reentrydDate, emp.d_startDate) BETWEEN '{frm.dtpFechaIngreso1.Value.ToString("yyyy-MM-dd")}' AND '{frm.dtpFechaIngreso2.Value.ToString("yyyy-MM-dd")}' ORDER BY emp.v_lastNamePat, emp.v_lastNameMat, emp.v_name";

            //ES LA VISTA DEL DATAGRIDVIEW, NO LA TABLA DE LOS DATOS DE LA CREDENCIAL
            DataTable dt = new DataTable();

            dt = ClsQuerysDB.GetDataTable(query);

            if (dt.Rows.Count == 0)
                SystemSounds.Exclamation.Play();

            return dt;
        }

        private DataTable GetDataTableToAddTxbEmployees()
        {
            string datosPegados = frm.txbCodigoEmpleado.Text;
            DataTable dt = new DataTable();

            if (string.IsNullOrWhiteSpace(datosPegados))
            {
                SystemSounds.Exclamation.Play();
                return dt;
            }

            // Procesar los datos, eliminando espacios y saltos de línea
            var valores = datosPegados.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                      .Select(v => v.Trim().PadLeft(6, '0')) // Asegurar que el valor tenga 6 dígitos
                                      .Where(v => !string.IsNullOrEmpty(v))
                                      .ToArray();

            if (valores.Length == 0)
            {
                SystemSounds.Exclamation.Play();
                return dt;
            }

            Dictionary<string, object?> parameters = new();
            string query = queryColumns + " WHERE id_employee IN (" + string.Join(", ", valores.Select((v, i) =>
            {
                string paramName = $"@id{i}";
                parameters.Add(paramName, v);
                return paramName;
            })) + ")";

            // Ejecutar la consulta con parámetros
            dt = ClsQuerysDB.ExecuteParameterizedQuery(query, parameters);

            if (dt.Rows.Count == 0)
                SystemSounds.Exclamation.Play();

            return dt;
        }

        public void cboPaymentPlaceList()
        {
            DataTable dt = ClsQuerysDB.GetDataTable("SELECT id_placePayment 'Código', CONCAT(id_placePayment,' | ',v_namePlace) 'Nombre' FROM Nom_PlacePayment WHERE c_activePlace = '1'");
            frm.cboLP.DataSource = dt;
            frm.cboLP.DisplayMember = "Nombre";
            frm.cboLP.ValueMember = "Código";
        }

        private void LoadDgvColumns()
        {
            frm.dataGridView1.Visible = true;

            // Limpiar las columnas existentes antes de agregar nuevas
            frm.dataGridView1.Columns.Clear();

            AddColumnsToDataGridView();

            // Configurar la primera columna como checkbox con lógica para interpretar "1" como true y "0" como false
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
            {
                Name = "Imprimir",
                HeaderText = "Imprimir",
                TrueValue = "1",
                FalseValue = "0",
                DataPropertyName = "Imprimir",
            };

            // Reemplazar la columna generada automáticamente por el checkbox
            frm.dataGridView1.Columns.RemoveAt(0);
            frm.dataGridView1.Columns.Insert(0, checkBoxColumn);
        }

        private void FillDgvEmployeesList()
        {
            LoadDgvColumns();

            DataTable dtDGV = GetDataTableToEmployeesList();

            frm.dataGridView1.SuspendLayout();

            foreach (DataRow row in dtDGV.Rows)
            {
                frm.dataGridView1.Rows.Add(
                    row["Imprimir"],
                    row["Código"],
                    row["A. Paterno"],
                    row["A. Materno"],
                    row["Nombre"],
                    row["F. Nacimiento"],
                    row["F. Ingreso"],
                    row["F. Impresion"]
                );
            }

            frm.dataGridView1.ResumeLayout();
        }

        public void btnAddTxbEmployeesToList()
        {
            ShowDgvEmployeesList();

            if (frm.dataGridView1.ColumnCount == 0)
                LoadDgvColumns();

            DataTable dt = GetDataTableToAddTxbEmployees();

            if (dt.Rows.Count == 0)
            {
                SystemSounds.Exclamation.Play();
                return;
            }

            foreach (DataRow row in dt.Rows)
            {
                bool employeeExists = false;

                foreach (DataGridViewRow fila in frm.dataGridView1.Rows)
                {
                    if (fila.Cells["Código"].Value?.ToString() == row["Código"].ToString())
                    {
                        employeeExists = true;
                        break;
                    }
                }

                if (!employeeExists)
                {
                    frm.dataGridView1.Rows.Add(row["Imprimir"], row["Código"], row["A. Paterno"], row["A. Materno"], row["Nombre"], row["F. Nacimiento"], row["F. Ingreso"], row["F. Impresion"]);
                }
            }

            HidePdfViewer();
        }

        public void btnEmployeesList()
        {
            FillDgvEmployeesList();

            HidePdfViewer();
        }

        private void AddColumnsToDataGridView()
        {
            frm.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Imprimir",
                HeaderText = "Imprimir",
                DataPropertyName = "Imprimir"
            });

            frm.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Código",
                HeaderText = "Código",
                DataPropertyName = "Código",
                ReadOnly = true
            });

            frm.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "A. Paterno",
                HeaderText = "A. Paterno",
                DataPropertyName = "A. Paterno",
                ReadOnly = true
            });

            frm.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "A. Materno",
                HeaderText = "A. Materno",
                DataPropertyName = "A. Materno",
                ReadOnly = true
            });

            frm.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nombre",
                HeaderText = "Nombre",
                DataPropertyName = "Nombre",
                ReadOnly = true
            });

            frm.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "F. Nacimiento",
                HeaderText = "F. Nacimiento",
                DataPropertyName = "F. Nacimiento",
                ReadOnly = true
            });

            frm.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "F. Ingreso",
                HeaderText = "F. Ingreso",
                DataPropertyName = "F. Ingreso",
                ReadOnly = true
            });

            frm.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "F. Impresion",
                HeaderText = "F. Impresion",
                DataPropertyName = "F. Impresion",
                ReadOnly = true
            });
        }

        private List<string> GetIdEmployeesListToPrint()
        {
            List<string> idEmployees = new List<string>();

            foreach (DataGridViewRow fila in frm.dataGridView1.Rows)
            {
                if (fila.Cells["Imprimir"].Value.ToString() == "1")
                {
                    idEmployees.Add(fila.Cells["Código"].Value.ToString());
                }
            }

            return idEmployees;
        }

        private DataTable GetDataTableToPrintCards(List<string> idEmployees)
        {
            string query = "SELECT emp.v_name 'Nombre',  CONCAT_WS(' ', emp.v_lastNamePat, emp.v_lastNameMat) 'Apellidos', emp.c_numimss 'NSS', emp.id_employee 'Id', emp.id_paymentPlace 'LP', gro.v_shortName 'Empresa', gro.v_regPat 'RegistroPatronal', con.v_nameContractor 'Contratista', COALESCE(emp.d_reentrydDate, emp.d_startDate) AS 'Ingreso', CONVERT(DATE,SYSDATETIME()) 'Impresion', gro.v_logo 'logo' FROM Nom_Employees emp LEFT JOIN Nom_PlacePayment lp ON lp.id_placePayment = emp.id_paymentPlace LEFT JOIN Pack_Contractor con ON con.id_contractor = lp.id_contractor LEFT JOIN Pack_Grower gro ON gro.id_grower = lp.id_grower" + $" WHERE emp.id_employee IN ('{string.Join("', '", idEmployees)}')";

            return ClsQuerysDB.GetDataTable(query);
        }

        private void HidePdfViewer()
        {
            if (pdfViewer != null)
                pdfViewer.Visible = false;

            frm.btnCargarCredenciales.Enabled = true;
        }

        private void HideDgvEmployeesList()
        {
            frm.dataGridView1.Visible = false;
            frm.btnCargarCredenciales.Enabled = false;
        }

        private void ShowDgvEmployeesList()
        {
            frm.dataGridView1.Visible = true;
        }

        public void btnSetSelectedAsPrinterCards()
        {
            List<string> idEmployees = GetIdEmployeesListToPrint();

            if (idEmployees.Count == 0)
            {
                SystemSounds.Exclamation.Play();
                return;
            }

            DialogResult result = MessageBox.Show("¿Desea marcar como impresas las credenciales de los empleados seleccionados?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string query = $"UPDATE Nom_Employees SET d_printingDate = CONVERT(DATE,SYSDATETIME()) WHERE id_employee IN ('{string.Join("', '", idEmployees)}')";

                if (ClsQuerysDB.ExecuteQuery(query))
                {
                    MessageBox.Show("Se marcaron correctamente como credenciales impresas a los empleados seleccionados.", "Impresión de credenciales");
                }
            }
        }

        public void SetImprimirColumnValues(bool value)
        {
            string newValue = value ? "1" : "0";
            foreach (DataGridViewRow row in frm.dataGridView1.Rows)
            {
                row.Cells["Imprimir"].Value = newValue;
            }

            HidePdfViewer();

            ShowDgvEmployeesList();
        }

        public void ClsFrmClosing()
        {
            if (pdfViewer != null)
            {
                pdfViewer.Document?.Dispose();
                pdfViewer.Dispose();
                pdfViewer = null;
            }
        }

        public void BtnShowEmployeeList()
        {
            HidePdfViewer();

            ShowDgvEmployeesList();
        }
    }
}
