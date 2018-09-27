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
		private static readonly Guid IdUser = Guid.Parse("0540e8f7-dc44-4b2f-8e42-5004cca3700b");

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
			SeedInitialDataForMeasuringUnit(builder);
			builder.Entity<LaneGenericCode>().HasData(InitialLaneGenericCodesGenerator.GetInitialData().ToArray());
			builder.Entity<LanePublicCode>().HasData(InitialLanePublicCodesGenerator.GetInitialData().ToArray());

			InitialUserGenerator.SeedInitialData(builder, IdUser);
			InitialPermissionGenerator.SeedInitialData(builder, IdUser);
			InitialRiskLevelGenerator.SeedInitialData(builder);	
		}

		public static void SeedInitialDataForDevelopment(this ModelBuilder builder)
		{
			/*InitialDataForCauca.SeedInitialGeographicData(builder);
			InitialDataForCauca.SeedInitialCityTypes(builder);*/
		}

		private static void SeedInitialFireResistanceType(ModelBuilder builder)
		{
			SeedFireResistanceType(builder, "Ordinaire", "Regular", "37b22728-8de2-4f85-ad21-4fa7ba95aaa2", "df258851-5140-429a-b022-e29301f10844", "57df3d48-2755-44da-8e9c-0b4df88c344f");
			SeedFireResistanceType(builder, "Combustible", "Flammable", "1bf7bd80-a821-49b7-95c2-c1683ae4d97d", "d61fa446-ad4d-48b7-a755-0da80a93b5a3", "8a321a84-d5da-4542-bd41-8d603f68a7d0");
			SeedFireResistanceType(builder, "Incombustible", "Nonflammable", "08271a20-bd18-445e-8ba5-ec89bfd3f042", "5e51e28e-025d-48b2-a3c6-3b10c8ac9883", "6cc720c2-67ab-4e77-9159-1c2faee12c67");
			SeedFireResistanceType(builder, "Résistante au feu", "Fire resistant", "e4f66e0d-87d5-47f8-a825-e5ea38819d20", "42bdb80b-2909-49fc-8509-739c4f4b1abb", "8a9cd98f-0bd4-417c-9c5b-e936f610a20e");
			SeedFireResistanceType(builder, "Hybride", "Hybrid", "b6d79902-1622-47b2-b44c-391fa2dd35f1", "eeb2abcf-1af5-4561-81a4-d233b77c8ad0", "3236e848-4139-4484-930a-bf83006228b0");
		}

		private static void SeedFireResistanceType(ModelBuilder builder, string french, string english, string id, string idFr, string idEn)
		{
			var type = new ConstructionFireResistanceType {Id = Guid.Parse(id), CreatedOn = Now};
			var frenchLocalization = new ConstructionFireResistanceTypeLocalization {Id = Guid.Parse(idFr), LanguageCode = "fr", Name = french, IdParent = type.Id, CreatedOn = Now};
			var englishLocalization = new ConstructionFireResistanceTypeLocalization {Id = Guid.Parse(idEn), LanguageCode = "en", Name = english, IdParent = type.Id, CreatedOn = Now};
			builder.Entity<ConstructionFireResistanceType>().HasData(type);
			builder.Entity<ConstructionFireResistanceTypeLocalization>().HasData(frenchLocalization, englishLocalization);
		}

		private static void SeedInitialConstructionType(ModelBuilder builder)
		{
			SeedConstructionType(builder, "Ossature de bois avec solives préfabriquées", "Wood frame and prefabricated joists", "af8b5c51-d1c8-4b20-b5ce-dd54c24581e5", "6831736c-8c66-44a9-a3dc-93bbaea0f455", "ea131d1c-633e-4a19-9881-6ac0554d8d5e");
			SeedConstructionType(builder, "Gros bois d'oeuvre", "Lumber", "6e706db7-c12c-4d8f-8e9a-556822193d48", "d4b4ed94-b8fd-4bce-9338-016cd8642610", "be8ac495-3fd3-49bd-8fbc-ce75f5ced1bd");
			SeedConstructionType(builder, "Mur porteur en maçonnerie avec mur solives en bois solides", "Masonry bearing wall and solid wood joists", "1c727c63-2579-4035-baac-39df4c09bbe8", "cd7504b2-a0e1-4507-b842-1a8696a3a4fb", "ec4f297d-4e7c-46a7-a694-6ceb89a7d6f9");
			SeedConstructionType(builder, "Mur porteur en maçonnerie et solives préfabriquées", "Masonry bearing wall and prefabricated joists", "025f20b1-9a98-482a-8e11-a2daae3d08f2", "1ae424b2-3bf3-4970-8842-eaa5cb4f2da8", "0b954872-07d1-4263-82fb-00bf04d68f7b");
			SeedConstructionType(builder, "Mur porteur en maçonnerie et solives en aciers ou dalle de béton", "Masonry bearing wall and steel joists or concrete slab", "121e0751-ea21-4746-808c-6f09a45bd687", "e3cac5a9-2bc0-4577-adfe-38754fc726a1", "c5394200-4ea1-4c1b-9e66-054e2a306a56");
			SeedConstructionType(builder, "Acier avec solives en acier protégées", "Steel with protected steel joists", "088798b8-31ef-4644-a735-1091a28d0e75", "774c53de-df84-49bd-90d5-bfccadad6cb2", "4ef8b821-3631-40bf-aa05-311e55f9f246");
			SeedConstructionType(builder, "Acier avec solives en acier non protégées", "Steel with unprotected steel joists", "80994dae-01a0-4701-be45-7271abe7364f", "9629f2b5-8e41-46d2-ada8-1eae746232a5", "71413cfa-9383-4347-8ca5-d736a03c061b");
			SeedConstructionType(builder, "Béton", "Concrete", "723839fb-0d7f-4f5f-b1c4-dde687ddf416", "aaf71bb3-7313-4e22-9955-cf5a22040e01", "c911cf12-2ef0-481c-a904-0814796e29d8");
			SeedConstructionType(builder, "Autre type", "Other", "2543bae8-9f96-4fb9-81d7-fd78fcabec5c", "bb1f1be0-c570-4cb1-a4ed-fd2dc20f4c4b", "5cf5ce19-e6aa-4a79-8101-6d61f60271f1");
			SeedConstructionType(builder, "Indéterminé", "Undetermined", "87ad142b-119a-4757-9b4c-4281469b3810", "ca867ce0-9331-406c-9587-df12dd551372", "82ecd48c-ba4d-4bbc-b254-f4b83a12bf28");
		}

		private static void SeedConstructionType(ModelBuilder builder, string french, string english, string id, string idFr, string idEn)
		{
			var type = new ConstructionType { Id = Guid.Parse(id), CreatedOn = Now };
			var frenchLocalization = new ConstructionTypeLocalization { Id = Guid.Parse(idFr), LanguageCode = "fr", Name = french, IdParent = type.Id, CreatedOn = Now };
			var englishLocalization = new ConstructionTypeLocalization {Id = Guid.Parse(idEn), LanguageCode = "en", Name = english, IdParent = type.Id, CreatedOn = Now };
			builder.Entity<ConstructionType>().HasData(type);
			builder.Entity<ConstructionTypeLocalization>().HasData(frenchLocalization, englishLocalization);
		}

		private static void SeedInitialBuildingType(ModelBuilder builder)
		{
			SeedBuildingType(builder, "Attaché", "Attached", "7f64d446-ee04-4be4-8884-d478b2205015", "98af843d-a6b4-45c6-8c06-bd2ecd10bbf7", "fe1e2e0d-cf3e-440e-af40-3c4aa89ca476");
			SeedBuildingType(builder, "Détaché", "Detached", "56c0186b-9c3f-4f9a-9b31-526505eb2f27", "55bbce33-b0ba-4ff1-9072-9c6f36e60a5a", "5cbaa810-c9eb-432f-9562-285d69a1daea");
			SeedBuildingType(builder, "Jumelé", "Semi-detached", "2a6ce3e4-41a4-4279-81d7-2302273932e9", "b7592a40-405b-4d2b-b5bf-ee6ea095c97f", "ade71aa8-8104-4f0b-8b70-b09afd1c0149");
			SeedBuildingType(builder, "Autre", "Other", "3f39af62-ab3f-4792-a83a-42e1a33bc4e6", "a3495dbe-238f-43c5-95ab-f6e7e1182b85", "cb0461e3-bff7-4f67-b7af-aac02de5bc22");
		}

		private static void SeedBuildingType(ModelBuilder builder, string french, string english, string id, string idFr, string idEn)
		{
			var type = new BuildingType { Id = Guid.Parse(id), CreatedOn = Now };
			var frenchLocalization = new BuildingTypeLocalization { Id = Guid.Parse(idFr), LanguageCode = "fr", Name = french, IdParent = type.Id, CreatedOn = Now };
			var englishLocalization = new BuildingTypeLocalization {Id = Guid.Parse(idEn), LanguageCode = "en", Name = english, IdParent = type.Id, CreatedOn = Now };
			builder.Entity<BuildingType>().HasData(type);
			builder.Entity<BuildingTypeLocalization>().HasData(frenchLocalization, englishLocalization);
		}

		private static void SeedInitialRoofType(ModelBuilder builder)
		{
			SeedRoofType(builder, "1 versant", "1 slope", "0e23640f-2a4b-4b37-9a93-dc694c3f228d", "9c28bc1d-3b65-4c0a-a6f7-3cca6d344faa", "4f1fe925-5653-4fc9-ac72-04126e9dbe2e");
			SeedRoofType(builder, "2 versants", "2 slopes", "4801d403-5564-4ac3-91e6-4c679c44f085", "db57ba45-7d1b-4812-b0f9-0b6e45e5ba49", "f98bab94-e1a9-45bb-b7b9-6ea8e7128c0d");
			SeedRoofType(builder, "4 versants", "3 slopes", "d0b106f0-0751-4a96-b2c6-c16ecf9ba2bc", "72dca069-e359-4d89-8536-9f6979a58952", "95101771-4d13-4401-8958-1684ca89da39");
			SeedRoofType(builder, "Cône français", "French cone", "a8964d13-7910-433d-9513-88995ccf0820", "d191edd8-376d-40bd-8004-dc1f8f098227", "28e8fde4-3771-4ae6-9b3b-b158ba1d474e");
			SeedRoofType(builder, "Diamant", "Diamond", "b3f36659-bb7e-4553-8d4e-6a7abd9fb697", "dea17fbe-4c98-4a16-90f9-b157f7c17866", "bf01d730-5489-41d3-9210-6b7ea13faf1d");
			SeedRoofType(builder, "Dôme", "Dome", "773de910-a94a-41cb-9f17-38e69d788700", "4f246487-3254-413c-a737-936cdf3ea5de", "30bb690c-a146-45c8-83a4-9f2185c5a611");
			SeedRoofType(builder, "Mansarde", "Mansard", "5e5509fd-e91b-4e0a-8e84-e2bf3027f949", "244e1b8b-e08b-4260-884c-73eb37095e94", "a903ba9e-6a42-4d8c-91d5-99c4c40af03e");
			SeedRoofType(builder, "Pente", "Slope", "75802958-7ee5-4fe3-b7f7-59edc5a3b712", "037d2be4-0a50-4a6f-827e-00e4a58cae47", "b448162f-2840-4de2-999a-f75abcfb239d");
			SeedRoofType(builder, "Plat", "Flat", "5cc36bd7-fe6a-47d9-a490-2d4560505445", "140d3f25-1819-43fe-8a0d-28b65aa55630", "519e1c86-c15e-4ad3-a5ca-5cdd8c462dcb");
		}

		private static void SeedRoofType(ModelBuilder builder, string french, string english, string id, string idFr, string idEn)
		{
			var type = new RoofType { Id = Guid.Parse(id), CreatedOn = Now };
			var frenchLocalization = new RoofTypeLocalization { Id = Guid.Parse(idFr), LanguageCode = "fr", Name = french, IdParent = type.Id, CreatedOn = Now };
			var englishLocalization = new RoofTypeLocalization {Id = Guid.Parse(idEn), LanguageCode = "en", Name = english, IdParent = type.Id, CreatedOn = Now };
			builder.Entity<RoofType>().HasData(type);
			builder.Entity<RoofTypeLocalization>().HasData(frenchLocalization, englishLocalization);
		}

		private static void SeedInitialRoofMaterialType(ModelBuilder builder)
		{
			SeedRoofMaterialType(builder, "Bardeaux d'asphalte", "Asphalt shingles", "a5c7abf1-1b2a-4296-b2c4-c035df4c9a5b", "5febbedc-c0cb-4f41-83ed-49db713383f2", "658df9f3-024c-48f1-be6a-b33d13098f35");
			SeedRoofMaterialType(builder, "Tôle", "Sheet metal", "d88e6309-f67a-43f6-a961-bdf56f928cbc", "0c122e8e-1ec5-4741-ab72-346bfb39def6", "9e59695c-7227-472d-9b43-86324206ac13");
			SeedRoofMaterialType(builder, "Tapis de goudron", "Tar mat", "acb67374-bb4e-4a27-82ef-2b83db82e7c1", "402c2c4e-0478-477a-88fd-adc40ada03b9", "b5831b33-8eef-413c-ad95-625a3ce56f0e");
			SeedRoofMaterialType(builder, "Puit de lumière", "Skylight", "be830279-4687-4e1f-bd97-23a3f879ffb8", "87a68248-9828-4ccc-8fe9-60a4cfa7efeb", "f3aa5521-568d-41c7-8710-bde6cec6c61f");
			SeedRoofMaterialType(builder, "Bois", "Wood", "d61be0bd-fff0-422a-909e-2ba5d92757eb", "c45526dc-6d5f-4473-b4cb-8506ed7d48fe", "c8218002-6904-4033-8e39-2ebabf700840");
		}

		private static void SeedRoofMaterialType(ModelBuilder builder, string french, string english, string id, string idFr, string idEn)
		{
			var type = new RoofMaterialType {Id = Guid.Parse(id), CreatedOn = Now};
			var frenchLocalization = new RoofMaterialTypeLocalization { Id = Guid.Parse(idFr), LanguageCode = "fr", Name = french, IdParent = type.Id, CreatedOn = Now};
			var englishLocalization = new RoofMaterialTypeLocalization {Id = Guid.Parse(idEn), LanguageCode = "en", Name = english, IdParent = type.Id, CreatedOn = Now};
			builder.Entity<RoofMaterialType>().HasData(type);
			builder.Entity<RoofMaterialTypeLocalization>().HasData(frenchLocalization, englishLocalization);
		}

		private static void SeedInitialSidingType(ModelBuilder builder)
		{					
			SeedSidingType(builder,"Brique", "Brick", "3ee73750-2034-4bcb-84e2-52c87b7cf47c", "cafe52e4-271c-4281-b647-9afb47308e2f", "770fba5e-75e5-4ea1-b313-15cb1d31db16");
			SeedSidingType(builder,"Béton", "Concrete", "9a2fdec1-5e2d-4868-958f-747ec719a888", "9b5fb7d1-bade-41ba-8d5a-1fa541272636", "8c9d3d7f-1d2e-48b4-8b26-bd9c495f5cd4");
			SeedSidingType(builder,"Vinyle", "Vinyl", "aa3aabab-e510-4df1-86d7-cadb7e9b8a54", "e4023573-08d9-47a3-b35c-7bbdad0016f0", "026b6b9c-1a96-4f61-9e74-2771b520c265");
			SeedSidingType(builder,"Bois", "Wood", "78397b1c-f2bf-4bc2-b05e-2206a1249503", "f3e9c9b1-0a50-4ce3-b764-597e69c731db", "b0440e97-3d82-4e23-b003-4f89f0242cb4");
			SeedSidingType(builder,"Canexel", "Canexel", "5258d5e9-846a-4f33-9246-49aa25ce4fe3", "1376d1eb-6221-408d-ad45-430347935312", "9b4402f8-656e-4c4d-9f36-4ea1f644d02b");
			SeedSidingType(builder,"Pierre", "Stone", "d951897a-949f-4b80-9208-1b3b340c82c6", "6698affd-3310-44e9-ad5f-94c5a187bc95", "98f8304c-468e-44a6-a44f-ab24508292c0");
			SeedSidingType(builder,"Stucco", "Stucco", "947c3969-430b-4ee3-9453-b24ca1a35a9c", "7f0a6e34-f5ee-427b-8935-71e6c87f068a", "8f00d828-3db9-4296-aa38-ad8bf6b8ccfa");
			SeedSidingType(builder,"Tôle", "Sheet metal", "d0079e8f-b0d1-4fe8-ac69-84087a4ea42c", "5da4c4ed-850e-482a-9222-33c18bdf27ae", "8d505447-4146-4a26-bf1e-6733f3c1b05e");
			SeedSidingType(builder,"Bardeaux de cèdre", "Cedar shingles", "174ed7a6-c79c-4aa5-ab87-6f7ceabcbd32", "a3972b78-6039-43ce-a285-9975faaa4361", "fa2717e9-4890-4310-ac0b-e1fedcd86d28");
			SeedSidingType(builder,"Masonite", "Masonite", "e58e7209-e151-49f1-b241-775401036425", "e0beebfd-ad61-4e87-a5ed-d407cccb198a", "c2e68a37-0e20-4fa8-86b9-f5b7774e5b18");
		}

		private static void SeedSidingType(ModelBuilder builder, string french, string english, string id, string idFr, string idEn)
		{
			var type = new SidingType { Id = Guid.Parse(id), CreatedOn = Now };
			var frenchLocalization = new SidingTypeLocalization { Id = Guid.Parse(idFr), LanguageCode = "fr", Name = french, IdParent = type.Id, CreatedOn = Now };
			var englishLocalization = new SidingTypeLocalization {Id = Guid.Parse(idEn), LanguageCode = "en", Name = english, IdParent = type.Id, CreatedOn = Now };
			builder.Entity<SidingType>().HasData(type);
			builder.Entity<SidingTypeLocalization>().HasData(frenchLocalization, englishLocalization);
		}

		private static void SeedInitialSprinklerType(ModelBuilder builder)
		{
			SeedSprinklerType(builder, "Système sous eau", "Wet pipe", "758e5835-deeb-4167-8732-be9d2c338968", "b260a409-897b-4007-af26-9ed430f59138", "ee1b31da-1539-40ef-92e7-aa1d69075dc5");
			SeedSprinklerType(builder, "Système sous air", "Dry pipe", "90a001d9-1348-47cd-b44e-ac2a0484cd57", "faf15cd3-ce59-4aa5-aff1-982900aa96c5", "7ea70243-8935-40d4-b843-a82cc6b10be1");
			SeedSprinklerType(builder, "Pré action", "Pre-Action", "2cdd734c-0ffe-4c39-b874-59f1743db693", "a5c30a93-8ff4-4778-9be3-3c1e522e35c1", "3763b5b8-8f8a-404d-9323-43c809d99975");
			SeedSprinklerType(builder, "Déluge", "Deluge", "f745efd4-3851-4440-9502-15eb1fcf4b40", "51412199-75c8-4a31-bb9b-17bd0251b296", "8f170e4b-8ea1-4943-9da7-5b7dd64af268");
			SeedSprinklerType(builder, "Mousse", "Foam", "0f0da61b-8bbd-4f79-927a-e2a98a87ca3d", "e8ed792d-aa4f-48f4-bfe8-ac0079abad26", "d13f78bb-c98c-4778-84a3-675e2decd875");
			SeedSprinklerType(builder, "FM 200", "FM 200", "2bcb05e1-5788-4beb-8395-07ec55c2ed60", "536b74f4-21ca-46d5-a9dd-aa38c7f6ad98", "704c4f7e-c3ea-473f-b9b7-6237e9e85342");
		}

		private static void SeedSprinklerType(ModelBuilder builder, string french, string english, string id, string idFr, string idEn)
		{
			var type = new SprinklerType { Id = Guid.Parse(id), CreatedOn = Now };
			var frenchLocalization = new SprinklerTypeLocalization { Id = Guid.Parse(idFr), LanguageCode = "fr", Name = french, IdParent = type.Id, CreatedOn = Now };
			var englishLocalization = new SprinklerTypeLocalization {Id = Guid.Parse(idEn), LanguageCode = "en", Name = english, IdParent = type.Id, CreatedOn = Now };
			builder.Entity<SprinklerType>().HasData(type);
			builder.Entity<SprinklerTypeLocalization>().HasData(frenchLocalization, englishLocalization);
		}

		private static void SeedInitialAlarmPanelType(ModelBuilder builder)
		{
			SeedAlarmPanelType(builder, "Intrusion","Intrusion", "9eaab857-ee8d-456f-aa4c-db54577a78be", "eaa9876f-c242-4288-a88c-856e5cb20229", "3242a0d5-8206-4cec-891f-5540e59f8164");
			SeedAlarmPanelType(builder, "Non zoné", "Not zoned", "5b79c12a-8bb2-4f2e-99e5-148cabd3e01b", "b8e11d29-8ba4-4525-8037-0469931417c1", "da11be29-00f5-4877-83d0-da8ca2bd7186");
			SeedAlarmPanelType(builder, "Zoné", "Zoned", "e2624494-61a9-43e8-8c80-7b951ccf890b", "d536c44b-671d-45be-b065-2cf47efa4dde", "3583c264-0d3a-4022-bb6f-2d8760ec91a6");
			SeedAlarmPanelType(builder, "Adressable", "Adressable", "8df88764-3d85-4c3f-8d0c-bedeca587660", "f6bf1b90-9901-4378-a9b2-e453cd6236ae", "c25b9219-849d-4f9d-8f89-c27b9af975ce");
		}

		private static void SeedAlarmPanelType(ModelBuilder builder, string french, string english, string id, string idFr, string idEn)
		{
			var type = new AlarmPanelType { Id = Guid.Parse(id), CreatedOn = Now };
			var frenchLocalization = new AlarmPanelTypeLocalization { Id = Guid.Parse(idFr), LanguageCode = "fr", Name = french, IdParent = type.Id, CreatedOn = Now };
			var englishLocalization = new AlarmPanelTypeLocalization {Id = Guid.Parse(idEn), LanguageCode = "en", Name = english, IdParent = type.Id, CreatedOn = Now };
			builder.Entity<AlarmPanelType>().HasData(type);
			builder.Entity<AlarmPanelTypeLocalization>().HasData(frenchLocalization, englishLocalization);
		}

		private static void SeedInitialPersonRequiringAssistanceType(ModelBuilder builder)
		{
			SeedPersonRequiringAssistanceType(builder, "Camp/Terrain de jeu", "Camp/playground", "895aa8c5-f5fa-4d71-90c9-0f9b48e818f8", "03827c16-2907-4b31-9235-dc0aa41ddc77", "8ee314bb-fab1-496f-805b-2647bfae85b4");
			SeedPersonRequiringAssistanceType(builder,"Personnes handicapées", "Handicapped person", "ec2d9d88-79ac-41ab-8b5c-caac90db4b28", "819db690-b8ad-4bca-9c24-f5908acf87b3", "506d6909-cdfa-4417-882b-c37a42fb0177");
			SeedPersonRequiringAssistanceType(builder,"Trouble vision", "Visually impaired", "fec9e14d-e357-40ba-97d8-fcbfe2c6642c", "38152889-a72a-4673-acc1-35165c23d8d8", "fe739214-f81d-4e12-916e-e2d0aef6e1d8");
			SeedPersonRequiringAssistanceType(builder,"Surdité", "Deafness", "5c2b2097-8e67-4fe5-be33-9adea39fb90a", "d26d0cda-68ce-49c3-9eb2-696d1e02916c", "729d73fa-a8ac-4412-9667-268e633c4eef");
			SeedPersonRequiringAssistanceType(builder,"Cognitif", "Cognitive", "9a056318-cb54-4240-8637-0b38cfcaf9f3", "56c81cd9-d07c-4986-a475-a5814e88c7d2", "fa9bcff7-9e18-4c0e-8f69-a936b754bbb0");
			SeedPersonRequiringAssistanceType(builder,"Autre", "Other", "1bbd7cc9-49ae-490f-a175-ca253d12c21e", "c143742a-e9a1-4f0d-b095-108d12da184a", "f6a9e651-52a7-4a7e-ab95-f4c6ebfa568f");
			SeedPersonRequiringAssistanceType(builder,"Centre médical", "Medical center", "b76531bc-460c-4ff8-889c-9504e6003e20", "1d7914fa-cd6b-4ee6-9bd8-372d4e755f16", "8b6acc43-00f6-41f2-93d4-9dd8ddc7095b");
			SeedPersonRequiringAssistanceType(builder,"Déficients intellectuels", "Intellectual deficient", "aaf8e4ca-c2d8-4b68-acb5-bc43bf059b6d", "00cd08c2-00b4-4e1f-9c1d-8927db5bedb4", "b3c6ef63-b480-4143-9b80-bbda483cf3ce");
			SeedPersonRequiringAssistanceType(builder,"École", "School", "3dc24fa2-e091-487f-8d0b-7d0932edcbbe", "d4d6aab8-aa99-41e3-b2fd-dd887fb96737", "2049151a-43a0-483e-89c7-7ccc62991f9d");
			SeedPersonRequiringAssistanceType(builder,"Garderie", "Nursery", "3ed291a4-39fb-4625-93e5-1e0efd76bdea", "68a9742b-48c9-43b0-9a92-89cda72bbb6f", "352b62b5-0f59-4e87-967d-12d1b17be2b4");
			SeedPersonRequiringAssistanceType(builder,"Malentendants", "Hard of hearing", "e54c9200-d7c1-4fbf-a08a-833f491e9e50", "7a897396-f98b-4290-b620-580182a283b8", "e3ed7e5a-ff65-4f47-b032-b86fa783e4b6");
			SeedPersonRequiringAssistanceType(builder,"Mobilité réduite", "Reduced mobility", "7efe2297-c9ca-473f-b48e-3430e6778272", "f69c1037-d381-4524-a6ae-e05f5624b832", "7b4c01fe-ba09-4db4-90f9-9de61c32f179");
			SeedPersonRequiringAssistanceType(builder,"Non-voyants", "Blind", "016af358-f9ac-4f72-becc-2b486bb6646b", "831609a5-c7b6-4c3f-80e9-e19448db0eda", "99c58d75-2700-41f4-8d1b-e90bd6f7c4d5");
			SeedPersonRequiringAssistanceType(builder,"Personnes agées", "Elderly", "078ebd48-9843-43cf-b9fd-cb262b7540df", "2b25c4c1-b5fd-4db2-8d91-fec3b6b5180d", "ba10c7cc-ed99-4df8-a0f5-c4d0d14e56cb");
		}

		private static void SeedPersonRequiringAssistanceType(ModelBuilder builder, string french, string english, string id, string idFr, string idEn)
		{
			var type = new PersonRequiringAssistanceType { Id = Guid.Parse(id), CreatedOn = Now };
			var frenchLocalization = new PersonRequiringAssistanceTypeLocalization { Id = Guid.Parse(idFr), LanguageCode = "fr", Name = french, IdParent = type.Id, CreatedOn = Now };
			var englishLocalization = new PersonRequiringAssistanceTypeLocalization {Id = Guid.Parse(idEn), LanguageCode = "en", Name = english, IdParent = type.Id, CreatedOn = Now };
			builder.Entity<PersonRequiringAssistanceType>().HasData(type);
			builder.Entity<PersonRequiringAssistanceTypeLocalization>().HasData(frenchLocalization, englishLocalization);
		}

		private static void SeedInitialFireHydrantConnectionType(ModelBuilder builder)
		{
			SeedFireHydrantConnectionType(builder, "Fileté", "Threaded", "7358ab2d-d6f2-4d0f-af9a-a2146e0c46b1", "73022941-bcff-4319-96e0-ecd904bfc2b4", "c802d0b9-a5ef-4005-a6fd-97faf994abaa");
			SeedFireHydrantConnectionType(builder, "Storz", "Storz", "0fc2d8b3-5485-48eb-9573-0ad7d9ca2edb", "63c49005-623d-4ff3-80d8-ae5c6b3d3e0f", "bc883ad5-cfde-482c-b05b-3802ee873643");
		}

		private static void SeedFireHydrantConnectionType(ModelBuilder builder, string french, string english, string id, string idFr, string idEn)
		{
			var type = new FireHydrantConnectionType { Id = Guid.Parse(id), CreatedOn = Now };
			var frenchLocalization = new FireHydrantConnectionTypeLocalization { Id = Guid.Parse(idFr), LanguageCode = "fr", Name = french, IdParent = type.Id, CreatedOn = Now };
			var englishLocalization = new FireHydrantConnectionTypeLocalization {Id = Guid.Parse(idEn), LanguageCode = "en", Name = english, IdParent = type.Id, CreatedOn = Now };
			builder.Entity<FireHydrantConnectionType>().HasData(type);
			builder.Entity<FireHydrantConnectionTypeLocalization>().HasData(frenchLocalization, englishLocalization);
		}

		private static void SeedInitialFireHydrantType(ModelBuilder builder)
		{
			SeedFireHydrantType(builder, "Sèche", "Dry", "353badcc-5530-403e-8f9a-71b4ff7969d6", "6c739381-2fe8-4bf8-b95b-a7b99131947e", "4b05ea0b-b20a-4232-aedd-e39c8c94771f");
			SeedFireHydrantType(builder, "Fontaine", "Fountain", "5f2fbabf-a5d1-4471-a093-2e8614690044", "99f5c70f-bec8-473c-b3a7-8f7229a09aae", "7342589c-297d-44a2-a592-06d9d3e8cf4e");
			SeedFireHydrantType(builder, "Citerne", "Tank", "5148b24f-1c77-470f-a32f-34b63f191e5d", "f0e5c2a6-36fd-4f12-8698-3c3cd80179f5", "c81b0038-41f6-45ec-8f6f-4ed1a58d9fe0");
			SeedFireHydrantType(builder, "Borne fontaine", "Fire hydrant", "694f3f50-3476-4f4c-895b-7a14ff52e7d9", "a7b90d2c-6b37-4d1e-b580-591fe4f8eaeb", "35d759eb-abe8-400b-bd28-ea1c4ad9c705");
			SeedFireHydrantType(builder, "Point d'eau", "Water point", "3e021bff-d493-4e8c-be32-a62a7ad91f95", "fbf3a7d8-c9ff-4bad-b225-f2e260befdb4", "2998c6ff-c26e-4908-a4a0-60f1be244585");
			SeedFireHydrantType(builder, "Borne sèche", "Dry fire hydrant", "7fc0daf9-6b33-4928-92a6-353986acd40e", "fcb0c181-f9de-46b3-a480-66158de4ceee", "38146953-dc9f-4929-bbf9-6dd48eca2292");
			SeedFireHydrantType(builder, "Statique", "Static", "29f3c611-db28-4500-8d27-944527e006c1", "75539adb-c971-4901-b251-c3a75145bed2", "bcef3322-18a7-4768-9878-1bd183a5a0bf");
		}

		private static void SeedFireHydrantType(ModelBuilder builder, string french, string english, string id, string idFr, string idEn)
		{
			var type = new FireHydrantType { Id = Guid.Parse(id), CreatedOn = Now };
			var frenchLocalization = new FireHydrantTypeLocalization { Id = Guid.Parse(idFr), LanguageCode = "fr", Name = french, IdParent = type.Id, CreatedOn = Now };
			var englishLocalization = new FireHydrantTypeLocalization {Id = Guid.Parse(idEn), LanguageCode = "en", Name = english, IdParent = type.Id, CreatedOn = Now };
			builder.Entity<FireHydrantType>().HasData(type);
			builder.Entity<FireHydrantTypeLocalization>().HasData(frenchLocalization, englishLocalization);
		}

		private static void SeedInitialDataForMeasuringUnit(ModelBuilder builder)
		{
			SeedUnitOfMeasure(builder, MeasureType.Rate, "GIPM", "GIPM", "GIPM", "f4f46acc-3aa5-4a77-9a75-25d66c23a917", "a5adc39c-87db-47ba-b9f3-b7ca57b1cc64", "e62794be-4dd3-47e2-a24c-57daadc8e798");
			SeedUnitOfMeasure(builder, MeasureType.Rate, "GPM", "GPM", "GPM", "96801d59-e01e-4219-a918-0a570a174b74", "58e46d9b-2c54-4f6f-bc85-e82002cd28e5", "c25b755f-1a2e-40c8-8d72-8412d3e91fec");
			SeedUnitOfMeasure(builder, MeasureType.Rate, "LPM", "LPM", "LPM", "14ea0d1c-a434-47d1-ba17-57967e79b4c9", "d4e10a5f-a2d1-4e00-aeec-11e33576f13a", "9238cdd2-dd75-4f64-b2c0-063a3df56f25");
			SeedUnitOfMeasure(builder, MeasureType.Rate, "GI", "GI", "GI", "845d7bb3-6554-441d-bf41-6ec003598f20", "ff23e766-ab8a-4019-a4da-9e5dcda63bb8", "7ddf2111-9497-49fa-a57e-ddcb776858cb");
			SeedUnitOfMeasure(builder, MeasureType.Rate, "G", "G", "G", "3ac84278-7606-4cb9-bc5a-9bdc3a8fb9d0", "0cd5110a-f0a7-4a46-b650-c028cc23731f", "0c771b77-b0ba-4a6a-890c-b83e9d89bad0");
			SeedUnitOfMeasure(builder, MeasureType.Rate, "L", "L", "L", "3015ac3e-43c5-4b74-9b3d-6f4cec3d1409", "c6aabfee-0d80-42f5-8157-a23afcf848fe", "e672cde8-4751-476a-85bd-63286429c26e");
			SeedUnitOfMeasure(builder, MeasureType.Rate, "", "Indéterminé", "Unknown", "a6b0949f-d056-4aa9-8281-d6f93941369a", "8d7c21db-320b-449d-a55a-781f97c26dd8", "1422ae64-85db-47cc-a647-20753f0fe420");

			SeedUnitOfMeasure(builder, MeasureType.Pressure, "PSI", "PSI", "PSI", "d5a9dd30-c345-496e-8669-ca9f09295878", "41150af7-9750-4808-ab4f-1b52e61a3ca9", "f9bb8fae-f8c3-4971-be25-7082804e016f");
			SeedUnitOfMeasure(builder, MeasureType.Pressure, "KPA", "KPA", "KPA", "2ee63245-6a57-4c01-8746-b10acc473b1a", "b3f79de8-8b91-4010-9151-2dc43ed94123", "3ff72c23-0049-43fe-8a5c-93affe13051d");
			SeedUnitOfMeasure(builder, MeasureType.Pressure, "m3/h", "m3/h", "m3/h", "5f45f2f3-cd97-4ba4-a17c-f191df34ee4a", "30376b32-e5a2-431e-b9ee-1cc74a15f49f", "f3fd4d74-85f4-425a-a0e2-98ae50025db7");

			SeedUnitOfMeasure(builder, MeasureType.Diameter, "mm", "Millimètres", "Millimeters", "32d7e795-31e6-4b07-9784-c2de1c63980d", "25a3a165-49c3-4a17-881a-aa650f1c27dc", "bd915193-bc2a-4821-9161-ed95f8c497ad");
			SeedUnitOfMeasure(builder, MeasureType.Diameter, "po", "Pouces", "Inches", "71feff9f-c32d-44e6-82a8-b86b82d64bb5", "44034780-45d9-4ec6-b77c-c94b199e945b", "2dad6387-b63f-4f64-ac17-96f168755a58");

			SeedUnitOfMeasure(builder, MeasureType.Dimension, "m", "Mètres", "Meters", "900edc6d-7658-46d6-a696-77b57e32a3c7", "8a152e9e-cceb-4ddc-b8ba-065ca99143a2", "c9cc27ce-653c-4846-8a7c-dad6d8e1761c");
			SeedUnitOfMeasure(builder, MeasureType.Dimension, "pi", "Pieds", "Feet", "ada51f7e-2aef-4879-99e2-cd11fe8ca93b", "6b257f96-5e76-4427-a648-53c7b7eaef93", "f5c1bc3c-9220-4a54-9b37-40823c988460");

			SeedUnitOfMeasure(builder, MeasureType.Capacity, "m3", "Mètres cubes", "Cubic meters", "a29dd195-53b0-4e5f-857d-6236f6faf588", "a9bc22e3-ae2e-4f37-b1a2-cbf7f9f57b29", "7679719f-a90d-4b5e-ab1e-7306b9a79412");
			SeedUnitOfMeasure(builder, MeasureType.Capacity, "po3", "Pouces cubes", "Cubic inches", "db98476e-04bf-4502-9a0a-6e4a14797915", "bb8866b5-5fc2-435a-a9ce-90975cf8cf64", "c5831049-3947-45b8-8410-760e4c057dfc");
			SeedUnitOfMeasure(builder, MeasureType.Capacity, "ml", "Millilitres", "Millilitre", "eb9d70c4-3b1b-4c84-99dd-684700e84484", "d32460bb-1ee8-4e91-b39c-7a235a1e15ed", "f24d5ff3-1be5-46b1-9263-a19781042fd5");
			SeedUnitOfMeasure(builder, MeasureType.Capacity, "pt", "Pintes", "Pints", "ef8f06ac-6718-489b-b833-eb0b24926812", "a2da656a-d18f-4ec2-a8ea-9e8d77be4e3e", "a6fae969-1e74-4843-b473-917b3090c710");
			SeedUnitOfMeasure(builder, MeasureType.Capacity, "t", "Tonnes", "Tons", "6414f1c7-73a7-434b-9217-caba747ec10e", "ac20811f-493a-4ed9-aa83-7dc114f7888d", "b0a5d1b1-d474-487e-8edc-e8375dd20117");
			SeedUnitOfMeasure(builder, MeasureType.Capacity, "sh tn", "Tonnes US", "US tons", "c1ca6d9b-0808-4add-a609-ed50ca8cd23c", "1d484b28-1cd4-4943-ad4d-b2253443aa6d", "0755bd90-d621-42aa-85bc-b7a44177aaf2");
			SeedUnitOfMeasure(builder, MeasureType.Capacity, "pi3", "Pieds cubes", "Cubic feet", "1d79513f-faeb-4bc8-801d-964dd07afa10", "2dfd45bb-3f3e-4f27-b71e-11dd1a0718ce", "13fe2a8a-0fb6-422f-b342-f2422338d821");
			SeedUnitOfMeasure(builder, MeasureType.Capacity, "GI", "Gallons impériaux", "Imperial gallons", "556b2773-cd90-413c-a666-a8825a0cc2a3", "0b926f99-3046-4780-8ed7-f69e692e49a1", "7fce8abf-8b56-45ff-9bb2-bf0698d748de");
			SeedUnitOfMeasure(builder, MeasureType.Capacity, "", "Aucune", "None", "47d931ed-da80-4643-b7ce-1a32fc86366d", "6c2e8bc0-aa97-4097-b1ae-a772f7f992c5", "d826bae7-bac3-445d-b6d9-1560b060f72b");
			SeedUnitOfMeasure(builder, MeasureType.Capacity, "G", "Gallons US", "US gallons", "0a89ee7d-1205-4e9b-ac34-5231df0477cb", "44a11937-a9c1-4f46-b426-bea5e4492cd5", "16674fc7-89f4-408c-bc33-7d77b20d6d8b");
			SeedUnitOfMeasure(builder, MeasureType.Capacity, "g", "Grammes", "Grams", "d2f7d529-f330-44f7-a522-c1248fd0f68d", "ff8ae4c7-bea2-4034-9835-d7faf2475a9d", "895c3f09-52a8-4876-bca0-5c5b1b9b80e3");
			SeedUnitOfMeasure(builder, MeasureType.Capacity, "Kg", "Kilos", "Kilos", "b2974a84-ed50-4660-85d0-39d7d394d308", "0a18ecff-62e4-45bd-9570-8b8f46ee2498", "d9641dee-cd87-4cc4-af35-26b19e97ec5a");
			SeedUnitOfMeasure(builder, MeasureType.Capacity, "L", "Litres", "Litres", "fa616ff7-f819-497c-a80b-e0adf04f4b40", "0e369bef-bd66-4f4c-b827-c2b3c706701f", "f1b0b099-259f-4276-86af-7f87998a33f6");
			SeedUnitOfMeasure(builder, MeasureType.Capacity, "lb", "Livres", "Pounds", "18ac17a4-623a-404f-a8e3-ffe8e0d5436b", "e0acfa33-b725-40e6-9010-051cd13e2160", "ace3489e-af53-4b38-ae18-e0ce84473ccf");
			SeedUnitOfMeasure(builder, MeasureType.Capacity, "oz", "Onces", "Onces", "01952575-4d87-4bc2-a087-b4b5ec2cb979", "5d20c6a6-da86-4db5-a40c-3249ad9e5a66", "f4aa0d84-6f2f-4ea7-bfa9-3c44bb486c53");
		}

		private static void SeedUnitOfMeasure(ModelBuilder builder, MeasureType measureType, string abbreviation, string french, string english, string id, string idFr, string idEn)
		{
			var type = new UnitOfMeasure { Id = Guid.Parse(id), MeasureType = measureType, CreatedOn = Now, Abbreviation = abbreviation };
			var frenchLocalization = new UnitOfMeasureLocalization { Id = Guid.Parse(idFr), LanguageCode = "fr", Name = french, IdParent = type.Id, CreatedOn = Now };
			var englishLocalization = new UnitOfMeasureLocalization {Id = Guid.Parse(idEn), LanguageCode = "en", Name = english, IdParent = type.Id, CreatedOn = Now };
			builder.Entity<UnitOfMeasure>().HasData(type);
			builder.Entity<UnitOfMeasureLocalization>().HasData(frenchLocalization, englishLocalization);
		}
	}
}