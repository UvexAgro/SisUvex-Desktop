using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Nomina.Padron.SUA
{
    public partial class FrmSUALoad : Form
    {
        public FrmSUALoad()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Cobranza\SUA\SUA.MDB;Jet OLEDB:Database Password=S5@N52V49;";
            string query = "SELECT NSS FROM MovtosImp";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    // Limpiar el TextBox antes de agregar datos
                    textBox1.Clear();

                    while (reader.Read())
                    {
                        // Agregar cada NSS en una nueva línea
                        textBox1.AppendText(reader["NSS"].ToString() + Environment.NewLine);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void FrmSUALoad_Load(object sender, EventArgs e)
        {

        }
    }
}
