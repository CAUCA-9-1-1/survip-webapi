using System;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.Models.FireSafetyDepartments
{
	public class FireSafetyDepartmentInspectionConfigurationRiskLevel : BaseModel
	{
		public Guid IdFireSafetyDepartmentInspectionConfiguration { get; set; }
		public Guid IdRiskLevel { get; set; }

		public RiskLevel RiskLevel { get; set; }
		public FireSafetyDepartmentInspectionConfiguration Configuration { get; set; }
	}
}