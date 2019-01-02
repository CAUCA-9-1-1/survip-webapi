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

        public override List<ReportConfigurationTemplate> GetList()
        {
            var query =
                from template in Context.ReportConfigurationTemplate
                where template.IsActive
                select new ReportConfigurationTemplate
                {
                    Id = template.Id,
                    Name = template.Name
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
    }
}
