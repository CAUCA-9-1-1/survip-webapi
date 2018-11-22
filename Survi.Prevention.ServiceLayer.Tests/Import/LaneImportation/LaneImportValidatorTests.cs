using FluentValidation.TestHelper;
using Survi.Prevention.ServiceLayer.Import.Lane;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.LaneImportation
{
    public class LaneImportValidatorTests
    {
	    private readonly LaneValidator validator;

	    public LaneImportValidatorTests()
	    {		    		    
		    validator = new LaneValidator();
	    }

	    [Fact]
	    public void IdCityIsValidWhenItHasAValue()
	    {
		    validator.ShouldNotHaveValidationErrorFor(lane => lane.IdCity, "IdCity");
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("   ")]
	    [InlineData(null)]
	    public void IdCityIsInvalidWhenNullOrEmpty(string idCity)
	    {
		    validator.ShouldHaveValidationErrorFor(lane => lane.IdCity, idCity);
	    }

	    [Fact]
	    public void IdPublicCodeIsValidWhenItHasAValue()
	    {
		    validator.ShouldNotHaveValidationErrorFor(lane => lane.IdPublicCode, "IdPublicCode");
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("   ")]
	    [InlineData(null)]
	    public void IdPublicCodeIsInvalidWhenNullOrEmpty(string idPublicCode)
	    {
		    validator.ShouldHaveValidationErrorFor(lane => lane.IdPublicCode, idPublicCode);
	    }

	    [Fact]
	    public void IdGenericCodeIsValidWhenItHasAValue()
	    {
		    validator.ShouldNotHaveValidationErrorFor(lane => lane.IdLaneGenericCode, "IdLaneGenericCode");
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("   ")]
	    [InlineData(null)]
	    public void IdGenericCodeIsInvalidWhenNullOrEmpty(string idGenericCode)
	    {
		    validator.ShouldHaveValidationErrorFor(lane => lane.IdLaneGenericCode, idGenericCode);
	    }
    }
}
