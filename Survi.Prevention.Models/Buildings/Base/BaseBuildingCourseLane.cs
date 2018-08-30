using System;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.Models.Buildings.Base
{
	public abstract class BaseBuildingCourseLane : BaseModel 
	{
		public Guid IdLane { get; set; }
		public Guid IdBuildingCourse { get; set; }
		public CourseLaneDirection Direction { get; set; }
		public int Sequence { get; set; }
		public Lane Lane { get; set; }		
	}
}