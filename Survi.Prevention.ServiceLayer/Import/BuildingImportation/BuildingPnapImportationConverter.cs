using System;
using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Import.Base;
using importedBuildingPnap = Survi.Prevention.ApiClient.DataTransferObjects.BuildingPersonRequiringAssistance;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
	public class
		BuildingPnapImportationConverter : BaseEntityConverter<importedBuildingPnap, BuildingPersonRequiringAssistance>
	{
		public BuildingPnapImportationConverter(IManagementContext context,
			AbstractValidator<importedBuildingPnap> validator) : base(context, validator, null)
		{
		}

		protected override void CopyCustomFieldsToEntity(importedBuildingPnap importedObject,
			BuildingPersonRequiringAssistance entity)
		{
			entity.IdBuilding = Guid.Parse(importedObject.IdBuilding);
			entity.IdPersonRequiringAssistanceType = Guid.Parse(importedObject.IdPersonRequiringAssistanceType);

			entity.ContactName = importedObject.ContactName;
			entity.ContactPhoneNumber = importedObject.ContactPhoneNumber;
			entity.DayIsApproximate = importedObject.DayIsApproximate;
			entity.DayResidentCount = importedObject.DayResidentCount;
			entity.EveningIsApproximate = importedObject.EveningIsApproximate;
			entity.Description = importedObject.Description;
			entity.EveningResidentCount = importedObject.EveningResidentCount;
			entity.Floor = importedObject.Floor;
			entity.NightIsApproximate = importedObject.NightIsApproximate;
			entity.NightResidentCount = importedObject.NightResidentCount;
			entity.Local = importedObject.Local;
			entity.PersonName = importedObject.PersonName;
		}

		protected override void GetRealForeignKeys(importedBuildingPnap importedObject)
		{
			importedObject.IdBuilding = GetRealId<Building>(importedObject.IdBuilding);
			importedObject.IdPersonRequiringAssistanceType =
				GetRealId<PersonRequiringAssistanceType>(importedObject.IdPersonRequiringAssistanceType);
		}
	}
}
