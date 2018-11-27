using System;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation.CustomFieldsCopiers;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation.Copiers
{
    public class BuildingSprinklerCustomFieldsCopierTests
    {
        private readonly Guid idParent;
        private readonly Guid idType;
        private readonly BuildingSprinkler imported;
        private readonly Models.Buildings.BuildingSprinkler entity;
        private readonly BuildingSprinklerCustomFieldsCopier copier;

        public BuildingSprinklerCustomFieldsCopierTests()
        {
            copier = new BuildingSprinklerCustomFieldsCopier();
            idParent = Guid.NewGuid();
            idType = Guid.NewGuid();
            imported = new BuildingSprinkler
            {
                IdBuilding = idParent.ToString(),
                Floor = "F",
                IdSprinklerType = idType.ToString(),
                Sector = "S",
                Wall = "W",
                CollectorLocation = "CollLoc",
                PipeLocation = "PipeLoc"
            };

            entity = new Models.Buildings.BuildingSprinkler
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
        public void IdSprinklerTypeIsCorrectlyCopied()
        {
            copier.DuplicateFieldsValues(imported, entity);
            Assert.Equal(idType, entity.IdSprinklerType);
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

        [Fact]
        public void PipeLocationIsCorrectlyCopied()
        {
            copier.DuplicateFieldsValues(imported, entity);
            Assert.Equal("PipeLoc", entity.PipeLocation);
        }

        [Fact]
        public void CollectorLocationIsCorrectlyCopied()
        {
            copier.DuplicateFieldsValues(imported, entity);
            Assert.Equal("CollLoc", entity.CollectorLocation);
        }
    }
}