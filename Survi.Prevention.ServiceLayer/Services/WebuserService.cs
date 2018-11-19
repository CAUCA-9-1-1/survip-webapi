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
				.Where(wu => wu.IsActive)
                .Include(u => u.Attributes)
                .Include(u => u.FireSafetyDepartments)
                .ToList();

            return result;
        }

        public Guid AddOrUpdate(Webuser user, string applicationName, Guid idUserModified)
        {
            UpdateUserDepartment(user);
            UpdateUserAttribute(user);

            user.Password = user.Password == "" ? 
	            Context.Webusers.AsNoTracking().First(u => u.Id == user.Id).Password : 
	            new PasswordGenerator().EncodePassword(user.Password, applicationName);

            return base.AddOrUpdate(user);
        }

        private void UpdateUserAttribute(Webuser user)
        {
            var webuserAttributes = new List<WebuserAttributes>();
            var dbWebuserAttributes = new List<WebuserAttributes>();

            if (user.Attributes != null)
                webuserAttributes = user.Attributes.Where(a => a.IdWebuser == user.Id).ToList();
            if (Context.WebuserAttributes.AsNoTracking().Any(a => a.IdWebuser == user.Id))
                dbWebuserAttributes = Context.WebuserAttributes.AsNoTracking().Where(a => a.IdWebuser == user.Id).ToList();

            dbWebuserAttributes.ForEach(child =>
            {
                if (webuserAttributes.All(a => a.Id != child.Id))
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

        private void UpdateUserDepartment(Webuser user)
        {
            var fireSafetyDepartments = new List<WebuserFireSafetyDepartment>();
            var dbFireSafetyDepartments = new List<WebuserFireSafetyDepartment>();

            if (user.FireSafetyDepartments != null)
                fireSafetyDepartments = user.FireSafetyDepartments.Where(d => d.IdWebuser == user.Id).ToList();
            if (Context.WebuserFireSafetyDepartments.AsNoTracking().Any(d => d.IdWebuser == user.Id))
                dbFireSafetyDepartments = Context.WebuserFireSafetyDepartments.AsNoTracking().Where(i => i.IdWebuser == user.Id).ToList();

            dbFireSafetyDepartments.ForEach(child =>
            {
                if (fireSafetyDepartments.All(i => i.Id != child.Id))
                {
                    Context.WebuserFireSafetyDepartments.Remove(child);
                }
            });
            fireSafetyDepartments.ForEach(child =>
            {
                var isExistRecord = Context.WebuserFireSafetyDepartments.Any(c => c.Id == child.Id);

                if (!isExistRecord)
                    Context.WebuserFireSafetyDepartments.Add(child);
            });

            Context.SaveChanges();
        }

		public List<WebuserForWeb> GetListActive(List<Guid> allowedDepartmentIds)
        {
            var query =
                from user in Context.Webusers
                where user.IsActive && user.FireSafetyDepartments.Any(dep => allowedDepartmentIds.Contains(dep.IdFireSafetyDepartment) && dep.IsActive)
                let firstName = user.Attributes.FirstOrDefault(a => a.AttributeName == "first_name")
                let lastName = user.Attributes.FirstOrDefault(a => a.AttributeName == "last_name")
                select new {
                    user.Id,
                    firstName,
                    lastName
                };

            var result = query.ToList()
                .Select(user => new WebuserForWeb
                {
                    Id = user.Id,
                    Name = (user.firstName?.AttributeValue??"") + " " + (user.lastName?.AttributeValue ?? "")
                })
                .ToList();

            return result;
        }

		public List<Guid> GetUserFireSafetyDepartments(Guid idWebuser)
		{
			var query =
				from department in Context.WebuserFireSafetyDepartments
				where department.IdWebuser == idWebuser && department.IsActive
				select department.IdFireSafetyDepartment;

			return query.ToList();
		}
    }
}
