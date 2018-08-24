using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings.Base
{
	public interface IBaseBuildingHazardousMaterial : IBaseModel
	{
		decimal CapacityContainer { get; set; }
		string Container { get; set; }
		string Floor { get; set; }
		string GasInlet { get; set; }
		Guid IdBuilding { get; set; }
		Guid IdHazardousMaterial { get; set; }
		Guid? IdUnitOfMeasure { get; set; }
		HazardousMaterial Material { get; set; }
		string OtherInformation { get; set; }
		string Place { get; set; }
		int Quantity { get; set; }
		string Sector { get; set; }
		string SecurityPerimeter { get; set; }
		string SupplyLine { get; set; }
		StorageTankType TankType { get; set; }
		UnitOfMeasure Unit { get; set; }
		string Wall { get; set; }
	}
}