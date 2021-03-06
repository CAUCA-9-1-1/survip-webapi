using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;
using importedLane = Survi.Prevention.ApiClient.DataTransferObjects.Lane;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class LaneService : BaseCrudServiceWithImportation<Lane, importedLane>
	{
		public LaneService(IManagementContext context, IEntityConverter<importedLane, Lane> converter) 
			: base(context, converter)
		{
		}

		public override Lane Get(Guid id)
		{
			var result = Context.Lanes.AsNoTracking()
				.Include(s => s.Localizations)
				.First(s => s.Id == id);

			return result;
		}

		public IQueryable<Lane> GetList(List<Guid> idCities)
		{
			var query = Context.Lanes
				.Where(l => idCities.Contains(l.IdCity));

			return query;
		}

        public List<LaneLocalized> GetListLocalized(List<Guid> idCities, string languageCode)
        {
		    var query =
			    from lane in Context.Lanes.AsNoTracking()
			    where lane.IsActive && idCities.Contains(lane.IdCity)
			    let genericCode = lane.LaneGenericCode
			    let publicCode = lane.PublicCode
			    from localization in lane.Localizations.DefaultIfEmpty()
			    where localization.IsActive && localization.LanguageCode == languageCode
			    from city in lane.City.Localizations.Where(loc => loc.IsActive && loc.LanguageCode == languageCode).DefaultIfEmpty()
				orderby localization.Name
			    select new {lane.Id, localization.Name, genericDescription = genericCode.Description, genericCode.AddWhiteSpaceAfter, publicDescription = publicCode.Description, CityName = city.Name};

		    var rawResult = query.ToList();

		    var result = rawResult
			    .Select(lane => new LaneLocalized
			    {
				    Id = lane.Id,
				    Name = new LocalizedLaneNameGenerator().GenerateLaneName(lane.Name, lane.genericDescription, lane.publicDescription, lane.AddWhiteSpaceAfter),
					CityName = lane.CityName
			    })
			    .ToList();

		    return result;
        }

        public List<LaneLocalized> GetListByCityLocalized(Guid cityId, string languageCode)
		{
			var query =
				from lane in Context.Lanes.AsNoTracking()
				where lane.IdCity == cityId && lane.IsActive
				let genericCode = lane.LaneGenericCode
				let publicCode = lane.PublicCode
				from localization in lane.Localizations.DefaultIfEmpty()
				where localization.IsActive && localization.LanguageCode == languageCode
				from city in lane.City.Localizations.Where(loc => loc.IsActive && loc.LanguageCode == languageCode).DefaultIfEmpty()
				orderby localization.Name
				select new {lane.Id, localization.Name, genericDescription = genericCode.Description, genericCode.AddWhiteSpaceAfter, publicDescription = publicCode.Description, CityName = city.Name};

			var result = query.ToList()
				.Select(lane => new LaneLocalized
					{
						Id = lane.Id,
						Name = new LocalizedLaneNameGenerator().GenerateLaneName(lane.Name, lane.genericDescription, lane.publicDescription, lane.AddWhiteSpaceAfter),
						CityName = lane.CityName
					})
				.ToList();

			return result;
		}

		public List<LaneLocalized> GetFilteredLanesLocalized(Guid cityId, string languageCode, string searchTerm = "")
		{
			if (searchTerm == null)
				searchTerm = "";

			searchTerm = searchTerm.ToLower();

			var query =
				from lane in Context.Lanes.AsNoTracking()
				where lane.IdCity == cityId && lane.IsActive
				let genericCode = lane.LaneGenericCode
				let publicCode = lane.PublicCode
				from localization in lane.Localizations.DefaultIfEmpty()
				where localization.IsActive && localization.LanguageCode == languageCode
				&& (((localization.Name.ToLower().Contains(searchTerm) 
				    || genericCode.Description.ToLower().Contains(searchTerm)
				    || publicCode.Description.ToLower().Contains(searchTerm))&& searchTerm != "")||(searchTerm == ""))
				orderby localization.Name
				select new {lane.Id, localization.Name, genericDescription = genericCode.Description, genericCode.AddWhiteSpaceAfter, publicDescription = publicCode.Description};

			var result = query.Take(30).ToList()
				.Select(lane => new LaneLocalized {Id = lane.Id, Name = new LocalizedLaneNameGenerator().GenerateLaneName(lane.Name, lane.genericDescription, lane.publicDescription, lane.AddWhiteSpaceAfter)})
				.ToList();

			return result;
		}

		public string GetLaneLocalizedName(Guid laneId, string languageCode)
		{
			var query =
				from lane in Context.Lanes.AsNoTracking()
				where lane.Id == laneId && lane.IsActive
				let genericCode = lane.LaneGenericCode
				let publicCode = lane.PublicCode
				from localization in lane.Localizations.DefaultIfEmpty()
				where localization.IsActive && localization.LanguageCode == languageCode
				select new { localization.Name, genericDescription = genericCode.Description, genericCode.AddWhiteSpaceAfter, publicDescription = publicCode.Description };

			var laneFound = query.SingleOrDefault();
			
			if (laneFound == null)
				return null;
			return new LocalizedLaneNameGenerator()
				.GenerateLaneName(laneFound.Name, laneFound.genericDescription, laneFound.publicDescription, laneFound.AddWhiteSpaceAfter);
		}
	}
}