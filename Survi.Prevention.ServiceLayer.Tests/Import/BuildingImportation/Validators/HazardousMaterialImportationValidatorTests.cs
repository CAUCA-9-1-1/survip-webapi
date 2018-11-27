using FluentValidation.TestHelper;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation
{
    public class HazardousMaterialImportationValidatorTests
    {
        private readonly HazardousMaterialImportationValidator validator;

        public HazardousMaterialImportationValidatorTests()
        {
            validator = new HazardousMaterialImportationValidator();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ValidationFailWhenGuideNumberIsInvalid(string guideNumber)
        {
            validator.ShouldHaveValidationErrorFor(mat => mat.GuideNumber, guideNumber);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ValidationFailWhenNumberIsInvalid(string number)
        {
            validator.ShouldHaveValidationErrorFor(mat => mat.Number, number);
        }
    }
}