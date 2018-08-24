using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings.Base
{
	public interface IBaseBuildingPersonRequiringAssistance : IBaseModel
	{
		string ContactName { get; set; }
		string ContactPhoneNumber { get; set; }
		bool DayIsApproximate { get; set; }
		int DayResidentCount { get; set; }
		string Description { get; set; }
		bool EveningIsApproximate { get; set; }
		int EveningResidentCount { get; set; }
		string Floor { get; set; }
		Guid IdBuilding { get; set; }
		Guid IdPersonRequiringAssistanceType { get; set; }
		string Local { get; set; }
		bool NightIsApproximate { get; set; }
		int NightResidentCount { get; set; }
		string PersonName { get; set; }
		PersonRequiringAssistanceType PersonType { get; set; }
	}
}