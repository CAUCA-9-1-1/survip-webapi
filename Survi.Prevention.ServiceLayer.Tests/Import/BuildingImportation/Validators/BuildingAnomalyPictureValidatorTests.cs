using FluentValidation.TestHelper;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation.Validators
{
    public class BuildingAnomalyPictureValidatorTests
    {
        private readonly BuildingAnomalyPictureImportationValidator validator;

        public BuildingAnomalyPictureValidatorTests()
        {
            validator = new BuildingAnomalyPictureImportationValidator();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ValidationFailWhenIdBuildingAnomalyIsInvalid(string idBuildingAnomaly)
        {
            validator.ShouldHaveValidationErrorFor(code => code.IdBuildingAnomaly, idBuildingAnomaly);
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