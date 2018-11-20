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
		public PermissionService(IManagementContext context) : base(context)
		{
		}

		public List<Permission> GetFeatureListOfPermissionObject(Guid id)
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
				var permission = new Permission
				{
					Access = null,
					IdPermissionSystemFeature = feature.Id,
					IdPermissionObject = id,
					IdPermissionSystem = feature.IdPermissionSystem,
					Feature = feature
				};

				activePermission.Add(permission);
			});

			return activePermission;
		}

		public List<Permission> GetListOfUserPermission(Guid id)
		{
			var idPermisionObject = Context.PermissionObjects.First(p => p.GenericId == id.ToString()).Id;
			var permissions = GetFeatureListOfPermissionObject(idPermisionObject);
			
			permissions.ForEach(permission =>
			{
				if (permission.Access is null)
				{
					var permissionObjectParent = Context.PermissionObjects
						.First(p => p.Id == permission.IdPermissionObject).IdPermissionObjectParent;
					var permissionParent = Context.Permissions.FirstOrDefault(p => 
						p.IdPermissionObject == permissionObjectParent &&
					    p.IdPermissionSystemFeature == permission.IdPermissionSystemFeature &&
						p.IdPermissionSystem == permission.IdPermissionSystem
					);

					if (permissionParent != null)
					{
						permission.Access = permissionParent.Access;

						if (permissionParent.Access is null)
						{
							permission.Access = permissionParent.Feature.DefaultValue;
						}
					}
					else
					{
						permission.Access = permission.Feature.DefaultValue;
					}
				}
			});

			return permissions;
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