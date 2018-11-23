﻿using System;
using System.Linq;
using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Base;
using Survi.Prevention.ServiceLayer.Import.Base;
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
            AbstractValidator<FireHydrant> validator
        )
            : base(context, validator)
        {
        }

        protected override void CopyCustomFieldsToEntity(
            FireHydrant importedObject,
            Models.FireHydrants.FireHydrant entity)
        {
            entity.AddressLocationType = (FireHydrantAddressLocationType) importedObject.AddressLocationType;
            entity.Altitude = importedObject.Altitude;
            entity.CivicNumber = importedObject.CivicNumber;
            entity.Color = importedObject.Color;
            entity.Comments = importedObject.Comments;
            entity.Coordinates = importedObject.WktCoordinates;
            entity.IdCity = Guid.Parse(importedObject.IdCity);
            entity.IdFireHydrantType = Guid.Parse(importedObject.IdFireHydrantType);
            entity.IdIntersection = ParseId(importedObject.IdIntersection);
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
        }

        protected override void GetRealForeignKeys(FireHydrant importedObject)
        {
            importedObject.IdCity = GetRealId<Models.FireSafetyDepartments.City>(importedObject.IdCity);
            importedObject.IdFireHydrantType = GetRealId<Models.FireHydrants.FireHydrantType>(importedObject.IdFireHydrantType);
            importedObject.IdIntersection = GetRealId<Models.FireSafetyDepartments.Lane>(importedObject.IdIntersection);
            importedObject.IdLane = GetRealId<Models.FireSafetyDepartments.Lane>(importedObject.IdLane);
            importedObject.IdUnitOfMeasurePressure = GetRealId<Models.UnitOfMeasure>(importedObject.IdUnitOfMeasurePressure);
            importedObject.IdUnitOfMeasureRate = GetRealId<Models.UnitOfMeasure>(importedObject.IdUnitOfMeasureRate);
        }
    }
}