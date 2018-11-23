using System;
using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Base;
using ImportedCounty = Survi.Prevention.ApiClient.DataTransferObjects.County;

namespace Survi.Prevention.ServiceLayer.Import.Places
{
    public class CountyImportationConverter : BaseLocalizableEntityConverter<ImportedCounty, County, CountyLocalization>
    {
	    public CountyImportationConverter(IManagementContext context, AbstractValidator<ImportedCounty> validator)
		    : base(context, validator)
	    {
	    }

	    protected override void CopyCustomFieldsToEntity(ImportedCounty importedObject, County entity)
	    {
		    entity.IdState = Guid.Parse(importedObject.IdState);
		    entity.IdRegion = Guid.Parse(importedObject.IdRegion);
	    }

	    protected override void GetRealForeignKeys(ImportedCounty importedObject)
	    {
	        importedObject.IdState = GetRealId<State>(importedObject.IdState);
	        importedObject.IdRegion = GetRealId<Region>(importedObject.IdRegion);
	    }
    }
}
