using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Catalogos.Material
{
    internal class EMaterial
    {
        private string idMaterial;
        private string idMatType;
        private int quantMat;
        private string nameMat;
        private decimal quantMatPerUnit;
        private string idColor;
        private string idDistributor;
        private string nameMatLabel;
        private string idUnit;

        private SQLControl sql = new SQLControl();

        public string IdMaterial
        {
            get { return idMaterial; }
            set { idMaterial = value; }
        }
        public string IdMatType
        {
            get { return idMatType; }
            set { idMatType = value; }
        }
        public int QuantMat
        {
            get { return quantMat; }
            set { quantMat = value; }
        }
        public string NameMat
        {
            get { return nameMat; }
            set { nameMat = value; }
        }
        public decimal QuantMatPerUnit
        {
            get { return quantMatPerUnit; }
            set { quantMatPerUnit = value; }
        }
        public string IdColor
        {
            get { return idColor; }
            set { idColor = value; }
        }
        public string IdDistributor
        {
            get { return idDistributor; }
            set { idDistributor = value; }
        }
        public string NameMatLabel
        {
            get { return nameMatLabel; }
            set { nameMatLabel = value; }
        }
        public string IdUnit
        {
            get { return idUnit; }
            set { idUnit = value; }
        }

        public void SetMaterial(string idMaterial)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Pack_Material WHERE id_material = '{idMaterial}'", sql.cnn);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    IdMaterial = dr.GetValue(dr.GetOrdinal("id_material")).ToString();
                    IdMatType = dr.GetValue(dr.GetOrdinal("id_matType")).ToString();
                    QuantMat = int.Parse(dr.GetValue(dr.GetOrdinal("i_quantMat")).ToString());
                    NameMat = dr.GetValue(dr.GetOrdinal("v_nameMat")).ToString();
                    QuantMatPerUnit = decimal.Parse(dr.GetValue(dr.GetOrdinal("n_quantMatPerUnit")).ToString());
                    IdColor = dr.GetValue(dr.GetOrdinal("id_color")).ToString();
                    IdDistributor = dr.GetValue(dr.GetOrdinal("id_distributor")).ToString();
                    NameMatLabel = dr.GetValue(dr.GetOrdinal("v_nameMatLabel")).ToString();
                    IdUnit = dr.GetValue(dr.GetOrdinal("id_unit")).ToString();
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
