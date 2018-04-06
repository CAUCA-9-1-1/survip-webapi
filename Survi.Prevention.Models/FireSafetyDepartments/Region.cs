using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.FireSafetyDepartments
{
	public class Region : BaseModel
	{
		public string Code { get; set; }
		public Guid IdLanguageContentName { get; set; }
		public Guid IdState { get; set; }

		public State State { get; set; }

		public ICollection<County> Counties { get; set; }
	}
}
