using System;
using Survi.Prevention.Models.InspectionManagement;

namespace Survi.Prevention.Models.DataTransfertObjects
{
    public class InspectionForList
    {
		public Guid Id { get; set; }
        public InspectionStatus Status { get; set; }

		public Guid IdBatch { get; set; }
		public string BatchDescription { get; set; }
		public string Matricule { get; set; }
		public Guid? IdRiskLevel { get; set; }
		public Guid IdBuilding { get; set; }
        public Guid IdCity { get; set; }
		public string LaneName { get; set; }
        public string CivicNumber { get; set; }
        public string CivicLetter { get; set; }
        public string AliasName { get; set; }
        public string OwnerName { get; set; }
        public string UtilisationCodeDescription { get; set; }
        public string TransversalLaneName { get; set; }  
        public string ApprobationRefusalReason { get; set; }
    }
}
