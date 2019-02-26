using System;
using System.Collections.Generic;
using Survi.Prevention.Models.DataTransfertObjects.Reporting;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportBuildingPersonRequiringAssistanceGroupHandler : BaseReportGroupHandler<PersonRequiringAssistanceForReport>
	{
		private readonly BuildingPersonRequiringAssistanceService service;
		protected override ReportBuildingGroup Group => ReportBuildingGroup.BuildingPersonRequiringAssistance;

		public ReportBuildingPersonRequiringAssistanceGroupHandler(BuildingPersonRequiringAssistanceService service)
		{
			this.service = service;
		}
		
		protected override List<PersonRequiringAssistanceForReport> GetData(Guid idParent, string languageCode)
		{
			return service.GetPersonsForReport(idParent, languageCode);
		}

		public static (string Group, List<string> Placeholders) GetPlaceholders()
		{
			var placeholders = GetPlaceholderList();
			return (ReportBuildingGroup.BuildingPersonRequiringAssistance.ToString(), placeholders);
		}
	}
}