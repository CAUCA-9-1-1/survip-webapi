using Survi.Prevention.Models.Buildings.Base;

namespace Survi.Prevention.Models.Buildings
{
	public enum StorageTankType
	{
		Unknown,
		Underground,
		Aboveground
	}

	public class BuildingHazardousMaterial : BaseBuildingHazardousMaterial<Building>
	{
	}
}
