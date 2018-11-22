using System;
using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Base;
using System.Linq;
using importedFireSafetyDepartment = Survi.Prevention.ApiClient.DataTransferObjects.FireSafetyDepartment;

namespace Survi.Prevention.ServiceLayer.Import.FireSafetyDepartment
{
    public class FireSafetyDepartmentImportationConverter: BaseLocalizableEntityConverter<importedFireSafetyDepartment, Models.FireSafetyDepartments.FireSafetyDepartment, FireSafetyDepartmentLocalization>
    {
	    public FireSafetyDepartmentImportationConverter(IManagementContext context, AbstractValidator<importedFireSafetyDepartment> validator) 
		    : base(context, validator)
	    {
	    }

	    protected override void CopyCustomFieldsToEntity(importedFireSafetyDepartment importedObject, Models.FireSafetyDepartments.FireSafetyDepartment entity)
	    {
		    entity.Language = importedObject.Language;
			entity.IdCounty = Guid.Parse(importedObject.IdCounty);
	    }

	    protected override void GetRealForeignKeys(importedFireSafetyDepartment importedObject)
	    {
		    var idCounty = Context.Set<County>()
			    .FirstOrDefault(county => county.IdExtern == importedObject.IdCounty)?.Id;
		    importedObject.IdCounty = idCounty.HasValue ? idCounty.ToString() : null;
	    }
    }
}
