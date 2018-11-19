using FluentValidation;

namespace Survi.Prevention.ServiceLayer.Import.Country
{
    public class CountryValidator: BaseImportValidator<ApiClient.DataTransferObjects.Country>
    {
	    public CountryValidator()
	    {
		    RuleFor(m => m.CodeAlpha2)
			    .NotEmpty().WithMessage("{PropertyName}_EmptyValue")
			    .MaximumLength(2).WithMessage("{PropertyName}_InvalidValue");

		    RuleFor(m => m.CodeAlpha3)
			    .NotEmpty().WithMessage("{PropertyName}_EmptyValue")
			    .MaximumLength(3).WithMessage("{PropertyName}_InvalidValue");

		    
	    }
    }
}
