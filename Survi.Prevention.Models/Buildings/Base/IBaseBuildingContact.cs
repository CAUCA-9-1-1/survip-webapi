using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings.Base
{
	public interface IBaseBuildingContact : IBaseModel
	{
		int CallPriority { get; set; }
		string CellphoneNumber { get; set; }
		string FirstName { get; set; }
		Guid IdBuilding { get; set; }
		bool IsOwner { get; set; }
		string LastName { get; set; }
		string OtherNumber { get; set; }
		string OtherNumberExtension { get; set; }
		string PagerCode { get; set; }
		string PagerNumber { get; set; }
		string PhoneNumber { get; set; }
		string PhoneNumberExtension { get; set; }
	}
}