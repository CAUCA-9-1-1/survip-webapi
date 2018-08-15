using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models;

namespace Survi.Prevention.ServiceLayer.Services
{
    public class ReportConfigurationTemplateService : BaseCrudService<ReportConfigurationTemplate>
    {
        public ReportConfigurationTemplateService(ManagementContext context) : base(context)
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
        
        public List<string> GetAvailablePlaceholders()
        {
            return new ReportPlaceholders().GetAvailablePlaceholders();
        }
    }
}
