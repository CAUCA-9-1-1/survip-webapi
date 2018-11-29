using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.FireSafetyDepartment
{
    public class FirestationImportationValidator : AbstractValidator<Firestation>
    {
        public FirestationImportationValidator()
        {
            RuleFor(m => m.Id).NotNullOrEmpty();
            RuleFor(m => m.Name).NotNullOrEmpty();
            RuleFor(m => m.IdBuilding).OptionalKeyIsNullOrValid();
            RuleFor(m => m.IdFireSafetyDepartment).RequiredKeyIsValid();
            RuleFor(m => m.PhoneNumber).NotNullMaxLength(10);
            RuleFor(m => m.FaxNumber).NotNullMaxLength(10);
            RuleFor(m => m.Email).NotNullMaxLength(100);
        }
    }
}
