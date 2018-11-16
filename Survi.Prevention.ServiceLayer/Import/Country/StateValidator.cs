using FluentValidation;
using Survi.Prevention.DataLayer;

namespace Survi.Prevention.ServiceLayer.Import.Country
{
    public class StateValidator: BaseImportValidator<ApiClient.DataTransferObjects.State>
    {
	    private IManagementContext stateContext;
	    public StateValidator(IManagementContext context)
	    {
		    stateContext = context;

		    RuleFor(m => m.AnsiCode)
			    .NotEmpty()
			    .MaximumLength(2).WithMessage("{PropertyName}_InvalidValue");

		    RuleFor(m => m.Id)
			    .NotNull().WithMessage("{PropertyName}_InvalidValue");

		    RuleFor(m => m.IdCountry)
			    .NotNull().WithMessage("{PropertyName}_NullValue");

		    RuleFor(m => m.Localizations)
			    .NotNull().WithMessage("{PropertyName}_NullValue")
			    .Must(ValidateMinimumLocalizations).WithMessage("{PropertyName}_InvalidCount")
			    .Must(ValidateRequiredLanguage).WithMessage("{PropertyName}_InvalidValue")
			    .Must(ValidateLanguage).WithMessage("{PropertyName}_InvalidValue");
	    }

    }
}
