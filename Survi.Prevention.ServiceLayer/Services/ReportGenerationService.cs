using System;
using System.Linq;
using System.IO;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models;
using System.Text;
using Survi.Prevention.ServiceLayer.Reporting;
using WkWrap;

namespace Survi.Prevention.ServiceLayer.Services
{
    public class ReportGenerationService : BaseService
    {
        private const double MarginInMm = 19.05;

		private readonly BuildingReportTemplateFiller templateFiller;

		public ReportGenerationService(ManagementContext context, BuildingReportTemplateFiller templateFiller) 
			: base(context)
		{
			this.templateFiller = templateFiller;
		}
        
        private ReportConfigurationTemplate GetTemplate(Guid id)
        {
            return Context.ReportConfigurationTemplate.FirstOrDefault(t => t.Id == id);
        }

        private string GetWkhtmltopdfPath()
        {
            var os = Environment.OSVersion;
            var pid = os.Platform;
            switch (pid) 
            {
                case PlatformID.Win32NT:
                case PlatformID.Win32S:
                case PlatformID.Win32Windows:
                case PlatformID.WinCE:
                    return @"C:\Program Files\wkhtmltopdf\bin\wkhtmltopdf.exe";
                case PlatformID.Unix:
                    return @"/usr/bin/wkhtmltopdf";
                case PlatformID.MacOSX:
                    return @"/usr/local/bin/wkhtmltopdf";
                default:
                    return "";
            }
        }

        public MemoryStream Generate(Guid inspectionId, Guid templateId, string languageCode)
        {
	        var filledTemplate = GetFilledTemplate(inspectionId, templateId, languageCode);

			using (var inputStream = new MemoryStream())
			using (var streamWriter = new StreamWriter(inputStream, new UnicodeEncoding()))
			{
				streamWriter.Write(filledTemplate);
				streamWriter.Flush();
				inputStream.Seek(0, SeekOrigin.Begin);

				var settings = GetConversionSettings();

				var wkhtmltopdf = new FileInfo(GetWkhtmltopdfPath());
				var converter = new HtmlToPdfConverter(wkhtmltopdf);

				var outputStream = new MemoryStream();
				converter.ConvertToPdf(inputStream, outputStream, settings);
				outputStream.Seek(0, SeekOrigin.Begin);				
				return outputStream;
			}
        }

	    private static ConversionSettings GetConversionSettings()
	    {
		    var settings = new ConversionSettings
		    {
			    PageSize = PageSize.Letter,
			    Margins = new PageMargins
			    {
				    Bottom = MarginInMm,
				    Top = MarginInMm,
				    Left = MarginInMm,
				    Right = MarginInMm
			    }
		    };
		    return settings;
	    }

	    private string GetFilledTemplate(Guid buildingId, Guid templateId, string languageCode)
	    {
		    var template = GetTemplate(templateId);
		    template.Data = "<style type=\"text/css\">h3, tr { page-break-inside: avoid; }<\\style>" + template.Data;
		    var filledTemplate = templateFiller.FillTemplate(buildingId, template.Data, languageCode);
		    return filledTemplate;
	    }       
    }
}
