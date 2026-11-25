using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SisUvex.Nomina.Asistencia_AS
{
    /// <summary>
    /// Línea con tirador (una "píldora" al centro) que se arrastra verticalmente para cambiar el alto de un
    /// contenedor. No redimensiona nada por sí sola: avisa con <see cref="DragStarted"/> y
    /// <see cref="DragMoved"/> (desplazamiento vertical total en píxeles desde que se empezó a arrastrar).
    /// </summary>
    public sealed class AntdResizeGrip : Control
    {
        private bool _hot;
        private bool _dragging;
        private int _startScreenY;

        public event EventHandler? DragStarted;
        public event EventHandler<int>? DragMoved;
        public event EventHandler? DragEnded;

        [Category("Appearance")]
        public Color LineColor { get; set; } = AntdTheme.CardBorder;

        [Category("Appearance")]
        public Color HandleColor { get; set; } = Color.FromArgb(196, 184, 216);

        [Category("Appearance")]
        public Color HandleColorActive { get; set; } = AntdTheme.Primary;

        public AntdResizeGrip()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, false);
            TabStop = false;
            Cursor = Cursors.SizeNS;
            BackColor = Color.White;
            Height = 8;
        }

        protected override Size DefaultSize => new(200, 8);

        public bool IsDragging => _dragging;

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _hot = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _hot = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button != MouseButtons.Left) return;

            _dragging = true;
            _startScreenY = Cursor.Position.Y;
            Capture = true;
            DragStarted?.Invoke(this, EventArgs.Empty);
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!_dragging) return;
            DragMoved?.Invoke(this, Cursor.Position.Y - _startScreenY);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (!_dragging) return;

            _dragging = false;
            Capture = false;
            DragEnded?.Invoke(this, EventArgs.Empty);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(BackColor);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int midY = Height / 2;
            using (Pen line = new(LineColor))
                g.DrawLine(line, 0, midY, Width, midY);

            int handleW = Math.Min(Width, (int)Math.Round(64 * DeviceDpi / 96f));
            int handleH = Math.Max(4, (int)Math.Round(5 * DeviceDpi / 96f));
            Rectangle r = new((Width - handleW) / 2, midY - handleH / 2, handleW, handleH);

            using GraphicsPath path = new();
            int d = r.Height;
            path.AddArc(r.Left, r.Top, d, d, 90, 180);
            path.AddArc(r.Right - d, r.Top, d, d, 270, 180);
            path.CloseFigure();

            using SolidBrush fill = new(_hot || _dragging ? HandleColorActive : HandleColor);
            g.FillPath(fill, path);
        }
    }
}
