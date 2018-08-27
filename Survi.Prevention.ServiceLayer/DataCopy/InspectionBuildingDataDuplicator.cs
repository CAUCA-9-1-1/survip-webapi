using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.ServiceLayer.DataCopy
{
	public class InspectionBuildingDataCopyManager : IDisposable
	{
		private ManagementContext context;
		private readonly Guid inspectionId;
		private readonly Guid mainBuildingId;

		public InspectionBuildingDataCopyManager(ManagementContext context, Guid inspectionId)
		{
			this.context = context;
			this.inspectionId = inspectionId;
			mainBuildingId = GetInspectionMainBuilding(context, inspectionId);
		}

		private static Guid GetInspectionMainBuilding(ManagementContext context, Guid inspectionId)
		{
			return context.Inspections.AsNoTracking()
				.Where(inspection => inspection.Id == inspectionId)
				.Select(inspection => inspection.IdBuilding)
				.FirstOrDefault();
		}

		public void Dispose()
		{
			context = null;
		}

		public void CreateCopy()
		{
			if (!DataHaveAlreadyBeenDuplicated())
				CopyInspectionBuildings();
		}

		public void ReplaceOriginalWithCopy()
		{
			if (DataHaveAlreadyBeenDuplicated())
				ReplaceBuildingWithCopy();
		}

		private void ReplaceBuildingWithCopy()
		{
			var buildings = GetInspectionBuildings();
			new OriginalBuildingReplacer(context)
				.ReplaceOriginalDataWithCopy(buildings);
			context.SaveChanges();
			context.RemoveRange(buildings);
			context.SaveChanges();
		}

		private bool DataHaveAlreadyBeenDuplicated()
		{
			return context.InspectionBuildings.AsNoTracking()
				.Any(building => building.IdInspection == inspectionId);
		}

		private void CopyInspectionBuildings()
		{
			new BuildingDuplicator(context, inspectionId).DuplicateBuildings(GetBuildings());
			context.SaveChanges();
		}

		private List<Building> GetBuildings()
		{
			var buildings = context.Buildings
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

		private List<InspectionBuilding> GetInspectionBuildings()
		{
			var buildings = context.InspectionBuildings.IgnoreQueryFilters()
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
				.Include(building => building.Anomalies)
				.ThenInclude(anomaly => anomaly.Pictures)
				.ThenInclude(pic => pic.Picture)
				.Include(building => building.ParticularRisks)
				.ThenInclude(risk => risk.Pictures)
				.ThenInclude(riskPic => riskPic.Picture)
				.ToList();
			return buildings;
		}
	}
}