using FluentValidation.TestHelper;
using Survi.Prevention.ServiceLayer.Import.FireSafetyDepartment;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.FireSafetyDepartment
{
    public class FireSafetyDepartmentCityServingValidatorTests
    {
	    private readonly FireSafetyDepartmentCityServingValidator validator;

	    public FireSafetyDepartmentCityServingValidatorTests()
	    {		    		    
		    validator = new FireSafetyDepartmentCityServingValidator();
	    }

	    [Fact]
	    public void IdCityIsValidWhenItHasAValue()
	    {
		    validator.ShouldNotHaveValidationErrorFor(fireDeptCityServing => fireDeptCityServing.IdCity, "CAUCA21092005-10");
	    }

	    [Fact]
	    public void IdFireSafetyDepartmentIsValidWhenItHasAValue()
	    {
		    validator.ShouldNotHaveValidationErrorFor(fireDeptCityServing => fireDeptCityServing.IdFireSafetyDepartment, "CAUCA21092005-10");
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("   ")]
	    [InlineData(null)]
	    public void IdCityIsInvalidWhenNullOrEmpty(string idCity)
	    {
		    validator.ShouldHaveValidationErrorFor(fireSafetyDepartment => fireSafetyDepartment.IdCity, idCity);
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("   ")]
	    [InlineData(null)]
	    public void IdFireSafetyDepartmentIsInvalidWhenNullOrEmpty(string idFireSafetyDepartment)
	    {
		    validator.ShouldHaveValidationErrorFor(fireSafetyDepartment => fireSafetyDepartment.IdFireSafetyDepartment, idFireSafetyDepartment);
	    }
    }
}
