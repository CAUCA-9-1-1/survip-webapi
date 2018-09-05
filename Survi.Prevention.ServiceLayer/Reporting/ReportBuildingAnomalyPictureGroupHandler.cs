using System;
using System.Collections.Generic;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportBuildingAnomalyPictureGroupHandler : BaseReportGroupHandler<BuildingChildPictureForWeb>
	{
		private readonly BuildingAnomalyService service;

		protected override ReportBuildingGroup Group => ReportBuildingGroup.AnomalyPicture;

		public ReportBuildingAnomalyPictureGroupHandler(BuildingAnomalyService service)
		{
			this.service = service;
		}

		protected override List<BuildingChildPictureForWeb> GetData(Guid idParent, string languageCode)
		{
			return service.GetAnomalyPictures(idParent, languageCode);
		}

		protected override string FormatPropertyValue((string name, object value) property, string languageCode)
		{
			if (property.name == "PictureData")
			{
				return "<img style=\"margin: 20px 20px\" src=\"data:image/png;base64, " +
				       property.value +
				       "\" height=\"400\" />";
			}
			return base.FormatPropertyValue(property, languageCode);
		}
	}
}