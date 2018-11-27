using System;
using System.Drawing;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.Base;
using Survi.Prevention.ServiceLayer.Tests.Import.FireHydrantImportation.Mocks;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.FireHydrantImportation
{
    public class FireHydrantImportationConnectorTests
    {
        [Fact]
        public void CustomFieldsAreAllCorrectlyCopied()
        {
            var id = Guid.NewGuid();
            var imported = CreateFireHydrant(id);
            var entity = new Models.FireHydrants.FireHydrant();

            var converter = new FireHydrantImportationConverterMock();
            converter.CopyCustomFields(imported, entity);

            Assert.True(entity.AddressLocationType == (Models.FireHydrants.FireHydrantAddressLocationType)imported.AddressLocationType
                        && entity.Altitude == imported.Altitude
                        && entity.CivicNumber == imported.CivicNumber
                        && entity.Color == Color.FromArgb(imported.Color).ToHexString()
                        && entity.Comments == imported.Comments
                        && entity.IdCity == id
                        && entity.IdFireHydrantType == id
                        && entity.IdIntersection == id
                        && entity.IdLane == id
                        && entity.IdUnitOfMeasurePressure == id
                        && entity.IdUnitOfMeasureRate == id
                        && entity.LocationType == (Models.FireHydrants.FireHydrantLocationType)imported.LocationType
                        && entity.Number == imported.Number
                        && entity.PhysicalPosition == imported.PhysicalPosition
                        && entity.PressureFrom == imported.PressureFrom
                        && entity.PressureTo == imported.PressureTo
                        && entity.RateFrom == imported.RateFrom
                        && entity.RateTo == imported.RateTo 
                        && entity.Coordinates == imported.WktCoordinates
            );
        }

        private static FireHydrant CreateFireHydrant(Guid id)
        {
            var imported = new FireHydrant
            {
                AddressLocationType = FireHydrantAddressLocationType.Above,
                Altitude = 2, CivicNumber = "civic",
                Color = Color.Blue.ToArgb(),
                Comments = "comments",
                IdCity = id.ToString(),
                IdFireHydrantType = id.ToString(),
                IdIntersection = id.ToString(),
                IdLane = id.ToString(),
                IdUnitOfMeasurePressure = id.ToString(),
                IdUnitOfMeasureRate = id.ToString(),
                LocationType = FireHydrantLocationType.Address,
                Number = "ABC",
                PhysicalPosition = "There",
                PressureFrom = 1,
                PressureTo = 2,
                RateFrom = 1,
                RateTo = 2,
                WktCoordinates = "POINT (3 4)"
            };
            return imported;
        }
    }
}