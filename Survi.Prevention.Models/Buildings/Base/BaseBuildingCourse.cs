using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.Models.Buildings.Base
{
	public abstract class BaseBuildingCourse<TCourseLane> : BaseImportedModel, IBaseBuildingCourse<TCourseLane>
	{
		public Guid IdBuilding { get; set; }
		public Guid IdFirestation { get; set; }
		
		public Firestation Firestation { get; set; }

	    public virtual ICollection<TCourseLane> Lanes { get; set; } = new List<TCourseLane>();
	}
}