using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.Models.Buildings.Base
{
	public interface IBaseBuildingCourse<TCourseLane> : IBaseModel
	{
		Firestation Firestation { get; set; }
		Guid IdBuilding { get; set; }
		Guid IdFirestation { get; set; }
		ICollection<TCourseLane> Lanes { get; set; }
	}
}