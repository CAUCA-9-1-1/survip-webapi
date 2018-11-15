using System.Collections.Generic;
using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;

namespace Survi.Prevention.ServiceLayer.Import
{
    public class CountryValidator: AbstractValidator<Country>
    {
	    public CountryValidator()
	    {
		    RuleFor(m => m.CodeAlpha2)
			    .NotEmpty()
			    .MaximumLength(2).WithMessage("{PropertyName}_InvalidValue");

		    RuleFor(m => m.CodeAlpha3)
			    .NotEmpty()
			    .MaximumLength(3).WithMessage("{PropertyName}_InvalidValue");

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
    }
}
