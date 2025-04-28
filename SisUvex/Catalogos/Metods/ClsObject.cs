
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.Identity.Client;
using System.Diagnostics.Metrics;
using System.Web;

namespace SisUvex.Catalogos.Metods
{
    class ClsObject
    {
        //LOS CAMPOS DE Cbo ES EL NOMBRE CLAVE PARA BUSCAR EN LOS METODOS DE CARGA DE COMBOBOX
        //LO MISMO PARA LOS DgvCatalog

        public static class String
        {
            public const string SelectText = "---Seleccionar---";
        }
        public static class Column
        {
            public const string name = "Nombre";
            public const string id = "Código";
            public const string active = "Activo";
        }
        public static class WorkPlan
        {
            public const string TableName = "Pack_WorkPlan";
            public const string ColumnName = "Plan de trabajo";
            public const string ColumnId = "idWorkPlan";
            public const string ColumnActive = "ActiveWorkPlan";
            public const string ColumnDate = "dateWorkPlan";
            public const string ColumnVpc = "VPC";
            public const string Cbo = "CboWorkPlan";
            public const string DgvCatalog = "DgvCatalogWorkPlan";
            public const string QueryCbo = "queryWorkPlan";
            public const string QueryDgvCatalog = $" SELECT wpl.*, w.id_workPlan AS {ColumnId}], w.c_active AS [{ColumnActive}], w.d_workDay AS [{ColumnDate}], w.id_lot AS [{Lot.ColumnId}] FROM vw_PackWorkPlanCat wpl JOIN Pack_WorkPlan w ON w.id_workPlan = wpl.[Código] ";
            public const string CboPresentation = "CboWorkPlanPresentation";
            public const string QueryCboPresentation = $" SELECT CONCAT_WS(' ',wpl.id_workPlan,'|',lot.v_nameLot,'|',dis.v_nameDistShort,'|',CONCAT(con.v_nameContainer,CAST(gtn.n_lbs AS FLOAT)),siz.v_sizeValue,gtn.v_preLabel,pre.v_namePresentation,[var].v_nameComercial,gtn.v_postLabel) AS [{Column.name}], wpl.c_active AS [{Column.active}], wpl.id_workPlan AS [{Column.id}], FORMAT(wpl.d_workDay, 'yyyy-MM-dd') AS [{ColumnDate}], wpl.id_workGroup AS [{WorkGroup.ColumnId}], wpl.id_lot AS [{Lot.ColumnId}], lot.v_nameLot AS [{Lot.ColumnName}], gtn.id_variety AS [{Variety.ColumnId}], [var].v_nameComercial AS [{Variety.ColumnName}], [var].v_nameScientis AS [{Variety.ColumnScientis}], [var].v_shortName AS [{Variety.ColumnShortName}], cro.id_crop AS [{Crop.ColumnId}], cro.v_nameCrop AS [{Crop.ColumnName}], wpl.id_size AS [{Size.ColumnId}], siz.v_sizeValue AS [{Size.ColumnName}], gtn.id_distributor AS [{Distributor.ColumnId}], dis.v_nameDistributor AS [{Distributor.ColumnName}], dis.v_address AS [{Distributor.ColumnAddress}], dis.v_city AS [{Distributor.ColumnCity}], dis.v_nameDistShort AS [{Distributor.ColumnShortName}], wpl.id_GTIN AS [{Gtin.ColumnId}], gtn.v_GTIN AS [{Gtin.ColumnName}], gtn.id_container AS [{Container.ColumnId}], gtn.v_UPC AS [{Gtin.ColumnUpc}], gtn.c_PLU AS [{Gtin.ColumnPlu}], con.v_nameContainer AS [{Container.ColumnName}], gtn.n_lbs AS [{Gtin.ColumnLbs}], gtn.v_preLabel AS [{Gtin.ColumnPreLabel}], gtn.id_presentation AS [{Presentation.ColumnId}], pre.v_namePresentation AS [{Presentation.ColumnName}], gtn.v_postLabel AS [{Gtin.ColumnPostLabel}], gtn.i_palletBoxes AS [{Gtin.ColumnPalletBoxes}], gtn.id_pti AS [{Pti.ColumnId}], pti.v_namePti AS [{Pti.ColumnName}], [var].id_color AS [{Color.ColumnId}], col.v_genericName AS [{Color.ColumnGenericName}], col.v_nameColor AS [{Color.ColumnName}], wpl.c_voicePickCode AS [{ColumnVpc}], ctr.id_contractor AS [{Contractor.ColumnId}], ctr.v_nameContractor AS [{Contractor.ColumnName}] FROM Pack_WorkPlan AS wpl LEFT JOIN dbo.Pack_WorkGroup AS wgp ON wgp.id_workGroup = wpl.id_workGroup LEFT JOIN dbo.Pack_Contractor AS ctr ON ctr.id_contractor = wgp.id_contractor LEFT JOIN dbo.Pack_Size AS siz ON siz.id_size = wpl.id_size LEFT JOIN dbo.Pack_GTIN AS gtn ON gtn.id_GTIN = wpl.id_GTIN LEFT JOIN dbo.Pack_Presentation AS pre ON pre.id_presentation = gtn.id_presentation LEFT JOIN dbo.Pack_Container AS con ON con.id_container = gtn.id_container LEFT JOIN dbo.Pack_Variety AS [var] ON [var].id_variety = gtn.id_variety LEFT JOIN dbo.Pack_Distributor AS dis ON dis.id_distributor = gtn.id_distributor LEFT JOIN dbo.Pack_Price AS prc ON prc.id_price = gtn.id_price LEFT JOIN dbo.Pack_PtiType AS pti ON pti.id_pti = gtn.id_pti LEFT JOIN dbo.Pack_Lot AS lot ON lot.id_lot = wpl.id_lot AND lot.id_variety = gtn.id_variety LEFT JOIN dbo.Pack_Crop AS cro ON cro.id_crop = [var].id_crop LEFT JOIN dbo.Pack_Color AS col ON col.id_color = [var].id_color ";
        }
        public static class Grower
        {
            public const string TableName = "Pack_Grower";
            public const string ColumnName = "Productor";
            public const string ColumnId = "idGrower";
            public const string ColumnActive = "ActiveGrower";
            public const string ColumnAddress = "Dirección";
            public const string ColumnCity = "Ciudad";
            public const string ColumnRegPat = "RegPat";
            public const string Cbo = "CboGrower";
            public const string DgvCatalog = "DgvCatalogGrower";
            public const string QueryCbo = $" SELECT id_grower AS [{Column.id}], CONCAT(v_nameGrower, ' | ', id_grower, ' | (',c_active,')') AS [{Column.name}], c_active AS [{Column.active}], v_regPat AS [{ColumnRegPat}], v_nameGrower AS [{ColumnName}] FROM Pack_Grower ORDER BY [{Column.name}] ";
            public const string QueryDgvCatalog = "queryGrower";
        }
        public static class Gtin
        {
            public const string TableName = "Pack_GTIN";
            public const string ColumnName = "GTIN";
            public const string ColumnId = "idGtin";
            public const string ColumnActive = "ActivoGtin";
            public const string ColumnLbs = "Libras";
            public const string ColumnPreLabel = "Pre etiqueta";
            public const string ColumnPostLabel = "Post etiqueta";
            public const string ColumnPalletBoxes = "Cajas por pallet";
            public const string ColumnUpc = "UPC";
            public const string ColumnPlu = "PLU";
            public const string Cbo = "CboGtin";
            public const string DgvForWorkPlan = "DgvGtinForWorkPlan";
            public const string DgvCatalog = "DgvCatalogGtin";
            public const string QueryCbo = "queryGtin";
            public const string QueryDgvCatalog = "queryGtin";
            public const string QueryDgvForWorkPlan = $" SELECT gtnC.Código, gtnC.Variedad, gtnC.Distribuidor, gtnC.Presentación, gtnC.Libras, gtnC.[Pre etiqueta], gtnC.[Post etiqueta], gtnC.Contenedor, gtnC.[Cajas por pallet], gtnC.PTI, gtnC.GTIN, gtnC.PLU, gtnC.UPC, gtn.c_active AS [{ColumnActive}], gtn.id_GTIN AS [{ColumnId}], gtn.id_variety AS [{Variety.ColumnId}], gtn.id_presentation AS [{Presentation.ColumnId}], gtn.id_container AS [{Container.ColumnId}], id_price AS [{Price.ColumnId}], gtn.id_pti AS [{Pti.ColumnId}], gtn.id_distributor AS [{Distributor.ColumnId}]  from vw_PackGTINCat gtnC JOIN Pack_GTIN gtn ON gtn.id_GTIN = gtnC.Código ";
        }

