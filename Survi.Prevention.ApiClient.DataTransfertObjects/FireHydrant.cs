using System;
using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.DataTransferObjects
{
    public class FireHydrant : BaseTransferObject
    {
        public FireHydrantLocationType LocationType { get; set; }
        public string WktCoordinates { get; set; }

        public decimal Altitude { get; set; }
        public string Number { get; set; }
        public Decimal? RateFrom { get; set; }
        public Decimal? RateTo { get; set; }

        public Decimal? PressureFrom { get; set; }
        public Decimal? PressureTo { get; set; }
        public string Color { get; set; }
        public string Comments { get; set; }
        public string PhysicalPosition { get; set; }
        public string CivicNumber { get; set; }
        public FireHydrantAddressLocationType AddressLocationType { get; set; }
        public OperatorType RateOperatorType { get; set; } = OperatorType.Equal;
        public OperatorType PressureOperatorType { get; set; } = OperatorType.Equal;

        public string IdCity { get; set; }
        public string IdLane { get; set; }
        public string IdIntersection { get; set; }
        public string IdFireHydrantType { get; set; }
        public string IdUnitOfMeasureRate { get; set; }
        public string IdUnitOfMeasurePressure { get; set; }
    }
}