using System;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators;
using Survi.Prevention.ServiceLayer.Tests.Mocks;
using Xunit;
using ImportedBuildingPnap = Survi.Prevention.ApiClient.DataTransferObjects.BuildingPersonRequiringAssistance;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation
{
    public class BuildingPnapImportationConverterTests
    {
		private readonly ImportedBuildingPnap imported;
		private readonly BuildingPersonRequiringAssistance existing;

		public BuildingPnapImportationConverterTests()
		{
			imported = new ImportedBuildingPnap
			{
				Id = "importedBuildingPnap1",
				ContactName = "",
				ContactPhoneNumber = "",
				DayIsApproximate = false,
				DayResidentCount = 0,
				Description = "",
				EveningIsApproximate = false,
				EveningResidentCount = 0,
				Floor = "",
				Local = "",
				NightIsApproximate = false,
				NightResidentCount = 0,
				PersonName = "",
				IsActive = false,
				IdPersonRequiringAssistanceType = "idPnapTypeTest",
				IdBuilding = "idBuildingTest"
			};

			existing = new BuildingPersonRequiringAssistance
			{
				Id = Guid.NewGuid(),
				IsActive = true,
				IdExtern = "importedBuildingPnap1"
			};

		}

		private IManagementContext CreateMockContext()
		{
			var buildingPnaps = new List<BuildingPersonRequiringAssistance> { existing };
			var pnapTypes = new List<PersonRequiringAssistanceType> { new PersonRequiringAssistanceType{IdExtern = "idPnapTypeTest", Id = Guid.NewGuid()} };
			var buildings = new List<Building> { new Building{ IdExtern = "idBuildingTest", Id = Guid.NewGuid()} };
			var mockCtx = new BaseContextMock();
			mockCtx.Setup(ctx => ctx.Set<BuildingPersonRequiringAssistance>()).Returns(mockCtx.GetMockDbSet(buildingPnaps).Object);
			mockCtx.Setup(ctx => ctx.Set<PersonRequiringAssistanceType>()).Returns(mockCtx.GetMockDbSet(pnapTypes).Object);
			mockCtx.Setup(ctx => ctx.Set<Building>()).Returns(mockCtx.GetMockDbSet(buildings).Object);
			return mockCtx.Object;
		}

		[Fact]
		public void CustomFieldsAreCorrectlyCopied()
		{
			var validator = new BuildingPnapImportationValidator();
			var converter = new BuildingPnapImportationConverter(CreateMockContext(), validator);
			var result = converter.Convert(imported).Result;

			Assert.True(result.DayResidentCount == imported.DayResidentCount
						&& result.EveningResidentCount == imported.EveningResidentCount
						&& result.NightResidentCount == imported.NightResidentCount
						&& result.DayIsApproximate == imported.DayIsApproximate
						&& result.EveningIsApproximate == imported.EveningIsApproximate
						&& result.NightIsApproximate == imported.NightIsApproximate
						&& result.Description == imported.Description
						&& result.PersonName == imported.PersonName
						&& result.Floor == imported.Floor
						&& result.Local == imported.Local
						&& result.ContactName == imported.ContactName
			            && result.ContactPhoneNumber == imported.ContactPhoneNumber
						&& result.IsActive == imported.IsActive
						&& result.IdExtern == imported.Id);
		}
    }
}
