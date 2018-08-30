using Survi.Prevention.Models.Buildings.Base;

namespace Survi.Prevention.Models.Buildings
{
	public class BuildingAnomalyPicture : BaseBuildingAnomalyPicture<Picture>
	{
		public BuildingAnomaly Anomaly { get; set; }
	}
}