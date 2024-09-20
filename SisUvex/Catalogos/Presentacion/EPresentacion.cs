using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace SisUvex.Catalogos.Presentacion
{
    internal class EPresentacion
    {
        private string idPresentation;
        private string namePresentation;
        private string idCategory;
        private string idCrop;
        private string idColor;
        private string market;
        private int active;

        private SQLControl sql = new SQLControl();
        public string IdPresentation
        {
            get { return idPresentation; }
            set { idPresentation = value; }
        }
        public string NamePresentation
        {
            get { return namePresentation; }
            set { namePresentation = value; }
        }
        public string IdCategory
        {
            get { return idCategory; }
            set { idCategory = value; }
        }
        public string IdCrop
        {
            get { return idCrop; }
            set { idCrop = value; }
        }
        public string IdColor
        {
            get { return idColor; }
            set { idColor = value; }
        }
        public string Market
        {
            get { return market; }
            set { market = value; }
        }
        public int Active
        {
            get { return active; }
            set { active = value; }
        }

        public void SetPresentation(string idPresentacion)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Pack_Presentation WHERE id_presentation = '{idPresentacion}'", sql.cnn);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    IdPresentation = dr.GetValue(dr.GetOrdinal("id_presentation")).ToString();
                    NamePresentation = dr.GetValue(dr.GetOrdinal("v_namePresentation")).ToString();
                    IdCategory = dr.GetValue(dr.GetOrdinal("id_category")).ToString();
                    IdCrop = dr.GetValue(dr.GetOrdinal("id_crop")).ToString();
                    IdColor = dr.GetValue(dr.GetOrdinal("id_color")).ToString();
                    Market = dr.GetValue(dr.GetOrdinal("c_marketTarget")).ToString();
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
