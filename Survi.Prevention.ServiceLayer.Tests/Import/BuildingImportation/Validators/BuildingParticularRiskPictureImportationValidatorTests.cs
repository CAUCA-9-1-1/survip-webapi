using FluentValidation.TestHelper;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation.Validators
{
    public class BuildingParticularRiskPictureImportationValidatorTests
    {
        private readonly BuildingParticularRiskPictureImportationValidator validator;

        public BuildingParticularRiskPictureImportationValidatorTests()
        {
            validator = new BuildingParticularRiskPictureImportationValidator();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ValidationFailWhenIdBuildingParticularRiskIsInvalid(string idBuildingParticularRisk)
        {
            validator.ShouldHaveValidationErrorFor(code => code.IdBuildingParticularRisk, idBuildingParticularRisk);
        }

        [Fact]
        public void ValidationFailWhenPictureDataIsNotSet()
        {
            validator.ShouldHaveValidationErrorFor(risk => risk.PictureData, null as byte[]);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ValidationFailWhenMimeTypeIsNotSet(string mimeType)
        {
            validator.ShouldHaveValidationErrorFor(risk => risk.MimeType, mimeType);
        }
    }
}