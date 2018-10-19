using Survi.Prevention.DataLayer;
using System;

namespace Survi.Prevention.ServiceLayer.Services
{
	public abstract class BaseService
	{
		protected readonly ManagementContext Context;
		protected BaseService(ManagementContext context)
		{
			Context = context;
		}
	}
}