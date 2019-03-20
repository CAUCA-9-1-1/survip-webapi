using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.Places
{
    public class RegionValidator: BaseImportWithLocalizationValidator<ApiClient.DataTransferObjects.Region>
    {
	    public RegionValidator()
	    {
		    RuleFor(m => m.Code)
			    .NotNullOrEmptyWithMaxLength(10);

		    RuleFor(m => m.IdState)
			    .RequiredKeyIsValid();
	    }
    }
}
