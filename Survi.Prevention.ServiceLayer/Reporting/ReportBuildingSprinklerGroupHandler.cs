﻿using System;
using System.Collections.Generic;
using Survi.Prevention.Models.DataTransfertObjects.Reporting;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportBuildingSprinklerGroupHandler : BaseReportGroupHandler<SprinklerForReport>
	{
		private readonly BuildingSprinklerService service;
		protected override ReportBuildingGroup Group => ReportBuildingGroup.BuildingSprinkler;

		public ReportBuildingSprinklerGroupHandler(BuildingSprinklerService service)
		{
			this.service = service;
		}

		protected override List<SprinklerForReport> GetData(Guid idParent, string languageCode)
		{
			return service.GetSprinklersForReport(idParent, languageCode);
		}

		public static (string Group, List<string> Placeholders) GetPlaceholders()
		{
			var placeholders = GetPlaceholderList();
			return (ReportBuildingGroup.BuildingSprinkler.ToString(), placeholders);
		}
	}
}