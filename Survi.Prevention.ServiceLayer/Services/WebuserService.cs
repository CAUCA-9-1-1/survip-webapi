using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.SecurityManagement;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.Models.DataTransfertObjects;

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

        public List<WebuserForWeb> GetListActive()
        {
            var query =
                from users in Context.Webusers
                where users.IsActive
                let firstname = users.Attributes.First(a => a.AttributeName == "first_name")
                let lastname = users.Attributes.First(a => a.AttributeName == "last_name")
                select new {
                    users.Id,
                    firstname = firstname.AttributeValue,
                    lastname =  lastname.AttributeValue
                };

            var result = query.ToList()
                .Select(user => new WebuserForWeb
                {
                    Id = user.Id,
                    Name = user.firstname + " " + user.lastname
                })
                .ToList();

            return result;
        }
    }
}
