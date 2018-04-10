using System;

namespace Survi.Prevention.Models.SecurityManagement
{
	public class Permission
	{
		public Guid Id { get; set; } = Guid.NewGuid();

		public string Comments { get; set; }
		public bool Access { get; set; }
		public DateTime CreatedOn { get; set; } = DateTime.Now;

		public Guid IdPermissionObject { get; set; }
		public Guid IdPermissionSystem { get; set; }
		public Guid IdPermissionSystemFeature { get; set; }

		public PermissionObject PermissionObject { get; set; }
		public PermissionSystem System { get; set; }
		public PermissionSystemFeature Feature { get; set; }
	}
}
