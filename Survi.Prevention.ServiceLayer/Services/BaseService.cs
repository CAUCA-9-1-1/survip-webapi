using Survi.Prevention.DataLayer;
using System;

namespace Survi.Prevention.ServiceLayer.Services
{
	public abstract class BaseService
	{
		protected readonly ManagementContext Context;
		public Guid idUserModified { get; set;}
		protected BaseService(ManagementContext context)
		{
			Context = context;
		}
	}
}