using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace SisUvex.Inicio
{
    internal static class GraficosLogin
    {
        public static GraphicsPath RectanguloRedondeado(RectangleF rect, float radio)
        {
            float d = Math.Max(radio * 2, 1F);
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        public static Color Mezclar(Color origen, Color destino, float cantidad)
        {
            int Canal(int a, int b) => (int)Math.Round(a + (b - a) * cantidad);
            return Color.FromArgb(Canal(origen.R, destino.R), Canal(origen.G, destino.G), Canal(origen.B, destino.B));
        }
    }

    /// <summary>Panel con forma de píldora y borde en degradado, dibujado con suavizado.</summary>
    public class PanelPildora : Panel
    {
        private Color _colorInicio = Color.FromArgb(122, 44, 166);
        private Color _colorFin = Color.FromArgb(142, 205, 118);
        private float _grosor = 2F;

        public PanelPildora()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        }

        [Category("Appearance")]
        public Color ColorBordeInicio { get => _colorInicio; set { _colorInicio = value; Invalidate(); } }

        [Category("Appearance")]
        public Color ColorBordeFin { get => _colorFin; set { _colorFin = value; Invalidate(); } }

        [Category("Appearance"), DefaultValue(2F)]
        public float GrosorBorde { get => _grosor; set { _grosor = value; Invalidate(); } }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Parent?.BackColor ?? SystemColors.Control);
            if (Width < 4 || Height < 4)
                return;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            float mitad = _grosor / 2F;
            RectangleF rect = new RectangleF(mitad, mitad, Width - _grosor - 1, Height - _grosor - 1);
            using GraphicsPath path = GraficosLogin.RectanguloRedondeado(rect, rect.Height / 2F);

            using (SolidBrush relleno = new SolidBrush(BackColor))
                g.FillPath(relleno, path);

            using LinearGradientBrush degradado = new LinearGradientBrush(
                new Rectangle(0, 0, Width, Height), _colorInicio, _colorFin, 20F);
            using Pen lapiz = new Pen(degradado, _grosor);
            g.DrawPath(lapiz, path);
        }
    }

    /// <summary>Botón en forma de píldora con degradado horizontal.</summary>
    public class BotonDegradado : Button
    {
        private Color _colorInicio = Color.FromArgb(112, 40, 160);
        private Color _colorFin = Color.FromArgb(140, 205, 118);
        private bool _encima;
        private bool _presionado;

        public BotonDegradado()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            FlatStyle = FlatStyle.Flat;
            UseVisualStyleBackColor = false;
            Cursor = Cursors.Hand;
            ForeColor = Color.White;
        }

        [Category("Appearance")]
        public Color ColorInicio { get => _colorInicio; set { _colorInicio = value; Invalidate(); } }

        [Category("Appearance")]
        public Color ColorFin { get => _colorFin; set { _colorFin = value; Invalidate(); } }

        protected override void OnMouseEnter(EventArgs e) { _encima = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _encima = false; _presionado = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnMouseDown(MouseEventArgs e) { _presionado = true; Invalidate(); base.OnMouseDown(e); }
        protected override void OnMouseUp(MouseEventArgs e) { _presionado = false; Invalidate(); base.OnMouseUp(e); }
        protected override void OnEnabledChanged(EventArgs e) { Invalidate(); base.OnEnabledChanged(e); }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Parent?.BackColor ?? SystemColors.Control);
            if (Width < 4 || Height < 4)
                return;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            Color inicio = _colorInicio;
            Color fin = _colorFin;
            if (!Enabled)
            {
                inicio = Color.FromArgb(190, 190, 196);
                fin = Color.FromArgb(214, 214, 218);
            }
            else if (_presionado)
            {
                inicio = GraficosLogin.Mezclar(inicio, Color.Black, 0.18F);
                fin = GraficosLogin.Mezclar(fin, Color.Black, 0.18F);
            }
            else if (_encima)
            {
                inicio = GraficosLogin.Mezclar(inicio, Color.White, 0.14F);
                fin = GraficosLogin.Mezclar(fin, Color.White, 0.14F);
            }

            RectangleF rect = new RectangleF(0.5F, 0.5F, Width - 2, Height - 2);
            using GraphicsPath path = GraficosLogin.RectanguloRedondeado(rect, rect.Height / 2F);
            using LinearGradientBrush pincel = new LinearGradientBrush(
                new Rectangle(0, 0, Width, Height), inicio, fin, LinearGradientMode.Horizontal);
            g.FillPath(pincel, path);

            TextRenderer.DrawText(g, Text, Font, new Rectangle(0, 0, Width, Height), ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter |
                TextFormatFlags.SingleLine | TextFormatFlags.NoPadding);
        }
    }

    /// <summary>Cuadro de texto que muestra un texto gris cuando está vacío y sin foco.</summary>
    public class TextBoxMarcador : TextBox
    {
        private const int WM_PAINT = 0x000F;
        private string _marcador = "";
        private Color _colorMarcador = Color.FromArgb(150, 150, 156);

        [Category("Appearance"), DefaultValue("")]
        public string Marcador { get => _marcador; set { _marcador = value ?? ""; Invalidate(); } }

        [Category("Appearance")]
        public Color ColorMarcador { get => _colorMarcador; set { _colorMarcador = value; Invalidate(); } }

        protected override void OnGotFocus(EventArgs e) { base.OnGotFocus(e); Invalidate(); }
        protected override void OnLostFocus(EventArgs e) { base.OnLostFocus(e); Invalidate(); }
        protected override void OnTextChanged(EventArgs e) { base.OnTextChanged(e); Invalidate(); }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg != WM_PAINT || Text.Length != 0 || Focused || _marcador.Length == 0)
                return;

            TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.NoPadding;
            flags |= TextAlign switch
            {
                HorizontalAlignment.Center => TextFormatFlags.HorizontalCenter,
                HorizontalAlignment.Right => TextFormatFlags.Right,
                _ => TextFormatFlags.Left
            };

            using Graphics g = CreateGraphics();
            TextRenderer.DrawText(g, _marcador, Font, ClientRectangle, _colorMarcador, BackColor, flags);
        }
    }

    /// <summary>Panel que dibuja una imagen a todo el área (recortada al centro) y puede verla en blanco y negro.</summary>
    public class PanelImagenFondo : Panel
    {
        private Image? _imagen;
        private bool _escalaGrises;

        public PanelImagenFondo()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        }

        [Category("Appearance")]
        public Image? Imagen { get => _imagen; set { _imagen = value; Invalidate(); } }

        [Category("Appearance"), DefaultValue(false)]
        public bool EscalaGrises { get => _escalaGrises; set { _escalaGrises = value; Invalidate(); } }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.FromArgb(64, 64, 64));
            if (Width < 2 || Height < 2)
                return;

            if (_imagen != null)
            {
                float escala = Math.Max((float)Width / _imagen.Width, (float)Height / _imagen.Height);
                float origenAncho = Width / escala;
                float origenAlto = Height / escala;
                RectangleF origen = new RectangleF(
                    (_imagen.Width - origenAncho) / 2F,
                    (_imagen.Height - origenAlto) / 2F,
                    origenAncho,
                    origenAlto);

                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using ImageAttributes atributos = new ImageAttributes();
                if (_escalaGrises)
                {
                    ColorMatrix matriz = new ColorMatrix(new float[][]
                    {
                        new float[] { 0.299F, 0.299F, 0.299F, 0, 0 },
                        new float[] { 0.587F, 0.587F, 0.587F, 0, 0 },
                        new float[] { 0.114F, 0.114F, 0.114F, 0, 0 },
                        new float[] { 0, 0, 0, 1, 0 },
                        new float[] { 0, 0, 0, 0, 1 }
                    });
                    atributos.SetColorMatrix(matriz);
                }
                atributos.SetWrapMode(WrapMode.TileFlipXY);

                g.DrawImage(_imagen, new Rectangle(0, 0, Width, Height),
                    origen.X, origen.Y, origen.Width, origen.Height, GraphicsUnit.Pixel, atributos);
            }

            // Franja oscura abajo para que el texto de conexión se lea sobre cualquier parte de la imagen.
            int alto = Math.Min(72, Height);
            Rectangle franja = new Rectangle(0, Height - alto, Width, alto);
            using LinearGradientBrush sombra = new LinearGradientBrush(
                franja, Color.FromArgb(0, 0, 0, 0), Color.FromArgb(175, 0, 0, 0), LinearGradientMode.Vertical);
            g.FillRectangle(sombra, franja);
        }
    }

    public enum TipoIconoLinea
    {
        Menu,
        Cerrar
    }

    /// <summary>Botón plano que dibuja un icono de líneas (menú de tres rayas o X) con suavizado.</summary>
    public class BotonIconoLinea : Control
    {
        private TipoIconoLinea _tipo = TipoIconoLinea.Menu;
        private Color _colorNormal = Color.FromArgb(150, 150, 158);
        private Color _colorEncima = Color.FromArgb(122, 44, 166);
        private bool _encima;

        public BotonIconoLinea()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            TabStop = false;
            Cursor = Cursors.Hand;
        }

        [Category("Appearance"), DefaultValue(TipoIconoLinea.Menu)]
        public TipoIconoLinea Tipo { get => _tipo; set { _tipo = value; Invalidate(); } }

        [Category("Appearance")]
        public Color ColorNormal { get => _colorNormal; set { _colorNormal = value; Invalidate(); } }

        [Category("Appearance")]
        public Color ColorEncima { get => _colorEncima; set { _colorEncima = value; Invalidate(); } }

        protected override void OnMouseEnter(EventArgs e) { _encima = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _encima = false; Invalidate(); base.OnMouseLeave(e); }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Parent?.BackColor ?? SystemColors.Control);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using Pen lapiz = new Pen(_encima ? _colorEncima : _colorNormal, 1.7F)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round
            };

            float cx = Width / 2F;
            float cy = Height / 2F;

            if (_tipo == TipoIconoLinea.Menu)
            {
                float medio = 10F;
                g.DrawLine(lapiz, cx - medio, cy - 6F, cx + medio, cy - 6F);
                g.DrawLine(lapiz, cx - medio, cy, cx + medio, cy);
                g.DrawLine(lapiz, cx - medio, cy + 6F, cx + medio, cy + 6F);
            }
            else
            {
                float medio = 6F;
                g.DrawLine(lapiz, cx - medio, cy - medio, cx + medio, cy + medio);
                g.DrawLine(lapiz, cx - medio, cy + medio, cx + medio, cy - medio);
            }
        }
    }
}
