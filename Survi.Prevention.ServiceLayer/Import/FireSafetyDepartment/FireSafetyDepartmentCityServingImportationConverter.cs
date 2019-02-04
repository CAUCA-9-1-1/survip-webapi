using System;
using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Base;
using Survi.Prevention.ServiceLayer.Import.Base.Cache;
using importedFireDepCity = Survi.Prevention.ApiClient.DataTransferObjects.FireSafetyDepartmentCityServing;

namespace Survi.Prevention.ServiceLayer.Import.FireSafetyDepartment
{
	public class FireSafetyDepartmentCityServingImportationConverter: BaseEntityConverter<importedFireDepCity, FireSafetyDepartmentCityServing>
    {
	    public FireSafetyDepartmentCityServingImportationConverter(IManagementContext context,
		    AbstractValidator<importedFireDepCity> validator, CacheSystem cache)
	        : base(context, validator, null, cache)
        {
	    }

		protected override void CopyCustomFieldsToEntity(importedFireDepCity importedObject, FireSafetyDepartmentCityServing entity)
		{
			entity.IdCity = Guid.Parse(importedObject.IdCity);
			entity.IdFireSafetyDepartment = Guid.Parse(importedObject.IdFireSafetyDepartment);
		}

		protected override void GetRealForeignKeys(importedFireDepCity importedFireDepCityServing)
		{
			importedFireDepCityServing.IdCity = GetRealId<City>(importedFireDepCityServing.IdCity);
			importedFireDepCityServing.IdFireSafetyDepartment = GetRealId<Models.FireSafetyDepartments.FireSafetyDepartment>(importedFireDepCityServing.IdFireSafetyDepartment);
		}
    }
}

