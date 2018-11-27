﻿using System;
using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Base;
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
	        importedObject.IdCounty = GetRealId<County>(importedObject.IdCounty);
	        importedObject.IdCityType = GetRealId<CityType>(importedObject.IdCityType);
        }
	}
}
