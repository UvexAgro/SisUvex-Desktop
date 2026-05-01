using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;

namespace SisUvex.Cuadro_de_herramientas.ZPL
{
    /// <summary>
    /// Vista previa de ZPL (Zebra): Labelary REST + visualización en control o imagen.
    /// </summary>
    public sealed class ClsZplPreview : IDisposable
    {
        private static readonly HttpClient SharedHttp = CreateHttpClient();

        private PictureBox? _pictureBox;
        private int _zoomPercent = 100;

        /// <summary>Escala de vista previa respecto al tamaño nativo del PNG (100 = tamaño real en píxeles).</summary>
        public int ZoomPercent
        {
            get => _zoomPercent;
            set
            {
                int v = Math.Clamp(value, 25, 500);
                if (v == _zoomPercent)
                    return;
                _zoomPercent = v;
                RefreshZoomDisplay();
            }
        }

        /// <summary>Base del servicio (Labelary público o servidor propio).</summary>
        public string ApiBaseUrl { get; set; } = "https://api.labelary.com";

        /// <summary>Si tu API lo requiere (p. ej. despliegue privado): se envía como Authorization: Bearer.</summary>
        public string? ApiKey { get; set; }

        /// <summary>"Grayscale" o "Bitonal" (cabecera X-Quality de Labelary).</summary>
        public string OutputQuality { get; set; } = "Grayscale";

        /// <summary>Resolución de la impresora en puntos/mm (6, 8, 12, 24…).</summary>
        public int Dpmm { get; set; } = 8;

        /// <summary>Ancho de la etiqueta en pulgadas (interno para la API).</summary>
        public double WidthInches { get; set; } = 4;

        /// <summary>Alto de la etiqueta en pulgadas (interno para la API).</summary>
        public double HeightInches { get; set; } = 6;

        /// <summary>Índice de etiqueta (0 = primera) cuando el ZPL incluye varias.</summary>
        public int LabelIndex { get; set; }

        /// <summary>Último valor de X-Total-Count devuelto por Labelary, si existe.</summary>
        public int? LastTotalLabelCount { get; private set; }

        /// <summary>Último error al renderizar (red, servidor, ZPL).</summary>
        public string? LastError { get; private set; }

