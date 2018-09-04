using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Services;
using Survi.Prevention.Models.DataTransfertObjects.Reporting;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportBuildingDetailGroupHandler : BaseReportGroupHandler<BuildingDetailForReport>
	{
		protected override ReportBuildingGroup Group => ReportBuildingGroup.Detail;

		private readonly BuildingDetailService service;
		private readonly string sitePlanPlaceholder = "{{SitePlan}}";

		public ReportBuildingDetailGroupHandler(BuildingDetailService service)
		{
			this.service = service;
		}

		protected override List<BuildingDetailForReport> GetData(Guid mainBuildingId, string languageCode)
		{
			return new List<BuildingDetailForReport> {service.GetDetailForReport(mainBuildingId, languageCode)};
		}

		protected override string GetFilledTemplate(string groupTemplate, BuildingDetailForReport entity, string languageCode)
		{
			var filledTemplate = base.GetFilledTemplate(groupTemplate, entity, languageCode);
			if (filledTemplate.Contains(sitePlanPlaceholder))
				filledTemplate = ReplaceSitePlanPlaceholderByPicture(entity, filledTemplate);
			
			return filledTemplate;
		}

		private string ReplaceSitePlanPlaceholderByPicture(BuildingDetailForReport entity, string filledTemplate)
		{
			var picture = service.GetSitePlan(entity.Id);
			if (picture == null)
				filledTemplate = filledTemplate.Replace(sitePlanPlaceholder, "");
			else
				filledTemplate = filledTemplate.Replace("{{" + sitePlanPlaceholder + "}}", FormatPicture(picture.PictureData));
			return filledTemplate;
		}

		private string FormatPicture(string picture)
		{
			return "<img style=\"margin: 20px 20px\" src=\"data:image/png;base64, " + picture +
			       "\" height=\"400\" />";
		}

		protected override string FormatPropertyValue((string name, object value) property, string languageCode)
		{
			if (property.value is GarageType type)
				return GetBuildingGarageLocalized(type, languageCode);		
			return base.FormatPropertyValue(property, languageCode);
		}

		private string GetBuildingGarageLocalized(GarageType garageType, string languageCode)
		{
			var val = languageCode == "en" ? "No" : "Non";
			switch (garageType)
			{
				case GarageType.Detached:
					val = languageCode == "en" ? "Detached" : "Détaché";
					break;
				case GarageType.Yes:
					val = languageCode == "en" ? "Yes" : "Oui";
					break;
			}

			return val;
		}
	}
}