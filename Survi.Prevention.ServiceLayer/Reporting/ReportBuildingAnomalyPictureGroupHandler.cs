using System;
using System.Collections.Generic;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportBuildingAnomalyPictureGroupHandler : BaseReportGroupHandler<InspectionPictureForWeb>
	{
		private readonly BuildingAnomalyService service;

		protected override ReportBuildingGroup Group => ReportBuildingGroup.BuildingAnomalyPicture;

		public ReportBuildingAnomalyPictureGroupHandler(BuildingAnomalyService service)
		{
			this.service = service;
		}

		protected override List<InspectionPictureForWeb> GetData(Guid idParent, string languageCode)
		{
			return service.GetAnomalyPictures(idParent, languageCode);
		}

		public static (string Group, List<string> Placeholders) GetPlaceholders()
		{
			var placeholders = GetPlaceholderList();
			return (ReportBuildingGroup.BuildingAnomalyPicture.ToString(), placeholders);
		}
	}
}