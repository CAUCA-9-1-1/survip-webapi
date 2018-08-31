using System;
using System.Collections.Generic;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportBuildingParticularRiskPictureGroupHandler : BaseReportGroupHandler<BuildingChildPictureForWeb>
	{
		private readonly BuildingParticularRiskService service;
		protected override ReportBuildingGroup Group => ReportBuildingGroup.ParticularRiskPicture;

		public ReportBuildingParticularRiskPictureGroupHandler(BuildingParticularRiskService service)
		{
			this.service = service;
		}

		protected override List<BuildingChildPictureForWeb> GetData(Guid idParent, string languageCode)
		{
			return service.GetRiskPictures(idParent, languageCode);
		}

		protected override string FormatPropertyValue((string name, string value) property)
		{
			if (property.name == "PictureData")
			{
				return "<img style=\"margin: 20px 20px\" src=\"data:image/png;base64, " +
				       property.value +
				       "\" height=\"400\" />";
			}
			return base.FormatPropertyValue(property);
		}
	}
}