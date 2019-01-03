using System;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.Base.Cache;
using Survi.Prevention.ServiceLayer.Import.Places;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.Places
{
    public class CountyImportTests : CountyImportationConverter
    {
        private readonly Guid someId = Guid.NewGuid();

        public CountyImportTests() : base(null, null, new CacheSystem())
        {
        }

        protected override string GetRealId<T>(string externId)
        {
            return someId.ToString();
        }

        [Fact]
        public void IdRegionIsCorrectlyRetrievedWhenSet()
        {
            var import = new County { IdRegion = "ABC" };
            GetRealForeignKeys(import);            

            Assert.Equal(someId.ToString(), import.IdRegion);
        }

        [Fact]
        public void IdRegionIsCorrectlyCopiedWhenSet()
        {
            var country = new Models.FireSafetyDepartments.County();
            var import = new County { IdRegion = someId.ToString() };
            CopyCustomFieldsToEntity(import, country);

            Assert.Equal(someId, country.IdRegion);
        }
    }
}