using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.Lane
{
    public class LanePublicCodeValidator: AbstractValidator<LanePublicCode>
    {
	    public LanePublicCodeValidator()
	    {
		    RuleFor(m => m.Id).NotNullOrEmpty();
		    RuleFor(m => m.Code).NotNullOrEmptyWithMaxLength(2);
		    RuleFor(m => m.Abbreviation).NotNullMaxLength(2);
		    RuleFor(m => m.Description).NotNullMaxLength(20);
	    }
    }
}
