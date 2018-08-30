using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models;
using System.Text;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;
using WkWrap;

namespace Survi.Prevention.ServiceLayer.Services
{
    public class ReportGenerationService : BaseService
    {
        private const double MarginInMm = 19.05;

        private readonly BuildingPersonRequiringAssistanceService pnapService;
        private readonly BuildingHazardousMaterialService hazardousMaterialService;
        /*private readonly BuildingAlarmPanelService alarmPanelService;
        private readonly BuildingParticularRiskService particularRiskService;
        private readonly BuildingParticularRiskPictureService particularRiskPictureService;
        private readonly BuildingSprinklerService sprinklerService;*/
        private readonly BuildingContactService contactService;
	    private readonly InspectionQuestionService questionService;
		/*private readonly BuildingFireHydrantService fireHydrantService;        
        private readonly BuildingCourseService courseService;
        private readonly BuildingAnomalyService anomalyService;
        private readonly BuildingAnomalyPictureService anomalyPictureService;*/

		public ReportGenerationService(ManagementContext context) : base(context)
        {
            pnapService                  = new BuildingPersonRequiringAssistanceService(context);
            hazardousMaterialService     = new BuildingHazardousMaterialService(context);
            /*alarmPanelService            = new BuildingAlarmPanelService(context);
            particularRiskService        = new BuildingParticularRiskService(context);
            particularRiskPictureService = new nBuildingParticularRiskPictureService(context);
            sprinklerService             = new BuildingSprinklerService(context);*/
            contactService               = new BuildingContactService(context);
            //fireHydrantService           = new BuildingFireHydrantService(context);
            questionService              = new InspectionQuestionService(context);
            /*courseService                = new BuildingCourseService(context);
            anomalyService               = new BuildingAnomalyService(context);
            anomalyPictureService        = new BuildingAnomalyPictureService(context);*/
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

        public MemoryStream Generate(Guid buildingId, Guid templateId, string languageCode)
        {
            var inputStream = new MemoryStream();
            var streamWriter = new StreamWriter(inputStream, new UnicodeEncoding());

            var template = GetTemplate(templateId);
            
            // Avoids splitting tables
            template.Data = "<style type=\"text/css\">h3, tr { page-break-inside: avoid; }<\\style>" + template.Data;
            
            var reportPlaceholders = SetPlaceholders(buildingId, languageCode);
            string inspectionTextReport = reportPlaceholders.ReplacePlaceholders(template.Data);

            streamWriter.Write(inspectionTextReport);
            
            // Prevents getting an empty stream
            streamWriter.Flush(); 
            inputStream.Seek(0, SeekOrigin.Begin);

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
            var wkhtmltopdf = new FileInfo(GetWkhtmltopdfPath());
            var converter = new HtmlToPdfConverter(wkhtmltopdf);
            
            var outputStream = new MemoryStream();
            converter.ConvertToPdf(inputStream, outputStream, settings);
            outputStream.Seek(0, SeekOrigin.Begin);
            streamWriter.Dispose();
            
            return outputStream;
        }
        
        private ReportPlaceholders SetPlaceholders(Guid buildingId, string languageCode)
        {
            var reportPlaceholders = new ReportPlaceholders();
            var inspectionId = GetCurrentInspectionId(buildingId);
            var detail = GetBuildingDetail(inspectionId, languageCode);
            
            reportPlaceholders.SetBuildingDetails(detail);
            reportPlaceholders.SetGeneralInformation(GetGeneralInformation(buildingId, languageCode));
            /*reportPlaceholders.SetWaterSupply(fireHydrantService.GetFormFireHydrants(inspectionId, languageCode));
            reportPlaceholders.SetPersonRequiringAssistance(pnapService.GetListLocalized(languageCode, buildingId));
            reportPlaceholders.SetHazardousMaterials(hazardousMaterialService.GetListLocalized(languageCode, buildingId));
            reportPlaceholders.SetFireProtectionAlarmPanels(alarmPanelService.GetListLocalized(languageCode, buildingId));
            reportPlaceholders.SetContact(contactService.GetListLocalized(buildingId, languageCode));

            var courses = courseService.GetCourses(inspectionId);
            reportPlaceholders.SetCourses(courses, GetCourseLanes(courses, languageCode));
            
            var sprinklers = sprinklerService.GetListLocalized(languageCode, buildingId);
            reportPlaceholders.SetFireProtectionSprinklers(sprinklers);*/

            var surveySummary = questionService.GetInspectionQuestionSummaryListLocalized(inspectionId, languageCode);
            reportPlaceholders.SetSurvey(surveySummary);
            
            // Particular risks
            /*var foundationRisks = particularRiskService.Get<FoundationParticularRisk>(buildingId);
            var floorRisks = particularRiskService.Get<FloorParticularRisk>(buildingId);
            var wallRisks = particularRiskService.Get<WallParticularRisk>(buildingId);
            var roofRisks = particularRiskService.Get<RoofParticularRisk>(buildingId);

            reportPlaceholders.SetParticulerRiskFoundationProperties(foundationRisks, 
                particularRiskPictureService.GetAnomalyPictures(foundationRisks.Id));
            reportPlaceholders.SetParticulerRiskFloorProperties(floorRisks, 
                particularRiskPictureService.GetAnomalyPictures(floorRisks.Id));
            reportPlaceholders.SetParticulerRiskWallProperties(wallRisks, 
                particularRiskPictureService.GetAnomalyPictures(wallRisks.Id));
            reportPlaceholders.SetParticulerRiskRoofProperties(roofRisks, 
                particularRiskPictureService.GetAnomalyPictures(roofRisks.Id));*/

            // Direct assignation
            reportPlaceholders.Transversal = GetTransversal(inspectionId, languageCode);
            //reportPlaceholders.Anomalies = SetAnomalies(buildingId);
            
            return reportPlaceholders;
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

        /*private Dictionary<Guid, InspectionBuildingCourseWithLanes> GetCourseLanes(List<InspectionBuildingCourseForList> courses, string languageCode)
        {
            var lanesDictionary = new Dictionary<Guid, InspectionBuildingCourseWithLanes>();
            foreach (var course in courses)
            {
                lanesDictionary.Add(course.Id, courseService.GetCourse(course.Id, languageCode));
            }

            return lanesDictionary;
        }*/
        
        /*
         * Because of the data structure, it is simpler to generate the string for Anomalies here instead of in
         * ReportPlaceholers.cs
         */
        /*private string SetAnomalies(Guid idBuilding)
        {
            var anomalies = anomalyService.GetListForWeb(idBuilding);
            var report = "";
            foreach (var theme in anomalies)
            {
                report += "<h3>" + theme.Theme + "</h3>\n";
                foreach (var anomaly in theme.Anomalies)
                {
                    report += "<h4>Notes: " + anomaly.Notes + "</h4>\n";
                    var pictures = anomalyPictureService.GetAnomalyPictures(anomaly.Id);
                    foreach (var picture in pictures)
                    {
                        report += "<img style=\"margin: 20px 20px\" src=\"data:image/png;base64, " + 
                                  picture.PictureData + 
                                  "\" height=\"400\" />\n";
                    }
                }
            }
            return report;
        }*/
    }
}
