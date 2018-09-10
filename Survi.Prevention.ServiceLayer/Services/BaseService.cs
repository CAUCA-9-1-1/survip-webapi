using NetTopologySuite.Index.Bintree;
using Survi.Prevention.DataLayer;

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