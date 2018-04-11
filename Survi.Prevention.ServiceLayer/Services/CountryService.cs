using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.ServiceLayer.Services
{
    public class CountryService : BaseService
    {
        public CountryService(ManagementContext context) : base(context)
        {
        }

        public List<Country> GetList()
        {
            return Context.Countries.ToList();
        }

        public void AddOrUpdate(Country country)
        {
            var isExistRecord = Context.Countries.Any(c => c.Id == country.Id);

            if (isExistRecord)
            {
                
            }
            else
            {
                Context.Countries.Add(country);
            }
            
            Context.SaveChanges();
        }
    }
}
