using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.FireSafetyDepartments
{
	public class County : BaseModel
	{
		public Guid IdLanguageContentName { get; set; }
		public Guid IdRegion { get; set; }
		public Guid IdState { get; set; }

		public Region Region { get; set; }
		public State State { get; set; }

		public ICollection<County> Counties { get; set; }
	}
}
