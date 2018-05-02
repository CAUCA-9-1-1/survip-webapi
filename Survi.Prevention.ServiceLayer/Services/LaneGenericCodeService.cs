using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class LaneGenericCodeService : BaseService
	{
		public LaneGenericCodeService(ManagementContext context) : base(context)
		{
		}

		public List<LaneGenericCode> GetList()
		{
			var result = Context.LaneGenericCodes.ToList();

			return result;
		}
	}
}