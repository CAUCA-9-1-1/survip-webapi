using FluentValidation.TestHelper;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation.Validators
{
    public class BuildingAnomalyImportationValidatorTests
    {
        private readonly BuildingAnomalyImportationValidator validator;

        public BuildingAnomalyImportationValidatorTests()
        {
            validator = new BuildingAnomalyImportationValidator();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ValidationFailWhenIdBuildingIsInvalid(string idBuilding)
        {
            validator.ShouldHaveValidationErrorFor(code => code.IdBuilding, idBuilding);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ValidationFailWhenThemeIsInvalid(string theme)
        {
            validator.ShouldHaveValidationErrorFor(code => code.Theme, theme);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ValidationFailWhenNotesAreInvalid(string notes)
        {
            validator.ShouldHaveValidationErrorFor(code => code.Theme, notes);
        }
    }
}