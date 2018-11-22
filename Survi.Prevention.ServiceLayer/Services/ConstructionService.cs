using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects.Base;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Import.Base;
using ImportConstructionType = Survi.Prevention.ApiClient.DataTransferObjects.ConstructionType;
using ImportFireResistanceType = Survi.Prevention.ApiClient.DataTransferObjects.ConstructionFireResistanceType;
using ImportSidingType = Survi.Prevention.ApiClient.DataTransferObjects.SidingType;
using ImportRoofType = Survi.Prevention.ApiClient.DataTransferObjects.RoofType;
using ImportRoofMaterialType = Survi.Prevention.ApiClient.DataTransferObjects.RoofMaterialType;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class ConstructionService : BaseService
	{
	    private readonly List<object> converters = new List<object>();

		public ConstructionService(
		    IManagementContext context,
		    IEntityConverter<ImportConstructionType, ConstructionType> constructionTypeConverter,
		    IEntityConverter<ImportFireResistanceType, ConstructionFireResistanceType> fireResistanceTypeConverter,
	        IEntityConverter<ImportSidingType, SidingType> sidingTypeConverter,
	        IEntityConverter<ImportRoofType, RoofType> roofTypeConverter,
	        IEntityConverter<ImportRoofMaterialType, RoofMaterialType> roofMaterialTypeConverter
        ) : base(context)
		{
		    converters.Add(constructionTypeConverter);
		    converters.Add(fireResistanceTypeConverter);
		    converters.Add(sidingTypeConverter);
		    converters.Add(roofTypeConverter);
		    converters.Add(roofMaterialTypeConverter);
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

	    public List<ImportationResult> Import<TEntity,TImportedEntity>(List<TImportedEntity> entities)
	        where TEntity : BaseImportedModel, new()
	        where TImportedEntity : BaseTransferObject
        {
	        var resultList = new List<ImportationResult>();
	        foreach (var entity in entities)
	            resultList.Add(Import<TEntity, TImportedEntity>(entity));

	        return resultList;
	    }

	    protected ImportationResult Import<TEntity, TImportedEntity>(TImportedEntity importedEntity)
	        where TEntity : BaseImportedModel, new()
	        where TImportedEntity : BaseTransferObject
        {
	        var result = GetImportationResult<TEntity, TImportedEntity>(importedEntity);

	        if (result.IsValid)
	        {
	            Context.SaveChanges();
	            result.HasBeenImported = true;
	        }
	        return result;
	    }

	    protected ImportationResult GetImportationResult<TEntity, TImportedEntity>(TImportedEntity importedEntity)
	        where TEntity : BaseImportedModel, new()
	        where TImportedEntity : BaseTransferObject
	    {
	        var converter = converters.OfType<IEntityConverter<TImportedEntity, TEntity>>().First();
            var conversionResult = converter.Convert(importedEntity);
	        return new ImportationResult
	        {
	            IdEntity = importedEntity.Id,
	            Messages = conversionResult.ValidationErrors
	        };
	    }
    }
}