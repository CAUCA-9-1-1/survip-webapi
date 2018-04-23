using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.Models.Buildings
{
	public class BuildingCourse : BaseModel
	{
		public Guid IdBuilding { get; set; }
		public Guid IdFirestation { get; set; }

		public Building Building { get; set; }
		public Firestation Firestation { get; set; }

		public ICollection<BuildingCourseLane> Lanes { get; set; }
	}
}
