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
		    var copy = new TCopy();
		    person.CopyProperties(copy);
		    return copy;
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