using System;
using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Import.Base;
using importedLane = Survi.Prevention.ApiClient.DataTransferObjects.Lane;
using Survi.Prevention.Models.FireSafetyDepartments;
using System.Linq;

namespace Survi.Prevention.ServiceLayer.Import.Lane
{
	public class LaneImportationConverter : BaseLocalizableEntityConverter<importedLane, Models.FireSafetyDepartments.Lane, LaneLocalization>
	{
		public LaneImportationConverter(IManagementContext context, AbstractValidator<importedLane> validator)
			: base(context, validator)
		{
		}

		protected override void CopyCustomFieldsToEntity(importedLane importedObject, Models.FireSafetyDepartments.Lane entity)
		{
			entity.IsValid = importedObject.IsValid;
			entity.IdCity = Guid.Parse(importedObject.IdCity);
			entity.IdPublicCode = Guid.Parse(importedObject.IdCity);
			entity.IdLaneGenericCode = Guid.Parse(importedObject.IdCity);
		}

		protected override void GetRealForeignKeys(importedLane importedObject)
		{
			GetCityForeignKey(importedObject);
			GetLanePublicCodeForeignKey(importedObject);
			GetLaneGenericCodeForeignKey(importedObject);
		}

		private void GetCityForeignKey(importedLane importedObject)
		{
			var idCity = Context.Set<City>()
				.FirstOrDefault(country => country.IdExtern == importedObject.IdCity)?.Id;
			importedObject.IdCity = idCity.HasValue ? idCity.ToString() : null;
		}
		private void GetLanePublicCodeForeignKey(importedLane importedObject)
		{
			var idLanePublicCode = Context.Set<LanePublicCode>()
				.FirstOrDefault(country => country.IdExtern == importedObject.IdPublicCode)?.Id;
			importedObject.IdPublicCode = idLanePublicCode.HasValue ? idLanePublicCode.ToString() : null;
		}
		private void GetLaneGenericCodeForeignKey(importedLane importedObject)
		{
			var idLaneGenericCode = Context.Set<LaneGenericCode>()
				.FirstOrDefault(country => country.IdExtern == importedObject.IdLaneGenericCode)?.Id;
			importedObject.IdLaneGenericCode = idLaneGenericCode.HasValue ? idLaneGenericCode.ToString() : null;
		}
	}
}
