using Survi.Prevention.Models.Buildings.Base;

namespace Survi.Prevention.Models.Buildings
{
	public class BuildingParticularRiskPicture : BaseBuildingParticularRiskPicture<Picture>
	{
		public BuildingParticularRisk Risk { get; set; }		
	}
}