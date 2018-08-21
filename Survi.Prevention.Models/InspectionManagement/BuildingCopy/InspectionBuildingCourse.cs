using Survi.Prevention.Models.Buildings.Base;

namespace Survi.Prevention.Models.InspectionManagement.BuildingCopy
{
	public class InspectionBuildingCourse : BaseBuildingCourse<InspectionBuildingCourseLane>
	{
		public InspectionBuilding Building { get; set; }
	}
}