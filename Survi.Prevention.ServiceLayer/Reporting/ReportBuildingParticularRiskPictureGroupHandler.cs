using System;
using System.Collections.Generic;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportBuildingParticularRiskPictureGroupHandler : BaseReportGroupHandler<InspectionPictureForWeb>
	{
		private readonly BuildingParticularRiskService service;
		protected override ReportBuildingGroup Group => ReportBuildingGroup.BuildingParticularRiskPicture;

		public ReportBuildingParticularRiskPictureGroupHandler(BuildingParticularRiskService service)
		{
			this.service = service;
		}

		protected override List<InspectionPictureForWeb> GetData(Guid idParent, string languageCode)
		{
			return service.GetRiskPictures(idParent, languageCode);
		}

		public static (string Group, List<string> Placeholders) GetPlaceholders()
		{
			var placeholders = GetPlaceholderList();
			return (ReportBuildingGroup.BuildingParticularRiskPicture.ToString(), placeholders);
		}
	}
}