using System;
using System.Linq;
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
		    GetRealStateForeignKey(importedObject);
		    GetRealRegionForeignKey(importedObject);
	    }

	    private void GetRealStateForeignKey(ImportedCounty importedObject)
	    {
		    var idState = Context.States
			    .FirstOrDefault(state => state.IdExtern == importedObject.IdState)?.Id;
		    importedObject.IdState = idState.HasValue ? idState.ToString() : null;
	    }

	    private void GetRealRegionForeignKey(ImportedCounty importedObject)
	    {
		    var idRegion = Context.Regions
			    .FirstOrDefault(region => region.IdExtern == importedObject.IdRegion)?.Id;
		    importedObject.IdRegion = idRegion.HasValue ? idRegion.ToString() : null;
	    }
    }
}
