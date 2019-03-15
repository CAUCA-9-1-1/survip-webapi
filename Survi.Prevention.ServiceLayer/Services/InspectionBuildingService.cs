using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.DataTransfertObjects.Inspections;
using Survi.Prevention.Models.InspectionManagement;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InspectionBuildingService : BaseService
	{
		public InspectionBuildingService(IManagementContext context) : base(context)
		{
		}

		public List<BatchInspectionBuilding> GetBuildingForManagement(Guid batchId, string languageCode)
		{
			var query =
				from building in Context.BatchInspectionBuildings.AsNoTracking()
				where building.LanguageCode == languageCode && building.IdBatch == batchId
				select building;

			return query.ToList();
		}

		public List<InspectionBuildingForList> GetBuildings(Guid inspectionId, string languageCode)
		{
			var results = (
				from inspection in Context.Inspections.AsNoTracking()
				where inspection.Id == inspectionId && inspection.IsActive
				from building in inspection.Buildings
				where building.IsActive
				select new
				{
					building.Id,
					building.AliasName,
                    building.CorporateName,
                    building.ChildType,
					building.Picture.Data
				}).ToList();

			return results
				.Select(building => new InspectionBuildingForList
				{
					Id = building.Id,
					IdInspection = inspectionId,
                    IsParent = building.ChildType == 0,
                    AliasName = building.AliasName,
                    CorporateName = building.CorporateName,
					Picture = building.Data == null ? null : Convert.ToBase64String(building.Data)
				})
                .ToList();
		}

	    public List<InspectionBuildingResume> GetBuildingsResume(Guid inspectionId)
	    {
	        var query =
	            from building in Context.InspectionBuildings.AsNoTracking()
	            where building.IsActive && building.IdInspection == inspectionId
	            select new InspectionBuildingResume
	            {
	                IdBuilding = building.Id,
	                AliasName = building.AliasName,
	                CorporateName = building.CorporateName,
	                IsMainBuilding = building.ChildType == BuildingChildType.None,
	                Coordinates = building.Coordinates,
	                IdLaneTransversal = building.IdLaneTransversal
	            };

	        var result = query.ToList();
	        return result;
	    }

        public List<InspectionForExport> GetInspectionForExport()
        {
            var query = (from inspection in Context.Inspections.AsNoTracking()
                where inspection.IsActive && inspection.Status == InspectionStatus.Approved
                from building in Context.Buildings
                where building.IsActive && building.Id == inspection.IdBuilding &&
                      !string.IsNullOrEmpty(building.IdExtern) &&
                      building.HasBeenModified
                from cityLoc in building.City.Localizations.Where(cl => cl.LanguageCode == "fr" && cl.IsActive)
                from laneLocalization in building.Lane.Localizations.Where(ll => ll.LanguageCode == "fr" && ll.IsActive)
                         select new InspectionForExport
                {
                    CityName = cityLoc.Name,
                    Name = building.AliasName,
                    Id = inspection.Id,
                    IdBuilding = inspection.IdBuilding,
                    IdCity = building.City.IdExtern,
                    Address = new AddressGenerator().GenerateAddress(building.CivicNumber, building.CivicLetter, laneLocalization.Name, building.Lane.LaneGenericCode.Description, building.Lane.PublicCode.Description, building.Lane.LaneGenericCode.AddWhiteSpaceAfter),
                    LastEditedOn = inspection.LastModifiedOn ?? DateTime.Now,
                    IdBuildingExtern = building.IdExtern
                });

            return query.ToList();
        }

	    public bool SaveBuildingsResume(InspectionBuildingResume building)
	    {
	        var currentBuilding = Context.InspectionBuildings.FirstOrDefault(b => b.Id == building.IdBuilding);
	        if (currentBuilding != null)
	        {
	            currentBuilding.IdLaneTransversal = building.IdLaneTransversal;
	            currentBuilding.AliasName = building.AliasName;
	            currentBuilding.CorporateName = building.CorporateName;
	        }
	        else
	            return false;

	        Context.SaveChanges();
	        return true;
	    }
	}
}
