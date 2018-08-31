using System;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public abstract class BaseReportGroupHandlerWithChild<T> : BaseReportGroupHandler<T>
		where T : class, IDataTransferObjectWithId
	{
		protected string FillSubGroup(string template, Guid idParent, string languageCode, ReportBuildingGroup group, IBaseReportGroupHandler handler)
		{
			if (ReportingTemplateVariableListExtractor.HasGroup(group, template))
			{
				var groupContent = ReportingTemplateVariableListExtractor.GetGroupContent(group, template);
				var filledGroup = handler.FillGroup(groupContent, idParent, languageCode);
				template = template.Replace(groupContent, filledGroup);
			}
			return template;
		}

		protected override string GetFilledTemplate(string groupTemplate, T entity, string languageCode)
		{
			foreach (var property in entity.GetPublicProperties())
			{
				groupTemplate = FillChildren(groupTemplate, entity.Id, languageCode);
				groupTemplate = ReplacePropertiesPlaceholder(groupTemplate, property);
			}

			return groupTemplate;
		}		

		protected abstract string FillChildren(string template, Guid idParent, string languageCode);
	}
}