        public static class Category
        {
            public const string TableName = "Pack_Category";
            public const string ColumnName = "Categoría";
            public const string ColumnId = "idCategory";
            public const string ColumnActive = "ActiveCategory";
            public const string Cbo = "CboCategory";
            public const string DgvCatalog = "DgvCatalogCategory";
            public const string QueryCbo = $" SELECT id_category AS [{Column.id}], CONCAT(v_nameCategory, ' | ', id_category,' | (',c_active,')') AS [{Column.name}], c_active AS [{Column.active}], v_nameCategory AS [{ColumnName}] FROM Pack_Category ORDER BY [{Column.name}] ";
            public const string QueryDgvCatalog = "queryCategory ";
        }

        public static class Crop
        {
            public const string TableName = "Pack_Crop";
            public const string ColumnName = "Cultivo";
            public const string ColumnId = "idCrop";
            public const string ColumnActive = "ActiveCrop";
            public const string Cbo = "CboCrop";
            public const string DgvCatalog = "DgvCatalogCrop";
            public const string QueryCbo = $" SELECT id_crop AS [{Column.id}], CONCAT(v_nameCrop, ' | ', id_crop) AS [{Column.name}], '1' AS [{Column.active}], v_nameCrop AS [{ColumnName}] FROM Pack_Crop ORDER BY [{Column.name}] ";
            public const string QueryDgvCatalog = "queryCrop";
        }

