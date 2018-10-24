using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings
{
	public class UtilisationCode : BaseImportedModel
	{
		public string Cubf { get; set; }
		public string Scian { get; set; }
		public ICollection<UtilisationCodeLocalization> Localizations { get; set; }
	}
}