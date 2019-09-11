using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.Security;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.Models.InspectionManagement
{
	public class Batch: BaseModel
	{
		public DateTime? ShouldStartOn { get; set; }
		public bool IsReadyForInspection { get; set; }
		public string Description { get; set; }

		public Guid IdWebuserCreatedBy { get; set; }

		public User CreatedBy { get; set; }
		public ICollection<BatchUser> Users { get; set; }
		public ICollection<Inspection> Inspections { get; set; }
	}
}