using System;
using System.Linq;
using System.IO;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models;
using System.Text;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Reporting;
using WkWrap;

namespace Survi.Prevention.ServiceLayer.Services
{
    public class ReportGenerationService : BaseService
    {
        private const double MarginInMm = 19.05;

		private readonly ReportBuildingGroupHandler buildingHandler;

		public ReportGenerationService(ManagementContext context, ReportBuildingGroupHandler buildingHandler) 
			: base(context)
		{
			this.buildingHandler = buildingHandler;
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

	    private string GetFilledTemplate(Guid inspectionId, Guid templateId, string languageCode)
	    {
		    var template = GetTemplate(templateId);
		    template.Data = "<style type=\"text/css\">h3, tr { page-break-inside: avoid; }<\\style>" + template.Data;
		    var filledTemplate = buildingHandler.FillGroup(template.Data, inspectionId, languageCode);
		    return filledTemplate;
	    }

	    private Guid GetCurrentInspectionId(Guid buildingId)
        {
            var query =
                from inspection in Context.Inspections
                where inspection.IdBuilding == buildingId && inspection.IsActive
                select new 
                {
                    idInspection = inspection.Id
                };

            var result = query.First();
            return result.idInspection;
        }
        
        private BuildingGeneralInformationForReport GetGeneralInformation(Guid buildingId, string languageCode)
        {
            var query =
            from inspection in Context.Inspections
            where inspection.IdBuilding == buildingId && inspection.IsActive
            let building = inspection.MainBuilding
            
            from buildingLocalization in building.Localizations
            where buildingLocalization.LanguageCode == languageCode
            from laneLocalization in building.Lane.Localizations
            where laneLocalization.IsActive && laneLocalization.LanguageCode == languageCode
            from riskLevelLocalization in building.RiskLevel.Localizations
            where riskLevelLocalization.IsActive && riskLevelLocalization.LanguageCode == languageCode
            from utilisationCode in Context.UtilisationCodes
            where utilisationCode.IsActive && utilisationCode.Id == building.IdUtilisationCode
            from utilisationCodelocalization in utilisationCode.Localizations
            where utilisationCodelocalization.LanguageCode == languageCode
            select new 
            {
                buildingName = buildingLocalization.Name,
                idInspection = inspection.Id,
                idBuilding = building.Id,
                civicLetter = building.CivicLetter,
                civicNumber = building.CivicNumber,
                matricule = building.Matricule,
                postalCode = building.PostalCode,
                riskLevelName = riskLevelLocalization.Name,
                laneName = laneLocalization.Name,
                publicDescription = building.Lane.PublicCode.Description,
                genericDescription = building.Lane.LaneGenericCode.Description,
                building.Lane.LaneGenericCode.AddWhiteSpaceAfter,
                assignment = utilisationCodelocalization.Description

            };
 
            var results = query.First();
            return new BuildingGeneralInformationForReport
                {
                    Alias = results.buildingName,
                    IdInspection = results.idInspection,
                    IdBuilding = results.idBuilding,
                    RiskCategory = results.riskLevelName,
                    Matricule = results.matricule,
                    ZipCode = results.postalCode,
                    Lane = results.laneName,
                    Address = new AddressGenerator()
                        .GenerateAddress(
                        results.civicNumber,
                        results.civicLetter, 
                        results.laneName,
                        results.genericDescription, 
                        results.publicDescription,
                        results.AddWhiteSpaceAfter
                    ),
                    Assignment = results.assignment
            };
        }

        private string GetTransversal(Guid id, string languageCode)
        {
            var inspection = Context.Inspections
                .First(u => u.Id == id);
            var building = Context.Buildings.First(u => u.Id == inspection.IdBuilding);
            var laneId = building.IdLaneTransversal;
            if (laneId == null)
                return "";
            var query =
                from lane in Context.Lanes
                where lane.IsActive && lane.Id == laneId
                from laneLocalization in lane.Localizations
                where laneLocalization.LanguageCode == languageCode
                select new 
                {
                    laneLocalization.Name
                };
 
            var res = query.SingleOrDefault();
 
            return res != null ? res.Name : "";
        }
             
        private string GetBuildingGarageLocalized(GarageType garageType, string languageCode)
        {
            var val = languageCode == "en" ? "No" : "Non";
            switch (garageType)
            {
                case GarageType.Detached:
                    val = languageCode == "en" ? "Detached" : "Détaché";
                    break;
                case GarageType.Yes:
                    val = languageCode == "en" ? "Yes" : "Oui";
                    break;
            }

            return val;
        }
        
        private BuildingDetailForReport GetBuildingDetail(Guid id, string languageCode)
        {
            var inspection = Context.Inspections
                .First(u => u.Id == id);
            var building = Context.Buildings.First(u => u.Id == inspection.IdBuilding);
            var details = Context.BuildingDetails.FirstOrDefault(u => u.IdBuilding == building.Id);
            if (details == null)
            {
                return new BuildingDetailForReport();
            }

            var query =
                from buildingTypes in Context.BuildingTypes
                where buildingTypes.IsActive && buildingTypes.Id == details.IdBuildingType
                from buildingTypeLocalization in buildingTypes.Localizations
                where buildingTypeLocalization.LanguageCode == languageCode
                
                from constructionType in Context.ConstructionTypes
                where constructionType.IsActive && constructionType.Id == details.IdConstructionType
                from constructionTypeLocalization in constructionType.Localizations
                where constructionTypeLocalization.LanguageCode == languageCode
                
                from constructionFireResistanceType in Context.ConstructionFireResistanceTypes
                where constructionFireResistanceType.IsActive && 
                      constructionFireResistanceType.Id == details.IdConstructionFireResistanceType
                from constructionFireResistanceTypeLocalization in constructionFireResistanceType.Localizations
                where constructionFireResistanceTypeLocalization.LanguageCode == languageCode
                      
                from sidingType in Context.SidingTypes
                where sidingType.IsActive && 
                      sidingType.Id == details.IdBuildingSidingType
                from sidingTypeLocalization in sidingType.Localizations
                where sidingTypeLocalization.LanguageCode == languageCode
                      
                from roofType in Context.RoofTypes
                where roofType.IsActive && roofType.Id == details.IdRoofType
                from roofTypeLocalization in roofType.Localizations
                where roofTypeLocalization.LanguageCode == languageCode
                      
                from roofMaterialType in Context.RoofMaterialTypes
                where roofMaterialType.IsActive && roofMaterialType.Id == details.IdRoofMaterialType
                from roofMaterialTypeLocalization in roofMaterialType.Localizations
                where roofMaterialTypeLocalization.LanguageCode == languageCode
                select new 
                {
                    BuildingType = buildingTypeLocalization.Name,
                    ConstructionType = constructionTypeLocalization.Name,
                    ConstructionFireResistanceLocalized = constructionFireResistanceTypeLocalization.Name,
                    RoofMaterialLocalized = roofMaterialTypeLocalization.Name,
                    RoofTypeLocalized = roofTypeLocalization.Name,
                    ConstructionSidingLocalized = sidingTypeLocalization.Name
                };
            
            var res = query.SingleOrDefault();
            var result = new BuildingDetailForReport
            {
                BuildingType = res == null ? "" : res.BuildingType,
                GarageTypeLocalized = GetBuildingGarageLocalized(details.GarageType, languageCode),
                BuildingHeight = details.Height,
                EstimatedWaterFlow = details.EstimatedWaterFlow,
                ConstructionTypeLocalized = res == null ? "" : res.ConstructionType,
                ConstructionFireResistanceLocalized = res == null ? "" : res.ConstructionFireResistanceLocalized,
                ConstructionSidingLocalized = res == null ? "" : res.ConstructionSidingLocalized,
                RoofTypeLocalized = res == null ? "" : res.RoofTypeLocalized,
                RoofMaterialLocalized = res == null ? "" : res.RoofMaterialLocalized,
                
                ImplementationPlan = details.PlanPicture
            };

            return result;
        }
    }
}
