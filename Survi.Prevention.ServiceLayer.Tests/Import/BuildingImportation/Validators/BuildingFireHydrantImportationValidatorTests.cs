using FluentValidation.TestHelper;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation.Validators
{
    public class BuildingFireHydrantImportationValidatorTests
    {
        private readonly BuildingFireHydrantImportationValidator validator;

        public BuildingFireHydrantImportationValidatorTests()
        {
            validator = new BuildingFireHydrantImportationValidator();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("00000000-0000-0000-0000-000000000000")]
        public void ValidationFailWhenIdBuildingIsInvalid(string idBuilding)
        {
            validator.ShouldHaveValidationErrorFor(code => code.IdBuilding, idBuilding);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("00000000-0000-0000-0000-000000000000")]
        public void ValidationFailWhenIdFireHydrantIsInvalid(string id)
        {
            validator.ShouldHaveValidationErrorFor(code => code.IdFireHydrant, id);
        }
    }
}