using System;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings.Base;

namespace Survi.Prevention.ServiceLayer.DataCopy
{
    public abstract class BaseBuildingDuplicator
    {
        protected readonly IManagementContext Context;
        protected readonly Guid InspectionId;

        protected BaseBuildingDuplicator(IManagementContext context, Guid inspectionId)
        {
            this.Context = context;
            this.InspectionId = inspectionId;
        }

        protected TCopy DuplicateBuilding<TOriginal, TCopy>(TOriginal building)
            where TOriginal : IBaseBuilding
            where TCopy : IBaseBuilding, new()
        {
            return new TCopy
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
                YearOfConstruction = building.YearOfConstruction,
                AliasName = building.AliasName,
                CorporateName = building.CorporateName
            };
        }	
    }
}