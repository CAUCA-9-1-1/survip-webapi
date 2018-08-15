using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Survi.Prevention.ServiceLayer 
{
    public class ReportPlaceholders
    {   
        /*
         * Inspection
         */
        
        // General Information
        public string RiskCategory { get; set; }
        public string Assignment { get; set; }
        public string Matricule { get; set; }
        public string Alias { get; set; }
        public string Lane { get; set; }
        public string Transversal { get; set; }
        
        // Implementation Plan
        public string ImplementationPlan { get; set; }

        // Course
        public string Course { get; set; }
        
        // Water Supply
        public string WaterSupply { get; set; }
        
        // Survey
        public string Survey { get; set; }
        
        /*
         * Building
         */
        
        // Address
        public string Address { get; set; }
        public string ZipCode { get; set; }
        
        // Details
        public string BuildingType { get; set; }
        public string BuildingGarage { get; set; }
        public string BuildingHeight { get; set; }
        public string BuildingEstimatedWaterFlow { get; set; }
        public string ConstructionType { get; set; }
        public string ConstructionFireResistance { get; set; }
        public string ConstructionSiding { get; set; }
        public string RoofType { get; set; }
        public string RoofMaterial { get; set; }
        
        // Contact
        public string Contact { get; set; }
        
        // PNAPS
        public string PersonRequiringAssistance { get; set; }
        
        // Hazardous materials
        public string HazardousMaterials { get; set; }
        
        // Fire Protection
        public string FireProtectionAlarmPanels { get; set; }
        public string FireProtectionSprinklers { get; set; }
        
        // Particular Risks Foundation
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

        
        // Anomalies
        public string Anomalies { get; set; }
        
        public string ReplacePlaceholders(string template)
        {
            if (template == null)
                return "";
            var res = Regex.Replace(template, "{{(.*?)}}", m => GetValue(ref m));
            return res;
        }

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
            catch (NullReferenceException e)
            {
                return "{{" + m.Groups[1].Value + "}} Invalid PLACEHOLDER";
            }
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
    }
}
