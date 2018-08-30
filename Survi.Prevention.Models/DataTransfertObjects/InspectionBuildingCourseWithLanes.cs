using System.Collections.Generic;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.Models.DataTransfertObjects
{
	public class InspectionBuildingCourseWithLanes
	{
		public BuildingCourse Course { get; set; }
		public ICollection<BuildingCourseLaneForList> Lanes { get; set; }
	}
}