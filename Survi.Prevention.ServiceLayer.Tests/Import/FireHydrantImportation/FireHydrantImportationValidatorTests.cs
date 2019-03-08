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
        [InlineData(FireHydrantLocationType.LaneAndTransversal)]
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
            validator.ShouldHaveValidationErrorFor(m => m.IdLaneTransversal, new FireHydrant { LocationType = FireHydrantLocationType.LaneAndTransversal, IdLaneTransversal = null });
        }

        [Fact]
        public void EntityShouldNotBeValidWhenPhysicalPositionIsNotSetAndLocationTypeIsIntersection()
        {
            validator.ShouldHaveValidationErrorFor(m => m.PhysicalPosition, new FireHydrant { LocationType = FireHydrantLocationType.Text, PhysicalPosition = null });
        }

        [Theory]
        [InlineData(FireHydrantLocationType.Address, "test")]
        [InlineData(FireHydrantLocationType.NotSpecified, null)]
        public void EntityShouldNotBeValidWhenCoordinatesIsInvalidOrLocationTypeIsCoordinatesAndCoordinatesAreInvalid(FireHydrantLocationType type, string coordinates)
        {
            validator.ShouldHaveValidationErrorFor(m => m.WktCoordinates, new FireHydrant { LocationType = type, WktCoordinates = coordinates });
        }

        [Fact]
        public void EntityShouldBeValidWhenCoordinatesAreSetAndAreValid()
        {
            validator.ShouldNotHaveValidationErrorFor(m => m.WktCoordinates, "POINT (30 10)");
        }

        [Fact]
        public void RateOperatorIsInvalidWhenValueNotInEnum()
        {
            validator.ShouldHaveValidationErrorFor(m => m.RateOperatorType, (OperatorType)22);
        }

        [Fact]
        public void PressureOperatorIsInvalidWhenValueNotInEnum()
        {
            validator.ShouldHaveValidationErrorFor(m => m.PressureOperatorType, (OperatorType)22);
        }

        [Fact]
        public void AddressLocationIsInvalidWhenValueNotInEnum()
        {
            validator.ShouldHaveValidationErrorFor(m => m.AddressLocationType, (FireHydrantAddressLocationType)22);
        }

        [Fact]
        public void LocationTypeIsInvalidWhenValueNotInEnum()
        {
            validator.ShouldHaveValidationErrorFor(m => m.LocationType, (FireHydrantLocationType)22);
        }

        [Fact]
        public void RateOperatorIsValidWhenValueInEnum()
        {
            validator.ShouldNotHaveValidationErrorFor(m => m.RateOperatorType, OperatorType.Greater);
        }

        [Fact]
        public void PressureOperatorIsValidWhenValueInEnum()
        {
            validator.ShouldNotHaveValidationErrorFor(m => m.PressureOperatorType, OperatorType.Greater);
        }

        [Fact]
        public void AddressLocationTypeIsValidWhenValueInEnum()
        {
            validator.ShouldNotHaveValidationErrorFor(m => m.AddressLocationType, FireHydrantAddressLocationType.AtEnd);
        }

        [Fact]
        public void LocationTypeIsValidWhenValueInEnum()
        {
            validator.ShouldNotHaveValidationErrorFor(m => m.LocationType, FireHydrantLocationType.NotSpecified);
        }
    }
}