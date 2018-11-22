using System;
using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Base;
using importedFireDepCity = Survi.Prevention.ApiClient.DataTransferObjects.FireSafetyDepartmentCityServing;
using System.Linq;

namespace Survi.Prevention.ServiceLayer.Import.FireSafetyDepartment
{
    public class FireSafetyDepartmentCityServingImportationConverter: BaseEntityConverter<importedFireDepCity, FireSafetyDepartmentCityServing>
    {
	    public FireSafetyDepartmentCityServingImportationConverter(IManagementContext context,
		    AbstractValidator<importedFireDepCity> validator) : base(context, validator)
	    {

	    }

		protected override void CopyCustomFieldsToEntity(importedFireDepCity importedObject, FireSafetyDepartmentCityServing entity)
		{
			entity.IdCity = Guid.Parse(importedObject.IdCity);
			entity.IdFireSafetyDepartment = Guid.Parse(importedObject.IdFireSafetyDepartment);
		}

		protected override void GetRealForeignKeys(importedFireDepCity importedFireDepCityServing)
		{
			GetFireSafetyDepartmentForeignKey(importedFireDepCityServing);
			GetCityForeignKey(importedFireDepCityServing);
		}

	    private void GetFireSafetyDepartmentForeignKey(importedFireDepCity importedFireDepCityServing)
	    {
		    var idFireSafetyDepartment = Context.Set<Models.FireSafetyDepartments.FireSafetyDepartment>()
			    .FirstOrDefault(fireSafetyDepartment => fireSafetyDepartment.IdExtern == importedFireDepCityServing.IdFireSafetyDepartment)?.Id;
		    importedFireDepCityServing.IdFireSafetyDepartment = idFireSafetyDepartment.HasValue ? idFireSafetyDepartment.ToString() : null;
	    }

	    private void GetCityForeignKey(importedFireDepCity importedFireDepCityServing)
	    {
		    var idCity = Context.Set<City>()
			    .FirstOrDefault(city => city.IdExtern == importedFireDepCityServing.IdCity)?.Id;
		    importedFireDepCityServing.IdCity = idCity.HasValue ? idCity.ToString() : null;
	    }
    }
}
