using System;

namespace Survi.Prevention.Models.SecurityManagement
{
	public class PermissionObject
	{
		public Guid Id { get; set; } = Guid.NewGuid();

		public string ObjectTable { get; set; }
		public string GenericId { get; set; }
		public bool IsGroup { get; set; }
		public string GroupName { get; set; }

		public Guid IdPermissionSystem { get; set; }
		public Guid? IdPermissionObjectParent { get; set; }

		public PermissionSystem System { get; set; }
		public PermissionObject Parent { get; set; }
	}
}