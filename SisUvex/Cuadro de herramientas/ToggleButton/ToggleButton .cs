using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
using SisUvex.Cuadro_de_herramientas.Colors;

namespace SisUvex.Cuadro_de_herramientas
{
    public enum ToggleButtonShape
    {
        Pill,
        RoundedRectangle
    }

    public class ToggleButton : CheckBox
    {
        private readonly Timer animationTimer = new Timer();
        private float togglePosition = 2f;
        private float targetPosition = 2f;
        private bool isFocused = false;
        private ToggleButtonShape toggleShape = ToggleButtonShape.Pill;

        [Category("Apariencia")]
        [Description("Forma del interruptor.")]
        [DefaultValue(ToggleButtonShape.Pill)]
        public ToggleButtonShape ToggleShape
        {
            get => toggleShape;
            set
            {
                if (toggleShape == value)
                    return;

                toggleShape = value;
                UpdateTargetPosition();

                if (!animationTimer.Enabled)
                    togglePosition = targetPosition;

                Invalidate();
            }
        }

        [Category("Apariencia")]
        [Description("Radio de las esquinas cuando ToggleShape es RoundedRectangle.")]
        [DefaultValue(4)]
        public int CornerRadius { get; set; } = 4;

        [Category("Apariencia")]
        [Description("Color del borde en estilo RoundedRectangle. Si está vacío, se usa ToggleColor (apagado) o FocusBorderColor (encendido).")]
        public Color BorderColor { get; set; } = Color.Empty;

        [Category("Apariencia")]
        [Description("Margen extra del cuadro interior en estilo RoundedRectangle.")]
        [DefaultValue(2)]
        public int ThumbInset { get; set; } = 2;

        public Color OnBackColor { get; set; } = ColorUvex.Purple;
        public Color OffBackColor { get; set; } = Color.LightGray;
        public Color ToggleColor { get; set; } = Color.White;
        public Color FocusBorderColor { get; set; } = ColorUvex.Purple;
        public Color FocusBackColor { get; set; } = ColorUvex.Purplely;

        public int AnimationSpeed { get; set; } = 4;

        public ToggleButton()
        {
            MinimumSize = new Size(20, 10);
            Size = new Size(40, 20);
            AutoSize = false;
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
            int thumbSize = GetThumbSize();
            int thumbOffset = GetThumbOffset();

            targetPosition = Checked
                ? Width - thumbSize - thumbOffset
                : thumbOffset;
        }

        private int GetPaddingSize()
        {
            return Height <= 14 ? 1 : 2;
        }

        private int GetThumbSize()
        {
            int padding = GetPaddingSize();
            int maxSize = Math.Max(Height - padding * 2, 1);

            if (toggleShape == ToggleButtonShape.RoundedRectangle)
                return Math.Max(maxSize - ThumbInset * 2, 1);

            return maxSize;
        }

        private int GetThumbOffset()
        {
            int padding = GetPaddingSize();
            int maxSize = Math.Max(Height - padding * 2, 1);
            int thumbSize = GetThumbSize();

            return padding + (maxSize - thumbSize) / 2;
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

            if (toggleShape == ToggleButtonShape.RoundedRectangle)
                PaintRoundedRectangle(g);
            else
                PaintPill(g);
        }

        private Color GetTrackBackColor()
        {
            return Checked ? OnBackColor : OffBackColor;
        }

        private Color GetFocusRingColor()
        {
            return FocusBackColor;
        }

        private float GetBorderWidth()
        {
            return Height <= 21 ? 1.2f : 1.6f;
        }

        private void PaintPill(Graphics g)
        {
            int padding = GetPaddingSize();
            int diameter = GetThumbSize();
            Rectangle backRect = new Rectangle(0, 0, Width - 1, Height - 1);

            using (GraphicsPath backPath = GetPillPath(backRect))
            using (SolidBrush backBrush = new SolidBrush(GetTrackBackColor()))
            {
                g.FillPath(backBrush, backPath);

                if (isFocused)
                {
                    float focusWidth = GetBorderWidth();
                    Rectangle focusRect = new Rectangle(1, 1, Width - 3, Height - 3);

                    using (GraphicsPath focusPath = GetPillPath(focusRect))
                    using (Pen focusPen = new Pen(GetFocusRingColor(), focusWidth))
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

        private void PaintRoundedRectangle(Graphics g)
        {
            int thumbSize = GetThumbSize();
            Rectangle backRect = new Rectangle(0, 0, Width - 1, Height - 1);
            int trackRadius = GetEffectiveCornerRadius(backRect);

            using (GraphicsPath backPath = CreateRoundedRectanglePath(backRect, trackRadius))
            using (SolidBrush backBrush = new SolidBrush(GetTrackBackColor()))
            {
                g.FillPath(backBrush, backPath);
            }

            float borderWidth = GetBorderWidth();
            using (GraphicsPath borderPath = CreateRoundedRectanglePath(backRect, trackRadius))
            using (Pen borderPen = new Pen(GetEffectiveBorderColor(), borderWidth))
            {
                borderPen.Alignment = PenAlignment.Inset;
                g.DrawPath(borderPen, borderPath);
            }

            Rectangle thumbRect = new Rectangle(
                (int)Math.Round(togglePosition),
                GetThumbOffset(),
                thumbSize,
                thumbSize);

            int thumbRadius = Math.Min(GetEffectiveCornerRadius(thumbRect), Math.Max(2, thumbSize / 4));

            using (GraphicsPath thumbPath = CreateRoundedRectanglePath(thumbRect, thumbRadius))
            using (SolidBrush toggleBrush = new SolidBrush(ToggleColor))
            {
                g.FillPath(toggleBrush, thumbPath);
            }
        }

        private int GetEffectiveCornerRadius(Rectangle rect)
        {
            return Math.Max(0, Math.Min(CornerRadius, Math.Min(rect.Width, rect.Height) / 2));
        }

        private Color GetEffectiveBorderColor()
        {
            if (isFocused)
                return GetFocusRingColor();

            if (BorderColor != Color.Empty)
                return BorderColor;

            return Checked ? FocusBorderColor : OffBackColor;
        }

        private GraphicsPath GetPillPath(Rectangle rect)
        {
            GraphicsPath path = new GraphicsPath();
            int arc = rect.Height;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, arc, arc, 90, 180);
            path.AddArc(rect.Right - arc, rect.Y, arc, arc, 270, 180);
            path.CloseFigure();

            return path;
        }

        private static GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int r = Math.Max(0, Math.Min(radius, Math.Min(rect.Width, rect.Height) / 2));

            if (r <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            int d = r * 2;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}
