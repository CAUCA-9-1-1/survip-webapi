using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.Country.Mocks;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation
{
    public class UtilisationCodeImporterConverterTests
    {
        [Fact]
        public void CustomFieldsAreCorrectlyCopied()
        {
            var imported = new UtilisationCode { Scian = "ABC", Cubf = "BDE" };
            var existing = new Models.Buildings.UtilisationCode { Scian = "", Cubf = "" };

            var converter = new UtilisationCodeImportationConverterMock();
            converter.CopyCustomFields(imported, existing);

            Assert.True(imported.Scian == existing.Scian && imported.Cubf == existing.Cubf);
        }
    }
}
