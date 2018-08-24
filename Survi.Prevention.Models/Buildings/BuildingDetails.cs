using Survi.Prevention.Models.Buildings.Base;

namespace Survi.Prevention.Models.Buildings
{
	public enum GarageType
	{
		No,
		Yes,
		Detached
	}

	public class BuildingDetail : BaseBuildingDetail<Building, Picture>
	{
	}
}
