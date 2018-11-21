using Survi.Prevention.ServiceLayer.Import.Country;
using Xunit;
using FluentValidation.TestHelper;

namespace Survi.Prevention.ServiceLayer.Tests.Import.Country
{
    public class CountryImportValidatorTests
    {
	    private readonly CountryValidator validator;

	    public CountryImportValidatorTests()
	    {
			validator = new CountryValidator();
	    }

	    [Fact]
        public void IdCountryIsValidWhenItHasAValue()
	    {
	        validator.ShouldNotHaveValidationErrorFor(country => country.Id, "country008");
	    }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void IdCountryIsInvalidWhenNullEmptyOrTooLong(string idCountry)
        {
            validator.ShouldHaveValidationErrorFor(country => country.Id, idCountry);
        }

        [Fact]
        public void AlphaCode2IsValidWhenItHasAValue()
        {
            validator.ShouldNotHaveValidationErrorFor(country => country.CodeAlpha2, "QC");
        }
        
        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("WayTooLongCode")]
        [InlineData(null)]
        public void AlphaCode2IsInvalidWhenNullOrEmpty(string alphaCode2)
        {
            validator.ShouldHaveValidationErrorFor(country => country.CodeAlpha2, alphaCode2);
        }

        [Fact]
        public void AlphaCode3IsValidWhenItHasAValue()
        {
            validator.ShouldNotHaveValidationErrorFor(country => country.CodeAlpha3, "QCB");
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("WayTooLongCode")]
        [InlineData(null)]
        public void AlphaCode3IsInvalidWhenNullOrEmpty(string alphaCode2)
        {
            validator.ShouldHaveValidationErrorFor(country => country.CodeAlpha3, alphaCode2);
        }
    }
}
