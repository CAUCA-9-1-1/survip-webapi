using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.Models.InspectionManagement
{
	public class InterventionFormCourse : BaseModel
	{
		public Guid IdInterventionPlan { get; set; }
		public Guid IdFirestation { get; set; }

		public InterventionForm Form { get; set; }
		public Firestation Firestation { get; set; }

		public ICollection<InterventionFormCourseLane> Lanes { get; set; }
	}

	public enum CourseLaneDirection
	{
		Left,
		Right
	}

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
