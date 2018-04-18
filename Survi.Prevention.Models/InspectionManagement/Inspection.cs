using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.SecurityManagement;
using Survi.Prevention.Models.SurveyManagement;

namespace Survi.Prevention.Models.InspectionManagement
{
	public class Inspection : BaseModel
	{
		public Guid? IdSurvey { get; set; }
		public Guid IdInterventionForm { get; set; }
		public Guid IdBuilding { get; set; }
		public Guid? IdWebuserInspectedBy { get; set; }
		public Guid IdWebuserCreatedBy { get; set; }
		public Guid? IdWebUserAssignedTo { get; set; }
		public Guid IdBatch { get; set; }

		public bool IsStarted { get; set; }
		public bool IsCompleted { get; set; }
		public DateTime? StartedOn { get; set; }
		public DateTime? CompletedOn { get; set; }

		public Batch Batch { get; set; }
		public Survey Survey { get; set; }
		public InterventionForm Form { get; set; }
		public Webuser InspectedBy { get; set;}
		public Webuser CreatedBy { get; set; }
		public Webuser AssignedTo { get; set; }
		public Building Building { get; set; }

		public ICollection<InspectionAnswer> Answers { get; set; }
	}
}