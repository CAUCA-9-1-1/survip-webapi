using System;
using System.Linq;
using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Import.Base;
using Survi.Prevention.Models.FireSafetyDepartments;
using ImportedRegion = Survi.Prevention.ApiClient.DataTransferObjects.Region;

namespace Survi.Prevention.ServiceLayer.Import.Places
{
	public class RegionImportationConverter : BaseLocalizableEntityConverter<ImportedRegion, Region, RegionLocalization>
	{
		public RegionImportationConverter(IManagementContext context, AbstractValidator<ImportedRegion> validator)
			: base(context, validator)
		{
		}

		protected override void CopyCustomFieldsToEntity(ImportedRegion importedObject, Region entity)
		{
			entity.IdState = Guid.Parse(importedObject.IdState);
			entity.Code = importedObject.Code;
		}

		protected override void GetRealForeignKeys(ImportedRegion importedObject)
		{
			var idState = Context.Set<State>()
				.FirstOrDefault(state => state.IdExtern == importedObject.IdState)?.Id;
			importedObject.IdState = idState.HasValue ? idState.ToString() : null;
		}
	}
}
