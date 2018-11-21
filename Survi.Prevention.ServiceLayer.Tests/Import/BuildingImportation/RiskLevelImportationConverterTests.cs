using System;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators;
using Survi.Prevention.ServiceLayer.Tests.Mocks;
using Xunit;
using RiskLevel = Survi.Prevention.ApiClient.DataTransferObjects.RiskLevel;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation
{
    public class RiskLevelImportationConverterTests
    {
        private readonly RiskLevel imported;
        private readonly Models.Buildings.RiskLevel existing;

        public RiskLevelImportationConverterTests()
        {
            imported = new RiskLevel
            {
                Id = "imported1",
                ArgbColor = 100,
                Code = 100,
                Sequence = 100,
                IsActive = true,
                Localizations = new List<ApiClient.DataTransferObjects.Base.Localization>
                {
                    new ApiClient.DataTransferObjects.Base.Localization {Name = "Nom 1", LanguageCode = "en"},
                    new ApiClient.DataTransferObjects.Base.Localization {Name = "Name 1", LanguageCode = "fr"}
                }
            };

            existing = new Models.Buildings.RiskLevel
            {
                Id = Guid.NewGuid(),
                Color = "1",
                Code = 1,
                Sequence = 1,
                IsActive = true,
                IdExtern = "imported1"
            };
            existing.Localizations = new List<RiskLevelLocalization>
            {
                new RiskLevelLocalization
                    {Id = Guid.NewGuid(), LanguageCode = "en", Name = "existing Name", IdParent = existing.Id},
                new RiskLevelLocalization
                    {Id = Guid.NewGuid(), LanguageCode = "fr", Name = "existing Name", IdParent = existing.Id}
            };
        }

        private IManagementContext CreateMockContext()
        {
            var risks = new List<Models.Buildings.RiskLevel> { existing };
            var mockCtx = new BaseContextMock();
            mockCtx.Setup(ctx => ctx.Set<Models.Buildings.RiskLevel>()).Returns(mockCtx.GetMockDbSet(risks).Object);
            return mockCtx.Object;
        }

        [Fact]
        public void CustomFieldsAreCorrectlyCopied()
        {
            var validator = new RiskLevelImportationValidator();
            var converter = new RiskLevelImportationConverter(CreateMockContext(), validator);
            var result = converter.Convert(imported).Result;

            Assert.True(result.Sequence == imported.Sequence
                        && result.Color == imported.ArgbColor.ToString()
                        && result.Code == imported.Code);
        }
    }
}