        public static class Color
        {
            public const string TableName = "Pack_Color";
            public const string ColumnName = "Color";
            public const string ColumnId = "idColor";
            public const string ColumnActive = "ActiveColor";
            public const string ColumnGenericName = "genericNameColor";
            public const string Cbo = "CboColor";
            public const string DgvCatalog = "DgvCatalogColor";
            public const string QueryCbo = $" SELECT id_color AS [{Column.id}], CONCAT(v_nameColor, ' | ', id_color) AS [{Column.name}], '1' AS [{Column.active}], v_nameColor AS [{ColumnName}] FROM Pack_Color ";
            public const string QueryDgvCatalog = "queryColor";
        }

        public static class Contractor
        {
            public const string TableName = "Pack_Contractor";
            public const string ColumnName = "Contratista";
            public const string ColumnId = "idContractor";
            public const string ColumnActive = "ActiveContractor";
            public const string Cbo = "CboContractor";
            public const string DgvCatalog = "DgvCatalogContractor";
            public const string QueryCbo = $" SELECT id_contractor AS [{Column.id}], CONCAT(v_nameContractor, ' | ', id_contractor, ' | (', c_active, ')') AS [{Column.name}], c_active AS [{Column.active}], v_nameContractor AS [{ColumnName}] FROM Pack_Contractor ORDER BY [{Column.name}] ";
            public const string QueryDgvCatalog = "queryContractor";
        }

        public static class Variety
        {
            public const string TableName = "Pack_Variety";
            public const string ColumnName = "Variedad";
            public const string ColumnScientis = "Variedad científica";
            public const string ColumnShortName = "shortVariety";
            public const string ColumnId = "idVariety";
            public const string ColumnActive = "ActiveVariety";
            public const string Cbo = "CboVariety";
            public const string DgvCatalog = "DgvCatalogVariety";
            public const string QueryCbo = $" SELECT id_variety AS [{Column.id}], CONCAT(v_nameComercial, ' | ', id_variety, ' (',c_active,') ',v_nameScientis) AS [{Column.name}], c_active AS [{Column.active}], id_color AS 'Color.ColumnId', id_crop AS 'Crop.ColumnId', v_nameComercial AS [{ColumnName}], v_nameScientis AS [{ColumnScientis}] FROM Pack_Variety ORDER BY [{Column.name}]  ";
            public const string QueryDgvCatalog = "queryVariety";
        }

