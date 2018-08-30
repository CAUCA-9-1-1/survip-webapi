using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.FireHydrants;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

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
				from building in inspection.Buildings
				where building.ChildType == Models.Buildings.BuildingChildType.None
				from formHydrant in building.FireHydrants
				where formHydrant.IsActive
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
				.Select(hydrant => new InspectionBuildingFireHydrantForList
				{
					Id = hydrant.Id,
					Color = hydrant.Color,
					IdInspection = inspectionId,
					Number = hydrant.Number,
					Address = GenerateAddress(hydrant.LocationType, hydrant.IdLane, hydrant.IdIntersection, hydrant.PhysicalPosition, 
						hydrant.PointCoordinates, hydrant.CivicNumber, hydrant.AddressLocationType, languageCode),
					IdFireHydrant = hydrant.IdFireHydrant
				}).ToList();
		}

		private string GenerateAddress(FireHydrantLocationType type, Guid? idLane, Guid? idIntersection, string physicalPosition, 
			NetTopologySuite.Geometries.Point coordinate, string civicNumber, FireHydrantAddressLocationType addressLocationType, string languageCode)
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
			var buildingfirehydrant = Context.InspectionBuildingFireHydrants.Find(idBuildingFireHydrant);
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
			if(idBuilding != Guid.Empty && idFireHydrant != Guid.Empty)
			{
				var fireHydrant = new InspectionBuildingFireHydrant
				{
					IdFireHydrant = idFireHydrant,
					IdBuilding = idBuilding,
					IsActive = true
				};
				Context.InspectionBuildingFireHydrants.Add(fireHydrant);

				Context.SaveChanges();
				return true;
			}
			return false;
		}
	}
}