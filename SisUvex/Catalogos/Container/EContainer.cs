using DocumentFormat.OpenXml.Presentation;
using SisUvex.Catalogos.Presentacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SisUvex.Catalogos.Container
{
    internal class EContainer
    {
        private string idContainer;
        private string nameContainer;
        private int active;

        private SQLControl sql = new SQLControl();


        public string IdContainer
        {
            get { return idContainer; }
            set { idContainer = value; }
        }

        public string NameContainer
        {
            get { return nameContainer; }
            set { nameContainer = value; }
        }

        public int Active
        {
            get { return active; }
            set { active = value; }
        }

        public void SetContainer(string idContainer)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Pack_Container WHERE id_container = '{idContainer}'", sql.cnn);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    IdContainer = dr.GetValue(dr.GetOrdinal("id_container")).ToString();
                    NameContainer = dr.GetValue(dr.GetOrdinal("v_nameContainer")).ToString();
                    Active = int.Parse(dr.GetValue(dr.GetOrdinal("c_active")).ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo añadir");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
    }
}
