using System;

namespace Survi.Prevention.Models.DataTransfertObjects
{
    public class InspectionBuildingDetailForWeb
    {
		public Guid Id { get; set; }
		public Guid? IdDetail { get; set; }
		public Guid IdInspection { get; set; }
		public Guid? IdLaneTransversal { get; set; }
		public Guid? IdPictureSitePlan { get; set; }
		public string OtherInformation { get; set; }
		public Guid IdCity { get; set; }
		public string MainBuildingAddress { get; set; }
		public Guid MainBuildingIdLane { get; set; }
		public string MainBuildingName { get; set; }
		public string MainBuildingMatricule { get; set; }
		public Guid MainBuildingIdRiskLevel { get; set; }
		public Guid? MainBuildingIdUtilisationCode { get; set; }
    }
}
