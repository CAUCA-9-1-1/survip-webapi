using System;
using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Import.Base;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
    public class BuildingSprinklerImportationConverter
        : BaseEntityConverter<
            BuildingSprinkler,
            Models.Buildings.BuildingSprinkler>
    {
        public BuildingSprinklerImportationConverter(
            IManagementContext context,
            AbstractValidator<BuildingSprinkler> validator)
            : base(context, validator)
        {
        }

        protected override void GetRealForeignKeys(BuildingSprinkler importedObject)
        {
            importedObject.IdSprinklerType = GetRealId<Models.Buildings.SprinklerType>(importedObject.IdSprinklerType);
            importedObject.IdBuilding = GetRealId<Models.Buildings.Building>(importedObject.IdBuilding);
        }

        protected override void CopyCustomFieldsToEntity(
            BuildingSprinkler importedObject,
            Models.Buildings.BuildingSprinkler entity)
        {
            entity.Floor = importedObject.Floor;
            entity.IdBuilding = Guid.Parse(importedObject.IdBuilding);
            entity.IdSprinklerType = Guid.Parse(importedObject.IdSprinklerType);
            entity.PipeLocation = importedObject.PipeLocation;
            entity.Sector = importedObject.Sector;
            entity.Wall = importedObject.Wall;
            entity.CollectorLocation = importedObject.CollectorLocation;
        }
    }
}