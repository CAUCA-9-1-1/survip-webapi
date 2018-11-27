using System;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Tests.Import.BaseEntityConverterTests.Mocks;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BaseEntityConverterTests
{
    public class BaseCustomFieldsCopierTests
    {
        private readonly Guid idBuilding;
        private readonly BuildingAnomaly imported;
        private readonly Models.Buildings.BuildingAnomaly entity;
        private readonly BaseCustomFieldsCopierMock copier;

        public BaseCustomFieldsCopierTests()
        {
            copier = new BaseCustomFieldsCopierMock();
            idBuilding = Guid.NewGuid();
            imported = new BuildingAnomaly
            {
                IdBuilding = idBuilding.ToString(),
                Notes = "Tests",
                Theme = "Test"
            };

            entity = new Models.Buildings.BuildingAnomaly
            {
                Notes = "Old",
                Theme = "Old"
            };
        }

        [Fact]
        public void CopyValuesIsCorrectlyCalledWhenCopyingFieldsValues()
        {
            copier.DuplicateFieldsValues(imported, entity);
            Assert.True(copier.CopyValuesIsCorrectlyCalled);
        }

        [Theory]
        [InlineData("", null)]
        [InlineData(null, null)]
        [InlineData("abc", null)]
        public void ParseIdIsCorrectlyHandlingAllInvalidValue(string input, Guid? output)
        {
            var result = copier.ParseId(input);
            Assert.Equal(output, result);
        }

        [Fact]
        public void ParseIdIsCorrectlyHandlingValidValue()
        {
            var result = copier.ParseId(idBuilding.ToString());
            Assert.Equal(idBuilding, result);
        }
    }
}