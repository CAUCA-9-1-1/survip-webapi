using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.SecurityManagement;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.Models;
using Survi.Prevention.Models.DataTransfertObjects;
using System.Net.Http;

namespace Survi.Prevention.ServiceLayer.Services
{
    public class ReportGenerationService : BaseCrudService<ReportConfigurationTemplate>
    {
        private static readonly HttpClient client = new HttpClient();
        
        public ReportGenerationService(ManagementContext context) : base(context)
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

        public Guid Generate(Guid id)
        {
            var inspection = Context.Inspections
                .First(u => u.Id == id);
            var building = Context.Buildings.First(u => u.Id == inspection.IdBuilding);
            var template = GetTemplate();
            var newString = template.Data.Replace("@BUILDING.postal_code", building.PostalCode);
            var values = new Dictionary<string, string>
            {
                { "value", newString }
            };
            var content = new FormUrlEncodedContent(values);
            var response = client.PostAsync("http://localhost:5762/save", content);
            return id;
        }

        private ReportConfigurationTemplate GetTemplate()
        {
            var result = Context.ReportConfigurationTemplate
                .ToList();
            var template = result.ElementAt(0);
            return template;
        }
    }
}
