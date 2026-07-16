using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SisUvex.Usuarios
{
    public partial class CreacionUsuario : Form
    {
        SQLControl sql = new SQLControl();

        public CreacionUsuario()
        {
            InitializeComponent();
        }

        private void CreacionUsuario_Load(object sender, EventArgs e)
        {

        }

        public void CrearUsuario(string username, string accesibilidad, string pass, string passConfirm)
        {
            try
            {
                if (!ComprobarUsuario(username))
                {
                    if (passConfirm != pass)
                    {
                        MessageBox.Show("[CrearUsuario] La contraseña es incorrectas");
                    }
                    else
                    {
                        sql.OpenConectionRead();
                        string passCrypt = BCrypt.Net.BCrypt.HashPassword(pass);

                        SqlCommand cmdUserRegister = new SqlCommand("sp_userRegister", sql.cnn); //spUserRegister

                        cmdUserRegister.CommandType = CommandType.StoredProcedure;
                        cmdUserRegister.Parameters.AddWithValue("@usuario", username.ToUpper());
                        cmdUserRegister.Parameters.AddWithValue("@pass", passCrypt);
                        cmdUserRegister.Parameters.AddWithValue("@accesibilidad", accesibilidad);
                        cmdUserRegister.Parameters.AddWithValue("@creador", "ADMIN");
                        cmdUserRegister.ExecuteNonQuery();

                        sql.CloseConectionRead();

                        if (ComprobarUsuario(username))
                        {
                            MessageBox.Show($"[CrearUsuario] Se ha creado el usuario: {username}");
                            txbUsername.Text = "";

                        }
                    }
                    //SI SE COMPLETÓ CON ÉXITO
                }
                else //SI EL USUARIO EXISTE
                { MessageBox.Show($"[CrearUsuario] El usuario {username} ya existe, intente con otro."); }
            }
            catch (Exception e) { MessageBox.Show("Error: " + e.Message, "[Error : CreacionUsuario]"); }
            finally
            {
                sql.CloseConectionRead();
                txbPass.Text = string.Empty;
                txbPassConfirm.Text = string.Empty;
            }
        }

        public bool ComprobarUsuario(string username)
        {
            bool resultado = false;
            int user = 0;
            try
            {
                sql.OpenConectionRead();
                SqlCommand cmdUserExist = new SqlCommand("sp_userExist", sql.cnn);
                cmdUserExist.CommandType = CommandType.StoredProcedure;
                cmdUserExist.Parameters.AddWithValue("@usuario", username);
                SqlDataReader dr = cmdUserExist.ExecuteReader();

                if (dr.Read())
                {
                    user = dr.GetInt32(0);
                    if (user > 0)
                    {
                        resultado = true;
                    }
                }
            }
            catch (Exception e) { MessageBox.Show("Error: " + e.Message, "[Error : CreacionUsuario]"); }
            finally
            {
                sql.CloseConectionRead();
            }
            return resultado;
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            CrearUsuario(txbUsername.Text.ToUpper(), nudAccesibilidad.Value.ToString(), txbPass.Text, txbPassConfirm.Text);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txbUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }//clase
}//namespace