        public static class Lot
        {
            public const string TableName = "Pack_Lot";
            public const string ColumnName = "Lote";
            public const string ColumnId = "idLot";
            public const string ColumnActive = "ActiveLot";
            public const string Cbo = "CboLot";
            public const string DgvCatalog = "DgvCatalogLot";
            public const string QueryCbo = $" SELECT CONCAT(lot.id_lot, '|',lot.id_variety) AS [{Column.id}], lot.id_lot AS [{Lot.ColumnId}], lot.id_variety AS [{Variety.ColumnId}], CONCAT(lot.v_nameLot, ' | ', var.v_nameComercial, ' | ', lot.id_lot, '|', var.id_variety, CASE WHEN var.v_nameScientis IS NOT NULL THEN CONCAT(' | (', var.v_nameScientis, ')') ELSE '' END,' (',lot.c_active,')') AS [{Column.name}], lot.c_active AS [{Column.active}], v_nameLot AS [{ColumnName}] FROM Pack_Lot lot JOIN Pack_Variety var ON var.id_variety = lot.id_variety ORDER BY [{Column.name}] ";
            public const string QueryDgvCatalog = "queryLot";
        }

        public static class Presentation
        {
            public const string TableName = "Pack_Presentation";
            public const string ColumnName = "Presentación";
            public const string ColumnId = "idPresentation";
            public const string ColumnActive = "ActivePresentation";
            public const string Cbo = "CboPresentation";
            public const string DgvCatalog = "DgvCatalogPresentation";
            public const string QueryCbo = $" SELECT id_presentation AS [{Column.id}], CONCAT(v_namePresentation, ' | ', id_presentation, ' | (', c_active, ')') AS [{Column.name}], c_active AS [{Column.active}], v_namePresentation AS [{ColumnName}] FROM Pack_Presentation ORDER BY [{Column.name}] ";
            public const string QueryDgvCatalog = "queryPresentation";
        }

        public static class Container
        {
            public const string TableName = "Pack_Container";
            public const string ColumnName = "Contenedor";
            public const string ColumnId = "idContainer";
            public const string ColumnActive = "ActiveContainer";
            public const string Cbo = "CboContainer";
            public const string DgvCatalog = "DgvCatalogContainer";
            public const string QueryCbo = $" SELECT id_container AS [{Column.id}], CONCAT(v_nameContainer, ' | ', id_container, ' | (', c_active, ')') AS [{Column.name}], c_active AS [{Column.active}], v_nameContainer AS [{ColumnName}] FROM Pack_Container ORDER BY [{Column.name}] ";
            public const string QueryDgvCatalog = "queryContainer";
        }

        public static class Distributor
        {
            public const string TableName = "Pack_Distributor";
            public const string ColumnName = "Distribuidor";
            public const string ColumnShortName = "shortNameDistributor";
            public const string ColumnId = "idDistributor";
            public const string ColumnActive = "ActiveDistributor";
            public const string ColumnAddress = "Dirección";
            public const string ColumnCity = "Ciudad";
            public const string Cbo = "CboDistributor";
            public const string DgvCatalog = "DgvCatalogDistributor";
            public const string QueryCbo = $"  SELECT id_distributor AS [{Column.id}], CONCAT(v_nameDistributor, ' | ', id_distributor, ' | (',c_active,')') AS [{Column.name}], c_active AS [{Column.active}], v_nameDistributor AS [{ColumnName}], v_nameDistShort AS [{ColumnShortName}] FROM Pack_Distributor ORDER BY [{Column.name}] ";
            public const string QueryDgvCatalog = "queryDistributor";
        }

        public static class Pti
        {
            public const string TableName = "Pack_PtiType";
            public const string ColumnName = "Pti";
            public const string ColumnId = "idPti";
            public const string ColumnActive = "ActivePti";
            public const string Cbo = "CboPti";
            public const string DgvCatalog = "DgvCatalogPti";
            public const string QueryCbo = $"SELECT id_pti AS [{Column.id}], CONCAT(v_namePti, ' | ', id_pti) AS [{Column.name}], '1' AS [{Column.active}], v_namePti AS [{ColumnName}] FROM Pack_PtiType";
            public const string QueryDgvCatalog = "queryPti";
        }

