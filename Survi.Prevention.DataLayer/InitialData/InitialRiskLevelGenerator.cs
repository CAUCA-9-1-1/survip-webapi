using System.Collections.Generic;
using System.Drawing;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.InitialData
{
	internal class InitialRiskLevelGenerator
	{
		internal static IEnumerable<RiskLevel> GetInitialData()
		{
			yield return new RiskLevel
			{
				Code = 1,
				Color = Color.Green.ToArgb().ToString(),
				Sequence = 1,
				Localizations = new List<RiskLevelLocalization> {new RiskLevelLocalization {LanguageCode = "fr", Name = "Faible"}, new RiskLevelLocalization {LanguageCode = "en", Name = "Low"}}
			};

			yield return new RiskLevel
			{
				Code = 2,
				Color = Color.Yellow.ToArgb().ToString(),
				Sequence = 2,
				Localizations = new List<RiskLevelLocalization> { new RiskLevelLocalization { LanguageCode = "fr", Name = "Moyen" }, new RiskLevelLocalization { LanguageCode = "en", Name = "Low" } }
			};

			yield return new RiskLevel
			{
				Code = 3,
				Color = Color.Orange.ToArgb().ToString(),
				Sequence = 3,
				Localizations = new List<RiskLevelLocalization> { new RiskLevelLocalization { LanguageCode = "fr", Name = "Élevé" }, new RiskLevelLocalization { LanguageCode = "en", Name = "High" } }
			};
			yield return new RiskLevel
			{
				Code = 4,
				Color = Color.Red.ToArgb().ToString(),
				Sequence = 4,
				Localizations = new List<RiskLevelLocalization> { new RiskLevelLocalization { LanguageCode = "fr", Name = "Très élevé" }, new RiskLevelLocalization { LanguageCode = "en", Name = "Very high" } }
			};
			yield return new RiskLevel
			{
				Code = 0,
				Color = Color.Black.ToArgb().ToString(),
				Sequence = 0,
				Localizations = new List<RiskLevelLocalization> { new RiskLevelLocalization { LanguageCode = "fr", Name = "Indéterminé" }, new RiskLevelLocalization { LanguageCode = "en", Name = "Unknown" } }
			};
		}
	}
}