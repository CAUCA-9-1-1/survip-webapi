using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models;
using Survi.Prevention.Models.DataTransfertObjects.Reporting;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class BuildingService : BaseCrudService<Building>
	{
		public BuildingService(ManagementContext context) : base(context)
		{
		}

		public override Building Get(Guid id)
		{
			var result = Context.Buildings
                .Include(b => b.Localizations)
				.First(b => b.Id == id);

			return result;
		}

		public IQueryable<Building> GetList(List<Guid> idCities)
		{
			var query = Context.Buildings
                .Where(b => b.ChildType == BuildingChildType.None && idCities.Contains(b.IdCity));

			return query;
		}

        public List<Building> GetChildList(Guid idParentBuilding)
        {
            var result = Context.Buildings
                .Where(b => b.ChildType == BuildingChildType.Child && b.IdParentBuilding == idParentBuilding)
                .Include(b => b.Localizations)
                .ToList();

            return result;
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
                    building.Localizations.FirstOrDefault(l => l.IsActive && l.LanguageCode == languageCode).Name,
                    Lane = laneName.FirstOrDefault(l => l.IsActive && l.LanguageCode == languageCode).Name,
                    City = cityName.FirstOrDefault(l => l.IsActive && l.LanguageCode == languageCode).Name,
                    RiskLevel = riskLevel.FirstOrDefault(l => l.IsActive && l.LanguageCode == languageCode).Name,
                };

            var result = query.ToList()
                .Select(b => new BuildingForWeb
                {
                    Id = b.Id,
                    Name = b.Name,
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
            if (building.Picture is Picture)
            {
                building.IdPicture = UpdatePicture(building);
            }

            return base.AddOrUpdate(building);
        }

        private Guid UpdatePicture(Building building)
        {
            var isExistRecord = Context.Pictures.Any(p => p.Id == building.Picture.Id);

            if (!isExistRecord)
            {
                Context.Add(building.Picture);
            }

            Context.SaveChanges();

            return building.Picture.Id;
        }

		public List<BuildingForReport> GetBuildingsForReport(Guid mainBuildingId, string languageCode)
		{
			var query =
				from building in Context.Buildings.AsNoTracking()
				where building.IsActive && (building.Id == mainBuildingId || building.IdParentBuilding == mainBuildingId)
				orderby building.ChildType
				select new BuildingForReport
				{
					Id = building.Id
				};

			return query.ToList();
		}
	}
}