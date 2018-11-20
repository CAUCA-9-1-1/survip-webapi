using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.ServiceLayer.DataCopy
{
	public class InspectionBuildingDataCopyManager : InspectionBuildingDataCopyDeleter
	{
		private readonly Guid inspectionId;
		private readonly Guid mainBuildingId;

		public InspectionBuildingDataCopyManager(IManagementContext context, Guid inspectionId) : base(context)
		{
			this.inspectionId = inspectionId;
			mainBuildingId = GetInspectionMainBuilding(context, inspectionId);
		}

		private static Guid GetInspectionMainBuilding(IManagementContext context, Guid inspectionId)
		{
			return context.Inspections.AsNoTracking()
				.Where(inspection => inspection.Id == inspectionId)
				.Select(inspection => inspection.IdBuilding)
				.FirstOrDefault();
		}

		public void CreateCopy()
		{
			if (!DataHasAlreadyBeenDuplicated())
				CopyInspectionBuildings();
		}

		public void ReplaceOriginalWithCopy()
		{
			if (DataHasAlreadyBeenDuplicated())
				ReplaceBuildingWithCopy();
		}

		public void DeleteCopy()
		{
			DeleteCopy(inspectionId);
		}

		private List<InspectionBuilding> GetInspectionBuildings()
		{
			return GetInspectionBuildings(mainBuildingId);
		}

		private void ReplaceBuildingWithCopy()
		{
			var buildings = GetInspectionBuildings();
			new OriginalBuildingReplacer(Context)
				.ReplaceOriginalDataWithCopy(buildings);
			DeleteCopy(buildings);
			Context.SaveChanges();
		}		

		private bool DataHasAlreadyBeenDuplicated()
		{
			return Context.InspectionBuildings.AsNoTracking()
				.Any(building => building.IdInspection == inspectionId);
		}

		private void CopyInspectionBuildings()
		{
			new BuildingDuplicator(Context, inspectionId).DuplicateBuildings(GetBuildings());
			Context.SaveChanges();
		}

		private List<Building> GetBuildings()
		{
			var buildings = Context.Buildings
				.Where(building => building.IsActive && (building.Id == mainBuildingId || building.IdParentBuilding == mainBuildingId))
				.Include(building => building.AlarmPanels)
				.Include(building => building.Contacts)
				.Include(building => building.Detail)
				.ThenInclude(detail => detail.PlanPicture)
				.Include(building => building.FireHydrants)
				.Include(building => building.HazardousMaterials)
				.Include(building => building.Localizations)
				.Include(building => building.PersonsRequiringAssistance)
				.Include(building => building.Sprinklers)
				.ToList();
			return buildings;
		}
	}
}