using System;
using System.Linq;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class PermissionSystemFeatureService : BaseService
	{
		public PermissionSystemFeatureService(IManagementContext context) : base(context)
		{
		}

		public Guid AddOrUpdate(PermissionSystemFeature permissionFeature)
		{
			var isExistRecord = Context.PermissionSystemFeatures.Any(p => p.Id == permissionFeature.Id);

			if (isExistRecord)
				Context.PermissionSystemFeatures.Update(permissionFeature);
			else
				Context.PermissionSystemFeatures.Add(permissionFeature);

			Context.SaveChanges();

			return permissionFeature.Id;
		}
    }
}