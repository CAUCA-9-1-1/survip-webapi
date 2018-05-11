using System.Collections.Generic;

namespace Survi.Prevention.Models.DataTransfertObjects
{
    public class InspectionBuildingAnomalyThemeForList
    {
		public string Theme { get; set; }
		public List<BuildingAnomalyForList> Anomalies { get; set; }
    }
}
