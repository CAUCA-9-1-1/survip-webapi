using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InspectionBuildingService : BaseService
	{
		public InspectionBuildingService(ManagementContext context) : base(context)
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
				from loc in building.Localizations
				where loc.IsActive && loc.LanguageCode == languageCode
				select new
				{
					building.Id,
					loc.Name,
                    building.ChildType,
					building.Picture.Data
				}).ToList();

			return results
				.Select(building => new InspectionBuildingForList
				{
					Id = building.Id,
					IdInspection = inspectionId,
                    IsParent = building.ChildType == 0,
                    Name = building.Name,
					Picture = building.Data == null ? null : Convert.ToBase64String(building.Data)
				})
                .ToList();
		}
	}
}
