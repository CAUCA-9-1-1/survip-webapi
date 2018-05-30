using System;
using System.Collections.Generic;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.InitialData
{
	public class InitialDataForCauca
	{
		private static readonly Guid CityTypeId = Guid.NewGuid();
		private static readonly Guid CityStGeorgesId = Guid.Parse("8a4737d2-e3c8-4d1f-b5ad-76a4703568a5");
		private static readonly Guid StateId = Guid.NewGuid();

		public static IEnumerable<Country> GetInitialGeographicData()
		{
			yield return new Country
			{
				CodeAlpha2 = "CA",
				CodeAlpha3 = "CAD",
				Localizations = GetCountryLocalizations(),
				States = GetStates()
			};
		}

		public static IEnumerable<CityType> GetInitialCityTypes()
		{
			yield return new CityType {Id = CityTypeId, Localizations = new List<CityTypeLocalization> {new CityTypeLocalization {LanguageCode = "fr", Name = "Ville"}, new CityTypeLocalization {LanguageCode = "en", Name = "City"}}};
			yield return new CityType {Localizations = new List<CityTypeLocalization> {new CityTypeLocalization {LanguageCode = "fr", Name = "Municipalité"}, new CityTypeLocalization {LanguageCode = "en", Name = "Municipality"}}};
		}

		private static List<CountryLocalization> GetCountryLocalizations()
		{
			return new List<CountryLocalization>
			{
				new CountryLocalization {LanguageCode = "fr", Name = "Canada"},
				new CountryLocalization {LanguageCode = "en", Name = "Canada"}
			};
		}

		private static List<State> GetStates()
		{
			return new List<State>
			{
				new State {Id = StateId, AnsiCode = "QC", Localizations = GetStateLocalization(), Regions = GetRegions()}
			};
		}

		private static List<StateLocalization> GetStateLocalization()
		{
			return new List<StateLocalization>
			{
				new StateLocalization {LanguageCode = "fr", Name = "Québec"},
				new StateLocalization {LanguageCode = "en", Name = "Quebec"}
			};
		}

		private static List<Region> GetRegions()
		{
			return new List<Region>
			{
				new Region {Code = "12", Localizations = GetRegionLocalizations(), Counties = GetCounties()},
			};
		}

		private static List<RegionLocalization> GetRegionLocalizations()
		{
			return new List<RegionLocalization>
			{
				new RegionLocalization {LanguageCode = "fr", Name = "Chaudière-Appalaches"},
				new RegionLocalization {LanguageCode = "en", Name = "Chaudière-Appalaches"}
			};
		}

		private static List<County> GetCounties()
		{
			return new List<County>
			{
				new County {Localizations = GetBeauceSartiganLocalizations(), Cities = GetCities(), IdState = StateId},
				new County {Localizations = GetNewBeauceLocalizations(), IdState = StateId}
			};
		}

		private static List<CountyLocalization> GetNewBeauceLocalizations()
		{
			return new List<CountyLocalization> {new CountyLocalization {LanguageCode = "fr", Name = "La Nouvelle-Beauce"}, new CountyLocalization {LanguageCode = "en", Name = "The New-Beauce"}};
		}

		private static List<CountyLocalization> GetBeauceSartiganLocalizations()
		{
			return new List<CountyLocalization> {new CountyLocalization {LanguageCode = "fr", Name = "Beauce-Sartigan"}, new CountyLocalization {LanguageCode = "en", Name = "Beauce-Sartigan"}};
		}		

		private static List<City> GetCities()
		{
			return new List<City>
			{
				new City { Code = "29045", Code3Letters = "SIN", IdCityType = CityTypeId, Localizations = GetStMartinLocalizations()},
				new City { Id = CityStGeorgesId, Code = "29073", Code3Letters = "SGS", IdCityType = CityTypeId, Localizations = GetStGeorgesLocalizations()}
			};
		}

		private static List<CityLocalization> GetStGeorgesLocalizations()
		{
			return new List<CityLocalization> {new CityLocalization {LanguageCode = "fr", Name = "Saint-Georges"}, new CityLocalization { LanguageCode = "en", Name = "St. Georges"}};
		}

		private static List<CityLocalization> GetStMartinLocalizations()
		{
			return new List<CityLocalization> {new CityLocalization {LanguageCode = "fr", Name = "Saint-Martin"}, new CityLocalization { LanguageCode = "en", Name = "St. Martin"}};
		}
	}
}