using FluentValidation;
using FluentValidation.TestHelper;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.Lane;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.LaneImportation
{
    public class LaneGenericCodeImportValidatorTests: AbstractValidator<LaneGenericCode>
    {
	    private readonly LaneGenericCodeValidator validator;

	    public LaneGenericCodeImportValidatorTests()
	    {		    		    
		    validator = new LaneGenericCodeValidator();
	    }

		[Fact]
	    public void CodeIsValidWhenNotEmpty()
	    {
		    validator.ShouldNotHaveValidationErrorFor(genCode => genCode.Code, "1");
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("   ")]
	    [InlineData(null)]
	    [InlineData("CodeTooLong")]
	    public void CodeIsInvalidWhenNullEmptyOrTooLong(string code)
	    {
		    validator.ShouldHaveValidationErrorFor(genCode => genCode.Code, code);
	    }

	    [Fact]
	    public void DescriptionIsValidWhenNotEmpty()
	    {
		    validator.ShouldNotHaveValidationErrorFor(genCode => genCode.Description, "lane generic code");
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("   ")]
	    [InlineData(null)]
	    [InlineData("TooLongDescriptionToValidate")]
	    public void DescriptionIsInvalidWhenNullEmptyOrTooLong(string description)
	    {
		    validator.ShouldHaveValidationErrorFor(genCode => genCode.Description, description);
	    }
    }
}
