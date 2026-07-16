namespace SisUvex.Usuarios.UserCrud;

/// <summary>
/// Cambio de contraseña sobre la base de usuarios. Abrir con <see cref="ClsUserCrud.OpenFrmChangePassword(string)"/>
/// o cargar con <see cref="LoadByUserCode"/> antes de <c>ShowDialog</c>.
/// </summary>
internal partial class FrmUserChangePass : Form
{
    public FrmUserChangePass()
    {
        InitializeComponent();
    }

    /// <summary>Carga datos de solo lectura a partir de <c>c_codigo_usu</c>.</summary>
    public void LoadByUserCode(string userCode)
    {
        EUserCrud e = new();
        e.GetUser(userCode);

        txbId.Text = e.IdUser ?? "";
        txbUserName.Text = e.UserDisplayName ?? "";
        txbIdEmployee.Text = e.IdEmployee ?? "";
        txbEmployeeName.Text = e.Name ?? "";
    }

    private void btnAccept_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txbId.Text))
        {
            MessageBox.Show("No hay un usuario cargado.", "Cambiar contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (txbPassword.Text != txbPasswordConfirm.Text)
        {
            MessageBox.Show("La contraseña y la confirmación no coinciden.", "Cambiar contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(txbPassword.Text))
        {
            MessageBox.Show("Debe ingresar una contraseña.", "Cambiar contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string hash = BCrypt.Net.BCrypt.HashPassword(txbPassword.Text);
        
        if (EUserCrud.ChangePasswordProcedure(txbId.Text, hash))
        {
            MessageBox.Show("La contraseña se actualizó correctamente.", "Cambiar contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        Close();
    }
}
