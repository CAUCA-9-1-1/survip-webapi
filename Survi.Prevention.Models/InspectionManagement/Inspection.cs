using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.InspectionManagement
{
  public class Inspection : BaseModel
  {
    public Guid IdSurvey { get; set; }
    public Guid IdInterventionPlan { get; set; }
    public Guid IdBuilding { get; set; }
    public Guid IdWebuser { get; set; }
    public Guid CreatedBy { get; set; }
    public bool IsCompleted { get; set; }
  }
}
