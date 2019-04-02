using System.Collections.Generic;
using Survi.Prevention.Models.Buildings.Base;

namespace Survi.Prevention.ServiceLayer.DataCopy
{
	public class ContactDuplicator
	{
		public TCopy Duplicate<TOriginal, TCopy>(TOriginal contact)
			where TOriginal : IBaseBuildingContact, new()
			where TCopy : IBaseBuildingContact, new()
		{
		    var copy = new TCopy();
		    contact.CopyProperties(copy);
		    return copy;
		}

		public IEnumerable<TCopy> Duplicate<TOriginal, TCopy>(ICollection<TOriginal> contacts)
			where TOriginal : IBaseBuildingContact, new()
			where TCopy : IBaseBuildingContact, new()
		{
			foreach (var contact in contacts)
				yield return Duplicate<TOriginal, TCopy>(contact);
		}
	}
}