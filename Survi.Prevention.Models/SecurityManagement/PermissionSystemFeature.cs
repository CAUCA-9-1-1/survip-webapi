using System;

namespace Survi.Prevention.Models.SecurityManagement
{
	public class PermissionSystemFeature
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string FeatureName { get; set; }
		public string Description { get; set; }
		public bool DefaultValue { get; set; }
		public Guid IdPermissionSystem { get; set; }

		public PermissionSystem System { get; set; }
	}
}
