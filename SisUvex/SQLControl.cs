using System.Data;
using System.Data.SqlClient;
using SisUvex;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SisUvex.Configuracion;
using System.Configuration;
using System.Windows.Forms;

namespace SisUvex
{
    public class SQLControl
    {
        static public string cadenaConexion = "";
        public SqlConnection cnn = new SqlConnection();
        public SqlTransaction transaction;
        public ClsXmlArchivos xml = new ClsXmlArchivos();
        //public string server, database, user, password, cadenaTexto;
        bool conext = false;
        private ClsConfig conf = new ClsConfig();
        public string server;
        public string dbConn;
        public string userConn;
        public string passConn;
        public string dbWrite;
        public string userWrite;
        public string passWrite;
        public string dbEmployees;
        public SQLControl()
        {
            if (ClsConfig.Server == null)
            {
                try
                {
                    xml.PutInTempFile();
                    conf.Leer();
                    xml.PutInConfFile();
                    conf.Guardar();
                    xml.DeleteXmlConTemp();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "[Error : SQLControl]");
                }
            }
            server = ClsConfig.Server;
            dbConn = ClsConfig.DbConn;
            userConn = ClsConfig.UserConn;
            passConn = ClsConfig.PassConn;
            dbWrite = ClsConfig.DbWrite;
            userWrite = ClsConfig.UserWrite;
            passWrite = ClsConfig.PassWrite;
            dbEmployees = ClsConfig.DbEmployees;
        }

        public string WriteSvr()
        {
            cadenaConexion = $"Data Source = {server}; Initial Catalog = {dbWrite};TrustServerCertificate=true; Persist Security Info = True; User ID = {userWrite}; Password = {passWrite}";

            return cadenaConexion;
        }
        public string ReadSvr()
        {
            cadenaConexion = $"Data Source = {server}; Initial Catalog = {dbConn} ; Persist Security Info = True; User ID =  {userConn} ; Password =  {passConn}";
            return cadenaConexion;
        }

         
        public bool ValidateConnection()
        {
            return conext;
        }

        public bool Login(string username, string pass)
        {
            bool confirm = false;
            try
            {
                OpenConectionRead();
                SqlCommand cmd = new SqlCommand("sp_loginCrypt", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", username); //es el del Login

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string druser = dr.GetString(0);
                    string drpass = dr.GetString(1);
                    string dracces = dr.GetString(2);

                    if (druser == username && BCrypt.Net.BCrypt.Verify(pass, drpass) == true)
                    {
                        User.SetUserName(druser);
                        User.SetAccessLevel(int.Parse(dracces));
                        cadenaConexion = ""; //Para poder leer la que 
                        return confirm = true;
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "[Error : Login]");
            }
            finally
            {
                CloseConectionRead();
            }
            return confirm;
        }       

        public void OpenConectionRead()
        {
            if (cnn.State == ConnectionState.Closed)
            {
                ReadSvr();
                cnn.ConnectionString = cadenaConexion;
                cnn.Open();
                conext = true;
            }
            conext = true;
        }

        public void OpenConectionWrite()
        {
            if (cnn.State == ConnectionState.Closed)
            {
                if (cadenaConexion == "")
                    WriteSvr();
                cnn.ConnectionString = cadenaConexion;
                cnn.Open();
            }
            conext = true;
        }

        public void CloseConectionWrite()
        {
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }
            conext = false;

        }

        public void CloseConectionRead()
        {
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
                cadenaConexion = "";
            }
            conext = false;
        }

        public void ChangeConectionSettingsMessege()
        {
            DialogResult result = MessageBox.Show("No se pudo conectar a la base de datos.\n¿Desea cambiar la configuración de conexión?", "Conexión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                FrmConfiguracion frmConfig = new FrmConfiguracion();
                frmConfig.ShowDialog();
            }
            else
                Application.Exit();
        }
        public void BeginTransaction()
        {
            if (cnn.State == ConnectionState.Closed)
            {
                //MessageBox.Show("BEGIN TRANSACTION");
                OpenConectionWrite();
            }
            transaction = cnn.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (cnn.State == ConnectionState.Open)
            {
                //MessageBox.Show("BEGIN commit");

                transaction.Commit();
                CloseConectionWrite();
            }
        }

        public void RollbackTransaction()
        {
            if (cnn.State == ConnectionState.Open)
            {
                transaction.Rollback();
                CloseConectionWrite();
            }
        }



    }
}//namespace SisUvex
