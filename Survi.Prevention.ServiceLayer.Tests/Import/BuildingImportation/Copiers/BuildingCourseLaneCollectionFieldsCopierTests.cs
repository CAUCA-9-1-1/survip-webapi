using System;
using System.Collections.Generic;
using System.Linq;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation.CustomFieldsCopiers;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation.Copiers
{
    public class BuildingCourseLaneCollectionFieldsCopierTests : BuildingCourseLaneCollectionFieldsCopier
    {
        [Fact]
        public void AllFieldsAreCorrectlyCopied()
        {
            var idLane = Guid.NewGuid();
            var imported = new BuildingCourseLane { Direction = CourseLaneDirection.StraightAhead, IdLane = idLane.ToString() };
            var entity = new Models.Buildings.BuildingCourseLane();
            CopyEntityValue(imported, entity);

            Assert.Equal(idLane, entity.IdLane);
            Assert.Equal(Models.Buildings.CourseLaneDirection.StraightAhead, entity.Direction);
        }

        [Fact]
        public void GetCorrespondingEntitiesReturnsANewLaneWhenMissing()
        {
            var entities = new List<Models.Buildings.BuildingCourseLane>();
            GetCorrespondingEntity(entities, 10);

            Assert.True(entities.Any());
        }

        [Fact]
        public void GetCorrespondingEntitiesReturnsExistingLaneWhenItExist()
        {
            var entity = new Models.Buildings.BuildingCourseLane {Sequence = 10, IsActive = true};
            var entities = new List<Models.Buildings.BuildingCourseLane> {entity};

            Assert.Equal(entity, GetCorrespondingEntity(entities, 10));
        }

        [Fact]
        public void GetCorrespondingEntitiesDoesNotReturnExistingLaneWhenItExistButIsInactive()
        {
            var entity = new Models.Buildings.BuildingCourseLane { Sequence = 10, IsActive = false };
            var entities = new List<Models.Buildings.BuildingCourseLane> { entity };

            Assert.NotEqual(entity, GetCorrespondingEntity(entities, 10));
        }

        [Fact]
        public void RemoveUnusedLaneRemovesLaneThatAreNotInUseAnymore()
        {
            var idLane = Guid.NewGuid();
            var imported = new BuildingCourseLane { Direction = CourseLaneDirection.StraightAhead, IdLane = idLane.ToString(), Sequence = 1 };
            var importedLanes = new List<BuildingCourseLane> {imported};
            var entity1 = new Models.Buildings.BuildingCourseLane { Sequence = 1, IsActive = true };
            var entity2 = new Models.Buildings.BuildingCourseLane { Sequence = 2, IsActive = true };
            var entities = new List<Models.Buildings.BuildingCourseLane> { entity1, entity2 };

            RemoveUnusedLane(importedLanes, entities);

            Assert.False(entity2.IsActive);
        }

        [Fact]
        public void RemoveUnusedLaneKeepsLaneThatAreNotInUseAnymore()
        {
            var idLane = Guid.NewGuid();
            var imported = new BuildingCourseLane { Direction = CourseLaneDirection.StraightAhead, IdLane = idLane.ToString(), Sequence = 1 };
            var importedLanes = new List<BuildingCourseLane> { imported };
            var entity1 = new Models.Buildings.BuildingCourseLane { Sequence = 1, IsActive = true };
            var entity2 = new Models.Buildings.BuildingCourseLane { Sequence = 2, IsActive = true };
            var entities = new List<Models.Buildings.BuildingCourseLane> { entity1, entity2 };

            RemoveUnusedLane(importedLanes, entities);

            Assert.True(entity1.IsActive);
        }
    }
}