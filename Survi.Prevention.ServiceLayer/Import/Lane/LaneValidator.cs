using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.Lane
{
    public class LaneValidator: BaseImportValidator<ApiClient.DataTransferObjects.Lane>
    {
	    public LaneValidator()
	    {
		    RuleFor(m => m.IdCity).NotNullOrEmpty();
		    RuleFor(m => m.IdLaneGenericCode).NotNullOrEmpty();
		    RuleFor(m => m.IdPublicCode).NotNullOrEmpty();
	    }
    }
}
