using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Import.Base;
using importedGenericCode = Survi.Prevention.ApiClient.DataTransferObjects.LaneGenericCode;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.ServiceLayer.Import.Lane
{
	public class LaneGenericCodeImportationConverter : BaseEntityConverter<importedGenericCode, LaneGenericCode>
	{
		public LaneGenericCodeImportationConverter(IManagementContext context, AbstractValidator<importedGenericCode> validator) : base(context, validator, null)
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
