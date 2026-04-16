using System.Media;
using SisUvex.Catalogos.Metods;

namespace SisUvex.Usuarios.Role
{
    internal partial class FrmUserRoleCat : Form
    {
        public ClsUserRole cls = null!;

        public FrmUserRoleCat()
        {
            InitializeComponent();
        }

        private void FrmUserRoleCat_Load(object sender, EventArgs e)
        {
            cls ??= new();
            cls._frmCat ??= this;
            cls.BeginFormCat();

            FormatRolePermissionsGrid(dgvCatalog);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cls.OpenFrmAdd();

            if (cls.IsAddUpdate)
                cls.AddNewRowByIdInDGVCatalog();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            OpenFrmModifyFromCat();
        }

        private void OpenFrmModifyFromCat()
        {
            if (dgvCatalog.SelectedRows.Count == 0)
            {
                SystemSounds.Exclamation.Play();
                return;
            }

            cls.OpenFrmModify(dgvCatalog.Rows[dgvCatalog.SelectedRows[0].Index].Cells[ClsObject.Column.id].Value.ToString());

            if (cls.IsModifyUpdate)
                cls.ModifyRowByIdInDGVCatalog();
        }

        private void chbRemoved_CheckedChanged(object sender, EventArgs e)
        {
            cls.ChbRemovedFilter();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCatalog.SelectedRows.Count != 0)
            {
                cls.BtnActiveProcedure(dgvCatalog.Rows[dgvCatalog.SelectedRows[0].Index].Cells[ClsObject.Column.id].Value.ToString(), "0");
            }
            else
                SystemSounds.Exclamation.Play();
        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            if (dgvCatalog.SelectedRows.Count != 0)
            {
                cls.BtnActiveProcedure(dgvCatalog.Rows[dgvCatalog.SelectedRows[0].Index].Cells[ClsObject.Column.id].Value.ToString(), "1");
            }
            else
                SystemSounds.Exclamation.Play();
        }

        private void dgvCatalog_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return; // 👈 ignora encabezados

            OpenFrmModifyFromCat();
        }

        //formatos encabezados y columnas
        public static void FormatRolePermissionsGrid(DataGridView dgv, int startColumnIndex = 3, int permissionsWidth = 60, int headerHeight = 45)
        {
            if (dgv == null || dgv.Columns.Count == 0)
                return;

            if (startColumnIndex < 0 || startColumnIndex >= dgv.Columns.Count)
                return;

            dgv.AutoGenerateColumns = false;
            dgv.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv.ColumnHeadersHeight = headerHeight;

            for (int i = startColumnIndex; i < dgv.Columns.Count; i++)
            {
                DataGridViewColumn oldColumn = dgv.Columns[i];

                string headerText = oldColumn.HeaderText;
                string headerText2Lines = SplitHeaderInTwoLines(headerText);

                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn
                {
                    Name = oldColumn.Name,
                    HeaderText = headerText2Lines,
                    DataPropertyName = oldColumn.DataPropertyName,
                    Width = permissionsWidth,
                    MinimumWidth = permissionsWidth,
                    ReadOnly = oldColumn.ReadOnly,
                    Visible = oldColumn.Visible,
                    DisplayIndex = oldColumn.DisplayIndex,
                    SortMode = DataGridViewColumnSortMode.Automatic,
                    TrueValue = "1",
                    FalseValue = "0",
                    IndeterminateValue = DBNull.Value,
                    ThreeState = false,
                    Resizable = oldColumn.Resizable
                };

                int index = oldColumn.Index;
                dgv.Columns.RemoveAt(index);
                dgv.Columns.Insert(index, checkColumn);
            }

            for (int i = startColumnIndex; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private static string SplitHeaderInTwoLines(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (words.Length <= 1)
                return text;

            if (words.Length == 2)
                return words[0] + Environment.NewLine + words[1];

            int middle = words.Length / 2;

            string line1 = string.Join(" ", words.Take(middle));
            string line2 = string.Join(" ", words.Skip(middle));

            return line1 + Environment.NewLine + line2;
        }
    }

}