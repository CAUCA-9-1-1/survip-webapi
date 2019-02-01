using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings.Base
{
	public abstract class BaseBuildingContact<T> : BaseImportedModel, IBaseBuildingContact 
		where T : IBaseBuilding
    {
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int CallPriority { get; set; }
		public string PhoneNumber { get; set; }
		public string PhoneNumberExtension { get; set; }
		public string PagerNumber { get; set; }
		public string PagerCode { get; set; }
		public string CellphoneNumber { get; set; }
		public string OtherNumber { get; set; }
		public string OtherNumberExtension { get; set; }
		public bool IsOwner { get; set; }

		public Guid IdBuilding { get; set; }

		public T Building { get; set; }
	}
}