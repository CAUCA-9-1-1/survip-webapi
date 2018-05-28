using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.SurveyManagement;

namespace Survi.Prevention.Models.FireSafetyDepartments
{
	public class FireSafetyDepartmentRiskLevel : BaseModel
	{
        public Guid IdFireSafetyDepartment { get; set; }

        public Boolean HasGeneralInformation { get; set; }
        public Boolean HasImplantationPlan { get; set; }
        public Boolean HasCourse { get; set; }
		public Boolean HasWaterSupply { get; set; }
        public Boolean HasBuildingDetails { get; set; }
        public Boolean HasBuildingContacts { get; set; }
        public Boolean HasBuildingPNAPS { get; set; }
        public Boolean HasBuildingFireProtection { get; set; }
        public Boolean HasBuildingHazardousMaterials { get; set; }
        public Boolean HasBuildingParticularRisks { get; set; }
        public Boolean HasBuildingAnomalies { get; set; }

        public Guid IdRiskLevel { get; set; }
        public Guid? IdSurvey { get; set; }

        public RiskLevel RiskLevel { get; set; }
		public Survey Survey { get; set; }
	}
}
