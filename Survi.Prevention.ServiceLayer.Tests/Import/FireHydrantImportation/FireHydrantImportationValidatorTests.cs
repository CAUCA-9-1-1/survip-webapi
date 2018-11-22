using FluentValidation;
using FluentValidation.TestHelper;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.FireHydrantImportation.Validators;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.FireHydrantImportation
{
    public class FireHydrantImportationValidatorTests
    {
        private readonly AbstractValidator<FireHydrant> validator;

        public FireHydrantImportationValidatorTests()
        {
            validator = new FireHydrantImportationValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("   ")]
        public void EntityShouldNotBeValidWhenPrimaryKeyIsNotSet(string value)
        {
            validator.ShouldHaveValidationErrorFor(m => m.Id, value);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        public void EntityShouldNotBeValidWhenUnitOfMeasureIsNotSetAndPressureIsGreaterThanZero(decimal pressureFrom, decimal pressureTo)
        {
            validator.ShouldHaveValidationErrorFor(m => m.IdUnitOfMeasurePressure, new FireHydrant { PressureFrom = pressureFrom, PressureTo = pressureTo, IdUnitOfMeasurePressure = null });
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        public void EntityShouldNotBeValidWhenUnitOfMeasureIsNotSetAndRateIsGreaterThanZero(decimal rateFrom, decimal rateTo)
        {
            validator.ShouldHaveValidationErrorFor(m => m.IdUnitOfMeasureRate, new FireHydrant { RateFrom = rateFrom, RateTo = rateTo, IdUnitOfMeasureRate = null });
        }

        [Fact]
        public void EntityShouldBeValidWhenUnitOfMeasureIsNotSetAndPressureIsZero()
        {
            validator.ShouldNotHaveValidationErrorFor(m => m.IdUnitOfMeasurePressure, new FireHydrant { PressureFrom = 0, PressureTo = 0, IdUnitOfMeasurePressure = null });
        }

        [Fact]
        public void EntityShouldBeValidWhenUnitOfMeasureIsNotSetAndRateIsZero()
        {
            validator.ShouldNotHaveValidationErrorFor(m => m.IdUnitOfMeasurePressure, new FireHydrant { RateFrom = 0, RateTo = 0, IdUnitOfMeasureRate = null });
        }

        [Theory]
        [InlineData("")]
        [InlineData("12345678901")]
        public void EntityIsInvalidWhenNumberIsNullEmptyOrTooLong(string value)
        {
            validator.ShouldHaveValidationErrorFor(m => m.Number, value);
        }

        [Fact]
        public void EntityIsInvalidWhenCivicNumberIsTooLong()
        {
            validator.ShouldHaveValidationErrorFor(m => m.CivicNumber, new string('1', 51));
        }

        [Fact]
        public void EntityIsInvalidWhenPhysicalPositionIsTooLong()
        {
            validator.ShouldHaveValidationErrorFor(m => m.PhysicalPosition, new string('1', 201));
        }

        [Fact]
        public void EntityShouldNotBeValidWhenIdCityIsUnknown()
        {
            validator.ShouldHaveValidationErrorFor(m => m.IdCity, null as string);
        }

        [Fact]
        public void EntityShouldNotBeValidWhenIdFireHydrantTypeIsUnknown()
        {
            validator.ShouldHaveValidationErrorFor(m => m.IdFireHydrantType, null as string);
        }

        [Theory]
        [InlineData(FireHydrantLocationType.Address)]
        [InlineData(FireHydrantLocationType.LaneAndIntersection)]
        public void EntityShouldNotBeValidWhenIdLaneIsMissingAndLocationTypeIsAddressOrIntersection(FireHydrantLocationType type)
        {
            validator.ShouldHaveValidationErrorFor(m => m.IdLane, new FireHydrant { LocationType = type, IdLane = null });
        }

        [Fact]
        public void EntityShouldNotBeValidWhenCivicNumberIsNotSetAndLocationTypeIsAddress()
        {
            validator.ShouldHaveValidationErrorFor(m => m.CivicNumber, new FireHydrant { LocationType = FireHydrantLocationType.Address, CivicNumber = null });
        }

        [Fact]
        public void EntityShouldNotBeValidWhenIdIntersectionIsNotSetAndLocationTypeIsIntersection()
        {
            validator.ShouldHaveValidationErrorFor(m => m.IdIntersection, new FireHydrant { LocationType = FireHydrantLocationType.LaneAndIntersection, IdIntersection = null });
        }

        [Fact]
        public void EntityShouldNotBeValidWhenPhysicalPositionIsNotSetAndLocationTypeIsIntersection()
        {
            validator.ShouldHaveValidationErrorFor(m => m.PhysicalPosition, new FireHydrant { LocationType = FireHydrantLocationType.Text, PhysicalPosition = null });
        }

        [Theory]
        [InlineData(FireHydrantLocationType.Address, "test")]
        [InlineData(FireHydrantLocationType.Coordinates, null)]
        public void EntityShouldNotBeValidWhenCoordinatesIsInvalidOrLocationTypeIsCoordinatesAndCoordinatesAreInvalid(FireHydrantLocationType type, string coordinates)
        {
            validator.ShouldHaveValidationErrorFor(m => m.WktCoordinates, new FireHydrant { LocationType = type, WktCoordinates = coordinates });
        }

        [Fact]
        public void EntityShouldBeValidWhenCoordinatesAreSetAndAreValid()
        {
            validator.ShouldNotHaveValidationErrorFor(m => m.WktCoordinates, "POINT (30 10)");
        }
    }
}