using System.Collections.Generic;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.Models.DataTransfertObjects
{
	public class InspectionBuildingCourseWithLanes
	{
		public BuildingCourse Course { get; set; }
		public ICollection<InspectionBuildingCourseLaneForList> Lanes { get; set; }
	}
}