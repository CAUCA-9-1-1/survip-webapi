using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Tests.Import.FireHydrantImportation.Mocks;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.FireHydrantImportation
{
    public class UnitOfMeasureImportationConverterTests
    {
        [Fact]
        public void CustomFieldsAreBeingCopied()
        {
            var unit = new UnitOfMeasure { Abbreviation = "BC", MeasureType = MeasureType.Capacity };
            var entity = new Models.UnitOfMeasure { };

            var converter = new UnitOfMeasureImportationConverterMock();
            converter.CopyCustomFields(unit, entity);

            Assert.True(unit.MeasureType == (MeasureType) entity.MeasureType
                        && unit.Abbreviation == entity.Abbreviation);
        }
    }
}