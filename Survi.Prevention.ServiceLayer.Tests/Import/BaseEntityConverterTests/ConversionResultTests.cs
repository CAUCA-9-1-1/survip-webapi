using System.Collections.Generic;
using Survi.Prevention.ServiceLayer.Import.Base;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BaseEntityConverterTests
{
    public class ConversionResultTests
    {
        [Fact]
        public void ConversionIsValidWhenThereIsNoValidationErrors()
        {
            var result = new ConversionResult<int> { ValidationErrors = new List<string>() };
            Assert.True(result.IsValid);
        }

        [Fact]
        public void ConversionIsValidWhenValidationErrorsIsNull()
        {
            var result = new ConversionResult<int> { ValidationErrors = null };
            Assert.True(result.IsValid);
        }

        [Fact]
        public void ConversionIsNotValidWhenThereIsNoValidationErrors()
        {
            var result = new ConversionResult<int> { ValidationErrors = new List<string> { "Hey!" } };
            Assert.False(result.IsValid);
        }
    }
}