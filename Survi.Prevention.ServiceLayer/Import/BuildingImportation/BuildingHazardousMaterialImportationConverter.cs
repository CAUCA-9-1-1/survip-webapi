using System;
using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Import.Base;
using importedBuildingHazardousMaterial = Survi.Prevention.ApiClient.DataTransferObjects.BuildingHazardousMaterial;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
	public class BuildingHazardousMaterialImportationConverter : BaseEntityConverter<importedBuildingHazardousMaterial, BuildingHazardousMaterial>
	{
		public BuildingHazardousMaterialImportationConverter
			(IManagementContext context, 
			AbstractValidator<importedBuildingHazardousMaterial> validator) : base(context, validator, null)
		{
		}

		protected override void CopyCustomFieldsToEntity(importedBuildingHazardousMaterial importedObject, BuildingHazardousMaterial entity)
		{
			entity.IdBuilding = Guid.Parse(importedObject.IdBuilding);
			entity.IdHazardousMaterial = Guid.Parse(importedObject.IdHazardousMaterial);
			entity.IdUnitOfMeasure = ParseId(importedObject.IdUnitOfMeasure);

			entity.CapacityContainer = importedObject.CapacityContainer;
			entity.Container = importedObject.Container;
			entity.Floor = importedObject.Floor;
			entity.GasInlet = importedObject.GasInlet;
			entity.OtherInformation = importedObject.OtherInformation;
			entity.Place = importedObject.Place;
			entity.Quantity = importedObject.Quantity;
			entity.Sector = importedObject.Sector;
			entity.SecurityPerimeter = importedObject.SecurityPerimeter;
			entity.SupplyLine = importedObject.SupplyLine;
			entity.TankType = (StorageTankType)importedObject.TankType;
			entity.Wall = importedObject.Wall;
		}

		protected override void GetRealForeignKeys(importedBuildingHazardousMaterial importedObject)
		{
			importedObject.IdBuilding = GetRealId<Building>(importedObject.IdBuilding);
			importedObject.IdHazardousMaterial = GetRealId<HazardousMaterial>(importedObject.IdHazardousMaterial);
			importedObject.IdUnitOfMeasure = GetRealId<UnitOfMeasure>(importedObject.IdUnitOfMeasure);
		}
	}
}