        public static class Price
        {
            public const string TableName = "Pack_Price";
            public const string ColumnName = "Precio";
            public const string ColumnId = "idPrice";
            public const string ColumnActive = "ActivePrice";
            public const string Cbo = "CboPrice";
            public const string DgvCatalog = "DgvCatalogPrice";
            public const string QueryCbo = $" SELECT id_price AS [{Column.id}], CONCAT(v_descriptionPrice, ' | ', id_price) AS [{Column.name}], '1' AS [{Column.active}], v_descriptionPrice AS [{ColumnName}] FROM Pack_Price ";
            public const string QueryDgvCatalog = "queryPrice";
        }
        public static class Size
        {
            public const string TableName = "Pack_Size";
            public const string ColumnName = "Tamaño";
            public const string ColumnId = "idSize";
            public const string ColumnActive = "ActiveSize";
            public const string Cbo = "CboSize";
            public const string DgvCatalog = "DgvCatalogSize";
            public const string QueryCbo = $" SELECT id_size AS [{Column.id}], CONCAT(v_sizeValue,' | ',id_size,' | (',c_active,')') AS [{Column.name}] , c_active AS [{Column.active}] ,  v_sizeValue AS [{ColumnName}] FROM Pack_Size ORDER BY [{Column.name}] ";
            public const string QueryDgvCatalog = "querySize";
        }

        public static class WorkGroup
        {
            public const string TableName = "Pack_WorkGroup";
            public const string ColumnName = "Cuadrilla";
            public const string ColumnId = "idWorkGroup";
            public const string ColumnActive = "ActiveWorkGroup";
            public const string Cbo = "CboWorkGroup";
            public const string DgvCatalog = "DgvCatalogWorkGroup";
            public const string QueryCbo = $" SELECT id_workGroup AS [{Column.id}], CONCAT(id_workGroup,COALESCE(' ('+con.v_nameContractor+')',NULL)) [{Column.name}], wgp.id_contractor AS [{Contractor.ColumnId}], '1' AS [{Column.active}] , wgp.v_nameWorkGroup AS [{ColumnName}] FROM Pack_WorkGroup wgp LEFT JOIN Pack_Contractor con ON con.id_contractor = wgp.id_contractor ";
            public const string QueryDgvCatalog = "queryWorkGroup";
        }

        public static class ProductionLine
        {
            public const string TableName = "Nom_ProductionLine";
            public const string ColumnName = "Banda";
            public const string ColumnId = "idProductionLine";
            public const string ColumnActive = "ActiveProductionLine";
            public const string Cbo = "CboProductionLine";
            public const string DgvCatalog = "DgvCatalogProductionLine";
            public const string QueryCbo = $" SELECT id_productionLine AS [{Column.id}], CONCAT(v_pLName, ' | ', id_productionLine, ' | (', c_active, ')') AS [{Column.name}], c_active AS [{Column.active}], v_pLName AS [{ColumnName}] FROM Nom_ProductionLine ORDER BY [{Column.name}] ";
        }

        public static class PlacePayment
        {
            public const string TableName = "Nom_PlacePayment";
            public const string ColumnName = "Lugar de pago";
            public const string ColumnId = "idPlacePayment";
            public const string ColumnActive = "ActivePlacePayment";
            public const string Cbo = "CboPlacePayment";
            public const string DgvCatalog = "DgvCatalogPlacePayment";
            public const string QueryCbo = $" SELECT id_placePayment AS [{Column.id}], CONCAT(id_placePayment, ' | ', v_namePlace,  ' | (', c_activePlace, ')')  AS [{Column.name}], c_activePlace AS [{Column.active}], v_namePlace AS [{ColumnName}] FROM Nom_PlacePayment ORDER BY [{Column.id}] ";
        }

