using System;
using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Import.Base;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
    public class BuildingFireHydrantImportationConverter
        : BaseEntityConverter<
            BuildingFireHydrant,
            Models.Buildings.BuildingFireHydrant>
    {
        public BuildingFireHydrantImportationConverter(
            IManagementContext context,
            AbstractValidator<BuildingFireHydrant> validator)
            : base(context, validator, null)
        {
        }

        protected override void GetRealForeignKeys(BuildingFireHydrant importedObject)
        {
            importedObject.IdFireHydrant = GetRealId<Models.FireHydrants.FireHydrant>(importedObject.IdFireHydrant);
            importedObject.IdBuilding = GetRealId<Models.Buildings.Building>(importedObject.IdBuilding);
        }

        protected override void CopyCustomFieldsToEntity(BuildingFireHydrant importedObject, Models.Buildings.BuildingFireHydrant entity)
        {
            entity.IdFireHydrant = Guid.Parse(importedObject.IdFireHydrant);
            entity.IdBuilding = Guid.Parse(importedObject.IdBuilding);
        }
    }
}