using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects.Base;
using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import
{
    public abstract class BaseImportValidator<T> : AbstractValidator<T>
        where T : BaseTransferObject, new()
    {
        protected BaseImportValidator()
        {
            RuleFor(m => m.Id)
                .NotNullOrEmpty();
        }
    }
}
