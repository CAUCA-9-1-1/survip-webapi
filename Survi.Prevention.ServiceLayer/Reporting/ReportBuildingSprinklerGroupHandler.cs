using System;
using System.Collections.Generic;
using Survi.Prevention.Models.DataTransfertObjects.Reporting;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportBuildingSprinklerGroupHandler : BaseReportGroupHandler<FireProtectionForReport>
	{
		private readonly BuildingSprinklerService service;
		protected override ReportBuildingGroup Group => ReportBuildingGroup.Sprinkler;

		public ReportBuildingSprinklerGroupHandler(BuildingSprinklerService service)
		{
			this.service = service;
		}

		protected override List<FireProtectionForReport> GetData(Guid idParent, string languageCode)
		{
			return service.GetSprinklersForReport(idParent, languageCode);
		}
	}
}