using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.ServiceLayer
{
    public class InspectionBuildingDataCopyManager : IDisposable
    {
	    private readonly ManagementContext context;
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
		    context?.Dispose();
	    }

		public void DuplicateData()
		{
			if (!DataHaveAlreadyBeenDuplicated())
			{

			}
		}

		private bool DataHaveAlreadyBeenDuplicated()
		{
			return context.InspectionBuildings.AsNoTracking()
				.Any(building => building.IdInspection == inspectionId);
		}

		private void CopyBuildings()
		{
			var buildings = context.Buildings.AsNoTracking()
				.Where(building => building.IsActive && (building.Id == mainBuildingId || building.IdParentBuilding == mainBuildingId))
				.Include(building => building.AlarmPanels)
				.ToList();

			foreach(var building in buildings)
			{
				context.Add(GenerateInspectionBuilding(building));
				//CopyBuildingChildren(building.Id);
			}
		}

	    private InspectionBuilding GenerateInspectionBuilding(Building building)
	    {
		    return new InspectionBuilding
		    {
				Id = building.Id,
				AppartmentNumber = building.AppartmentNumber,
				BuildingValue = building.BuildingValue,
				ChildType = building.ChildType,
				CivicLetter = building.CivicLetter,
				CivicLetterSupp = building.CivicLetterSupp,
				CivicNumber = building.CivicNumber,
				CivicSupp = building.CivicSupp,
				Coordinates = building.Coordinates,
				CoordinatesSource = building.CoordinatesSource,
				CreatedOn = building.CreatedOn,
				Details = building.Details,
				Floor = building.Floor,
				IdCity = building.IdCity,
				IdInspection = inspectionId,
				IdLane = building.IdLane,
				IdLaneTransversal = building.IdLaneTransversal,
				IdParentBuilding = building.IdParentBuilding,
				IdPicture = building.IdPicture,
				IdRiskLevel = building.IdRiskLevel,
				IdUtilisationCode = building.IdUtilisationCode,
				IsActive = building.IsActive,
				Matricule = building.Matricule,
				NumberOfAppartment = building.NumberOfAppartment,
				NumberOfBuilding = building.NumberOfBuilding,
				NumberOfFloor = building.NumberOfFloor,
				PostalCode = building.PostalCode,
				ShowInResources = building.ShowInResources,
				Source = building.Source,
				Suite = building.Suite,
				UtilisationDescription = building.UtilisationDescription,
				VacantLand = building.VacantLand,
				YearOfConstruction = building.YearOfConstruction
		    };
	    }
    }
}
