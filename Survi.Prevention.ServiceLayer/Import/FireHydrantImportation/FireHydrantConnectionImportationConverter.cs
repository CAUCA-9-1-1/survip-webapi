using System;
using System.Linq;
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
            var idFireHydrant = Context.FireHydrants.Where(m => m.IdExtern == importedObject.IdFireHydrant).Select(m => m.Id).FirstOrDefault();
            var idFireHydrantConnectionType = Context.FireHydrants.Where(m => m.IdExtern == importedObject.IdFireHydrantConnectionType).Select(m => m.Id).FirstOrDefault();
            var idUnitOfMeasureDiameter = Context.UnitOfMeasures.Where(m => m.IdExtern == importedObject.IdUnitOfMeasureDiameter).Select(m => m.Id).FirstOrDefault();

            importedObject.IdFireHydrant = idFireHydrant.ToString();
            importedObject.IdFireHydrantConnectionType = idFireHydrantConnectionType.ToString();
            importedObject.IdUnitOfMeasureDiameter = idUnitOfMeasureDiameter.ToString();
        }
    }
}