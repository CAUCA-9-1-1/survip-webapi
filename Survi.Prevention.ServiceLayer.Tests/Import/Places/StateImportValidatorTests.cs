using FluentValidation.TestHelper;
using Survi.Prevention.ServiceLayer.Import.Places;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.Places
{
    public class StateImportValidatorTests
    {
	    private readonly StateValidator validator;

	    public StateImportValidatorTests()
	    {		    		    
			validator = new StateValidator();
	    }

        [Fact]
        public void AnsiCodeIsValidWhenItHasAValue()
        {
            validator.ShouldNotHaveValidationErrorFor(state => state.AnsiCode, "CA");
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void AnsiCodeIsInvalidWhenNullEmptyOrTooLong(string ansiCode)
        {
            validator.ShouldHaveValidationErrorFor(state => state.AnsiCode, ansiCode);
        }

        [Fact]
        public void IdCountryIsValidWhenItHasAValue()
        {
            validator.ShouldNotHaveValidationErrorFor(state => state.IdCountry, "CA");
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void IdCountryIsInvalidWhenNullOrEmpty(string idCountry)
        {
            validator.ShouldHaveValidationErrorFor(state => state.IdCountry, idCountry);
        }
    }
}