

namespace SisUvex.Cuadro_de_herramientas.ToggleButton;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SisUvex.Cuadro_de_herramientas.Colors;
public class ToggleButton : CheckBox
{
    private Timer animationTimer;
    private float togglePosition = 2; // posición actual
    private float targetPosition;     // destino

    public Color OnBackColor { get; set; } = ColorUvex.Purple;
    public Color OffBackColor { get; set; } = Color.LightGray;
    public Color ToggleColor { get; set; } = Color.White;

    public int AnimationSpeed { get; set; } = 4; // más alto = más rápido

    public ToggleButton()
    {
        this.MinimumSize = new Size(20, 10);

        animationTimer = new Timer();
        animationTimer.Interval = 10;
        animationTimer.Tick += AnimateToggle;
    }

    protected override void OnCheckedChanged(EventArgs e)
    {
        base.OnCheckedChanged(e);

        int diameter = this.Height - 4;

        targetPosition = this.Checked
            ? this.Width - diameter - 2
            : 2;

        animationTimer.Start();
    }

    private void AnimateToggle(object sender, EventArgs e)
    {
        if (Math.Abs(togglePosition - targetPosition) < 1)
        {
            togglePosition = targetPosition;
            animationTimer.Stop();
        }
        else
        {
            togglePosition += (targetPosition - togglePosition) / AnimationSpeed;
        }

        this.Invalidate();
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        pevent.Graphics.Clear(this.Parent.BackColor);

        int padding = 2;
        int diameter = this.Height - padding * 2;

        Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

        using (var path = GetFigurePath(rect, this.Height))
        using (var brush = new SolidBrush(this.Checked ? OnBackColor : OffBackColor))
        {
            pevent.Graphics.FillPath(brush, path);
        }

        using (var brush = new SolidBrush(ToggleColor))
        {
            pevent.Graphics.FillEllipse(
                brush,
                togglePosition,
                padding,
                diameter,
                diameter
            );
        }
    }

    private GraphicsPath GetFigurePath(Rectangle rect, int radius)
    {
        GraphicsPath path = new GraphicsPath();
        int curveSize = radius;

        path.StartFigure();
        path.AddArc(rect.X, rect.Y, curveSize, curveSize, 90, 180);
        path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 180);
        path.CloseFigure();

        return path;
    }
}