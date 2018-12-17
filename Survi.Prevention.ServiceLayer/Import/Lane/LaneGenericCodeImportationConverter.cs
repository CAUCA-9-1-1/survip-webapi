using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Import.Base;
using importedGenericCode = Survi.Prevention.ApiClient.DataTransferObjects.LaneGenericCode;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Base.Cache;

namespace Survi.Prevention.ServiceLayer.Import.Lane
{
	public class LaneGenericCodeImportationConverter : BaseEntityConverter<importedGenericCode, LaneGenericCode>
	{
		public LaneGenericCodeImportationConverter(IManagementContext context, AbstractValidator<importedGenericCode> validator, CacheSystem cache)
		    : base(context, validator, null, cache)
        {
		}

		protected override void CopyCustomFieldsToEntity(importedGenericCode importedObject, LaneGenericCode entity)
		{
			entity.Code = importedObject.Code;
			entity.Description = importedObject.Description;
			entity.AddWhiteSpaceAfter = importedObject.AddWhiteSpaceAfter;
		}
	}
}
