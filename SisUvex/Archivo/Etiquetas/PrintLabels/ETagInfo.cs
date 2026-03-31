using Microsoft.Win32.SafeHandles;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Values;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Archivo.Etiquetas.PrintLabels
{
    internal class ETagInfo
    {
        public bool? showDate { get; set; } //DETERMINA SI EN LA ETIQUETA SE VA A MOSTRAR LA FECHA O NO (DE MOMENTO SOLO AL IMPRIMIR EL PTI)
        public string? nameProduct { get; set; }
        public string? active { get; set; }
        public string? idWorkPlan { get; set; }
        public DateTime? dateWorkPlan { get; set; }
        public string? idWorkGroup { get; set; }
        public string? idLot { get; set; }
        public string? nameLot { get; set; }
        public string? idVariety { get; set; }
        public string? nameVariety { get; set; }
        public string? scientisVarierty { get; set; }
        public string? shortNameVariety { get; set; }
        public string? idCrop { get; set; }
        public string? nameCrop { get; set; }
        public string? idSize { get; set; }
        public string? nameSize { get; set; }
        public string? idDistributor { get; set; }
        public string? nameDistributor { get; set; }
        public string? addressDistributor { get; set; }
        public string? cityDistributor { get; set; }
        public string? shortNameDistributor { get; set; }
        public string? idGTIN { get; set; }
        public string? valueGTIN { get; set; }
        public string? upcGTIN { get; set; }
        public string? PLU { get; set; }
        public string? idContainer { get; set; }
        public string? nameContainer { get; set; }
        public string? Lbs { get; set; }
        public string? preLabel { get; set; }
        public string? idPresentation { get; set; }
        public string? namePresentation { get; set; }
        public string? postLabel { get; set; }
        public string? palletBoxes { get; set; }
        public string? idPti { get; set; }
        public string? namePti { get; set; }
        public string? idColor { get; set; }
        public string? nameColor { get; set; }
        public string? nameGenericColor { get; set; }
        public string? nameColorCanEn { get; set; }
        public string? nameColorCanFr { get; set; }
        public string? voicePickCode { get; set; }
        public string? idContractor { get; set; }
        public string? nameContractor { get; set; }
        public string? growFarmName { get; set; } // Added for grow farm name
        public string? idTypeBox { get; set; }
        public string? nameTypeBox { get; set; }
        public string? shortNameTypeBox { get; set; } // Added for short name type box

        public void ClearFields()
        {
            nameProduct = null;
            active = null;
            idWorkPlan = null;
            dateWorkPlan = null;
            idWorkGroup = null;
            idLot = null;
            nameLot = null;
            idVariety = null;
            nameVariety = null;
            scientisVarierty = null;
            shortNameVariety = null;
            idCrop = null;
            nameCrop = null;
            idSize = null;
            nameSize = null;
            idDistributor = null;
            nameDistributor = null;
            addressDistributor = null;
            cityDistributor = null;
            shortNameDistributor = null;
            idGTIN = null;
            valueGTIN = null;
            upcGTIN = null;
            PLU = null;
            idContainer = null;
            nameContainer = null;
            Lbs = null;
            preLabel = null;
            idPresentation = null;
            namePresentation = null;
            postLabel = null;
            palletBoxes = null;
            idPti = null;
            namePti = null;
            idColor = null;
            nameColor = null;
            nameColorCanEn = null;
            nameColorCanFr = null;
            nameGenericColor = null;
            voicePickCode = null;
            idContractor = null;
            nameContractor = null;
            growFarmName = null; // Clear grow farm name
            idTypeBox = null;
            nameTypeBox = null;
            shortNameTypeBox = null;
        }

        public void SetTagInfo(string idWorkPlan)
        {
            DataTable dtWorkPlan = ClsComboBoxFiles.GetCboCatalogDataTable(ClsObject.WorkPlan.CboPresentation);
            DataRow[] rows = dtWorkPlan.Select($"{Column.id} = '{idWorkPlan}'");

            if (rows.Length > 0)
            {
                if (DateTime.TryParse(rows[0][ClsObject.WorkPlan.ColumnDate].ToString(), out DateTime dateWorkPlan))
                    this.dateWorkPlan = dateWorkPlan;
                else
                    this.dateWorkPlan = null;

                this.nameProduct = rows[0][Column.name].ToString();
                this.active = rows[0][Column.active].ToString();
                this.idWorkPlan = rows[0][Column.id].ToString();
                this.idWorkGroup = rows[0][WorkGroup.ColumnId].ToString();
                this.idLot = rows[0][Lot.ColumnId].ToString();
                this.nameLot = rows[0][Lot.ColumnName].ToString();
                this.idVariety = rows[0][Variety.ColumnId].ToString();
                this.nameVariety = rows[0][Variety.ColumnName].ToString();
                this.scientisVarierty = rows[0][Variety.ColumnScientis].ToString();
                this.idCrop = rows[0][Crop.ColumnId].ToString();
                this.nameCrop = rows[0][Crop.ColumnName].ToString();
                this.idSize = rows[0][ClsObject.Size.ColumnId].ToString();
                this.nameSize = rows[0][ClsObject.Size.ColumnName].ToString();
                this.idDistributor = rows[0][Distributor.ColumnId].ToString();
                this.nameDistributor = rows[0][Distributor.ColumnName].ToString();
                this.addressDistributor = rows[0][Distributor.ColumnAddress].ToString();
                this.cityDistributor = rows[0][Distributor.ColumnCity].ToString();
                this.shortNameDistributor = rows[0][Distributor.ColumnShortName].ToString();
                this.idGTIN = rows[0][Gtin.ColumnId].ToString();
                this.valueGTIN = rows[0][Gtin.ColumnName].ToString();
                this.upcGTIN = rows[0][Gtin.ColumnUpc].ToString();
                this.PLU = rows[0][Gtin.ColumnPlu].ToString();
                this.idContainer = rows[0][ClsObject.Container.ColumnId].ToString();
                this.nameContainer = rows[0][ClsObject.Container.ColumnName].ToString();
                this.Lbs = ClsValues.RemoveTrailingZeros(rows[0][Gtin.ColumnLbs].ToString()); //Ej: de 10.00 a 10
                this.preLabel = rows[0][Gtin.ColumnPreLabel].ToString();
                this.idPresentation = rows[0][Presentation.ColumnId].ToString();
                this.namePresentation = rows[0][Presentation.ColumnName].ToString();
                this.postLabel = rows[0][Gtin.ColumnPostLabel].ToString();
                this.palletBoxes = rows[0][Gtin.ColumnPalletBoxes].ToString();
                this.idPti = rows[0][Pti.ColumnId].ToString();
                this.namePti = rows[0][Pti.ColumnName].ToString();
                this.idColor = rows[0][ClsObject.Color.ColumnId].ToString();
                this.nameColor = rows[0][ClsObject.Color.ColumnName].ToString();
                this.voicePickCode = rows[0][ClsObject.WorkPlan.ColumnVpc].ToString();
                this.idContractor = rows[0][Contractor.ColumnId].ToString();
                this.nameContractor = rows[0][Contractor.ColumnName].ToString();
                this.growFarmName = rows[0][Farm.ColumnName].ToString(); // Added for grow farm name
            }
        }
    }
}
