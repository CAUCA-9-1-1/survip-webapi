using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class LanePublicCodeService : BaseService
	{
		public LanePublicCodeService(ManagementContext context) : base(context)
		{
		}

		public List<LanePublicCode> GetList()
		{
			var result = Context.LanePublicCodes.ToList();

			return result;
		}
	}
}