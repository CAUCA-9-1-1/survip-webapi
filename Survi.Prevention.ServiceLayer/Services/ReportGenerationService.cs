using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models;
using System.Text;
using System.Text.RegularExpressions;
using WkWrap;

namespace Survi.Prevention.ServiceLayer.Services
{
    public class ReportGenerationService : BaseCrudService<ReportConfigurationTemplate>
    {
        private const double KMarginInMM = 19.05;

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
        
        private ReportConfigurationTemplate GetTemplate()
        {
            var result = Context.ReportConfigurationTemplate
                .ToList();
            var template = result.ElementAt(0);
            return template;
        }

        public MemoryStream Generate(Guid id)
        {
            var inputStream = new MemoryStream();
            var outputStream = new MemoryStream();
            var streamWriter = new StreamWriter(inputStream, new UnicodeEncoding());

            var template = GetTemplate();
            var inspectionTextReport = report.ReplacePlaceholders(template.Data);
            streamWriter.Write(inspectionTextReport);
            streamWriter.Flush();    // Prevents getting an empty stream
            inputStream.Seek(0, SeekOrigin.Begin);

            var settings = new ConversionSettings
            {
                PageSize = PageSize.Letter,
                Margins = new PageMargins
                {
                    Bottom = KMarginInMM,
                    Top = KMarginInMM,
                    Left = KMarginInMM,
                    Right = KMarginInMM
                }
            };
            var wkhtmltopdf = new FileInfo(@"/usr/bin/wkhtmltopdf");
            var converter = new HtmlToPdfConverter(wkhtmltopdf);
            converter.ConvertToPdf(inputStream, outputStream, settings);
            outputStream.Seek(0, SeekOrigin.Begin);
            streamWriter.Dispose();
            
            return outputStream;
        }
        

        
        private Report report = new Report
        {
            Address = "2712 Rue Linton",
            ZipCode = "H2L 9N2"
        };
    }
}
