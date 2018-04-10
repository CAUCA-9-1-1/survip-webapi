using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings
{
	public class BuildingHazardousMaterial : BaseModel
	{
		public int Quantity { get; set; }
		public string Container { get; set; }
		public string CapacityContainer { get; set; }
		public string Place { get; set; }
		public string Floor { get; set; }
		public string GasInlet { get; set; }
		public string SecurityPerimeter { get; set; }
		public string OtherInformation { get; set; }

		public Guid IdBuilding { get; set; }
		public Guid IdHazardousMaterial { get; set; }
		public Guid IdUnitOfMeasure { get; set; }

		public Building Building { get; set; }
		public HazardousMaterial Material { get; set; }
		public UnitOfMeasure Unit { get; set; }
	}
}
