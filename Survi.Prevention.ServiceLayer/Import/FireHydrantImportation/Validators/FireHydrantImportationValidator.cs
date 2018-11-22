using FluentValidation;
using NetTopologySuite.Geometries;
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

            RuleFor(m => m.WktCoordinates)
                .Must(BeAValidWktCoordinate)
                .When(m => !string.IsNullOrWhiteSpace(m.WktCoordinates) || m.LocationType == FireHydrantLocationType.Coordinates);
        }

        private bool BeAValidWktCoordinate(string coordinate)
        {
            return ReadCoordinate(coordinate) != null;
        }

        private static Point ReadCoordinate(string coordinate)
        {
            try
            {
                if (coordinate == null)
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