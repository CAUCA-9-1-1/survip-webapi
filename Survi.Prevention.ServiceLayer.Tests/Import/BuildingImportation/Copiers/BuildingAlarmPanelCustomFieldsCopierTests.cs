using System;
using System.Collections.Generic;
using System.Linq;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation.CustomFieldsCopiers;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation.Copiers
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

    public class BuildingCourseFieldsCopierTests
    {
        private readonly BuildingCourseFieldsCopier copier;
        private readonly BuildingCourse imported;
        private readonly Models.Buildings.BuildingCourse entity;
        private readonly Guid idBuilding;
        private readonly Guid idFirestation;

        public BuildingCourseFieldsCopierTests()
        {
            idBuilding = Guid.NewGuid();
            idFirestation = Guid.NewGuid();
            var idLane = Guid.NewGuid();
            var importedLane = new BuildingCourseLane { Direction = CourseLaneDirection.StraightAhead, IdLane = idLane.ToString(), Sequence = 1 };
            var importedLanes = new List<BuildingCourseLane> { importedLane };

            copier = new BuildingCourseFieldsCopier();
            imported = new BuildingCourse
            {
                IdBuilding = idBuilding.ToString(),
                IdFirestation = idFirestation.ToString(),
                Lanes = importedLanes
            };
            entity = new Models.Buildings.BuildingCourse
            {
                Lanes = new List<Models.Buildings.BuildingCourseLane>()
            };
        }

        [Fact]
        public void IdFirestationIsCorrectlyCopied()
        {
            copier.DuplicateFieldsValues(imported, entity);
            Assert.Equal(idFirestation, entity.IdFirestation);
        }

        [Fact]
        public void IdBuildingIsCorrectlyCopied()
        {
            copier.DuplicateFieldsValues(imported, entity);
            Assert.Equal(idBuilding, entity.IdBuilding);
        }

        [Fact]
        public void LanesCorrectlyCopied()
        {
            copier.DuplicateFieldsValues(imported, entity);
            Assert.Equal(imported.Lanes.Count, entity.Lanes.Count(lane => lane.IsActive));
        }
    }
}