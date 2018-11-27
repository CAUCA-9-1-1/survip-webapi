using FluentValidation;
using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Tests.Mocks.Validations
{
    public class MockObjectValidator : AbstractValidator<MockObject>
    {
        public MockObjectValidator()
        {
            RuleFor(m => m.SomeProperty).NotNullOrEmpty();
            RuleFor(m => m.SomeOtherProperty).NotNullOrEmptyWithMaxLength(5);

            RuleFor(m => m.SomeRequiredForeignKey).RequiredKeyIsValid();
            RuleFor(m => m.SomeOptionalForeignKey).OptionalKeyIsNullOrValid();
        }
    }
}