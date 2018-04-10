using System;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.Models.SecurityManagement
{
	public class WebuserFireSafetyDepartment : BaseModel
	{
		public Guid IdWebuser { get; set; }
		public Guid IdFireSafetyDepartment { get; set; }

		public Webuser User { get; set; }
		public FireSafetyDepartment FireSafetyDepartment { get; set; }
	}
}
