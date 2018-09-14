using System;
using System.Collections.Generic;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportingTemplateVariableListExtractor
    {
	    private readonly string template;

		public ReportingTemplateVariableListExtractor(string template)
		{
			this.template = template;
		}

		public List<ReportBuildingGroup> GetGroups()
		{
			var list = new List<ReportBuildingGroup>();

			foreach(ReportBuildingGroup value in Enum.GetValues(typeof(ReportBuildingGroup)))
			{
				if (HasGroup(value, template))
					list.Add(value);
			}

			return list;
		}

	    public static string GetOpening(ReportBuildingGroup group) => $"[{group.ToString()}]";
	    public static string GetClosure(ReportBuildingGroup group) => $"[/{group.ToString()}]";

		public static string RemoveOpeningAndClosure(ReportBuildingGroup group, string template)
		{
			return template.Replace(GetOpening(group), "").Replace(GetClosure(group), "");
		}

		public static string GetGroupContent(ReportBuildingGroup group, string template)
		{
			var opening = GetOpening(group);
			var closure = GetClosure(group);

			var start = template.IndexOf(opening, StringComparison.Ordinal);
			var end = template.IndexOf(closure, StringComparison.Ordinal);

			if (start == -1 || end == -1)
				return "";

			var length = end - start + closure.Length;
			var content = template.Substring(start, length);
			return content;
		}

		public static bool HasGroup(ReportBuildingGroup group, string template)
		{		
			var opening = GetOpening(group);
			var closure = GetClosure(group);

			return template.Contains(opening) && template.Contains(closure);
		}
    }
}