        public static class DiningHall
        {
            public const string TableName = "Nom_DiningHall";
            public const string ColumnName = "Ventanilla";
            public const string ColumnId = "idDiningHall";
            public const string ColumnActive = "ActiveDiningHall";
            public const string ColumnDinerProvider = "idDinerProvider";
            public const string Cbo = "CboDiningHall";
            public const string DgvCatalog = "DgvCatalogDiningHall";
            public const string QueryCbo = $" SELECT dhl.id_dinningHall AS [{Column.id}], CONCAT(dhl.v_nameDiningHall, ' | ', dhl.id_dinningHall, ' | ', dpr.v_nameDinerProvider, ' | (', dhl.c_active, ')') AS [{Column.name}], dhl.c_active AS [{Column.active}], dhl.id_dinerProvider AS [{ColumnDinerProvider}], v_nameDiningHall AS [{ColumnName}] FROM Nom_DiningHall dhl LEFT JOIN Nom_DinerProvider dpr ON dpr.id_dinerProvider = dhl.id_dinerProvider ORDER BY [{Column.name}] ";
        }

        public static class DinerProvider
        {
            public const string TableName = "Nom_DinerProvider";
            public const string ColumnName = "Proveedor";
            public const string ColumnId = "id_dinerProvider";
            public const string ColumnActive = "ActiveDinerProvider";
            public const string Cbo = "CboDinerProvider";
            public const string DgvCatalog = "DgvCatalogDinerProvider";
            public const string QueryCbo = $" SELECT id_dinerProvider AS [{Column.id}], CONCAT(v_nameDinerProvider, ' | ', id_dinerProvider, ' | (', c_active, ')') AS [{Column.name}], c_active AS [{Column.active}], v_nameDinerProvider AS [{ColumnName}] FROM Nom_DinerProvider ORDER BY [{Column.name}] ";
        }

        public static class Season
        {
            public const string TableName = "Pack_Season";
            public const string ColumnName = "Temporada";
            public const string ColumnId = "id_Season";
            public const string ColumnActive = "ActiveSeason";
            public const string Cbo = "CboSeason";
            public const string DgvCatalog = "DgvCatalogSeason";
            public const string QueryCbo = $" SELECT id_season AS [{Column.id}], CONCAT(v_nameSeason, ' | ', id_season, ' | (', c_active, ')') AS [{Column.name}], c_active AS [{Column.active}], v_nameSeason AS [{ColumnName}] FROM Pack_Season ORDER BY [{Column.name}] ";
        }

        public static class City
        {
            public const string TableName = "Pack_City";
            public const string ColumnName = "Ciudad";
            public const string ColumnId = "idCity";
            public const string ColumnActive = "ActiveCity";
            public const string Cbo = "CboCity";
            public const string DgvCatalog = "DgvCatalogCity";
            public const string QueryCbo = $" SELECT id_city AS [{Column.id}], CONCAT_WS(', ',v_nameCity, v_state, v_country) + CONCAT(' | ', id_city, ' | (', c_active, ')') AS [{Column.name}], c_active AS [{Column.active}],  CONCAT_WS(', ',v_nameCity, v_state, v_country) AS [{ColumnName}] FROM Pack_City ORDER BY [{Column.name}] ";
            //AUN NO SE USA LA COLUMNA DE NAME A: 2025-ABRIL-10
            public const string ColumnNameCrossPoint = "Ciudad de cruce";
            public const string ColumnIdCrossPoint = "idCityCrossPoint";
            public const string ColumnNameDestiny = "Ciudad de destino";
            public const string ColumnIdDestiny = "idCityDestiny";
        }

        public static class Consignee
        {
            public const string TableName = "Pack_Consignee";
            public const string ColumnName = "Consignatario";
            public const string ColumnId = "idConsignee";
            public const string ColumnActive = "ActiveConsignee";
            public const string Cbo = "CboConsignee";
            public const string DgvCatalog = "DgvCatalogConsignee";
            public const string QueryCbo = $" SELECT id_consignee AS [{Column.id}], CONCAT(v_nameConsignee, ' | ', id_consignee, ' | (', c_active, ')') AS [{Column.name}], c_active AS [{Column.active}], v_nameConsignee AS [{ColumnName}], id_distributor AS [{Distributor.ColumnId}] FROM Pack_Consignee ORDER BY [{Column.name}] ";
        }

