using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings
{
	public class RiskLevel : BaseImportedModel
	{
		public int Sequence { get; set; }
		public int Code { get; set; }
		public string Color { get; set; }

		public ICollection<RiskLevelLocalization> Localizations { get; set; }
	}
}
