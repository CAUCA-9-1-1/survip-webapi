using System;

namespace Survi.Prevention.ServiceLayer.Reporting
{
    public class BuildingReportTemplateFiller
    {
		private readonly ReportBuildingGroupHandler handler;
	    private readonly ReportInspectionGroupHandler inspectionHandler;

		public BuildingReportTemplateFiller(ReportBuildingGroupHandler handler, ReportInspectionGroupHandler inspectionHandler)
		{
			this.handler = handler;
			this.inspectionHandler = inspectionHandler;
		}

		public string FillTemplate(Guid buildingId, string template, string languageCode)
		{
			var buildingPart = ReportingTemplateVariableListExtractor.GetGroupContent(ReportBuildingGroup.Building, template);
			var filledTemplate = template.Replace(buildingPart, handler.FillGroup(buildingPart, buildingId, languageCode));
			var inspectionPart = ReportingTemplateVariableListExtractor.GetGroupContent(ReportBuildingGroup.Inspection, template);
			filledTemplate = filledTemplate.Replace(inspectionPart, inspectionHandler.FillGroup(inspectionPart, buildingId, languageCode));
			return filledTemplate;
		}
    }
}
