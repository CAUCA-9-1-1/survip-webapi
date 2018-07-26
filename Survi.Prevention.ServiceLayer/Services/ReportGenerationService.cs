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
        private const double KMarginInMm = 19.05;

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
            var result = Context.ReportConfigurationTemplate.First(t => t.Name == "Rapport Cauca");
            return result;
        }

        private ReportPlaceholders SetPlaceholders(Guid id, string languageCode)
        {
            var query =
                from inspection in Context.Inspections
                where inspection.Id == id
                let building = inspection.MainBuilding
                from laneLocalization in building.Lane.Localizations
                where laneLocalization.IsActive && laneLocalization.LanguageCode == languageCode
                select new 
                {
                    building.CivicLetter,
                    building.CivicNumber,
                    building.PostalCode,
                    laneLocalization.Name,
                    publicDescription = building.Lane.PublicCode.Description,
                    GenericDescription = building.Lane.LaneGenericCode.Description,
                    building.Lane.LaneGenericCode.AddWhiteSpaceAfter
                };

            var results = query.Single();
            var result = new
                {
                    ZipCode = results.PostalCode,
                    Address = new AddressGenerator()
                        .GenerateAddress(results.CivicNumber, results.CivicLetter, results.Name, results.GenericDescription, results.publicDescription, results.AddWhiteSpaceAfter)
                };

            
            var reportPlaceholders = new ReportPlaceholders
            {
                Address = result.Address,
                ZipCode = result.ZipCode
            };
            return reportPlaceholders;
        }

        public MemoryStream Generate(Guid id, string languageCode)
        {
            var inputStream = new MemoryStream();
            var streamWriter = new StreamWriter(inputStream, new UnicodeEncoding());

            var template = GetTemplate();
            var reportPlaceholders = SetPlaceholders(id, languageCode);
            var inspectionTextReport = reportPlaceholders.ReplacePlaceholders(template.Data);
            streamWriter.Write(inspectionTextReport);
            
            // Prevents getting an empty stream
            streamWriter.Flush(); 
            inputStream.Seek(0, SeekOrigin.Begin);

            var settings = new ConversionSettings
            {
                PageSize = PageSize.Letter,
                Margins = new PageMargins
                {
                    Bottom = KMarginInMm,
                    Top = KMarginInMm,
                    Left = KMarginInMm,
                    Right = KMarginInMm
                }
            };
            var wkhtmltopdf = new FileInfo(@"/usr/bin/wkhtmltopdf");
            var converter = new HtmlToPdfConverter(wkhtmltopdf);
            
            var outputStream = new MemoryStream();
            converter.ConvertToPdf(inputStream, outputStream, settings);
            outputStream.Seek(0, SeekOrigin.Begin);
            streamWriter.Dispose();
            
            return outputStream;
        }
    }
}
