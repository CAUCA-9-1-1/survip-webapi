using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireHydrants;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Services
{
    public class FireHydrantService : BaseCrudService<FireHydrant>
    {
		public FireHydrantService(ManagementContext context) : base(context)
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
					IdIntersection = hydrant.IdIntersection,
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
					IdIntersection = hydrant.IdIntersection,
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
		    if (hydrant.LocationType == FireHydrantLocationType.Coordinates)
		    {
			    if (hydrant.PhysicalPosition != String.Empty)
				    return hydrant.PhysicalPosition;
			    if (!hydrant.PointCoordinates.IsEmpty && hydrant.PointCoordinates.IsValid)
				    return $"{hydrant.PointCoordinates.ToText()}";
		    }
		    if (hydrant.LocationType == FireHydrantLocationType.LaneAndIntersection)
		    {
			    return new AddressGeneratorWithDb().GenerateAddressFromLanes(Context, hydrant.IdLane, hydrant.IdIntersection, languageCode);
		    }
		    return "";
	    }
	}
}