        public static class AgencyTradeUS
        {
            public const string TableName = "Pack_AgencyTrade";
            public const string ColumnName = "Agencia extrangera";
            public const string ColumnId = "idAgencyTradeUS";
            public const string ColumnActive = "ActiveAgencyTradeUS";
            public const string ColumnCountry = "País";
            public const string Cbo = "CboAgencyTradeUS";
            public const string DgvCatalog = "DgvCatalogAgencyTradeUS";
            public const string QueryCbo = $" SELECT id_agencyTrade AS [{Column.id}], CONCAT(v_nameAgency, ' | ', id_agencyTrade, ' | (', c_active, ')') AS [{Column.name}], c_active AS [{Column.active}], v_nameAgency AS [{ColumnName}], c_country AS [{ColumnCountry}] FROM Pack_AgencyTrade WHERE c_country = 'US' ORDER BY [{Column.name}";
        }

        public static class AgencyTradeMX
        {
            public const string TableName = "Pack_AgencyTrade";
            public const string ColumnName = "Agencia nacional";
            public const string ColumnId = "idAgencyTradeMX";
            public const string ColumnActive = "ActiveAgencyTradeMX";
            public const string ColumnCountry = "País";
            public const string Cbo = "CboAgencyTradeMX";
            public const string DgvCatalog = "DgvCatalogAgencyTradeMX";
            public const string QueryCbo = $" SELECT id_agencyTrade AS [{Column.id}], CONCAT(v_nameAgency, ' | ', id_agencyTrade, ' | (', c_active, ')') AS [{Column.name}], c_active AS [{Column.active}], v_nameAgency AS [{ColumnName}], c_country AS [{ColumnCountry}] FROM Pack_AgencyTrade WHERE c_country = 'MX' ORDER BY [{Column.name}] ";
        }

        public static class TransportLine
        {
            public const string TableName = "Pack_TransportLine";
            public const string ColumnName = "Linea de transporte";
            public const string ColumnId = "idTransportLine";
            public const string ColumnActive = "ActiveTransportLine";
            public const string Cbo = "CboTransportLine";
            public const string DgvCatalog = "DgvCatalogTransportLine";
            public const string QueryCbo = $" SELECT id_transportLine AS [{Column.id}], CONCAT(v_nameTransportLine, ' | ', id_transportLine, ' | (', c_active, ')') AS [{Column.name}], c_active AS [{Column.active}], v_nameTransportLine AS [{ColumnName}] FROM Pack_TransportLine ORDER BY [{Column.name}] ";
        }

        public static class Driver
        {
            public const string TableName = "Pack_Driver";
            public const string ColumnName = "Chofer";
            public const string ColumnId = "idDriver";
            public const string ColumnActive = "ActiveDriver";
            public const string Cbo = "CboDriver";
            public const string DgvCatalog = "DgvCatalogDriver";
            public const string QueryCbo = $" SELECT id_driver AS [{Column.id}], CONCAT(v_lastNameDriver, ' ',v_nameDriver, ' | ', id_driver, ' | (', c_active, ')') AS [{Column.name}], c_active AS [{Column.active}], id_transportLine AS [{TransportLine.ColumnId}] FROM Pack_Driver ORDER BY [{Column.name}] ";
        }

        public static class Truck
        {
            public const string TableName = "Pack_Truck";
            public const string ColumnName = "Troque";
            public const string ColumnId = "idTruck";
            public const string ColumnActive = "ActiveTruck";
            public const string Cbo = "CboTruck";
            public const string DgvCatalog = "DgvCatalogTruck";
            public const string QueryCbo = $" SELECT id_truck AS [{Column.id}], CONCAT_WS(' | ', v_ecoNumber, v_plateUS, v_plateMX, '(' + id_truck + ')', '(' + c_active + ')' ) AS [{Column.name}], c_active AS [{Column.active}], id_transportLine AS [{TransportLine.ColumnId}] FROM Pack_Truck ";
        }

        public static class FreightContainer
        {
            public const string TableName = "Pack_FreightContainer";
            public const string ColumnName = "Caja";
            public const string ColumnId = "idFreightContainer";
            public const string ColumnActive = "ActiveFreightContainer";
            public const string Cbo = "CboFreightContainer";
            public const string DgvCatalog = "DgvCatalogFreightContainer";
            public const string QueryCbo = $" SELECT id_freightContainer AS [{Column.id}], CONCAT_WS(' | ', v_ecoNumber, v_plateUS, v_plateMX, '(' + id_freightContainer + ')', '(' + c_active + ')' ) AS [{Column.name}], c_active AS [{Column.active}], id_transportLine AS [{TransportLine.ColumnId}]  FROM Pack_FreightContainer ORDER BY [{Column.name}] ";
        }

