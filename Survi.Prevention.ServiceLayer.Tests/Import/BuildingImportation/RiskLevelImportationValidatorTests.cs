using Survi.Prevention.ServiceLayer.Import.BuildingImportation;
using Xunit;
using FluentValidation.TestHelper;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation
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
        [InlineData("")]
        [InlineData("   ")]
        public void ValidationFailWhenScianIsInvalid(string scian)
        {
            validator.ShouldHaveValidationErrorFor(code => code.Scian, scian);
        }
    }
}
