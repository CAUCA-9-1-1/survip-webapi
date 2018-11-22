using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.FireSafetyDepartments
{
	public class LaneGenericCode: BaseImportedModel
	{
		public string Code { get; set; }
		public string Description { get; set; }
		public bool AddWhiteSpaceAfter { get; set; }
	}
}
