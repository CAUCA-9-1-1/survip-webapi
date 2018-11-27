using System;
using System.Collections.Generic;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation;
using Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation.Mocks;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation
{
    public class BuildingAlarmPanelCustomFieldsCopierTests
    {
        private readonly Guid idParent;
        private readonly Guid idType;
        private readonly BuildingAlarmPanel imported;
        private readonly Models.Buildings.BuildingAlarmPanel entity;
        private readonly BuildingAlarmPanelCustomFieldsCopier copier;

        public BuildingAlarmPanelCustomFieldsCopierTests()
        {
            copier = new BuildingAlarmPanelCustomFieldsCopier();
            idParent = Guid.NewGuid();
            idType = Guid.NewGuid();
            imported = new BuildingAlarmPanel
            {
                IdBuilding = idParent.ToString(),
                Floor = "F",
                IdAlarmPanelType = idType.ToString(),
                Sector = "S",
                Wall = "W"                
            };

            entity = new Models.Buildings.BuildingAlarmPanel
            {
                IdBuilding = Guid.NewGuid(),
            };
        }

        [Fact]
        public void IdParentIsCorrectlyCopied()
        {
            copier.DuplicateFieldsValues(imported, entity);
            Assert.Equal(idParent, entity.IdBuilding);
        }

        [Fact]
        public void IdAlarmPanelTypeIsCorrectlyCopied()
        {
            copier.DuplicateFieldsValues(imported, entity);
            Assert.Equal(idType, entity.IdAlarmPanelType);
        }

        [Fact]
        public void FloorIsCorrectlyCopied()
        {
            copier.DuplicateFieldsValues(imported, entity);
            Assert.Equal("F", entity.Floor);
        }


        [Fact]
        public void SectorIsCorrectlyCopied()
        {
            copier.DuplicateFieldsValues(imported, entity);
            Assert.Equal("S", entity.Sector);
        }

        [Fact]
        public void WallIsCorrectlyCopied()
        {
            copier.DuplicateFieldsValues(imported, entity);
            Assert.Equal("W", entity.Wall);
        }
    }

    public class BuildingAnomalyCustomFieldsCopierTests
    {
        private readonly Guid idParent;
        private readonly BuildingAnomaly imported;
        private readonly Models.Buildings.BuildingAnomaly entity;
        private readonly BuildingAnomalyCustomFieldsCopier copier;

        public BuildingAnomalyCustomFieldsCopierTests()
        {
            copier = new BuildingAnomalyCustomFieldsCopier();
            idParent = Guid.NewGuid();
            imported = new BuildingAnomaly
            {
                IdBuilding = idParent.ToString(),
                Notes = "Notes",
                Theme = "Theme"
            };

            entity = new Models.Buildings.BuildingAnomaly
            {
                IdBuilding = Guid.NewGuid(),
            };
        }

        [Fact]
        public void IdBuildingIsCorrectlyCopied()
        {
            copier.DuplicateFieldsValues(imported, entity);
            Assert.Equal(idParent, entity.IdBuilding);
        }

        [Fact]
        public void NotesIsCorrectlyCopied()
        {
            copier.DuplicateFieldsValues(imported, entity);
            Assert.Equal("Notes", entity.Notes);
        }

        [Fact]
        public void ThemeIsCorrectlyCopied()
        {
            copier.DuplicateFieldsValues(imported, entity);
            Assert.Equal("Theme", entity.Theme);
        }
    }
}