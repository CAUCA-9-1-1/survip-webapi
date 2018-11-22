using System;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Tests.Import.FireHydrantImportation.Mocks;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.FireHydrantImportation
{
    public class FireHydrantConnectionImportationConnectorTests
    {
        [Fact]
        public void CustomFieldsAreAllCorrectlyCopied()
        {
            var idType = Guid.NewGuid();
            var idUnit = Guid.NewGuid();
            var imported = new FireHydrantConnection { Diameter = 2, IdFireHydrantConnectionType = idType.ToString(), IdUnitOfMeasureDiameter = idUnit.ToString(), IdFireHydrant = idUnit.ToString() };
            var entity = new Models.FireHydrants.FireHydrantConnection();

            var converter = new FireHydrantConnectionImportationConverterMock();
            converter.CopyCustomFields(imported, entity);

            Assert.True(entity.Diameter == imported.Diameter
                        && entity.IdFireHydrant == idUnit
                        && entity.IdFireHydrantConnectionType == idType
                        && entity.IdUnitOfMeasureDiameter == idUnit);
        }
    }
}