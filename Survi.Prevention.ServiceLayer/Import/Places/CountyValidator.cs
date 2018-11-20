
using FluentValidation;

namespace Survi.Prevention.ServiceLayer.Import.Places
{
    public class CountyValidator: BaseImportValidator<ApiClient.DataTransferObjects.County>
    {
	    public CountyValidator()
	    {
		    RuleFor(m => m.IdRegion)
			    .NotNull().WithMessage("{PropertyName}_NullValue");

		    RuleFor(m => m.IdState)
			    .NotNull().WithMessage("{PropertyName}_NullValue");

	    }
    }
}
