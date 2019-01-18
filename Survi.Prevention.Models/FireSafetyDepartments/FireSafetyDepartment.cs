using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.FireSafetyDepartments
{
	public class FireSafetyDepartment : BaseLocalizableImportedModel<FireSafetyDepartmentLocalization>
	{
		public string Language { get; set; }
		public Guid IdCounty { get; set; }
        public Guid? IdPicture { get; set; }

        public County County { get; set; }
        public Picture Picture { get; set; }

        public ICollection<FireSafetyDepartmentCityServing> FireSafetyDepartmentServing { get; set; }
		public ICollection<Firestation> Firestations { get; set; }
	}
}
