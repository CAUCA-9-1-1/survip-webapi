using System.Collections.Generic;
using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Tests.Import.BaseEntityConverterTests.Mocks;
using Survi.Prevention.ServiceLayer.Tests.Mocks;
using Xunit;
using ImportedCountry = Survi.Prevention.ApiClient.DataTransferObjects.Country;
using DataCountry = Survi.Prevention.Models.FireSafetyDepartments.Country;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BaseEntityConverterTests
{
    public class BaseEntityConverterTests
    {
        private readonly ImportedCountry importedCountry = new ImportedCountry {Id = "COUNTRY1", CodeAlpha2 = "CA", CodeAlpha3 = "CAD", IsActive = true};

        private AbstractValidator<ImportedCountry> CreateMockValidator()
        {
            return new BaseEntityValidatorMock();
        }

        private IManagementContext CreateMockContext(bool withCountry)
        {
            var countries = new List<DataCountry>();
            if (withCountry)
                countries.Add(new DataCountry {CodeAlpha2 = "CA", CodeAlpha3 = "CAD", IdExtern = "COUNTRY1"});
            var mockCtx = new BaseContextMock();
            mockCtx.Setup(ctx => ctx.Set<DataCountry>()).Returns(mockCtx.GetMockDbSet(countries).Object);
            return mockCtx.Object;
        }

        [Fact]
        public void CustomFieldsAreBeingCopied()
        {
            var converter = new BaseEntityConverterMock(CreateMockContext(false), CreateMockValidator());
            converter.Convert(importedCountry);
            Assert.True(converter.CustomFieldsHaveBeenCopied);
        }

        [Fact]
        public void UseNewEntityWhenDoesntExist()
        {
            var converter = new BaseEntityConverterMock(CreateMockContext(false), CreateMockValidator());
            converter.Convert(importedCountry);
            Assert.True(converter.HasCreateANewCountry);
        }

        [Fact]
        public void UseExistingCountryWhenItDoesExist()
        {
            var converter = new BaseEntityConverterMock(CreateMockContext(true), CreateMockValidator());
            converter.Convert(importedCountry);
            Assert.True(converter.HasUsedAnExistingCountry);
        }

        [Fact]
        public void BaseFieldsAreCorrectlyBeingCopied()
        {
            var converter = new BaseEntityConverterMock(CreateMockContext(false), CreateMockValidator());
            var country = converter.Convert(importedCountry).Result;

            Assert.True(country.IdExtern == importedCountry.Id
                        && country.IsActive == importedCountry.IsActive);
        }

        [Fact] 
        public void ConvertReturnsNullAsResultWhenImportedEntityIsInvalid()
        {
            importedCountry.CodeAlpha2 = null;
            var converter = new BaseEntityConverterMock(CreateMockContext(false), CreateMockValidator());
            var country = converter.Convert(importedCountry);

            Assert.Null(country.Result);
        }

        [Fact]
        public void ConvertReturnsConvertedValueAsResultWhenImportedEntityIsValid()
        {
            var converter = new BaseEntityConverterMock(CreateMockContext(false), CreateMockValidator());
            var country = converter.Convert(importedCountry);

            Assert.NotNull(country.Result);
        }
    }
}