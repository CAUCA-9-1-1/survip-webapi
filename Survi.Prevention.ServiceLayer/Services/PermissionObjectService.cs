using System.Linq;
using System.Collections.Generic;
using System.Data.Common;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class PermissionObjectService : BaseService
	{
		public PermissionObjectService(ManagementContext context) : base(context)
		{
		}

		public List<PermissionObject> GetList()
		{
			var permissionObjects = Context.PermissionObjects
				.ToList();

			return permissionObjects;
		}
    }
}