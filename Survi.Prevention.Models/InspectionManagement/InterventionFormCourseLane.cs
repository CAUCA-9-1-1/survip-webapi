using System;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.Models.InspectionManagement
{
	public class InterventionFormCourseLane : BaseModel
	{
		public Guid IdLane { get; set; }
		public Guid IdInterventionFormCourse { get; set; }
		public CourseLaneDirection Direction { get; set; }
		public int Sequence { get; set;}
		public Lane Lane { get; set; }
		public InterventionFormCourse Course { get; set; }
	}
}