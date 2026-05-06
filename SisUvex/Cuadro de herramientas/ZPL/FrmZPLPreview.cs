using System;
using System.Drawing.Printing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
using SisUvex;

namespace SisUvex.Cuadro_de_herramientas.ZPL
{
    public partial class FrmZPLPreview : Form
    {
        private readonly int[] _dpmmValores = { 6, 8, 12, 24 };
        private bool _cambiandoUnidad;
        private bool _resaltandoZpl;
        private readonly Timer _timerResaltadoZpl;
        private readonly ClsZplPreview _zplPreview = new();

        public FrmZPLPreview()
        {
            InitializeComponent();
            InicializarControlesOpciones();

            _timerResaltadoZpl = new Timer { Interval = 130 };
            _timerResaltadoZpl.Tick += (_, _) =>
            {
                _timerResaltadoZpl.Stop();
                AplicarResaltadoZpl();
            };

            rtbZpl.TextChanged += (_, _) =>
            {
                if (_resaltandoZpl)
                    return;
                _timerResaltadoZpl.Stop();
                _timerResaltadoZpl.Start();
            };
            rtbZpl.DetectUrls = false;

            _zplPreview.AttachPreviewPanel(pnlPreview);
            _zplPreview.ZoomPercent = trackZoom.Value;
            ActualizarEtiquetaZoom();

            trackZoom.ValueChanged += (_, _) =>
            {
                _zplPreview.ZoomPercent = trackZoom.Value;
                ActualizarEtiquetaZoom();
            };
            btnZoomMenos.Click += (_, _) =>
            {
                int v = Math.Max(trackZoom.Minimum, trackZoom.Value - 10);
                if (v != trackZoom.Value)
                    trackZoom.Value = v;
            };
            btnZoomMas.Click += (_, _) =>
            {
                int v = Math.Min(trackZoom.Maximum, trackZoom.Value + 10);
                if (v != trackZoom.Value)
                    trackZoom.Value = v;
            };
            btnZoom100.Click += (_, _) => trackZoom.Value = 100;

            btnActualizarPreview.Click += async (_, _) => await ActualizarVistaAsync();
            btnImprimirZpl.Click += BtnImprimirZpl_Click;
            cboUnidad.SelectedIndexChanged += CboUnidad_SelectedIndexChanged;

            Load += (_, _) =>
            {
                CargarImpresoras();
                ActualizarLblTotalPrecheck();
                BeginInvoke(AplicarResaltadoZpl);
            };
            Shown += async (_, _) => await ActualizarVistaAsync();
        }

        public ClsZplPreview ServicioPreview => _zplPreview;

        private void ActualizarEtiquetaZoom()
        {
            lblZoomPct.Text = $"{trackZoom.Value} %";
        }

        private void AplicarResaltadoZpl()
        {
            if (rtbZpl.IsDisposed)
                return;

            _resaltandoZpl = true;
            try
            {
                ClsZplRichHighlighter.Aplicar(rtbZpl);
            }
            finally
            {
                _resaltandoZpl = false;
            }
        }

        private void InicializarControlesOpciones()
        {
            cboDpmm.Items.Clear();
            cboDpmm.Items.AddRange([
                "6 dpmm (~152 dpi)",
                "8 dpmm (~203 dpi)",
                "12 dpmm (~300 dpi)",
                "24 dpmm (~600 dpi)"
            ]);
            cboDpmm.SelectedIndex = 1;

            cboCalidad.Items.Clear();
            cboCalidad.Items.Add("Grayscale (grises, recomendado)");
            cboCalidad.Items.Add("Bitonal (1 bit, menor tamaño)");
            cboCalidad.SelectedIndex = 0;

            cboUnidad.Items.Clear();
            cboUnidad.Items.Add("pulgadas (in)");
            cboUnidad.Items.Add("milímetros (mm)");
            cboUnidad.SelectedIndex = 0;

            lblTotalEtiquetas.Text = "?";

            ToolTip tip = new();
            tip.SetToolTip(cboDpmm,
                "Puntos por milímetro. Debe coincidir con la resolución de la impresora/diseño.");
            tip.SetToolTip(cboCalidad,
                "Grayscale por defecto Labelary (X-Quality). Bitonal para archivos PNG más compactos.");
            tip.SetToolTip(txbApiHost,
                "Ej.: https://api.labelary.com o tu servidor Labelary. Vacío = API pública.");
            tip.SetToolTip(txbApiKey,
                "Solo si tu servidor exige token (p. ej. Bearer). La API pública no lo requiere.");
        }

        private void CargarImpresoras()
        {
            string? previa = cboImpresora.Text;

            cboImpresora.BeginUpdate();
            try
            {
                cboImpresora.Items.Clear();
                foreach (string p in PrinterSettings.InstalledPrinters)
                    cboImpresora.Items.Add(p);

                string def = new PrinterSettings().PrinterName;
                if (!string.IsNullOrEmpty(def) && cboImpresora.Items.Contains(def))
                    cboImpresora.Text = def;
                else if (!string.IsNullOrEmpty(previa) && cboImpresora.Items.Contains(previa))
                    cboImpresora.Text = previa;
                else if (cboImpresora.Items.Count > 0)
                    cboImpresora.SelectedIndex = 0;
            }
            finally
            {
                cboImpresora.EndUpdate();
            }
        }

