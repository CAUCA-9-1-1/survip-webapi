using System;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators;
using Survi.Prevention.ServiceLayer.Tests.Mocks;
using Xunit;
using ImportedBuildingContact = Survi.Prevention.ApiClient.DataTransferObjects.BuildingContact;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation
{
    public class BuildingContactImportationConverterTests
    {
		private readonly ImportedBuildingContact imported;
		private readonly BuildingContact existing;

		public BuildingContactImportationConverterTests()
		{
			imported = new ImportedBuildingContact
			{
				Id = "importedBuildingContact1",
				FirstName = "Phil",
				LastName = "Robert",
				PhoneNumber = "4182152404",
				PhoneNumberExtension = "",
				CellphoneNumber = "",
				PagerCode = "",
				PagerNumber = "",
				OtherNumber = "",
				OtherNumberExtension = "",
				IsActive =  false,
				IdBuilding = "idBuildingTest"
			};

			existing = new BuildingContact
			{
				Id = Guid.NewGuid(),
				IdExtern = "importedBuildingContact1",
				FirstName = "Phil",
				LastName = "Robert",
				PhoneNumber = "4182152404",
				IdBuilding = Guid.NewGuid()
			};

		}

		private IManagementContext CreateMockContext()
		{
			var buildingContacts = new List<BuildingContact> { existing };
			var buildings = new List<Building> { new Building{ IdExtern = "idBuildingTest", Id = Guid.NewGuid()} };
			var mockCtx = new BaseContextMock();
			mockCtx.Setup(ctx => ctx.Set<BuildingContact>()).Returns(mockCtx.GetMockDbSet(buildingContacts).Object);
			mockCtx.Setup(ctx => ctx.Set<Building>()).Returns(mockCtx.GetMockDbSet(buildings).Object);
			return mockCtx.Object;
		}

		[Fact]
		public void CustomFieldsAreCorrectlyCopied()
		{
			var validator = new BuildingContactImportationValidator();
			var converter = new BuildingContactImportationConverter(CreateMockContext(), validator);
			var result = converter.Convert(imported).Result;

			Assert.True(result.CallPriority == imported.CallPriority
						&& result.CellphoneNumber == imported.CellphoneNumber
			            && result.FirstName == imported.FirstName
			            && result.LastName == imported.LastName
						&& result.IsOwner == imported.IsOwner
						&& result.OtherNumber == imported.OtherNumber
						&& result.OtherNumberExtension == imported.OtherNumberExtension
						&& result.PagerCode == imported.PagerCode
						&& result.PagerNumber == imported.PagerNumber
						&& result.PhoneNumber == imported.PhoneNumber
						&& result.PhoneNumberExtension == imported.PhoneNumberExtension	
						&& result.IsActive == imported.IsActive
						&& result.IdExtern == imported.Id);
		}
    }
}
