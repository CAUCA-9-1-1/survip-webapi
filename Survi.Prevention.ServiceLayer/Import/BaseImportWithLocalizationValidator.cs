using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects.Base;
using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import
{
    public abstract class BaseImportWithLocalizationValidator<T> : AbstractValidator<T>
        where T : BaseLocalizableTransferObject, new()
    {
        protected BaseImportWithLocalizationValidator()
        {
            RuleFor(m => m.Id)
                .NotNullOrEmpty();

            RuleFor(m => m.Localizations)
                .NotNull().WithMessage("{PropertyName}_NullValue")
                .Must(new BaseLocalizationValidator().HaveRequiredLocalizationCount)
                .WithMessage("{PropertyName}_InvalidCount")
                .Must(new BaseLocalizationValidator().HaveRequiredLanguages).WithMessage("{PropertyName}_InvalidValue")
                .Must(new BaseLocalizationValidator().HaveLocalizationNames).WithMessage("{PropertyName}_InvalidValue");
        }
    }
}