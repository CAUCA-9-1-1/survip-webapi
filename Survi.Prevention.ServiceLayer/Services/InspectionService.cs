using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.DataTransfertObjects.Inspections;
using Survi.Prevention.Models.DataTransfertObjects.Reporting;
using Survi.Prevention.Models.InspectionManagement;
using Survi.Prevention.ServiceLayer.DataCopy;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InspectionService : BaseService
	{
		public InspectionService(IManagementContext context) : base(context)
		{
		}

		public bool Remove(Guid id)
		{
			var entity = Context.Inspections.Find(id);
			entity.IsActive = false;

			using (var copyManager = new InspectionBuildingDataCopyManager(Context, id))
				copyManager.DeleteCopy();

			Context.SaveChanges();

			return true;
		}

		public bool SetStatus(InspectionStatus status, Guid id, string refusalReason = null)
		{
			var inspection = Context.Inspections
				.Where(i => i.Id == id)
				.Include(i => i.Visits)
				.Single();

			inspection.Status = status;
			
			AssignRefusalReasonToLastVisit(refusalReason, inspection);

			using (var manager = new InspectionBuildingDataCopyManager(Context, inspection.Id))
			{
				if (status == InspectionStatus.Approved)
					manager.ReplaceOriginalWithCopy();
				else if (status == InspectionStatus.Canceled)
					manager.DeleteCopy();
			}

			Context.SaveChanges();
			return true;
		}

		private void AssignRefusalReasonToLastVisit(string refusalReason, Inspection inspection)
		{
			if (!string.IsNullOrWhiteSpace(refusalReason))
			{
				var currentVisit = inspection.Visits.OrderBy(v => v.EndedOn)
					.Last(v => v.IsActive && v.Status == InspectionVisitStatus.Completed);
				currentVisit.ReasonForApprobationRefusal = refusalReason;
			}
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
				let building = inspection.MainBuilding
                from alias in building.Localizations.Where(loc => loc.LanguageCode == languageCode && loc.IsActive)
				from laneLocalization in building.Lane.Localizations
				where laneLocalization.IsActive && laneLocalization.LanguageCode == languageCode
                let transversal = building.Transversal
                select new
                {
                    inspection.Id,
                    inspection.Status,
                    idBatch = batch.Id,
                    batchDescription = batch.Description,
                    inspection.IdBuilding,
                    building.IdRiskLevel,
                    building.Matricule,
                    building.IdCity,
                    codeUtilisation = building.IdUtilisationCode == null ? "" : 
                        Context.UtilisationCodeLocalizations
                            .Where(code => code.IdParent == building.IdUtilisationCode && code.LanguageCode == languageCode)
                            .Select(code => code.Name)
                            .FirstOrDefault(),
                            
                    building.CivicLetter,
                    building.CivicNumber,                    
                    aliasName = alias.Name,
                    ownerName = Context.BuildingContacts
                        .Where(c => c.IsActive && c.IdBuilding == building.Id && c.IsOwner)
                        .Select(c => c.FirstName + " " + c.LastName)
                        .FirstOrDefault(), 

                    laneName = laneLocalization.Name,
                    publicDescription = building.Lane.PublicCode.Description,
                    genericDescription = building.Lane.LaneGenericCode.Description,
                    building.Lane.LaneGenericCode.AddWhiteSpaceAfter,

                    transName = transversal != null ? transversal.Localizations.Where(loc => loc.IsActive && loc.LanguageCode == languageCode).Select(loc => loc.Name).FirstOrDefault() : "",
                    transPublicDescription = transversal != null ? transversal.PublicCode.Description : "",
                    transGenericDescription = transversal != null ? transversal.LaneGenericCode.Description : "",
                    transAddWhiteSpace = transversal != null && transversal.LaneGenericCode.AddWhiteSpaceAfter,
                    approbationRefusalReason = (
                        Context.InspectionVisits
                            .Where(visit => visit.IdInspection == inspection.Id)
                            .OrderBy(visit => visit.EndedOn)
                            .Where(iv => iv.IsActive && iv.Status == InspectionVisitStatus.Completed)
                            .Select(visit => visit.ReasonForApprobationRefusal)
                            .DefaultIfEmpty("")
                            .LastOrDefault())
                };

			var results = query.AsNoTracking().ToList()
				.Select(result => new InspectionForList
				{
					Id = result.Id,
					IdBatch = result.idBatch,
					BatchDescription = result.batchDescription,
					IdBuilding = result.IdBuilding,
                    IdCity = result.IdCity,
					IdRiskLevel = result.IdRiskLevel,
					Matricule = result.Matricule,
                    Status = result.Status,
                    AliasName = result.aliasName,
                    CivicLetter = result.CivicLetter,
                    CivicNumber = result.CivicNumber,
                    OwnerName = result.ownerName ?? "",
                    UtilisationCodeDescription = result.codeUtilisation ?? "",
                    LaneName = new LocalizedLaneNameGenerator()
                        .GenerateLaneName(result.laneName, result.genericDescription, result.publicDescription, result.AddWhiteSpaceAfter),
				    TransversalLaneName = new LocalizedLaneNameGenerator()
				        .GenerateLaneName(result.transName, result.transGenericDescription, result.transPublicDescription, result.transAddWhiteSpace),
				    ApprobationRefusalReason = result.approbationRefusalReason
                });

			return results
				.GroupBy(data => new { data.IdBatch, data.BatchDescription })
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
				using (var manager = new InspectionBuildingDataCopyManager(Context, idInspection))
					manager.CreateCopy();

				var targetInspection = Context.Inspections.Where(i => i.Id == idInspection && i.IsActive)
					.Include(i => i.Visits)
					.Single();

				AddNewInspectionWhenMissing(idUser, targetInspection);
				targetInspection.Status = InspectionStatus.Started;
				targetInspection.StartedOn = DateTime.Now;

				Context.SaveChanges();
				return true;
			}
			return false;
		}

		private static void AddNewInspectionWhenMissing(Guid idUser, Inspection targetInspection)
		{
			if (!targetInspection.Visits.Any(iv => iv.IsActive && iv.Status != InspectionVisitStatus.Completed))
			{
				targetInspection.Visits.Add(new InspectionVisit
				{
					Status = InspectionVisitStatus.Started,
					CreatedOn = DateTime.Now,
					IdWebuserVisitedBy = idUser,
					IdWebUserLastModifiedBy = idUser
				});
			}
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
					RequestedDateOfVisit = inspectionVisit.RequestedDateOfVisit,
					IdWebUserLastModifiedBy = idUser
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

	    public InspectionWithBuildings GetInspectionWithBuildings(Guid inspectionId, string languageCode)
	    {
	        var currentInspection = (
	            from inspection in Context.Inspections.AsNoTracking()
	            where inspection.Id == inspectionId
	            select new
	            {
                    inspection.IdBuilding,
                    inspection.IdSurvey,
                    inspection.IsSurveyCompleted,
                    inspection.Status                   
	            }).First();

	        var query =	            
	            from building in Context.InspectionBuildings.AsNoTracking()
	            where building.IsActive && building.IdInspection == inspectionId
	            from loc in building.Localizations
	            where loc.IsActive && loc.LanguageCode == languageCode
	            select new InspectionBuildingResume
	            {
	                IdBuilding = building.Id,
	                Name = loc.Name,
	                IsMainBuilding = building.Id == currentInspection.IdBuilding,
                    Coordinates = building.Coordinates,
                    IdLaneTransversal = building.IdLaneTransversal
	            };

	        var buildings = query.ToList();

            return new InspectionWithBuildings
	        {
	            Id = inspectionId,
	            Buildings = buildings,
                Configuration = GetInspectionConfiguration(inspectionId),
                IdSurvey = currentInspection.IdSurvey,
                IsSurveyCompleted = currentInspection.IsSurveyCompleted,
                Status = currentInspection.Status
	        };
	    }

        public InspectionConfiguration GetInspectionConfiguration(Guid inspectionId)
		{
			var currentInspection = (
				from inspection in Context.Inspections.AsNoTracking()
				where inspection.Id == inspectionId
				select new
				{
					inspection.IdSurvey,
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
				from config in Context.FireSafetyDepartmentInspectionConfigurations.AsNoTracking()
				where config.IsActive && config.IdFireSafetyDepartment == departmentId
									  && config.RiskLevels.Any(risk => risk.IdRiskLevel == currentInspection.IdRiskLevel && risk.IsActive)
				select new InspectionConfiguration
				{
					HasBuildingAnomalies = config.HasBuildingAnomalies,
					HasBuildingContacts = config.HasBuildingContacts,
					HasBuildingDetails = config.HasBuildingDetails,
					HasBuildingFireProtection = config.HasBuildingFireProtection,
					HasBuildingHazardousMaterials = config.HasBuildingHazardousMaterials,
					HasBuildingParticularRisks = config.HasBuildingParticularRisks,
					HasBuildingPnaps = config.HasBuildingPnaps,
					HasCourse = config.HasCourse,
					HasGeneralInformation = config.HasGeneralInformation,
					HasImplantationPlan = config.HasImplantationPlan,
					HasWaterSupply = config.HasWaterSupply,
					HasSurvey = currentInspection.IdSurvey != null && currentInspection.IdSurvey != Guid.Empty
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

		public InspectionForReport GetBuildingLastCompletedInspection(Guid idBuilding)
		{
			var lastInspectionId = Context.Inspections.AsNoTracking()
				.Where(inspection => inspection.IdBuilding == idBuilding && inspection.Status == InspectionStatus.Approved)
				.OrderByDescending(inspection => inspection.CompletedOn)
				.Select(inspection => inspection.Id)
				.FirstOrDefault();

			if (lastInspectionId == Guid.Empty)
				return null;

			var lastVisit =
				(from visit in Context.InspectionVisits.AsNoTracking()
				 where visit.IdInspection == lastInspectionId
				 orderby visit.EndedOn descending
				 select visit)
				.Include(visit => visit.VisitedBy)
				.ThenInclude(user => user.Attributes)
				.FirstOrDefault();

			if (lastVisit == null)
				return null;

			var firstName = lastVisit.VisitedBy.Attributes.FirstOrDefault(a => a.AttributeName == "first_name");
			var lastName = lastVisit.VisitedBy.Attributes.FirstOrDefault(a => a.AttributeName == "last_name");

			return new InspectionForReport
			{
				Id = lastInspectionId,
				StartedOn = lastVisit.StartedOn,
				EndedOn = lastVisit.EndedOn,
				InspectorName = (firstName?.AttributeValue ?? "") + " " + (lastName?.AttributeValue ?? "")
			};
		}
	}
}