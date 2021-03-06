﻿using System;
using Survi.Prevention.Models.InspectionManagement;

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
		public string MainBuildingAliasName { get; set; }
        public string MainBuildingCorporateName { get; set; }
		public string MainBuildingMatricule { get; set; }
		public Guid MainBuildingIdRiskLevel { get; set; }
		public Guid? MainBuildingIdUtilisationCode { get; set; }
        public string MainBuildingOwner { get; set; }
	    public Guid? IdBuilding { get; set; }
	    public Guid? IdSurvey { get; set; }
	    public bool IsSurveyCompleted { get; set; }
	    public InspectionStatus Status { get; set; }
	    public string ApprobationRefusalReason { get; set; } = "";
	    public string Coordinates { get; set; }
    }
}
