using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Services;
using Survi.Prevention.Models.DataTransfertObjects.Reporting;
using Survi.Prevention.ServiceLayer.Localization.Base;	

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportBuildingDetailGroupHandler : BaseReportGroupHandler<BuildingDetailForReport>
	{
		protected override ReportBuildingGroup Group => ReportBuildingGroup.BuildingDetail;

		private readonly BuildingDetailService service;
		private static readonly string sitePlanPlaceholder = "SitePlan";

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
			if (filledTemplate.Contains($"@{Group.ToString()}.{sitePlanPlaceholder}@"))
				filledTemplate = ReplaceSitePlanPlaceholderByPicture(entity, filledTemplate);
			
			return filledTemplate;
		}

		private string ReplaceSitePlanPlaceholderByPicture(BuildingDetailForReport entity, string filledTemplate)
		{
			var picture = service.GetSitePlan(entity.Id);

		    filledTemplate = PictureHtmlTagGenerator.GetFilledTemplateWithPicture(filledTemplate, Group.ToString(), sitePlanPlaceholder, picture.DataUri, PictureType.Tag);

			return filledTemplate;
		}

		protected override string FormatPropertyValue((string name, object value) property, string languageCode)
		{
			if (property.value is GarageType type)
				return GetBuildingGarageLocalized(type, languageCode);		
			return base.FormatPropertyValue(property, languageCode);
		}

		private string GetBuildingGarageLocalized(GarageType garageType, string languageCode)
		{
			return garageType.GetDisplayName(languageCode);
		}

		public static (string Group, List<string> Placeholders) GetPlaceholders()
		{
			var placeholders = GetPlaceholderList();
			placeholders.Add(sitePlanPlaceholder);
			return (ReportBuildingGroup.BuildingDetail.ToString(), placeholders);
		}
	}
}