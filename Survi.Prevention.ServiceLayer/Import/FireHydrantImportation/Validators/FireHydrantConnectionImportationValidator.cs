using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.FireHydrantImportation.Validators
{
    public class FireHydrantConnectionImportationValidator
        : AbstractValidator<FireHydrantConnection>
    {
        public FireHydrantConnectionImportationValidator()
        {
            RuleFor(m => m.Id)
                .NotNullOrEmpty();

            RuleFor(m => m.Diameter)
                .GreaterThanOrEqualTo(0);

            RuleFor(m => m.IdUnitOfMeasureDiameter)
                .NotNullOrEmpty();

            RuleFor(m => m.IdFireHydrantConnectionType)
                .ForeignKeyExists();

            RuleFor(m => m.IdFireHydrant)
                .ForeignKeyExists();
        }
    }
}