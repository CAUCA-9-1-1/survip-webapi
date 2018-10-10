using System;
using System.Collections.Generic;

namespace Survi.Prevention.Models.DataTransfertObjects
{
    public class FireSafetyDepartmentInspectionConfigurationForEdition
	{
		public Guid Id { get; set; }

		public Guid IdFireSafetyDepartment { get; set; }

		public bool HasGeneralInformation { get; set; }
		public bool HasImplantationPlan { get; set; }
		public bool HasCourse { get; set; }
		public bool HasWaterSupply { get; set; }
		public bool HasBuildingDetails { get; set; }
		public bool HasBuildingContacts { get; set; }
		public bool HasBuildingPnaps { get; set; }
		public bool HasBuildingFireProtection { get; set; }
		public bool HasBuildingHazardousMaterials { get; set; }
		public bool HasBuildingParticularRisks { get; set; }
		public bool HasBuildingAnomalies { get; set; }

		public Guid? IdSurvey { get; set; }

		public List<string> RiskLevelIds { get; set; }
    }
}
