using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Archivo.Etiquetas.PrintLabels
{
    internal class ETagInfo
    {
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
        }
    }
}
