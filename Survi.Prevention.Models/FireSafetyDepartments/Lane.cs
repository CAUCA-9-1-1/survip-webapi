using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.FireSafetyDepartments
{
	public class Lane : BaseImportedModel
	{
		public bool IsValid { get; set; }

		public Guid? IdPublicCode { get; set; }
		public Guid? IdLaneGenericCode { get; set; }
		public Guid IdCity { get; set; }

		public City City { get; set; }
		public LaneGenericCode LaneGenericCode { get; set; }
		public LanePublicCode PublicCode { get; set; }
		public ICollection<LaneLocalization> Localizations { get; set; }
	}
}
