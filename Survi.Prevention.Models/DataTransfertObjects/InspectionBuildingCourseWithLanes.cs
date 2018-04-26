using System.Collections.Generic;

namespace Survi.Prevention.Models.DataTransfertObjects
{
	public class InspectionBuildingCourseWithLanes
	{
		public InspectionBuildingCourseForWeb Course { get; set; }
		public ICollection<InspectionBuildingCourseLaneForList> Lanes { get; set; }
	}
}