using System;
using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Import.Base;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
    public class BuildingAnomalyImportationConverter
        : BaseEntityConverter<
            BuildingAnomaly,
            Models.Buildings.BuildingAnomaly>
    {
        public BuildingAnomalyImportationConverter(
            IManagementContext context,
            AbstractValidator<BuildingAnomaly> validator)
            : base(context, validator)
        {
        }

        protected override void GetRealForeignKeys(BuildingAnomaly importedObject)
        {            
            importedObject.IdBuilding = GetRealId<Models.Buildings.Building>(importedObject.IdBuilding);
        }

        protected override void CopyCustomFieldsToEntity(
            BuildingAnomaly importedObject,
            Models.Buildings.BuildingAnomaly entity)
        {
            entity.IdBuilding = Guid.Parse(importedObject.IdBuilding);
            entity.Notes = importedObject.Notes;
            entity.Theme = importedObject.Theme;
        }
    }
}