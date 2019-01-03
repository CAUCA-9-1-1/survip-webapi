using FluentValidation.TestHelper;
using Survi.Prevention.ServiceLayer.Import.Places;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.Places
{
    public class CountyImportValidatorTests
    {
        private readonly CountyValidator validator;

        public CountyImportValidatorTests()
        {
            validator = new CountyValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void IdRegionIsInvalidWhenNullEmpty(string idRegion)
        {
            validator.ShouldHaveValidationErrorFor(state => state.IdRegion, idRegion);
        }

        [Fact]
        public void IdRegionIsValidWhenItHasAValue()
        {
            validator.ShouldNotHaveValidationErrorFor(state => state.IdRegion, "CACO12");
        }
    }
}