using Survi.Prevention.Models.Buildings.Base;

namespace Survi.Prevention.Models.InspectionManagement.BuildingCopy
{
	public class InspectionBuildingParticularRiskPicture : BaseBuildingParticularRiskPicture<InspectionPicture>
	{
		public InspectionBuildingParticularRisk Risk { get; set; }
	}
}