using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.Lane
{
    public class LaneGenericCodeValidator : AbstractValidator<LaneGenericCode>
    {
	    public LaneGenericCodeValidator()
	    {
		    RuleFor(m => m.Code).NotNullOrEmptyWithMaxLength(2);
		    RuleFor(m => m.Description).NotNullOrEmptyWithMaxLength(20);
	    }
    }
}
