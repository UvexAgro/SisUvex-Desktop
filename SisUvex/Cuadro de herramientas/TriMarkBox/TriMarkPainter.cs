using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SisUvex.Cuadro_de_herramientas
{
    public readonly struct TriMarkPalette
    {
        public Color EmptyBackColor { get; }
        public Color EmptyBorderColor { get; }
        public Color CheckBackColor { get; }
        public Color CrossBackColor { get; }
        public Color MarkColor { get; }

        public TriMarkPalette(
            Color emptyBackColor,
            Color emptyBorderColor,
            Color checkBackColor,
            Color crossBackColor,
            Color markColor)
        {
            EmptyBackColor = emptyBackColor;
            EmptyBorderColor = emptyBorderColor;
            CheckBackColor = checkBackColor;
            CrossBackColor = crossBackColor;
            MarkColor = markColor;
        }

        public static TriMarkPalette Default { get; } = new(
            Color.FromArgb(232, 232, 232),
            Color.FromArgb(150, 150, 150),
            Color.FromArgb(34, 160, 70),
            Color.FromArgb(198, 48, 48),
            Color.White);
    }

    public static class TriMarkPainter
    {
        public static TriMarkValue Next(TriMarkValue value)
        {
            return value switch
            {
                TriMarkValue.Empty => TriMarkValue.Check,
                TriMarkValue.Check => TriMarkValue.Cross,
                _ => TriMarkValue.Empty
            };
        }

        public static int ToNumber(TriMarkValue value, TriMarkNumberMode mode)
        {
            if (mode == TriMarkNumberMode.Code)
            {
                return value switch
                {
                    TriMarkValue.Cross => 0,
                    TriMarkValue.Check => 1,
                    _ => 2
                };
            }

            return (int)value;
        }

        public static int ToNumber(object? value, TriMarkNumberMode mode)
        {
            return ToNumber(FromObject(value, mode), mode);
        }

        public static TriMarkValue FromNumber(int number, TriMarkNumberMode mode)
        {
            if (mode == TriMarkNumberMode.Code)
            {
                return number switch
                {
                    0 => TriMarkValue.Cross,
                    1 => TriMarkValue.Check,
                    2 => TriMarkValue.Empty,
                    _ => TriMarkValue.Empty
                };
            }

            if (Enum.IsDefined(typeof(TriMarkValue), number))
                return (TriMarkValue)number;

            return TriMarkValue.Empty;
        }

        public static TriMarkValue FromObject(object? value)
        {
            return FromObject(value, TriMarkNumberMode.Enum);
        }

        public static TriMarkValue FromObject(object? value, TriMarkNumberMode mode)
        {
            if (value == null || value is DBNull)
                return TriMarkValue.Empty;

            if (value is TriMarkValue mark)
                return mark;

            if (TryReadNumber(value, out int number))
                return FromNumber(number, mode);

            if (value is string text && Enum.TryParse(text.Trim(), true, out TriMarkValue parsed))
                return parsed;

            return TriMarkValue.Empty;
        }

        public static bool TryReadNumber(object? value, out int number)
        {
            switch (value)
            {
                case byte byteNumber:
                    number = byteNumber;
                    return true;
                case short shortNumber:
                    number = shortNumber;
                    return true;
                case int intNumber:
                    number = intNumber;
                    return true;
                case long longNumber when longNumber >= int.MinValue && longNumber <= int.MaxValue:
                    number = (int)longNumber;
                    return true;
                case string text when int.TryParse(text.Trim(), out int parsed):
                    number = parsed;
                    return true;
                default:
                    number = 0;
                    return false;
            }
        }

        public static void Draw(
            Graphics g,
            Rectangle box,
            TriMarkValue value,
            bool hovered,
            bool enabled,
            bool focused,
            TriMarkPalette palette)
        {
            if (box.Width <= 0 || box.Height <= 0)
                return;

            GraphicsState state = g.Save();
            try
            {
                g.SetClip(box, CombineMode.Intersect);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                Color fill = GetFillColor(value, hovered, enabled, palette);
                Color border = GetBorderColor(value, hovered, enabled, palette);
                float borderWidth = hovered && enabled && value != TriMarkValue.Empty ? 2.2f : 1.4f;

                using (GraphicsPath path = CreateRoundedRectanglePath(box, 3))
                using (SolidBrush fillBrush = new SolidBrush(fill))
                using (Pen borderPen = new Pen(border, borderWidth))
                {
                    g.FillPath(fillBrush, path);
                    borderPen.Alignment = PenAlignment.Inset;
                    g.DrawPath(borderPen, path);
                }

                if (value == TriMarkValue.Check)
                    DrawCheck(g, box, enabled, palette.MarkColor);
                else if (value == TriMarkValue.Cross)
                    DrawCross(g, box, enabled, palette.MarkColor);

                if (focused && enabled)
                {
                    Rectangle focus = Rectangle.Inflate(box, 2, 2);
                    focus.Intersect(box);
                    if (focus.Width > 0 && focus.Height > 0)
                        ControlPaint.DrawFocusRectangle(g, focus);
                }
            }
            finally
            {
                g.Restore(state);
            }
        }

        private static Color GetFillColor(TriMarkValue value, bool hovered, bool enabled, TriMarkPalette palette)
        {
            Color color = value switch
            {
                TriMarkValue.Check => palette.CheckBackColor,
                TriMarkValue.Cross => palette.CrossBackColor,
                _ => palette.EmptyBackColor
            };

            if (!enabled)
                return BlendWithGray(color);

            if (!hovered)
                return color;

            if (value == TriMarkValue.Empty)
                return Color.FromArgb(214, 214, 214);

            return Lighten(color, 42);
        }

        private static Color GetBorderColor(TriMarkValue value, bool hovered, bool enabled, TriMarkPalette palette)
        {
            if (!enabled)
                return Color.FromArgb(180, 180, 180);

            if (value == TriMarkValue.Empty)
                return hovered ? Color.FromArgb(120, 120, 120) : palette.EmptyBorderColor;

            Color border = value == TriMarkValue.Check
                ? Darken(palette.CheckBackColor)
                : Darken(palette.CrossBackColor);

            return hovered ? Color.White : border;
        }

        private static void DrawCheck(Graphics g, Rectangle box, bool enabled, Color markColor)
        {
            PointF[] points =
            {
                new PointF(box.Left + box.Width * 0.22f, box.Top + box.Height * 0.52f),
                new PointF(box.Left + box.Width * 0.42f, box.Top + box.Height * 0.72f),
                new PointF(box.Left + box.Width * 0.78f, box.Top + box.Height * 0.28f)
            };

            using Pen pen = CreateMarkPen(box, enabled, markColor);
            g.DrawLines(pen, points);
        }

        private static void DrawCross(Graphics g, Rectangle box, bool enabled, Color markColor)
        {
            float left = box.Left + box.Width * 0.28f;
            float right = box.Left + box.Width * 0.72f;
            float top = box.Top + box.Height * 0.28f;
            float bottom = box.Top + box.Height * 0.72f;

            using Pen pen = CreateMarkPen(box, enabled, markColor);
            g.DrawLine(pen, left, top, right, bottom);
            g.DrawLine(pen, right, top, left, bottom);
        }

        private static Pen CreateMarkPen(Rectangle box, bool enabled, Color markColor)
        {
            Color color = enabled ? markColor : Color.FromArgb(245, 245, 245);
            return new Pen(color, Math.Max(2f, box.Width * 0.14f))
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round,
                LineJoin = LineJoin.Round
            };
        }

        private static Color Lighten(Color color, int amount)
        {
            return Color.FromArgb(
                color.A,
                Math.Min(255, color.R + amount),
                Math.Min(255, color.G + amount),
                Math.Min(255, color.B + amount));
        }

        private static Color Darken(Color color)
        {
            return Color.FromArgb(
                color.A,
                Math.Max(0, color.R - 30),
                Math.Max(0, color.G - 30),
                Math.Max(0, color.B - 30));
        }

        private static Color BlendWithGray(Color color)
        {
            return Color.FromArgb(
                (color.R + 180) / 2,
                (color.G + 180) / 2,
                (color.B + 180) / 2);
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
