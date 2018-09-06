using System;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.SurveyManagement;

namespace Survi.Prevention.Models.FireSafetyDepartments
{
	public class FireSafetyDepartmentRiskLevel : BaseModel
	{
        public Guid IdFireSafetyDepartment { get; set; }

        public bool HasGeneralInformation { get; set; }
        public bool HasImplantationPlan { get; set; }
        public bool HasCourse { get; set; }
		public bool HasWaterSupply { get; set; }
        public bool HasBuildingDetails { get; set; }
        public bool HasBuildingContacts { get; set; }
        public bool HasBuildingPNAPS { get; set; }
        public bool HasBuildingFireProtection { get; set; }
        public bool HasBuildingHazardousMaterials { get; set; }
        public bool HasBuildingParticularRisks { get; set; }
        public bool HasBuildingAnomalies { get; set; }

        public Guid IdRiskLevel { get; set; }
        public Guid? IdSurvey { get; set; }

        public RiskLevel RiskLevel { get; set; }
		public Survey Survey { get; set; }
	}
}
