using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;
using Survi.Prevention.Models.Security;
using Survi.Prevention.Models.SurveyManagement;
using System;
using System.Collections.Generic;

namespace Survi.Prevention.Models.InspectionManagement
{
	public class Inspection : BaseModel
	{
		public Guid? IdSurvey { get; set; }
		public Guid IdBuilding { get; set; }
		public Guid IdWebuserCreatedBy { get; set; }
		public Guid? IdWebuserAssignedTo { get; set; }
		public Guid IdBatch { get; set; }

        public int Sequence { get; set; }

		public InspectionStatus Status { get; set; }

		public DateTime? StartedOn { get; set; }
		public DateTime? CompletedOn { get; set; }
		public DateTime? SurveyCompletedOn { get; set; }

		public bool IsSurveyCompleted { get; set; }

		public Batch Batch { get; set; }
		public Survey Survey { get; set; }
		public User CreatedBy { get; set; }
		public User AssignedTo { get; set; }
		public Building MainBuilding { get; set; }

		public ICollection<InspectionVisit> Visits { get; set; }
		public ICollection<InspectionSurveyAnswer> SurveyAnswers { get; set; }

		public ICollection<InspectionBuilding> Buildings { get; set; }
	}
}