
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Survi.Prevention.DataLayer;

namespace Survi.Prevention.ServiceLayer.Import.Country
{
    public class StateValidator: AbstractValidator<ApiClient.DataTransferObjects.State>
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
			    .NotNull().WithMessage("{PropertyName}_NullValue")
			    .Must(CountryMustExists).WithMessage("{PropertyName}_NotExists");

		    RuleFor(m => m.Localizations)
			    .NotNull().WithMessage("{PropertyName}_NullValue")
			    .Must(ValidateMinimumLocalizations).WithMessage("{PropertyName}_InvalidCount")
			    .Must(ValidateRequiredLanguage).WithMessage("{PropertyName}_InvalidValue")
			    .Must(ValidateLanguage).WithMessage("{PropertyName}_InvalidValue");
	    }

	    private bool ValidateLanguage(ICollection<ApiClient.DataTransferObjects.Base.Localization> localizations)
	    {
		    if(localizations == null)
			    return false;

		    foreach (var loc in localizations)
		    {
			    if (string.IsNullOrEmpty(loc.Name))
				    return false;
		    }

		    return true;
	    }

	    private bool ValidateMinimumLocalizations(
		    ICollection<ApiClient.DataTransferObjects.Base.Localization> localizations)
	    {
		    if(localizations == null || localizations.Count <= 1)
			    return false;
		    return true;
	    }

	    private bool ValidateRequiredLanguage(
		    ICollection<ApiClient.DataTransferObjects.Base.Localization> localizations)
	    {
		    if(localizations == null)
			    return false;

		    List<string> languages = new List<string>{"fr","en"};
		    foreach (var loc in localizations)
		    {
			    if (string.IsNullOrEmpty(loc.LanguageCode) || !languages.Contains(loc.LanguageCode))
				    return false;
		    }

		    return true;
	    }

	    private bool CountryMustExists(string idExternal)
	    {
		    if(string.IsNullOrEmpty(idExternal))
			    return false;

		    if (!stateContext.Countries.Any(c => c.IdExtern == idExternal))
			    return false;

		    return false;
	    }
    }
}
