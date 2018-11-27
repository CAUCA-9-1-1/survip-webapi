using System;
using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Import.Base;

namespace Survi.Prevention.ServiceLayer.Import.FireHydrantImportation
{
    public class FireHydrantConnectionImportationConverter
        : BaseEntityConverter<FireHydrantConnection, Models.FireHydrants.FireHydrantConnection>
    {
        public FireHydrantConnectionImportationConverter(
            IManagementContext context,
            AbstractValidator<FireHydrantConnection> validator)
            : base(context, validator)
        {
        }

        protected override void CopyCustomFieldsToEntity(
            FireHydrantConnection importedObject,
            Models.FireHydrants.FireHydrantConnection entity)
        {
            entity.Diameter = importedObject.Diameter;
            entity.IdFireHydrantConnectionType = Guid.Parse(importedObject.IdFireHydrantConnectionType);
            entity.IdUnitOfMeasureDiameter = Guid.Parse(importedObject.IdUnitOfMeasureDiameter);
            entity.IdFireHydrant = Guid.Parse(importedObject.IdFireHydrant);
        }

        protected override void GetRealForeignKeys(FireHydrantConnection importedObject)
        {
            importedObject.IdFireHydrant = GetRealId<Models.FireHydrants.FireHydrant>(importedObject.IdFireHydrant);
            importedObject.IdFireHydrantConnectionType = GetRealId<Models.FireHydrants.FireHydrantConnectionType>(importedObject.IdFireHydrantConnectionType);
            importedObject.IdUnitOfMeasureDiameter = GetRealId<Models.UnitOfMeasure>(importedObject.IdUnitOfMeasureDiameter);
        }
    }
}