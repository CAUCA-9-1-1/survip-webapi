using System;
using System.Collections.Generic;
using System.Linq;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class FireSafetyDepartmentInspectionConfigurationService : BaseCrudService<FireSafetyDepartmentInspectionConfiguration>
	{
		public FireSafetyDepartmentInspectionConfigurationService(ManagementContext context) : base(context)
		{
		}

		public override FireSafetyDepartmentInspectionConfiguration Get(Guid id)
		{
			var result = Context.FireSafetyDepartmentInspectionConfigurations
				.First(s => s.Id == id);

			return result;
		}

		public override List<FireSafetyDepartmentInspectionConfiguration> GetList()
		{
			var result = Context.FireSafetyDepartmentInspectionConfigurations
				.ToList();

			return result;
		}
	}
}