using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.ServiceLayer.DataCopy
{
	public abstract class BaseInspectionBuildingDataCopyHandler: IDisposable
	{
		protected IManagementContext Context;

		protected BaseInspectionBuildingDataCopyHandler(IManagementContext context)
		{
			Context = context;
		}

		public void Dispose()
		{
			Context = null;
		}

		protected List<InspectionBuilding> GetInspectionBuildings(Guid mainBuildingId)
		{
			var buildings = Context.InspectionBuildings.IgnoreQueryFilters()
				.Where(building => building.IsActive && (building.Id == mainBuildingId || building.IdParentBuilding == mainBuildingId))
				.Include(building => building.AlarmPanels)
				.Include(building => building.Contacts)
				.Include(building => building.Detail)
				.ThenInclude(detail => detail.PlanPicture)
				.Include(building => building.FireHydrants)
				.Include(building => building.HazardousMaterials)
				.Include(building => building.PersonsRequiringAssistance)
				.Include(building => building.Sprinklers)
				.Include(building => building.Courses)
				.ThenInclude(course => course.Lanes)
				.Include(building => building.Anomalies)
				.ThenInclude(anomaly => anomaly.Pictures)
				.ThenInclude(pic => pic.Picture)
				.Include(building => building.ParticularRisks)
				.ThenInclude(risk => risk.Pictures)
				.ThenInclude(riskPic => riskPic.Picture)
				.ToList();
			return buildings;
		}

		protected Guid GetInspectionMainBuilding(Guid inspectionId)
		{
			return Context.Inspections.AsNoTracking()
				.Where(inspection => inspection.Id == inspectionId)
				.Select(inspection => inspection.IdBuilding)
				.FirstOrDefault();
		}
	}
}