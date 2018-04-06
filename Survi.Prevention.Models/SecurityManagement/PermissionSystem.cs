using System;

namespace Survi.Prevention.Models.SecurityManagement
{
	public class PermissionSystem
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Description { get; set; }
	}
}
