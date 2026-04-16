using System.Data;
using System.Media;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;

namespace SisUvex.Usuarios.UserCrud;

internal partial class FrmUserAdd : Form
{
    public ClsUserCrud cls = null!;

    public FrmUserAdd()
    {
        InitializeComponent();
    }

    private void btnSearchEmployee_Click(object sender, EventArgs e)
    {
        ClsSelectionForm sel = new();

        sel.OpenSelectionForm("EmployeeBasic", "Código");

        if (!string.IsNullOrEmpty(sel.SelectedValue))
        {
            DataTable? dt = ClsObject.Employee.GetDtFullName(sel.SelectedValue);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txbEmployeeName.Text = row[ClsObject.Employee.ColumnName].ToString();
                txbIdEmployee.Text = row[ClsObject.Employee.ColumnId].ToString();
            }
            else
            {
                SystemSounds.Beep.Play();
                txbEmployeeName.Text = string.Empty;
                txbIdEmployee.Text = string.Empty;
                txbIdEmployee.Focus();
                txbIdEmployee.SelectAll();
            }
        }
    }

    private void FrmUserAdd_Load(object sender, EventArgs e)
    {
        cls ??= new();
        cls._frmAdd ??= this;
        cls.BeginFormAdd();
    }

    private void btnAccept_Click(object sender, EventArgs e)
    {
        cls.BtnAccept();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        Close();
    }
}
