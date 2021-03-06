using System;
using Survi.Prevention.Models.Security;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.Models.InspectionManagement
{
	public class BatchUser
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid IdWebuser { get; set; }
		public Guid IdBatch { get; set; }

		public Batch Batch { get; set; }
		public User User { get; set; }
	}
}