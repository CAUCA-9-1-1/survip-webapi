using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireHydrants;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;

namespace Survi.Prevention.ServiceLayer.Services
{
    public class FireHydrantService 
        : BaseCrudServiceWithImportation<FireHydrant, ApiClient.DataTransferObjects.FireHydrant>
    {
		public FireHydrantService(
		    IManagementContext context, 
		    IEntityConverter<ApiClient.DataTransferObjects.FireHydrant, FireHydrant> converter)
		    : base(context, converter)
		{
		}

	    public IQueryable<FireHydrant> GetList(List<Guid> idCities)
	    {
		    var query = Context.FireHydrants
			    .Where(b => idCities.Contains(b.IdCity) && b.IsActive);

		    return query;
	    }
	    
		public List<FireHydrantForList> GetListForCity(Guid idCity, string languageCode)
		{
			var results = (
				from hydrant in Context.FireHydrants.AsNoTracking()
				where hydrant.IsActive && hydrant.IdCity == idCity
				select new FireHydrant
				{
					Id = hydrant.Id,
					Number = hydrant.Number,
					IdLane = hydrant.IdLane,
					IdLaneTransversal = hydrant.IdLaneTransversal,
					PhysicalPosition = hydrant.PhysicalPosition,
					LocationType = hydrant.LocationType,
					Coordinates = hydrant.Coordinates,
					Color = hydrant.Color,
					CivicNumber = hydrant.CivicNumber,
					AddressLocationType = hydrant.AddressLocationType
				}).ToList();

			return results
				.Select(hydrant => new FireHydrantForList
				{
					Id = hydrant.Id,
					Color = hydrant.Color,
					Number = hydrant.Number,
					Address = GetFireHydrantAddress(hydrant, languageCode)

				}).ToList();
		}

        public List<FireHydrantForList> GetListForBuilding(Guid idBuilding, int distance, string languageCode)
        {
            /*var building = Context.Buildings.AsNoTracking()
                .Where(b => b.Id == idBuilding)
                .Select(b => new { b.PointCoordinates, b.IdCity}).First();*/

            var results = Context.FireHydrants.FromSql(@"
                select  fire_hydrant.*
                From building
                inner join fire_hydrant on fire_hydrant.id_city = building.id_city
                where building.id = {0}
                and st_dwithin(building.coordinates, fire_hydrant.coordinates, {1}, false)
                and fire_hydrant.is_active = true", idBuilding, distance);

            /*
            fire_hydrant.id as Id, fire_hydrant.location_type as LocationType, 
                   fire_hydrant.coordinates as Coordinates, fire_hydrant.number as Number, 
                   fire_hydrant.color as Color, fire_hydrant.physical_position as PhysicalPosition, 
                   fire_hydrant.civic_number as CivicNumber, fire_hydrant.id_lane as IdLane, 
                   fire_hydrant.id_intersection as IdIntersection, fire_hydrant.address_location_type as AddressLocationType

            var query = 
                from hydrant in Context.FireHydrants.AsNoTracking()
                where hydrant.IsActive && hydrant.IdCity == building.IdCity
                                       && (hydrant.PointCoordinates).Distance(building.PointCoordinates) < 200
                select new FireHydrant
                {
                    Id = hydrant.Id,
                    Number = hydrant.Number,
                    IdLane = hydrant.IdLane,
                    IdIntersection = hydrant.IdIntersection,
                    PhysicalPosition = hydrant.PhysicalPosition,
                    LocationType = hydrant.LocationType,
                    Coordinates = hydrant.Coordinates,
                    Color = hydrant.Color,
                    CivicNumber = hydrant.CivicNumber,
                    AddressLocationType = hydrant.AddressLocationType
                };

            var results = query.ToList();*/

            return results
                .Select(hydrant => new FireHydrantForList
                {
                    Id = hydrant.Id,
                    Color = hydrant.Color,
                    Number = hydrant.Number,
                    Address = GetFireHydrantAddress(hydrant, languageCode)

                }).ToList();
        }

        public List<FireHydrantForList> GetCityListForBuilding(Guid idCity, Guid idBuilding, string languageCode)
		{
			var results = (
				from hydrant in Context.FireHydrants.AsNoTracking()
				where hydrant.IsActive && hydrant.IdCity == idCity
				&& !Context.InspectionBuildingFireHydrants.Any(bf => bf.IdBuilding == idBuilding && bf.IdFireHydrant == hydrant.Id && bf.IsActive)
				select new FireHydrant
				{
					Id = hydrant.Id,
					Number = hydrant.Number,
					IdLane = hydrant.IdLane,
					IdLaneTransversal = hydrant.IdLaneTransversal,
					PhysicalPosition = hydrant.PhysicalPosition,
					LocationType = hydrant.LocationType,
					PointCoordinates = hydrant.PointCoordinates,
					Color = hydrant.Color,
					CivicNumber = hydrant.CivicNumber,
					AddressLocationType = hydrant.AddressLocationType
				}).ToList();

			return results
				.Select(hydrant => new FireHydrantForList
				{
					Id = hydrant.Id,
					Color = hydrant.Color,
					Number = hydrant.Number,
					Address = GetFireHydrantAddress(hydrant, languageCode)

				}).ToList();
		}


	    private string GetFireHydrantAddress(FireHydrant hydrant, string languageCode)
	    {
		    if (hydrant.LocationType == FireHydrantLocationType.Address)
		    {
			    return new AddressGeneratorWithDb().GenerateAddressFromAddressLocationType(Context, hydrant.IdLane, hydrant.CivicNumber, hydrant.AddressLocationType, languageCode);
		    }
		    if (hydrant.LocationType == FireHydrantLocationType.Text)
			    return hydrant.PhysicalPosition;
		    if (hydrant.LocationType == FireHydrantLocationType.NotSpecified)
		    {
			    if (hydrant.PhysicalPosition != String.Empty)
				    return hydrant.PhysicalPosition;
			    if (!hydrant.PointCoordinates.IsEmpty && hydrant.PointCoordinates.IsValid)
				    return $"{hydrant.PointCoordinates.ToText()}";
		    }
		    if (hydrant.LocationType == FireHydrantLocationType.LaneAndTransversal)
		    {
			    return new AddressGeneratorWithDb().GenerateAddressFromLanes(Context, hydrant.IdLane, hydrant.IdLaneTransversal, languageCode);
		    }
		    return "";
	    }
	}
}
