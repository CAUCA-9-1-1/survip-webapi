using System;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation
{
    public class BuildingDetailCustomFieldsCopierTests
    {
        private readonly Guid idParent;
        private readonly Guid idType;
        private readonly BuildingDetail imported;
        private readonly Models.Buildings.BuildingDetail entity;
        private readonly BuildingDetailCustomFieldsCopier copier;

        public BuildingDetailCustomFieldsCopierTests()
        {
            copier = new BuildingDetailCustomFieldsCopier();
            idParent = Guid.NewGuid();
            idType = Guid.NewGuid();
            imported = new BuildingDetail
            {
                IdBuilding = idParent.ToString(),
                AdditionalInformation = "Add",
                EstimatedWaterFlow = 2,
                GarageType= GarageType.No,
                Height = 3,
                IdBuildingSidingType = idType.ToString(),
                IdBuildingType = idType.ToString(),
                IdConstructionFireResistanceType = idType.ToString(),
                IdConstructionType = idType.ToString(),
                IdRoofMaterialType = idType.ToString(),
                IdRoofType = idType.ToString(),
                IdUnitOfMeasureEstimatedWaterFlow = idType.ToString(),
                IdUnitOfMeasureHeight = idType.ToString(),
                RevisedOn = new DateTime(2010, 1, 1),
                ApprovedOn = new DateTime(2009, 1, 1)
            };

            entity = new Models.Buildings.BuildingDetail
            {
                IdBuilding = Guid.NewGuid(),
            };
        }

        [Fact]
        public void FieldsAreCorrectlyCopied()
        {
            copier.DuplicateFieldsValues(imported, entity);
            Assert.True(
                entity.IdBuilding == idParent
                && entity.AdditionalInformation == "Add"
                && entity.EstimatedWaterFlow == 2
                && entity.GarageType == Models.Buildings.GarageType.No
                && entity.Height == 3
                && entity.IdBuildingSidingType == idType
                && entity.IdBuildingType == idType
                && entity.IdConstructionFireResistanceType == idType
                && entity.IdConstructionType == idType
                && entity.IdRoofMaterialType == idType
                && entity.IdRoofType == idType
                && entity.IdUnitOfMeasureEstimatedWaterFlow == idType
                && entity.IdUnitOfMeasureHeight == idType
                && entity.RevisedOn == new DateTime(2010, 1, 1)
                && entity.ApprovedOn == new DateTime(2009, 1, 1)
            );
        }
    }
}