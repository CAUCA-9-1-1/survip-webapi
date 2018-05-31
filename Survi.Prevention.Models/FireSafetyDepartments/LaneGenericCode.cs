using System;

namespace Survi.Prevention.Models.FireSafetyDepartments
{
	public class LaneGenericCode
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Code { get; set; }
		public string Description { get; set; }
		public bool AddWhiteSpaceAfter { get; set; }
		public bool IsActive { get; set; } = true;
	}
}
