using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;
using ImportConstructionType = Survi.Prevention.ApiClient.DataTransferObjects.ConstructionType;
using ImportFireResistanceType = Survi.Prevention.ApiClient.DataTransferObjects.ConstructionFireResistanceType;
using ImportSidingType = Survi.Prevention.ApiClient.DataTransferObjects.SidingType;
using ImportRoofType = Survi.Prevention.ApiClient.DataTransferObjects.RoofType;
using ImportRoofMaterialType = Survi.Prevention.ApiClient.DataTransferObjects.RoofMaterialType;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class ConstructionService : BaseServiceWithGenericImportation
    {
		public ConstructionService(
		    IManagementContext context,
		    IEntityConverter<ImportConstructionType, ConstructionType> constructionTypeConverter,
		    IEntityConverter<ImportFireResistanceType, ConstructionFireResistanceType> fireResistanceTypeConverter,
	        IEntityConverter<ImportSidingType, SidingType> sidingTypeConverter,
	        IEntityConverter<ImportRoofType, RoofType> roofTypeConverter,
	        IEntityConverter<ImportRoofMaterialType, RoofMaterialType> roofMaterialTypeConverter
        ) : base(context)
		{
		    Converters.Add(constructionTypeConverter);
		    Converters.Add(fireResistanceTypeConverter);
		    Converters.Add(sidingTypeConverter);
		    Converters.Add(roofTypeConverter);
		    Converters.Add(roofMaterialTypeConverter);
        }

		public List<GenericModelForDisplay> GetBuildingSidingTypes(string languageCode)
		{
			var query =
				from type in Context.SidingTypes.AsNoTracking()
				where type.IsActive
				from loc in type.Localizations
				where loc.IsActive && loc.LanguageCode == languageCode
				select new GenericModelForDisplay {Id = type.Id, Name = loc.Name};

			return query.ToList();
		}

		public List<GenericModelForDisplay> GetBuildingTypes(string languageCode)
		{
			var query =
				from type in Context.BuildingTypes.AsNoTracking()
				where type.IsActive
				from loc in type.Localizations
				where loc.IsActive && loc.LanguageCode == languageCode
				select new GenericModelForDisplay {Id = type.Id, Name = loc.Name};

			return query.ToList();
		}

		public List<GenericModelForDisplay> GetConstructionFireResistanceTypes(string languageCode)
		{
			var query =
				from type in Context.ConstructionFireResistanceTypes.AsNoTracking()
				where type.IsActive
				from loc in type.Localizations
				where loc.IsActive && loc.LanguageCode == languageCode
				select new GenericModelForDisplay {Id = type.Id, Name = loc.Name};

			return query.ToList();
		}

		public List<GenericModelForDisplay> GetConstructionTypes(string languageCode)
		{
			var query =
				from type in Context.ConstructionTypes.AsNoTracking()
				where type.IsActive
				from loc in type.Localizations
				where loc.IsActive && loc.LanguageCode == languageCode
				select new GenericModelForDisplay {Id = type.Id, Name = loc.Name};

			return query.ToList();
		}

		public List<GenericModelForDisplay> GetRoofMaterialTypes(string languageCode)
		{
			var query =
				from type in Context.RoofMaterialTypes.AsNoTracking()
				where type.IsActive
				from loc in type.Localizations
				where loc.IsActive && loc.LanguageCode == languageCode
				select new GenericModelForDisplay {Id = type.Id, Name = loc.Name};

			return query.ToList();
		}

		public List<GenericModelForDisplay> GetRoofTypes(string languageCode)
		{
			var query =
				from type in Context.RoofTypes.AsNoTracking()
				where type.IsActive
				from loc in type.Localizations
				where loc.IsActive && loc.LanguageCode == languageCode
				select new GenericModelForDisplay {Id = type.Id, Name = loc.Name};

			return query.ToList();
		}

		public AllTypesForConstruction GetAllTypes(string languageCode)
		{
			return new AllTypesForConstruction
			{
				BuildingSidingTypes = GetBuildingSidingTypes(languageCode),
				BuildingTypes = GetBuildingTypes(languageCode),
				ConstructionFireResistanceTypes = GetConstructionFireResistanceTypes(languageCode),
				ConstructionTypes = GetConstructionTypes(languageCode),
				RoofMaterialTypes = GetRoofMaterialTypes(languageCode),
				RoofTypes = GetRoofTypes(languageCode)
			};
		}
    }
}