using System;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation
{
    public class BuildingParticularRiskCustomFieldsCopierTests
    {
        private readonly Guid idParent;
        private readonly BuildingParticularRisk imported;
        private readonly Models.Buildings.Base.BuildingParticularRisk entity;
        private readonly BuildingParticularRiskCustomFieldsCopier copier;

        public BuildingParticularRiskCustomFieldsCopierTests()
        {
            copier = new BuildingParticularRiskCustomFieldsCopier();
            idParent = Guid.NewGuid();
            imported = new BuildingParticularRisk
            {
                IdBuilding = idParent.ToString(),
                Comments = "Comments",
                Dimension = "Dimension",
                HasOpening = true,
                IsWeakened = true,
                Sector = "Sector",
                Wall = "Wall"
            };

            entity = new Models.Buildings.BuildingFloorParticularRisk
            {
                IdBuilding = Guid.NewGuid(),
            };
        }

        [Fact]
        public void FieldsAreCorrectlyCopied()
        {
            copier.DuplicateFieldsValues(imported, entity);
            Assert.True(
                entity.Comments == "Comments"
                && entity.Dimension == "Dimension"
                && entity.HasOpening
                && entity.IdBuilding == idParent
                && entity.IsWeakened
                && entity.Sector == "Sector"
                && entity.Wall == "Wall"
            );
        }
    }
}