using FluentValidation.TestHelper;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation.Validators
{
    public class UtilisationCodeImportationValidatorTests
    {
        private readonly UtilisationCodeImportationValidator validator;

        public UtilisationCodeImportationValidatorTests()
        {
            validator = new UtilisationCodeImportationValidator();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ValidationFailWhenCubfIsInvalid(string cubf)
        {
            validator.ShouldHaveValidationErrorFor(code => code.Cubf, cubf);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("012345678901234567890123456789")]
        public void ValidationFailWhenScianIsInvalid(string scian)
        {
            validator.ShouldHaveValidationErrorFor(code => code.Scian, scian);
        }
    }
}
