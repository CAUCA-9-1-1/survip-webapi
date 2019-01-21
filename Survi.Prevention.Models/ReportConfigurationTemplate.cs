using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models
{
	public class ReportConfigurationTemplate : BaseModel
	{
		public string Data { get; set; }
		public string Name { get; set; } = "";
		public bool IsDefault { get; set; } = false;
		public Guid IdFireSafetyDepartment{ get; set; }
	}
}
