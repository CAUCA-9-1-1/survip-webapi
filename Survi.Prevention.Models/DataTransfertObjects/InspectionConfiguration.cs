using System;

namespace Survi.Prevention.Models.DataTransfertObjects
{
    public class InspectionConfiguration
    {
		public bool HasGeneralInformation { get; set; } = true;
		public bool HasImplantationPlan { get; set; } = true;
	    public bool HasCourse { get; set; }
	    public bool HasWaterSupply { get; set; }
		public bool HasBuildingDetails { get; set; } = true;
	    public bool HasBuildingContacts { get; set; }
	    public bool HasBuildingPnaps { get; set; }
	    public bool HasBuildingFireProtection { get; set; }
	    public bool HasBuildingHazardousMaterials { get; set; }
	    public bool HasBuildingParticularRisks { get; set; }
	    public bool HasBuildingAnomalies { get; set; }
		public bool HasSurvey { get; set; }
        public decimal MaxUploadSize { get; set; } = 5.0m;
    }
}
