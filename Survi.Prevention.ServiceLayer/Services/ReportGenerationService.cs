using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Reflection;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models;
using System.Text;
using WkWrap;

namespace Survi.Prevention.ServiceLayer.Services
{
    public class ReportGenerationService : BaseCrudService<ReportConfigurationTemplate>
    {        
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

        public MemoryStream Generate(Guid id)
        {
            var output = new MemoryStream();
            var input = new MemoryStream();
            var uniEncoding = new UnicodeEncoding();
            var sw = new StreamWriter(input, uniEncoding);

            var template = GetTemplate();
            sw.Write(template.Data);
            sw.Flush();    // Prevents getting an empty stream
            input.Seek(0, SeekOrigin.Begin);

            var wkhtmltopdf = new FileInfo(@"/usr/bin/wkhtmltopdf");
            var converter = new HtmlToPdfConverter(wkhtmltopdf);
            converter.ConvertToPdf(input, output);
            output.Seek(0, SeekOrigin.Begin);
            sw.Dispose();
            
            return output;
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
