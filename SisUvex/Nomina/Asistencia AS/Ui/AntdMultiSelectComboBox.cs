using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace SisUvex.Nomina.Asistencia_AS
{
    /// <summary>
    /// <see cref="AntdComboBox"/> de selección múltiple con filtro tipo Excel: al abrirlo muestra un cuadro
    /// "Buscar", una lista con casillas, "(Seleccionar todo)" y botones Aceptar / Cancelar.
    /// Sigue siendo un <see cref="ComboBox"/> enlazado a un DataTable: la fila vacía ("---Seleccionar---") se
    /// ignora y, cuando hay exactamente un elemento marcado, <see cref="ComboBox.SelectedIndex"/> apunta a él
    /// (así el código que lee SelectedValue / ComboValueOrNull sigue funcionando con una sola selección).
    /// </summary>
    public class AntdMultiSelectComboBox : AntdComboBox
    {
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_CHAR = 0x0102;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONDBLCLK = 0x0203;
        private const int WM_MOUSEWHEEL = 0x020A;
        private const int CB_SHOWDROPDOWN = 0x014F;

        private readonly HashSet<string> _selected = new(StringComparer.OrdinalIgnoreCase);
        private MultiSelectPopup? _popup;
        private long _closedTick = -10_000;

        /// <summary>Se dispara cuando el usuario acepta una nueva selección (o la limpia con Supr / Retroceso).</summary>
        public event EventHandler? SelectionCommitted;

        /// <summary>Texto del cuadro de búsqueda cuando no hay nada escrito.</summary>
        [Category("Appearance")]
        public string SearchPlaceholder { get; set; } = "Buscar";

        /// <summary>Valores (ValueMember) marcados, en el orden de la lista. Vacío = sin filtro.</summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IReadOnlyList<string> SelectedValues
            => EnumerateEntries().Where(e => _selected.Contains(e.Value)).Select(e => e.Value).ToList();

        [Browsable(false)]
        public bool HasSelection => _selected.Count > 0;

        protected override bool ForceActive => _popup != null;

        public void ClearSelection()
        {
            if (_selected.Count == 0) return;
            _selected.Clear();
            SyncSelectedIndex();
            Invalidate();
            SelectionCommitted?.Invoke(this, EventArgs.Empty);
        }

        public void SetSelectedValues(IEnumerable<string> values)
        {
            _selected.Clear();
            foreach (string v in values)
                if (!string.IsNullOrWhiteSpace(v))
                    _selected.Add(v.Trim());
            SyncSelectedIndex();
            Invalidate();
        }

        protected override string GetCaptionText()
            => _selected.Count >= 2 ? $"{_selected.Count} seleccionados" : base.GetCaptionText();

        // ── Datos ────────────────────────────────────────────────────────────

        private IEnumerable<(string Value, string Text, int Index)> EnumerateEntries()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                object item = Items[i]!;
                string value = (FilterItemOnProperty(item, ValueMember)?.ToString() ?? string.Empty).Trim();
                if (value.Length == 0) continue;           // fila "---Seleccionar---"
                yield return (value, GetItemText(item), i);
            }
        }

        private void SyncSelectedIndex()
        {
            if (Items.Count == 0) return;

            int index = 0;
            if (_selected.Count == 1)
            {
                string only = _selected.First();
                foreach (var e in EnumerateEntries())
                    if (string.Equals(e.Value, only, StringComparison.OrdinalIgnoreCase))
                    {
                        index = e.Index;
                        break;
                    }
            }

            if (SelectedIndex != index)
                SelectedIndex = index;
        }

        private void Commit(IEnumerable<string> values)
        {
            _selected.Clear();
            foreach (string v in values)
                _selected.Add(v);
            SyncSelectedIndex();
            Invalidate();
            SelectionCommitted?.Invoke(this, EventArgs.Empty);
        }

        // ── Popup ────────────────────────────────────────────────────────────

        private void OpenPopup(string? initialSearch)
        {
            if (_popup != null || !Enabled || !IsHandleCreated) return;
            if (Environment.TickCount64 - _closedTick < 250) return;   // el clic que cerró el popup no debe reabrirlo

            var entries = EnumerateEntries()
                .Select(e => new MultiSelectPopup.Entry(e.Value, e.Text, _selected.Contains(e.Value)))
                .ToList();

            var popup = new MultiSelectPopup(entries, Math.Max(Width, 300), SearchPlaceholder, initialSearch);
            _popup = popup;
            popup.FormClosed += (_, _) =>
            {
                _popup = null;
                _closedTick = Environment.TickCount64;
                if (popup.Accepted)
                    Commit(popup.CheckedValues);
                Invalidate();
                if (!IsDisposed && Enabled)
                    Focus();
            };

            Rectangle below = RectangleToScreen(new Rectangle(0, 0, Width, Height));
            popup.ShowNear(below);
            Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _popup != null && !_popup.IsDisposed)
                _popup.Close();
            base.Dispose(disposing);
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_LBUTTONDOWN:
                case WM_LBUTTONDBLCLK:
                    if (Enabled)
                    {
                        Focus();
                        OpenPopup(null);
                    }
                    return;

                case WM_MOUSEWHEEL:
                case CB_SHOWDROPDOWN:
                    return;                                  // nada de cambiar la selección con la rueda

                case WM_KEYDOWN:
                case WM_SYSKEYDOWN:
                {
                    Keys key = (Keys)(int)m.WParam;
                    if (key is Keys.F4 or Keys.Down or Keys.Up or Keys.Space or Keys.Return)
                        OpenPopup(null);
                    else if (key is Keys.Delete or Keys.Back)
                        ClearSelection();
                    return;
                }

                case WM_CHAR:
                {
                    char c = (char)(int)m.WParam;
                    if (!char.IsControl(c))
                        OpenPopup(c.ToString());             // escribir abre el filtro con ese texto
                    return;
                }
            }

            base.WndProc(ref m);
        }
    }

    /// <summary>Ventana flotante del filtro: búsqueda, lista con casillas, seleccionar todo, Aceptar / Cancelar.</summary>
    internal sealed class MultiSelectPopup : Form
    {
        public sealed class Entry
        {
            public Entry(string value, string text, bool isChecked)
            {
                Value = value;
                Text = text;
                Checked = isChecked;
            }

            public string Value { get; }
            public string Text { get; }
            public bool Checked { get; set; }
        }

        /// <summary>Fila especial "(Seleccionar todo)".</summary>
        private sealed class SelectAllRow { }

        private sealed class BufferedListBox : ListBox
        {
            public BufferedListBox()
            {
                DoubleBuffered = true;
                SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            }
        }

        private readonly List<Entry> _all;
        private readonly List<Entry> _visible = new();
        private readonly SelectAllRow _selectAllRow = new();
        private readonly ListBox _list;
        private readonly TextBox _search;
        private readonly Label _count;
        private readonly Label _empty;
        private readonly AntdUI.Panel _searchHost;
        private readonly AntdUI.Button _ok;
        private readonly AntdUI.Button _cancel;
        private bool _closing;

        public bool Accepted { get; private set; }

        public List<string> CheckedValues => _all.Where(e => e.Checked).Select(e => e.Value).ToList();

        private int S(int v) => (int)Math.Round(v * DeviceDpi / 96f);

        public MultiSelectPopup(List<Entry> entries, int width, string placeholder, string? initialSearch)
        {
            _all = entries;

            AutoScaleMode = AutoScaleMode.None;
            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            TopMost = true;
            KeyPreview = true;
            BackColor = Color.White;
            Font = new Font("Segoe UI", 9.5F);
            DoubleBuffered = true;
            ClientSize = new Size(S(width), S(360));

            int w = ClientSize.Width;
            int h = ClientSize.Height;
            int pad = S(8);

            _searchHost = new AntdUI.Panel
            {
                Back = Color.White,
                BorderColor = AntdTheme.InputBorder,
                BorderWidth = 1F,
                Radius = 8,
                Location = new Point(pad, pad),
                Size = new Size(w - pad * 2, S(34)),
            };
            _search = new TextBox
            {
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(S(10), S(7)),
                Width = _searchHost.Width - S(20),
            };
            _searchHost.Controls.Add(_search);
            Label hint = new()
            {
                AutoSize = false,
                Text = placeholder,
                ForeColor = AntdTheme.TextMuted,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 10F),
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(S(10), S(5)),
                Size = new Size(_search.Width, S(24)),
            };
            hint.Click += (_, _) => _search.Focus();
            _searchHost.Controls.Add(hint);
            hint.BringToFront();
            _search.TextChanged += (_, _) => hint.Visible = _search.TextLength == 0;
            AntdInputHost.Bind(_searchHost, _search);

            int listTop = pad * 2 + S(34);
            int bottomBar = S(48);
            _list = new BufferedListBox
            {
                BorderStyle = BorderStyle.None,
                DrawMode = DrawMode.OwnerDrawFixed,
                ItemHeight = S(28),
                IntegralHeight = false,
                Location = new Point(pad, listTop),
                Size = new Size(w - pad * 2, h - listTop - bottomBar),
                BackColor = Color.White,
            };

            _empty = new Label
            {
                AutoSize = false,
                Text = "Sin resultados",
                ForeColor = AntdTheme.TextMuted,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Italic),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = _list.Location,
                Size = new Size(_list.Width, S(40)),
                Visible = false,
            };

            _count = new Label
            {
                AutoSize = false,
                ForeColor = AntdTheme.TextMuted,
                Font = new Font("Segoe UI", 8.5F),
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(pad + S(2), h - bottomBar + S(8)),
                Size = new Size(S(110), S(32)),
            };

            _cancel = new AntdUI.Button
            {
                Text = "Cancelar",
                BorderWidth = 1.5F,
                DefaultBack = Color.White,
                DefaultBorderColor = AntdTheme.Primary,
                ForeColor = AntdTheme.Primary,
                BackHover = AntdTheme.PrimarySoft,
                BackActive = AntdTheme.PrimarySofter,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Radius = 8,
                Cursor = Cursors.Hand,
                Size = new Size(S(84), S(32)),
            };
            _cancel.Location = new Point(w - pad - _cancel.Width, h - bottomBar + S(8));

            _ok = new AntdUI.Button
            {
                Text = "Aceptar",
                Type = AntdUI.TTypeMini.Primary,
                BackColor = AntdTheme.Primary,
                BackHover = AntdTheme.PrimaryHover,
                BackActive = AntdTheme.PrimaryActive,
                ForeColor = Color.White,
                BorderWidth = 0F,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Radius = 8,
                Cursor = Cursors.Hand,
                Size = new Size(S(84), S(32)),
            };
            _ok.Location = new Point(_cancel.Left - S(8) - _ok.Width, h - bottomBar + S(8));

            Controls.Add(_searchHost);
            Controls.Add(_list);
            Controls.Add(_empty);
            Controls.Add(_count);
            Controls.Add(_ok);
            Controls.Add(_cancel);

            _search.TextChanged += (_, _) => ApplyFilter();
            _search.KeyDown += Search_KeyDown;
            _list.DrawItem += List_DrawItem;
            _list.MouseDown += List_MouseDown;
            _list.KeyDown += List_KeyDown;
            _ok.Click += (_, _) => Finish(true);
            _cancel.Click += (_, _) => Finish(false);
            Deactivate += (_, _) => Finish(false);

            if (!string.IsNullOrEmpty(initialSearch))
                _search.Text = initialSearch;
            ApplyFilter();

            Shown += (_, _) =>
            {
                _search.Focus();
                _search.SelectionStart = _search.TextLength;
            };
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x00020000;   // CS_DROPSHADOW
                return cp;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using Pen p = new(AntdTheme.InputBorder);
            e.Graphics.DrawRectangle(p, 0, 0, Width - 1, Height - 1);
            using Pen sep = new(Color.FromArgb(235, 235, 243));
            int y = _ok.Top - S(6);
            e.Graphics.DrawLine(sep, S(8), y, Width - S(8), y);
        }

        /// <summary>Se muestra debajo del control (o encima si no cabe), dentro del área de trabajo.</summary>
        public void ShowNear(Rectangle owner)
        {
            Rectangle area = Screen.FromRectangle(owner).WorkingArea;
            int x = Math.Min(Math.Max(owner.Left, area.Left), area.Right - Width);
            int y = owner.Bottom + 2;
            if (y + Height > area.Bottom)
                y = Math.Max(area.Top, owner.Top - Height - 2);
            Location = new Point(x, y);
            Show();
            Activate();
        }

        private void Finish(bool accept)
        {
            if (_closing) return;
            _closing = true;
            Accepted = accept;
            Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Finish(false);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // ── Filtro y selección ────────────────────────────────────────────────

        private static bool Matches(string text, string term)
            => CultureInfo.CurrentCulture.CompareInfo.IndexOf(
                   text, term, CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace) >= 0;

        private void ApplyFilter()
        {
            string term = _search.Text.Trim();
            _visible.Clear();
            _visible.AddRange(term.Length == 0 ? _all : _all.Where(e => Matches(e.Text, term)));

            _list.BeginUpdate();
            _list.Items.Clear();
            if (_visible.Count > 0)
            {
                _list.Items.Add(_selectAllRow);
                foreach (Entry e in _visible)
                    _list.Items.Add(e);
            }
            _list.EndUpdate();

            _empty.Visible = _visible.Count == 0;
            UpdateCount();
        }

        private void UpdateCount()
        {
            int n = _all.Count(e => e.Checked);
            _count.Text = $"{n} de {_all.Count} marcados";
            _list.Invalidate();
        }

        /// <summary>true = todos marcados, false = ninguno, null = mezcla (entre los elementos visibles).</summary>
        private bool? SelectAllState()
        {
            if (_visible.Count == 0) return false;
            int n = _visible.Count(e => e.Checked);
            if (n == 0) return false;
            return n == _visible.Count ? true : null;
        }

        private void ToggleIndex(int index)
        {
            if (index < 0 || index >= _list.Items.Count) return;

            if (_list.Items[index] is Entry entry)
                entry.Checked = !entry.Checked;
            else
            {
                bool check = SelectAllState() != true;
                foreach (Entry e in _visible)
                    e.Checked = check;
            }
            UpdateCount();
        }

        private void List_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            int index = _list.IndexFromPoint(e.Location);
            if (index < 0) return;
            _list.SelectedIndex = index;
            ToggleIndex(index);
        }

        private void List_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                ToggleIndex(_list.SelectedIndex);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                Finish(true);
            }
            else if (e.KeyCode == Keys.Up && _list.SelectedIndex <= 0)
            {
                e.Handled = true;
                _search.Focus();
            }
        }

        private void Search_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                Finish(true);
            }
            else if (e.KeyCode == Keys.Down && _list.Items.Count > 0)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                _list.Focus();
                _list.SelectedIndex = Math.Min(1, _list.Items.Count - 1);
            }
        }

        // ── Dibujo ────────────────────────────────────────────────────────────

        private void List_DrawItem(object? sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= _list.Items.Count) return;

            Graphics g = e.Graphics;
            Rectangle r = e.Bounds;
            object item = _list.Items[e.Index];

            bool selected = (e.State & DrawItemState.Selected) != 0 && _list.Focused;
            using (SolidBrush back = new(selected ? AntdTheme.PrimarySoft : Color.White))
                g.FillRectangle(back, r);

            bool? state;
            string text;
            if (item is Entry entry)
            {
                state = entry.Checked;
                text = entry.Text;
            }
            else
            {
                state = SelectAllState();
                text = "(Seleccionar todo)";
            }

            int box = S(16);
            Rectangle glyph = new(r.X + S(8), r.Y + (r.Height - box) / 2, box, box);
            DrawCheck(g, glyph, state);

            Rectangle textRect = new(glyph.Right + S(8), r.Y, r.Right - glyph.Right - S(12), r.Height);
            Font font = item is Entry ? _list.Font : new Font(_list.Font, FontStyle.Bold);
            try
            {
                TextRenderer.DrawText(g, text, font, textRect, AntdTheme.TextStrong,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPadding);
            }
            finally
            {
                if (item is not Entry) font.Dispose();
            }
        }

        private static void DrawCheck(Graphics g, Rectangle r, bool? state)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using GraphicsPath path = new();
            int d = 6;
            Rectangle b = new(r.X, r.Y, r.Width - 1, r.Height - 1);
            path.AddArc(b.X, b.Y, d, d, 180, 90);
            path.AddArc(b.Right - d, b.Y, d, d, 270, 90);
            path.AddArc(b.Right - d, b.Bottom - d, d, d, 0, 90);
            path.AddArc(b.X, b.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            bool filled = state != false;
            using (SolidBrush fill = new(filled ? AntdTheme.Primary : Color.White))
                g.FillPath(fill, path);
            using (Pen border = new(filled ? AntdTheme.Primary : Color.FromArgb(175, 182, 198), 1.2f))
                g.DrawPath(border, path);

            using Pen mark = new(Color.White, 2f) { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round };
            if (state == true)
            {
                g.DrawLines(mark, new[]
                {
                    new PointF(r.X + r.Width * 0.25f, r.Y + r.Height * 0.52f),
                    new PointF(r.X + r.Width * 0.43f, r.Y + r.Height * 0.70f),
                    new PointF(r.X + r.Width * 0.76f, r.Y + r.Height * 0.32f),
                });
            }
            else if (state == null)
            {
                g.DrawLine(mark, r.X + r.Width * 0.28f, r.Y + r.Height * 0.5f, r.X + r.Width * 0.72f, r.Y + r.Height * 0.5f);
            }
        }
    }
}
