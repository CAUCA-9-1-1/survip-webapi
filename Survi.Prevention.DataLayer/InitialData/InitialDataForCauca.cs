using System;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.InitialData
{
	public class InitialDataForCauca
	{
		private static readonly DateTime Now = new DateTime(2018, 06, 01);

		private static readonly Guid CityTypeId = GuidExtensions.GetGuid();
		private static readonly Guid CityStGeorgesId = Guid.Parse("8a4737d2-e3c8-4d1f-b5ad-76a4703568a5");
		private static readonly Guid StateId = GuidExtensions.GetGuid();
		private static readonly Guid FireSafetyDepartmentId = GuidExtensions.GetGuid();

		public static void SeedInitialGeographicData(ModelBuilder builder)
		{
			var country = new Country
			{
				Id = GuidExtensions.GetGuid(),
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
			SeedCityType(builder, CityTypeId, "Ville", "City");
			SeedCityType(builder, GuidExtensions.GetGuid(), "Municipalité", "Municipality");
		}

		private static void SeedCityType(ModelBuilder builder, Guid id, string french, string english)
		{
			var type = new CityType { Id = id, CreatedOn = Now };
			var frenchLocalization = new CityTypeLocalization { Id = GuidExtensions.GetGuid(), LanguageCode = "fr", Name = french, IdParent = type.Id, CreatedOn = Now };
			var englishLocalization = new CityTypeLocalization { Id = GuidExtensions.GetGuid(), LanguageCode = "fr", Name = english, IdParent = type.Id, CreatedOn = Now };
			builder.Entity<CityType>().HasData(type);
			builder.Entity<CityTypeLocalization>().HasData(frenchLocalization, englishLocalization);
		}

		private static void SeedCountryLocalization(ModelBuilder builder, Guid idCountry)
		{
			var localizations = new []
			{
				new CountryLocalization {LanguageCode = "fr", Name = "Canada", Id = GuidExtensions.GetGuid(), IdParent = idCountry, CreatedOn = Now },
				new CountryLocalization {LanguageCode = "en", Name = "Canada", Id = GuidExtensions.GetGuid(), IdParent = idCountry, CreatedOn = Now }
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
				new StateLocalization {Id = GuidExtensions.GetGuid(), LanguageCode = "fr", Name = "Québec", CreatedOn = Now, IdParent = idParent},
				new StateLocalization {Id = GuidExtensions.GetGuid(), LanguageCode = "en", Name = "Quebec", CreatedOn = Now, IdParent = idParent}
			};
			builder.Entity<StateLocalization>().HasData(localizations);
		}

		private static void SeedRegions(ModelBuilder builder, Guid idState)
		{
			var region = new Region {Code = "12", CreatedOn = Now, Id = GuidExtensions.GetGuid(), IdState = idState};
			builder.Entity<Region>().HasData(region);
			SeedRegionLocalizations(builder, region.Id);
			SeedCounties(builder, region.Id);
		}

		private static void SeedRegionLocalizations(ModelBuilder builder, Guid idParent)
		{
			var localizations = new []
			{
				new RegionLocalization {Id = GuidExtensions.GetGuid(), LanguageCode = "fr", Name = "Chaudière-Appalaches", CreatedOn = Now, IdParent = idParent},
				new RegionLocalization {Id = GuidExtensions.GetGuid(), LanguageCode = "en", Name = "Chaudière-Appalaches", CreatedOn = Now, IdParent = idParent }
			};
			builder.Entity<RegionLocalization>().HasData(localizations);
		}

		private static void SeedCounties(ModelBuilder builder, Guid idRegion)
		{
			var beauce = new County {Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdState = StateId, IdRegion = idRegion};
		    var newBeauce = new County { Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdState = StateId, IdRegion = idRegion};

			builder.Entity<County>().HasData(beauce, newBeauce);
			SeedCities(builder, beauce.Id);
			SeedNewBeauceLocalizations(builder, newBeauce.Id);
			SeedBeauceSartiganLocalizations(builder, beauce.Id);
			SeedFireSafetyDepartment(builder, FireSafetyDepartmentId, beauce.Id, "Cauca SSI", "Cauca SSI");
			var fireStations = new[]
			{
				new Firestation{ Id = GuidExtensions.GetGuid(), CreatedOn = Now, Name = "Caserne 1", IdFireSafetyDepartment = FireSafetyDepartmentId },
				new Firestation{ Id = GuidExtensions.GetGuid(), CreatedOn = Now, Name = "Caserne 2", IdFireSafetyDepartment = FireSafetyDepartmentId },
				new Firestation{ Id = GuidExtensions.GetGuid(), CreatedOn = Now, Name = "Caserne 3", IdFireSafetyDepartment = FireSafetyDepartmentId }
			};			
			builder.Entity<Firestation>().HasData(fireStations);
		}

		private static void SeedNewBeauceLocalizations(ModelBuilder builder, Guid idCounty)
		{
			var loc = new [] {
				new CountyLocalization {LanguageCode = "fr", Name = "La Nouvelle-Beauce", IdParent = idCounty, CreatedOn = Now, Id = GuidExtensions.GetGuid()},
				new CountyLocalization {LanguageCode = "en", Name = "The New-Beauce", IdParent = idCounty, CreatedOn = Now, Id = GuidExtensions.GetGuid()}};
			builder.Entity<CountyLocalization>().HasData(loc);
		}

		private static void SeedBeauceSartiganLocalizations(ModelBuilder builder, Guid idCounty)
		{
			var loc = new [] {
				new CountyLocalization {LanguageCode = "fr", Name = "Beauce-Sartigan", IdParent = idCounty, CreatedOn = Now, Id = GuidExtensions.GetGuid()},
				new CountyLocalization {LanguageCode = "en", Name = "Beauce-Sartigan", IdParent = idCounty, CreatedOn = Now, Id = GuidExtensions.GetGuid()}};
			builder.Entity<CountyLocalization>().HasData(loc);
		}

		private static void SeedCities(ModelBuilder builder, Guid idCounty)
		{
			var cause = new City {Code = "29045", Code3Letters = "SIN", IdCityType = CityTypeId, IdCounty = idCounty, CreatedOn = Now, Id = GuidExtensions.GetGuid()};
			var cauca = new City {Id = CityStGeorgesId, Code = "29073", Code3Letters = "SGS", IdCityType = CityTypeId, IdCounty = idCounty, CreatedOn = Now };
			builder.Entity<City>().HasData(cause, cauca);
			SeedCauseLocalizations(builder, cause.Id);
			SeedCaucaLocalizations(builder, cauca.Id);
			var serving = new FireSafetyDepartmentCityServing { Id = GuidExtensions.GetGuid(), CreatedOn = Now, IdFireSafetyDepartment = FireSafetyDepartmentId, IdCity = cauca.Id };
			builder.Entity<FireSafetyDepartmentCityServing>().HasData(serving);
		}

		private static void SeedCaucaLocalizations(ModelBuilder builder, Guid idCity)
		{
			var loc = new[] {
				new CityLocalization {LanguageCode = "fr", Name = "Caucaville", IdParent = idCity, CreatedOn = Now, Id = GuidExtensions.GetGuid()},
				new CityLocalization { LanguageCode = "en", Name = "Caucatown", IdParent = idCity, CreatedOn = Now, Id = GuidExtensions.GetGuid() } };
			builder.Entity<CityLocalization>().HasData(loc);
		}

		private static void SeedCauseLocalizations(ModelBuilder builder, Guid idCity)
		{
			var loc = new[] {
				new CityLocalization {LanguageCode = "fr", Name = "Causeville", IdParent = idCity, CreatedOn = Now, Id = GuidExtensions.GetGuid() },
				new CityLocalization { LanguageCode = "en", Name = "Causetown", IdParent = idCity, CreatedOn = Now, Id = GuidExtensions.GetGuid() } };
			builder.Entity<CityLocalization>().HasData(loc);
		}

		private static void SeedFireSafetyDepartment(ModelBuilder builder, Guid id, Guid idCounty, string french, string english)
		{
			var type = new FireSafetyDepartment { Id = id, IdCounty = idCounty, CreatedOn = Now, Language = "fr" };
			var frenchLocalization = new FireSafetyDepartmentLocalization { Id = GuidExtensions.GetGuid(), LanguageCode = "fr", Name = french, IdParent = type.Id, CreatedOn = Now };
			var englishLocalization = new FireSafetyDepartmentLocalization { Id = GuidExtensions.GetGuid(), LanguageCode = "fr", Name = english, IdParent = type.Id, CreatedOn = Now };
			builder.Entity<FireSafetyDepartment>().HasData(type);
			builder.Entity<FireSafetyDepartmentLocalization>().HasData(frenchLocalization, englishLocalization);
		}
	}
}