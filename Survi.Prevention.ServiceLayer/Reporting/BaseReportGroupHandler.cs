using System;
using System.Collections.Generic;
using System.Linq;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public abstract class BaseReportGroupHandler<T>
		where T : class
	{
		protected readonly ManagementContext Context;
		protected abstract ReportBuildingGroup Group { get; }

		protected BaseReportGroupHandler(ManagementContext context)
		{
			Context = context;
		}

		public string FillGroup(string template, Guid idParent, string languageCode)
		{
			template = ReportingTemplateVariableListExtractor.RemoveOpeningAndClosure(Group, template);
			var filledGroup = string.Empty;
			var entities = GetData(idParent, languageCode);

			foreach (var entity in entities)
				filledGroup += GetFilledTemplate(template, entity, languageCode);

			return filledGroup;
		}

		protected virtual string GetFilledTemplate(string groupTemplate, T entity, string languageCode)
		{
			foreach (var property in entity.GetPublicProperties())
				groupTemplate = ReplacePropertiesPlaceholder(groupTemplate, property);

			return groupTemplate;
		}

		protected string ReplacePropertiesPlaceholder(string groupTemplate, (string name, string value) property)
		{
			groupTemplate = groupTemplate.Replace("{{" + property.name + "}}", FormatPropertyValue(property));
			return groupTemplate;
		}

		protected virtual string FormatPropertyValue((string name, string value) property)
		{
			return property.value;
		}

		protected abstract List<T> GetData(Guid idParent, string languageCode);		
	}

	public abstract class BaseReportGroupHandlerWithChild<T> : BaseReportGroupHandler<T>
		where T : class, IDataTransferObjectWithId
	{
		protected BaseReportGroupHandlerWithChild(ManagementContext context) : base(context)
		{
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