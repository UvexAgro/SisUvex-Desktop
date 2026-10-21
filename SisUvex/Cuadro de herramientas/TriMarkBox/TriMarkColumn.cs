using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace SisUvex.Cuadro_de_herramientas
{
    public class TriMarkColumn : DataGridViewColumn
    {
        private TriMarkNumberMode numberMode = TriMarkNumberMode.Enum;

        public TriMarkColumn() : base(new TriMarkCell())
        {
            SortMode = DataGridViewColumnSortMode.NotSortable;
            Width = 78;
        }

        [Category("Comportamiento")]
        [Description("Enum: vacío 0, paloma 1, equis 2. Code: equis 0, paloma 1, vacío 2. Al cambiar el modo, la marca se conserva y el entero guardado se reescribe.")]
        [DefaultValue(TriMarkNumberMode.Enum)]
        public TriMarkNumberMode NumberMode
        {
            get => numberMode;
            set
            {
                if (numberMode == value)
                    return;

                TriMarkNumberMode previous = numberMode;
                numberMode = value;
                RewriteNumericCells(previous, value);

                if (DataGridView != null && Index >= 0)
                    DataGridView.InvalidateColumn(Index);
            }
        }

        public override object Clone()
        {
            TriMarkColumn column = (TriMarkColumn)base.Clone();
            column.numberMode = numberMode;
            return column;
        }

        private void RewriteNumericCells(TriMarkNumberMode from, TriMarkNumberMode to)
        {
            if (DataGridView == null || Index < 0)
                return;

            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                if (row.IsNewRow)
                    continue;

                DataGridViewCell cell = row.Cells[Index];
                if (!TriMarkPainter.TryReadNumber(cell.Value, out int number))
                    continue;

                TriMarkValue mark = TriMarkPainter.FromNumber(number, from);
                cell.Value = TriMarkPainter.ToNumber(mark, to);
            }
        }

        public override DataGridViewCell? CellTemplate
        {
            get => base.CellTemplate;
            set
            {
                if (value != null && value is not TriMarkCell)
                    throw new InvalidCastException("TriMarkColumn requiere una celda TriMarkCell.");

                base.CellTemplate = value;
            }
        }
    }

    public class TriMarkCell : DataGridViewCell
    {
        private bool hovered;
        private bool keyHeld;

        public TriMarkCell()
        {
            ValueType = typeof(TriMarkValue);
        }

        public override object DefaultNewRowValue => TriMarkValue.Empty;

        public override object Clone()
        {
            TriMarkCell cell = (TriMarkCell)base.Clone();
            cell.hovered = false;
            cell.keyHeld = false;
            return cell;
        }

        protected override void OnDataGridViewChanged()
        {
            base.OnDataGridViewChanged();

            if (DataGridView == null)
                return;

            typeof(DataGridView).InvokeMember(
                "DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty,
                null,
                DataGridView,
                new object[] { true });
        }

        protected override void Paint(
            Graphics graphics,
            Rectangle clipBounds,
            Rectangle cellBounds,
            int rowIndex,
            DataGridViewElementStates cellState,
            object? value,
            object? formattedValue,
            string? errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            if ((paintParts & DataGridViewPaintParts.Border) != 0)
            {
                PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle);
            }

            Rectangle interior = cellBounds;
            Rectangle border = BorderWidths(advancedBorderStyle);
            interior.Offset(border.X, border.Y);
            interior.Width -= border.Right;
            interior.Height -= border.Bottom;

            if (interior.Width > 0 && interior.Height > 0 &&
                (paintParts & DataGridViewPaintParts.Background) != 0)
            {
                using SolidBrush backBrush = new SolidBrush(ResolveBackColor(cellState, cellStyle));
                graphics.FillRectangle(backBrush, interior);
            }

            Rectangle box = GetBoxRectangle(cellBounds);
            if (box.Width <= 0 || box.Height <= 0)
                return;

            GraphicsState state = graphics.Save();
            try
            {
                graphics.SetClip(box, CombineMode.Intersect);
                TriMarkPainter.Draw(
                    graphics,
                    box,
                    TriMarkPainter.FromObject(value, CurrentMode),
                    hovered,
                    DataGridView == null || DataGridView.Enabled,
                    false,
                    TriMarkPalette.Default);
            }
            finally
            {
                graphics.Restore(state);
            }
        }

        private Color ResolveBackColor(DataGridViewElementStates cellState, DataGridViewCellStyle cellStyle)
        {
            bool selected = (cellState & DataGridViewElementStates.Selected) != 0;
            Color color = selected ? cellStyle.SelectionBackColor : cellStyle.BackColor;

            if (color.IsEmpty || color.A < 255)
            {
                color = selected
                    ? DataGridView?.DefaultCellStyle.SelectionBackColor ?? SystemColors.Highlight
                    : DataGridView?.DefaultCellStyle.BackColor ?? SystemColors.Window;
            }

            if (color.IsEmpty || color.A < 255)
                color = selected ? SystemColors.Highlight : SystemColors.Window;

            return color;
        }

        protected override void OnMouseDown(DataGridViewCellMouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left && e.RowIndex >= 0)
                Cycle();
        }

        protected override void OnMouseEnter(int rowIndex)
        {
            base.OnMouseEnter(rowIndex);
            hovered = true;

            if (DataGridView != null)
            {
                DataGridView.Cursor = Cursors.Hand;
                DataGridView.InvalidateCell(this);
            }
        }

        protected override void OnMouseLeave(int rowIndex)
        {
            hovered = false;

            if (DataGridView != null)
            {
                DataGridView.Cursor = Cursors.Default;
                DataGridView.InvalidateCell(this);
            }

            base.OnMouseLeave(rowIndex);
        }

        protected override void OnKeyDown(KeyEventArgs e, int rowIndex)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
            {
                if (!keyHeld && rowIndex >= 0)
                {
                    keyHeld = true;
                    Cycle();
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }

            base.OnKeyDown(e, rowIndex);
        }

        protected override void OnKeyUp(KeyEventArgs e, int rowIndex)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
                keyHeld = false;

            base.OnKeyUp(e, rowIndex);
        }

        private void Cycle()
        {
            if (DataGridView == null || RowIndex < 0 || ReadOnly || DataGridView.ReadOnly)
                return;

            TriMarkNumberMode mode = CurrentMode;
            object? current = Value;
            TriMarkValue next = TriMarkPainter.Next(TriMarkPainter.FromObject(current, mode));

            if (TriMarkPainter.TryReadNumber(current, out _))
                Value = TriMarkPainter.ToNumber(next, mode);
            else
                Value = next;
        }

        private TriMarkNumberMode CurrentMode
        {
            get => OwningColumn is TriMarkColumn column
                ? column.NumberMode
                : TriMarkNumberMode.Enum;
        }

        private static Rectangle GetBoxRectangle(Rectangle cellBounds)
        {
            const int width = 16;
            const int height = 16;
            int x = cellBounds.X + (cellBounds.Width - width) / 2;
            int y = cellBounds.Y + (cellBounds.Height - height) / 2;
            return new Rectangle(x, y, width, height);
        }
    }
}
