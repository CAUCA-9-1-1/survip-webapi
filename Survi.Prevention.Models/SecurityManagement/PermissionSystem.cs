using System;
using System.Collections.Generic;

namespace Survi.Prevention.Models.SecurityManagement
{
	public class PermissionSystem
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Description { get; set; }

		public ICollection<PermissionSystemFeature> Features { get; set; }
		public ICollection<PermissionObject> Objects { get; set; }
		public ICollection<Permission> Permissions { get; set; }
	}
}
