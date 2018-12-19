using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class PermissionObjectService : BaseService
	{
		public PermissionObjectService(IManagementContext context) : base(context)
		{
		}

		public List<PermissionObject> GetList()
		{
			var permissionObjects = Context.PermissionObjects
				.ToList();

			permissionObjects.ForEach(obj =>
			{
				if (obj.ObjectTable != "webuser")
				{
					return;
				}

				obj.GroupName = Context.WebuserAttributes
					.First(a => a.IdWebuser.ToString() == obj.GenericId && a.AttributeName == "first_name")
					.AttributeValue;
				obj.GroupName += " " + Context.WebuserAttributes
					.First(a => a.IdWebuser.ToString() == obj.GenericId && a.AttributeName == "last_name")
					.AttributeValue; 
			});

			return permissionObjects;
		}
		
		public Guid AddOrUpdate(PermissionObject permissionObject)
		{
			var isExistRecord = Context.PermissionObjects.Any(p => p.Id == permissionObject.Id);

			if (isExistRecord)
				Context.PermissionObjects.Update(permissionObject);
			else
				Context.PermissionObjects.Add(permissionObject);

			Context.SaveChanges();
			
			return permissionObject.Id;
		}
		
		public bool Remove(Guid id)
		{
			var isExistRecord = Context.PermissionObjects.Any(p => p.Id == id);

			if (isExistRecord)
			{
				var children = Context.PermissionObjects.Where(p => p.IdPermissionObjectParent == id).ToList();

				if (children.Any())
				{
				    children.ForEach(child => { Context.PermissionObjects.Remove(child); });
				}

				Context.PermissionObjects.Remove(Context.PermissionObjects.First(p => p.Id == id));
				Context.SaveChanges();
			}

			return true;
		}
    }
}