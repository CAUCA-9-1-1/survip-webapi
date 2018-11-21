using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.Places
{
    public class StateValidator: BaseImportValidator<ApiClient.DataTransferObjects.State>
    {
	    public StateValidator()
	    {
	        RuleFor(m => m.AnsiCode)
	            .NotNullOrEmptyWithMaxLength(2);

		    RuleFor(m => m.IdCountry)
			    .NotNullOrEmpty();
	    }
    }
}
