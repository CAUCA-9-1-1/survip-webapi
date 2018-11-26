using System;
using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Import.Base;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
    public class BuildingParticularRiskImportationConverter
        : BaseEntityConverter<
            BuildingParticularRisk,
            Models.Buildings.Base.BuildingParticularRisk>
    {
        public BuildingParticularRiskImportationConverter(
            IManagementContext context,
            AbstractValidator<BuildingParticularRisk> validator)
            : base(context, validator)
        {
        }

        protected override void GetRealForeignKeys(BuildingParticularRisk importedObject)
        {
            importedObject.IdBuilding = GetRealId<Models.Buildings.Building>(importedObject.IdBuilding);
        }

        protected override void CopyCustomFieldsToEntity(
            BuildingParticularRisk importedObject,
            Models.Buildings.Base.BuildingParticularRisk entity)
        {
            entity.Comments = importedObject.Comments;
            entity.Dimension = importedObject.Dimension;
            entity.HasOpening = importedObject.HasOpening;
            entity.IdBuilding = Guid.Parse(importedObject.IdBuilding);
            entity.IsWeakened = importedObject.IsWeakened;
            entity.Sector = importedObject.Sector;
            entity.Wall = importedObject.Wall;
        }
    }
}