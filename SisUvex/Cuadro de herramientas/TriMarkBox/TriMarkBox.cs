using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SisUvex.Cuadro_de_herramientas
{
    public enum TriMarkValue
    {
        Empty = 0,
        Check = 1,
        Cross = 2
    }

    public enum TriMarkNumberMode
    {
        Enum = 0,
        Code = 1
    }

    public class TriMarkBox : Control
    {
        private TriMarkValue markValue = TriMarkValue.Empty;
        private TriMarkNumberMode numberMode = TriMarkNumberMode.Enum;
        private bool isFocused;
        private bool isHovered;
        private bool keyHeld;
        private bool readOnly;

        private Color emptyBackColor = Color.FromArgb(232, 232, 232);
        private Color emptyBorderColor = Color.FromArgb(150, 150, 150);
        private Color checkBackColor = Color.FromArgb(34, 160, 70);
        private Color crossBackColor = Color.FromArgb(198, 48, 48);
        private Color markColor = Color.White;

        [Category("Apariencia")]
        [Description("Vacío, paloma o equis.")]
        [DefaultValue(TriMarkValue.Empty)]
        public TriMarkValue Value
        {
            get => markValue;
            set
            {
                if (markValue == value)
                    return;

                markValue = value;
                UpdateAccessibility();
                Invalidate();
                ValueChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        [Category("Comportamiento")]
        [Description("Enum: vacío 0, paloma 1, equis 2. Code: equis 0, paloma 1, vacío 2.")]
        [DefaultValue(TriMarkNumberMode.Enum)]
        public TriMarkNumberMode NumberMode
        {
            get => numberMode;
            set
            {
                if (numberMode == value)
                    return;

                numberMode = value;
                NumberModeChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Number
        {
            get => TriMarkPainter.ToNumber(markValue, numberMode);
            set => Value = TriMarkPainter.FromNumber(value, numberMode);
        }

        [Category("Comportamiento")]
        [Description("Si está activo, el clic y la barra espaciadora no cambian el valor.")]
        [DefaultValue(false)]
        public bool ReadOnly
        {
            get => readOnly;
            set
            {
                readOnly = value;
                UpdateCursor();
            }
        }

        [Category("Apariencia")]
        [Description("Fondo del estado vacío.")]
        public Color EmptyBackColor
        {
            get => emptyBackColor;
            set
            {
                emptyBackColor = value;
                Invalidate();
            }
        }

        [Category("Apariencia")]
        [Description("Borde del estado vacío.")]
        public Color EmptyBorderColor
        {
            get => emptyBorderColor;
            set
            {
                emptyBorderColor = value;
                Invalidate();
            }
        }

        [Category("Apariencia")]
        [Description("Fondo de la paloma.")]
        public Color CheckBackColor
        {
            get => checkBackColor;
            set
            {
                checkBackColor = value;
                Invalidate();
            }
        }

        [Category("Apariencia")]
        [Description("Fondo de la equis.")]
        public Color CrossBackColor
        {
            get => crossBackColor;
            set
            {
                crossBackColor = value;
                Invalidate();
            }
        }

        [Category("Apariencia")]
        [Description("Color de la paloma y de la equis.")]
        public Color MarkColor
        {
            get => markColor;
            set
            {
                markColor = value;
                Invalidate();
            }
        }

        [Category("Acción")]
        [Description("Ocurre cuando cambia el valor.")]
        public event EventHandler? ValueChanged;

        [Category("Acción")]
        [Description("Ocurre cuando cambia el modo numérico. La marca no cambia; Number pasa a usar la otra escala.")]
        public event EventHandler? NumberModeChanged;

        public override Color BackColor
        {
            get => base.BackColor;
            set
            {
                if (value.A < 255)
                    value = Parent?.BackColor ?? SystemColors.Control;

                if (value.A < 255)
                    value = SystemColors.Control;

                base.BackColor = value;
            }
        }

        public TriMarkBox()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.Selectable |
                ControlStyles.StandardClick |
                ControlStyles.Opaque,
                true);
            SetStyle(ControlStyles.StandardDoubleClick, false);

            Size = new Size(16, 16);
            MinimumSize = new Size(16, 12);
            BackColor = SystemColors.Control;
            TabStop = true;
            AccessibleRole = AccessibleRole.CheckButton;
            UpdateCursor();
            UpdateAccessibility();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && CanChange())
            {
                Focus();
                Cycle();
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            isHovered = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isHovered = false;
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
            keyHeld = false;
            Invalidate();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            UpdateCursor();
            Invalidate();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
            {
                if (!keyHeld && CanChange())
                {
                    keyHeld = true;
                    Cycle();
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
                keyHeld = false;

            base.OnKeyUp(e);
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            SyncBackColor();
        }

        protected override void OnParentBackColorChanged(EventArgs e)
        {
            base.OnParentBackColorChanged(e);
            SyncBackColor();
        }

        private void SyncBackColor()
        {
            if (Parent != null && BackColor != Parent.BackColor)
                BackColor = Parent.BackColor;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(BackColor);

            TriMarkPalette palette = new TriMarkPalette(
                emptyBackColor,
                emptyBorderColor,
                checkBackColor,
                crossBackColor,
                markColor);

            TriMarkPainter.Draw(
                g,
                GetBoxRectangle(),
                markValue,
                isHovered,
                Enabled,
                isFocused,
                palette);
        }

        private void Cycle()
        {
            Value = TriMarkPainter.Next(markValue);
        }

        private bool CanChange()
        {
            return Enabled && !ReadOnly;
        }

        private void UpdateCursor()
        {
            Cursor = CanChange() ? Cursors.Hand : Cursors.Default;
        }

        private void UpdateAccessibility()
        {
            AccessibleDescription = markValue switch
            {
                TriMarkValue.Check => "Paloma",
                TriMarkValue.Cross => "Equis",
                _ => "Vacío"
            };
        }

        private Rectangle GetBoxRectangle()
        {
            return new Rectangle(0, 0, Math.Max(1, Width - 1), Math.Max(1, Height - 1));
        }

    }
}
