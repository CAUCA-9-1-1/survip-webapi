using System;
using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.DataTransferObjects
{
    public class BuildingDetail : BaseTransferObjectWithPicture
    {
        public string AdditionalInformation { get; set; } = "";
        public decimal Height { get; set; }
        public int EstimatedWaterFlow { get; set; }
        public GarageType GarageType { get; set; } = GarageType.No;
        public DateTime? RevisedOn { get; set; }
        public DateTime? ApprovedOn { get; set; }

        public string IdBuilding { get; set; }
        public string IdUnitOfMeasureHeight { get; set; }
        public string IdUnitOfMeasureEstimatedWaterFlow { get; set; }
        public string IdConstructionType { get; set; }
        public string IdConstructionFireResistanceType { get; set; }

        public string IdRoofType { get; set; }
        public string IdRoofMaterialType { get; set; }
        public string IdBuildingType { get; set; }
        public string IdBuildingSidingType { get; set; }
    }
}