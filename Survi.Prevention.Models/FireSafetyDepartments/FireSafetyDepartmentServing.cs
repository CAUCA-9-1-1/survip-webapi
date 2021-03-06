using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.FireSafetyDepartments
{
	public class FireSafetyDepartmentCityServing : BaseImportedModel
	{
		public Guid IdFireSafetyDepartment { get; set; }
		public Guid IdCity { get; set; }
		
		public FireSafetyDepartment FireSafetyDepartment { get; set; }
		public City City { get; set; }
	}
}
