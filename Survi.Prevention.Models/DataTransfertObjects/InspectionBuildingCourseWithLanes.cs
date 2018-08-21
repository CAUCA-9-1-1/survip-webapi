using System.Collections.Generic;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.Models.DataTransfertObjects
{
	public class InspectionBuildingCourseWithLanes
	{
		public InspectionBuildingCourse Course { get; set; }
		public ICollection<InspectionBuildingCourseLaneForList> Lanes { get; set; }
	}
}