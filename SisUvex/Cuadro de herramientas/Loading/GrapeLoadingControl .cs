using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SisUvex.Cuadro_de_herramientas.Loading
{
    public class GrapeLoadingControl : Control
    {
        private readonly System.Windows.Forms.Timer timer;
        private float progress = 0f;
        private int colorIndex = 0;

        private readonly Color[] colors =
        {
            Color.FromArgb(84, 78, 119),
            Color.FromArgb(190, 55, 55),
            Color.FromArgb(160, 215, 87)
        };

        public int AnimationSpeed { get; set; } = 4;
        public float RingThickness { get; set; } = 42f;

        public PointF CenterOffset { get; set; } = new PointF(0, 0);
        public float BaseSize { get; set; } = 340f;

        public PointF LeafOffset { get; set; } = new PointF(0, 0);
        public float LeafScaleX { get; set; } = 1f;
        public float LeafScaleY { get; set; } = 1f;
        public float LeafRotation { get; set; } = 0f;
        public Color LeafColor { get; set; } = Color.FromArgb(160, 215, 87);
        public SizeF LogoSize { get; set; } = new SizeF(170, 170);
        public PointF LogoOffset { get; set; } = new PointF(0, 0);
        public GrapeLoadingControl()
        {
            DoubleBuffered = true;
            Size = new Size(170, 170);
            BackColor = Color.White;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 16;
            timer.Tick += (s, e) =>
            {
                progress += AnimationSpeed;

                if (progress >= 360)
                {
                    progress = 0;
                    colorIndex = (colorIndex + 1) % colors.Length;
                }

                Invalidate();
            };

            timer.Start();
        }

        public void ApplyPreset(
            Size controlSize,
            float ringThickness,
            int animationSpeed,
            PointF centerOffset,
            PointF leafOffset,
            float leafScaleX,
            float leafScaleY,
            float leafRotation
        )
        {
            Size = controlSize;
            RingThickness = ringThickness;
            AnimationSpeed = animationSpeed;
            CenterOffset = centerOffset;

            LeafOffset = leafOffset;
            LeafScaleX = leafScaleX;
            LeafScaleY = leafScaleY;
            LeafRotation = leafRotation;

            Invalidate();
        }

        public void ApplyVerySmall()
        {
            ApplyPreset(
                new Size(45, 45),
                16f,
                5,
                new PointF(0, 0),
                new PointF(-4, -4),
                0.75f,
                0.75f,
                0f
            );
        }

        public void ApplySmall()
        {
            ApplyPreset(
                new Size(75, 75),
                22f,
                5,
                new PointF(0, 0),
                new PointF(-2, -3),
                0.85f,
                0.85f,
                0f
            );
        }

        public void ApplyMedium()
        {
            ApplyPreset(
                new Size(120, 120),
                32f,
                4,
                new PointF(0, 0),
                new PointF(10, -15),
                1f,
                1f,
                0f
            );
        }

        public void ApplyLarge()
        {
            ApplyPreset(
                new Size(180, 180),
                42f,
                4,
                new PointF(0, 0),
                new PointF(2, -30),
                1.1f,
                1.1f,
                0f
            );
        }

        public void ApplyVeryLarge()
        {
            ApplyPreset(
                new Size(260, 260),
                55f,
                3,
                new PointF(0, 0),
                new PointF(4, 4),
                1.25f,
                1.25f,
                0f
            );
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            float scale = Math.Min(LogoSize.Width, LogoSize.Height) / BaseSize;

            float offsetX = (Width - LogoSize.Width) / 2f + LogoOffset.X;
            float offsetY = (Height - LogoSize.Height) / 2f + LogoOffset.Y;

            g.TranslateTransform(offsetX, offsetY);
            g.ScaleTransform(scale, scale);

            DrawLeaf(g);
            DrawGrapeCircle(g);
        }

        private void DrawGrapeCircle(Graphics g)
        {
            RectangleF circle = new RectangleF(80, 82, 180, 180);

            Color currentColor = colors[colorIndex];
            Color nextColor = colors[(colorIndex + 1) % colors.Length];

            float startBaseAngle = -45;

            using Pen basePen = new Pen(currentColor, RingThickness);
            basePen.StartCap = LineCap.Round;
            basePen.EndCap = LineCap.Round;
            g.DrawArc(basePen, circle, 0, 360);

            using Pen mainPen = new Pen(nextColor, RingThickness);
            mainPen.StartCap = LineCap.Flat;
            mainPen.EndCap = LineCap.Round;
            g.DrawArc(mainPen, circle, startBaseAngle, progress);

            DrawFadeTip(g, circle, nextColor, startBaseAngle);
        }

        private void DrawFadeTip(Graphics g, RectangleF circle, Color color, float startBaseAngle)
        {
            if (progress <= 4)
                return;

            int steps = 12;
            float fadeLength = RingThickness;
            float tipAngle = startBaseAngle + progress;

            for (int i = 0; i < steps; i++)
            {
                float percent = i / (float)steps;
                int alpha = (int)(120 * (1 - percent));

                float startAngle = tipAngle - (percent * fadeLength);

                if (startAngle < startBaseAngle)
                    startAngle = startBaseAngle;

                using Pen fadePen = new Pen(Color.FromArgb(alpha, color), RingThickness);
                fadePen.StartCap = LineCap.Flat;
                fadePen.EndCap = LineCap.Round;

                g.DrawArc(fadePen, circle, startAngle, 3f);
            }
        }

        private void DrawLeaf(Graphics g)
        {
            GraphicsState state = g.Save();

            float centerX = 285f;
            float centerY = 62f;

            g.TranslateTransform(centerX + LeafOffset.X, centerY + LeafOffset.Y);
            g.RotateTransform(LeafRotation);
            g.ScaleTransform(LeafScaleX, LeafScaleY);
            g.TranslateTransform(-centerX, -centerY);

            using GraphicsPath leaf = new GraphicsPath();

            leaf.AddBezier(
                new PointF(235, 110),
                new PointF(220, 55),
                new PointF(270, 5),
                new PointF(332, 11)
            );

            leaf.AddBezier(
                new PointF(332, 11),
                new PointF(340, 75),
                new PointF(295, 115),
                new PointF(235, 110)
            );

            leaf.CloseFigure();

            using SolidBrush brush = new SolidBrush(LeafColor);
            g.FillPath(brush, leaf);

            g.Restore(state);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                timer?.Dispose();

            base.Dispose(disposing);
        }
    }
}