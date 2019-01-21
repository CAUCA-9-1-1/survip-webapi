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
                where template.IsActive && ContainsAllowedDepartmentId(allowedDepartmentIds, template.IdFireSafetyDepartment)
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
			return reportTemplate;
		}	

        public override Guid AddOrUpdate(ReportConfigurationTemplate entity)
		{
            if (entity.IsDefault)
            {
                RemovePreviousDefault(entity.IdFireSafetyDepartment);
            }

			var isExistRecord = Context.Set<ReportConfigurationTemplate>().Any(c => c.Id == entity.Id);

			if (isExistRecord)
				Context.Set<ReportConfigurationTemplate>().Update(entity);
			else
				Context.Set<ReportConfigurationTemplate>().Add(entity);

			Context.SaveChanges();
			return entity.Id;
		}

        private bool ContainsAllowedDepartmentId(List<Guid> allowedDepartmentIds, Guid templateFireDepartmentId)
        {
            if (allowedDepartmentIds == null)
                return false;
            return (allowedDepartmentIds.Contains(templateFireDepartmentId)) || templateFireDepartmentId == Guid.Empty;
        }

        private void RemovePreviousDefault(Guid? idFireSafetyDepartment)
        {
                var query =
                from template in Context.ReportConfigurationTemplate
                where template.IdFireSafetyDepartment == idFireSafetyDepartment && template.IsDefault
                select template;

                query.ToList();

                foreach (ReportConfigurationTemplate template in query) {
                    template.IsDefault = false;
                    Context.Set<ReportConfigurationTemplate>().Update(template);
                }

                Context.SaveChanges();
        }
    }
}
