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
			SeedRiskLevel(builder, 1, Color.Green, "Faible", "Low", "aa91450d-3528-44b3-b589-6fcbba77ad3f", "39e352db-07a5-4d9b-b736-20dd19be1752", "1523aed4-853b-42fe-b57b-7269ea96e01f");
			SeedRiskLevel(builder, 2, Color.Yellow, "Moyen", "Medium", "9da4d106-116f-42dc-b92e-323f90d672cd", "d96503f6-09ba-46be-bfe0-543012cdc676", "4bd93cf9-7ff5-412b-819a-5ef49c103b3c");
			SeedRiskLevel(builder, 3, Color.Orange, "Élevé", "High", "90e4f73a-0c96-4da7-b9e0-4243cd29c2e8", "3d07f034-9b74-48f4-92fc-03da6225719f", "08d04860-f1d1-4e14-a7b8-d464ec2737eb");
			SeedRiskLevel(builder, 4, Color.Red, "Très élevé", "Very high", "7b7f3db7-ca71-4ef4-ac7d-0f89a79a651d", "718a742b-707b-4580-96ab-3b19a272e839", "d6771676-0c5c-47b2-ba86-b3469898ecd5");
			SeedRiskLevel(builder, 0, Color.Black, "Indéterminé", "Unknown", "ee9f0456-d6c3-4763-86ad-bd174a76b629", "7bce3236-009c-4a7c-aea8-fe8fdfb91b96", "fcd6d560-bd16-44d7-9230-b7f205c38bcb");			
		}

		private static void SeedRiskLevel(ModelBuilder builder, int code, Color color, string french, string english, string id, string idFr, string idEn)
		{
			var type = new RiskLevel { Id = Guid.Parse(id), CreatedOn = Now, Code = code, Sequence = code, Color = color.ToArgb().ToString() };
			var frenchLocalization = new RiskLevelLocalization { Id = Guid.Parse(idFr), LanguageCode = "fr", Name = french, IdParent = type.Id, CreatedOn = Now };
			var englishLocalization = new RiskLevelLocalization { Id = Guid.Parse(idEn), LanguageCode = "en", Name = english, IdParent = type.Id, CreatedOn = Now };
			builder.Entity<RiskLevel>().HasData(type);
			builder.Entity<RiskLevelLocalization>().HasData(frenchLocalization, englishLocalization);
		}
	}
}