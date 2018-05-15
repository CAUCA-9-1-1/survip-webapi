using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.InspectionManagement;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InspectionService : BaseService
	{
		public InspectionService(ManagementContext context) : base(context)
		{
		}

        public bool Remove(Guid id)
        {
            var entity = Context.Inspections.Find(id);
            entity.IsActive = false;
            Context.SaveChanges();

            return true;
        }

        public bool SetVisitStatus(InspectionVisitStatus status, Guid id)
        {
            var entity = Context.Inspections
                .Where(i => i.Id == id)
                .Include(i => i.Visits)
                .Single();
            var visit = entity.Visits
                .Where(v => v.Status == InspectionVisitStatus.WaitingApprobation)
                .OrderBy(v => v.CompletedOn)
                .Single();

            visit.Status = status;
            Context.SaveChanges();

            return true;
        }

        public List<BatchForList> GetGroupedUserInspections(string languageCode, Guid userId)
		{
			var query =
				from batch in Context.Batches
				where batch.IsActive
				      && batch.IsReadyForInspection
				      && batch.Users.Any(user => user.IdWebuser == userId)
				from inspection in batch.Inspections
				where inspection.IsActive
					  && !inspection.IsCompleted
				      && (inspection.IdWebuserAssignedTo == null || inspection.IdWebuserAssignedTo == userId)
				      && inspection.MainBuilding.IsActive
				let building = inspection.MainBuilding
				from laneLocalization in building.Lane.Localizations
				where laneLocalization.IsActive && laneLocalization.LanguageCode == languageCode
				select new 
				{
					inspection.Id,
					IdBatch = batch.Id,
					BatchDescription = batch.Description,
					inspection.IdBuilding,
					building.IdRiskLevel,
					building.Matricule,
					building.CivicLetter,
					building.CivicNumber,
					laneLocalization.Name,
					publicDescription = building.Lane.PublicCode.Description,
					GenericDescription = building.Lane.LaneGenericCode.Description,
					building.Lane.LaneGenericCode.AddWhiteSpaceAfter
				};

			var results = query.ToList()
				.Select(result => new InspectionForList
				{
					Id = result.Id,
					IdBatch = result.IdBatch,
					BatchDescription = result.BatchDescription,
					IdBuilding = result.IdBuilding,
					IdRiskLevel = result.IdRiskLevel,
					Matricule = result.Matricule,
					Address = new AddressGenerator()
						.GenerateAddress(result.CivicNumber, result.CivicLetter, result.Name, result.GenericDescription, result.publicDescription, result.AddWhiteSpaceAfter)
				});

			return results
				.GroupBy(data => new {data.IdBatch, data.BatchDescription})
				.Select(group => new BatchForList { Id = group.Key.IdBatch, Description = group.Key.BatchDescription, Inspections = group.ToList() })
				.ToList();
		}

        public List<InspectionForDashboard> GetToDoInspection(string languageCode)
        {
            var query =
                from inspection in Context.Inspections
                where inspection.IsActive && !inspection.IsCompleted
                let batch = inspection.Batch
                let building = inspection.MainBuilding
                let lane = building.Lane
                from laneLocalization in lane.Localizations.DefaultIfEmpty()
                where laneLocalization.IsActive && laneLocalization.LanguageCode == languageCode
                select new
                {
                    Inspection = inspection,
                    Batch = batch,
                    Building = building,
                    LaneName = laneLocalization.Name,
                    IdCity = lane.IdCity,
                    PublicDescription = lane.PublicCode.Description,
                    GenericDescription = lane.LaneGenericCode.Description,
                    AddWhiteSpaceAfter = (Boolean)lane.LaneGenericCode.AddWhiteSpaceAfter
                };

            var results = query.ToList()
                .Select(r => new InspectionForDashboard
                {
                    Id = r.Inspection.Id,
                    IdBatch = r.Inspection.IdBatch,
                    BatchDescription = r.Batch.Description,
                    IdBuilding = r.Building.Id,
                    IdRiskLevel = r.Building.IdRiskLevel,
                    IdWebuserAssignedTo = r.Inspection.IdWebuserAssignedTo,
                    Address = new AddressGenerator()
                        .GenerateAddress(r.Building.CivicNumber, r.Building.CivicLetter, r.LaneName, r.GenericDescription, r.PublicDescription, r.AddWhiteSpaceAfter),
                    IdCity = r.IdCity,
                    IdLaneTransversal = r.Building.IdLaneTransversal,
                    PostalCode = r.Building.PostalCode,
                    VisitStatus = InspectionVisitStatus.Todo,
                    HasVisitNote = false,
                    HasAnomaly = Context.BuildingAnomalies.Any(a => a.IsActive && a.IdBuilding == r.Building.Id),
                    //LastInspectionOn = null,
                    Contact = "",
                    Owner = "",
                    IdUtilisationCode = r.Building.IdUtilisationCode,
                    IdPicture = r.Building.IdPicture,
                    BuildingValue = r.Building.BuildingValue,
                    Matricule = r.Building.Matricule,
                    NumberOfAppartment = r.Building.NumberOfAppartment,
                    NumberOfBuilding = r.Building.NumberOfBuilding,
                    NumberOfFloor = r.Building.NumberOfFloor,
                    VacantLand = r.Building.VacantLand,
                    Details = r.Building.Details
                });

            return results.ToList();
        }

        public List<InspectionForDashboard> GetForApprovalInspection(string languageCode)
        {
            var query =
                from inspection in Context.Inspections
                where inspection.IsActive && inspection.IsCompleted
                orderby inspection.CompletedOn
                let batch = inspection.Batch
                let building = inspection.MainBuilding
                let lane = building.Lane
                from laneLocalization in lane.Localizations.DefaultIfEmpty()
                where laneLocalization.IsActive && laneLocalization.LanguageCode == languageCode
                from visits in inspection.Visits
                where visits.IsActive && visits.Status == InspectionVisitStatus.WaitingApprobation
                orderby visits.CompletedOn
                select new
                {
                    Inspection = inspection,
                    Batch = batch,
                    Visit = visits,
                    Building = building,
                    LaneName = laneLocalization.Name,
                    IdCity = lane.IdCity,
                    PublicDescription = lane.PublicCode.Description,
                    GenericDescription = lane.LaneGenericCode.Description,
                    AddWhiteSpaceAfter = (Boolean)lane.LaneGenericCode.AddWhiteSpaceAfter
                };

            var results = query
                .ToList()
                .Select(r => new InspectionForDashboard
                {
                    Id = r.Inspection.Id,
                    IdBatch = r.Inspection.IdBatch,
                    BatchDescription = r.Batch.Description,
                    IdBuilding = r.Building.Id,
                    IdRiskLevel = r.Building.IdRiskLevel,
                    IdWebuserAssignedTo = r.Inspection.IdWebuserAssignedTo,
                    Address = new AddressGenerator()
                        .GenerateAddress(r.Building.CivicNumber, r.Building.CivicLetter, r.LaneName, r.GenericDescription, r.PublicDescription, r.AddWhiteSpaceAfter),
                    IdCity = r.IdCity,
                    IdLaneTransversal = r.Building.IdLaneTransversal,
                    PostalCode = r.Building.PostalCode,
                    VisitStatus = r.Visit.Status,
                    HasVisitNote = false,
                    HasAnomaly = Context.BuildingAnomalies.Any(a => a.IsActive && a.IdBuilding == r.Building.Id),
                    //LastInspectionOn = null,
                    Contact = "",
                    Owner = "",
                    IdUtilisationCode = r.Building.IdUtilisationCode,
                    IdPicture = r.Building.IdPicture,
                    BuildingValue = r.Building.BuildingValue,
                    Matricule = r.Building.Matricule,
                    NumberOfAppartment = r.Building.NumberOfAppartment,
                    NumberOfBuilding = r.Building.NumberOfBuilding,
                    NumberOfFloor = r.Building.NumberOfFloor,
                    VacantLand = r.Building.VacantLand,
                    Details = r.Building.Details
                });

            return results.ToList();
        }

        public List<InspectionForDashboard> GetBuildingWithHistory(string languageCode)
        {
            var query =
                from building in Context.Buildings
                where building.IsActive == true && building.IsParent == true
                join inspection in Context.Inspections
                on building.Id equals inspection.IdBuilding
                where inspection.IsActive && inspection.IsCompleted
                orderby inspection.CompletedOn
                let batch = inspection.Batch
                let lane = building.Lane
                from laneLocalization in lane.Localizations
                where laneLocalization.IsActive && laneLocalization.LanguageCode == languageCode
                from visits in inspection.Visits
                where visits.IsActive && visits.Status == InspectionVisitStatus.Approved
                select new
                {
                    Inspection = inspection,
                    Batch = batch,
                    Building = building,
                    LaneName = laneLocalization.Name,
                    LaneIdCity = lane.IdCity,
                    PublicDescription = lane.PublicCode.Description,
                    GenericDescription = lane.LaneGenericCode.Description,
                    AddWhiteSpaceAfter = (Boolean)lane.LaneGenericCode.AddWhiteSpaceAfter,
                };

            var results = query
            .Select(r => new InspectionForDashboard
            {
                Id = Guid.Empty,
                IdBatch = Guid.Empty,
                BatchDescription = "",
                IdBuilding = r.Building.Id,
                IdRiskLevel = r.Building.IdRiskLevel,
                IdWebuserAssignedTo = r.Inspection.IdWebuserAssignedTo,
                Address = new AddressGenerator()
                    .GenerateAddress(r.Building.CivicNumber, r.Building.CivicLetter, r.LaneName, r.GenericDescription, r.PublicDescription, r.AddWhiteSpaceAfter),
                IdCity = r.LaneIdCity,
                IdLaneTransversal = r.Building.IdLaneTransversal,
                PostalCode = r.Building.PostalCode,
                VisitStatus = InspectionVisitStatus.Approved,
                HasVisitNote = false,
                HasAnomaly = Context.BuildingAnomalies.Any(a => a.IsActive && a.IdBuilding == r.Building.Id),
                LastInspectionOn = (DateTime)r.Inspection.CompletedOn,
                Contact = "",
                Owner = "",
                IdUtilisationCode = r.Building.IdUtilisationCode,
                IdPicture = r.Building.IdPicture,
                BuildingValue = r.Building.BuildingValue,
                Matricule = r.Building.Matricule,
                NumberOfAppartment = r.Building.NumberOfAppartment,
                NumberOfBuilding = r.Building.NumberOfBuilding,
                NumberOfFloor = r.Building.NumberOfFloor,
                VacantLand = r.Building.VacantLand,
                Details = r.Building.Details
            });

            return results.ToList();
        }

        public List<InspectionForDashboard> GetBuildingWithoutInspection(string languageCode)
        {
            var query =
                from building in Context.Buildings
                where building.IsActive == true && building.IsParent == true && !Context.Inspections.Any(i => i.IsActive && !i.IsCompleted && i.IdBuilding == building.Id)
                let lane = building.Lane
                from laneLocalization in lane.Localizations
                where laneLocalization.IsActive && laneLocalization.LanguageCode == languageCode
                select new
                {
                    Building = building,
                    LaneName = laneLocalization.Name,
                    IdCity = lane.IdCity,
                    PublicDescription = lane.PublicCode.Description,
                    GenericDescription = lane.LaneGenericCode.Description,
                    AddWhiteSpaceAfter = (Boolean)lane.LaneGenericCode.AddWhiteSpaceAfter,
                };

            var results = query
                .Select(r => new InspectionForDashboard
                {
                    Id = Guid.Empty,
                    IdBatch = Guid.Empty,
                    BatchDescription = "",
                    IdBuilding = r.Building.Id,
                    IdRiskLevel = r.Building.IdRiskLevel,
                    Address = new AddressGenerator()
                        .GenerateAddress(r.Building.CivicNumber, r.Building.CivicLetter, r.LaneName, r.GenericDescription, r.PublicDescription, r.AddWhiteSpaceAfter),
                    IdCity = r.IdCity,
                    IdLaneTransversal = r.Building.IdLaneTransversal,
                    PostalCode = r.Building.PostalCode,
                    VisitStatus = InspectionVisitStatus.Todo,
                    HasVisitNote = false,
                    HasAnomaly = Context.BuildingAnomalies.Any(a => a.IsActive && a.IdBuilding == r.Building.Id),
                    //LastInspectionOn = null,
                    Contact = "",
                    Owner = "",
                    IdUtilisationCode = r.Building.IdUtilisationCode,
                    IdPicture = r.Building.IdPicture,
                    BuildingValue = r.Building.BuildingValue,
                    Matricule = r.Building.Matricule,
                    NumberOfAppartment = r.Building.NumberOfAppartment,
                    NumberOfBuilding = r.Building.NumberOfBuilding,
                    NumberOfFloor = r.Building.NumberOfFloor,
                    VacantLand = r.Building.VacantLand,
                    Details = r.Building.Details
                });

            return results.ToList();
        }
	}
}