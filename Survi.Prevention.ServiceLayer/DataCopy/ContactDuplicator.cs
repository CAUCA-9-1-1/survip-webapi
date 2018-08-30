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
			return new TCopy
			{
				Id = contact.Id,
				CallPriority = contact.CallPriority,
				CellphoneNumber = contact.CellphoneNumber,
				CreatedOn = contact.CreatedOn,
				IdBuilding = contact.IdBuilding,
				IsActive = contact.IsActive,
				FirstName = contact.FirstName,
				IsOwner = contact.IsOwner,
				LastName = contact.LastName,
				OtherNumber = contact.OtherNumber,
				OtherNumberExtension = contact.OtherNumberExtension,
				PagerCode = contact.PagerCode,
				PagerNumber = contact.PagerNumber,
				PhoneNumber = contact.PhoneNumber,
				PhoneNumberExtension = contact.PhoneNumberExtension
			};
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