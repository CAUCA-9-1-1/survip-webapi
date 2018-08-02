using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.Models;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.FireHydrants;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.DataLayer.InitialData
{
    public static class InitialDataForBaseTable
    {
		public static void SeedInitialData(this ModelBuilder builder)
		{
			var data = GetInitialConstructionTypes();
			builder.Entity<ConstructionType>().HasData(data);
			/*builder.Entity<BuildingType>().HasData(GetInitialBuildingType());
			builder.Entity<RoofType>().HasData(GetInitialRoofType());

			builder.Entity<RoofType>().HasData(GetInitialRoofMaterialType());
			builder.Entity<SidingType>().HasData(GetInitialSidingType());
			builder.Entity<SprinklerType>().HasData(GetInitialSprinklerType());
			builder.Entity<AlarmPanelType>().HasData(GetInitialAlarmPanelType());
			builder.Entity<PersonRequiringAssistanceType>().HasData(GetInitialPersonRequiringAssistanceType());
			builder.Entity<FireHydrantConnectionType>().HasData(GetInitialFireHydrantConnectionType());
			builder.Entity<FireHydrantType>().HasData(GetInitialFireHydrantType());
			builder.Entity<OperatorType>().HasData(GetInitialOperatorTypes());
			builder.Entity<ConstructionFireResistanceType>().HasData(GetInitialFireResistanceType());
			builder.Entity<UnitOfMeasure>().HasData(GetInitialDataForMeasuringUnit());
			builder.Entity<LaneGenericCode>().HasData(InitialLaneGenericCodesGenerator.GetInitialData());
			builder.Entity<LanePublicCode>().HasData(InitialLanePublicCodesGenerator.GetInitialData());
			var users = InitialUserGenerator.GetInitialData();
			builder.Entity<Webuser>().HasData(users);
			builder.Entity<PermissionSystem>().HasData(InitialPermissionGenerator.GetInitialData(users.First().Id));
			builder.Entity<RiskLevel>().HasData(InitialRiskLevelGenerator.GetInitialData());	*/
		}

		public static void SeedInitialDataForDevelopment(this ModelBuilder builder)
		{
			/*builder.Entity<Country>().HasData(InitialDataForCauca.GetInitialGeographicData());
			builder.Entity<CityType>().HasData(InitialDataForCauca.GetInitialCityTypes());*/
		}

		private static IEnumerable<ConstructionFireResistanceType> GetInitialFireResistanceType()
		{
			yield return new ConstructionFireResistanceType { Localizations = new List<ConstructionFireResistanceTypeLocalization> { new ConstructionFireResistanceTypeLocalization { LanguageCode = "fr", Name = "Ordinaire"}, new ConstructionFireResistanceTypeLocalization { LanguageCode = "en", Name = "Regular"} } };
			yield return new ConstructionFireResistanceType { Localizations = new List<ConstructionFireResistanceTypeLocalization> { new ConstructionFireResistanceTypeLocalization { LanguageCode = "fr", Name = "Combustible" }, new ConstructionFireResistanceTypeLocalization { LanguageCode = "en", Name = "Flammable" } } };
			yield return new ConstructionFireResistanceType { Localizations = new List<ConstructionFireResistanceTypeLocalization> { new ConstructionFireResistanceTypeLocalization { LanguageCode = "fr", Name = "Incombustible" }, new ConstructionFireResistanceTypeLocalization { LanguageCode = "en", Name = "Nonflammable" } } };
			yield return new ConstructionFireResistanceType { Localizations = new List<ConstructionFireResistanceTypeLocalization> { new ConstructionFireResistanceTypeLocalization { LanguageCode = "fr", Name = "Résistante au feu" }, new ConstructionFireResistanceTypeLocalization { LanguageCode = "en", Name = "Fire resistant" } } };
			yield return new ConstructionFireResistanceType { Localizations = new List<ConstructionFireResistanceTypeLocalization> { new ConstructionFireResistanceTypeLocalization { LanguageCode = "fr", Name = "Hybride" }, new ConstructionFireResistanceTypeLocalization { LanguageCode = "en", Name = "Hybrid" } } };
		}

	    private static ConstructionType[] GetInitialConstructionTypes()
	    {
		    var types = new[]
		    {
			    new ConstructionType {/*Localizations = new List<ConstructionTypeLocalization> {new ConstructionTypeLocalization {LanguageCode = "fr", Name = "Ossature de bois avec solives en bois solide"}, new ConstructionTypeLocalization {LanguageCode = "en", Name = "Wood frame with solid wood joists"}}*/},
			    /*new ConstructionType {Localizations = new List<ConstructionTypeLocalization> {new ConstructionTypeLocalization {LanguageCode = "fr", Name = "Ossature de bois avec solives préfabriquées"}, new ConstructionTypeLocalization {LanguageCode = "en", Name = "Wood frame and prefabricated joists"}}},
			    new ConstructionType {Localizations = new List<ConstructionTypeLocalization> {new ConstructionTypeLocalization {LanguageCode = "fr", Name = "Gros bois d'oeuvre"}, new ConstructionTypeLocalization {LanguageCode = "en", Name = "Lumber"}}},
			    new ConstructionType {Localizations = new List<ConstructionTypeLocalization> {new ConstructionTypeLocalization {LanguageCode = "fr", Name = "Mur porteur en maçonnerie avec mur solives en bois solides"}, new ConstructionTypeLocalization {LanguageCode = "en", Name = "Masonry bearing wall and solid wood joists"}}},
			    new ConstructionType {Localizations = new List<ConstructionTypeLocalization> {new ConstructionTypeLocalization {LanguageCode = "fr", Name = "Mur porteur en maçonnerie et solives préfabriquées" }, new ConstructionTypeLocalization {LanguageCode = "en", Name = "Masonry bearing wall and prefabricated joists"}}},
			    new ConstructionType {Localizations = new List<ConstructionTypeLocalization> {new ConstructionTypeLocalization {LanguageCode = "fr", Name = "Mur porteur en maçonnerie et solives en aciers ou dalle de béton" }, new ConstructionTypeLocalization {LanguageCode = "en", Name = "Masonry bearing wall and steel joists or concrete slab"}}},
			    new ConstructionType {Localizations = new List<ConstructionTypeLocalization> {new ConstructionTypeLocalization {LanguageCode = "fr", Name = "Acier avec solives en acier protégées" }, new ConstructionTypeLocalization {LanguageCode = "en", Name = "Steel with protected steel joists"}}},
			    new ConstructionType {Localizations = new List<ConstructionTypeLocalization> {new ConstructionTypeLocalization {LanguageCode = "fr", Name = "Acier avec solives en acier non protégées" }, new ConstructionTypeLocalization {LanguageCode = "en", Name = "Steel with unprotected steel joists"}}},
			    new ConstructionType {Localizations = new List<ConstructionTypeLocalization> {new ConstructionTypeLocalization {LanguageCode = "fr", Name = "Béton"}, new ConstructionTypeLocalization {LanguageCode = "en", Name = "Concrete"}}},
			    new ConstructionType {Localizations = new List<ConstructionTypeLocalization> {new ConstructionTypeLocalization {LanguageCode = "fr", Name = "Autre type"}, new ConstructionTypeLocalization {LanguageCode = "en", Name = "Other"}}},
			    new ConstructionType {Localizations = new List<ConstructionTypeLocalization> {new ConstructionTypeLocalization {LanguageCode = "fr", Name = "Indéterminé"}, new ConstructionTypeLocalization {LanguageCode = "en", Name = "Undetermined"}}}*/
		    };

			/*foreach (var type in types)
		    foreach (var localization in type.Localizations)
		    {
			    localization.Parent = type;
			    localization.IdParent = type.Id;
		    }*/

		    return types;
	    }

	    private static IEnumerable<BuildingType> GetInitialBuildingType()
		{
			yield return new BuildingType {Localizations = new List<BuildingTypeLocalization> {new BuildingTypeLocalization { LanguageCode = "fr", Name = "Attaché" }, new BuildingTypeLocalization { LanguageCode = "en", Name = "Attached" }}};
			yield return new BuildingType { Localizations = new List<BuildingTypeLocalization> { new BuildingTypeLocalization { LanguageCode = "fr", Name = "Détaché" }, new BuildingTypeLocalization { LanguageCode = "en", Name = "Detached" } } };
			yield return new BuildingType { Localizations = new List<BuildingTypeLocalization> { new BuildingTypeLocalization { LanguageCode = "fr", Name = "Jumelé" }, new BuildingTypeLocalization { LanguageCode = "en", Name = "Semi-detached" } } };
			yield return new BuildingType { Localizations = new List<BuildingTypeLocalization> { new BuildingTypeLocalization { LanguageCode = "fr", Name = "Autre" }, new BuildingTypeLocalization { LanguageCode = "en", Name = "Other" } } };
		}

	    private static IEnumerable<RoofType> GetInitialRoofType()
	    {
		    yield return new RoofType { Localizations = new List<RoofTypeLocalization> { new RoofTypeLocalization { LanguageCode = "fr", Name = "1 versant" }, new RoofTypeLocalization { LanguageCode = "en", Name = "1 slope" } } };
		    yield return new RoofType { Localizations = new List<RoofTypeLocalization> { new RoofTypeLocalization { LanguageCode = "fr", Name = "2 versants" }, new RoofTypeLocalization { LanguageCode = "en", Name = "2 slopes" } } };
		    yield return new RoofType { Localizations = new List<RoofTypeLocalization> { new RoofTypeLocalization { LanguageCode = "fr", Name = "4 versants" }, new RoofTypeLocalization { LanguageCode = "en", Name = "4 slopes" } } };
		    yield return new RoofType { Localizations = new List<RoofTypeLocalization> { new RoofTypeLocalization { LanguageCode = "fr", Name = "Cône français" }, new RoofTypeLocalization { LanguageCode = "en", Name = "French cone" } } };
		    yield return new RoofType { Localizations = new List<RoofTypeLocalization> { new RoofTypeLocalization { LanguageCode = "fr", Name = "Diamant" }, new RoofTypeLocalization { LanguageCode = "en", Name = "Diamond" } } };
		    yield return new RoofType { Localizations = new List<RoofTypeLocalization> { new RoofTypeLocalization { LanguageCode = "fr", Name = "Dôme" }, new RoofTypeLocalization { LanguageCode = "en", Name = "Dome" } } };
		    yield return new RoofType { Localizations = new List<RoofTypeLocalization> { new RoofTypeLocalization { LanguageCode = "fr", Name = "Mansarde" }, new RoofTypeLocalization { LanguageCode = "en", Name = "Mansard" } } };
		    yield return new RoofType { Localizations = new List<RoofTypeLocalization> { new RoofTypeLocalization { LanguageCode = "fr", Name = "Pente" }, new RoofTypeLocalization { LanguageCode = "en", Name = "Slope" } } };
		    yield return new RoofType { Localizations = new List<RoofTypeLocalization> { new RoofTypeLocalization { LanguageCode = "fr", Name = "Plat" }, new RoofTypeLocalization { LanguageCode = "en", Name = "Flat" } } };
		}

	    private static IEnumerable<RoofMaterialType> GetInitialRoofMaterialType()
	    {
		    yield return new RoofMaterialType { Localizations = new List<RoofMaterialTypeLocalization> { new RoofMaterialTypeLocalization { LanguageCode = "fr", Name = "Bardeaux d'asphalte" }, new RoofMaterialTypeLocalization { LanguageCode = "en", Name = "Asphalt shingles" } } };
		    yield return new RoofMaterialType { Localizations = new List<RoofMaterialTypeLocalization> { new RoofMaterialTypeLocalization { LanguageCode = "fr", Name = "Tôle" }, new RoofMaterialTypeLocalization { LanguageCode = "en", Name = "Sheet metal" } } };
		    yield return new RoofMaterialType { Localizations = new List<RoofMaterialTypeLocalization> { new RoofMaterialTypeLocalization { LanguageCode = "fr", Name = "Tapis de goudron" }, new RoofMaterialTypeLocalization { LanguageCode = "en", Name = "Tar mat" } } };
		    yield return new RoofMaterialType { Localizations = new List<RoofMaterialTypeLocalization> { new RoofMaterialTypeLocalization { LanguageCode = "fr", Name = "Puit de lumière" }, new RoofMaterialTypeLocalization { LanguageCode = "en", Name = "Skylight" } } };
		    yield return new RoofMaterialType { Localizations = new List<RoofMaterialTypeLocalization> { new RoofMaterialTypeLocalization { LanguageCode = "fr", Name = "Bois" }, new RoofMaterialTypeLocalization { LanguageCode = "en", Name = "Wood" } } };
		}

	    private static IEnumerable<SidingType> GetInitialSidingType()
	    {
		    yield return new SidingType { Localizations = new List<SidingTypeLocalization> { new SidingTypeLocalization { LanguageCode = "fr", Name = "Brique" }, new SidingTypeLocalization { LanguageCode = "en", Name = "Brick" } } };
		    yield return new SidingType { Localizations = new List<SidingTypeLocalization> { new SidingTypeLocalization { LanguageCode = "fr", Name = "Béton" }, new SidingTypeLocalization { LanguageCode = "en", Name = "Concrete" } } };
		    yield return new SidingType { Localizations = new List<SidingTypeLocalization> { new SidingTypeLocalization { LanguageCode = "fr", Name = "Vinyle" }, new SidingTypeLocalization { LanguageCode = "en", Name = "Vinyl" } } };
		    yield return new SidingType { Localizations = new List<SidingTypeLocalization> { new SidingTypeLocalization { LanguageCode = "fr", Name = "Bois" }, new SidingTypeLocalization { LanguageCode = "en", Name = "Wood" } } };
		    yield return new SidingType { Localizations = new List<SidingTypeLocalization> { new SidingTypeLocalization { LanguageCode = "fr", Name = "Canexel" }, new SidingTypeLocalization { LanguageCode = "en", Name = "Canexel" } } };
		    yield return new SidingType { Localizations = new List<SidingTypeLocalization> { new SidingTypeLocalization { LanguageCode = "fr", Name = "Pierre" }, new SidingTypeLocalization { LanguageCode = "en", Name = "Stone" } } };
		    yield return new SidingType { Localizations = new List<SidingTypeLocalization> { new SidingTypeLocalization { LanguageCode = "fr", Name = "Stucco" }, new SidingTypeLocalization { LanguageCode = "en", Name = "Stucco" } } };
		    yield return new SidingType { Localizations = new List<SidingTypeLocalization> { new SidingTypeLocalization { LanguageCode = "fr", Name = "Tôle" }, new SidingTypeLocalization { LanguageCode = "en", Name = "Sheet metal" } } };
		    yield return new SidingType { Localizations = new List<SidingTypeLocalization> { new SidingTypeLocalization { LanguageCode = "fr", Name = "Bardeaux de cèdre" }, new SidingTypeLocalization { LanguageCode = "en", Name = "Cedar shingles" } } };
		    yield return new SidingType { Localizations = new List<SidingTypeLocalization> { new SidingTypeLocalization { LanguageCode = "fr", Name = "Masonite" }, new SidingTypeLocalization { LanguageCode = "en", Name = "Masonite" } } };
		}

	    private static IEnumerable<SprinklerType> GetInitialSprinklerType()
	    {
		    yield return new SprinklerType { Localizations = new List<SprinklerTypeLocalization> { new SprinklerTypeLocalization { LanguageCode = "fr", Name = "Système sous eau" }, new SprinklerTypeLocalization { LanguageCode = "en", Name = "Wet pipe" } } };
		    yield return new SprinklerType { Localizations = new List<SprinklerTypeLocalization> { new SprinklerTypeLocalization { LanguageCode = "fr", Name = "Système sous air" }, new SprinklerTypeLocalization { LanguageCode = "en", Name = "Dry pipe" } } };
		    yield return new SprinklerType { Localizations = new List<SprinklerTypeLocalization> { new SprinklerTypeLocalization { LanguageCode = "fr", Name = "Pré action" }, new SprinklerTypeLocalization { LanguageCode = "en", Name = "Pre-Action" } } };
		    yield return new SprinklerType { Localizations = new List<SprinklerTypeLocalization> { new SprinklerTypeLocalization { LanguageCode = "fr", Name = "Déluge" }, new SprinklerTypeLocalization { LanguageCode = "en", Name = "Deluge" } } };
		    yield return new SprinklerType { Localizations = new List<SprinklerTypeLocalization> { new SprinklerTypeLocalization { LanguageCode = "fr", Name = "Mousse" }, new SprinklerTypeLocalization { LanguageCode = "en", Name = "Foam" } } };
		    yield return new SprinklerType { Localizations = new List<SprinklerTypeLocalization> { new SprinklerTypeLocalization { LanguageCode = "fr", Name = "FM 200" }, new SprinklerTypeLocalization { LanguageCode = "en", Name = "FM 200" } } };
		}

	    private static IEnumerable<AlarmPanelType> GetInitialAlarmPanelType()
	    {
		    yield return new AlarmPanelType { Localizations = new List<AlarmPanelTypeLocalization> { new AlarmPanelTypeLocalization { LanguageCode = "fr", Name = "Intrusion" }, new AlarmPanelTypeLocalization { LanguageCode = "en", Name = "Intrusion" } } };
		    yield return new AlarmPanelType { Localizations = new List<AlarmPanelTypeLocalization> { new AlarmPanelTypeLocalization { LanguageCode = "fr", Name = "Non zoné" }, new AlarmPanelTypeLocalization { LanguageCode = "en", Name = "Not zoned" } } };
		    yield return new AlarmPanelType { Localizations = new List<AlarmPanelTypeLocalization> { new AlarmPanelTypeLocalization { LanguageCode = "fr", Name = "Zoné" }, new AlarmPanelTypeLocalization { LanguageCode = "en", Name = "Zoned" } } };
		    yield return new AlarmPanelType { Localizations = new List<AlarmPanelTypeLocalization> { new AlarmPanelTypeLocalization { LanguageCode = "fr", Name = "Adressable" }, new AlarmPanelTypeLocalization { LanguageCode = "en", Name = "Adressable" } } };
	    }

	    private static IEnumerable<PersonRequiringAssistanceType> GetInitialPersonRequiringAssistanceType()
	    {
		    yield return new PersonRequiringAssistanceType { Localizations = new List<PersonRequiringAssistanceTypeLocalization> { new PersonRequiringAssistanceTypeLocalization { LanguageCode = "fr", Name = "Camp/Terrain de jeu" }, new PersonRequiringAssistanceTypeLocalization { LanguageCode = "en", Name = "Camp/playground" } } };
		    yield return new PersonRequiringAssistanceType { Localizations = new List<PersonRequiringAssistanceTypeLocalization> { new PersonRequiringAssistanceTypeLocalization { LanguageCode = "fr", Name = "Personnes handicapées" }, new PersonRequiringAssistanceTypeLocalization { LanguageCode = "en", Name = "Handicapped person" } } };
		    yield return new PersonRequiringAssistanceType { Localizations = new List<PersonRequiringAssistanceTypeLocalization> { new PersonRequiringAssistanceTypeLocalization { LanguageCode = "fr", Name = "Trouble vision" }, new PersonRequiringAssistanceTypeLocalization { LanguageCode = "en", Name = "Visually impaired" } } };
		    yield return new PersonRequiringAssistanceType { Localizations = new List<PersonRequiringAssistanceTypeLocalization> { new PersonRequiringAssistanceTypeLocalization { LanguageCode = "fr", Name = "Surdité" }, new PersonRequiringAssistanceTypeLocalization { LanguageCode = "en", Name = "Deafness" } } };
		    yield return new PersonRequiringAssistanceType { Localizations = new List<PersonRequiringAssistanceTypeLocalization> { new PersonRequiringAssistanceTypeLocalization { LanguageCode = "fr", Name = "Cognitif" }, new PersonRequiringAssistanceTypeLocalization { LanguageCode = "en", Name = "Cognitive" } } };
		    yield return new PersonRequiringAssistanceType { Localizations = new List<PersonRequiringAssistanceTypeLocalization> { new PersonRequiringAssistanceTypeLocalization { LanguageCode = "fr", Name = "Autre" }, new PersonRequiringAssistanceTypeLocalization { LanguageCode = "en", Name = "Other" } } };
		    yield return new PersonRequiringAssistanceType { Localizations = new List<PersonRequiringAssistanceTypeLocalization> { new PersonRequiringAssistanceTypeLocalization { LanguageCode = "fr", Name = "Centre médical" }, new PersonRequiringAssistanceTypeLocalization { LanguageCode = "en", Name = "Medical center" } } };
		    yield return new PersonRequiringAssistanceType { Localizations = new List<PersonRequiringAssistanceTypeLocalization> { new PersonRequiringAssistanceTypeLocalization { LanguageCode = "fr", Name = "Déficients intellectuels" }, new PersonRequiringAssistanceTypeLocalization { LanguageCode = "en", Name = "Intellectual deficient" } } };
		    yield return new PersonRequiringAssistanceType { Localizations = new List<PersonRequiringAssistanceTypeLocalization> { new PersonRequiringAssistanceTypeLocalization { LanguageCode = "fr", Name = "École" }, new PersonRequiringAssistanceTypeLocalization { LanguageCode = "en", Name = "School" } } };
		    yield return new PersonRequiringAssistanceType { Localizations = new List<PersonRequiringAssistanceTypeLocalization> { new PersonRequiringAssistanceTypeLocalization { LanguageCode = "fr", Name = "Garderie" }, new PersonRequiringAssistanceTypeLocalization { LanguageCode = "en", Name = "Nursery" } } };
		    yield return new PersonRequiringAssistanceType { Localizations = new List<PersonRequiringAssistanceTypeLocalization> { new PersonRequiringAssistanceTypeLocalization { LanguageCode = "fr", Name = "Malentendants" }, new PersonRequiringAssistanceTypeLocalization { LanguageCode = "en", Name = "Hard of hearing" } } };
		    yield return new PersonRequiringAssistanceType { Localizations = new List<PersonRequiringAssistanceTypeLocalization> { new PersonRequiringAssistanceTypeLocalization { LanguageCode = "fr", Name = "Mobilité réduite" }, new PersonRequiringAssistanceTypeLocalization { LanguageCode = "en", Name = "Reduced mobility" } } };
		    yield return new PersonRequiringAssistanceType { Localizations = new List<PersonRequiringAssistanceTypeLocalization> { new PersonRequiringAssistanceTypeLocalization { LanguageCode = "fr", Name = "Non-voyants" }, new PersonRequiringAssistanceTypeLocalization { LanguageCode = "en", Name = "Blind" } } };
		    yield return new PersonRequiringAssistanceType { Localizations = new List<PersonRequiringAssistanceTypeLocalization> { new PersonRequiringAssistanceTypeLocalization { LanguageCode = "fr", Name = "Personnes agées" }, new PersonRequiringAssistanceTypeLocalization { LanguageCode = "en", Name = "Elderly" } } };
		}

	    private static IEnumerable<FireHydrantConnectionType> GetInitialFireHydrantConnectionType()
	    {
		    yield return new FireHydrantConnectionType { Localizations = new List<FireHydrantConnectionTypeLocalization> { new FireHydrantConnectionTypeLocalization { LanguageCode = "fr", Name = "Fileté" }, new FireHydrantConnectionTypeLocalization { LanguageCode = "en", Name = "Threaded" } } };
		    yield return new FireHydrantConnectionType { Localizations = new List<FireHydrantConnectionTypeLocalization> { new FireHydrantConnectionTypeLocalization { LanguageCode = "fr", Name = "Storz" }, new FireHydrantConnectionTypeLocalization { LanguageCode = "en", Name = "Storz" } } };
	    }

	    private static IEnumerable<FireHydrantType> GetInitialFireHydrantType()
	    {
		    yield return new FireHydrantType { Localizations = new List<FireHydrantTypeLocalization> { new FireHydrantTypeLocalization { LanguageCode = "fr", Name = "Sèche" }, new FireHydrantTypeLocalization { LanguageCode = "en", Name = "Dry" } } };
		    yield return new FireHydrantType { Localizations = new List<FireHydrantTypeLocalization> { new FireHydrantTypeLocalization { LanguageCode = "fr", Name = "Fontaine" }, new FireHydrantTypeLocalization { LanguageCode = "en", Name = "Fountain" } } };
		    yield return new FireHydrantType { Localizations = new List<FireHydrantTypeLocalization> { new FireHydrantTypeLocalization { LanguageCode = "fr", Name = "Citerne" }, new FireHydrantTypeLocalization { LanguageCode = "en", Name = "Tank" } } };
		    yield return new FireHydrantType { Localizations = new List<FireHydrantTypeLocalization> { new FireHydrantTypeLocalization { LanguageCode = "fr", Name = "Borne fontaine" }, new FireHydrantTypeLocalization { LanguageCode = "en", Name = "Fire hydrant" } } };
		    yield return new FireHydrantType { Localizations = new List<FireHydrantTypeLocalization> { new FireHydrantTypeLocalization { LanguageCode = "fr", Name = "Point d'eau" }, new FireHydrantTypeLocalization { LanguageCode = "en", Name = "Water point" } } };
		    yield return new FireHydrantType { Localizations = new List<FireHydrantTypeLocalization> { new FireHydrantTypeLocalization { LanguageCode = "fr", Name = "Borne sèche" }, new FireHydrantTypeLocalization { LanguageCode = "en", Name = "Dry fire hydrant" } } };
		    yield return new FireHydrantType { Localizations = new List<FireHydrantTypeLocalization> { new FireHydrantTypeLocalization { LanguageCode = "fr", Name = "Statique" }, new FireHydrantTypeLocalization { LanguageCode = "en", Name = "Static" } } };
		}

		private static IEnumerable<OperatorType> GetInitialOperatorTypes()
		{
			yield return new OperatorType { Symbol = "=" };
			yield return new OperatorType { Symbol = ">" };
			yield return new OperatorType { Symbol = ">=" };
			yield return new OperatorType { Symbol = "<" };
			yield return new OperatorType { Symbol = "<=" };
		}

	    private static IEnumerable<UnitOfMeasure> GetInitialDataForMeasuringUnit()
	    {
		    yield return new UnitOfMeasure { MeasureType = MeasureType.Rate, Abbreviation = "GIPM", Localizations = new List<UnitOfMeasureLocalization> {new UnitOfMeasureLocalization {Name = "GIPM", LanguageCode = "fr"}, new UnitOfMeasureLocalization {Name = "GIPM", LanguageCode = "en" } }};
		    yield return new UnitOfMeasure { MeasureType = MeasureType.Rate, Abbreviation = "GPM", Localizations = new List<UnitOfMeasureLocalization> { new UnitOfMeasureLocalization { Name = "GPM", LanguageCode = "fr" }, new UnitOfMeasureLocalization { Name = "GPM", LanguageCode = "en" } } };
		    yield return new UnitOfMeasure { MeasureType = MeasureType.Rate, Abbreviation = "LPM", Localizations = new List<UnitOfMeasureLocalization> { new UnitOfMeasureLocalization { Name = "LPM", LanguageCode = "fr" }, new UnitOfMeasureLocalization { Name = "LPM", LanguageCode = "en" } } };
		    yield return new UnitOfMeasure { MeasureType = MeasureType.Rate, Abbreviation = "GI", Localizations = new List<UnitOfMeasureLocalization> { new UnitOfMeasureLocalization { Name = "GI", LanguageCode = "fr" }, new UnitOfMeasureLocalization { Name = "GI", LanguageCode = "en" } } };
		    yield return new UnitOfMeasure { MeasureType = MeasureType.Rate, Abbreviation = "G", Localizations = new List<UnitOfMeasureLocalization> { new UnitOfMeasureLocalization { Name = "G", LanguageCode = "fr" }, new UnitOfMeasureLocalization { Name = "G", LanguageCode = "en" } } };
		    yield return new UnitOfMeasure { MeasureType = MeasureType.Rate, Abbreviation = "L", Localizations = new List<UnitOfMeasureLocalization> { new UnitOfMeasureLocalization { Name = "L", LanguageCode = "fr" }, new UnitOfMeasureLocalization { Name = "L", LanguageCode = "en" } } };
		    yield return new UnitOfMeasure { MeasureType = MeasureType.Rate, Abbreviation = "", Localizations = new List<UnitOfMeasureLocalization> { new UnitOfMeasureLocalization { Name = "Indéterminé", LanguageCode = "fr" }, new UnitOfMeasureLocalization { Name = "Unknown", LanguageCode = "en" } } };

		    yield return new UnitOfMeasure { MeasureType = MeasureType.Pressure, Abbreviation = "PSI", Localizations = new List<UnitOfMeasureLocalization> { new UnitOfMeasureLocalization { Name = "PSI", LanguageCode = "fr" }, new UnitOfMeasureLocalization { Name = "PSI", LanguageCode = "en" } } };
		    yield return new UnitOfMeasure { MeasureType = MeasureType.Pressure, Abbreviation = "KPA", Localizations = new List<UnitOfMeasureLocalization> { new UnitOfMeasureLocalization { Name = "KPA", LanguageCode = "fr" }, new UnitOfMeasureLocalization { Name = "KPA", LanguageCode = "en" } } };
		    yield return new UnitOfMeasure { MeasureType = MeasureType.Pressure, Abbreviation = "m3/h", Localizations = new List<UnitOfMeasureLocalization> { new UnitOfMeasureLocalization { Name = "m3/h", LanguageCode = "fr" }, new UnitOfMeasureLocalization { Name = "m3/h", LanguageCode = "en" } } };

		    yield return new UnitOfMeasure { MeasureType = MeasureType.Diameter, Abbreviation = "mm", Localizations = new List<UnitOfMeasureLocalization> { new UnitOfMeasureLocalization { Name = "Millimètres", LanguageCode = "fr" }, new UnitOfMeasureLocalization { Name = "Millimeters", LanguageCode = "en" } } };
		    yield return new UnitOfMeasure { MeasureType = MeasureType.Diameter, Abbreviation = "po", Localizations = new List<UnitOfMeasureLocalization> { new UnitOfMeasureLocalization { Name = "Pouces", LanguageCode = "fr" }, new UnitOfMeasureLocalization { Name = "Inches", LanguageCode = "en" } } };

		    yield return new UnitOfMeasure { MeasureType = MeasureType.Dimension, Abbreviation = "m", Localizations = new List<UnitOfMeasureLocalization> { new UnitOfMeasureLocalization { Name = "Mètres", LanguageCode = "fr" }, new UnitOfMeasureLocalization { Name = "Meters", LanguageCode = "en" } } };
		    yield return new UnitOfMeasure { MeasureType = MeasureType.Dimension, Abbreviation = "pi", Localizations = new List<UnitOfMeasureLocalization> { new UnitOfMeasureLocalization { Name = "Pieds", LanguageCode = "fr" }, new UnitOfMeasureLocalization { Name = "Feet", LanguageCode = "en" } } };

		    yield return new UnitOfMeasure { MeasureType = MeasureType.Capacity, Abbreviation = "m3", Localizations = new List<UnitOfMeasureLocalization> { new UnitOfMeasureLocalization { Name = "Mètres cubes", LanguageCode = "fr" }, new UnitOfMeasureLocalization { Name = "Cubic meters", LanguageCode = "en" } } };
		    yield return new UnitOfMeasure { MeasureType = MeasureType.Capacity, Abbreviation = "po3", Localizations = new List<UnitOfMeasureLocalization> { new UnitOfMeasureLocalization { Name = "Pouces cubes", LanguageCode = "fr" }, new UnitOfMeasureLocalization { Name = "Cubic inches", LanguageCode = "en" } } };
		    yield return new UnitOfMeasure { MeasureType = MeasureType.Capacity, Abbreviation = "ml", Localizations = new List<UnitOfMeasureLocalization> { new UnitOfMeasureLocalization { Name = "Millilitres", LanguageCode = "fr" }, new UnitOfMeasureLocalization { Name = "Millilitre", LanguageCode = "en" } } };
		    yield return new UnitOfMeasure { MeasureType = MeasureType.Capacity, Abbreviation = "pt", Localizations = new List<UnitOfMeasureLocalization> { new UnitOfMeasureLocalization { Name = "Pintes", LanguageCode = "fr" }, new UnitOfMeasureLocalization { Name = "Pints", LanguageCode = "en" } } };
		    yield return new UnitOfMeasure { MeasureType = MeasureType.Capacity, Abbreviation = "t", Localizations = new List<UnitOfMeasureLocalization> { new UnitOfMeasureLocalization { Name = "Tonnes", LanguageCode = "fr" }, new UnitOfMeasureLocalization { Name = "Tons", LanguageCode = "en" } } };
		    yield return new UnitOfMeasure { MeasureType = MeasureType.Capacity, Abbreviation = "sh tn", Localizations = new List<UnitOfMeasureLocalization> { new UnitOfMeasureLocalization { Name = "Tonnes US", LanguageCode = "fr" }, new UnitOfMeasureLocalization { Name = "US tons", LanguageCode = "en" } } };
		    yield return new UnitOfMeasure { MeasureType = MeasureType.Capacity, Abbreviation = "pi3", Localizations = new List<UnitOfMeasureLocalization> { new UnitOfMeasureLocalization { Name = "Pieds cubes", LanguageCode = "fr" }, new UnitOfMeasureLocalization { Name = "Cubic feet", LanguageCode = "en" } } };
		    yield return new UnitOfMeasure { MeasureType = MeasureType.Capacity, Abbreviation = "GI", Localizations = new List<UnitOfMeasureLocalization> { new UnitOfMeasureLocalization { Name = "Gallons impériaux", LanguageCode = "fr" }, new UnitOfMeasureLocalization { Name = "Imperial gallons", LanguageCode = "en" } } };
		    yield return new UnitOfMeasure { MeasureType = MeasureType.Capacity, Abbreviation = "", Localizations = new List<UnitOfMeasureLocalization> { new UnitOfMeasureLocalization { Name = "Aucune", LanguageCode = "fr" }, new UnitOfMeasureLocalization { Name = "None", LanguageCode = "en" } } };
		    yield return new UnitOfMeasure { MeasureType = MeasureType.Capacity, Abbreviation = "G", Localizations = new List<UnitOfMeasureLocalization> { new UnitOfMeasureLocalization { Name = "Gallons US", LanguageCode = "fr" }, new UnitOfMeasureLocalization { Name = "US gallons", LanguageCode = "en" } } };
		    yield return new UnitOfMeasure { MeasureType = MeasureType.Capacity, Abbreviation = "g", Localizations = new List<UnitOfMeasureLocalization> { new UnitOfMeasureLocalization { Name = "Grammes", LanguageCode = "fr" }, new UnitOfMeasureLocalization { Name = "Grams", LanguageCode = "en" } } };
		    yield return new UnitOfMeasure { MeasureType = MeasureType.Capacity, Abbreviation = "Kg", Localizations = new List<UnitOfMeasureLocalization> { new UnitOfMeasureLocalization { Name = "Kilos", LanguageCode = "fr" }, new UnitOfMeasureLocalization { Name = "Kilos", LanguageCode = "en" } } };
		    yield return new UnitOfMeasure { MeasureType = MeasureType.Capacity, Abbreviation = "L", Localizations = new List<UnitOfMeasureLocalization> { new UnitOfMeasureLocalization { Name = "Litres", LanguageCode = "fr" }, new UnitOfMeasureLocalization { Name = "Litres", LanguageCode = "en" } } };
		    yield return new UnitOfMeasure { MeasureType = MeasureType.Capacity, Abbreviation = "lb", Localizations = new List<UnitOfMeasureLocalization> { new UnitOfMeasureLocalization { Name = "Livres", LanguageCode = "fr" }, new UnitOfMeasureLocalization { Name = "Pounds", LanguageCode = "en" } } };
		    yield return new UnitOfMeasure { MeasureType = MeasureType.Capacity, Abbreviation = "oz", Localizations = new List<UnitOfMeasureLocalization> { new UnitOfMeasureLocalization { Name = "Onces", LanguageCode = "fr" }, new UnitOfMeasureLocalization { Name = "Onces", LanguageCode = "en" } } };
		}
    }
}
