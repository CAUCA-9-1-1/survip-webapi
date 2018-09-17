using System;
using System.Collections.Generic;
using Survi.Prevention.Models.DataTransfertObjects.Reporting;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportBuildingAlarmPanelGroupHandler : BaseReportGroupHandler<FireProtectionForReport>
	{
		private readonly BuildingAlarmPanelService service;

		protected override ReportBuildingGroup Group => ReportBuildingGroup.BuildingAlarmPanel;

		public ReportBuildingAlarmPanelGroupHandler(BuildingAlarmPanelService service)
		{
			this.service = service;
		}

		protected override List<FireProtectionForReport> GetData(Guid idParent, string languageCode)
		{
			return service.GetPanelsForReport(idParent, languageCode);
		}

		public static (string Group, List<string> Placeholders) GetPlaceholders()
		{
			var placeholders = GetPlaceholderList();
			return (ReportBuildingGroup.BuildingAlarmPanel.ToString(), placeholders);
		}
	}
}