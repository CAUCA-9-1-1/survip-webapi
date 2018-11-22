using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.FireHydrantImportation.Validators;
using Xunit;
using FluentValidation.TestHelper;

namespace Survi.Prevention.ServiceLayer.Tests.Import.FireHydrantImportation
{
    public class FireHydrantConnectorImportationValidatorTests
    {
        private readonly AbstractValidator<FireHydrantConnection> validator;

        public FireHydrantConnectorImportationValidatorTests()
        {
            validator = new FireHydrantConnectionImportationValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("   ")]
        public void EntityShouldNotBeValidWhenPrimaryKeyIsNotSet(string value)
        {
            validator.ShouldHaveValidationErrorFor(m => m.Id, value);
        }

        [Fact]
        public void EntityShouldNotBeValidWhenDiameterIsNegative()
        {
            validator.ShouldHaveValidationErrorFor(m => m.Diameter, -1);
        }

        [Fact]
        public void EntityShouldNotBeValidWhenConnectionTypeIsUnknown()
        {
            validator.ShouldHaveValidationErrorFor(m => m.IdFireHydrantConnectionType, null as string);
        }

        [Fact]
        public void EntityShouldNotBeValidWhenUnitOfMeasureIsNotSetAndDiameterIsGreaterThanZero()
        {
            validator.ShouldHaveValidationErrorFor(m => m.IdUnitOfMeasureDiameter, new FireHydrantConnection {Diameter = 2, IdUnitOfMeasureDiameter = null});
        }

        [Fact]
        public void EntityShouldBeValidWhenUnitOfMeasureIsNotSetAndDiameterIsZero()
        {
            validator.ShouldNotHaveValidationErrorFor(m => m.IdUnitOfMeasureDiameter, new FireHydrantConnection {Diameter = 0, IdUnitOfMeasureDiameter = null});
        }
    }
}
