using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Import.Base;
using importedPublicCode = Survi.Prevention.ApiClient.DataTransferObjects.LanePublicCode;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Base.Cache;

namespace Survi.Prevention.ServiceLayer.Import.Lane
{
    public class LanePublicCodeImportationConverter: BaseEntityConverter<importedPublicCode, LanePublicCode>
    {
	    public LanePublicCodeImportationConverter(IManagementContext context, AbstractValidator<importedPublicCode> validator, CacheSystem cache)
	        : base(context, validator, null, cache)
        {
	    }

	    protected override void CopyCustomFieldsToEntity(importedPublicCode importedObject, LanePublicCode entity)
	    {
		    entity.Code = importedObject.Code;
		    entity.Description = importedObject.Description;
		    entity.Abbreviation = importedObject.Abbreviation;
	    }
    }
}
