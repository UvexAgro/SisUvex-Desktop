using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.Values;

namespace SisUvex.Archivo.Manifiesto.ManifestTemplates;

internal class EManifestTemplate
{
    public string? IdTemplate { get; set; }
    public int Active { get; set; }
    public string? NameTemplate { get; set; }
    public string? Description { get; set; }
    public string? IdDistributor { get; set; }
    public string? IdConsignee { get; set; }
    public string? IdGrower { get; set; }
    public string? IdUSAgencyTrade { get; set; }
    public string? IdMXAgencyTrade { get; set; }
    public string? IdCityCrossPoint { get; set; }
    public string? IdCityDestiny { get; set; }
    public string? IdCrop { get; set; }
    public bool printManifest { get; set; }
    public bool printMaping { get; set; }
    public bool printPackingList { get; set; }
    public bool printManifestPerFarm { get; set; }
    public bool printShowSize { get; set; }
    public bool printExcelLayout { get; set; }


    public static string GetNextId()
    {
        string result = ClsQuerysDB.GetData(
            "SELECT RIGHT('00' + CAST(ISNULL(MAX(CAST(id_template AS INT)), 0) + 1 AS VARCHAR(2)), 2) FROM Pack_ManifestTemplates");

        return string.IsNullOrEmpty(result) ? "01" : result;
    }

    private static string? ReadField(SqlDataReader dr, string column)
    {
        int o = dr.GetOrdinal(column);
        if (dr.IsDBNull(o))
            return null;
        return dr.GetValue(o).ToString();
    }

    private static int CharActiveToInt(object? value)
    {
        if (value == null || value == DBNull.Value)
            return 0;
        string? s = value.ToString();
        return s == "1" ? 1 : 0;
    }

