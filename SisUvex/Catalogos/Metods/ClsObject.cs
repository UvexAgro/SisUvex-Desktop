﻿using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using iText.Commons.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static SisUvex.Catalogos.Metods.ClsObject;

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
            public const string QueryDgvCatalog = $"SELECT wpl.*, w.id_workPlan AS '{ColumnId}', w.c_active AS '{ColumnActive}', w.d_workDay AS '{ColumnDate}', w.id_lot AS '{Lot.ColumnId}' FROM vw_PackWorkPlanCat wpl JOIN Pack_WorkPlan w ON w.id_workPlan = wpl.[Código] ";
            public const string CboPresentation = "CboWorkPlanPresentation";
            public const string QueryCboPresentation = $"SELECT CONCAT_WS(' ',wpl.id_workPlan,'|',lot.v_nameLot,'|',dis.v_nameDistShort,'|',CONCAT(con.v_nameContainer,CAST(gtn.n_lbs AS FLOAT)),gtn.v_preLabel,pre.v_namePresentation,[var].v_nameComercial,gtn.v_postLabel) AS '{Column.name}', wpl.c_active AS '{Column.active}', wpl.id_workPlan AS '{Column.id}', FORMAT(wpl.d_workDay, 'yyyy-MM-dd') AS '{ColumnDate}', wpl.id_workGroup AS '{WorkGroup.ColumnId}', wpl.id_lot AS '{Lot.ColumnId}', lot.v_nameLot AS '{Lot.ColumnName}', gtn.id_variety AS '{Variety.ColumnId}', [var].v_nameComercial AS '{Variety.ColumnName}', [var].v_nameScientis AS '{Variety.ColumnScientis}', [var].v_shortName AS '{Variety.ColumnShortName}', cro.id_crop AS '{Crop.ColumnId}', cro.v_nameCrop AS '{Crop.ColumnName}', wpl.id_size AS '{Size.ColumnId}', siz.v_sizeValue AS '{Size.ColumnName}', gtn.id_distributor AS '{Distributor.ColumnId}', dis.v_nameDistributor AS '{Distributor.ColumnName}', dis.v_address AS '{Distributor.ColumnAddress}', dis.v_city AS '{Distributor.ColumnCity}', dis.v_nameDistShort AS '{Distributor.ColumnShortName}', wpl.id_GTIN AS '{Gtin.ColumnId}', gtn.v_GTIN AS '{Gtin.ColumnName}', gtn.id_container AS '{Container.ColumnId}', gtn.v_UPC AS '{Gtin.ColumnUpc}', gtn.c_PLU AS '{Gtin.ColumnPlu}', con.v_nameContainer AS '{Container.ColumnName}', gtn.n_lbs AS '{Gtin.ColumnLbs}', gtn.v_preLabel AS '{Gtin.ColumnPreLabel}', gtn.id_presentation AS '{Presentation.ColumnId}', pre.v_namePresentation AS '{Presentation.ColumnName}', gtn.v_postLabel AS '{Gtin.ColumnPostLabel}', gtn.i_palletBoxes AS '{Gtin.ColumnPalletBoxes}', gtn.id_pti AS '{Pti.ColumnId}', pti.v_namePti AS '{Pti.ColumnName}', [var].id_color AS '{Color.ColumnId}', col.v_genericName AS '{Color.ColumnGenericName}', col.v_nameColor AS '{Color.ColumnName}', wpl.c_voicePickCode AS '{ColumnVpc}', ctr.id_contractor AS '{Contractor.ColumnId}', ctr.v_nameContractor AS '{Contractor.ColumnName}' FROM Pack_WorkPlan AS wpl LEFT JOIN dbo.Pack_WorkGroup AS wgp ON wgp.id_workGroup = wpl.id_workGroup LEFT JOIN dbo.Pack_Contractor AS ctr ON ctr.id_contractor = wgp.id_contractor LEFT JOIN dbo.Pack_Size AS siz ON siz.id_size = wpl.id_size LEFT JOIN dbo.Pack_GTIN AS gtn ON gtn.id_GTIN = wpl.id_GTIN LEFT JOIN dbo.Pack_Presentation AS pre ON pre.id_presentation = gtn.id_presentation LEFT JOIN dbo.Pack_Container AS con ON con.id_container = gtn.id_container LEFT JOIN dbo.Pack_Variety AS [var] ON [var].id_variety = gtn.id_variety LEFT JOIN dbo.Pack_Distributor AS dis ON dis.id_distributor = gtn.id_distributor LEFT JOIN dbo.Pack_Price AS prc ON prc.id_price = gtn.id_price LEFT JOIN dbo.Pack_PtiType AS pti ON pti.id_pti = gtn.id_pti LEFT JOIN dbo.Pack_Lot AS lot ON lot.id_lot = wpl.id_lot AND lot.id_variety = gtn.id_variety LEFT JOIN dbo.Pack_Crop AS cro ON cro.id_crop = [var].id_crop LEFT JOIN dbo.Pack_Color AS col ON col.id_color = [var].id_color ";
        }
        public static class Grower
        {
            public const string TableName = "Pack_Grower";
            public const string ColumnName = "Productor";
            public const string ColumnId = "idGrower";
            public const string ColumnActive = "ActiveGrower";
            public const string ColumnAddress = "Dirección";
            public const string ColumnCity = "Ciudad";
            public const string Cbo = "CboGrower";
            public const string DgvCatalog = "DgvCatalogGrower";
            public const string QueryCbo = $"SELECT id_grower AS '{Column.id}', CONCAT(v_nameGrower, ' | ', id_grower, ' | (',c_active,')') AS '{Column.name}', c_active AS '{Column.active}' FROM Pack_Grower ORDER BY '{Column.name}'";
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
            public const string QueryDgvForWorkPlan = $"SELECT gtnC.Código, gtnC.Variedad, gtnC.Distribuidor, gtnC.Presentación, gtnC.Libras, gtnC.[Pre etiqueta], gtnC.[Post etiqueta], gtnC.Contenedor, gtnC.[Cajas por pallet], gtnC.PTI, gtnC.GTIN, gtnC.PLU, gtnC.UPC, gtn.c_active AS '{ColumnActive}', gtn.id_GTIN AS '{ColumnId}', gtn.id_variety AS '{Variety.ColumnId}', gtn.id_presentation AS '{Presentation.ColumnId}', gtn.id_container AS '{Container.ColumnId}', id_price AS '{Price.ColumnId}', gtn.id_pti AS '{Pti.ColumnId}', gtn.id_distributor AS '{Distributor.ColumnId}'  from vw_PackGTINCat gtnC JOIN Pack_GTIN gtn ON gtn.id_GTIN = gtnC.Código ";
        }

        public static class Category
        {
            public const string TableName = "Pack_Category";
            public const string ColumnName = "Categoría";
            public const string ColumnId = "idCategory";
            public const string ColumnActive = "ActiveCategory";
            public const string Cbo = "CboCategory";
            public const string DgvCatalog = "DgvCatalogCategory";
            public const string QueryCbo = $"SELECT id_category AS '{Column.id}', CONCAT(v_nameCategory, ' | ', id_category,' |(',c_active,')') AS '{Column.name}', c_active AS '{Column.active}' FROM Pack_Category ORDER BY '{Column.name}'";
            public const string QueryDgvCatalog = "queryCategory";
        }

        public static class Crop
        {
            public const string TableName = "Pack_Crop";
            public const string ColumnName = "Cultivo";
            public const string ColumnId = "idCrop";
            public const string ColumnActive = "ActiveCrop";
            public const string Cbo = "CboCrop";
            public const string DgvCatalog = "DgvCatalogCrop";
            public const string QueryCbo = $"SELECT id_crop AS '{Column.id}', CONCAT(v_nameCrop, ' | ', id_crop) AS '{Column.name}', '1' AS '{Column.active}' FROM Pack_Crop ORDER BY '{Column.name}'";
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
            public const string QueryCbo = $"SELECT id_color AS '{Column.id}', CONCAT(v_nameColor, ' | ', id_color) AS '{Column.name}', '1' AS '{Column.active}' FROM Pack_Color";
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
            public const string QueryCbo = "queryContractor";
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
            public const string QueryCbo = $"SELECT id_variety AS '{Column.id}', CONCAT(v_nameComercial, ' | ', id_variety, ' (',c_active,') ',v_nameScientis) AS '{Column.name}', c_active AS '{Column.active}', id_color AS 'Color.ColumnId', id_crop AS 'Crop.ColumnId' FROM Pack_Variety ORDER BY '{Column.name}'";
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
            public const string QueryCbo = $"SELECT CONCAT(lot.id_lot, '|',lot.id_variety) AS '{Column.id}', lot.id_lot AS '{Lot.ColumnId}', lot.id_variety AS '{Variety.ColumnId}', CONCAT(lot.v_nameLot, ' | ', var.v_nameComercial, ' | ', lot.id_lot, '|', var.id_variety, CASE WHEN var.v_nameScientis IS NOT NULL THEN CONCAT(' | (', var.v_nameScientis, ')') ELSE '' END,' (',lot.c_active,')') AS '{Column.name}', lot.c_active AS '{Column.active}' FROM Pack_Lot lot JOIN Pack_Variety var ON var.id_variety = lot.id_variety ORDER BY '{Column.name}'";
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
            public const string QueryCbo = $"SELECT id_presentation AS '{Column.id}', CONCAT(v_namePresentation, ' | ', id_presentation, ' | (', c_active, ')') AS '{Column.name}', c_active AS '{Column.active}' FROM Pack_Presentation ORDER BY '{Column.name}'";
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
            public const string QueryCbo = $"SELECT id_container AS '{Column.id}', CONCAT(v_nameContainer, ' | ', id_container, ' | (', c_active, ')') AS '{Column.name}', c_active AS '{Column.active}' FROM Pack_Container ORDER BY '{Column.name}'";
            public const string QueryDgvCatalog = "queryContainer";
        }

        public static class Distributor
        {
            public const string TableName = "Pack_Distributor";
            public const string ColumnName = "Distribuidor";
            public const string ColumnShortName = "shortName";
            public const string ColumnId = "idDistributor";
            public const string ColumnActive = "ActiveDistributor";
            public const string ColumnAddress = "Dirección";
            public const string ColumnCity = "Ciudad";
            public const string Cbo = "CboDistributor";
            public const string DgvCatalog = "DgvCatalogDistributor";
            public const string QueryCbo = $"SELECT id_distributor AS '{Column.id}', CONCAT(v_nameDistributor, ' | ', id_distributor, ' | (',c_active,')') AS '{Column.name}', c_active AS '{Column.active}' FROM Pack_Distributor ORDER BY '{Column.name}'";
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
            public const string QueryCbo = $"SELECT id_pti AS '{Column.id}', CONCAT(v_namePti, '| ', id_pti) AS '{Column.name}', '1' AS '{Column.active}' FROM Pack_PtiType";
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
            public const string QueryCbo = $"SELECT id_price AS '{Column.id}', CONCAT(v_descriptionPrice, ' | ', id_price) AS '{Column.name}', '1' AS '{Column.active}' FROM Pack_Price";
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
            public const string QueryCbo = $"SELECT id_size AS '{Column.id}', CONCAT(v_sizeValue,' | ',id_size,' | (',c_active,')') AS '{Column.name}' , c_active AS '{Column.active}' FROM Pack_Size ORDER BY '{Column.name}'";
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
            public const string QueryCbo = $"SELECT id_workGroup AS '{Column.id}', CONCAT(id_workGroup,COALESCE(' ('+con.v_nameContractor+')',NULL)) '{Column.name}', wgp.id_contractor AS '{Contractor.ColumnId}', '1' AS {Column.active} FROM Pack_WorkGroup wgp LEFT JOIN Pack_Contractor con ON con.id_contractor = wgp.id_contractor";
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
            public const string QueryCbo = $"SELECT id_productionLine AS '{Column.id}', CONCAT(v_pLName, ' | ', id_productionLine, ' | (', c_active, ')') AS '{Column.name}', c_active AS '{Column.active}' FROM Nom_ProductionLine ORDER BY '{Column.name}'";
        }
    }
}