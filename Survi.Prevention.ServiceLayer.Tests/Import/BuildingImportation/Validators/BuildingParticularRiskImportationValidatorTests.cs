using FluentValidation.TestHelper;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation.Validators
{
    public class BuildingParticularRiskImportationValidatorTests
    {
        private readonly BuildingParticularRiskImportationValidator validator;

        public BuildingParticularRiskImportationValidatorTests()
        {
            validator = new BuildingParticularRiskImportationValidator();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ValidationFailWhenIdBuildingIsInvalid(string idBuilding)
        {
            validator.ShouldHaveValidationErrorFor(code => code.IdBuilding, idBuilding);
        }

        [Fact]
        public void ValidationFailWhenRiskTypeIsUnknown()
        {
            validator.ShouldHaveValidationErrorFor(m => m.RiskType, (ParticularRiskType) 10);
        }

        [Fact]
        public void ValidationFailWhenFloorIsTooLong()
        {
            validator.ShouldHaveValidationErrorFor(m => m.Dimension, new string('.', 101));
        }

        [Fact]
        public void ValidationFailWhenWallIsTooLong()
        {
            validator.ShouldHaveValidationErrorFor(m => m.Wall, new string('.', 16));
        }

        [Fact]
        public void ValidationFailWhenSectorIsTooLong()
        {
            validator.ShouldHaveValidationErrorFor(m => m.Sector, new string('.', 16));
        }
    }
}