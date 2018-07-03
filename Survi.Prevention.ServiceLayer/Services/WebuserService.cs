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

        public Guid AddOrUpdate(Webuser user, string applicationName)
        {
            updateUserDepartment(user);
            updateUserAttribute(user);

            if (user.Password == "")
            {
                user.Password = Context.Webusers.AsNoTracking().First(u => u.Id == user.Id).Password;
            } else
            {
                user.Password = new PasswordGenerator().EncodePassword(user.Password, applicationName);
            }

            return base.AddOrUpdate(user);
        }

        private void updateUserAttribute(Webuser user)
        {
            var webuserAttributes = new List<WebuserAttributes>();
            var dbWebuserAttributes = new List<WebuserAttributes>();

            if (user.Attributes != null)
                webuserAttributes = user.Attributes.Where(a => a.IdWebuser == user.Id).ToList();
            if (Context.WebuserAttributes.AsNoTracking().Any(a => a.IdWebuser == user.Id))
                dbWebuserAttributes = Context.WebuserAttributes.AsNoTracking().Where(a => a.IdWebuser == user.Id).ToList();

            dbWebuserAttributes.ForEach(child =>
            {
                if (!webuserAttributes.Any(a => a.Id == child.Id))
                {
                    Context.WebuserAttributes.Remove(child);
                }
            });
            webuserAttributes.ForEach(child =>
            {
                var isExistRecord = Context.WebuserAttributes.Any(a => a.Id == child.Id);

                if (!isExistRecord)
                {
                    Context.WebuserAttributes.Add(child);
                }
            });

            Context.SaveChanges();
        }

        private void updateUserDepartment(Webuser user)
        {
            var fireSafetyDepartments = new List<WebuserFireSafetyDepartment>();
            var dbFireSafetyDepartments = new List<WebuserFireSafetyDepartment>();

            if (user.FireSafetyDepartments != null)
                fireSafetyDepartments = user.FireSafetyDepartments.Where(d => d.IdWebuser == user.Id).ToList();
            if (Context.WebuserFireSafetyDepartments.AsNoTracking().Any(d => d.IdWebuser == user.Id))
                dbFireSafetyDepartments = Context.WebuserFireSafetyDepartments.AsNoTracking().Where(i => i.IdWebuser == user.Id).ToList();

            dbFireSafetyDepartments.ForEach(child =>
            {
                if (!fireSafetyDepartments.Any(i => i.Id == child.Id))
                {
                    Context.WebuserFireSafetyDepartments.Remove(child);
                }
            });
            fireSafetyDepartments.ForEach(child =>
            {
                var isExistRecord = Context.WebuserFireSafetyDepartments.Any(c => c.Id == child.Id);

                if (!isExistRecord)
                {
                    Context.WebuserFireSafetyDepartments.Add(child);
                }
            });

            Context.SaveChanges();
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
