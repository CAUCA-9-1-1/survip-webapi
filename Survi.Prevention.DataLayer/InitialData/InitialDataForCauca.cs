using System;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.InitialData
{
	public class InitialDataForCauca
	{
		private static readonly DateTime Now = new DateTime(2018, 06, 01);

		private static readonly Guid CityTypeId = Guid.Parse("ab0cfb19-ec48-4a5f-af01-2fdfaff6b9ef");
		private static readonly Guid CityStGeorgesId = Guid.Parse("8a4737d2-e3c8-4d1f-b5ad-76a4703568a5");
		private static readonly Guid StateId = Guid.Parse("af783569-fa64-4e67-b698-cd1bf371b601");
		private static readonly Guid FireSafetyDepartmentId = Guid.Parse("a7658f1f-c91b-44a2-9dd0-54fc1dc80135");

		public static void SeedInitialGeographicData(ModelBuilder builder)
		{
			var country = new Country
			{
				Id = Guid.Parse("4354e272-c63d-4800-a608-66b1d88661e5"),
				CodeAlpha2 = "CA",
				CodeAlpha3 = "CAD",
				CreatedOn = Now
			};
			builder.Entity<Country>().HasData(country);
			SeedCountryLocalization(builder, country.Id);
			SeedStates(builder, country.Id);
		}

		public static void SeedInitialCityTypes(ModelBuilder builder)
		{
			SeedCityType(builder, CityTypeId, "Ville", "City", Guid.Parse("fb797965-a4ed-48e8-94ba-d7a52beecab8"), Guid.Parse("a6efdfaa-cb26-4e4a-a35f-822c3c1f660a"));
			SeedCityType(builder, Guid.Parse("4354e272-c63d-4800-a608-66b1d88661e5"), "Municipalité", "Municipality", Guid.Parse("9e7540f3-4a36-4237-92cd-32145d0b3a46"), Guid.Parse("60722583-8382-4c56-8646-dba7f5135ba0"));
		}

		private static void SeedCityType(ModelBuilder builder, Guid id, string french, string english, Guid idFrench, Guid idEnglish)
		{
			var type = new CityType { Id = id, CreatedOn = Now };
			var frenchLocalization = new CityTypeLocalization { Id = idFrench, LanguageCode = "fr", Name = french, IdParent = type.Id, CreatedOn = Now };
			var englishLocalization = new CityTypeLocalization { Id = idEnglish, LanguageCode = "en", Name = english, IdParent = type.Id, CreatedOn = Now };
			builder.Entity<CityType>().HasData(type);
			builder.Entity<CityTypeLocalization>().HasData(frenchLocalization, englishLocalization);
		}

		private static void SeedCountryLocalization(ModelBuilder builder, Guid idCountry)
		{
			var localizations = new []
			{
				new CountryLocalization {LanguageCode = "fr", Name = "Canada", Id = Guid.Parse("f7e2b753-4124-4ebd-b557-5a4aed07c88b"), IdParent = idCountry, CreatedOn = Now },
				new CountryLocalization {LanguageCode = "en", Name = "Canada", Id = Guid.Parse("d5da483c-c69d-4725-b8c4-6317bfc01719"), IdParent = idCountry, CreatedOn = Now }
			};
			builder.Entity<CountryLocalization>().HasData(localizations);
		}

		private static void SeedStates(ModelBuilder builder, Guid idCountry)
		{
			var state = new State {Id = StateId, AnsiCode = "QC", IdCountry = idCountry, CreatedOn = Now};
			builder.Entity<State>().HasData(state);

			SeedStateLocalizations(builder, state.Id);
			SeedRegions(builder, state.Id);
		}

		private static void SeedStateLocalizations(ModelBuilder builder, Guid idParent)
		{
			var localizations = new []
			{
				new StateLocalization {Id = Guid.Parse("aca9aab0-5208-4c76-8969-c9929e8e3afc"), LanguageCode = "fr", Name = "Québec", CreatedOn = Now, IdParent = idParent},
				new StateLocalization {Id = Guid.Parse("565f8c38-bd85-4ddb-9269-d62af8659fec"), LanguageCode = "en", Name = "Quebec", CreatedOn = Now, IdParent = idParent}
			};
			builder.Entity<StateLocalization>().HasData(localizations);
		}

		private static void SeedRegions(ModelBuilder builder, Guid idState)
		{
			var region = new Region {Code = "12", CreatedOn = Now, Id = Guid.Parse("278e7a5b-e2a5-4f17-915e-48d505b9d468"), IdState = idState};
			builder.Entity<Region>().HasData(region);
			SeedRegionLocalizations(builder, region.Id);
			SeedCounties(builder, region.Id);
		}

		private static void SeedRegionLocalizations(ModelBuilder builder, Guid idParent)
		{
			var localizations = new []
			{
				new RegionLocalization {Id = Guid.Parse("f6694cba-1e14-4041-b8ce-d80f20f57ee7"), LanguageCode = "fr", Name = "Chaudière-Appalaches", CreatedOn = Now, IdParent = idParent},
				new RegionLocalization {Id = Guid.Parse("9b00cbee-8f05-465d-9f5b-0ddad284b672"), LanguageCode = "en", Name = "Chaudière-Appalaches", CreatedOn = Now, IdParent = idParent }
			};
			builder.Entity<RegionLocalization>().HasData(localizations);
		}

		private static void SeedCounties(ModelBuilder builder, Guid idRegion)
		{
			var beauce = new County {Id = Guid.Parse("4088faa7-6780-43ba-8b65-40709a1bc00d"), CreatedOn = Now, IdRegion = idRegion};
		    var newBeauce = new County { Id = Guid.Parse("f727eb7e-ce7b-4b9e-a314-b5beff1c9019"), CreatedOn = Now, IdRegion = idRegion};

			builder.Entity<County>().HasData(beauce, newBeauce);
			SeedCities(builder, beauce.Id);
			SeedNewBeauceLocalizations(builder, newBeauce.Id);
			SeedBeauceSartiganLocalizations(builder, beauce.Id);
			SeedFireSafetyDepartment(builder, FireSafetyDepartmentId, beauce.Id, "Cauca SSI", "Cauca SSI");
			var fireStations = new[]
			{
				new Firestation{ Id = Guid.Parse("8068ff2b-64d6-4cae-9893-5a0b49c7ed2a"), CreatedOn = Now, Name = "Caserne 1", IdFireSafetyDepartment = FireSafetyDepartmentId },
				new Firestation{ Id = Guid.Parse("364891f3-a29e-48d2-85cb-764597616d84"), CreatedOn = Now, Name = "Caserne 2", IdFireSafetyDepartment = FireSafetyDepartmentId },
				new Firestation{ Id = Guid.Parse("6a2a2f8b-05e5-4675-8815-36382eb0dcb7"), CreatedOn = Now, Name = "Caserne 3", IdFireSafetyDepartment = FireSafetyDepartmentId }
			};			
			builder.Entity<Firestation>().HasData(fireStations);
		}

		private static void SeedNewBeauceLocalizations(ModelBuilder builder, Guid idCounty)
		{
			var loc = new [] {
				new CountyLocalization {LanguageCode = "fr", Name = "La Nouvelle-Beauce", IdParent = idCounty, CreatedOn = Now, Id = Guid.Parse("d8ff5576-222d-4f09-87f2-1f4b5d051292")},
				new CountyLocalization {LanguageCode = "en", Name = "The New-Beauce", IdParent = idCounty, CreatedOn = Now, Id = Guid.Parse("ddf2fe6c-9852-48b5-962b-f9eefd90e1d9")}};
			builder.Entity<CountyLocalization>().HasData(loc);
		}

		private static void SeedBeauceSartiganLocalizations(ModelBuilder builder, Guid idCounty)
		{
			var loc = new [] {
				new CountyLocalization {LanguageCode = "fr", Name = "Beauce-Sartigan", IdParent = idCounty, CreatedOn = Now, Id = Guid.Parse("9de321f7-59fb-4694-9844-15a89637577e")},
				new CountyLocalization {LanguageCode = "en", Name = "Beauce-Sartigan", IdParent = idCounty, CreatedOn = Now, Id = Guid.Parse("469482dc-8ee2-4e49-93d7-087a3e7d8570")}};
			builder.Entity<CountyLocalization>().HasData(loc);
		}

		private static void SeedCities(ModelBuilder builder, Guid idCounty)
		{
			var cause = new City {Code = "29045", Code3Letters = "SIN", IdCityType = CityTypeId, IdCounty = idCounty, CreatedOn = Now, Id = Guid.Parse("919e4364-7118-4646-a641-c437a6106321") };
			var cauca = new City {Id = CityStGeorgesId, Code = "29073", Code3Letters = "SGS", IdCityType = CityTypeId, IdCounty = idCounty, CreatedOn = Now };
			builder.Entity<City>().HasData(cause, cauca);
			SeedCauseLocalizations(builder, cause.Id);
			SeedCaucaLocalizations(builder, cauca.Id);
			var serving = new FireSafetyDepartmentCityServing { Id = Guid.Parse("087815e0-7cec-4a57-b5a6-1864939d8933"), CreatedOn = Now, IdFireSafetyDepartment = FireSafetyDepartmentId, IdCity = cauca.Id };
			builder.Entity<FireSafetyDepartmentCityServing>().HasData(serving);
		}

		private static void SeedCaucaLocalizations(ModelBuilder builder, Guid idCity)
		{
			var loc = new[] {
				new CityLocalization {LanguageCode = "fr", Name = "Caucaville", IdParent = idCity, CreatedOn = Now, Id = Guid.Parse("22cdf842-be3d-4b46-ab12-05198cf7f9d2")},
				new CityLocalization { LanguageCode = "en", Name = "Caucatown", IdParent = idCity, CreatedOn = Now, Id = Guid.Parse("1abe4d86-66a1-4316-9cd4-49797ddab54c") } };
			builder.Entity<CityLocalization>().HasData(loc);
		}

		private static void SeedCauseLocalizations(ModelBuilder builder, Guid idCity)
		{
			var loc = new[] {
				new CityLocalization {LanguageCode = "fr", Name = "Causeville", IdParent = idCity, CreatedOn = Now, Id = Guid.Parse("519b72ee-cecd-42e7-a58b-5c20c69a68bc") },
				new CityLocalization { LanguageCode = "en", Name = "Causetown", IdParent = idCity, CreatedOn = Now, Id =Guid.Parse("a03f2487-a9d7-441a-98b4-3738983468ff") } };
			builder.Entity<CityLocalization>().HasData(loc);
		}

		private static void SeedFireSafetyDepartment(ModelBuilder builder, Guid id, Guid idCounty, string french, string english)
		{
			var type = new FireSafetyDepartment { Id = id, IdCounty = idCounty, CreatedOn = Now, Language = "fr" };
			var frenchLocalization = new FireSafetyDepartmentLocalization { Id = Guid.Parse("4ef5b483-c97f-45d7-b763-3fa3da905b1c"), LanguageCode = "fr", Name = french, IdParent = type.Id, CreatedOn = Now };
			var englishLocalization = new FireSafetyDepartmentLocalization { Id = Guid.Parse("a03f2487-a9d7-441a-98b4-3738983468ff"), LanguageCode = "en", Name = english, IdParent = type.Id, CreatedOn = Now };
			builder.Entity<FireSafetyDepartment>().HasData(type);
			builder.Entity<FireSafetyDepartmentLocalization>().HasData(frenchLocalization, englishLocalization);
		}
	}
}