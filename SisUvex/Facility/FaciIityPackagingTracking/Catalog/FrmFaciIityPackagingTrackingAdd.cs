using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.Querys;
using System.Data;
using SisUvex.Cuadro_de_herramientas;
using SisUvex.Catalogos.Metods.TextBoxes;
using System.Collections.Generic;
using System.Linq;

namespace SisUvex.Facility.FaciIityPackagingTracking.Catalog
{
    internal partial class FrmFaciIityPackagingTrackingAdd : Form
    {
        public ClsFaciIityPackagingTracking cls = null!;
        public FrmFaciIityPackagingTrackingAdd()
        {
            InitializeComponent();
        }

        private void FrmFaciIityPackagingTrackingAdd_Load(object sender, EventArgs e)
        {
            cls ??= new();
            DataTable dtcolors = ClsQuerysDB.GetDataTable(cls.queryColorAdd);
            LoadColors(dtcolors);
            cls._frmAdd ??= this;
            cls.BeginFormAdd();
        }
        private void LoadColors(DataTable dtColors)
        {
            if (dtColors == null || !dtColors.Columns.Contains(ClsObject.Color.ColumnName) || !dtColors.Columns.Contains(ClsObject.Column.id))
                return;

            flpColorsControls.Controls.Clear();

            flpColorsControls.FlowDirection = FlowDirection.TopDown;
            flpColorsControls.WrapContents = false;
            flpColorsControls.AutoScroll = true;
            flpColorsControls.Padding = new Padding(0);

            foreach (DataRow row in dtColors.Rows)
            {
                Panel pnlRow = new Panel();

                pnlRow.Width = flpColorsControls.ClientSize.Width - 15;
                pnlRow.Height = 26;
                pnlRow.Margin = new Padding(0);

                // 🔹 Toggle
                ToggleButton toggle = new ToggleButton();

                toggle.Tag = row[ClsObject.Column.id].ToString();
                toggle.Size = new Size(35, 20);
                toggle.Location = new Point(0, 3);
                toggle.Cursor = Cursors.Hand;

                // 🔹 Label
                Label lbl = new Label();

                lbl.Text = row[ClsObject.Color.ColumnName].ToString();
                lbl.AutoSize = true;
                lbl.Location = new Point(35, 1);
                lbl.Cursor = Cursors.Hand;

                // 🔹 TextBox (inicialmente oculto)
                TextBox txt = new TextBox();

                txt.Width = 50;
                txt.Height = 15;
                txt.BorderStyle = BorderStyle.FixedSingle;
                txt.Location = new Point(pnlRow.Width - 50, 1);
                txt.Font = new Font("Segoe UI", 9);
                txt.Size = new Size(50, 5);
                txt.Enabled = false;
                txt.BackColor = Color.LightGray;
                txt.TextAlign = HorizontalAlignment.Center;
                ClsTextBoxes.TxbApplyKeyPressEventNumericWithLimit(txt, 2, 2);

                // 🔹 Mostrar / ocultar textbox según toggle
                toggle.CheckedChanged += (s, e) =>
                {
                    txt.Enabled = toggle.Checked;

                    if (!toggle.Checked)
                    {
                        txt.Text = ""; // opcional: limpiar
                        txt.BackColor = Color.LightGray;
                    }
                    else
                        txt.BackColor = Color.White;
                };

                // 🔹 Click en label también activa toggle
                lbl.Click += (s, e) =>
                {
                    toggle.Checked = !toggle.Checked;
                };

                pnlRow.Controls.Add(toggle);
                pnlRow.Controls.Add(lbl);
                pnlRow.Controls.Add(txt);

                flpColorsControls.Controls.Add(pnlRow);
            }
        }

        internal List<(string id, decimal value)> GetSelectedWithValues()
        {
            var result = new List<(string, decimal)>();

            foreach (Panel pnl in flpColorsControls.Controls.OfType<Panel>())
            {
                var toggle = pnl.Controls.OfType<ToggleButton>().FirstOrDefault();
                var txt = pnl.Controls.OfType<TextBox>().FirstOrDefault();

                if (toggle != null && txt != null && toggle.Checked)
                {
                    if (decimal.TryParse(txt.Text, out decimal val))
                    {
                        result.Add((toggle.Tag.ToString(), val));
                    }
                    else
                    {
                        result.Add((toggle.Tag.ToString(), 0));
                    }
                }
            }

            return result;
        }

        internal IEnumerable<Panel> ColorsPanels()
            => flpColorsControls.Controls.OfType<Panel>();

        private void btnAccept_Click(object sender, EventArgs e)
        {
            cls.BtnAccept();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
