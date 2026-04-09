using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
using SisUvex.Cuadro_de_herramientas.Colors;

namespace SisUvex.Cuadro_de_herramientas
{
    public class ToggleButton : CheckBox
    {
        private readonly Timer animationTimer = new Timer();
        private float togglePosition = 2f;
        private float targetPosition = 2f;
        private bool isFocused = false;

        public Color OnBackColor { get; set; } = ColorUvex.Purple;
        public Color OffBackColor { get; set; } = Color.LightGray;
        public Color ToggleColor { get; set; } = Color.White;
        public Color FocusBorderColor { get; set; } = ColorUvex.Purple;
        public Color FocusBackColor { get; set; } = ColorUvex.Purplely; //ColorUvex.PurpleMedium;

        public int AnimationSpeed { get; set; } = 4;

        public ToggleButton()
        {
            MinimumSize = new Size(20, 10);
            Size = new Size(40, 20);
            TabStop = true;
            Appearance = Appearance.Button;

            animationTimer.Interval = 10;
            animationTimer.Tick += AnimateToggle;

            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor,
                true);

            BackColor = Color.Transparent;

            UpdateTargetPosition();
            togglePosition = targetPosition;
        }

        protected override void OnCheckedChanged(EventArgs e)
        {
            base.OnCheckedChanged(e);
            UpdateTargetPosition();
            animationTimer.Start();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (Height < 10)
                Height = 10;

            UpdateTargetPosition();

            if (!animationTimer.Enabled)
                togglePosition = targetPosition;

            Invalidate();
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            isFocused = true;
            Invalidate();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            isFocused = false;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            Focus();
        }

        private void UpdateTargetPosition()
        {
            int padding = GetPaddingSize();
            int diameter = Math.Max(Height - padding * 2, 1);

            targetPosition = Checked
                ? Width - diameter - padding
                : padding;
        }

        private int GetPaddingSize()
        {
            return Height <= 14 ? 1 : 2;
        }

        private void AnimateToggle(object? sender, EventArgs e)
        {
            if (Math.Abs(togglePosition - targetPosition) < 0.5f)
            {
                togglePosition = targetPosition;
                animationTimer.Stop();
            }
            else
            {
                togglePosition += (targetPosition - togglePosition) / AnimationSpeed;
            }

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;

            Color parentBackColor = Parent?.BackColor ?? SystemColors.Control;
            g.Clear(parentBackColor);

            int padding = GetPaddingSize();
            int diameter = Math.Max(Height - padding * 2, 1);
            Rectangle backRect = new Rectangle(0, 0, Width - 1, Height - 1);

            Color currentBackColor = isFocused
                ? FocusBackColor
                : (Checked ? OnBackColor : OffBackColor);

            using (GraphicsPath backPath = GetFigurePath(backRect))
            using (SolidBrush backBrush = new SolidBrush(currentBackColor))
            {
                g.FillPath(backBrush, backPath);

                if (isFocused)
                {
                    float focusWidth = Height <= 21 ? 1.2f : 1.6f;
                    Rectangle focusRect = new Rectangle(1, 1, Width - 3, Height - 3);

                    using (GraphicsPath focusPath = GetFigurePath(focusRect))
                    using (Pen focusPen = new Pen(FocusBorderColor, focusWidth))
                    {
                        focusPen.Alignment = PenAlignment.Center;
                        g.DrawPath(focusPen, focusPath);
                    }
                }
            }

            using (SolidBrush toggleBrush = new SolidBrush(ToggleColor))
            {
                g.FillEllipse(toggleBrush, togglePosition, padding, diameter, diameter);
            }
        }

        private GraphicsPath GetFigurePath(Rectangle rect)
        {
            GraphicsPath path = new GraphicsPath();
            int arc = rect.Height;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, arc, arc, 90, 180);
            path.AddArc(rect.Right - arc, rect.Y, arc, arc, 270, 180);
            path.CloseFigure();

            return path;
        }
    }
}