        private static HttpClient CreateHttpClient()
        {
            var http = new HttpClient { Timeout = TimeSpan.FromSeconds(60) };
            http.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "SisUvex ZPL Preview");
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("image/png"));
            return http;
        }

        private static string FormatInches(double value) =>
            value.ToString("0.###", CultureInfo.InvariantCulture);

        private static string NormalizeBaseUrl(string baseUrl)
        {
            string t = baseUrl.Trim();
            if (string.IsNullOrEmpty(t))
                return "https://api.labelary.com";
            return t.TrimEnd('/');
        }

        /// <summary>URL de la petición de vista previa (útil para depuración).</summary>
        public string BuildPreviewRequestUrl()
        {
            string w = FormatInches(WidthInches);
            string h = FormatInches(HeightInches);
            string root = NormalizeBaseUrl(ApiBaseUrl);
            return $"{root}/v1/printers/{Dpmm}dpmm/labels/{w}x{h}/{LabelIndex}/";
        }

        /// <summary>Vincula un <see cref="PictureBox"/> como destino del renderizado.</summary>
        public void AttachPictureBox(PictureBox pictureBox)
        {
            _pictureBox = pictureBox ?? throw new ArgumentNullException(nameof(pictureBox));
            ConfigurarPictureBoxPreview(pictureBox);
        }

        /// <summary>Usa el panel como contenedor de un <see cref="PictureBox"/> interno si hace falta.</summary>
        public void AttachPreviewPanel(Panel panel)
        {
            ArgumentNullException.ThrowIfNull(panel);
            PictureBox? existing = FindChildPictureBox(panel);
            if (existing != null)
            {
                _pictureBox = existing;
                ConfigurarPictureBoxPreview(existing);
                return;
            }

            panel.AutoScroll = true;
            panel.AutoScrollMinSize = Size.Empty;
            var pic = new PictureBox
            {
                Name = "picZplPreview"
            };
            ConfigurarPictureBoxPreview(pic);
            panel.Controls.Add(pic);
            _pictureBox = pic;
        }

        private static void ConfigurarPictureBoxPreview(PictureBox pictureBox)
        {
            pictureBox.Dock = DockStyle.None;
            pictureBox.Location = Point.Empty;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Size = new Size(1, 1);
        }

        /// <summary>Vuelve a aplicar el zoom sin regenerar la imagen (p. ej. al mover la barra).</summary>
        public void RefreshZoomDisplay()
        {
            if (_pictureBox == null)
                return;

            void Act()
            {
                if (!_pictureBox!.IsDisposed)
                    AplicarTamanoVistaPrevia();
            }

            if (_pictureBox.InvokeRequired)
                _pictureBox.BeginInvoke(Act);
            else
                Act();
        }

        private void AplicarTamanoVistaPrevia()
        {
            if (_pictureBox == null || _pictureBox.IsDisposed)
                return;

            Image? img = _pictureBox.Image;
            if (img == null)
            {
                _pictureBox.Size = new Size(1, 1);
                return;
            }

            double z = _zoomPercent / 100.0;
            int w = Math.Max(1, (int)Math.Round(img.Width * z));
            int h = Math.Max(1, (int)Math.Round(img.Height * z));
            _pictureBox.SuspendLayout();
            _pictureBox.Dock = DockStyle.None;
            _pictureBox.Location = Point.Empty;
            _pictureBox.Size = new Size(w, h);
            _pictureBox.ResumeLayout();
        }

        private static PictureBox? FindChildPictureBox(Panel panel)
        {
            foreach (Control c in panel.Controls)
                if (c is PictureBox pb)
                    return pb;
            return null;
        }

        /// <summary>Renderiza ZPL a imagen (sin UI). Usa las mismas reglas que la instancia actual.</summary>
        public async Task<Image?> RenderZplToImageAsync(string? zpl, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(zpl))
                return null;

            var (bmp, _) = await RenderInternalAsync(zpl.Trim(),
                NormalizeBaseUrl(ApiBaseUrl),
                Dpmm,
                WidthInches,
                HeightInches,
                LabelIndex,
                OutputQuality,
                ApiKey,
                cancellationToken).ConfigureAwait(false);
            return bmp;
        }

        /// <summary>Compatibilidad estática con parámetros explícitos.</summary>
        public static async Task<Image?> RenderZplToImageAsync(
            string? zpl,
            int dpmm = 8,
            double widthInches = 4,
            double heightInches = 6,
            int labelIndex = 0,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(zpl))
                return null;

            var (bmp, _) = await RenderInternalAsync(zpl.Trim(),
                NormalizeBaseUrl("https://api.labelary.com"),
                dpmm,
                widthInches,
                heightInches,
                labelIndex,
                "Grayscale",
                null,
                cancellationToken).ConfigureAwait(false);
            return bmp;
        }

        private static async Task<(Image? bmp, int? totalCount)> RenderInternalAsync(
            string zpl,
            string apiBaseRoot,
            int dpmm,
            double widthInches,
            double heightInches,
            int labelIndex,
            string outputQuality,
            string? apiKey,
            CancellationToken cancellationToken)
        {
            string w = FormatInches(widthInches);
            string h = FormatInches(heightInches);
            string url = $"{apiBaseRoot}/v1/printers/{dpmm}dpmm/labels/{w}x{h}/{labelIndex}/";

            using var content = new ByteArrayContent(Encoding.UTF8.GetBytes(zpl));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            using var request = new HttpRequestMessage(HttpMethod.Post, url) { Content = content };
            request.Headers.TryAddWithoutValidation("X-Quality",
                outputQuality.Equals("Bitonal", StringComparison.OrdinalIgnoreCase) ? "Bitonal" : "Grayscale");

            if (!string.IsNullOrWhiteSpace(apiKey))
                request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + apiKey.Trim());

            using HttpResponseMessage response =
                await SharedHttp.SendAsync(request, cancellationToken).ConfigureAwait(false);

            int? total = null;
            if (response.Headers.TryGetValues("X-Total-Count", out IEnumerable<string>? tc))
            {
                string v = tc.FirstOrDefault() ?? "";
                if (int.TryParse(v.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int n))
                    total = n;
            }

            if (!response.IsSuccessStatusCode)
            {
                string body = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                throw new HttpRequestException(
                    $"Labelary {(int)response.StatusCode}: {body.Trim()}");
            }

            await using Stream stream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
            return (new Bitmap(stream), total);
        }

        /// <summary>Actualiza el control vinculado con el ZPL indicado.</summary>
        public async Task<bool> ShowPreviewAsync(string? zpl, CancellationToken cancellationToken = default)
        {
            LastError = null;
            LastTotalLabelCount = null;

            if (_pictureBox == null)
            {
                LastError = "No hay destino de vista previa (AttachPictureBox o AttachPreviewPanel).";
                return false;
            }

            void ClearUi()
            {
                Image? old = _pictureBox.Image;
                _pictureBox.Image = null;
                old?.Dispose();
                if (!_pictureBox.IsDisposed)
                    AplicarTamanoVistaPrevia();
            }

            if (string.IsNullOrWhiteSpace(zpl))
            {
                if (_pictureBox.InvokeRequired)
                    _pictureBox.BeginInvoke(ClearUi);
                else
                    ClearUi();
                return true;
            }

            Image? bmp = null;
            int? totalCount = null;

            try
            {
                (bmp, totalCount) = await RenderInternalAsync(zpl.Trim(),
                    NormalizeBaseUrl(ApiBaseUrl),
                    Dpmm,
                    WidthInches,
                    HeightInches,
                    LabelIndex,
                    OutputQuality,
                    ApiKey,
                    cancellationToken).ConfigureAwait(false);

                LastTotalLabelCount = totalCount;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
            }

            if (bmp == null && LastError == null)
                LastError = "El servicio devolvió una imagen vacía.";

            void Apply()
            {
                if (_pictureBox!.IsDisposed)
                {
                    bmp?.Dispose();
                    return;
                }

                Image? previous = _pictureBox.Image;
                _pictureBox.Image = bmp;
                previous?.Dispose();
                AplicarTamanoVistaPrevia();
            }

            if (_pictureBox.IsDisposed)
            {
                bmp?.Dispose();
                return false;
            }

            if (_pictureBox.InvokeRequired)
                _pictureBox.BeginInvoke(Apply);
            else
                Apply();

            return LastError == null;
        }

        /// <summary>Quita la imagen actual del destino.</summary>
        public void ClearPreview()
        {
            if (_pictureBox == null)
                return;

            void Clear()
            {
                Image? old = _pictureBox!.Image;
                _pictureBox.Image = null;
                old?.Dispose();
            }

            if (_pictureBox.InvokeRequired)
                _pictureBox.BeginInvoke(Clear);
            else
                Clear();

            LastError = null;
            LastTotalLabelCount = null;
        }

        public void Dispose() => ClearPreview();
    }
}
