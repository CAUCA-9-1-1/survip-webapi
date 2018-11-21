using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings
{
	public class RiskLevel : BaseLocalizableImportedModel<RiskLevelLocalization>
	{
		public int Sequence { get; set; }
		public int Code { get; set; }
		public string Color { get; set; }
	}
}
