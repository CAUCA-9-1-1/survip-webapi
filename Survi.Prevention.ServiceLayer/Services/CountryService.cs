using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Microsoft.EntityFrameworkCore;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class CountryService : BaseService
    {
        public CountryService(ManagementContext context) : base(context)
        {
        }

        public Country Get(Guid id)
        {
            var result = Context.Countries
                        .Include(c => c.Localizations)
                        .First(c => c.Id == id);

            return result;
        }

        public List<Country> GetList()
        {
            var result = Context.Countries
                        .Include(c => c.Localizations)
                        .ToList();

            return result;
        }

        public Boolean AddOrUpdate(Country country)
        {
            var isExistRecord = Context.Countries.Any(c => c.Id == country.Id);

            if (isExistRecord)
            {
                Context.Countries.Update(country);
            }
            else
            {
                Context.Countries.Add(country);
            }
            
            Context.SaveChanges();

            return true;
        }

        public Boolean Remove(Guid id)
        {
            var country = Context.Countries.Find(id);

            country.IsActive = false;
            Context.SaveChanges();

            return true;
        }
    }
}
