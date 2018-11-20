using FluentValidation;

namespace Survi.Prevention.ServiceLayer.Import.Places
{
    public class RegionValidator: BaseImportValidator<ApiClient.DataTransferObjects.Region>
    {
	    public RegionValidator()
	    {
		    RuleFor(m => m.Code)
			    .NotEmpty().WithMessage("{PropertyName}_EmptyValue")
			    .MaximumLength(10).WithMessage("{PropertyName}_InvalidValue");

		    RuleFor(m => m.IdState)
			    .NotNull().WithMessage("{PropertyName}_NullValue");

	    }
    }
}
