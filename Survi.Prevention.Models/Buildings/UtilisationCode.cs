using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings
{
	public class UtilisationCode : BaseLocalizableImportedModel<UtilisationCodeLocalization>
	{
		public string Cubf { get; set; }
		public string Scian { get; set; }
		public int Year { get; set; }
	}
}