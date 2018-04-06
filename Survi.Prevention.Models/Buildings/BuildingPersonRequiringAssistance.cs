using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings
{
	public class BuildingPersonRequiringAssistance : BaseModel
	{
		public int DayResidentCount { get; set; }
		public int EveningResidentCount { get; set; }
		public int NightResidentCount { get; set; }
		public bool DayIsApproximate { get; set; }
		public bool EveningIsApproximate { get; set; }
		public bool NightIsApproximate { get; set; }
		public string Description { get; set; }
		public string PraName { get; set; }
		public string Floor { get; set; }
		public string Local { get; set; }
		public string ContactName { get; set; }
		public string ContactPhoneNumber { get; set; }

		public Guid IdBuilding { get; set; }
		public Guid IdPersonRequiringAssistanceType { get; set; }

		public Building Building { get; set; }
		public Building PersonType { get; set; }
	}
}
