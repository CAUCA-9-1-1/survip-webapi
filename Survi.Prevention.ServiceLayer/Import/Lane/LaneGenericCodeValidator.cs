using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.Lane
{
    public class LaneGenericCodeValidator : AbstractValidator<LaneGenericCode>
    {
	    public LaneGenericCodeValidator()
	    {
		    RuleFor(m => m.Id).NotNullOrEmpty();
		    RuleFor(m => m.Code).NotNullOrEmptyWithMaxLength(1);
		    RuleFor(m => m.Description).NotNullMaxLength(15);
	    }
    }
}
