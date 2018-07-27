using System;
using System.Runtime.Serialization;
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
        
        // Water Supply
        
        // Survey
        
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
            catch (NullReferenceException)
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
