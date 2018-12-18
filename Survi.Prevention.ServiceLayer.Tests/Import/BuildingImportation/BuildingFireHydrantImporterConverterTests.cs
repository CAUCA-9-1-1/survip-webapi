using System;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.Base.Cache;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation
{
    public class BuildingFireHydrantImporterConverterTests : BuildingFireHydrantImportationConverter
    {
        private readonly Guid idBuilding;
        private readonly Guid idFireHydrant;
        private readonly BuildingFireHydrant imported;
        private readonly Models.Buildings.BuildingFireHydrant entity;

        private bool fireHydrantHasBeenRetrievedFromDatabase;
        private bool buildingHasBeenRetrievedFromDatabase;

        public BuildingFireHydrantImporterConverterTests()
            : base(null, null, new CacheSystem())
        {
            idBuilding = Guid.NewGuid();
            idFireHydrant = Guid.NewGuid();
            imported = new BuildingFireHydrant {IdBuilding = idBuilding.ToString(), IdFireHydrant = idFireHydrant.ToString()};
            entity = new Models.Buildings.BuildingFireHydrant();
        }

        protected override string GetRealId<T>(string externId)
        {
            if (typeof(T) == typeof(Models.Buildings.Building))
                buildingHasBeenRetrievedFromDatabase = true;
            if (typeof(T) == typeof(Models.FireHydrants.FireHydrant))
                fireHydrantHasBeenRetrievedFromDatabase = true;
            return "ok";
        }

        [Fact]
        public void IdFireHydrantIsCorrectlyCopied()
        {
            CopyCustomFieldsToEntity(imported, entity);
            Assert.Equal(idBuilding, entity.IdBuilding);
        }

        [Fact]
        public void IdBuildingIsCorrectlyCopied()
        {
            CopyCustomFieldsToEntity(imported, entity);
            Assert.Equal(idFireHydrant, entity.IdFireHydrant);
        }

        [Fact]
        public void IdFireHydrantIsCorrectlyRetrievedFromDatabase()
        {
            GetRealForeignKeys(imported);
            Assert.True(fireHydrantHasBeenRetrievedFromDatabase);
        }

        [Fact]
        public void IdBuildingIsCorrectlyRetrievedFromDatabase()
        {
            GetRealForeignKeys(imported);
            Assert.True(buildingHasBeenRetrievedFromDatabase);
        }
    }
}
