using System.Collections.Generic;
using Survi.Prevention.Models.Buildings.Base;

namespace Survi.Prevention.ServiceLayer.DataCopy
{
	public class PersonRequiringAssistanceDuplicator
	{
		public TCopy Duplicate<TOriginal, TCopy>(TOriginal person)
			where TOriginal : IBaseBuildingPersonRequiringAssistance, new()
			where TCopy : IBaseBuildingPersonRequiringAssistance, new()
		{
			return new TCopy
			{
				ContactName = person.ContactName,
				ContactPhoneNumber = person.ContactPhoneNumber,
				CreatedOn = person.CreatedOn,
				DayIsApproximate = person.DayIsApproximate,
				DayResidentCount = person.DayResidentCount,
				Description = person.Description,
				EveningIsApproximate = person.EveningIsApproximate,
				EveningResidentCount = person.EveningResidentCount,
				Floor = person.Floor,
				Id = person.Id,
				IdBuilding = person.IdBuilding,
				IdPersonRequiringAssistanceType = person.IdPersonRequiringAssistanceType,
				IsActive = person.IsActive,
				Local = person.Local,
				NightIsApproximate = person.NightIsApproximate,
				NightResidentCount = person.NightResidentCount,
				PersonName = person.PersonName,
			};
		}

		public IEnumerable<TCopy> Duplicate<TOriginal, TCopy>(ICollection<TOriginal> persons)
			where TOriginal : IBaseBuildingPersonRequiringAssistance, new()
			where TCopy : IBaseBuildingPersonRequiringAssistance, new()
		{
			foreach (var person in persons)
				yield return Duplicate<TOriginal, TCopy>(person);
		}
	}
}