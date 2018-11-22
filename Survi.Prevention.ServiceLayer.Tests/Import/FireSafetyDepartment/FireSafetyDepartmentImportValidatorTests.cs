using FluentValidation.TestHelper;
using Survi.Prevention.ServiceLayer.Import.FireSafetyDepartment;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.FireSafetyDepartment
{
    public class FireSafetyDepartmentImportValidatorTests
    {
	    private readonly FireSafetyDepartmentValidator validator;

	    public FireSafetyDepartmentImportValidatorTests()
	    {		    		    
		    validator = new FireSafetyDepartmentValidator();
	    }

	    [Fact]
	    public void LanguageIsValidWhenItHasAValue()
	    {
		    validator.ShouldNotHaveValidationErrorFor(state => state.Language, "fr");
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("   ")]
	    [InlineData(null)]
	    public void LanguageIsInvalidWhenNullEmptyOrTooLong(string language)
	    {
		    validator.ShouldHaveValidationErrorFor(fireSafetyDepartment => fireSafetyDepartment.Language, language);
	    }

	    [Fact]
	    public void IdCountryIsValidWhenItHasAValue()
	    {
		    validator.ShouldNotHaveValidationErrorFor(fireSafetyDepartment => fireSafetyDepartment.IdCounty, "CAUCA21092005-10");
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("   ")]
	    [InlineData(null)]
	    public void IdCountryIsInvalidWhenNullOrEmpty(string idCounty)
	    {
		    validator.ShouldHaveValidationErrorFor(fireSafetyDepartment => fireSafetyDepartment.IdCounty, idCounty);
	    }
    }
}
