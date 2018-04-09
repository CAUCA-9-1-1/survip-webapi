using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.FireSafetyDepartments
{
	public class Lane : BaseModel
	{
		public bool IsValid { get; set; }

		public Guid? IdPublicCode { get; set; }
		public Guid? IdLaneGenericCode { get; set; }
		public Guid IdLanguageContentName { get; set; }
		public Guid IdCity { get; set; }

		public City City { get; set; }
		public LaneGenericCode LaneGenericCode { get; set; }
		public LanePublicCode PublicCode { get; set; }
	}
}
