using System;
using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Base;
using importedBuilding = Survi.Prevention.ApiClient.DataTransferObjects.Building;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
	public class BuildingImportationConverter : BaseLocalizableEntityWithPictureConverter<importedBuilding, Building, BuildingLocalization>
	{
		public BuildingImportationConverter(IManagementContext context, AbstractValidator<importedBuilding> validator) : base(context, validator)
		{
		}

		protected override void CopyCustomFieldsToEntity(importedBuilding importedObject, Building entity)
		{
			InitiateForeignKeyValues(importedObject, entity);
			InitiateCustomFieldsValues(importedObject, entity);
		}

		private void InitiateCustomFieldsValues(importedBuilding importedObject, Building entity)
		{
			entity.CivicNumber = importedObject.CivicNumber;
			entity.CivicLetter = importedObject.CivicLetter;
			entity.CivicSupp = importedObject.CivicSupp;
			entity.CivicLetterSupp = importedObject.CivicLetterSupp;
			entity.AppartmentNumber = importedObject.AppartmentNumber;
			entity.Floor = importedObject.Floor;
			entity.NumberOfFloor = importedObject.NumberOfFloor;
			entity.NumberOfAppartment = importedObject.NumberOfAppartment;
			entity.NumberOfBuilding = importedObject.NumberOfBuilding;
			entity.VacantLand = importedObject.VacantLand;
			entity.YearOfConstruction = importedObject.YearOfConstruction;
			entity.BuildingValue = importedObject.BuildingValue;
			entity.PostalCode = importedObject.PostalCode;
			entity.Suite = importedObject.Suite;
			entity.Source = importedObject.Source;
			entity.UtilisationDescription = importedObject.UtilisationDescription;
			entity.ShowInResources = importedObject.ShowInResources;
			entity.Matricule = importedObject.Matricule;
			entity.Coordinates = importedObject.WktCoordinates;
			entity.CoordinatesSource = importedObject.CoordinatesSource;
			entity.Details = importedObject.Details;
			entity.ChildType = (BuildingChildType) importedObject.ChildType;
		}

		private void InitiateForeignKeyValues(importedBuilding importedObject, Building entity)
		{
			entity.IdCity = Guid.Parse(importedObject.IdCity);
			entity.IdLane = Guid.Parse(importedObject.IdLane);
			entity.IdRiskLevel = Guid.Parse(importedObject.IdRiskLevel);
			entity.IdLaneTransversal = ParseId(importedObject.IdLaneTransversal);
			entity.IdParentBuilding = ParseId(importedObject.IdParentBuilding);
			entity.IdUtilisationCode = ParseId(importedObject.IdUtilisationCode);
			//entity.IdPicture = null;
		}


		protected override void GetRealForeignKeys(importedBuilding importedObject)
		{
			importedObject.IdCity = GetRealId<City>(importedObject.IdCity);
			importedObject.IdLane = GetRealId<Models.FireSafetyDepartments.Lane>(importedObject.IdLane);
			importedObject.IdRiskLevel = GetRealId<RiskLevel>(importedObject.IdRiskLevel);
			importedObject.IdLaneTransversal = GetRealId<Models.FireSafetyDepartments.Lane>(importedObject.IdLaneTransversal);
			importedObject.IdParentBuilding = GetRealId<Building>(importedObject.IdParentBuilding);		
			importedObject.IdUtilisationCode = GetRealId<UtilisationCode>(importedObject.IdUtilisationCode);
			//importedObject.IdPicture = null;
		}
	}
}
