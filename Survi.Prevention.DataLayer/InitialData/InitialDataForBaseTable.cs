using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.Models;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.FireHydrants;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.InitialData
{
	public static class InitialDataForBaseTable
	{
		private static readonly DateTime Now = new DateTime(2018, 06, 01);
		private static readonly Guid IdUser = GuidExtensions.GetGuid();

		public static void SeedInitialData(this ModelBuilder builder)
		{
			SeedInitialConstructionType(builder);
			SeedInitialFireResistanceType(builder);
			SeedInitialBuildingType(builder);
			SeedInitialRoofType(builder);
			SeedInitialRoofMaterialType(builder);
			SeedInitialSidingType(builder);

			SeedInitialSprinklerType(builder);
			SeedInitialAlarmPanelType(builder);
			SeedInitialPersonRequiringAssistanceType(builder);
			SeedInitialFireHydrantConnectionType(builder);
			SeedInitialFireHydrantType(builder);
			SeedInitialOperatorTypes(builder);
			SeedInitialDataForMeasuringUnit(builder);
			builder.Entity<LaneGenericCode>().HasData(InitialLaneGenericCodesGenerator.GetInitialData().ToArray());
			builder.Entity<LanePublicCode>().HasData(InitialLanePublicCodesGenerator.GetInitialData().ToArray());

			InitialUserGenerator.SeedInitialData(builder, IdUser);
			InitialPermissionGenerator.SeedInitialData(builder, IdUser);
			InitialRiskLevelGenerator.SeedInitialData(builder);	
		}

		public static void SeedInitialDataForDevelopment(this ModelBuilder builder)
		{
			InitialDataForCauca.SeedInitialGeographicData(builder);
			InitialDataForCauca.SeedInitialCityTypes(builder);
		}

		private static void SeedInitialFireResistanceType(ModelBuilder builder)
		{
			SeedFireResistanceType(builder, "Ordinaire", "Regular");
			SeedFireResistanceType(builder, "Combustible", "Flammable");
			SeedFireResistanceType(builder, "Incombustible", "Nonflammable");
			SeedFireResistanceType(builder, "Résistante au feu", "Fire resistant");
			SeedFireResistanceType(builder, "Hybride", "Hybrid");
		}

		private static void SeedFireResistanceType(ModelBuilder builder, string french, string english)
		{
			var type = new ConstructionFireResistanceType {Id = GuidExtensions.GetGuid(), CreatedOn = Now};
			var frenchLocalization = new ConstructionFireResistanceTypeLocalization {Id = GuidExtensions.GetGuid(), LanguageCode = "fr", Name = french, IdParent = type.Id, CreatedOn = Now};
			var englishLocalization = new ConstructionFireResistanceTypeLocalization {Id = GuidExtensions.GetGuid(), LanguageCode = "en", Name = english, IdParent = type.Id, CreatedOn = Now};
			builder.Entity<ConstructionFireResistanceType>().HasData(type);
			builder.Entity<ConstructionFireResistanceTypeLocalization>().HasData(frenchLocalization, englishLocalization);
		}

		private static void SeedInitialConstructionType(ModelBuilder builder)
		{
			SeedConstructionType(builder, "Ossature de bois avec solives préfabriquées", "Wood frame and prefabricated joists");
			SeedConstructionType(builder, "Gros bois d'oeuvre", "Lumber");
			SeedConstructionType(builder, "Mur porteur en maçonnerie avec mur solives en bois solides", "Masonry bearing wall and solid wood joists");
			SeedConstructionType(builder, "Mur porteur en maçonnerie et solives préfabriquées", "Masonry bearing wall and prefabricated joists");
			SeedConstructionType(builder, "Mur porteur en maçonnerie et solives en aciers ou dalle de béton", "Masonry bearing wall and steel joists or concrete slab");
			SeedConstructionType(builder, "Acier avec solives en acier protégées", "Steel with protected steel joists");
			SeedConstructionType(builder, "Acier avec solives en acier non protégées", "Steel with unprotected steel joists");
			SeedConstructionType(builder, "Béton", "Concrete");
			SeedConstructionType(builder, "Autre type", "Other");
			SeedConstructionType(builder, "Indéterminé", "Undetermined");
		}

		private static void SeedConstructionType(ModelBuilder builder, string french, string english)
		{
			var type = new ConstructionType { Id = GuidExtensions.GetGuid(), CreatedOn = Now };
			var frenchLocalization = new ConstructionTypeLocalization { Id = GuidExtensions.GetGuid(), LanguageCode = "fr", Name = french, IdParent = type.Id, CreatedOn = Now };
			var englishLocalization = new ConstructionTypeLocalization { Id = GuidExtensions.GetGuid(), LanguageCode = "en", Name = english, IdParent = type.Id, CreatedOn = Now };
			builder.Entity<ConstructionType>().HasData(type);
			builder.Entity<ConstructionTypeLocalization>().HasData(frenchLocalization, englishLocalization);
		}

		private static void SeedInitialBuildingType(ModelBuilder builder)
		{
			SeedBuildingType(builder, "Attaché", "Attached");
			SeedBuildingType(builder, "Détaché", "Detached");
			SeedBuildingType(builder, "Jumelé", "Semi-detached");
			SeedBuildingType(builder, "Autre", "Other");
		}

		private static void SeedBuildingType(ModelBuilder builder, string french, string english)
		{
			var type = new BuildingType { Id = GuidExtensions.GetGuid(), CreatedOn = Now };
			var frenchLocalization = new BuildingTypeLocalization { Id = GuidExtensions.GetGuid(), LanguageCode = "fr", Name = french, IdParent = type.Id, CreatedOn = Now };
			var englishLocalization = new BuildingTypeLocalization { Id = GuidExtensions.GetGuid(), LanguageCode = "en", Name = english, IdParent = type.Id, CreatedOn = Now };
			builder.Entity<BuildingType>().HasData(type);
			builder.Entity<BuildingTypeLocalization>().HasData(frenchLocalization, englishLocalization);
		}

		private static void SeedInitialRoofType(ModelBuilder builder)
		{
			SeedRoofType(builder, "1 versant", "1 slope");
			SeedRoofType(builder, "2 versants", "2 slopes");
			SeedRoofType(builder, "4 versants", "3 slopes");
			SeedRoofType(builder, "Cône français", "French cone");
			SeedRoofType(builder, "Diamant", "Diamond");
			SeedRoofType(builder, "Dôme", "Dome");
			SeedRoofType(builder, "Mansarde", "Mansard");
			SeedRoofType(builder, "Pente", "Slope");
			SeedRoofType(builder, "Plat", "Flat");
		}

		private static void SeedRoofType(ModelBuilder builder, string french, string english)
		{
			var type = new RoofType { Id = GuidExtensions.GetGuid(), CreatedOn = Now };
			var frenchLocalization = new RoofTypeLocalization { Id = GuidExtensions.GetGuid(), LanguageCode = "fr", Name = french, IdParent = type.Id, CreatedOn = Now };
			var englishLocalization = new RoofTypeLocalization { Id = GuidExtensions.GetGuid(), LanguageCode = "en", Name = english, IdParent = type.Id, CreatedOn = Now };
			builder.Entity<RoofType>().HasData(type);
			builder.Entity<RoofTypeLocalization>().HasData(frenchLocalization, englishLocalization);
		}

		private static void SeedInitialRoofMaterialType(ModelBuilder builder)
		{
			SeedRoofMaterialType(builder, "Bardeaux d'asphalte", "Asphalt shingles");
			SeedRoofMaterialType(builder, "Tôle", "Sheet metal");
			SeedRoofMaterialType(builder, "Tapis de goudron", "Tar mat");
			SeedRoofMaterialType(builder, "Puit de lumière", "Skylight");
			SeedRoofMaterialType(builder, "Bois", "Wood");
		}

		private static void SeedRoofMaterialType(ModelBuilder builder, string french, string english)
		{
			var type = new RoofMaterialType {Id = GuidExtensions.GetGuid(), CreatedOn = Now};
			var frenchLocalization = new RoofMaterialTypeLocalization {Id = GuidExtensions.GetGuid(), LanguageCode = "fr", Name = french, IdParent = type.Id, CreatedOn = Now};
			var englishLocalization = new RoofMaterialTypeLocalization {Id = GuidExtensions.GetGuid(), LanguageCode = "en", Name = english, IdParent = type.Id, CreatedOn = Now};
			builder.Entity<RoofMaterialType>().HasData(type);
			builder.Entity<RoofMaterialTypeLocalization>().HasData(frenchLocalization, englishLocalization);
		}

		private static void SeedInitialSidingType(ModelBuilder builder)
		{					
			SeedSidingType(builder,"Brique", "Brick");
			SeedSidingType(builder,"Béton", "Concrete");
			SeedSidingType(builder,"Vinyle", "Vinyl");
			SeedSidingType(builder,"Bois", "Wood");
			SeedSidingType(builder,"Canexel", "Canexel");
			SeedSidingType(builder,"Pierre", "Stone");
			SeedSidingType(builder,"Stucco", "Stucco");
			SeedSidingType(builder,"Tôle", "Sheet metal");
			SeedSidingType(builder,"Bardeaux de cèdre", "Cedar shingles");
			SeedSidingType(builder,"Masonite", "Masonite");
		}

		private static void SeedSidingType(ModelBuilder builder, string french, string english)
		{
			var type = new SidingType { Id = GuidExtensions.GetGuid(), CreatedOn = Now };
			var frenchLocalization = new SidingTypeLocalization { Id = GuidExtensions.GetGuid(), LanguageCode = "fr", Name = french, IdParent = type.Id, CreatedOn = Now };
			var englishLocalization = new SidingTypeLocalization { Id = GuidExtensions.GetGuid(), LanguageCode = "en", Name = english, IdParent = type.Id, CreatedOn = Now };
			builder.Entity<SidingType>().HasData(type);
			builder.Entity<SidingTypeLocalization>().HasData(frenchLocalization, englishLocalization);
		}

		private static void SeedInitialSprinklerType(ModelBuilder builder)
		{
			SeedSprinklerType(builder, "Système sous eau", "Wet pipe");
			SeedSprinklerType(builder, "Système sous air", "Dry pipe");
			SeedSprinklerType(builder, "Pré action", "Pre-Action");
			SeedSprinklerType(builder, "Déluge", "Deluge");
			SeedSprinklerType(builder, "Mousse", "Foam");
			SeedSprinklerType(builder, "FM 200", "FM 200");
		}

		private static void SeedSprinklerType(ModelBuilder builder, string french, string english)
		{
			var type = new SprinklerType { Id = GuidExtensions.GetGuid(), CreatedOn = Now };
			var frenchLocalization = new SprinklerTypeLocalization { Id = GuidExtensions.GetGuid(), LanguageCode = "fr", Name = french, IdParent = type.Id, CreatedOn = Now };
			var englishLocalization = new SprinklerTypeLocalization { Id = GuidExtensions.GetGuid(), LanguageCode = "en", Name = english, IdParent = type.Id, CreatedOn = Now };
			builder.Entity<SprinklerType>().HasData(type);
			builder.Entity<SprinklerTypeLocalization>().HasData(frenchLocalization, englishLocalization);
		}

		private static void SeedInitialAlarmPanelType(ModelBuilder builder)
		{
			SeedAlarmPanelType(builder, "Intrusion","Intrusion");
			SeedAlarmPanelType(builder, "Non zoné", "Not zoned");
			SeedAlarmPanelType(builder, "Zoné", "Zoned");
			SeedAlarmPanelType(builder, "Adressable", "Adressable");
		}

		private static void SeedAlarmPanelType(ModelBuilder builder, string french, string english)
		{
			var type = new AlarmPanelType { Id = GuidExtensions.GetGuid(), CreatedOn = Now };
			var frenchLocalization = new AlarmPanelTypeLocalization { Id = GuidExtensions.GetGuid(), LanguageCode = "fr", Name = french, IdParent = type.Id, CreatedOn = Now };
			var englishLocalization = new AlarmPanelTypeLocalization { Id = GuidExtensions.GetGuid(), LanguageCode = "en", Name = english, IdParent = type.Id, CreatedOn = Now };
			builder.Entity<AlarmPanelType>().HasData(type);
			builder.Entity<AlarmPanelTypeLocalization>().HasData(frenchLocalization, englishLocalization);
		}

		private static void SeedInitialPersonRequiringAssistanceType(ModelBuilder builder)
		{
			SeedPersonRequiringAssistanceType(builder, "Camp/Terrain de jeu", "Camp/playground");
			SeedPersonRequiringAssistanceType(builder,"Personnes handicapées", "Handicapped person");
			SeedPersonRequiringAssistanceType(builder,"Trouble vision", "Visually impaired");
			SeedPersonRequiringAssistanceType(builder,"Surdité", "Deafness");
			SeedPersonRequiringAssistanceType(builder,"Cognitif", "Cognitive");
			SeedPersonRequiringAssistanceType(builder,"Autre", "Other");
			SeedPersonRequiringAssistanceType(builder,"Centre médical", "Medical center");
			SeedPersonRequiringAssistanceType(builder,"Déficients intellectuels", "Intellectual deficient");
			SeedPersonRequiringAssistanceType(builder,"École", "School");
			SeedPersonRequiringAssistanceType(builder,"Garderie", "Nursery");
			SeedPersonRequiringAssistanceType(builder,"Malentendants", "Hard of hearing");
			SeedPersonRequiringAssistanceType(builder,"Mobilité réduite", "Reduced mobility");
			SeedPersonRequiringAssistanceType(builder,"Non-voyants", "Blind");
			SeedPersonRequiringAssistanceType(builder,"Personnes agées", "Elderly");
		}

		private static void SeedPersonRequiringAssistanceType(ModelBuilder builder, string french, string english)
		{
			var type = new PersonRequiringAssistanceType { Id = GuidExtensions.GetGuid(), CreatedOn = Now };
			var frenchLocalization = new PersonRequiringAssistanceTypeLocalization { Id = GuidExtensions.GetGuid(), LanguageCode = "fr", Name = french, IdParent = type.Id, CreatedOn = Now };
			var englishLocalization = new PersonRequiringAssistanceTypeLocalization { Id = GuidExtensions.GetGuid(), LanguageCode = "en", Name = english, IdParent = type.Id, CreatedOn = Now };
			builder.Entity<PersonRequiringAssistanceType>().HasData(type);
			builder.Entity<PersonRequiringAssistanceTypeLocalization>().HasData(frenchLocalization, englishLocalization);
		}

		private static void SeedInitialFireHydrantConnectionType(ModelBuilder builder)
		{
			SeedFireHydrantConnectionType(builder, "Fileté", "Threaded");
			SeedFireHydrantConnectionType(builder, "Storz", "Storz");
		}

		private static void SeedFireHydrantConnectionType(ModelBuilder builder, string french, string english)
		{
			var type = new FireHydrantConnectionType { Id = GuidExtensions.GetGuid(), CreatedOn = Now };
			var frenchLocalization = new FireHydrantConnectionTypeLocalization { Id = GuidExtensions.GetGuid(), LanguageCode = "fr", Name = french, IdParent = type.Id, CreatedOn = Now };
			var englishLocalization = new FireHydrantConnectionTypeLocalization { Id = GuidExtensions.GetGuid(), LanguageCode = "en", Name = english, IdParent = type.Id, CreatedOn = Now };
			builder.Entity<FireHydrantConnectionType>().HasData(type);
			builder.Entity<FireHydrantConnectionTypeLocalization>().HasData(frenchLocalization, englishLocalization);
		}

		private static void SeedInitialFireHydrantType(ModelBuilder builder)
		{
			SeedFireHydrantType(builder, "Sèche", "Dry");
			SeedFireHydrantType(builder, "Fontaine", "Fountain");
			SeedFireHydrantType(builder, "Citerne", "Tank");
			SeedFireHydrantType(builder, "Borne fontaine", "Fire hydrant");
			SeedFireHydrantType(builder, "Point d'eau", "Water point");
			SeedFireHydrantType(builder, "Borne sèche", "Dry fire hydrant");
			SeedFireHydrantType(builder, "Statique", "Static");
		}

		private static void SeedFireHydrantType(ModelBuilder builder, string french, string english)
		{
			var type = new FireHydrantType { Id = GuidExtensions.GetGuid(), CreatedOn = Now };
			var frenchLocalization = new FireHydrantTypeLocalization { Id = GuidExtensions.GetGuid(), LanguageCode = "fr", Name = french, IdParent = type.Id, CreatedOn = Now };
			var englishLocalization = new FireHydrantTypeLocalization { Id = GuidExtensions.GetGuid(), LanguageCode = "en", Name = english, IdParent = type.Id, CreatedOn = Now };
			builder.Entity<FireHydrantType>().HasData(type);
			builder.Entity<FireHydrantTypeLocalization>().HasData(frenchLocalization, englishLocalization);
		}

		private static void SeedInitialOperatorTypes(ModelBuilder builder)
		{
			SeedOperatorType(builder, "=");
			SeedOperatorType(builder, ">");
			SeedOperatorType(builder, ">=");
			SeedOperatorType(builder, "<");
			SeedOperatorType(builder, "<=");
		}

		private static void SeedOperatorType(ModelBuilder builder, string value)
		{
			var type = new OperatorType { Id = GuidExtensions.GetGuid(), CreatedOn = Now, Symbol = value };
			builder.Entity<OperatorType>().HasData(type);
		}

		private static void SeedInitialDataForMeasuringUnit(ModelBuilder builder)
		{
			SeedUnitOfMeasure(builder, MeasureType.Rate, "GIPM", "GIPM", "GIPM");
			SeedUnitOfMeasure(builder, MeasureType.Rate, "GPM", "GPM", "GPM");
			SeedUnitOfMeasure(builder, MeasureType.Rate, "LPM", "LPM", "LPM");
			SeedUnitOfMeasure(builder, MeasureType.Rate, "GI", "GI", "GI");
			SeedUnitOfMeasure(builder, MeasureType.Rate, "G", "G", "G");
			SeedUnitOfMeasure(builder, MeasureType.Rate, "L", "L", "L");
			SeedUnitOfMeasure(builder, MeasureType.Rate, "", "Indéterminé", "Unknown");

			SeedUnitOfMeasure(builder, MeasureType.Pressure, "PSI", "PSI", "PSI");
			SeedUnitOfMeasure(builder, MeasureType.Pressure, "KPA", "KPA", "KPA");
			SeedUnitOfMeasure(builder, MeasureType.Pressure, "m3/h", "m3/h", "m3/h");

			SeedUnitOfMeasure(builder, MeasureType.Diameter, "mm", "Millimètres", "Millimeters");
			SeedUnitOfMeasure(builder, MeasureType.Diameter, "po", "Pouces", "Inches");

			SeedUnitOfMeasure(builder, MeasureType.Dimension, "m", "Mètres", "Meters");
			SeedUnitOfMeasure(builder, MeasureType.Dimension, "pi", "Pieds", "Feet");

			SeedUnitOfMeasure(builder, MeasureType.Capacity, "m3", "Mètres cubes", "Cubic meters");
			SeedUnitOfMeasure(builder, MeasureType.Capacity, "po3", "Pouces cubes", "Cubic inches");
			SeedUnitOfMeasure(builder, MeasureType.Capacity, "ml", "Millilitres", "Millilitre");
			SeedUnitOfMeasure(builder, MeasureType.Capacity, "pt", "Pintes", "Pints");
			SeedUnitOfMeasure(builder, MeasureType.Capacity, "t", "Tonnes", "Tons");
			SeedUnitOfMeasure(builder, MeasureType.Capacity, "sh tn", "Tonnes US", "US tons");
			SeedUnitOfMeasure(builder, MeasureType.Capacity, "pi3", "Pieds cubes", "Cubic feet");
			SeedUnitOfMeasure(builder, MeasureType.Capacity, "GI", "Gallons impériaux", "Imperial gallons");
			SeedUnitOfMeasure(builder, MeasureType.Capacity, "", "Aucune", "None");
			SeedUnitOfMeasure(builder, MeasureType.Capacity, "G", "Gallons US", "US gallons");
			SeedUnitOfMeasure(builder, MeasureType.Capacity, "g", "Grammes", "Grams");
			SeedUnitOfMeasure(builder, MeasureType.Capacity, "Kg", "Kilos", "Kilos");
			SeedUnitOfMeasure(builder, MeasureType.Capacity, "L", "Litres", "Litres");
			SeedUnitOfMeasure(builder, MeasureType.Capacity, "lb", "Livres", "Pounds");
			SeedUnitOfMeasure(builder, MeasureType.Capacity, "oz", "Onces", "Onces");
		}

		private static void SeedUnitOfMeasure(ModelBuilder builder, MeasureType measureType, string abbreviation, string french, string english)
		{
			var type = new UnitOfMeasure { Id = GuidExtensions.GetGuid(), MeasureType = measureType, CreatedOn = Now, Abbreviation = abbreviation };
			var frenchLocalization = new UnitOfMeasureLocalization { Id = GuidExtensions.GetGuid(), LanguageCode = "fr", Name = french, IdParent = type.Id, CreatedOn = Now };
			var englishLocalization = new UnitOfMeasureLocalization { Id = GuidExtensions.GetGuid(), LanguageCode = "en", Name = english, IdParent = type.Id, CreatedOn = Now };
			builder.Entity<UnitOfMeasure>().HasData(type);
			builder.Entity<UnitOfMeasureLocalization>().HasData(frenchLocalization, englishLocalization);
		}
	}
}