using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection.Metadata;
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
        private const double KMarginInMm = 19.05;

        public ReportGenerationService(ManagementContext context) : base(context)
        {
        }
        
        private ReportConfigurationTemplate GetTemplate(Guid id)
        {
            return Context.ReportConfigurationTemplate.FirstOrDefault(t => t.Id == id);
        }

        private ReportPlaceholders SetPlaceholders(Guid buildingId, string languageCode)
        {
            var query =
                from inspection in Context.Inspections
                where inspection.IdBuilding == buildingId && inspection.IsActive
                let building = inspection.MainBuilding
                from laneLocalization in building.Lane.Localizations
                where laneLocalization.IsActive && laneLocalization.LanguageCode == languageCode
                from riskLevelLocalization in building.RiskLevel.Localizations
                where riskLevelLocalization.IsActive && riskLevelLocalization.LanguageCode == languageCode
                select new 
                {
                    civicLetter = building.CivicLetter,
                    civicNumber = building.CivicNumber,
                    matricule = building.Matricule,
                    postalCode = building.PostalCode,
                    riskLevelName = riskLevelLocalization.Name,
                    laneName = laneLocalization.Name,
                    publicDescription = building.Lane.PublicCode.Description,
                    genericDescription = building.Lane.LaneGenericCode.Description,
                    building.Lane.LaneGenericCode.AddWhiteSpaceAfter
                };

            var results = query.First();
            var result = new
                {
                    riskCategory = results.riskLevelName,
                    matricule = results.matricule,
                    zipCode = results.postalCode,
                    address = new AddressGenerator()
                        .GenerateAddress(
                            results.civicNumber,
                            results.civicLetter, 
                            results.laneName,
                            results.genericDescription, 
                            results.publicDescription,
                            results.AddWhiteSpaceAfter
                            )
                };

            
            var reportPlaceholders = new ReportPlaceholders
            {
                //
                RiskCategory = result.riskCategory,
                Assignment = SetAssignment(id),
                Matricule = result.matricule,
                Alias = SetAlias(id),
                Lane = SetLane(id),
                Transversal = SetTransversal(id),
                //
                ImplementationPlan = SetImplementationPlan(id),
                //
                Survey = SetSurveySummary(id, languageCode),
                //
                Address = result.address,
                ZipCode = result.zipCode,
                //
                BuildingType = SetBuildingType(id),
                BuildingGarage = SetBuildingGarage(id),
                BuildingHeight = SetBuildingHeight(id),
                BuildingEstimatedWaterFlow = SetBuildingWaterFlow(id),
                ConstructionType = SetConstructionType(id),
                ConstructionFireResistance = SetConstructionFireResistance(id),
                ConstructionSiding = SetConstructionSiding(id),
                RoofType = SetRoofType(id),
                RoofMaterial = SetRoofMaterial(id)
                
            };
            return reportPlaceholders;
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
            var inspectionTextReport = "";
            if (template != null)
            {
                var reportPlaceholders = SetPlaceholders(buildingId, languageCode);
                inspectionTextReport = reportPlaceholders.ReplacePlaceholders(template.Data);
            }

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
            var wkhtmltopdf = new FileInfo(GetWkhtmltopdfPath());
            var converter = new HtmlToPdfConverter(wkhtmltopdf);
            
            var outputStream = new MemoryStream();
            converter.ConvertToPdf(inputStream, outputStream, settings);
            outputStream.Seek(0, SeekOrigin.Begin);
            streamWriter.Dispose();
            
            return outputStream;
        }
        
        ///
        ///
        ///
        private string SetAssignment(Guid id)
        {
            var inspection = Context.Inspections
                .First(u => u.Id == id);
            var building = Context.Buildings.First(u => u.Id == inspection.IdBuilding);
            var utilisationCodeId = building.IdUtilisationCode;
            var query =
                from utilisationCode in Context.UtilisationCodes
                where utilisationCode.IsActive && utilisationCode.Id == utilisationCodeId
                from localization in utilisationCode.Localizations
                where localization.LanguageCode == "fr"
                select new RiskLevelForWeb
                {
                    Name = localization.Description
                };

            var res = query.SingleOrDefault();
            return res != null ? res.Name : "";
        }
        
        private string SetAlias(Guid id)
        {
            var inspection = Context.Inspections
                .First(u => u.Id == id);
            var query =
                from building in Context.Buildings
                where building.IsActive && building.Id == inspection.IdBuilding
                from localization in building.Localizations
                where localization.LanguageCode == "fr"
                select new RiskLevelForWeb
                {
                    Name = localization.Name
                };

            var res = query.SingleOrDefault();

            return res != null ? res.Name : "";
        }
        
        private string SetLane(Guid id)
        {
            var inspection = Context.Inspections
                .First(u => u.Id == id);
            var building = Context.Buildings.First(u => u.Id == inspection.IdBuilding);
            var laneId = building.IdLane;
            var query =
                from lane in Context.Lanes
                where lane.IsActive && lane.Id == laneId
                from localization in lane.Localizations
                where localization.LanguageCode == "fr"
                select new RiskLevelForWeb
                {
                    Name = localization.Name
                };

            var res = query.SingleOrDefault();

            return res != null ? res.Name : "";
        }
        
        private string SetTransversal(Guid id)
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
                from localization in lane.Localizations
                where localization.LanguageCode == "fr"
                select new RiskLevelForWeb
                {
                    Name = localization.Name
                };

            var res = query.SingleOrDefault();

            return res != null ? res.Name : "";
        }
        
        private string SetImplementationPlan(Guid id)
        {
            var inspection = Context.Inspections
                .First(u => u.Id == id);
            var building = Context.Buildings.First(u => u.Id == inspection.IdBuilding);
            var details = Context.BuildingDetails.FirstOrDefault(u => u.IdBuilding == building.Id);
            
            if (details?.IdPicturePlan == null)
            {
                return "";
            }
            var photo = Context.Pictures
                .First(u => u.Id == details.IdPicturePlan);
            if (photo == null)
            {
                return "";
            }
            var base64String = "<img src=\"data:image/png;base64, " + Convert.ToBase64String(photo.Data) + "\" height=\"400\" />";
            return base64String;
        }
                
        private string SetBuildingType(Guid id)
        {
            var inspection = Context.Inspections
                .First(u => u.Id == id);
            var building = Context.Buildings.First(u => u.Id == inspection.IdBuilding);
            var details = Context.BuildingDetails.FirstOrDefault(u => u.IdBuilding == building.Id);
            
            if (details == null)
            {
                return "";
            }
 
            var query =
                from buildingTypes in Context.BuildingTypes
                where buildingTypes.IsActive && buildingTypes.Id == details.IdBuildingType
                from localization in buildingTypes.Localizations
                where localization.LanguageCode == "fr"
                select new RiskLevelForWeb
                {
                    Name = localization.Name
                };
            var res = query.SingleOrDefault();
            return res == null ? "" : res.Name;
        }
        
        private string SetBuildingGarage(Guid id)
        {
            var inspection = Context.Inspections
                .First(u => u.Id == id);
            var building = Context.Buildings.First(u => u.Id == inspection.IdBuilding);
            var details = Context.BuildingDetails.FirstOrDefault(u => u.IdBuilding == building.Id);
            var val = "Non";
            if (details != null && details.GarageType == GarageType.Detached)
            {
                val = "Détaché";
            }
            else if (details != null && details.GarageType == GarageType.Yes)
            {
                val = "Oui";
            }
            return val;
        }
        
        private string SetBuildingHeight(Guid id)
        {
            var inspection = Context.Inspections
                .First(u => u.Id == id);
            var building = Context.Buildings.First(u => u.Id == inspection.IdBuilding);
            var details = Context.BuildingDetails.FirstOrDefault(u => u.IdBuilding == building.Id);
            var val = "";
            if (details != null)
            {
                val = details.Height.ToString();
            }
            return val;
        }
        
        private string SetBuildingWaterFlow(Guid id)
        {
            var inspection = Context.Inspections
                .First(u => u.Id == id);
            var building = Context.Buildings.First(u => u.Id == inspection.IdBuilding);
            var details = Context.BuildingDetails.FirstOrDefault(u => u.IdBuilding == building.Id);
            var val = "";
            if (details != null)
            {
                val = details.EstimatedWaterFlow.ToString();
            }
            return val;
        }
        
        private string SetConstructionType(Guid id)
        {
            var inspection = Context.Inspections
                .First(u => u.Id == id);
            var building = Context.Buildings.First(u => u.Id == inspection.IdBuilding);
            var details = Context.BuildingDetails.FirstOrDefault(u => u.IdBuilding == building.Id);
            if (details == null)
            {
                return "";
            }
            var query =
                from constructionType in Context.ConstructionTypes
                where constructionType.IsActive && constructionType.Id == details.IdConstructionType
                from localization in constructionType.Localizations
                where localization.LanguageCode == "fr"
                select new RiskLevelForWeb
                {
                    Name = localization.Name
                };
            var res = query.SingleOrDefault();
            return res == null ? "" : res.Name;
        }
        
        private string SetConstructionFireResistance(Guid id)
        {
            var inspection = Context.Inspections
                .First(u => u.Id == id);
            var building = Context.Buildings.First(u => u.Id == inspection.IdBuilding);
            var details = Context.BuildingDetails.FirstOrDefault(u => u.IdBuilding == building.Id);
            if (details == null)
            {
                return "";
            }
            var query =
                from constructionFireResistanceType in Context.ConstructionFireResistanceTypes
                where constructionFireResistanceType.IsActive && 
                constructionFireResistanceType.Id == details.IdConstructionFireResistanceType
                from localization in constructionFireResistanceType.Localizations
                where localization.LanguageCode == "fr"
                select new RiskLevelForWeb
                {
                    Name = localization.Name
                };
            var res = query.SingleOrDefault();
            return res == null ? "" : res.Name;
        }
        
        private string SetConstructionSiding(Guid id)
        {
            var inspection = Context.Inspections
                .First(u => u.Id == id);
            var building = Context.Buildings.First(u => u.Id == inspection.IdBuilding);
            var details = Context.BuildingDetails.FirstOrDefault(u => u.IdBuilding == building.Id);
            if (details == null)
            {
                return "";
            }
            var query =
                from sidingType in Context.SidingTypes
                where sidingType.IsActive && 
                      sidingType.Id == details.IdBuildingSidingType
                from localization in sidingType.Localizations
                where localization.LanguageCode == "fr"
                select new RiskLevelForWeb
                {
                    Name = localization.Name
                };
            var res = query.SingleOrDefault();
            return res == null ? "" : res.Name;
        }
       
        private string SetRoofType(Guid id)
        {
            var inspection = Context.Inspections
                .First(u => u.Id == id);
            var building = Context.Buildings.First(u => u.Id == inspection.IdBuilding);
            var details = Context.BuildingDetails.FirstOrDefault(u => u.IdBuilding == building.Id);
            if (details == null)
            {
                return "";
            }
            var query =
                from roofType in Context.RoofTypes
                where roofType.IsActive && roofType.Id == details.IdRoofType
                from localization in roofType.Localizations
                where localization.LanguageCode == "fr"
                select new RiskLevelForWeb
                {
                    Name = localization.Name
                };
            var res = query.SingleOrDefault();
            return res == null ? "" : res.Name;
        }
        
        private string SetRoofMaterial(Guid id)
        {
            var inspection = Context.Inspections
                .First(u => u.Id == id);
            var building = Context.Buildings.First(u => u.Id == inspection.IdBuilding);
            var details = Context.BuildingDetails.FirstOrDefault(u => u.IdBuilding == building.Id);
            if (details == null)
            {
                return "";
            }
            var query =
                from roofMaterialType in Context.RoofMaterialTypes
                where roofMaterialType.IsActive && roofMaterialType.Id == details.IdRoofMaterialType
                from localization in roofMaterialType.Localizations
                where localization.LanguageCode == "fr"
                select new RiskLevelForWeb
                {
                    Name = localization.Name
                };
            var res = query.SingleOrDefault();
            return res == null ? "" : res.Name;
        }

        private string SetSurveySummary(Guid idInspection, string languageCode)
        {
            var answerSummary = (
                from inspectionQuestion in Context.InspectionQuestions
                from surveyQuestion in Context.SurveyQuestions.Where(sq => sq.IsActive && sq.Id == inspectionQuestion.IdSurveyQuestion)
                join surveyQuestionChoice in Context.SurveyQuestionChoices.Where(sqc => sqc.IsActive) on inspectionQuestion.IdSurveyQuestionChoice equals surveyQuestionChoice.Id into aqc
                from surveyQuestionChoice in aqc.DefaultIfEmpty()
                where inspectionQuestion.IdInspection == idInspection
                orderby inspectionQuestion.CreatedOn
                select new InspectionQuestionForSummary
                {
                    Id = inspectionQuestion.Id,
                    NextQuestionId = surveyQuestion.Id,
                    QuestionTitle = surveyQuestion.Localizations.SingleOrDefault(l => l.IsActive && l.LanguageCode == languageCode).Title,
                    QuestionDescription = surveyQuestion.Localizations.SingleOrDefault(l => l.IsActive && l.LanguageCode == languageCode).Name,
                    Answer = surveyQuestion.QuestionType != 1 ? inspectionQuestion.Answer : surveyQuestionChoice.Localizations.SingleOrDefault(l => l.IsActive && l.LanguageCode == languageCode).Name,
                    QuestionType = surveyQuestion.QuestionType,
                    Sequence = surveyQuestion.Sequence,
                    IsRecursive = surveyQuestion.IsRecursive
					
                }).ToList();

            List<InspectionQuestionForSummary> recursiveList = new RecursiveInspectionQuestionProcess().GroupRecursiveQuestion(answerSummary);

            var groupedTitle =
                from groupedQuestion in recursiveList
                group groupedQuestion by groupedQuestion.QuestionTitle
                into gq
                select new InspectionSummaryCategoryForList
                {
                    Title = gq.Key,
                    AnswerSummary = gq.ToList()
                };

            var summary = groupedTitle.ToList();
            var report = "";
            foreach (var category in summary)
            {
                report += "<h3>" + category.Title + "</h3>\n";
                report += "<table border=\"1\" cellpadding=\"1\" cellspacing=\"1\" style=\"width:8.5in\">\n";
                report += "<tbody>\n";
                for (var i = 0; i < category.AnswerSummary.Count; i++)
                {
                    var recursive = category.AnswerSummary.ElementAt(i);
                    if (recursive.IsRecursive && recursive.RecursiveAnswer.Count != 0)
                    {
                        report += "<h3>" + recursive.QuestionTitle + " #" + (i + 1) + "</h3>\n";
                        foreach (var question in recursive.RecursiveAnswer)
                        {
                            report += "<tr>\n";
                            report += "<td style=\"width:5.5in\">\t" + question.QuestionDescription + "</td>\n";
                            report += "<td style=\"width:3.0in\">\t" + question.Answer + "</td>\n";
                            report += "</tr>\n";
                        }
                    }
                    else
                    {
                        report += "<tr>\n";
                        report += "<td style=\"width:5.5in\">" + recursive.QuestionDescription + "</td>\n";
                        report += "<td style=\"width:3.0in\">" + recursive.Answer + "</td>\n";
                        report += "</tr>\n";
                    }
                }
                report += "</tbody>\n";
                report += "</table>\n";
            }
            return report;
        }
    }
}