        private void CboUnidad_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_cambiandoUnidad || cboUnidad.SelectedIndex < 0)
                return;

            bool aMm = cboUnidad.SelectedIndex == 1;
            _cambiandoUnidad = true;
            try
            {
                if (aMm)
                {
                    nudAncho.Value = ClampDecimal((decimal)nudAncho.Value * 25.4m, nudAncho.Minimum, nudAncho.Maximum);
                    nudAlto.Value = ClampDecimal((decimal)nudAlto.Value * 25.4m, nudAlto.Minimum, nudAlto.Maximum);
                }
                else
                {
                    nudAncho.Value = ClampDecimal((decimal)nudAncho.Value / 25.4m, nudAncho.Minimum, nudAncho.Maximum);
                    nudAlto.Value = ClampDecimal((decimal)nudAlto.Value / 25.4m, nudAlto.Minimum, nudAlto.Maximum);
                }
            }
            finally
            {
                _cambiandoUnidad = false;
            }
        }

        private static decimal ClampDecimal(decimal v, decimal min, decimal max)
        {
            if (v < min) return min;
            if (v > max) return max;
            return v;
        }

        private void AplicarParametrosAPreview()
        {
            _zplPreview.Dpmm = _dpmmValores[Math.Clamp(cboDpmm.SelectedIndex, 0, _dpmmValores.Length - 1)];
            _zplPreview.OutputQuality = cboCalidad.SelectedIndex == 1 ? "Bitonal" : "Grayscale";

            bool mm = cboUnidad.SelectedIndex == 1;
            double w = (double)nudAncho.Value;
            double h = (double)nudAlto.Value;
            if (mm)
            {
                w /= 25.4;
                h /= 25.4;
            }

            _zplPreview.WidthInches = w;
            _zplPreview.HeightInches = h;
            _zplPreview.LabelIndex = Math.Max(0, (int)nudEtiqueta.Value - 1);

            _zplPreview.ApiBaseUrl = NormalizarHostApi(txbApiHost.Text);
            _zplPreview.ApiKey = string.IsNullOrWhiteSpace(txbApiKey.Text) ? null : txbApiKey.Text.Trim();
        }

        private static string NormalizarHostApi(string texto)
        {
            string t = texto.Trim();
            if (string.IsNullOrEmpty(t))
                return "https://api.labelary.com";
            if (t.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                t.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                return t.TrimEnd('/');
            return "https://" + t.Trim().TrimEnd('/');
        }

        private void ActualizarLblTotalPrecheck()
        {
            lblTotalEtiquetas.Text = "?";
        }

        private async Task ActualizarVistaAsync()
        {
            lblEstado.Text = "Generando vista previa…";
            lblEstado.ForeColor = System.Drawing.SystemColors.ControlText;
            Enabled = false;
            try
            {
                AplicarParametrosAPreview();

                bool ok = await _zplPreview.ShowPreviewAsync(rtbZpl.Text).ConfigureAwait(true);

                if (_zplPreview.LastTotalLabelCount is { } tot)
                {
                    lblTotalEtiquetas.Text = tot.ToString(CultureInfo.InvariantCulture);
                    nudEtiqueta.Maximum = Math.Max(1, tot);
                }
                else
                {
                    lblTotalEtiquetas.Text = "?";
                }

                if (ok && string.IsNullOrEmpty(_zplPreview.LastError))
                    lblEstado.Text = "Vista previa actualizada.";
                else
                    MostrarError(_zplPreview.LastError ?? "Sin detalle.");
            }
            finally
            {
                Enabled = true;
            }
        }

        private void MostrarError(string mensaje)
        {
            lblEstado.Text = "Error: " + mensaje;
            lblEstado.ForeColor = System.Drawing.Color.DarkRed;
        }

        private void BtnImprimirZpl_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtbZpl.Text))
            {
                MessageBox.Show("No hay código ZPL para imprimir.", "ZPL", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            string impresora = cboImpresora.Text?.Trim() ?? "";
            if (string.IsNullOrEmpty(impresora))
            {
                MessageBox.Show("Selecciona una impresora.", "ZPL", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                RawPrinterHelper.SendStringToPrinter(impresora, rtbZpl.Text);
                lblEstado.ForeColor = System.Drawing.SystemColors.ControlText;
                lblEstado.Text = "ZPL enviado a impresora: " + impresora;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo imprimir: " + ex.Message, "ZPL", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _timerResaltadoZpl.Stop();
            _timerResaltadoZpl.Dispose();
            _zplPreview.Dispose();
            base.OnFormClosed(e);
        }
    }
}
