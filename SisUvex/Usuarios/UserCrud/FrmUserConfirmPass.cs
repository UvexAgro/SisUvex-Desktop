namespace SisUvex.Usuarios.UserCrud;

/// <summary>
/// Cambio de contraseña sobre la base de usuarios. Abrir con <see cref="ClsUserCrud.OpenFrmChangePassword(string)"/>
/// o cargar con <see cref="LoadByUserCode"/> antes de <c>ShowDialog</c>.
/// </summary>
internal partial class FrmUserConfirmPass : Form
{
    public bool PasswordConfirmed { get; private set; } = false;

    public static bool OpenValidateUserPassword()
    {
        FrmUserConfirmPass frm = new FrmUserConfirmPass();
        frm.ShowDialog();
        return frm.PasswordConfirmed;
    }

    public FrmUserConfirmPass()
    {
        InitializeComponent();
    }

    private void btnAccept_Click(object sender, EventArgs e)
    {
        ValidatePassword();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        PasswordConfirmed = false;
        Close();
    }

    private void FrmUserConfirmPass_Load(object sender, EventArgs e)
    {
        txbUserName.Text = User.GetUserName() ?? "";
    }

    private void txbPassword_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
        {
            ValidatePassword();
        }
    }
    private void ValidatePassword()
    {
        if (User.ValidateUserPassword(User.GetUserName() ?? "", txbPassword.Text))
        {
            PasswordConfirmed = true;
            Close();
        }
        else
        {
            MessageBox.Show("Contraseña incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txbPassword.Focus();
            txbPassword.SelectAll();
        }
    }
}
