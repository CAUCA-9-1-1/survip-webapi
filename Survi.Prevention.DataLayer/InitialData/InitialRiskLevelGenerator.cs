using System;
using System.Drawing;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.InitialData
{
	internal class InitialRiskLevelGenerator
	{
		private static readonly DateTime Now = new DateTime(2018, 6, 1);

		internal static void SeedInitialData(ModelBuilder builder)
		{
			SeedRiskLevel(builder, 1, Color.Green, "Faible", "Low");
			SeedRiskLevel(builder, 2, Color.Yellow, "Moyen", "Medium");
			SeedRiskLevel(builder, 3, Color.Orange, "Élevé", "High");
			SeedRiskLevel(builder, 4, Color.Red, "Très élevé", "Very high");
			SeedRiskLevel(builder, 0, Color.Black, "Indéterminé", "Unknown");			
		}

		private static void SeedRiskLevel(ModelBuilder builder, int code, Color color, string french, string english)
		{
			var type = new RiskLevel { Id = GuidExtensions.GetGuid(), CreatedOn = Now, Code = code, Sequence = code, Color = color.ToArgb().ToString() };
			var frenchLocalization = new RiskLevelLocalization { Id = GuidExtensions.GetGuid(), LanguageCode = "fr", Name = french, IdParent = type.Id, CreatedOn = Now };
			var englishLocalization = new RiskLevelLocalization { Id = GuidExtensions.GetGuid(), LanguageCode = "en", Name = english, IdParent = type.Id, CreatedOn = Now };
			builder.Entity<RiskLevel>().HasData(type);
			builder.Entity<RiskLevelLocalization>().HasData(frenchLocalization, englishLocalization);
		}
	}
}