using System.Collections.Generic;
using Survi.Prevention.Models;

namespace Survi.Prevention.ServiceLayer.DataCopy
{
	public class ReportTemplateDuplicator
	{
		public ReportConfigurationTemplate DuplicateReportTemplate(ReportConfigurationTemplate template)
		{
			return new ReportConfigurationTemplate
			{
				Name = template.Name + " (Copie)",
				Data = template.Data,
				CreatedOn = template.CreatedOn,
				IsActive = template.IsActive,
				IdFireSafetyDepartment = template.IdFireSafetyDepartment,
				IsDefault = false
			};
		}
	}
}