using System;
using System.Collections.Generic;
using Survi.Prevention.Models.DataTransfertObjects.Reporting;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportMainBuildingGroupHandler : BaseReportGroupHandlerWithChild<BuildingForReport>
	{
		private readonly ReportBuildingFireHydrantGroupHandler hydrantHandler;
		private readonly ReportBuildingCourseGroupHandler courseHandler;
		private readonly BuildingService service;
		private readonly BuildingDetailService detailService;
		private static readonly string sitePlanPlaceholder = "SitePlan";

		protected override ReportBuildingGroup Group => ReportBuildingGroup.MainBuilding;

		public ReportMainBuildingGroupHandler()
		{ }

		public ReportMainBuildingGroupHandler(BuildingService service, BuildingDetailService detailService,
			ReportBuildingFireHydrantGroupHandler hydrantHandler, ReportBuildingCourseGroupHandler courseHandler)
		{
			this.service = service;
			this.detailService = detailService;
			this.hydrantHandler = hydrantHandler;
			this.courseHandler = courseHandler;
		}

		protected override List<BuildingForReport> GetData(Guid mainBuildingId, string languageCode)
		{
			return service.GetBuildingsForReport(mainBuildingId, languageCode, false);
		}

		protected override string GetFilledTemplate(string groupTemplate, BuildingForReport entity, string languageCode)
		{
			var filledTemplate = base.GetFilledTemplate(groupTemplate, entity, languageCode);
			if (filledTemplate.Contains(sitePlanPlaceholder))
				filledTemplate = ReplaceSitePlanPlaceholderByPicture(entity, filledTemplate);

			return filledTemplate;
		}


		protected override string FillChildren(string template, Guid idBuilding, string languageCode)
		{
			template = FillSubGroup(template, idBuilding, languageCode, ReportBuildingGroup.MainBuildingFireHydrant, hydrantHandler);
			template = FillSubGroup(template, idBuilding, languageCode, ReportBuildingGroup.MainBuildingCourse, courseHandler);

			return template;
		}

		public static (string Group, List<string> Placeholders) GetPlaceholders()
		{
			var placeholders = GetPlaceholderList();
			placeholders.Add(sitePlanPlaceholder);
			return (ReportBuildingGroup.MainBuilding.ToString(), placeholders);
		}

		private string ReplaceSitePlanPlaceholderByPicture(BuildingForReport entity, string filledTemplate)
		{
			var detailId = detailService.GetIdByIdBuilding(entity.Id);
			var picture = detailId != null ? detailService.GetSitePlan(detailId.Value) : null; ;
			filledTemplate = picture == null
				? filledTemplate.Replace(sitePlanPlaceholder, "")
				: filledTemplate.Replace($"@{Group.ToString()}.{sitePlanPlaceholder}@", FormatPicture(picture.PictureData));
			return filledTemplate;
		}

		private string FormatPicture(string picture)
		{
			return "<img style=\"margin: 20px 20px\" src=\"" + picture +
			       "\" height=\"400\" />";
		}
	}
}