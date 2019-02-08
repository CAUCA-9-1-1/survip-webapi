using System;
using System.Drawing;
using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Import.Base;
using Survi.Prevention.ServiceLayer.Import.Base.Cache;
using FireHydrantAddressLocationType = Survi.Prevention.Models.FireHydrants.FireHydrantAddressLocationType;

namespace Survi.Prevention.ServiceLayer.Import.FireHydrantImportation
{
    public class FireHydrantImportationConverter
        : BaseEntityConverter<
            FireHydrant,
            Models.FireHydrants.FireHydrant>
    {
        public FireHydrantImportationConverter(
            IManagementContext context,
            AbstractValidator<FireHydrant> validator, CacheSystem cache)
            : base(context, validator, null, cache)
        {
        }

        protected override void CopyCustomFieldsToEntity(
            FireHydrant importedObject,
            Models.FireHydrants.FireHydrant entity)
        {
            entity.AddressLocationType = (FireHydrantAddressLocationType) importedObject.AddressLocationType;
            entity.Altitude = importedObject.Altitude;
            entity.CivicNumber = importedObject.CivicNumber;
            entity.Color = Color.FromArgb(importedObject.Color).ToHexString();
            entity.Comments = importedObject.Comments;
            entity.Coordinates = importedObject.WktCoordinates;
            entity.IdCity = Guid.Parse(importedObject.IdCity);
            entity.IdFireHydrantType = Guid.Parse(importedObject.IdFireHydrantType);
            entity.IdLaneTransversal = ParseId(importedObject.IdLaneTransversal);
            entity.IdLane = ParseId(importedObject.IdLane);
            entity.IdUnitOfMeasurePressure = ParseId(importedObject.IdUnitOfMeasurePressure);
            entity.IdUnitOfMeasureRate = ParseId(importedObject.IdUnitOfMeasureRate);
            entity.LocationType = (Models.FireHydrants.FireHydrantLocationType) importedObject.LocationType;
            entity.Number = importedObject.Number;
            entity.PhysicalPosition = importedObject.PhysicalPosition;
            entity.PressureFrom = importedObject.PressureFrom;
            entity.PressureTo = importedObject.PressureTo;
            entity.RateFrom = importedObject.RateFrom;
            entity.RateTo = importedObject.RateTo;
            entity.PressureOperatorType = (Models.FireHydrants.OperatorType) importedObject.PressureOperatorType;
            entity.RateOperatorType = (Models.FireHydrants.OperatorType) importedObject.RateOperatorType;
        }

        protected override void GetRealForeignKeys(FireHydrant importedObject)
        {
            importedObject.IdCity = GetRealId<Models.FireSafetyDepartments.City>(importedObject.IdCity);
            importedObject.IdFireHydrantType = GetRealId<Models.FireHydrants.FireHydrantType>(importedObject.IdFireHydrantType);
            importedObject.IdLaneTransversal = GetRealId<Models.FireSafetyDepartments.Lane>(importedObject.IdLaneTransversal);
            importedObject.IdLane = GetRealId<Models.FireSafetyDepartments.Lane>(importedObject.IdLane);
            importedObject.IdUnitOfMeasurePressure = GetRealId<Models.UnitOfMeasure>(importedObject.IdUnitOfMeasurePressure);
            importedObject.IdUnitOfMeasureRate = GetRealId<Models.UnitOfMeasure>(importedObject.IdUnitOfMeasureRate);
        }
    }
}