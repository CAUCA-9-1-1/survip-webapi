using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
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

		public bool SetReasonForApprobationRefusal(Guid id, string reason)
		{
			var inspection = Context.Inspections.Single(i => i.Id == id);
			var currentVisit = inspection.Visits.OrderBy(v => v.EndedOn)
				.Last(v => v.IsActive && v.Status == InspectionVisitStatus.Completed);

			currentVisit.ReasonForApprobationRefusal = reason;
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
				from building in inspection.Buildings
				where building.ChildType == BuildingChildType.None && building.IsActive
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

        public IQueryable<InspectionToDo> GetToDoInspections(string languageCode, List<Guid> cityIds)
        {
			var query =
				from inspection in Context.InspectionsToDo
				where inspection.LanguageCode == languageCode && cityIds.Contains(inspection.IdCity)
				select inspection;
			return query;
        }

        public IQueryable<InspectionForApproval> GetInspectionsForApproval(string languageCode, List<Guid> cityIds)
        {
	        var query =
		        from inspection in Context.InspectionsForApproval
		        where inspection.LanguageCode == languageCode && cityIds.Contains(inspection.IdCity)
				select inspection;
	        return query;		
        }

        public IQueryable<InspectionCompleted> GetInspectionsCompleted(string languageCode, List<Guid> cityIds)
        {
	        var query =
		        from inspection in Context.InspectionsCompleted
		        where inspection.LanguageCode == languageCode && cityIds.Contains(inspection.IdCity)
				select inspection;
	        return query;			
        }

		public IQueryable<BuildingWithoutInspection> GetBuildingWithoutInspectionQueryable(string languageCode, List<Guid> cityIds)
		{
			var query = Context.BuildingsWithoutInspection
				.Where(b => b.LanguageCode == languageCode && cityIds.Contains(b.IdCity));

			return query;
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
					targetInspection.Visits.Add(new InspectionVisit{Status = InspectionVisitStatus.Started, CreatedOn = DateTime.Now, IdWebuserVisitedBy = idUser});
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

				if (CompleteInspectionVisit(targetInspection))
				{
					targetInspection.Status = InspectionStatus.WaitingForApprobation;
					targetInspection.CompletedOn = DateTime.Now;
					Context.SaveChanges();

					return true;
				}				
			}
			return false;
		}

		private bool CompleteInspectionVisit(Inspection inspection)
		{
			if (inspection.Visits.Any(v => v.IsActive && v.Status != InspectionVisitStatus.Completed))
			{
				InspectionVisit currentVisit =
					inspection.Visits.Single(v => v.IsActive && v.Status != InspectionVisitStatus.Completed);
				currentVisit.EndedOn = DateTime.Now;
				currentVisit.Status = InspectionVisitStatus.Completed;

				return true;
			}

			return false;
		}

		public bool RefuseInspectionVisit(InspectionVisit inspectionVisit, Guid idUser)
		{
			var targetInspection = Context.Inspections.Where(i => i.Id == inspectionVisit.IdInspection && i.IsActive)
									.Include(i => i.Visits)
									.Single();

			RefuseCurrentInspectionVisit(targetInspection, inspectionVisit, idUser);
			if (inspectionVisit.RequestedDateOfVisit != null)
			{
				targetInspection.Visits.Add(new InspectionVisit()
				{
					Status = InspectionVisitStatus.Todo,
					CreatedOn = DateTime.Now,
					IdWebuserVisitedBy = idUser,
					RequestedDateOfVisit = inspectionVisit.RequestedDateOfVisit
				});
			}

			targetInspection.Status = InspectionStatus.Todo;

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
				if (inspection.Visits.Any(v => v.IsActive && v.Status != InspectionVisitStatus.Completed))
				{
					var currentVisit =
						inspection.Visits.Last(v => v.IsActive && v.Status != InspectionVisitStatus.Completed);
					currentVisit.Status = refusedInspectionVisit.Status;
					currentVisit.ReasonForInspectionRefusal = refusedInspectionVisit.ReasonForInspectionRefusal;
					currentVisit.HasBeenRefused = refusedInspectionVisit.HasBeenRefused;
					currentVisit.OwnerWasAbsent = refusedInspectionVisit.OwnerWasAbsent;
					currentVisit.DoorHangerHasBeenLeft = refusedInspectionVisit.DoorHangerHasBeenLeft;
					currentVisit.EndedOn = refusedInspectionVisit.EndedOn;
					currentVisit.RequestedDateOfVisit = refusedInspectionVisit.RequestedDateOfVisit;
				}
			}
		}

		public InspectionConfiguration GetInspectionConfiguration(Guid inspectionId)
		{
			var currentInspection = (
				from inspection in Context.Inspections.AsNoTracking()
				where inspection.Id == inspectionId
				select new
				{
					inspection.MainBuilding.IdCity,
					inspection.MainBuilding.IdRiskLevel
				}).FirstOrDefault();

			if (currentInspection == null)
				return null;

			var departmentId = (
				from city in Context.Cities.AsNoTracking()
				where city.Id == currentInspection.IdCity
				from serving in city.ServedByFireSafetyDepartments
				where serving.IsActive
				select serving.IdFireSafetyDepartment
			).First();

			var query =
				from risk in Context.FireSafetyDepartmentRiskLevels.AsNoTracking()
				where risk.IsActive && risk.IdFireSafetyDepartment == departmentId && risk.IdRiskLevel == currentInspection.IdRiskLevel
				select new InspectionConfiguration
				{
					HasBuildingAnomalies = risk.HasBuildingAnomalies,
					HasBuildingContacts = risk.HasBuildingContacts,
					HasBuildingDetails = risk.HasBuildingDetails,
					HasBuildingFireProtection = risk.HasBuildingFireProtection,
					HasBuildingHazardousMaterials = risk.HasBuildingHazardousMaterials,
					HasBuildingParticularRisks = risk.HasBuildingParticularRisks,
					HasBuildingPnaps = risk.HasBuildingPNAPS,
					HasCourse = risk.HasCourse,
					HasGeneralInformation = risk.HasGeneralInformation,
					HasImplantationPlan = risk.HasImplantationPlan,
					HasWaterSupply = risk.HasWaterSupply
				};

			return query.FirstOrDefault() ?? new InspectionConfiguration();
		}

		public bool CanUserAccessInspection(Guid idInspection, Guid idUser)
		{
			var retValue = false;

			var targetInspection = Context.Inspections.Where(i => i.Id == idInspection && i.IsActive)
				.Include(i => i.Visits)
				.Single();
			if (targetInspection != null)
			{
				var visit = targetInspection.Visits.SingleOrDefault(iv =>
					iv.IsActive && iv.Status != InspectionVisitStatus.Completed);
				if (visit == null || visit.IdWebuserVisitedBy == idUser)
					retValue = true;
			}

			return retValue;
		}
	}
}