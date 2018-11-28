using System;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation.CustomFieldsCopiers;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators;
using Survi.Prevention.ServiceLayer.Tests.Mocks;
using Xunit;
using ImportedBuilding = Survi.Prevention.ApiClient.DataTransferObjects.Building;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation
{
    public class BuildingImportationConverterTests
    {
		private readonly ImportedBuilding imported;
		private readonly Building existing;

		public BuildingImportationConverterTests()
		{
			imported = new ImportedBuilding
			{
				Id = "importedBuilding1",
				IdCity = "idCity1",
				IdLane = "idLane1",
				IdRiskLevel = "idRiskLevel1",
				CivicNumber = "civicNumber",
				CivicLetter = "",
				CivicSupp = "",
				CivicLetterSupp = "",
				AppartmentNumber = "",
				Floor = "",
				NumberOfFloor = 0,
				NumberOfAppartment = 0,
				NumberOfBuilding = 0,
				VacantLand = false,
				YearOfConstruction = 2018,
				BuildingValue = 1800000,
				PostalCode = "",
				Suite = 0,
				Source = "",
				UtilisationDescription = "",
				ShowInResources = true,
				Matricule = "",
				WktCoordinates = "",
				CoordinatesSource = "",
				Details = "",
				ChildType = ApiClient.DataTransferObjects.BuildingChildType.None,
				PictureData = new byte[100],
				MimeType = "png",
				IsActive =  false
			};
			imported.Localizations = new List<ApiClient.DataTransferObjects.Base.Localization>
			{
				new ApiClient.DataTransferObjects.Base.Localization{LanguageCode = "en", Name = "Building 1"},
				new ApiClient.DataTransferObjects.Base.Localization{LanguageCode = "fr", Name = "Bâtiment 1"}
			};

			existing = new Building
			{
				Id = Guid.NewGuid(),
				IdExtern = "importedBuilding1",

			};

		}

		private IManagementContext CreateMockContext()
		{
			var buildings = new List<Building> { existing };
			var mockCtx = new BaseContextMock();
			mockCtx.Setup(ctx => ctx.Set<RiskLevel>()).Returns(mockCtx.GetMockDbSet(new List<RiskLevel> { new RiskLevel{IdExtern = "idRiskLevel1", Id = Guid.NewGuid()} }).Object);
			mockCtx.Setup(ctx => ctx.Set<Lane>()).Returns(mockCtx.GetMockDbSet(new List<Lane> { new Lane{IdExtern = "idLane1", Id = Guid.NewGuid()} }).Object);
			mockCtx.Setup(ctx => ctx.Set<City>()).Returns(mockCtx.GetMockDbSet(new List<City> { new City{IdExtern = "idCity1", Id = Guid.NewGuid()} }).Object);
			mockCtx.Setup(ctx => ctx.Set<Building>()).Returns(mockCtx.GetMockDbSet(buildings).Object);
			return mockCtx.Object;
		}

		[Fact]
		public void CustomFieldsAreCorrectlyCopied()
		{
			var validator = new BuildingImportationValidator();
			var converter = new BuildingImportationConverter(CreateMockContext(), validator, new BuildingCustomFieldsCopier());
			var result = converter.Convert(imported).Result;

			Assert.True(result.CivicNumber == imported.CivicNumber && 
			            result.CivicLetter == imported.CivicLetter &&
			            result.CivicSupp == imported.CivicSupp &&
						result.CivicLetterSupp == imported.CivicLetterSupp &&
						result.AppartmentNumber == imported.AppartmentNumber &&
						result.Floor == imported.Floor &&
						result.NumberOfFloor == imported.NumberOfFloor &&
						result.NumberOfAppartment == imported.NumberOfAppartment &&
						result.NumberOfBuilding == imported.NumberOfBuilding &&
						result.VacantLand == imported.VacantLand &&
						result.YearOfConstruction == imported.YearOfConstruction &&
						result.BuildingValue == imported.BuildingValue &&
						result.PostalCode == imported.PostalCode &&
						result.Suite == imported.Suite &&
						result.Source == imported.Source &&
						result.UtilisationDescription == imported.UtilisationDescription &&
						result.ShowInResources == imported.ShowInResources &&
						result.Matricule == imported.Matricule &&
						result.Coordinates == imported.WktCoordinates &&
						result.CoordinatesSource == imported.CoordinatesSource &&
						result.Details == imported.Details &&
						result.ChildType == (BuildingChildType) imported.ChildType);
		}
    }
}
