using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects.Reporting;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class BuildingService : BaseCrudServiceWithImportation<Building, ApiClient.DataTransferObjects.Building>
	{
		public BuildingService(
			IManagementContext context, 
			IEntityConverter<ApiClient.DataTransferObjects.Building, Building> converter) 
			: base(context, converter)
		{
		}

		public override Building Get(Guid id)
		{
			var result = Context.Buildings.AsNoTracking()
				.First(b => b.Id == id);

			return result;
		}

		public IQueryable<Building> GetList(List<Guid> idCities)
		{
			var query = Context.Buildings
                .Where(b => b.ChildType == BuildingChildType.None && idCities.Contains(b.IdCity));

			return query;
		}

		public IQueryable<AvailableBuildingForManagement> GetAvailableForInspectionList(string languageCode, List<Guid> idCities)
		{
			var query = Context.AvailableBuildingsForManagement
				.Where(b => idCities.Contains(b.IdCity) && b.LanguageCode == languageCode);

			return query;
		}

		public IQueryable<AvailableBuildingForManagement> GetForInspectionList(string languageCode, List<Guid> buildingIds)
		{
			var query = Context.AvailableBuildingsForManagement
				.Where(b => buildingIds.Contains(b.IdBuilding) && b.LanguageCode == languageCode);

			return query;
		}

		public List<Building> GetChildList(Guid idParentBuilding)
        {
            var result = Context.Buildings
                .Where(b => b.ChildType == BuildingChildType.Child && b.IdParentBuilding == idParentBuilding)
                .ToList();

            return result;
        }

	    public IQueryable<Building> GetChildListOData()
	    {
	        var query = Context.Buildings
	            .Where(b => b.ChildType == BuildingChildType.Child);

	        return query;
	    }

        public List<BuildingForWeb> GetListActive(string languageCode, List<Guid> idCities)
        {
            var query =
                from building in Context.Buildings
                where building.IsActive && idCities.Contains(building.IdCity)
                let laneName = building.Lane.Localizations
                let cityName = building.Lane.City.Localizations
                let riskLevel = building.RiskLevel.Localizations
                select new
                {
                    building.Id,
                    building.CivicNumber,
                    building.AliasName,
                    Lane = laneName.Where(l => l.IsActive && l.LanguageCode == languageCode).Select(l => l.Name).FirstOrDefault(),
                    City = cityName.Where(l => l.IsActive && l.LanguageCode == languageCode).Select(l => l.Name).FirstOrDefault(),
                    RiskLevel = riskLevel.Where(l => l.IsActive && l.LanguageCode == languageCode).Select(l => l.Name).FirstOrDefault(),
                };

            var result = query.ToList()
                .Select(b => new BuildingForWeb
                {
                    Id = b.Id,
                    Name = b.AliasName,
                    CivicNumber = b.CivicNumber,
                    Lane = b.Lane,
                    City = b.City,
                    RiskLevel = b.RiskLevel,
                })
                .ToList();

            return result;
        }

        public override Guid AddOrUpdate(Building building)
        {
            if (building.Picture != null)
            {
                building.IdPicture = UpdatePicture(building);
            }

            return base.AddOrUpdate(building);
        }

        private Guid UpdatePicture(Building building)
        {
            var isExistRecord = Context.Pictures.Any(p => p.Id == building.Picture.Id);

            if (!isExistRecord)
                Context.Add(building.Picture);
			else
				building.Picture.LastModifiedOn = DateTime.Now;

            Context.SaveChanges();

            return building.Picture.Id;
        }

		public List<BuildingForReport> GetBuildingsForReport(Guid mainBuildingId, string languageCode, bool loadMainBuildingOnly)
		{
			IQueryable<BuildingForReport> query;

			if (loadMainBuildingOnly)
			{
				query =
					from building in Context.BuildingsForReport
					where building.LanguageCode == languageCode && building.Id == mainBuildingId
					orderby building.ChildType
					select building;
			}
			else
			{
				query =
					from building in Context.BuildingsForReport
					where (building.Id == mainBuildingId || building.IdParentBuilding == mainBuildingId) && building.LanguageCode == languageCode
					orderby building.ChildType
					select building;
			}

			return query.ToList();
		}

        public List<ApiClient.DataTransferObjects.Building> Export(List<string> idBuildings)
        {
            var query = from building in Context.Buildings.AsNoTracking()
                    .IgnoreQueryFilters()
                where idBuildings.Contains(building.Id.ToString()) && building.HasBeenModified
                select new ApiClient.DataTransferObjects.Building
                {
                    AppartmentNumber = building.AppartmentNumber,
                    BuildingValue = building.BuildingValue,
                    ChildType = (ApiClient.DataTransferObjects.BuildingChildType) building.ChildType,
                    CivicLetter = building.CivicLetter,
                    CivicLetterSupp = building.CivicLetterSupp,
                    CivicNumber = building.CivicNumber,
                    CivicSupp = building.CivicSupp,
                    CoordinatesSource = building.CoordinatesSource,
                    CreatedOn = building.CreatedOn,
                    Details = building.Details,
                    IsActive = building.IsActive,
                    Id = building.IdExtern,
                    IdCity = building.City.IdExtern,
                    IdLaneTransversal = building.Transversal.IdExtern,
                    IdLane = building.Lane.IdExtern,
                    IdParentBuilding = building.Parent.IdExtern,
                    IdRiskLevel = building.RiskLevel.IdExtern,
                    IdUtilisationCode = building.UtilisationCode.IdExtern,
                    Floor = building.Floor,
                    YearOfConstruction = building.YearOfConstruction,
                    LastEditedOn = building.LastModifiedOn,
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
                    WktCoordinates = building.Coordinates,
                    AliasName = building.AliasName,
                    CorporateName = building.CorporateName,                    
                    MimeType = building.Picture.MimeType,
                    PictureData = building.Picture.Data,
                    PictureName = building.Picture.Name,
                    SketchJson = building.Picture.SketchJson
                };
            return query.ToList();
        }

	    public Guid GetIdCity(Guid buildingId)
	    {
	        return Context.Buildings.AsNoTracking()
	            .Where(b => b.Id == buildingId)
	            .Select(b => b.IdCity)
	            .First();
	    }
    }
}