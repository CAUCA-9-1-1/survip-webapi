using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.FireSafetyDepartments
{
	public class Lane : BaseLocalizableImportedModel<LaneLocalization>
	{
		public Guid? IdPublicCode { get; set; }
		public Guid? IdLaneGenericCode { get; set; }
		public Guid IdCity { get; set; }

		public City City { get; set; }
		public LaneGenericCode LaneGenericCode { get; set; }
		public LanePublicCode PublicCode { get; set; }
	}
}
