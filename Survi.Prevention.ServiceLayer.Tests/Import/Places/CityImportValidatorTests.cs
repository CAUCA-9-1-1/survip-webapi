using FluentValidation.TestHelper;
using Survi.Prevention.ServiceLayer.Import.Places;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.Places
{
    public class CityImportValidatorTests
    {
	    private readonly CityValidator validator;

	    public CityImportValidatorTests()
	    {
		    validator = new CityValidator();
	    }

	    [Theory]
	    [InlineData(null)]
	    [InlineData("")]
	    [InlineData("   ")]
	    public void ValidationFailWhenCubfIsInvalid(string code)
	    {
		    validator.ShouldHaveValidationErrorFor(cityCode => cityCode.Code, code);
	    }

	    [Theory]
	    [InlineData(null)]
	    [InlineData("")]
	    [InlineData("   ")]
	    public void ValidationFailWhenScianIsInvalid(string code3)
	    {
		    validator.ShouldHaveValidationErrorFor(cityCode => cityCode.Code3Letters, code3);
	    }
    }
}
