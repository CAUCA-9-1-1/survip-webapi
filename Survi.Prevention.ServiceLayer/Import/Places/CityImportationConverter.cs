using System;
using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Base;
using System.Linq;
using ImportedCity = Survi.Prevention.ApiClient.DataTransferObjects.City;

namespace Survi.Prevention.ServiceLayer.Import.Places
{
    public class CityImportationConverter : BaseLocalizableEntityConverter<ImportedCity, City, CityLocalization>
    {
	    public CityImportationConverter(IManagementContext context, AbstractValidator<ImportedCity> validator) 
		    : base(context, validator)
	    {
	    }

	    protected override void CopyCustomFieldsToEntity(ImportedCity importedObject, City entity)
	    {
		    entity.IdCounty = Guid.Parse(importedObject.IdCounty);
		    entity.IdCityType = Guid.Parse(importedObject.IdCityType);
		    entity.Code3Letters = importedObject.Code3Letters;
		    entity.Code = importedObject.Code;
		    entity.EmailAddress = importedObject.EmailAddress;
	    }

	    protected override void GetRealForeignKeys(ImportedCity importedObject)
	    {
		    GetCountyForeignKey(importedObject);
		    GetCityTypeForeignKey(importedObject);
	    }

	    private void GetCountyForeignKey(ImportedCity importedObject)
	    {
		    var idCounty = Context.Set<County>()
			    .FirstOrDefault(county => county.IdExtern == importedObject.IdCounty)?.Id;
		    importedObject.IdCounty = idCounty.HasValue ? idCounty.ToString() : null;
	    }

	    private void GetCityTypeForeignKey(ImportedCity importedObject)
	    {
		    var idCityType = Context.Set<CityType>()
			    .FirstOrDefault(cityType => cityType.IdExtern == importedObject.IdCityType)?.Id;
		    importedObject.IdCityType = idCityType.HasValue ? idCityType.ToString() : null;
	    }

	}
}
