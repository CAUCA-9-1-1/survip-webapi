using System;
using System.Collections.Generic;
using System.Linq;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.FireHydrants;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class BuildingFireHydrantService 
	    : BaseCrudServiceWithImportation<BuildingFireHydrant, ApiClient.DataTransferObjects.BuildingFireHydrant>
	{
	    public BuildingFireHydrantService(
	        IManagementContext context, 
	        IEntityConverter<ApiClient.DataTransferObjects.BuildingFireHydrant, BuildingFireHydrant> converter) 
	        : base(context, converter)
	    {
	    }

        public List<FireHydrantForList> GetFireHydrants(Guid idBuilding, string languageCode)
		{
			var results = (
				from formHydrant in Context.BuildingFireHydrants
				where formHydrant.IsActive && formHydrant.IdBuilding == idBuilding
				let hydrant = formHydrant.Hydrant
				select new
				{
					formHydrant.Id,
					IdFireHdydrant = hydrant.Id,
					hydrant.Color,
					hydrant.Number,
					hydrant.IdLane,
					hydrant.IdIntersection,
					hydrant.PhysicalPosition,
					hydrant.LocationType,
					hydrant.PointCoordinates,
					formHydrant.IdFireHydrant,
					hydrant.CivicNumber,
					hydrant.AddressLocationType
				}).ToList();

			return results
				.Select(hydrant => new FireHydrantForList
				{
					Id = hydrant.Id,
					Color = hydrant.Color,
					Number = hydrant.Number,
					Address = GenerateAddress(hydrant.LocationType, hydrant.IdLane, hydrant.IdIntersection, hydrant.PhysicalPosition,
						hydrant.PointCoordinates, hydrant.CivicNumber, hydrant.AddressLocationType, languageCode),
				}).ToList();
		}

		public string GenerateAddress(FireHydrantLocationType type, Guid? idLane, Guid? idIntersection, string physicalPosition,
			NetTopologySuite.Geometries.Point coordinate, string civicNumber,
			FireHydrantAddressLocationType addressLocationType, string languageCode)
		{
			if (type == FireHydrantLocationType.Address)
			{
				return new AddressGeneratorWithDb().GenerateAddressFromAddressLocationType(Context, idLane, civicNumber, addressLocationType, languageCode);
			}
			if (type == FireHydrantLocationType.Text)
				return physicalPosition;
			if (type == FireHydrantLocationType.Coordinates)
			{
				if (physicalPosition != String.Empty)
					return physicalPosition;
				if (!coordinate.IsEmpty && coordinate.IsValid)
					return $"{coordinate.ToText()}";
			}

			if (type == FireHydrantLocationType.LaneAndIntersection)
				return new AddressGeneratorWithDb().GenerateAddressFromLanes(Context, idLane, idIntersection, languageCode);

			return "";
		}
	}
}