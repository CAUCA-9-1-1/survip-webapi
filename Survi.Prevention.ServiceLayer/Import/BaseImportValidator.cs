using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects.Base;
using Survi.Prevention.ServiceLayer.ValidationUtilities;
using imported = Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ServiceLayer.Import
{
    public abstract class BaseImportValidator<T>: AbstractValidator<T> where T : BaseLocalizableTransferObject, new()
    {
	    protected BaseImportValidator()
	    {
	        RuleFor(m => m.Id)
	            .NotNullOrEmpty();

		    RuleFor(m => m.Localizations)
			    .NotNull().WithMessage("{PropertyName}_NullValue")
			    .Must(HaveRequiredLocalisationCount).WithMessage("{PropertyName}_InvalidCount")
			    .Must(HaveRequiredLanguages).WithMessage("{PropertyName}_InvalidValue")
			    .Must(HaveLocalizationNames).WithMessage("{PropertyName}_InvalidValue");
	    }

	    public virtual bool HaveLocalizationNames(ICollection<imported.Localization> localizations)
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

	    public virtual bool HaveRequiredLocalisationCount(ICollection<imported.Localization> localizations)
	    {
		    if(localizations == null || localizations.Count <= 1)
			    return false;
		    return true;
	    }

	    public virtual bool HaveRequiredLanguages(ICollection<imported.Localization> localizations)
	    {
		    if(localizations == null)
			    return false;

		    if (localizations.Any(loc => string.IsNullOrEmpty(loc.LanguageCode)))
			    return false;

		    List<string> languages = new List<string>{"fr","en"};		    
		    foreach (var code in languages)
		    {
			    if (localizations.All(loc => loc.LanguageCode != code))
				    return false;
		    }
		    return true;
	    }
    }
}
