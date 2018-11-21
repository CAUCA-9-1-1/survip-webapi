using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.Places
{
    public class CountryValidator: BaseImportValidator<ApiClient.DataTransferObjects.Country>
    {
	    public CountryValidator()
	    {
		    RuleFor(m => m.CodeAlpha2)
			    .NotNullOrEmptyWithMaxLength(2);

		    RuleFor(m => m.CodeAlpha3)
		        .NotNullOrEmptyWithMaxLength(3);
	    }
    }
}
