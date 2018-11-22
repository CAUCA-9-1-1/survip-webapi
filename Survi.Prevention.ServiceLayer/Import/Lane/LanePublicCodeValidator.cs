using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.Lane
{
    public class LanePublicCodeValidator: AbstractValidator<LanePublicCode>
    {
	    public LanePublicCodeValidator()
	    {
		    RuleFor(m => m.Code).NotNullOrEmptyWithMaxLength(2);
		    RuleFor(m => m.Abbreviation).NotNullOrEmptyWithMaxLength(2);
		    RuleFor(m => m.Description).NotNullOrEmptyWithMaxLength(20);
	    }
    }
}
