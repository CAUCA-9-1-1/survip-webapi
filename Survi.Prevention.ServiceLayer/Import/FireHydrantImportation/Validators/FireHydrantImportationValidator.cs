using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.FireHydrantImportation.Validators
{
    public class FireHydrantImportationValidator
        : AbstractValidator<FireHydrant>
    {
        public FireHydrantImportationValidator(AbstractValidator<FireHydrantConnection> validator)
        {
            RuleFor(m => m.Id)
                .NotNullOrEmpty();
            RuleFor(m => m.Number)
                .NotNullOrEmptyWithMaxLength(10);
            RuleFor(m => m.PhysicalPosition)
                .MaximumLength(200);
            RuleFor(m => m.CivicNumber)
                .MaximumLength(50);

            RuleFor(m => m.IdCity).ForeignKeyExists();

            RuleFor(m => m.IdFireHydrantType).ForeignKeyExists();

            RuleFor(m => m.IdUnitOfMeasurePressure)
                .ForeignKeyExists()
                .When(m => m.PressureFrom > 0 || m.PressureTo > 0);

            RuleFor(m => m.IdUnitOfMeasureRate)
                .ForeignKeyExists()
                .When(m => m.RateFrom > 0 || m.RateTo > 0);

            RuleFor(m => m.IdLane)
                .ForeignKeyExists()
                .When(m => m.LocationType == FireHydrantLocationType.Address || m.LocationType == FireHydrantLocationType.LaneAndIntersection);

            RuleFor(m => m.CivicNumber)
                .NotNullOrEmpty()
                .When(m => m.LocationType == FireHydrantLocationType.Address);

            RuleFor(m => m.IdIntersection)
                .ForeignKeyExists()
                .When(m => m.LocationType == FireHydrantLocationType.LaneAndIntersection);

            RuleFor(m => m.WktCoordinates)
                .NotNullOrEmpty()
                .When(m => m.LocationType == FireHydrantLocationType.Coordinates);

            RuleFor(m => m.PhysicalPosition)
                .NotNullOrEmpty()
                .When(m => m.LocationType == FireHydrantLocationType.Text);

            RuleForEach(m => m.Connections)
                .SetValidator(validator);
        }
    }
}