using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InspectionService : BaseService
	{
		public InspectionService(ManagementContext context) : base(context)
		{
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

			var fake1 = new InspectionForList { Id = Guid.NewGuid(), IdBatch = Guid.Parse("ad58af45-89e5-4cc4-8c71-294e9b9a9c63"), BatchDescription = "Batch A", IdBuilding = Guid.NewGuid(), IdInterventionForm = Guid.NewGuid(), IdRiskLevel = Guid.Parse("74b65770-4a12-494b-ab73-042c1fd381a3"), Matricule = "12340981", Address = "525, Rue des Finfins"};
			var fake2 = new InspectionForList { Id = Guid.NewGuid(), IdBatch = Guid.Parse("ad58af45-89e5-4cc4-8c71-294e9b9a9c63"), BatchDescription = "Batch A", IdBuilding = Guid.NewGuid(), IdInterventionForm = Guid.NewGuid(), IdRiskLevel = Guid.Parse("74b65770-4a12-494b-ab73-042c1fd381a3"), Matricule = "12340981", Address = "535, Rue des Finfins"};
			var fake3 = new InspectionForList { Id = Guid.NewGuid(), IdBatch = Guid.NewGuid(), BatchDescription = "Batch B", IdBuilding = Guid.NewGuid(), IdInterventionForm = Guid.NewGuid(), IdRiskLevel = Guid.Parse("b1d41784-5e49-4ffb-ab5e-e0665ad0b330"), Matricule = "12340981", Address = "164, Rue des Pinpons" };
			return results.Union(new List<InspectionForList> {fake1, fake2, fake3})
				.GroupBy(data => new {data.IdBatch, data.BatchDescription})
				.Select(group => new BatchForList { Id = group.Key.IdBatch, Description = group.Key.BatchDescription, Inspections = group.ToList() })
				.ToList();
		}

        public List<Building> GetBuildingWithoutInspection(string languageCode)
        {
            var results = Context.Buildings
                .Include(b => b.Localizations)
                .Include(b => b.Lane)
                .Where(b => b.IsActive == true && b.IsParent == true)
                .Where(b => !Context.Inspections.Where(i => i.IsActive == true && i.IsCompleted == false).Select(i => i.IdBuilding).Contains(b.Id))
                .ToList();

            return results;
        }
	}
}