    public void GetManifestTemplate(string? idTemplate)
    {
        if (string.IsNullOrWhiteSpace(idTemplate))
            return;

        SQLControl sql = new();
        try
        {
            sql.OpenConectionWrite();
            SqlCommand cmd = new("SELECT * FROM Pack_ManifestTemplates WHERE id_template = @id", sql.cnn);
            cmd.Parameters.AddWithValue("@id", idTemplate.Trim());

            using SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.Read())
                return;

            IdTemplate = ReadField(dr, "id_template");
            NameTemplate = ReadField(dr, "v_nameTemplate");
            Description = ReadField(dr, "v_description");
            IdDistributor = ReadField(dr, "id_distributor");
            IdConsignee = ReadField(dr, "id_consignee");
            IdGrower = ReadField(dr, "id_grower");
            IdUSAgencyTrade = ReadField(dr, "id_USAgencyTrade");
            IdMXAgencyTrade = ReadField(dr, "id_MXAgencyTrade");
            IdCityCrossPoint = ReadField(dr, "id_cityCrossPoint");
            IdCityDestiny = ReadField(dr, "id_cityDestiny");
            IdCrop = ReadField(dr, "id_crop");
            Active = CharActiveToInt(dr["c_active"]);
            printManifest = dr["c_printManifest"].ToString() == "1";
            printMaping = dr["c_printMaping"].ToString() == "1";
            printPackingList = dr["c_printPackingList"].ToString() == "1";
            printManifestPerFarm = dr["c_printManifestPerField"].ToString() == "1";
            printShowSize = dr["c_printShowSize"].ToString() == "1";
            printExcelLayout = dr["c_printExcelLayout"].ToString() == "1";
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Obtener plantilla de manifiesto");
        }
        finally
        {
            sql.CloseConectionWrite();
        }
    }

    public (bool success, string? id) AddProcedure()
    {
        SQLControl sql = new();
        try
        {
            sql.OpenConectionWrite();
            SqlCommand cmd = new("sp_PackManifestTemplatesExecute", sql.cnn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@action", "ADD");
            cmd.Parameters.AddWithValue("@v_nameTemplate", NameTemplate);
            cmd.Parameters.AddWithValue("@v_description", ClsValues.IfEmptyToDBNull(Description));
            cmd.Parameters.AddWithValue("@id_distributor", ClsValues.IfEmptyToDBNull(IdDistributor));
            cmd.Parameters.AddWithValue("@id_consignee", ClsValues.IfEmptyToDBNull(IdConsignee));
            cmd.Parameters.AddWithValue("@id_grower", ClsValues.IfEmptyToDBNull(IdGrower));
            cmd.Parameters.AddWithValue("@id_USAgencyTrade", ClsValues.IfEmptyToDBNull(IdUSAgencyTrade));
            cmd.Parameters.AddWithValue("@id_MXAgencyTrade", ClsValues.IfEmptyToDBNull(IdMXAgencyTrade));
            cmd.Parameters.AddWithValue("@id_cityCrossPoint", ClsValues.IfEmptyToDBNull(IdCityCrossPoint));
            cmd.Parameters.AddWithValue("@id_cityDestiny", ClsValues.IfEmptyToDBNull(IdCityDestiny));
            cmd.Parameters.AddWithValue("@c_active", Active == 1 ? "1" : "0");
            cmd.Parameters.AddWithValue("@id_crop", ClsValues.IfEmptyToDBNull(IdCrop));
            cmd.Parameters.AddWithValue("@user", User.GetUserName());
            cmd.Parameters.AddWithValue("@c_printManifest", printManifest ? "1" : "0");
            cmd.Parameters.AddWithValue("@c_printMaping", printMaping ? "1" : "0");
            cmd.Parameters.AddWithValue("@c_printPackingList", printPackingList ? "1" : "0");
            cmd.Parameters.AddWithValue("@c_printManifestPerField", printManifestPerFarm ? "1" : "0");
            cmd.Parameters.AddWithValue("@c_printShowSize", printShowSize ? "1" : "0");
            cmd.Parameters.AddWithValue("@c_printExcelLayout", printExcelLayout ? "1" : "0");

            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string? id = ReadField(dr, "id_template");
                return (true, id);
            }

            return (false, null);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Añadir plantilla de manifiesto");
            return (false, null);
        }
        finally
        {
            sql.CloseConectionWrite();
        }
    }

    public (bool success, string? id) ModifyProcedure()
    {
        SQLControl sql = new();
        try
        {
            sql.OpenConectionWrite();
            SqlCommand cmd = new("sp_PackManifestTemplatesExecute", sql.cnn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@action", "MODIFY");
            cmd.Parameters.AddWithValue("@id_template", IdTemplate);
            cmd.Parameters.AddWithValue("@v_nameTemplate", NameTemplate);
            cmd.Parameters.AddWithValue("@v_description", ClsValues.IfEmptyToDBNull(Description));
            cmd.Parameters.AddWithValue("@id_distributor", ClsValues.IfEmptyToDBNull(IdDistributor));
            cmd.Parameters.AddWithValue("@id_consignee", ClsValues.IfEmptyToDBNull(IdConsignee));
            cmd.Parameters.AddWithValue("@id_grower", ClsValues.IfEmptyToDBNull(IdGrower));
            cmd.Parameters.AddWithValue("@id_USAgencyTrade", ClsValues.IfEmptyToDBNull(IdUSAgencyTrade));
            cmd.Parameters.AddWithValue("@id_MXAgencyTrade", ClsValues.IfEmptyToDBNull(IdMXAgencyTrade));
            cmd.Parameters.AddWithValue("@id_cityCrossPoint", ClsValues.IfEmptyToDBNull(IdCityCrossPoint));
            cmd.Parameters.AddWithValue("@id_cityDestiny", ClsValues.IfEmptyToDBNull(IdCityDestiny));
            cmd.Parameters.AddWithValue("@c_active", Active == 1 ? "1" : "0");
            cmd.Parameters.AddWithValue("@id_crop", ClsValues.IfEmptyToDBNull(IdCrop));
            cmd.Parameters.AddWithValue("@user", User.GetUserName());
            cmd.Parameters.AddWithValue("@c_printManifest", printManifest ? "1" : "0");
            cmd.Parameters.AddWithValue("@c_printMaping", printMaping ? "1" : "0");
            cmd.Parameters.AddWithValue("@c_printPackingList", printPackingList ? "1" : "0");
            cmd.Parameters.AddWithValue("@c_printManifestPerField", printManifestPerFarm ? "1" : "0");
            cmd.Parameters.AddWithValue("@c_printShowSize", printShowSize ? "1" : "0");
            cmd.Parameters.AddWithValue("@c_printExcelLayout", printExcelLayout ? "1" : "0");

            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string? id = ReadField(dr, "id_template");
                return (true, id);
            }

            return (false, null);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Modificar plantilla de manifiesto");
            return (false, null);
        }
        finally
        {
            sql.CloseConectionWrite();
        }
    }

    public static bool ActiveProcedure(string id, string active)
    {
        SQLControl sql = new();
        try
        {
            sql.OpenConectionWrite();
            SqlCommand cmd = new("sp_PackManifestTemplatesExecute", sql.cnn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@action", "STATUS");
            cmd.Parameters.AddWithValue("@id_template", id);
            cmd.Parameters.AddWithValue("@c_active", active);
            cmd.Parameters.AddWithValue("@user", User.GetUserName());

            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Activar/Desactivar plantilla de manifiesto");
            return false;
        }
        finally
        {
            sql.CloseConectionWrite();
        }
    }
}