        public static class ManifestTemplate
        {
            public const string TableName = "Pack_ManifestTemplates";
            public const string ColumnName = "Plantilla de manifiesto";
            public const string ColumnId = "idManifestTemplate";
            public const string Cbo = "CboManifestTemplate";
            public const string DgvCatalog = "DgvCatalogManifestTemplate";
            public const string QueryCbo = $" SELECT id_template AS [{Column.id}], v_nameTemplate AS [{Column.name}], id_distributor AS [{Distributor.ColumnId}], id_grower AS [{Grower.ColumnId}], id_USAgencyTrade AS [{AgencyTradeUS.ColumnId}], id_MXAgencyTrade AS [{AgencyTradeMX.ColumnId}], id_cityCrossPoint AS [{City.ColumnIdCrossPoint}], id_cityDestiny AS [{City.ColumnIdDestiny}], id_consignee AS [{Consignee.ColumnId}], '1' AS [{ClsObject.Column.active}] FROM Pack_ManifestTemplates ";
        }

        public static class Unit
        {
            public const string TableName = "Pack_Unit";
            public const string ColumnName = "Unidad";
            public const string ColumnId = "idUnit";
            public const string ColumnActive = "ActiveUnit";
            public const string Cbo = "CboUnit";
            public const string DgvCatalog = "DgvCatalogUnit";
            public const string QueryCbo = $" SELECT id_unit AS [{Column.id}], CONCAT(v_nameUnit, ' | ', id_unit) AS [{Column.name}], v_nameUnit AS [{ColumnName}] FROM Pack_Unit ORDER BY [{Column.name}] ";
        }

        public static class MaterialType //AGREGARLA AL LISTADO DONDE ESTAN LOS CLSCOMBOBOXES
        {
            public const string TableName = "Pack_MaterialType";
            public const string ColumnName = "Tipo de material";
            public const string ColumnId = "idMaterialType";
            public const string ColumnActive = "ActiveMaterialType";
            public const string Cbo = "CboMaterialType";
            public const string DgvCatalog = "DgvCatalogMaterialType";
            public const string QueryCbo = $" SELECT [id_matType] AS [{Column.id}], CONCAT([v_nameMatType], ' | ', [id_matType]) AS [{Column.name}], v_nameMatType AS [{ColumnName}] FROM [Pack_MaterialType] ORDER BY [{Column.name}] ";
        }

        public static class MaterialProvider
        {
            public const string TableName = "Pack_Provider";
            public const string ColumnName = "Proveedor";
            public const string ColumnId = "idMaterialProvider";
            public const string ColumnActive = "ActiveMaterialProvider";
            public const string Cbo = "CboMaterialProvider";
            public const string DgvCatalog = "DgvCatalogMaterialProvider";
            public const string QueryCbo = $" SELECT id_provider AS [{Column.id}], CONCAT(v_nameProvider, ' | ', id_provider, ' | (', c_active, ')') AS [{Column.name}], c_active AS [{Column.active}], v_nameProvider AS [{ColumnName}] FROM [Pack_Provider] ORDER BY [{Column.name}] ";
        }

        public static class MaterialWarehouse
        {
            public const string TableName = "Pack_Warehouses";
            public const string ColumnName = "Almacén";
            public const string ColumnId = "idMatWarehouse";
            public const string ColumnActive = "ActiveMatWarehouse";
            public const string Cbo = "CboMatWarehouse";
            public const string DgvCatalog = "DgvCatalogMatWarehouse";
            public const string QueryCbo = $" SELECT id_warehouses AS [{Column.id}], CONCAT(v_namewarehouses, ' | ', id_warehouses, ' | (', c_active, ')') AS [{Column.name}], c_active AS [{Column.active}] ,v_namewarehouses AS [{ColumnName}] FROM Pack_Warehouses ORDER BY [{Column.name}] ";
        }
    }
}
