using System;
using System.Linq;
using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Base;
using County = Survi.Prevention.Models.FireSafetyDepartments.County;

namespace Survi.Prevention.ServiceLayer.Import.Places
{
    public class CountyImportationConverter : BaseLocalizableEntityConverter<ApiClient.DataTransferObjects.County, County, CountyLocalization>
    {
	    public CountyImportationConverter(IManagementContext context, AbstractValidator<ApiClient.DataTransferObjects.County> validator)
		    : base(context, validator)
	    {
	    }

	    protected override void CopyCustomFieldsToEntity(ApiClient.DataTransferObjects.County importedObject, County entity)
	    {
		    entity.IdState = Guid.Parse(importedObject.IdState);
		    entity.IdRegion = Guid.Parse(importedObject.IdRegion);
	    }

	    protected override void GetRealForeignKeys(ApiClient.DataTransferObjects.County importedObject)
	    {
		    GetRealStateForeignKey(importedObject);
		    GetRealRegionForeignKey(importedObject);
	    }

	    public bool GetRealStateForeignKey(ApiClient.DataTransferObjects.County importedObject)
	    {
		    var idState = Context.States
			    .FirstOrDefault(state => state.IdExtern == importedObject.IdState)?.Id;
		    importedObject.IdState = idState.HasValue ? idState.ToString() : null;
		    return idState != null;
	    }

	    public bool GetRealRegionForeignKey(ApiClient.DataTransferObjects.County importedObject)
	    {
		    var idRegion = Context.Regions
			    .FirstOrDefault(region => region.IdExtern == importedObject.IdRegion)?.Id;
		    importedObject.IdRegion = idRegion.HasValue ? idRegion.ToString() : null;

		    return idRegion != null;
	    }
    }
}
