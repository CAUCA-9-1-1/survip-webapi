using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Survi.Prevention.Models;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer 
{
    public class ReportPlaceholders
    {   
        /*
         * Inspection
         */
        public string RiskCategory { get; set; }
        public string Assignment { get; set; }
        public string Matricule { get; set; }
        public string Alias { get; set; }
        public string Lane { get; set; }
        public string Transversal { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string ImplementationPlan { get; set; }
        public string Course { get; set; }
        public string WaterSupply { get; set; }
        public string Survey { get; set; }
        
        /*
         * Building
         */
        public string BuildingType { get; set; }
        public string BuildingGarage { get; set; }
        public string BuildingHeight { get; set; }
        public string BuildingEstimatedWaterFlow { get; set; }
        public string ConstructionType { get; set; }
        public string ConstructionFireResistance { get; set; }
        public string ConstructionSiding { get; set; }
        public string RoofType { get; set; }
        public string RoofMaterial { get; set; }
        public string Contact { get; set; }
        public string PersonRequiringAssistance { get; set; }
        public string HazardousMaterials { get; set; }
        public string FireProtectionAlarmPanels { get; set; }
        public string FireProtectionSprinklers { get; set; }
  
        // Particular Risks
        public string ParticularRisksFoundationIsWeakened { get; set; }
        public string ParticularRisksFoundationHasOpening { get; set; }
        public string ParticularRisksFoundationDimension { get; set; }
        public string ParticularRisksFoundationWall { get; set; }
        public string ParticularRisksFoundationSector { get; set; }
        public string ParticularRisksFoundationComments { get; set; }
        public string ParticularRisksFoundationPictures { get; set; }
  
        public string ParticularRisksFloorIsWeakened { get; set; }
        public string ParticularRisksFloorHasOpening { get; set; }
        public string ParticularRisksFloorDimension { get; set; }
        public string ParticularRisksFloorWall { get; set; }
        public string ParticularRisksFloorSector { get; set; }
        public string ParticularRisksFloorComments { get; set; }
        public string ParticularRisksFloorPictures { get; set; }
  
        public string ParticularRisksWallIsWeakened { get; set; }
        public string ParticularRisksWallHasOpening { get; set; }
        public string ParticularRisksWallDimension { get; set; }
        public string ParticularRisksWallWall { get; set; }
        public string ParticularRisksWallSector { get; set; }
        public string ParticularRisksWallComments { get; set; }
        public string ParticularRisksWallPictures { get; set; }
  
        public string ParticularRisksRoofIsWeakened { get; set; }
        public string ParticularRisksRoofHasOpening { get; set; }
        public string ParticularRisksRoofDimension { get; set; }
        public string ParticularRisksRoofWall { get; set; }
        public string ParticularRisksRoofSector { get; set; }
        public string ParticularRisksRoofComments { get; set; }
        public string ParticularRisksRoofPictures { get; set; }

        public string Anomalies { get; set; }
        
        /*
         * End of member variables
         */
        
        private string GetValue(ref Match m)
        {
            try
            {
                return 
                    GetType()
                        .GetProperty(m.Groups[1].Value)
                        .GetValue(this)
                        .ToString();
            }
            catch (NullReferenceException)
            {
                return "{{" + m.Groups[1].Value + "}} Invalid PLACEHOLDER";
            }
        }
        
        public string ReplacePlaceholders(string template)
        {
            if (template == null)
                return "";
            var res = Regex.Replace(template, "{{(.*?)}}", m => GetValue(ref m));
            return res;
        }

        public List<string> GetAvailablePlaceholders()
        {
            var placeholders = new List<string>();
            foreach (var property in GetType().GetProperties())
            {
                placeholders.Add(property.Name);     
            }
            return placeholders;
        }
        
        /*
         * Data setters
         */

        public void SetGeneralInformation(BuildingGeneralInformationForReport generalInformation)
        {
            RiskCategory = generalInformation.RiskCategory;
            Matricule = generalInformation.Matricule;
            Address = generalInformation.Address;
            ZipCode = generalInformation.ZipCode;
            Lane = generalInformation.Lane;
            Alias = generalInformation.Alias;
            Assignment = generalInformation.Assignment;
        }

        public void SetBuildingDetails(BuildingDetailForReport details)
        {
            BuildingType = details.BuildingType;
            BuildingGarage = details.GarageTypeLocalized;
            BuildingHeight = $"{details.BuildingHeight: f2}";
            BuildingEstimatedWaterFlow = details.EstimatedWaterFlow.ToString();
            ConstructionType = details.ConstructionTypeLocalized;
            ConstructionFireResistance = details.ConstructionFireResistanceLocalized;
            ConstructionSiding = details.ConstructionSidingLocalized;
            RoofType = details.RoofTypeLocalized;
            RoofMaterial = details.RoofMaterialLocalized;
            
            SetImplementationPlan(details.ImplementationPlan);
        }

        private void SetImplementationPlan(Picture picture)
        {
            var pictureToText = "";
            if (picture != null)
            {
                pictureToText = "<img src=\"data:image/png;base64, " + Convert.ToBase64String(picture.Data) +
                                   "\" height=\"400\" />";
            }

            ImplementationPlan = pictureToText;
        }

        public void SetSurvey(List<InspectionSummaryCategoryForList> groupedTitle)
        {
            var surveyToText = "";
            foreach (var category in groupedTitle)
            {
                surveyToText += "<h3>" + category.Title + "</h3>\n";
                surveyToText += "<table border=\"1\" cellpadding=\"1\" cellspacing=\"1\" style=\"width:8.5in\">\n";
                surveyToText += "<tbody>\n";
                for (var i = 0; i < category.AnswerSummary.Count; i++)
                {
                    var recursive = category.AnswerSummary.ElementAt(i);
                    if (recursive.IsRecursive && recursive.RecursiveAnswer.Count != 0)
                    {
                        surveyToText += "<h3>" + recursive.QuestionTitle + " #" + (i + 1) + "</h3>\n";
                        foreach (var question in recursive.RecursiveAnswer)
                        {
                            surveyToText += "<tr>\n";
                            surveyToText += "<td style=\"width:5.5in\">\t" + question.QuestionDescription + "</td>\n";
                            surveyToText += "<td style=\"width:3.0in\">\t" + question.Answer + "</td>\n";
                            surveyToText += "</tr>\n";
                        }
                    }
                    else
                    {
                        surveyToText += "<tr>\n";
                        surveyToText += "<td style=\"width:5.5in\">" + recursive.QuestionDescription + "</td>\n";
                        surveyToText += "<td style=\"width:3.0in\">" + recursive.Answer + "</td>\n";
                        surveyToText += "</tr>\n";
                    }
                }
                surveyToText += "</tbody>\n";
                surveyToText += "</table>\n";
            }

            Survey = surveyToText;
        }

        private string SetParticularRiskImage(List<BuildingChildPictureForWeb> pictures)
        {
            var imageToString = "";
            if (pictures == null)
            {
                return imageToString;
            }
            foreach (var picture in pictures)
            {
                imageToString += "<img style=\"margin: 20px 20px\" src=\"data:image/png;base64, " + 
                                 picture.PictureData + 
                                 "\" height=\"400\" />\n";
            }

            return imageToString;
        }
        
        public void SetParticulerRiskFoundationProperties(BuildingParticularRisk risks, List<BuildingChildPictureForWeb> pictures)
        {
            ParticularRisksFoundationIsWeakened = risks.IsWeakened ? "yes" : "no";
            ParticularRisksFoundationHasOpening = risks.HasOpening ? "yes" : "no";
            ParticularRisksFoundationDimension = risks.Dimension;
            ParticularRisksFoundationWall = risks.Wall;
            ParticularRisksFoundationSector = risks.Sector;
            ParticularRisksFoundationComments = risks.Comments;
            ParticularRisksFoundationPictures = SetParticularRiskImage(pictures);
        }
        
        public void SetParticulerRiskFloorProperties(BuildingParticularRisk risks, List<BuildingChildPictureForWeb> pictures)
        {
            ParticularRisksFloorIsWeakened = risks.IsWeakened ? "yes" : "no";
            ParticularRisksFloorHasOpening = risks.HasOpening ? "yes" : "no";
            ParticularRisksFloorDimension = risks.Dimension;
            ParticularRisksFloorWall = risks.Wall;
            ParticularRisksFloorSector = risks.Sector;
            ParticularRisksFloorComments = risks.Comments;
            ParticularRisksFloorPictures = SetParticularRiskImage(pictures);
        }
        
        public void SetParticulerRiskWallProperties(BuildingParticularRisk risks, List<BuildingChildPictureForWeb> pictures)
        {
            ParticularRisksWallIsWeakened = risks.IsWeakened ? "yes" : "no";
            ParticularRisksWallHasOpening = risks.HasOpening ? "yes" : "no";
            ParticularRisksWallDimension = risks.Dimension;
            ParticularRisksWallWall = risks.Wall;
            ParticularRisksWallSector = risks.Sector;
            ParticularRisksWallComments = risks.Comments;
            ParticularRisksWallPictures = SetParticularRiskImage(pictures);

        }
        
        public void SetParticulerRiskRoofProperties(BuildingParticularRisk risks, List<BuildingChildPictureForWeb> pictures)
        {
            ParticularRisksRoofIsWeakened = risks.IsWeakened ? "yes" : "no";
            ParticularRisksRoofHasOpening = risks.HasOpening ? "yes" : "no";
            ParticularRisksRoofDimension = risks.Dimension;
            ParticularRisksRoofWall = risks.Wall;
            ParticularRisksRoofSector = risks.Sector;
            ParticularRisksRoofComments = risks.Comments;
            ParticularRisksRoofPictures = SetParticularRiskImage(pictures);

        }

        public void SetContact(List<BuildingContactForList> contacts)
        {
            var contactToString = "";
            foreach (var contact in contacts)
            {
                contactToString += "<div>" + contact.Name + "</div>\n";
            }

            Contact = contactToString;
        }

        public void SetWaterSupply(List<InspectionBuildingFireHydrantForList> waterSupplies)
        {
            var waterSupplyToString = "";
            foreach (var waterSupply in waterSupplies)
            {
                waterSupplyToString += "<tr>\n";
                waterSupplyToString += "<td>" + waterSupply.Number + "</td>\n";
                waterSupplyToString += "<td>" + waterSupply.Address + "</td>\n";
                waterSupplyToString += "</tr>\n";
            }

            WaterSupply = waterSupplyToString;
        }

        public void SetPersonRequiringAssistance(List<BuildingPersonRequiringAssistanceForList>  pnaps)
        {
            var pnapToString = "";
            pnapToString += "<table border=\"1\" cellpadding=\"1\" cellspacing=\"1\" style=\"width:8.5in\">\n";
            pnapToString += "<tbody>\n";
            foreach (var pnap in pnaps)
            {
                pnapToString += "<tr>\n";
                pnapToString += "<td style=\"width:3.0in\">" + pnap.Name + "</td>\n";
                pnapToString += "<td style=\"width:5.5in\">" + pnap.TypeDescription + "</td>\n";
                pnapToString += "</tr>\n";
            }
            pnapToString += "</tbody>\n";
            pnapToString += "</table>\n";

            PersonRequiringAssistance = pnapToString;
        }

        public void SetHazardousMaterials(List<BuildingHazardousMaterialForList> materials)
        {
            var hazardousMaterialToString = "";
            hazardousMaterialToString += "<table border=\"1\" cellpadding=\"1\" " +
                                         "cellspacing=\"1\" style=\"width:8.5in\">\n";
            hazardousMaterialToString += "<tbody>\n";
            foreach (var material in materials)
            {
                hazardousMaterialToString += "<tr>\n";
                hazardousMaterialToString += "<td style=\"width:3.0in\">" + material.HazardousMaterialName + "</td>\n";
                hazardousMaterialToString += "<td style=\"width:5.5in\">" + material.QuantityDescription + "</td>\n";
                hazardousMaterialToString += "</tr>\n";
            }
            hazardousMaterialToString += "</tbody>\n";
            hazardousMaterialToString += "</table>\n";

            HazardousMaterials = hazardousMaterialToString;
        }

        public void SetFireProtectionAlarmPanels(List<BuildingFireProtectionForList> alarmPanels)
        {
            var alarmPanelsToString = "";
            foreach (var alarmPanel in alarmPanels)
            {
                alarmPanelsToString += "<tr>\n";
                alarmPanelsToString += "<td style=\"width:3.0in\">" + alarmPanel.LocationDescription + "</td>\n";
                alarmPanelsToString += "<td style=\"width:5.5in\">" + alarmPanel.TypeDescription + "</td>\n";
                alarmPanelsToString += "</tr>\n";
            }

            FireProtectionAlarmPanels = alarmPanelsToString;
        }

        public void SetFireProtectionSprinklers(List<BuildingFireProtectionForList> sprinklers)
        {
            var sprinklerToString = "";
            foreach (var sprinkler in sprinklers)
            {
                sprinklerToString += "<tr>\n";
                sprinklerToString += "<td style=\"width:3.0in\">" + sprinkler.LocationDescription + "</td>\n";
                sprinklerToString += "<td style=\"width:5.5in\">" + sprinkler.TypeDescription + "</td>\n";
                sprinklerToString += "</tr>\n";
            }

            FireProtectionSprinklers = sprinklerToString;
        }

        public void SetCourses(List<InspectionBuildingCourseForList> courses, Dictionary<Guid, InspectionBuildingCourseWithLanes> lanesDictionary)
        {
            var coursesToString = "";
            foreach (var course in courses)
            {
                var lanes = lanesDictionary[course.Id].Lanes;
                var orderedLanes = lanes.OrderByDescending(lane => lane.Sequence);
                coursesToString += "<h3>" + course.Description + "</h3>\n";
                foreach (var lane in orderedLanes)
                {
                    coursesToString += "<div>" + lane.Description + "</div>\n";
                }
            }
            courses.Sort();

            Course = coursesToString;
        }
    }
}
