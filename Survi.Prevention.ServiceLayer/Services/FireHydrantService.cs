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

        public override FireHydrant Get(Guid id)
        {
            var result = Context.FireHydrants
                        .First(s => s.Id == id);

            return result;
        }

        public override List<FireHydrant> GetList()
        {
            var result = Context.FireHydrants
                        .ToList();

            return result;
        }
		public List<FireHydrantForList> GetListForCity(Guid idCity, string languageCode)
		{
			var results = (
				from hydrant in Context.FireHydrants.AsNoTracking()
				where hydrant.IsActive && hydrant.IdCity == idCity
				select new
				{
					hydrant.Id,
					hydrant.Number,
					hydrant.IdLane,
					hydrant.IdIntersection,
					hydrant.PhysicalPosition,
					hydrant.LocationType,
					hydrant.Coordinates,
					hydrant.Color
				}).ToList();

			return results
				.Select(hydrant => new FireHydrantForList
				{
					Id = hydrant.Id,
					Color = hydrant.Color,
					Number = hydrant.Number,
					Address = GetFireHydrantAddress(hydrant.LocationType, hydrant.IdLane, hydrant.IdIntersection, hydrant.PhysicalPosition, hydrant.Coordinates, languageCode)

				}).ToList();
		}

		public List<FireHydrantForList> GetCityListForBuilding(Guid idCity, Guid idBuilding, string languageCode)
		{
			var results = (
				from hydrant in Context.FireHydrants.AsNoTracking()
				where hydrant.IsActive && hydrant.IdCity == idCity
				&& !Context.BuildingFireHydrants.Any(bf => bf.IdBuilding == idBuilding && bf.IdFireHydrant == hydrant.Id && bf.IsActive)
				select new
				{
					hydrant.Id,
					hydrant.Number,
					hydrant.IdLane,
					hydrant.IdIntersection,
					hydrant.PhysicalPosition,
					hydrant.LocationType,
					hydrant.Coordinates,
					hydrant.Color
				}).ToList();

			return results
				.Select(hydrant => new FireHydrantForList
				{
					Id = hydrant.Id,
					Color = hydrant.Color,
					Number = hydrant.Number,
					Address = GetFireHydrantAddress(hydrant.LocationType, hydrant.IdLane, hydrant.IdIntersection, hydrant.PhysicalPosition, hydrant.Coordinates, languageCode)

				}).ToList();
		}

		private string GetFireHydrantAddress(FireHydrantLocationType type, Guid? idLane, Guid? idIntersection, string physicalPosition, string coordinate, string languageCode)
		{
			if (type == FireHydrantLocationType.Text)
				return physicalPosition;
			if (type == FireHydrantLocationType.Coordinates)
				return coordinate;
			if (type == FireHydrantLocationType.LaneAndIntersection)
			{
				return new AddressGeneratorWithDb().GenerateAddressFromLanes(Context, idLane, idIntersection, languageCode);
			}
			return "";
		}
	}
}
