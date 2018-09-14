using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Reporting
{
    public class BuildingReportTemplateFiller
    {
	    private readonly ReportMainBuildingGroupHandler handler;
		private readonly ReportBuildingGroupHandler buildingHandler;
	    private readonly ReportInspectionGroupHandler inspectionHandler;

		public BuildingReportTemplateFiller(ReportMainBuildingGroupHandler handler, ReportBuildingGroupHandler buildingHandler, ReportInspectionGroupHandler inspectionHandler)
		{
			this.handler = handler;
			this.buildingHandler = buildingHandler;
			this.inspectionHandler = inspectionHandler;
		}

		public string FillTemplate(Guid buildingId, string template, string languageCode)
		{
			var filledTemplate = template;

			filledTemplate = FillMainBuildingPart(buildingId, template, languageCode, filledTemplate);
			filledTemplate = FillBuildingsPart(buildingId, template, languageCode, filledTemplate);
			filledTemplate = FillInspectionPart(buildingId, template, languageCode, filledTemplate);

			return filledTemplate;
		}

	    private string FillInspectionPart(Guid buildingId, string template, string languageCode, string filledTemplate)
	    {
		    if (ReportingTemplateVariableListExtractor.HasGroup(ReportBuildingGroup.Inspection, template))
		    {
			    var inspectionPart = ReportingTemplateVariableListExtractor.GetGroupContent(ReportBuildingGroup.Inspection, template);
			    filledTemplate = filledTemplate.Replace(inspectionPart, inspectionHandler.FillGroup(inspectionPart, buildingId, languageCode));
		    }

		    return filledTemplate;
	    }

	    private string FillBuildingsPart(Guid buildingId, string template, string languageCode, string filledTemplate)
	    {
		    if (ReportingTemplateVariableListExtractor.HasGroup(ReportBuildingGroup.Building, template))
		    {
			    var buildingPart = ReportingTemplateVariableListExtractor.GetGroupContent(ReportBuildingGroup.Building, template);
			    filledTemplate = filledTemplate.Replace(buildingPart, buildingHandler.FillGroup(buildingPart, buildingId, languageCode));
		    }

		    return filledTemplate;
	    }

	    private string FillMainBuildingPart(Guid buildingId, string template, string languageCode, string filledTemplate)
	    {
		    if (ReportingTemplateVariableListExtractor.HasGroup(ReportBuildingGroup.MainBuilding, template))
		    {
			    var mainBuildingPart = ReportingTemplateVariableListExtractor.GetGroupContent(ReportBuildingGroup.MainBuilding, template);
			    filledTemplate = filledTemplate.Replace(mainBuildingPart, handler.FillGroup(mainBuildingPart, buildingId, languageCode));
		    }

		    return filledTemplate;
	    }

	    public static List<PlaceholderGroup> GetPlaceholderGroups()
		{
			var list = new List<PlaceholderGroup>();

			Type ti = typeof(IBaseReportGroupHandler);
			foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
			{
				foreach (Type t in asm.GetTypes())
				{
					if (ti.IsAssignableFrom(t) && !t.IsAbstract)
					{
						var result = ((string Group, List<string> Placeholders))t.GetMethod("GetPlaceholders", BindingFlags.Public | BindingFlags.Static)?.Invoke(null, null);
						var group = new PlaceholderGroup { Name = PascalCaseToSentence(result.Group), Tag = result.Group };
						for (int i = 0; i < result.Placeholders.Count; i++)
							group.Placeholders.Add(new Placeholder { Name = result.Placeholders[i], Tag = $"@{result.Group}.{result.Placeholders[i]}@" });

						list.Add(group);
					}
				}
			}

			return list.OrderBy(item => (ReportBuildingGroup)Enum.Parse(typeof(ReportBuildingGroup), item.Tag))
				.ToList();
		}

		private static string PascalCaseToSentence(string input)
		{
			if (string.IsNullOrEmpty(input)) return input;

			var sb = new StringBuilder();
			sb.Append(char.ToUpper(input[0]));

			for (var i = 1; i < input.Length; i++)
			{
				if (char.IsUpper(input[i]) || char.IsDigit(input[i]))
					sb.Append(' ');
				sb.Append(input[i]);
			}
			return sb.ToString();
		}
    }
}
