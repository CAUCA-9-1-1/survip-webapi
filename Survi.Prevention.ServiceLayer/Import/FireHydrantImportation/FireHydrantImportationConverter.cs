using System;
using System.Linq;
using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.DataLayer;
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
            entity.AddressLocationType = (FireHydrantAddressLocationType)importedObject.AddressLocationType;
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
            var idCity = Context.Cities.Where(m => m.IdExtern == importedObject.IdCity).Select(m => m.Id).FirstOrDefault();
            var idFireHydrantType = Context.FireHydrantTypes.Where(m => m.IdExtern == importedObject.IdFireHydrantType).Select(m => m.Id).FirstOrDefault();
            var idIntersection = Context.Lanes.Where(m => m.IdExtern == importedObject.IdIntersection).Select(m => m.Id).FirstOrDefault();
            var idLane = Context.Lanes.Where(m => m.IdExtern == importedObject.IdLane).Select(m => m.Id).FirstOrDefault();
            var idUnitOfMeasurePressure = Context.UnitOfMeasures.Where(m => m.IdExtern == importedObject.IdUnitOfMeasurePressure).Select(m => m.Id).FirstOrDefault();
            var idUnitOfMeasureRate = Context.UnitOfMeasures.Where(m => m.IdExtern == importedObject.IdUnitOfMeasureRate).Select(m => m.Id).FirstOrDefault();

            importedObject.IdCity = idCity.ToString();
            importedObject.IdFireHydrantType = idFireHydrantType.ToString();
            importedObject.IdIntersection = idIntersection.ToString();
            importedObject.IdLane = idLane.ToString();
            importedObject.IdUnitOfMeasurePressure = idUnitOfMeasurePressure.ToString();
            importedObject.IdUnitOfMeasureRate = idUnitOfMeasureRate.ToString();
        }

        private Guid? ParseId(string id)
        {
            if (!string.IsNullOrWhiteSpace(id) && Guid.TryParse(id, out Guid idParsed) && idParsed != Guid.Empty)
                return idParsed;
            return null;
        }
    }
}