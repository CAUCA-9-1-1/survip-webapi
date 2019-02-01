using System;
using System.Collections.Generic;
using System.Linq;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.ServiceLayer.DataCopy
{
	public class InspectionBuildingDataCopyDeleter : BaseInspectionBuildingDataCopyHandler
	{
		public InspectionBuildingDataCopyDeleter(IManagementContext context) 
			: base(context)
		{
		}

		public void DeleteCopy(Guid inspectionId)
		{
			var mainBuildingId = GetInspectionMainBuilding(inspectionId);
			var buildings = GetInspectionBuildings(mainBuildingId);

            if (buildings.Any()) 
			DeleteCopy(buildings);			
		}

		public void DeleteCopy(List<InspectionBuilding> buildings)
		{
			foreach (var picture in buildings.SelectMany(p => p.ParticularRisks.SelectMany(r => r.Pictures.Select(rp => rp.Picture))))
				Context.Remove(picture);
			foreach (var picture in buildings.SelectMany(p => p.Anomalies.SelectMany(r => r.Pictures.Select(rp => rp.Picture))))
				Context.Remove(picture);
			foreach (var picture in buildings.Select(p => p.Picture).Where(p => p != null))
				Context.Remove(picture);
			foreach (var picture in buildings.Select(p => p.Detail.PlanPicture).Where(p => p != null))
				Context.Remove(picture);

			Context.InspectionBuildings.RemoveRange(buildings);
		}
	}
}