using System;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.Models.InspectionManagement
{
	public class BatchUser
	{
		public string Description { get; set; }

		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid IdWebuser { get; set; }
		public Guid IdInspectionBatch { get; set; }

		public Batch Batch { get; set; }
		public Webuser User { get; set; }
	}
}