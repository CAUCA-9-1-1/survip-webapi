using System;
using System.Collections.Generic;
using System.Linq;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class FireSafetyDepartmentRiskLevelService : BaseCrudService<FireSafetyDepartmentRiskLevel>
	{
		public FireSafetyDepartmentRiskLevelService(ManagementContext context) : base(context)
		{
		}

		public override FireSafetyDepartmentRiskLevel Get(Guid id)
		{
			var result = Context.FireSafetyDepartmentRiskLevels
				.First(s => s.Id == id);

			return result;
		}

		public override List<FireSafetyDepartmentRiskLevel> GetList()
		{
			var result = Context.FireSafetyDepartmentRiskLevels
				.ToList();

			return result;
		}
	}
}