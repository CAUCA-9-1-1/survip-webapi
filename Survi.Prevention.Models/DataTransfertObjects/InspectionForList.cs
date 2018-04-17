using System;

namespace Survi.Prevention.Models.DataTransfertObjects
{
    public class InspectionForList
    {
		public Guid Id { get; set; }
		public Guid IdBatch { get; set; }
		public string BatchDescription { get; set; }
		public string Matricule { get; set; }
		public object Geojson { get; set; }
		public Guid? IdRiskLevel { get; set; }
		public Guid? IdBuilding { get; set; }
		public Guid? IdInterventionForm { get; set; }
		public string Address { get; set; }
    }
}
