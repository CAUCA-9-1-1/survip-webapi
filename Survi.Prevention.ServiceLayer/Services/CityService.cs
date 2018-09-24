using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Converters;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class CityService : BaseCrudService<City>
	{
		public CityService(ManagementContext context) : base(context)
		{
		}
		
		public override City Get(Guid id)
		{
			var result = Context.Cities
                .Include(c => c.Localizations)
				.First(c => c.Id == id);

			return result;
		}

		public override List<City> GetList()
		{
			var result = Context.Cities
                .Include(c => c.Localizations)
				.ToList();

			return result;
		}

		public List<Guid> GetCityIdsByFireSafetyDepartments(List<Guid> fireSafetyDepartmentIds)
		{
			var query =
				from department in Context.FireSafetyDepartments.AsNoTracking()
				where fireSafetyDepartmentIds.Contains(department.Id) && department.IsActive
				from serving in department.FireSafetyDepartmentServing
				where serving.IsActive
				select serving.IdCity;

			return query.Distinct().ToList();
		}

        public List<CityLocalized> GetListLocalized(string languageCode, List<Guid> idCities)
        {
            var query =
                from city in Context.Cities.AsNoTracking()
                where city.IsActive
                from localization in city.Localizations.DefaultIfEmpty()
                where localization.IsActive && localization.LanguageCode == languageCode && idCities.Contains(city.Id)
                orderby localization.Name
                select new CityLocalized {
                    Id = city.Id,
                    Name = localization.Name,
					RegionName = "",
					CountyName = ""
                };

            return query.ToList();
        }

		public CityLocalized GetCityWithRegionLocalized(Guid idCity, string languageCode)
		{
			var query = (
				from city in Context.Cities.AsNoTracking()
				let county = city.County
				let region = city.County.Region
				where city.IsActive && city.Id == idCity
				select new CityLocalized {
					Id = city.Id,
					Name = city.Localizations.FirstOrDefault(ccl => ccl.LanguageCode == languageCode).Name,
					RegionName = city.County.Region.Localizations.FirstOrDefault(ccl => ccl.LanguageCode == languageCode).Name,
					CountyName = city.County.Localizations.FirstOrDefault(ccl => ccl.LanguageCode == languageCode).Name
				});
			return query.FirstOrDefault();
		}
    }
}