using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.SecurityManagement
{
	public class PermissionSystemFeature : BaseModel
	{
		public string FeatureName { get; set; }
		public string Description { get; set; }
		public bool DefaultValue { get; set; }
		public Guid IdPermissionSystem { get; set; }

		public PermissionSystem System { get; set; }
	}
}
