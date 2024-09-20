using DocumentFormat.OpenXml.Math;
using SisUvex.Catalogos.Presentacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SisUvex.Catalogos.GTIN_UPC
{
    internal class Egtin
    {
        private string idGtin;
        private int active;
        private string gtinNumber;
        private string upcNumber;
        private string plu;
        private string idVariety;
        private string idDistributor;
        private string idContainer;
        private string idPresentation;
        private string lbs;
        private string palletBoxes;
        private string preLabel;
        private string postLabel;
        private string price;
        private string ptiTag;
        private string loadPallets;

        private SQLControl sql = new SQLControl();
        public string IdGtin
        {
            get { return idGtin; }
            set { idGtin = value; }
        }
        public int Active
        {
            get { return active; }
            set { active = value; }
        }
        public string GtinNumber
        {
            get { return gtinNumber; }
            set { gtinNumber = value; }
        }
        public string UpcNumber
        {
            get { return upcNumber; }
            set { upcNumber = value; }
        }
        public string Plu
        {
            get { return plu; }
            set { plu = value; }
        }
        public string IdVariety
        {
            get { return idVariety; }
            set { idVariety = value; }
        }
        public string IdDistributor
        {
            get { return idDistributor; }
            set { idDistributor = value; }
        }
        public string IdContainer
        {
            get { return idContainer; }
            set { idContainer = value; }
        }
        public string IdPresentation
        {
            get { return idPresentation; }
            set { idPresentation = value; }
        }
        public string Lbs
        {
            get { return lbs; }
            set { lbs = value; }
        }
        public string PalletBoxes
        {
            get { return palletBoxes; }
            set { palletBoxes = value; }
        }
        public string PreLabel
        {
            get { return preLabel; }
            set { preLabel = value; }
        }
        public string PostLabel
        {
            get { return postLabel; }
            set { postLabel = value; }
        }
        public string Price
        {
            get { return price; }
            set { price = value; }
        }
        public string PtiTag
        {
            get { return ptiTag; }
            set { ptiTag = value; }
        }
        public string LoadPallets
        {
            get { return loadPallets; }
            set { loadPallets = value; }
        }
        public void SetGtin(string idGtin)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Pack_GTIN WHERE id_GTIN = '{idGtin}'", sql.cnn);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    IdGtin = dr.GetValue(dr.GetOrdinal("id_GTIN")).ToString();
                    GtinNumber = dr.GetValue(dr.GetOrdinal("v_GTIN")).ToString();
                    UpcNumber = dr.GetValue(dr.GetOrdinal("v_UPC")).ToString();
                    Plu = dr.GetValue(dr.GetOrdinal("c_PLU")).ToString();
                    IdVariety = dr.GetValue(dr.GetOrdinal("id_variety")).ToString();
                    IdDistributor = dr.GetValue(dr.GetOrdinal("id_distributor")).ToString();
                    IdContainer = dr.GetValue(dr.GetOrdinal("id_container")).ToString();
                    IdPresentation = dr.GetValue(dr.GetOrdinal("id_presentation")).ToString();
                    Lbs = dr.GetValue(dr.GetOrdinal("n_lbs")).ToString();
                    PalletBoxes = dr.GetValue(dr.GetOrdinal("i_palletBoxes")).ToString();
                    Active = int.Parse(dr.GetValue(dr.GetOrdinal("c_active")).ToString());
                    PreLabel = dr.GetValue(dr.GetOrdinal("v_preLabel")).ToString();
                    PostLabel = dr.GetValue(dr.GetOrdinal("v_postLabel")).ToString();
                    Price = dr.GetValue(dr.GetOrdinal("id_price")).ToString();
                    PtiTag = dr.GetValue(dr.GetOrdinal("id_pti")).ToString();
                    LoadPallets = dr.GetValue(dr.GetOrdinal("i_loadPallets")).ToString();
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
