using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class PermissionService : BaseService
	{
		public PermissionService(ManagementContext context) : base(context)
		{
		}

		public List<Permission> GetListOfPermissionObject(Guid id)
		{
			var activePermission = Context.Permissions
				.Where(p => p.IdPermissionObject == id)
				.Include(p => p.Feature)
				.ToList();

			var idFeatures = new List<Guid>();
			activePermission.ForEach(permission =>
			{
				idFeatures.Add(permission.Feature.Id);
			});
			
			var unusedPermission = Context.PermissionSystemFeatures
				.Where(p => !idFeatures.Contains(p.Id))
				.ToList();

			unusedPermission.ForEach(feature =>
			{
				var permission = new Permission();
				permission.Access = null;
				permission.IdPermissionSystemFeature = feature.Id;
				permission.IdPermissionObject = id;
				permission.IdPermissionSystem = feature.IdPermissionSystem;
				permission.Feature = feature;

				activePermission.Add(permission);
			});

			return activePermission;
		}
		
		public Guid Save(Permission permission)
		{
			if (permission.Access is null)
			{
				this.Delete(permission);
			}
			else
			{
				this.AddOrUpdate(permission);
			}
			
			return permission.Id;
		}

		private void Delete(Permission permission)
		{
			var isExistRecord = Context.Permissions.Any(c => c.Id == permission.Id);

			if (isExistRecord)
			{
				Context.Permissions.Remove(permission);
				Context.SaveChanges();
			}
		}

		private void AddOrUpdate(Permission permission)
		{
			var isExistRecord = Context.Permissions.Any(c => c.Id == permission.Id);

			if (isExistRecord)
				Context.Permissions.Update(permission);
			else
				Context.Permissions.Add(permission);

			Context.SaveChanges();
		}
    }
}