using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.Models.InspectionManagement
{
	public class InterventionForm : BaseModel
	{
		public string Name { get; set; }
		public string Number { get; set; }
		public string OtherInformation { get; set; }
		public DateTime RevisedOn { get; set; }
		public DateTime ApprovedOn { get; set; }
		public Guid? IdLaneTransversal { get; set; }
		public Guid? IdPictureSitePlan { get; set; }

		public Picture Picture { get; set; }
		public Lane Transversal { get; set; }

		public ICollection<InterventionFormBuilding> Buildings { get; set; }
		public ICollection<InterventionFormCourse> Courses { get; set; }
		public ICollection<InterventionFormFireHydrant> FireHydrants { get; set; }
	}
}
