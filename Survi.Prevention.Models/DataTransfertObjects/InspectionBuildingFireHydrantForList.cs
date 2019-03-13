using System;

namespace Survi.Prevention.Models.DataTransfertObjects
{
	public class InspectionBuildingFireHydrantForList
	{
		public Guid Id { get; set; }
		public Guid IdBuilding { get; set; }
		public Guid IdFireHydrant { get; set; }
		public string Color { get; set; }
		public string Number { get; set; }
		public string Address { get; set; }
	    public bool IsActive { get; set; } = true;
	}
}