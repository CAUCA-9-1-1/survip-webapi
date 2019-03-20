using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.Lane
{
    public class LaneValidator: BaseImportWithLocalizationValidator<ApiClient.DataTransferObjects.Lane>
    {
	    public LaneValidator()
	    {
		    RuleFor(m => m.IdCity).RequiredKeyIsValid();
		    RuleFor(m => m.IdLaneGenericCode).RequiredKeyIsValid();
		    RuleFor(m => m.IdPublicCode).RequiredKeyIsValid();
	    }
    }
}
