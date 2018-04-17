using System;

namespace Survi.Prevention.Models.DataTransfertObjects
{
    public class InterventionDetailForWeb
    {
		public Guid Id { get; set; }
		public string PlanNumber { get; set; }
		public string PlanName { get; set; }
		public Guid? IdLaneTransversal { get; set; }
		public Guid? IdPictureSitePlan { get; set; }
		public string OtherInformation { get; set; }
		public DateTime CreatedOn { get; set; }
		public bool IsActive { get; set; }
		public Guid IdCity { get; set; }
		public string MainBuildingAddress { get; set; }
		public Guid MainBuildingIdLane { get; set; }
		public string MainBuildingName { get; set; }
		public Guid MainBuildingIdRiskLevel { get; set; }
		public Guid MainBuildingIdUtilisationCode { get; set; }
    }
}
