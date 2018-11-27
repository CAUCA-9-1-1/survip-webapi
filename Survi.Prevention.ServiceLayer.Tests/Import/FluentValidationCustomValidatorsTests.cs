using System;
using FluentValidation;
using FluentValidation.TestHelper;
using Survi.Prevention.ServiceLayer.Tests.Mocks.Validations;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import
{
    public class FluentValidationCustomValidatorsTests
    {
        private readonly MockObjectValidator mockValidator;

        public FluentValidationCustomValidatorsTests()
        {
            ValidatorOptions.DisplayNameResolver = (type, memberInfo, expression) => memberInfo.Name;
            mockValidator = new MockObjectValidator();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("     ")]
        public void NotNullOrEmptyCorrectlyFailWhenValueIsInvalid(string value)
        {
            mockValidator.ShouldHaveValidationErrorFor(mock => mock.SomeProperty, value);
        }

        [Fact]
        public void NotNullOrEmptyWithMaxLengthCorrectlyFailWhenValueIsOverMaxLength()
        {
            mockValidator.ShouldHaveValidationErrorFor(mock => mock.SomeOtherProperty, "123456");
        }

        [Theory]
        [InlineData("1")]
        [InlineData("12345")]
        public void NotNullOrEmptyWithMaxLengthHasNoValidationErrorWhenValueIsValid(string value)
        {
            mockValidator.ShouldNotHaveValidationErrorFor(mock => mock.SomeOtherProperty, value);
        }

        [Fact]
        public void ValidationMessageIsCorrectlyGeneratedWhenValueIsNotNullOrEmpty()
        {
            mockValidator.ShouldHaveValidationErrorFor(mock => mock.SomeProperty, null as string)
                .WithErrorMessage("SomeProperty_EmptyValue");
        }

        [Fact]
        public void ValidationMessageIsCorrectlyGeneratedWhenValueIsOverMaxLength()
        {
            mockValidator.ShouldHaveValidationErrorFor(mock => mock.SomeOtherProperty, "123456")
                .WithErrorMessage("SomeOtherProperty_InvalidValue");
        }

        [Fact]
        public void RequiredKeyIsInvalidWhenIsEmptyGuid()
        {
            mockValidator.ShouldHaveValidationErrorFor(mock => mock.SomeRequiredForeignKey, Guid.Empty.ToString())
                .WithErrorMessage("SomeRequiredForeignKey_UnknownValue");
        }

        [Fact]
        public void RequiredKeyIsInvalidWhenNull()
        {
            mockValidator.ShouldHaveValidationErrorFor(mock => mock.SomeRequiredForeignKey, null as string)
                .WithErrorMessage("SomeRequiredForeignKey_MissingValue");
        }

        [Fact]
        public void RequiredKeyIsInvalidWhenEmpty()
        {
            mockValidator.ShouldHaveValidationErrorFor(mock => mock.SomeRequiredForeignKey, string.Empty)
                .WithErrorMessage("SomeRequiredForeignKey_MissingValue");
        }

        [Fact]
        public void RequiredKeyIsValidWhenGuid()
        {
            mockValidator.ShouldNotHaveValidationErrorFor(mock => mock.SomeRequiredForeignKey, Guid.NewGuid().ToString());
        }

        [Fact]
        public void OptionalKeyIsInvalidWhenIsEmptyGuid()
        {
            mockValidator.ShouldHaveValidationErrorFor(mock => mock.SomeOptionalForeignKey, Guid.Empty.ToString())
                .WithErrorMessage("SomeOptionalForeignKey_UnknownValue");
        }

        [Fact]
        public void OptionalKeyIsValidWhenGuid()
        {
            mockValidator.ShouldNotHaveValidationErrorFor(mock => mock.SomeOptionalForeignKey, Guid.NewGuid().ToString());
        }

        [Fact]
        public void OptionalKeyIsValidWhenNull()
        {
            mockValidator.ShouldNotHaveValidationErrorFor(mock => mock.SomeOptionalForeignKey, null as string);
        }
    }
}
