using Survip.DataLayer;

namespace Survip.ServiceLayer.Services
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
