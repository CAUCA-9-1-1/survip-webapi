using System;
using System.Collections.Generic;
using System.Linq;
using Survi.Prevention.Models.DataTransfertObjects.Reporting;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportMainBuildingGroupHandler : BaseReportGroupHandlerWithChild<BuildingForReport>
	{
		private readonly ReportBuildingFireHydrantGroupHandler hydrantHandler;
		private readonly ReportBuildingCourseGroupHandler courseHandler;
		private readonly BuildingService service;
	    private readonly FireSafetyDepartmentService departmentService;
		private readonly BuildingDetailService detailService;
		private static readonly string sitePlanPlaceholder = "SitePlan";
	    private static readonly string fireSafetyDepartmentLogoPlaceholder = "FireSafetyLogo";

		protected override ReportBuildingGroup Group => ReportBuildingGroup.MainBuilding;		

		public ReportMainBuildingGroupHandler(BuildingService service, BuildingDetailService detailService, FireSafetyDepartmentService departmentService,
			ReportBuildingFireHydrantGroupHandler hydrantHandler, ReportBuildingCourseGroupHandler courseHandler)
		{
			this.service = service;
		    this.departmentService = departmentService;
			this.detailService = detailService;
			this.hydrantHandler = hydrantHandler;
			this.courseHandler = courseHandler;
		}

		protected override List<BuildingForReport> GetData(Guid mainBuildingId, string languageCode)
		{
			return service.GetBuildingsForReport(mainBuildingId, languageCode, true);
		}

		protected override string GetFilledTemplate(string groupTemplate, BuildingForReport entity, string languageCode)
		{
			var filledTemplate = base.GetFilledTemplate(groupTemplate, entity, languageCode);
			if (filledTemplate.Contains($"@{Group.ToString()}.{sitePlanPlaceholder}@"))
				filledTemplate = ReplaceSitePlanPlaceholderByPicture(entity, filledTemplate);
		    if (filledTemplate.Contains($"@{Group.ToString()}.{fireSafetyDepartmentLogoPlaceholder}"))
		        filledTemplate = ReplaceFireSafetyLogoByPicture(entity, filledTemplate);

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
            placeholders.Add(fireSafetyDepartmentLogoPlaceholder);
			return (ReportBuildingGroup.MainBuilding.ToString(), placeholders);
		}

		private string ReplaceSitePlanPlaceholderByPicture(BuildingForReport entity, string filledTemplate)
		{
			var detailId = detailService.GetIdByIdBuilding(entity.Id);
			var picture = detailId != null ? detailService.GetSitePlan(detailId.Value) : null; 
			filledTemplate = picture == null
				? filledTemplate.Replace($"@{Group.ToString()}.{sitePlanPlaceholder}@", "")
				: filledTemplate.Replace($"@{Group.ToString()}.{sitePlanPlaceholder}@", PictureHtmlTagGenerator.GetTag(picture.DataUri));
			return filledTemplate;
		}

	    private string ReplaceFireSafetyLogoByPicture(BuildingForReport entity, string filledTemplate)
	    {
	        var idCity = service.GetIdCity(entity.Id);
	        var picture = departmentService.GetLogoByCity(idCity);

	        if (picture == null)
	        {
	            filledTemplate = filledTemplate.Replace($"@{Group.ToString()}.{fireSafetyDepartmentLogoPlaceholder}@", "");
	        }
	        else
	        {

                var heightWidthInt = filledTemplate.IndexOf($"@{Group.ToString()}.{fireSafetyDepartmentLogoPlaceholder}", StringComparison.Ordinal);
	            bool canStop = false;
	            int countForEnd = (Group.ToString().Length + fireSafetyDepartmentLogoPlaceholder.Length + 2);
	            do
	            {
	                var stringToCheck = filledTemplate.Substring(heightWidthInt, countForEnd);

                    if (!stringToCheck.EndsWith("@"))
	                    countForEnd++;
	                else
	                    canStop = true;
	            } while (canStop == false);

	            var holderSplit = filledTemplate.Substring(heightWidthInt, countForEnd).Split('.');

	            var height = String.Empty;
	            if (holderSplit.Length == 3)
	                height = holderSplit[2].Replace("@", "");

	            filledTemplate = !String.IsNullOrEmpty(height) 
	                ? filledTemplate.Replace($"@{Group.ToString()}.{fireSafetyDepartmentLogoPlaceholder}.{height}@", PictureHtmlTagGenerator.GetTagForLogo(picture.DataUri, height))
	                : filledTemplate.Replace($"@{Group.ToString()}.{fireSafetyDepartmentLogoPlaceholder}@", PictureHtmlTagGenerator.GetTagForLogo(picture.DataUri, "100"));
	        }


            return filledTemplate;
	    }

	    private string ReplaceAltForSrcWithLogo(string filledTemplate, string dataUri)
	    {
	        filledTemplate = filledTemplate.Replace($"alt=\"@{Group.ToString()}.{fireSafetyDepartmentLogoPlaceholder}@\"", "");
	        filledTemplate = filledTemplate.Replace("src=\" \"", $"src=\"{dataUri}\"");
	        return filledTemplate;
	    }
    }
}