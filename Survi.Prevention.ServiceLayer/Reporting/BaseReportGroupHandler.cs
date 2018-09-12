using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public abstract class BaseReportGroupHandler<T> : IBaseReportGroupHandler
		where T : class
	{
		protected abstract ReportBuildingGroup Group { get; }

		public string FillGroup(string template, Guid idParent, string languageCode)
		{
			template = ReportingTemplateVariableListExtractor.RemoveOpeningAndClosure(Group, template);
			var filledGroup = string.Empty;
			var entities = GetData(idParent, languageCode);

			foreach (var entity in entities)
				filledGroup += GetFilledTemplate(template, entity, languageCode);

			return filledGroup;
		}

		protected static List<string> GetPlaceholderList()
		{
			var placeholders = (
				from prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
				where prop.CanRead
				select prop.Name
			).ToList();
			return placeholders;
		}

		protected virtual string GetFilledTemplate(string groupTemplate, T entity, string languageCode)
		{
			foreach (var property in entity.GetPublicProperties())
				groupTemplate = ReplacePropertiesPlaceholder(groupTemplate, languageCode, property);

			return groupTemplate;
		}

		protected string ReplacePropertiesPlaceholder(string groupTemplate, string languageCode, (string name, object value) property)
		{
			groupTemplate = groupTemplate.Replace($"@{Group.ToString()}.{property.name}@", FormatPropertyValue(property, languageCode));
			return groupTemplate;
		}

		protected virtual string FormatPropertyValue((string name, object value) property, string languageCode)
		{
			if (property.value is bool value)
				return Localization.EnumResource.ResourceManager.GetString(value ? "Yes" : "No", System.Globalization.CultureInfo.GetCultureInfo(languageCode));

			if (property.value is decimal valueDecimal)
				return $"{valueDecimal:f2}";

			return (property.value ?? "").ToString();
		}

		protected abstract List<T> GetData(Guid idParent, string languageCode);		
	}
}