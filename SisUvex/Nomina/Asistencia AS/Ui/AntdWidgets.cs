using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SisUvex.Nomina.Asistencia_AS
{
    /// <summary>Paleta común del formulario de reporte de asistencia (mismo morado que FrmConfiguracion).</summary>
    internal static class AntdTheme
    {
        public static readonly Color Primary       = Color.FromArgb(122, 44, 166);
        public static readonly Color PrimaryHover  = Color.FromArgb(140, 66, 186);
        public static readonly Color PrimaryActive = Color.FromArgb(98, 28, 138);
        public static readonly Color PrimarySoft   = Color.FromArgb(240, 230, 250);
        public static readonly Color PrimarySofter = Color.FromArgb(225, 210, 245);
        public static readonly Color FormBack      = Color.FromArgb(244, 245, 250);
        public static readonly Color CardBorder    = Color.FromArgb(228, 228, 238);
        public static readonly Color InputBorder   = Color.FromArgb(206, 212, 224);
        public static readonly Color TextStrong    = Color.FromArgb(30, 41, 59);
        public static readonly Color TextNormal    = Color.FromArgb(51, 65, 85);
        public static readonly Color TextMuted     = Color.FromArgb(120, 130, 150);

        private static bool _applied;

        /// <summary>Aplica una sola vez el color primario de AntdUI (calendario, foco, botones primarios).</summary>
        public static void Apply()
        {
            if (_applied) return;
            _applied = true;
            AntdUI.Style.SetPrimary(Primary);
        }
    }

    /// <summary>Iconos SVG (24x24, un solo trazo relleno) para los botones AntdUI del formulario.</summary>
    internal static class AntdIcons
    {
        private static string Svg(string path)
            => "<svg viewBox=\"0 0 24 24\" xmlns=\"http://www.w3.org/2000/svg\"><path d=\"" + path + "\"/></svg>";

        public static readonly string Search = Svg("M15.5 14h-.79l-.28-.27A6.471 6.471 0 0 0 16 9.5 6.5 6.5 0 1 0 9.5 16c1.61 0 3.09-.59 4.23-1.57l.27.28v.79l5 4.99L20.49 19l-4.99-5zm-6 0C7.01 14 5 11.99 5 9.5S7.01 5 9.5 5 14 7.01 14 9.5 11.99 14 9.5 14z");
        public static readonly string Add = Svg("M19 13h-6v6h-2v-6H5v-2h6V5h2v6h6v2z");
        public static readonly string Play = Svg("M8 5v14l11-7z");
        public static readonly string Edit = Svg("M3 17.25V21h3.75L17.81 9.94l-3.75-3.75L3 17.25zM20.71 7.04a.996.996 0 0 0 0-1.41l-2.34-2.34a.996.996 0 0 0-1.41 0l-1.83 1.83 3.75 3.75 1.83-1.83z");
        public static readonly string Table = Svg("M20 2H4c-1.1 0-2 .9-2 2v16c0 1.1.9 2 2 2h16c1.1 0 2-.9 2-2V4c0-1.1-.9-2-2-2zM8 20H4v-4h4v4zm0-6H4v-4h4v4zm0-6H4V4h4v4zm6 12h-4v-4h4v4zm0-6h-4v-4h4v4zm0-6h-4V4h4v4zm6 12h-4v-4h4v4zm0-6h-4v-4h4v4zm0-6h-4V4h4v4z");
        public static readonly string Clear = Svg("M15 16h4v2h-4zm0-8h7v2h-7zm0 4h6v2h-6zM3 18c0 1.1.9 2 2 2h6c1.1 0 2-.9 2-2V8H3v10zM14 5h-3l-1-1H6L5 5H2v2h12z");
        public static readonly string Document = Svg("M14 2H6c-1.1 0-1.99.9-1.99 2L4 20c0 1.1.89 2 1.99 2H18c1.1 0 2-.9 2-2V8l-6-6zm2 16H8v-2h8v2zm0-4H8v-2h8v2zm-3-5V3.5L18.5 9H13z");
        public static readonly string Calendar = Svg("M19 4h-1V2h-2v2H8V2H6v2H5C3.89 4 3.01 4.9 3.01 6L3 20c0 1.1.89 2 2 2h14c1.1 0 2-.9 2-2V6c0-1.1-.9-2-2-2zm0 16H5V10h14v10zM5 8V6h14v2H5zm2 4h4v4H7z");
        public static readonly string List = Svg("M3 14h4v-4H3v4zm0 5h4v-4H3v4zM3 9h4V5H3v4zm5 5h13v-4H8v4zm0 5h13v-4H8v4zM8 5v4h13V5H8z");
        public static readonly string Settings = Svg("M19.14 12.94c.04-.3.06-.61.06-.94 0-.32-.02-.64-.07-.94l2.03-1.58a.49.49 0 0 0 .12-.61l-1.92-3.32a.488.488 0 0 0-.59-.22l-2.39.96c-.5-.38-1.03-.7-1.62-.94l-.36-2.54a.484.484 0 0 0-.48-.41h-3.84c-.24 0-.43.17-.47.41l-.36 2.54c-.59.24-1.13.57-1.62.94l-2.39-.96c-.22-.08-.47 0-.59.22L2.74 8.87c-.12.21-.08.47.12.61l2.03 1.58c-.05.3-.09.63-.09.94s.02.64.07.94l-2.03 1.58a.49.49 0 0 0-.12.61l1.92 3.32c.12.22.37.29.59.22l2.39-.96c.5.38 1.03.7 1.62.94l.36 2.54c.05.24.24.41.48.41h3.84c.24 0 .44-.17.47-.41l.36-2.54c.59-.24 1.13-.56 1.62-.94l2.39.96c.22.08.47 0 .59-.22l1.92-3.32c.12-.22.07-.47-.12-.61l-2.01-1.58zM12 15.6c-1.98 0-3.6-1.62-3.6-3.6s1.62-3.6 3.6-3.6 3.6 1.62 3.6 3.6-1.62 3.6-3.6 3.6z");
    }

    /// <summary>
    /// ComboBox con aspecto AntdUI (esquinas redondeadas, borde suave, flecha fina) que conserva
    /// todo el comportamiento de <see cref="ComboBox"/> (DataSource, SelectedItem, eventos, escritura).
    /// </summary>
    public class AntdComboBox : ComboBox
    {
        private const int WM_PAINT = 0x000F;
        private const int WM_ERASEBKGND = 0x0014;

        private bool _hot;

        /// <summary>Color que rodea el control (fondo de la tarjeta), para rellenar las esquinas.</summary>
        [Category("Appearance")]
        public Color OuterColor { get; set; } = Color.White;

        [Category("Appearance")]
        public Color BorderColorNormal { get; set; } = AntdTheme.InputBorder;

        [Category("Appearance")]
        public Color BorderColorActive { get; set; } = AntdTheme.Primary;

        [Category("Appearance")]
        public int CornerRadius { get; set; } = 6;

        public AntdComboBox()
        {
            BackColor = Color.White;
            FlatStyle = FlatStyle.Standard;
            MouseEnter += (_, _) => SetHot(true);
            MouseLeave += (_, _) => SetHot(false);
            GotFocus += (_, _) => Invalidate();
            LostFocus += (_, _) => Invalidate();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            StyleEditChild();
        }

        /// <summary>Quita el borde del cuadro de texto interno (combos editables) y le da un margen interior.</summary>
        private void StyleEditChild()
        {
            if (DropDownStyle == ComboBoxStyle.DropDownList) return;

            COMBOBOXINFO info = new() { cbSize = Marshal.SizeOf<COMBOBOXINFO>() };
            if (!GetComboBoxInfo(Handle, ref info) || info.hwndItem == IntPtr.Zero) return;

            IntPtr edit = info.hwndItem;
            int ex = GetWindowLong(edit, GWL_EXSTYLE) & ~WS_EX_CLIENTEDGE;
            int st = GetWindowLong(edit, GWL_STYLE) & ~WS_BORDER;
            SetWindowLong(edit, GWL_EXSTYLE, ex);
            SetWindowLong(edit, GWL_STYLE, st);
            SetWindowPos(edit, IntPtr.Zero, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER | SWP_FRAMECHANGED);
            SendMessage(edit, EM_SETMARGINS, (IntPtr)(EC_LEFTMARGIN | EC_RIGHTMARGIN), (IntPtr)((2 << 16) | 6));
        }

        private void SetHot(bool hot)
        {
            if (_hot == hot) return;
            _hot = hot;
            Invalidate();
        }

        protected override void WndProc(ref Message m)
        {
            bool selfDraw = DropDownStyle == ComboBoxStyle.DropDownList;

            if (selfDraw && m.Msg == WM_ERASEBKGND)
            {
                m.Result = (IntPtr)1;
                return;
            }

            if (selfDraw && m.Msg == WM_PAINT && IsHandleCreated)
            {
                PAINTSTRUCT ps = new();
                IntPtr hdc = m.WParam != IntPtr.Zero ? m.WParam : BeginPaint(Handle, ref ps);
                try
                {
                    using Graphics g = Graphics.FromHdc(hdc);
                    DrawFull(g);
                }
                finally
                {
                    if (m.WParam == IntPtr.Zero)
                        EndPaint(Handle, ref ps);
                }
                m.Result = IntPtr.Zero;
                return;
            }

            base.WndProc(ref m);

            if (!selfDraw && m.Msg == WM_PAINT && IsHandleCreated)
            {
                IntPtr hdc = GetDC(Handle);
                if (hdc == IntPtr.Zero) return;
                try
                {
                    using Graphics g = Graphics.FromHdc(hdc);
                    DrawOverlay(g);
                }
                finally
                {
                    ReleaseDC(Handle, hdc);
                }
            }
        }

        /// <summary>Permite a las clases derivadas mantener resaltado el borde (p. ej. con un popup propio abierto).</summary>
        protected virtual bool ForceActive => false;

        /// <summary>Texto que se dibuja en el control cuando es de solo lista.</summary>
        protected virtual string GetCaptionText()
            => SelectedIndex >= 0 ? GetItemText(SelectedItem) : string.Empty;

        private bool IsActive => Focused || ContainsFocus || DroppedDown || ForceActive;

        private GraphicsPath BuildPath(Rectangle r)
        {
            int d = Math.Max(2, CornerRadius * 2);
            Rectangle b = new(r.X, r.Y, r.Width - 1, r.Height - 1);
            GraphicsPath path = new();
            path.AddArc(b.X, b.Y, d, d, 180, 90);
            path.AddArc(b.Right - d, b.Y, d, d, 270, 90);
            path.AddArc(b.Right - d, b.Bottom - d, d, d, 0, 90);
            path.AddArc(b.X, b.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private Color CurrentBorder()
        {
            if (!Enabled) return Color.FromArgb(222, 226, 235);
            if (IsActive || _hot) return BorderColorActive;
            return BorderColorNormal;
        }

        private void DrawChevron(Graphics g, Rectangle area)
        {
            int cx = area.X + area.Width / 2;
            int cy = area.Y + area.Height / 2;
            Color c = Enabled ? Color.FromArgb(110, 118, 140) : Color.FromArgb(180, 186, 200);
            using Pen pen = new(c, 1.6f) { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round };
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawLines(pen, new[] { new PointF(cx - 4, cy - 2), new PointF(cx, cy + 2), new PointF(cx + 4, cy - 2) });
        }

        private void DrawFull(Graphics g)
        {
            Rectangle r = ClientRectangle;
            if (r.Width <= 2 || r.Height <= 2) return;

            using (SolidBrush outer = new(OuterColor))
                g.FillRectangle(outer, r);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            Color fill = Enabled ? Color.White : Color.FromArgb(245, 246, 250);
            using GraphicsPath path = BuildPath(r);
            using (SolidBrush b = new(fill))
                g.FillPath(b, path);
            using (Pen p = new(CurrentBorder(), 1f))
                g.DrawPath(p, path);

            const int arrowW = 26;
            Rectangle arrow = new(r.Right - arrowW, r.Y, arrowW, r.Height);
            Rectangle text = new(r.X + 9, r.Y + 1, r.Width - arrowW - 12, r.Height - 2);

            string caption = GetCaptionText();
            Color fore = Enabled ? AntdTheme.TextNormal : Color.FromArgb(150, 158, 175);
            TextRenderer.DrawText(g, caption, Font, text, fore,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPadding);

            DrawChevron(g, arrow);
        }

        private void DrawOverlay(Graphics g)
        {
            Rectangle r = ClientRectangle;
            if (r.Width <= 2 || r.Height <= 2) return;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            using GraphicsPath path = BuildPath(r);

            // Esquinas: rellena todo lo que queda fuera del rectángulo redondeado.
            GraphicsState state = g.Save();
            g.SetClip(path, CombineMode.Exclude);
            using (SolidBrush outer = new(OuterColor))
                g.FillRectangle(outer, r);
            g.Restore(state);

            // Botón de la lista desplegable.
            COMBOBOXINFO info = new() { cbSize = Marshal.SizeOf<COMBOBOXINFO>() };
            Rectangle button = new(r.Right - 24, r.Y + 1, 23, r.Height - 2);
            if (GetComboBoxInfo(Handle, ref info))
            {
                Rectangle rc = Rectangle.FromLTRB(info.rcButton.Left, info.rcButton.Top, info.rcButton.Right, info.rcButton.Bottom);
                if (rc.Width > 0 && rc.Height > 0)
                    button = rc;
            }

            GraphicsState state2 = g.Save();
            g.SetClip(path, CombineMode.Intersect);
            using (SolidBrush b = new(BackColor))
                g.FillRectangle(b, button);
            g.Restore(state2);
            DrawChevron(g, button);

            using Pen p = new(CurrentBorder(), 1f);
            g.DrawPath(p, path);
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT { public int Left, Top, Right, Bottom; }

        [StructLayout(LayoutKind.Sequential)]
        private struct COMBOBOXINFO
        {
            public int cbSize;
            public RECT rcItem;
            public RECT rcButton;
            public int stateButton;
            public IntPtr hwndCombo;
            public IntPtr hwndItem;
            public IntPtr hwndList;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct PAINTSTRUCT
        {
            public IntPtr hdc;
            public bool fErase;
            public RECT rcPaint;
            public bool fRestore;
            public bool fIncUpdate;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] rgbReserved;
        }

        private const int GWL_STYLE = -16;
        private const int GWL_EXSTYLE = -20;
        private const int WS_BORDER = 0x00800000;
        private const int WS_EX_CLIENTEDGE = 0x00000200;
        private const uint SWP_NOSIZE = 0x0001, SWP_NOMOVE = 0x0002, SWP_NOZORDER = 0x0004, SWP_FRAMECHANGED = 0x0020;
        private const int EM_SETMARGINS = 0x00D3;
        private const int EC_LEFTMARGIN = 0x0001, EC_RIGHTMARGIN = 0x0002;

        [DllImport("user32.dll")] private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")] private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll")] private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint flags);
        [DllImport("user32.dll")] private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")] private static extern IntPtr BeginPaint(IntPtr hWnd, ref PAINTSTRUCT lpPaint);
        [DllImport("user32.dll")] private static extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT lpPaint);
        [DllImport("user32.dll")] private static extern IntPtr GetDC(IntPtr hWnd);
        [DllImport("user32.dll")] private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("user32.dll")] private static extern bool GetComboBoxInfo(IntPtr hwndCombo, ref COMBOBOXINFO pcbi);
    }

    /// <summary>
    /// <see cref="AntdUI.DatePicker"/> que expone <see cref="Value"/> como <see cref="DateTime"/> (igual que
    /// <see cref="DateTimePicker"/>), para que el resto del código no cambie.
    /// </summary>
    public class AntdDatePicker : AntdUI.DatePicker
    {
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DateTime Value
        {
            get => base.Value ?? DateTime.Today;
            set => base.Value = value;
        }
    }

    /// <summary>
    /// Botón AntdUI que se queda presionado (alternancia). Expone <see cref="Checked"/> y
    /// <see cref="CheckedChanged"/> con la misma forma que <see cref="CheckBox"/> en modo botón.
    /// </summary>
    public class AntdToggleButton : AntdUI.Button
    {
        private bool _lastChecked;

        public AntdToggleButton()
        {
            AutoToggle = true;
            ToggleChanged += (_, _) => RaiseIfChanged();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Checked
        {
            get => Toggle;
            set
            {
                if (Toggle == value) return;
                Toggle = value;
                RaiseIfChanged();
            }
        }

        public event EventHandler? CheckedChanged;

        private void RaiseIfChanged()
        {
            bool now = Toggle;
            if (now == _lastChecked) return;
            _lastChecked = now;
            CheckedChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    /// <summary>Barra de progreso delgada y redondeada con los colores del formulario (misma API que ProgressBar).</summary>
    public class AntdProgressBar : ProgressBar
    {
        public AntdProgressBar()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint
                     | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color back = Parent?.BackColor ?? AntdTheme.FormBack;
            g.Clear(back);

            Rectangle track = new(0, 0, Width - 1, Height - 1);
            if (track.Width <= 2 || track.Height <= 2) return;

            using GraphicsPath trackPath = Rounded(track);
            using (SolidBrush b = new(Color.FromArgb(226, 220, 238)))
                g.FillPath(b, trackPath);

            int range = Maximum - Minimum;
            if (range <= 0 || Value <= Minimum) return;

            double ratio = Math.Min(1d, (double)(Value - Minimum) / range);
            int w = Math.Max(track.Height, (int)Math.Round(track.Width * ratio));
            Rectangle bar = new(track.X, track.Y, Math.Min(w, track.Width), track.Height);

            using GraphicsPath barPath = Rounded(bar);
            using LinearGradientBrush grad = new(bar, AntdTheme.Primary, AntdTheme.PrimaryHover, LinearGradientMode.Horizontal);
            g.FillPath(grad, barPath);
        }

        private static GraphicsPath Rounded(Rectangle r)
        {
            int d = Math.Max(2, r.Height);
            GraphicsPath p = new();
            p.AddArc(r.X, r.Y, d, d, 90, 180);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 180);
            p.CloseFigure();
            return p;
        }
    }

    /// <summary>Resalta el borde de un panel AntdUI que hace de "caja de texto" cuando el control interno tiene el foco.</summary>
    internal static class AntdInputHost
    {
        public static void Bind(AntdUI.Panel host, Control inner)
        {
            host.BorderColor = AntdTheme.InputBorder;

            void Active() => host.BorderColor = AntdTheme.Primary;
            void Normal() => host.BorderColor = AntdTheme.InputBorder;

            inner.Enter += (_, _) => Active();
            inner.Leave += (_, _) => Normal();
            inner.MouseEnter += (_, _) => { if (!inner.Focused) Active(); };
            inner.MouseLeave += (_, _) => { if (!inner.Focused) Normal(); };
            host.Click += (_, _) => inner.Focus();
        }
    }
}
