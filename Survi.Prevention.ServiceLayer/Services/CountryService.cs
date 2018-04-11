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

        public List<Country> GetList()
        {
            var result = Context.Countries
                        .Include(c => c.Localizations)
                        .ToList();
            return result;
        }

        public void AddOrUpdate(Country newCountry)
        {
            var isExistRecord = Context.Countries.Any(c => c.Id == newCountry.Id);

            if (isExistRecord)
            {

            }
            else
            {
                Context.Countries.Add(newCountry);
            }
            
            Context.SaveChanges();
        }
    }
}
