using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings.Base
{
	public abstract class BaseBuildingHazardousMaterial<T> : BaseImportedModel, IBaseBuildingHazardousMaterial where T : IBaseBuilding
    {
		public int Quantity { get; set; }
		public string Container { get; set; }
		public decimal CapacityContainer { get; set; }
		public string Place { get; set; }
		public string Wall { get; set; }
		public string Sector { get; set; }
		public string Floor { get; set; }
		public string GasInlet { get; set; }
		public string SecurityPerimeter { get; set; }
		public string OtherInformation { get; set; }
		public StorageTankType TankType { get; set; }
		public string SupplyLine { get; set; }

		public Guid IdBuilding { get; set; }
		public Guid IdHazardousMaterial { get; set; }
		public Guid? IdUnitOfMeasure { get; set; }

		public T Building { get; set; }
		public HazardousMaterial Material { get; set; }
		public UnitOfMeasure Unit { get; set; }

	}
}