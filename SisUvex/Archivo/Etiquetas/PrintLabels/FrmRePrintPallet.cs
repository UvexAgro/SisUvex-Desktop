using SisUvex.Archivo.Etiquetas.PrintLabels;
using SisUvex.Catalogos.Metods;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SisUvex.Archivo.Reimprimir
{
    public partial class FrmRePrintPallet : Form
    {
        private DataTable? _ultimaTablaPallet;
        private string? _palletConsultadoNormalizado;

        public FrmRePrintPallet()
        {
            InitializeComponent();
        }

        private void FrmRePrintPallet_Load(object sender, EventArgs e)
        {
            LimpiarVistas();
        }

        private void btnConsultar_Click(object sender, EventArgs e) => ConsultarPallet();

        private void txbRePrintCode_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ConsultarPallet();
            }
        }

        private void LimpiarVistas()
        {
            _ultimaTablaPallet = null;
            _palletConsultadoNormalizado = null;
            ConstruirPanelInfo(null);
            dgvPalletsEstiba.DataSource = null;
        }

        private static string NormalizarCodigoPallet(string texto)
        {
            string t = texto.Trim();
            if (t.Length == 0)
                return string.Empty;
            if (int.TryParse(t, out int n))
                return n.ToString("D5", System.Globalization.CultureInfo.InvariantCulture);
            return t.PadLeft(5, '0');
        }

        private void ConsultarPallet()
        {
            string id = NormalizarCodigoPallet(txbRePrintCode.Text);
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Ingrese un código de pallet.", "Consultar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarVistas();
                return;
            }

            txbRePrintCode.Text = id;
            _palletConsultadoNormalizado = id;

            DataTable dt = ClsReprintPallet.GetPalletPackConTable(id);
            if (dt.Rows.Count == 0)
            {
                _ultimaTablaPallet = null;
                MessageBox.Show("No se encontró el pallet en vw_PackPalletCon.", "Consultar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ConstruirPanelInfo(null);
                dgvPalletsEstiba.DataSource = null;
                return;
            }

            _ultimaTablaPallet = dt;
            DataRow fila = dt.Rows[0];
            ConstruirPanelInfo(fila);

            if (ClsReprintPallet.ColumnExists(dt, "Cajas"))
            {
                object? cajas = ClsReprintPallet.GetColumnValue(fila, "Cajas");
                txbUpdateBoxes.Text = ClsReprintPallet.FormatViewCellValue(cajas);
            }
            else
                txbUpdateBoxes.Clear();

            object? estiba = ClsReprintPallet.GetColumnValue(fila, "Estiba");
            DataTable dtEstiba = ClsReprintPallet.GetEstibaPalletSummary(dt, estiba);
            dgvPalletsEstiba.DataSource = dtEstiba;
        }

        /// <summary>Identificador de pallet desde la fila enlazada (fiable al ordenar columnas).</summary>
        private static string ObtenerIdPalletFila(DataGridViewRow row, string colPallet)
        {
            if (row.DataBoundItem is DataRowView drv)
            {
                DataTable t = drv.DataView.Table;
                DataColumn? col = t.Columns.Cast<DataColumn>().FirstOrDefault(c =>
                    string.Equals(c.ColumnName, colPallet, StringComparison.OrdinalIgnoreCase));
                if (col != null)
                {
                    object? o = drv[col.ColumnName];
                    if (o != null && o != DBNull.Value)
                        return o.ToString()?.Trim() ?? string.Empty;
                }
            }

            object? v = row.Cells[colPallet].Value;
            return v?.ToString()?.Trim() ?? string.Empty;
        }

        private void ConstruirPanelInfo(DataRow? fila)
        {
            tablePalletInfo.SuspendLayout();
            tablePalletInfo.Controls.Clear();
            tablePalletInfo.RowStyles.Clear();
            tablePalletInfo.ColumnStyles.Clear();
            tablePalletInfo.ColumnCount = 2;
            tablePalletInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tablePalletInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            if (fila == null)
            {
                tablePalletInfo.RowCount = 1;
                tablePalletInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
                var vacío = new Label
                {
                    Text = "Consulte un pallet para ver los campos de la vista.",
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Segoe UI", 9F, FontStyle.Italic),
                    ForeColor = SystemColors.GrayText,
                    Margin = new Padding(4)
                };
                tablePalletInfo.SetColumnSpan(vacío, 2);
                tablePalletInfo.Controls.Add(vacío, 0, 0);
                tablePalletInfo.ResumeLayout(true);
                return;
            }

            int n = fila.Table.Columns.Count;
            tablePalletInfo.RowCount = n;
            for (int i = 0; i < n; i++)
            {
                tablePalletInfo.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                DataColumn col = fila.Table.Columns[i];
                string valor = ClsReprintPallet.FormatViewCellValue(fila[col]);

                var lblNombre = new Label
                {
                    Text = col.ColumnName + ":",
                    AutoSize = true,
                    MaximumSize = new Size(190, 0),
                    Margin = new Padding(4, 6, 4, 2),
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    ForeColor = SystemColors.ControlText
                };
                var lblValor = new Label
                {
                    Text = string.IsNullOrEmpty(valor) ? "—" : valor,
                    AutoSize = true,
                    MaximumSize = new Size(340, 0),
                    Margin = new Padding(4, 6, 4, 2),
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = SystemColors.ControlText
                };
                tablePalletInfo.Controls.Add(lblNombre, 0, i);
                tablePalletInfo.Controls.Add(lblValor, 1, i);
            }

            tablePalletInfo.ResumeLayout(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string idPallet = NormalizarCodigoPallet(txbRePrintCode.Text);
            if (string.IsNullOrEmpty(idPallet))
            {
                MessageBox.Show("Ingrese y consulte un código de pallet.", "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_ultimaTablaPallet == null || _ultimaTablaPallet.Rows.Count == 0
                || !string.Equals(_palletConsultadoNormalizado, idPallet, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Pulse «Consultar» primero y verifique que el pallet exista.", "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool reverseOrientation = chbRevesePalletTag.Checked;
            bool showDate = !chbFechaOmitidaPallet.Checked;
            int copias = (int)nudCopiasEtiquetas.Value;

            if (!string.IsNullOrWhiteSpace(txbUpdateBoxes.Text))
            {
                if (!int.TryParse(txbUpdateBoxes.Text.Trim(), out int palletBoxes))
                {
                    MessageBox.Show("Las cajas deben ser un número entero.", "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ClsPalletCreate.UpdatePallet(idPallet, palletBoxes);
            }

            ClsReprintPallet.ReprintPalletTag(idPallet, copias, reverseOrientation, showDate);
        }
    }
}
