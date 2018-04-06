using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.FireSafetyDepartments
{
	public class FireSafetyDepartment : BaseModel
	{
		public string Language { get; set; }
		public Guid IdCounty { get; set; }
		public Guid IdLanguageContentName { get; set; }

		public County County { get; set; }

		public ICollection<FireSafetyDeparmentServing> FireSafetyDeparmentServing { get; set; }
		public ICollection<Firestation> Firestations { get; set; }
	}
}
