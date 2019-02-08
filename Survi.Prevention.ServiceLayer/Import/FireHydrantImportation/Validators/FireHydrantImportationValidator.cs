using FluentValidation;
using NetTopologySuite.Geometries;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.FireHydrantImportation.Validators
{
    public class FireHydrantImportationValidator: AbstractValidator<FireHydrant>
    {
        public FireHydrantImportationValidator()
        {
            RuleFor(m => m.Id)
                .NotNullOrEmpty();

            RuleFor(m => m.Number)
                .NotNullOrEmptyWithMaxLength(10);

            RuleFor(m => m.PhysicalPosition)
                .MaximumLength(200).WithMessage("{PropertyName}_TooLong");

            RuleFor(m => m.CivicNumber)
                .MaximumLength(5).WithMessage("{PropertyName}_TooLong");

            RuleFor(m => m.IdCity).RequiredKeyIsValid();

            RuleFor(m => m.IdFireHydrantType).RequiredKeyIsValid();

            RuleFor(m => m.IdUnitOfMeasurePressure)
                .RequiredKeyIsValid()
                .When(m => m.PressureFrom > 0 || m.PressureTo > 0);

            RuleFor(m => m.IdUnitOfMeasureRate)
                .RequiredKeyIsValid()
                .When(m => m.RateFrom > 0 || m.RateTo > 0);

            RuleFor(m => m.IdLane)
                .RequiredKeyIsValid()
                .When(m => m.LocationType == FireHydrantLocationType.Address || m.LocationType == FireHydrantLocationType.LaneAndLaneTransversal);

            RuleFor(m => m.CivicNumber)
                .NotNullOrEmptyWithMaxLength(5)
                .When(m => m.LocationType == FireHydrantLocationType.Address);

            RuleFor(m => m.IdLaneTransversal)
                .RequiredKeyIsValid()
                .When(m => m.LocationType == FireHydrantLocationType.LaneAndLaneTransversal);

            RuleFor(m => m.WktCoordinates)
                .NotNullOrEmpty()
                .When(m => m.LocationType == FireHydrantLocationType.Coordinates);

            RuleFor(m => m.PhysicalPosition)
                .NotNullOrEmptyWithMaxLength(200)
                .When(m => m.LocationType == FireHydrantLocationType.Text);

            RuleFor(m => m.WktCoordinates)
                .Must(BeAValidWktCoordinate)
                .When(m => !string.IsNullOrWhiteSpace(m.WktCoordinates) || m.LocationType == FireHydrantLocationType.Coordinates);

            RuleFor(m => m.AddressLocationType).IsInEnum()
                .WithMessage("{PropertyName}_InvalidValue");

            RuleFor(m => m.LocationType).IsInEnum()
                .WithMessage("{PropertyName}_InvalidValue");

            RuleFor(m => m.PressureOperatorType).IsInEnum()
                .WithMessage("{PropertyName}_InvalidValue");

            RuleFor(m => m.RateOperatorType).IsInEnum()
                .WithMessage("{PropertyName}_InvalidValue");
        }

        private bool BeAValidWktCoordinate(string coordinate)
        {
            return ReadCoordinate(coordinate) != null;
        }

        private static Point ReadCoordinate(string coordinate)
        {
            try
            {
                if (string.IsNullOrEmpty(coordinate))
                    return null;

                var r = new NetTopologySuite.IO.WKTReader {DefaultSRID = 4326, HandleOrdinates = GeoAPI.Geometries.Ordinates.XY};
                var vr = r.Read(coordinate) as Point;
                return vr;
            }
            catch
            {
                return null;
            }
        }
    }
}