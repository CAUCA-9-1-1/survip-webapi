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
	    public void IdIsValidWhenNotEmpty()
	    {
		    validator.ShouldNotHaveValidationErrorFor(genCode => genCode.Id, "IdGenericCode");
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("   ")]
	    [InlineData(null)]
	    public void IdIsNotValidWhenEmpty(string id)
	    {
		    validator.ShouldHaveValidationErrorFor(genCode => genCode.Id, id);
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
		    validator.ShouldNotHaveValidationErrorFor(genCode => genCode.Description, "Generic code");
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
