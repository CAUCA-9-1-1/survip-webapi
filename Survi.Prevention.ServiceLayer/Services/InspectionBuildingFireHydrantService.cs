using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.FireHydrants;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InspectionBuildingFireHydrantService : BaseService
	{
		public InspectionBuildingFireHydrantService(ManagementContext context) : base(context)
		{
		}

		public List<InspectionBuildingFireHydrantForList> GetFormFireHydrants(Guid inspectionId, string languageCode)
		{
			var results = (
				from inspection in Context.Inspections.AsNoTracking()
				where inspection.Id == inspectionId
				from formHydrant in inspection.MainBuilding.FireHydrants
				where formHydrant.IsActive
				let hydrant = formHydrant.Hydrant
				select new
				{
					formHydrant.Id,
					hydrant.Color,
					hydrant.Number,
					hydrant.IdLane,
					hydrant.IdIntersection,
					hydrant.PhysicalPosition,
					hydrant.LocationType,
					hydrant.Coordinates,
					formHydrant.IdFireHydrant,
					hydrant.CivicNumber,
					hydrant.AddressLocationType
				}).ToList();

			return results
				.Select(hydrant => new InspectionBuildingFireHydrantForList
				{
					Id = hydrant.Id,
					Color = hydrant.Color,
					IdInspection = inspectionId,
					Number = hydrant.Number,
					Address = GenerateAddress(hydrant.LocationType, hydrant.IdLane, hydrant.IdIntersection, hydrant.PhysicalPosition, hydrant.Coordinates, hydrant.CivicNumber, hydrant.AddressLocationType, languageCode),
					IdFireHydrant = hydrant.IdFireHydrant
				}).ToList();
		}

		private string GenerateAddress(FireHydrantLocationType type, Guid? idLane, Guid? idIntersection, string physicalPosition, NetTopologySuite.Geometries.Point coordinate, string civicNumber, FireHydrantAddressLocationType addressLocationType, string languageCode)
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

		public bool DeleteBuildingFireHydrant(Guid idBuildingFireHydrant)
		{
			var buildingfirehydrant = Context.BuildingFireHydrants.Find(idBuildingFireHydrant);
			if(buildingfirehydrant != null)
			{
				buildingfirehydrant.IsActive = false;
				Context.SaveChanges();
				return true;
			}
			return false;
		}

		public bool AddBuildingFireHydrant(Guid idBuilding, Guid idFireHydrant)
		{
			if((idBuilding != Guid.Empty) && (idFireHydrant != Guid.Empty))
			{
				Models.Buildings.BuildingFireHydrant newbf = new Models.Buildings.BuildingFireHydrant();
				newbf.IdFireHydrant = idFireHydrant;
				newbf.IdBuilding = idBuilding;
				newbf.IsActive = true;
				Context.BuildingFireHydrants.Add(newbf);

				Context.SaveChanges();
				return true;
			}
			return false;
		}
	}
}