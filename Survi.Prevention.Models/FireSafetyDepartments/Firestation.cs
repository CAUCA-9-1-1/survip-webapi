using System;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.Models.FireSafetyDepartments
{
	public class Firestation : BaseModel
	{
		public string Name { get; set; }
		public string PhoneNumber { get; set; }
		public string FaxNumber { get; set; }
		public string Email { get; set; }

		public Guid? IdBuilding { get; set; }
		public Guid IdFireSafetyDepartment { get; set; }

		public Building Building { get; set; }
		public FireSafetyDepartment FireSafetyDepartment { get; set; }
	}
}