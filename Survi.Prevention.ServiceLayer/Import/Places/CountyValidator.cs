using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.Places
{
    public class CountyValidator: BaseImportWithLocalizationValidator<ApiClient.DataTransferObjects.County>
    {
	    public CountyValidator()
	    {
		    RuleFor(m => m.IdRegion)
			    .RequiredKeyIsValid();
	    }
    }
}
