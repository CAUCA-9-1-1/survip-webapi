using System.Linq;
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

        [Fact]
        public void NotNullOrEmptyCorrectlyFailWhenValueIsNull()
        {
            mockValidator.ShouldHaveValidationErrorFor(mock => mock.SomeProperty, null as string);
        }

        [Fact]
        public void NotNullOrEmptyCorrectlyFailWhenValueIsEmpty()
        {
            mockValidator.ShouldHaveValidationErrorFor(mock => mock.SomeProperty, string.Empty);
        }

        [Fact]
        public void NotNullOrEmptyCorrectlyFailWhenValueIsWhiteSpaces()
        {
            mockValidator.ShouldHaveValidationErrorFor(mock => mock.SomeProperty, "   ");
        }

        [Fact]
        public void NotNullOrEmptyWithMaxLengthCorrectlyFailWhenValueIsOverMaxLength()
        {
            mockValidator.ShouldHaveValidationErrorFor(mock => mock.SomeOtherProperty, "123456");
        }

        [Fact]
        public void NotNullOrEmptyWithMaxLengthHasNoValidationErrorWhenValueIsAtMaxLength()
        {
            mockValidator.ShouldNotHaveValidationErrorFor(mock => mock.SomeOtherProperty, "12345");
        }

        [Fact]
        public void NotNullOrEmptyWithMaxLengthHasNoValidationErrorWhenValueIsUnderMaxLength()
        {
            mockValidator.ShouldNotHaveValidationErrorFor(mock => mock.SomeOtherProperty, "1234");
        }

        [Fact]
        public void ValidationMessageIsCorrectlyGeneratedWhenValueIsNotNullOrEmpty()
        {
            var mock = new MockObject { SomeProperty = null, SomeOtherProperty = "1" };
            var validation = mockValidator.Validate(mock);
            Assert.Equal("SomeProperty_EmptyValue", validation.Errors.FirstOrDefault()?.ErrorMessage);
        }

        [Fact]
        public void ValidationMessageIsCorrectlyGeneratedWhenValueIsOverMaxLength()
        {
            var mock = new MockObject { SomeProperty = "1", SomeOtherProperty = "123456" };
            var validation = mockValidator.Validate(mock);
            Assert.Equal("SomeOtherProperty_InvalidValue", validation.Errors.FirstOrDefault()?.ErrorMessage);
        }
    }
}
