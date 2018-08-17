using System;

namespace Survi.Prevention.Models.DataTransfertObjects
{
    public class InspectionConfiguration
    {
		public Boolean HasGeneralInformation { get; set; } = true;
		public Boolean HasImplantationPlan { get; set; } = true;
	    public Boolean HasCourse { get; set; }
	    public Boolean HasWaterSupply { get; set; }
		public Boolean HasBuildingDetails { get; set; } = true;
	    public Boolean HasBuildingContacts { get; set; }
	    public Boolean HasBuildingPnaps { get; set; }
	    public Boolean HasBuildingFireProtection { get; set; }
	    public Boolean HasBuildingHazardousMaterials { get; set; }
	    public Boolean HasBuildingParticularRisks { get; set; }
	    public Boolean HasBuildingAnomalies { get; set; }
	}
}
