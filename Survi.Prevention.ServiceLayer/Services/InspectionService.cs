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

        public bool SetStatus(InspectionStatus status, Guid id)
        {
            var entity = Context.Inspections
                .Where(i => i.Id == id)
                .Include(i => i.Visits)
                .Single();

            entity.Status = status;
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
					  && (inspection.Status == InspectionStatus.Todo || inspection.Status == InspectionStatus.Started || inspection.Status == InspectionStatus.Refused)
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
                from inspection in Context.Inspections.AsNoTracking()
                where inspection.IsActive && (inspection.Status == InspectionStatus.Todo || inspection.Status == InspectionStatus.Started || inspection.Status == InspectionStatus.Refused)
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
                    lane.IdCity,
                    PublicDescription = lane.PublicCode.Description,
                    GenericDescription = lane.LaneGenericCode.Description,
                    lane.LaneGenericCode.AddWhiteSpaceAfter
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
	                InspectionStatus = InspectionStatus.Todo,
                    HasAnomaly = Context.BuildingAnomalies.Any(a => a.IsActive && a.IdBuilding == r.Building.Id),
                    IdUtilisationCode = r.Building.IdUtilisationCode,
                    IdPicture = r.Building.IdPicture,
                    BuildingValue = r.Building.BuildingValue,
                    Matricule = r.Building.Matricule,
                    NumberOfAppartment = r.Building.NumberOfAppartment,
                    NumberOfBuilding = r.Building.NumberOfBuilding,
                    NumberOfFloor = r.Building.NumberOfFloor,
                    VacantLand = r.Building.VacantLand,
                    YearOfConstruction = r.Building.YearOfConstruction,
                    Details = r.Building.Details
                });

            return InsertMissingInformation(results.ToList());
        }

        public List<InspectionForDashboard> GetForApprovalInspection(string languageCode)
        {
            var query =
                from inspection in Context.Inspections.AsNoTracking()
                where inspection.IsActive && inspection.Status == InspectionStatus.WaitingForApprobation
                orderby inspection.CompletedOn
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
                    lane.IdCity,
                    PublicDescription = lane.PublicCode.Description,
                    GenericDescription = lane.LaneGenericCode.Description,
                    lane.LaneGenericCode.AddWhiteSpaceAfter
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
	                InspectionStatus = InspectionStatus.WaitingForApprobation,
                    HasAnomaly = Context.BuildingAnomalies.Any(a => a.IsActive && a.IdBuilding == r.Building.Id),
                    IdUtilisationCode = r.Building.IdUtilisationCode,
                    IdPicture = r.Building.IdPicture,
                    BuildingValue = r.Building.BuildingValue,
                    Matricule = r.Building.Matricule,
                    NumberOfAppartment = r.Building.NumberOfAppartment,
                    NumberOfBuilding = r.Building.NumberOfBuilding,
                    NumberOfFloor = r.Building.NumberOfFloor,
                    VacantLand = r.Building.VacantLand,
                    YearOfConstruction = r.Building.YearOfConstruction,
                    Details = r.Building.Details
                });

            return InsertMissingInformation(results.ToList());
        }

        public List<InspectionForDashboard> GetBuildingWithHistory(string languageCode)
        {
            var query =
                from building in Context.Buildings
                where building.IsActive && building.IsParent 
                join inspection in Context.Inspections.AsNoTracking()
                on building.Id equals inspection.IdBuilding
                where inspection.IsActive && inspection.Status == InspectionStatus.Approved
                orderby inspection.CompletedOn
                let batch = inspection.Batch
                let lane = building.Lane
                from laneLocalization in lane.Localizations
                where laneLocalization.IsActive && laneLocalization.LanguageCode == languageCode
                select new
                {
                    Inspection = inspection,
                    Batch = batch,
                    Building = building,
                    LaneName = laneLocalization.Name,
                    LaneIdCity = lane.IdCity,
                    PublicDescription = lane.PublicCode.Description,
                    GenericDescription = lane.LaneGenericCode.Description,
                    lane.LaneGenericCode.AddWhiteSpaceAfter,
                };

            var results = query.ToList()
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
	            InspectionStatus = InspectionStatus.Approved,
                HasAnomaly = Context.BuildingAnomalies.Any(a => a.IsActive && a.IdBuilding == r.Building.Id),
                IdUtilisationCode = r.Building.IdUtilisationCode,
                IdPicture = r.Building.IdPicture,
                BuildingValue = r.Building.BuildingValue,
                Matricule = r.Building.Matricule,
                NumberOfAppartment = r.Building.NumberOfAppartment,
                NumberOfBuilding = r.Building.NumberOfBuilding,
                NumberOfFloor = r.Building.NumberOfFloor,
                VacantLand = r.Building.VacantLand,
                YearOfConstruction = r.Building.YearOfConstruction,
                Details = r.Building.Details
            });

            return InsertMissingInformation(results.ToList());
        }

        public List<InspectionForDashboard> GetBuildingWithoutInspection(string languageCode)
        {
            var query =
                from building in Context.Buildings
                where building.IsActive 
                      && building.IsParent 
                      && !Context.Inspections.Any(i => i.IsActive && i.Status != InspectionStatus.Approved && i.Status != InspectionStatus.Canceled && i.IdBuilding == building.Id)
                let lane = building.Lane
                from laneLocalization in lane.Localizations
                where laneLocalization.IsActive && laneLocalization.LanguageCode == languageCode
                select new
                {
                    Building = building,
                    LaneName = laneLocalization.Name,
                    lane.IdCity,
                    PublicDescription = lane.PublicCode.Description,
                    GenericDescription = lane.LaneGenericCode.Description,
                    lane.LaneGenericCode.AddWhiteSpaceAfter,
                };

            var results = query.ToList()
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
	                InspectionStatus = InspectionStatus.Todo,
                    HasAnomaly = Context.BuildingAnomalies.Any(a => a.IsActive && a.IdBuilding == r.Building.Id),
                    IdUtilisationCode = r.Building.IdUtilisationCode,
                    IdPicture = r.Building.IdPicture,
                    BuildingValue = r.Building.BuildingValue,
                    Matricule = r.Building.Matricule,
                    NumberOfAppartment = r.Building.NumberOfAppartment,
                    NumberOfBuilding = r.Building.NumberOfBuilding,
                    NumberOfFloor = r.Building.NumberOfFloor,
                    VacantLand = r.Building.VacantLand,
                    YearOfConstruction = r.Building.YearOfConstruction,
                    Details = r.Building.Details
                });

            return InsertMissingInformation(results.ToList());
        }

        private List<InspectionForDashboard> InsertMissingInformation(List<InspectionForDashboard> data)
        {
            data.ForEach(row =>
            {
                row.LastInspectionOn = GetLastInspection(row.IdBuilding);
                row.Contact = GetBuildingContact(row.IdBuilding);
                row.Owner = GetBuildingOwner(row.IdBuilding);
            });

            return data;
        }

        private string GetBuildingContact(Guid idBuilding)
        {
            var list = new List<string>();
            var contacts = Context.BuildingContacts
                .AsNoTracking()
                .Where(c => c.IdBuilding == idBuilding && c.IsActive);

            contacts.ToList().ForEach(contact => {
                list.Add(contact.FirstName + " " + contact.LastName);
            });

            return String.Join(", ", list);
        }

        private string GetBuildingOwner(Guid idBuilding)
        {
            var owner = Context.BuildingContacts
                .AsNoTracking()
                .SingleOrDefault(c => c.IdBuilding == idBuilding && c.IsActive && c.IsOwner);

            if (owner is null)
            {
                return "";
            }

            return owner.FirstName + " " + owner.LastName;
        }

        private DateTime GetLastInspection(Guid idBuilding)
        {
            var lastInspection = Context.Inspections
                .AsNoTracking()
                .Where(i => i.IdBuilding == idBuilding && i.IsActive && i.Status == InspectionStatus.Approved)
                .OrderByDescending(i => i.CompletedOn)
                .FirstOrDefault();

	        return lastInspection?.CompletedOn ?? new DateTime(2000, 1, 1);
        }

		public bool StartInspection(Guid idInspection, Guid idUser)
		{
			if (idInspection != Guid.Empty)
			{
				var targetInspection = Context.Inspections.Where(i => i.Id == idInspection && i.IsActive)
										.Include(i => i.Visits)
										.Single();
				if (!targetInspection.Visits.Any(iv => iv.IsActive && iv.Status != InspectionVisitStatus.Completed))
				{		
					targetInspection.Visits.Add(new InspectionVisit(){Status = InspectionVisitStatus.Started, CreatedOn = DateTime.Now, IdWebuserVisitedBy = idUser});
				}

				targetInspection.Status = InspectionStatus.Started;
				targetInspection.StartedOn = DateTime.Now;
				
				Context.SaveChanges();

				return true;
			}

			return false;
		}

		public bool CompleteInspection(Guid idInspection, Guid idUser)
		{
			if (idInspection != Guid.Empty)
			{
				var targetInspection = Context.Inspections.Where(i => i.Id == idInspection && i.IsActive)
					.Include(i => i.Visits)
					.Single();

				targetInspection.Status = InspectionStatus.WaitingForApprobation;
				targetInspection.CompletedOn = DateTime.Now;

				completeInspectionVisit(targetInspection);

				Context.SaveChanges();

				return true;
			}

			return false;
		}

		private void completeInspectionVisit(Inspection inspection)
		{
			InspectionVisit currentVisit = inspection.Visits.Single(v=> v.IsActive && v.Status != InspectionVisitStatus.Completed);
			currentVisit.EndedOn = DateTime.Now;
			currentVisit.Status = InspectionVisitStatus.Completed;
		}

		public bool RefuseInspectionVisit(InspectionVisit inspectionVisit, Guid idUser)
		{
			var targetInspection = Context.Inspections.Where(i => i.Id == inspectionVisit.IdInspection && i.IsActive)
									.Include(i => i.Visits)
									.Single();

			RefuseCurrentInspectionVisit(targetInspection, inspectionVisit, idUser);
			if (inspectionVisit.RequestedDateOfVisit != null)
			{
				targetInspection.Visits.Add(new InspectionVisit(){Status = InspectionVisitStatus.Todo, CreatedOn = DateTime.Now, IdWebuserVisitedBy = idUser});
			}

			Context.SaveChanges();
			return true;
		}

		private void RefuseCurrentInspectionVisit(Inspection inspection, InspectionVisit refusedInspectionVisit, Guid idUser)
		{
			if (!inspection.Visits.Any())
			{
				refusedInspectionVisit.IdWebuserVisitedBy = idUser;
				inspection.Visits.Add(refusedInspectionVisit);
			}
			else
			{
				InspectionVisit currentVisit = inspection.Visits.Last(v=> v.IsActive && v.Status != InspectionVisitStatus.Completed);			
				currentVisit.Status = refusedInspectionVisit.Status;
				currentVisit.ReasonForInspectionRefusal = refusedInspectionVisit.ReasonForInspectionRefusal;
				currentVisit.HasBeenRefused = refusedInspectionVisit.HasBeenRefused;
				currentVisit.OwnerWasAbsent = refusedInspectionVisit.OwnerWasAbsent;
				currentVisit.DoorHangerHasBeenLeft = refusedInspectionVisit.DoorHangerHasBeenLeft;
				currentVisit.EndedOn = refusedInspectionVisit.EndedOn;
			}
		}
	}
}