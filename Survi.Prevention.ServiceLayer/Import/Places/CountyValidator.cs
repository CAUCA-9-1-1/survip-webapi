using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.Places
{
    public class CountyValidator: BaseImportValidator<ApiClient.DataTransferObjects.County>
    {
	    public CountyValidator()
	    {
		    RuleFor(m => m.IdRegion)
			    .NotNullOrEmpty();

		    RuleFor(m => m.IdState)
			    .NotNullOrEmpty();

	    }
    }
}
