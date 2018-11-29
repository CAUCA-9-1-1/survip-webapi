using System;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators;
using Survi.Prevention.ServiceLayer.Tests.Mocks;
using Xunit;
using ImportedBuildingMat = Survi.Prevention.ApiClient.DataTransferObjects.BuildingHazardousMaterial;
using StorageTankType = Survi.Prevention.ApiClient.DataTransferObjects.StorageTankType;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation
{
	public class BuildingHazardousMaterialImportationConverterTests
	{
		private readonly ImportedBuildingMat imported;
		private readonly BuildingHazardousMaterial existing;

		public BuildingHazardousMaterialImportationConverterTests()
		{
			imported = new ImportedBuildingMat
			{
				Id = "importedBuildingHM1",
				CapacityContainer = 150,
				Container = "tank",
				Floor = "SS",
				GasInlet = "GasInlet",
				OtherInformation = "OtherInformation",
				Place = "Place",
				Quantity = 800,
				Sector = "SS",
				SecurityPerimeter = "SecurityPerimeter",
				SupplyLine = "SupplyLine",
				TankType = (StorageTankType)Models.Buildings.StorageTankType.Underground,
				Wall = "SS",
				IsActive = false,
				IdUnitOfMeasure = "mes001",
				IdHazardousMaterial = "hmtest1",
				IdBuilding = "idBuildingTest"
			};

			existing = new BuildingHazardousMaterial
			{
				Id = Guid.NewGuid(),
				CapacityContainer = 0,
				Container = "",
				Floor = "",
				GasInlet = "",
				OtherInformation = "",
				Place = "",
				Quantity = 0,
				Sector = "",
				SecurityPerimeter = "",
				SupplyLine = "",
				TankType = Models.Buildings.StorageTankType.Aboveground,
				Wall = "",
				IsActive = true,
				IdExtern = "importedBuildingHM1"
			};

		}

		private IManagementContext CreateMockContext()
		{
			var buildingMats = new List<BuildingHazardousMaterial> { existing };
			var mats = new List<HazardousMaterial> { new HazardousMaterial{IdExtern = "hmtest1", Id = Guid.NewGuid()} };
			var units = new List<UnitOfMeasure> { new UnitOfMeasure{ IdExtern = "mes001" } };
			var buildings = new List<Building> { new Building{ IdExtern = "idBuildingTest", Id = Guid.NewGuid()} };
			var mockCtx = new BaseContextMock();
			mockCtx.Setup(ctx => ctx.Set<BuildingHazardousMaterial>()).Returns(mockCtx.GetMockDbSet(buildingMats).Object);
			mockCtx.Setup(ctx => ctx.Set<HazardousMaterial>()).Returns(mockCtx.GetMockDbSet(mats).Object);
			mockCtx.Setup(ctx => ctx.Set<UnitOfMeasure>()).Returns(mockCtx.GetMockDbSet(units).Object);
			mockCtx.Setup(ctx => ctx.Set<Building>()).Returns(mockCtx.GetMockDbSet(buildings).Object);
			return mockCtx.Object;
		}

		[Fact]
		public void CustomFieldsAreCorrectlyCopied()
		{
			var validator = new BuildingHazardousMaterialImportationValidator();
			var converter = new BuildingHazardousMaterialImportationConverter(CreateMockContext(), validator);
			var result = converter.Convert(imported).Result;

			Assert.True(result.CapacityContainer == imported.CapacityContainer
						&& result.Container == imported.Container
						&& result.Floor == imported.Floor
						&& result.GasInlet == imported.GasInlet
						&& result.OtherInformation == imported.OtherInformation
						&& result.Place == imported.Place
						&& result.Quantity == imported.Quantity
						&& result.Sector == imported.Sector
						&& result.SecurityPerimeter == imported.SecurityPerimeter
						&& result.SupplyLine == imported.SupplyLine
						&& (int)result.TankType == (int)imported.TankType
						&& result.Wall == imported.Wall
						&& result.IsActive == imported.IsActive
						&& result.IdExtern == imported.Id);
		}
	}
}
