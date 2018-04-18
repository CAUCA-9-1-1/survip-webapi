using System;

namespace Survi.Prevention.Models.DataTransfertObjects
{
	public class InterventionFormBuildingForList
	{
		public Guid Id { get; set; }
		public Guid IdBuilding { get; set; }
		public Guid IdInterventionForm { get; set; }
		public string Name { get; set; }
		public string Picture { get; set; }
	}
}