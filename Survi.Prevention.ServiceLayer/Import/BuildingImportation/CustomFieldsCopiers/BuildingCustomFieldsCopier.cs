using System;
using importedBuilding = Survi.Prevention.ApiClient.DataTransferObjects.Building;
using Survi.Prevention.Models.Base;
using Survi.Prevention.ServiceLayer.Import.Base;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.CustomFieldsCopiers
{
	public class BuildingCustomFieldsCopier : BaseCustomFieldsCopierWithPicture<importedBuilding, Building>
	{
		protected override void CopyValues(importedBuilding importedObject, Building entity)
		{
			InitiateForeignKeyValues(importedObject, entity);
			InitiateCustomFieldsValues(importedObject, entity);
		}

		protected override void CreatePictureWhenNeeded(importedBuilding importedObject, Building entity)
		{
			if (entity.Picture == null && importedObject.PictureData != null)
			{
				entity.Picture = new Models.Picture();
			}
		}

		protected override BasePicture GetEntityPicture(Building entity)
		{
			return entity.Picture;
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
		    entity.AliasName = importedObject.AliasName;
		    entity.CorporateName = importedObject.CorporateName;
		}

		private void InitiateForeignKeyValues(importedBuilding importedObject, Building entity)
		{
			entity.IdCity = Guid.Parse(importedObject.IdCity);
			entity.IdLane = Guid.Parse(importedObject.IdLane);
			entity.IdRiskLevel = Guid.Parse(importedObject.IdRiskLevel);
			entity.IdLaneTransversal = ParseId(importedObject.IdLaneTransversal);
			entity.IdParentBuilding = ParseId(importedObject.IdParentBuilding);
			entity.IdUtilisationCode = ParseId(importedObject.IdUtilisationCode);
		}
	}
}
