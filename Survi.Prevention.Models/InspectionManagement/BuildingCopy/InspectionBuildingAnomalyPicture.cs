using Survi.Prevention.Models.Buildings.Base;

namespace Survi.Prevention.Models.InspectionManagement.BuildingCopy
{
	public class InspectionBuildingAnomalyPicture : BaseBuildingAnomalyPicture<InspectionPicture>
	{
		public InspectionBuildingAnomaly Anomaly { get; set; }
	}
}