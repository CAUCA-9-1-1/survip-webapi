using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.ServiceLayer.DataCopy;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class ReportConfigurationTemplateService : BaseCrudService<ReportConfigurationTemplate>
	{
		public ReportConfigurationTemplateService(IManagementContext context) : base(context)
		{
		}

		public override ReportConfigurationTemplate Get(Guid id)
		{
			var result = Context.ReportConfigurationTemplate
				.First(u => u.Id == id);

			return result;
		}

		public List<ReportConfigurationTemplate> GetPlaceholders(List<Guid> allowedDepartmentIds = null)
		{
		    var query =
		        from template in Context.ReportConfigurationTemplate
		        select template;

		    if (allowedDepartmentIds != null)
		    {
		        query = query.Where(t => allowedDepartmentIds.Contains(t.IdFireSafetyDepartment) || t.IdFireSafetyDepartment == Guid.Empty);
		    }

            query = 
                from template in query
				select new ReportConfigurationTemplate
				{
					Id = template.Id,
					Name = template.Name,
					IdFireSafetyDepartment = template.IdFireSafetyDepartment,
					IsDefault = template.IsDefault
				};

			return query.ToList();
		}
		
		public ReportConfigurationTemplate CopyReportConfiguration(Guid idReport)
		{
			var reportTemplate = Context.ReportConfigurationTemplate.AsNoTracking()
				.First(u => u.Id == idReport);

			if (reportTemplate != null)
			{
				ReportConfigurationTemplate newReportTemplate = new ReportTemplateDuplicator().DuplicateReportTemplate(reportTemplate);

				Context.ReportConfigurationTemplate.Add(newReportTemplate);
				Context.SaveChanges();
				return newReportTemplate;
			}
			return null;
		}	

		public override Guid AddOrUpdate(ReportConfigurationTemplate entity)
		{
			if (entity.IsDefault)
			{
				RemovePreviousDefault(entity.IdFireSafetyDepartment, entity.Id);
			}

			var isExistRecord = Context.Set<ReportConfigurationTemplate>().Any(c => c.Id == entity.Id);

			if (isExistRecord)
				Context.Set<ReportConfigurationTemplate>().Update(entity);
			else
				Context.Set<ReportConfigurationTemplate>().Add(entity);

			Context.SaveChanges();
			return entity.Id;
		}

		private void RemovePreviousDefault(Guid? idFireSafetyDepartment)
		{
				var query =
				from template in Context.ReportConfigurationTemplate
				where template.IdFireSafetyDepartment == idFireSafetyDepartment && template.IsDefault && template.Id != currentReportId
				select template;

				foreach (ReportConfigurationTemplate template in query) {
					template.IsDefault = false;
					Context.Set<ReportConfigurationTemplate>().Update(template);
				}

				Context.SaveChanges();
		}
	}
}
