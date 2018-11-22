using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.FireSafetyDepartment
{
    public class FireSafetyDepartmentCityServingValidator : AbstractValidator<FireSafetyDepartmentCityServing>
    {
	    public FireSafetyDepartmentCityServingValidator()
	    {
		    RuleFor(m => m.IdCity).NotNullOrEmpty();
		    RuleFor(m => m.IdFireSafetyDepartment).NotNullOrEmpty();
	    }
    }
}
