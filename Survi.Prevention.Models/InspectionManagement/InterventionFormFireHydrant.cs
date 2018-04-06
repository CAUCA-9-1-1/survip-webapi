using System;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.FireHydrants;

namespace Survi.Prevention.Models.InspectionManagement
{
	public class InterventionFormFireHydrant : BaseModel
	{
		public DateTime DeletedOn { get; set; }

		public Guid IdInterventionForm { get; set; }
		public Guid IdFireHydrant { get; set; }

		public InterventionForm Form { get; set; }
		public FireHydrant Hydrant { get; set; }
	}
}
