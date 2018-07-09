using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models;

namespace Survi.Prevention.ServiceLayer.Services
{
    public class ReportConfigurationService : BaseCrudService<ReportConfigurationTemplate>
    {
        public ReportConfigurationService(ManagementContext context) : base(context)
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
            var result = Context.ReportConfigurationTemplate
                .ToList();

            return result;
        }
    }
}
