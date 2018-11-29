using System;
using System.Collections.Generic;
using System.Linq;
using Survi.Prevention.ApiClient.DataTransferObjects;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.CustomFieldsCopiers
{
    public class BuildingCourseLaneCollectionFieldsCopier     
    {
        public void CopyValues(List<BuildingCourseLane> lanes, ICollection<Models.Buildings.BuildingCourseLane> entities)
        {
            RemoveUnusedLane(lanes, entities);
            lanes.ForEach(lane => CopyEntityValue(lane, GetCorrespondingEntity(entities, lane.Sequence)));
        }

        protected void RemoveUnusedLane(List<BuildingCourseLane> lanes, ICollection<Models.Buildings.BuildingCourseLane> entities)
        {
            entities
                .Where(entity => entity.IsActive 
                                 && lanes.All(lane => lane.Sequence != entity.Sequence))
                .ToList()
                .ForEach(entity => entity.IsActive = false);
        }

        protected void CopyEntityValue(BuildingCourseLane lane, Models.Buildings.BuildingCourseLane entity)
        {
            entity.IdLane = Guid.Parse(lane.IdLane);
            entity.Direction = (Models.Buildings.CourseLaneDirection) lane.Direction;
            entity.ImportedOn = DateTime.Now;
        }

        protected Models.Buildings.BuildingCourseLane GetCorrespondingEntity(ICollection<Models.Buildings.BuildingCourseLane> entities, int sequence)
        {
            return entities.FirstOrDefault(entity => entity.IsActive && entity.Sequence == sequence)
                   ?? CreateNewLane(entities);
        }

        protected Models.Buildings.BuildingCourseLane CreateNewLane(ICollection<Models.Buildings.BuildingCourseLane> entities)
        {
            var lane = new Models.Buildings.BuildingCourseLane();
            entities.Add(lane);
            return lane;
        }
    }
}