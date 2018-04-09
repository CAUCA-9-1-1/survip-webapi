using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings
{
	public class BuildingContact : BaseModel
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

		public Guid IdBuilding { get; set; }

		public Building Building { get; set; }
	}
}
