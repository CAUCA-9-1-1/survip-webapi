using System;

namespace Survi.Prevention.Models.FireSafetyDepartments
{
	public class LanePublicCode
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Code { get; set; }
		public string Description { get; set; }
		public string Abbreviation { get; set; }
		public bool IsActive { get; set; }
	}
}
