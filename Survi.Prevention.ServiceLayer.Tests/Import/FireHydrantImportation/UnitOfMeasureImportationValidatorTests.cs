using FluentValidation;
using FluentValidation.TestHelper;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.FireHydrantImportation.Validators;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.FireHydrantImportation
{
    public class UnitOfMeasureImportationValidatorTests
    {
        private readonly AbstractValidator<UnitOfMeasure> validator;

        public UnitOfMeasureImportationValidatorTests()
        {
            validator = new UnitOfMeasureImportationValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("123456")]
        [InlineData(null)]
        public void EntityIsInvalidWhenAbbreviationIsInvalid(string value)
        {
            validator.ShouldHaveValidationErrorFor(m => m.Abbreviation, value);
        }

        [Fact]
        public void EntityIsInvalidWhenUnitTypeDoesNotExist()
        {
            validator.ShouldHaveValidationErrorFor(m => m.MeasureType, (MeasureType) 10);
        }
    }
}