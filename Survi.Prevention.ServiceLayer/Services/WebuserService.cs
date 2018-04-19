using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.SecurityManagement;
using Microsoft.EntityFrameworkCore;

namespace Survi.Prevention.ServiceLayer.Services
{
    public class WebuserService : BaseCrudService<Webuser>
    {
        public WebuserService(ManagementContext context) : base(context)
        {
        }

        public override Webuser Get(Guid id)
        {
            var result = Context.Webusers
                .Include(u => u.Attributes)
                .Include(u => u.FireSafetyDepartments)
                .First(u => u.Id == id);

            return result;
        }

        public override List<Webuser> GetList()
        {
            var result = Context.Webusers
                .Include(u => u.Attributes)
                .Include(u => u.FireSafetyDepartments)
                .ToList();

            return result;
        }
    }
}
