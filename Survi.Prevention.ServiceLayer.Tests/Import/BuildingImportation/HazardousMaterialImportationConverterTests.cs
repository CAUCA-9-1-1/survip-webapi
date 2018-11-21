using System;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators;
using Survi.Prevention.ServiceLayer.Tests.Mocks;
using Xunit;
using ImportedMat = Survi.Prevention.ApiClient.DataTransferObjects.HazardousMaterial;
using DataMat = Survi.Prevention.Models.Buildings.HazardousMaterial;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation
{
    public class HazardousMaterialImportationConverterTests
    {
        private readonly ImportedMat imported;
        private readonly DataMat existing;

        public HazardousMaterialImportationConverterTests()
        {
            imported = new ImportedMat
            {
                Id = "imported1",
                GuideNumber = "ABC",
                Number = "123",
                ReactToWater = true,
                ToxicInhalationHazard = true,
                IsActive = true,
                Localizations = new List<ApiClient.DataTransferObjects.Base.Localization>
                {
                    new ApiClient.DataTransferObjects.Base.Localization {Name = "Nom 1", LanguageCode = "en"},
                    new ApiClient.DataTransferObjects.Base.Localization {Name = "Name 1", LanguageCode = "fr"}
                }
            };

            existing = new DataMat
            {
                Id = Guid.NewGuid(),
                GuideNumber = "CDE",
                Number = "456",
                ReactToWater = false,
                ToxicInhalationHazard = false,
                IsActive = true,
                IdExtern = "imported1"
            };
            existing.Localizations = new List<HazardousMaterialLocalization>
            {
                new HazardousMaterialLocalization
                    {Id = Guid.NewGuid(), LanguageCode = "en", Name = "existing Name", IdParent = existing.Id},
                new HazardousMaterialLocalization
                    {Id = Guid.NewGuid(), LanguageCode = "fr", Name = "existing Name", IdParent = existing.Id}
            };
        }

        private IManagementContext CreateMockContext()
        {
            var mats = new List<DataMat> {existing};
            var mockCtx = new BaseContextMock();
            mockCtx.Setup(ctx => ctx.Set<DataMat>()).Returns(mockCtx.GetMockDbSet(mats).Object);
            return mockCtx.Object;
        }

        [Fact]
        public void CustomFieldsAreCorrectlyCopied()
        {
            var validator = new HazardousMaterialImportationValidator();
            var converter = new HazardousMaterialImportationConverter(CreateMockContext(), validator);
            var result = converter.Convert(imported).Result;

            Assert.True(result.GuideNumber == imported.GuideNumber
                        && result.Number == imported.Number
                        && result.ReactToWater == imported.ReactToWater
                        && result.ToxicInhalationHazard == imported.ToxicInhalationHazard);
        }
    }
}
