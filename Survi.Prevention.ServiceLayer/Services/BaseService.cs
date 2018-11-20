using Survi.Prevention.DataLayer;

namespace Survi.Prevention.ServiceLayer.Services
{
	public abstract class BaseService
	{
		protected readonly IManagementContext Context;
		protected BaseService(IManagementContext context)
		{
			Context = context;
		}
	}
}