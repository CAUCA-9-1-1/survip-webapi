using FluentValidation;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BaseEntityConverterTests.Mocks
{
    public class BaseEntityValidatorMock : AbstractValidator<ApiClient.DataTransferObjects.Country>
    {
        public BaseEntityValidatorMock()
        {
            RuleFor(m => m.CodeAlpha2).NotNull();
        }
    }
}